---
layout: post
title:  "Ninety-Eight: Coding"
date:   2019-02-05 09:40:18 -0600
categories: ADDER
image: images/King_playing_cards.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

For our third game, we will look at [Ninety-Eight](https://www.pagat.com/adders/98.html), 
a simple game from the [adding](https://www.pagat.com/adders/) genre of care games, which also includes 
[Cribbage](https://www.pagat.com/adders/crib6.html).
Sometimes called [Ninety-Nine](https://en.wikipedia.org/wiki/Ninety-nine_(addition_card_game)),
this game is alternately described as a [great game for kids to learn addition](http://www.cuppacocoa.com/math-game-99/), 
or a great [drinking game](https://en.wikipedia.org/wiki/Drinking_game) for adults. It's simple core
mechanism has been expanded into a few commercial games such as
[O'NO 99](https://boardgamegeek.com/boardgame/7803/ono-99),
[BOOMO](https://boardgamegeek.com/boardgame/1333/boom-o), and
[5 Alive](https://boardgamegeek.com/boardgame/1961/5-alive). 

First, let's see how you play!

### Rules

>Shuffle a standard deck of cards, and deal four cards face down to each player. Players
then take turns playing one card to the top of a discard pile and drawing a
replacement from the deck. The goal is to keep the total 
value of all cards in the discard pile less than or equal to 98. 
Ace through 9 are worth their number value (Ace equals 1). The
Jack and Queen are worth 0 points, while the ten is worth -10 points. The King
sets the value of the discard pile to 98. The player who
makes the total above 98 loses the game. 

### RECYCLE Coding

To illustrate how we encode these rules computationally, we will
walk through in detail the [RECYCLE](https://cardstock.readthedocs.io/en/latest/recycle/index.html) 
code for Ninety-Eight. Ninety-Eight is one of the smallest games in terms of rules and 
coding that we will examine.

First, we create the players and the (currently irrelevant) teams, followed by the standard
[French deck](https://en.wikipedia.org/wiki/French_playing_cards) of 52 cards.

{% highlight racket %}
(game
 (setup  
  (create players 4)
  (create teams (0) (1) (2) (3))
  (create deck (game iloc STOCK) (deck (RANK (A, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, J, Q, K))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (CLUBS, SPADES))))))) 
{% endhighlight %}

The point values of the Ace through 9 cards are assigned in a PointMap. The other card ranks
are left out, and will return a value of 0 when this `'PRECEDENCE` map is used.

{% highlight racket %}
 (do 
     (
      (put points 'PRECEDENCE 
           (
            ((RANK (NINE)) 9)
            ((RANK (EIGHT)) 8)
            ((RANK (SEVEN)) 7)
            ((RANK (SIX)) 6)
            ((RANK (FIVE)) 5)
            ((RANK (FOUR)) 4)
            ((RANK (THREE)) 3)
            ((RANK (TWO)) 2)
            ((RANK (A)) 1)))
{% endhighlight %}
      
To start off the game, each player is dealt 4 cards from the face-down `STOCK` to put in their 
private `HAND` location.
      
{% highlight racket %}
      (shuffle (game iloc STOCK))
      (all player 'P 
           (repeat 4 
                   (move (top (game iloc STOCK)) 
                         (top ('P iloc HAND))))))) 
{% endhighlight %}
 
There is only one stage in Ninety-Eight, which cycles through each player in turn until
someone has caused the total point value of the discard pile to go over 98. The
total value of the discard `PILE` will be tracked in an integer storage called `POINTS`.

In this stage, each player is free to choose any of the cards in their `HAND` location to
move to the top of the discard `PILE` location.
 
{% highlight racket %}
 (stage player
        (end 
         (> (game sto POINTS) 98))
        
        (choice 
         (
          (any ((current player) iloc HAND) 'C
               (move 'C 
                     (top (game vloc PILE))))))
{% endhighlight %}
    
After a player's turn, the game updates the `POINTS` storage based on the card played.
If it was an Ace through 9, then the value is simply incremented. If it was a King, 
then the value is set to 98. If it was a ten, then the value is decremented by 10.

One card is then dealt to the current player from the `STOCK`.

Finally, if the value of `POINTS` is above 98, the current player is declared the loser
by decreasing their `SCORE`.
        
{% highlight racket %}
        (do 
            (
             (inc (game sto POINTS) (score (top (game vloc PILE)) using 'PRECEDENCE)) 
             ((== (cardatt RANK (top (game vloc PILE))) K)
              (set (game sto POINTS) 98))
             ((== (cardatt RANK (top (game vloc PILE))) TEN)
              (dec (game sto POINTS) 10))
             ((> (size (game iloc STOCK)) 0) 
              (move (top (game iloc STOCK)) 
                    (top ((current player) iloc HAND))))
             ((> (game sto POINTS) 98) 
              (dec ((current player) sto SCORE) 1)))))				
{% endhighlight %}
 
At the end of the game, we look at the scores of the players to determine the winner. These numbers will
be either 0 if you won, and -1 if you lost.
 
{% highlight racket %}
 (scoring max ((current player) sto SCORE)))
{% endhighlight %}

### Up Next

Ninety-eight is simple, but is it too simple to be interesting?

In the next post,
we'll ask, 
does the player have **choices**, and is there opportunity for **strategy**? We'll 
also look at the way AI players affect the length of the game for Ninety-Eight.

Image courtesy of https://en.wikipedia.org/wiki/Ninety-nine_(addition_card_game)#/media/File:King_playing_cards.jpg.