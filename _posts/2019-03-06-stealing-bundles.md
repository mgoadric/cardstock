---
title: 'Stealing Bundles: Coding'
date: 2019-03-06 15:40:18 Z
categories:
- FISHING
layout: post
image: images/kindling-bundle.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

For our fourth game, we will look at [Stealing Bundles](https://www.pagat.com/fishing/bundle.html), 
an easy game from the [fishing](https://www.pagat.com/fishing/) genre of card games. 
Fishing games are popular all over the world, and Stealing Bundles shares
the core mechanic found in more complicated games like 
[Scopa](https://www.pagat.com/fishing/scopone.html), 
[Hachi-Hachi](https://vingel8.neocities.org/hachihachi.html) and 
[Casino](https://www.pagat.com/fishing/casino.html), although without some 
of the more complicated matching components. There is enough different in the structure of fishing games to make them a refreshing
experience to those used to trick-taking games, while retaining the elements of timing
and critical card-counting. Stealing Bundles is 
often found in the kid's section of card game rule books, perhaps
denoting the limited strategy corresponding to the limited rules.

First, let's see how you play!

### Rules

>Shuffle a standard deck of cards. Each player receives four cards, with an 
extra set of four cards dealt face up to the middle of the table to form
the pool. On their turn, players play one card face up from their hand. If their card matches
any cards in the pool based on rank, they collect all such matched cards and their played card. These cards
are added face up on top of any previously collected cards, thus forming a bundle. 
In addition, if their played card matches the top card of any other player's bundle,
they steal this whole bundle and add it on top of their own bundle. If there are no matches,
the played card is added to the central pool.
When all cards have been played, if there are still cards in the draw pile,
deal each player another four cards and repeat the process above. The player with the 
largest bundle at the end of the game is the winner.

### RECYCLE Coding

To illustrate how we encode these rules computationally, we will
walk through in detail the [RECYCLE](https://cardstock.readthedocs.io/en/latest/recycle/index.html) 
code for Stealing Bundles. 

First, we create the players and the (still irrelevant) teams, followed by the standard
[French deck](https://en.wikipedia.org/wiki/French_playing_cards) of 52 cards.

{% highlight racket %}
(game
 (setup  
  (create players 4)
  (create teams (0) (1) (2) (3))
  (create deck (game iloc STOCK) (deck (RANK (A, TWO, THREE, FOUR, FIVE, SIX, 
                                              SEVEN, EIGHT, NINE, TEN, J, Q, K))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (CLUBS, SPADES)))))))        
{% endhighlight %}

To start the game, four cards are dealt from the `STOCK` into the visible `POOL` location on
the table.

{% highlight racket %}
 (do 
     (
      (shuffle (game iloc STOCK))  
      (repeat 4
              (move (top (game iloc STOCK))
                    (top (game vloc POOL))))))  
{% endhighlight %}

Next, we have an outer stage over the players which repeats until
the `STOCK` is empty of cards. Each time we start this stage,
the players are dealt four cards into their invisible `HAND` location.


{% highlight racket %}
 (stage player
        (end 
         (== (size (game iloc STOCK)) 0))
        
        (do 
            (
             (all player 'P
                  (repeat 4
                          (move (top (game iloc STOCK))
                                (top ('P iloc HAND)))))))      
{% endhighlight %}

The inner stage repeats until each player is out of cards in their
`HAND`. On their turn, the current player chooses to play
any card from their hand into a temporary location called `TRICK`.

{% highlight racket %}
        (stage player
               (end 
                (all player 'P 
                     (== (size ('P iloc HAND)) 0)))
               
               (choice 
                (
                 (do 
                     (
                      (any ((current player) iloc HAND) 'AC
                           (move 'AC 
                                 (top ((current player) vloc TRICK))))))))
{% endhighlight %}

Now, we determine if the played `TRICK` card has any matches. We first assume 
it matches nothing by setting `MATCH` to 0.

{% highlight racket %}
   (do 
       (
        (set ((current player) sto MATCH) 0)
               
{% endhighlight %}

We then check to see if the `TRICK` card matches the top of any other player's
`BUNDLE` location based on the `RANK` attribute. If so, we need to move these cards to the current player's 
`BUNDLE`. We do this from bottom to top so that the last card moved is the 
matching card. After movement, we set the `MATCH` variable to 1 to denote
a match was found.

{% highlight racket %}
    (any (other player) 'P
         (do 
             (
              ((== (cardatt RANK (top ('P vloc BUNDLE)))
                   (cardatt RANK (top ((current player) vloc TRICK))))
               (do 
                   (
                    (repeat all
                            (move (bottom ('P vloc BUNDLE)) 
                                  (top ((current player) vloc BUNDLE))))
                    (set ((current player) sto MATCH) 1)))))))
               
        
{% endhighlight %}

Next, we check to see if the `TRICK` card matches any card in the pool. We create a 
filter of all cards in the pool that match on the `RANK` card attribute. Then we
iterate through these matches, calling each card in the filter `'PCF`, and 
moving it to the current player's `BUNDLE`.
After movement, we set the `MATCH` variable to 1 to denote
a match was found. Note that the order in which we check for matches is not important. 
This code could have been swapped for the section above without changing the game. 

{% highlight racket %}
   (all (filter (game vloc POOL) 'PC 
                 (== (cardatt RANK 'PC)
                     (cardatt RANK (top ((current player) vloc TRICK)))))
         'PCF
                   (do 
                       (
                        (move 'PCF 
                              (top ((current player) vloc BUNDLE)))
                        (set ((current player) sto MATCH) 1))))
                     
{% endhighlight %}

Finally, we determine where to place the `TRICK` card. It goes in the `POOL`
if there were no matches, and in the current player's `BUNDLE` if a match
was found.

{% highlight racket %}
    ((== ((current player) sto MATCH) 0)     
     (move (top ((current player) vloc TRICK))
           (top (game vloc POOL))))
    
    ((== ((current player) sto MATCH) 1)
     (move (top ((current player) vloc TRICK))
           (top ((current player) vloc BUNDLE))))))))        
{% endhighlight %}

We score using the size of the `BUNDLE` location, and sort these scores from 
maximum to minimum, with the highest being the winner.

{% highlight racket %}
 (scoring max (size ((current player) vloc BUNDLE))))
{% endhighlight %}

### Up Next

With the rules explained and coded, we can run simulations to gather basic statistics
and evaluate the game play and feel with heuristics! There's some interesting structure 
that we'll see in these upcoming charts, can't wait to share them. I'm always surprised 
at how different the lead histories look for each game and the stories they tell.
More coming soon! 