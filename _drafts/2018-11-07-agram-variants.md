---
layout: post
title:  "Agram"
date:   2018-11-07 09:43:18 -0600
categories: TRICK-TAKING
image: images/playing-cards.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

When we started the [CardStock](http://github.com/mgoadric/cardstock) project, we began with games that were short enough to 
quickly run simulations, yet allowed for elements of skillful play.
[Agram](https://www.pagat.com/last/agram.html), a simple Nigerian trick-taking card game for 2 to 6 players, fit 
the bill perfectly. To get the blog started and show what we'll be covering,
here is an updated version of [our analysis of Agram](http://mark.goadrich.com/articles/issue-2-1-09-recycled.pdf) 
that appeared in Volume 2, Number 1, of
[Game & Puzzle Design](http://gapdjournal.com/).

### Rules

> Agram uses a [stripped](https://en.wikipedia.org/wiki/Stripped_deck) French deck of only 35 cards, 
consisting of A3456789T in all suits, but removing the Ace of Spades.
In Agram, players are dealt six cards from the deck, and play six tricks. 
To win a trick, players must follow the suit of the lead player with a higher card; 
there is no trump suit. The object of the game is to **win the last trick**.

### RECYCLE Coding

To illustrate how we encode these rules computationally, we will
walk through in detail the [RECYCLE](https://cardstock.readthedocs.io/en/latest/recycle/index.html) code for Agram.

First, the number of players are defined as 4, and the players are created. 
The teams are defined as individuals, indicating no alliances. The deck is instantiated to 
the invisible `STOCK` location which belongs to the game. Because the rules for Agram dictate that there is no 
Ace of Spades, two separate `create deck` calls were necessary.

{% highlight racket %}
(game
 (declare 4 'NUMP)
 (setup
  (create players 'NUMP)
  (create teams (0) (1) (2) (3))

  (create deck (game iloc STOCK) (deck (RANK (THREE, FOUR, FIVE, SIX, 
                                              SEVEN, EIGHT, NINE, TEN))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (SPADES, CLUBS))))))
  (create deck (game iloc STOCK) (deck (RANK (ACE))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (CLUBS)))))))
{% endhighlight %}

Next, the `STOCK` location, now containing all of the requisite cards, is shuffled, and 6 cards are dealt to each player
into their invisible `HAND` location.

{% highlight racket %}
(do
 (
  (shuffle (game iloc STOCK))
  (all player 'P
       (repeat 6
               (move (top (game iloc STOCK))
                     (top ('P iloc HAND)))))))
{% endhighlight %}

Two nested stages are needed to play the game. The outer stage is over when all players have 
a `HAND` size of 0, so it will cycle for each trick in the game. The inner stage is over
when all players have moved a card to their visible `TRICK` location, so it cycles through
the players one at a time as they play a card to the trick. Because we need to know who
owns the cards to determine who wins the trick, we don't put the cards into one `TRICK` location 
belonging to the game. In physical card games, we can tell who played what card 
because of the orientation of the cards, as well as the player's memory.

{% highlight racket %}

(stage player
    (end
     (all player 'P
          (== (size ('P iloc HAND)) 0)))

    (stage player
           (end
            (all player 'P
                 (> (size ('P vloc TRICK)) 0)))
{% endhighlight %}

Each player gets to choose a card to play for the trick, given that they follow the rules of play. There
are three possible situations a player might be in when it is their turn.

* First player, who can play anything
* Following player, having a card of the same suit that has been led
* Following player, unable to follow suit

We first handle the case in which at least the first card of the trick has been played and the 
current player is unable to follow suit. They are therefore allowed to play any card from 
their invisible `HAND` to their visible `TRICK` location.

{% highlight racket %}
(choice
    (
     ((and (== (size (game mem LEAD)) 1)
           (== (size (filter ((current player) iloc HAND) 'C
                             (== (cardatt SUIT 'C)
                                 (cardatt SUIT (top (game mem LEAD)))))) 0))
      (any ((current player) iloc HAND) 'AC
           (move 'AC
                 (top ((current player) vloc TRICK)))))
{% endhighlight %}

Next, we handle the case in which at least the first card of the trick has been played and 
the player can (and therefore must) play a card which follows suit.

{% highlight racket %}
(any (filter ((current player) iloc HAND) 'T
              (== (cardatt SUIT 'T)
                  (cardatt SUIT (top (game mem LEAD)))))
       'C
                ((== (size (game mem LEAD)) 1)
                 (move 'C
                       (top ((current player) vloc TRICK)))))
{% endhighlight %}

Finally, we give the first player the freedom to play any card, and subsequently 
`remember` that card to the `LEAD` location, ensuring that the following 
players will be forced into one of the two cases above.

{% highlight racket %}
 ((== (size (game mem LEAD)) 0)
  (any ((current player) iloc HAND) 'AC
       (do
           (
            (move 'AC
                  (top ((current player) vloc TRICK)))
            (remember (top ((current player) vloc TRICK))
                      (top (game mem LEAD))))))))))
{% endhighlight %}

With the trick playing complete, we return to the outer stage.
The following `do` block creates a point map indicating how 
the cards are ranked. The `LEAD` suit is given higher precedence by 
adding 100 to each point value for those cards in that suit. 

We then clear the `LEAD` memory location, set the next leader to be the player who holds 
the winning card, and moves the cards from the last trick into the visible `DISCARD` location. 

In the event all of the players' `HAND` locations are empty, indicating the game is over, 
the game awards 1 point to the player who won the most recent trick. 

{% highlight racket %}
(do
    (
     ;; solidfy card precedence with LEAD suit
     (put points 'PRECEDENCE
          (
           ((SUIT (cardatt SUIT (top (game mem LEAD)))) 100)
           ((RANK (ACE)) 14)
           ((RANK (TEN)) 10)
           ((RANK (NINE)) 9)
           ((RANK (EIGHT)) 8)
           ((RANK (SEVEN)) 7)
           ((RANK (SIX)) 6)
           ((RANK (FIVE)) 5)
           ((RANK (FOUR)) 4)
           ((RANK (THREE)) 3)))

     ;; forget the LEAD card for next round
     (forget (top (game mem LEAD)))
     
     ;; determine who won the hand, set them first next time
     (cycle next (owner (max (union (all player 'P ('P vloc TRICK))) using 'PRECEDENCE)))

     ;; discard cards
     (all player 'P
          (move (top ('P vloc TRICK))
                (top (game vloc DISCARD))))

     ;; if that was the last round, give the winner a point
     ((all player 'P
           (== (size ('P iloc HAND)) 0))
      (inc ((next player) sto SCORE) 1)))))
{% endhighlight %}

Finally, the `scoring` code indicates that the winner of the game is the player with the 
highest value in their `SCORE` storage bin. 
From the prior rules we know that only one player will receive a point each game, making 
this a decidable and unique maximum value and owner.

{% highlight racket %}
(scoring max ((current player) sto SCORE)))
{% endhighlight %}

### Basic Game Statistics

With the game coded, we can run many simulations in CardStock with both random and AI 
players to try and understand how the game works. Random players make a choice in the 
game using a uniform distribution across each choice, while the AI players use 
statistics of random simulations for each choice to determine their
best chance of winning. The AI strategy we use most often is 
called a *Perfect Information Pure Monte Carlo Player* (PIPMC), with more
details on exactly how it plays the games given [here](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html).

Our earlier work with Agram looked at two main issues, 
does the player have **choices**, and is there opportunity for **strategy**? 

#### Are there sufficient choices for players?

The below image shows the average player decision branching factor in a four-player game 
using random players. 
This is actually a summary of four graphs, aggregated depending on the player's turn order in relation to the lead 
player for each trick. 

![Agram Branching Factor]({{site.url}}{{site.baseurl}}/images/agram/AgramBFRev.png){:class="post-image"}

We can see the effect of being forced to follow suit when possible. 
The lead player can always play whatever card they desire, but following players are then 
limited to approximately 2.5 card choices on average for the first three tricks and 
tapering off thereafter. There is a definite advantage to being in the lead player in terms of player choice.

#### Can players be strategic in Agram?

![Agram AI]({{site.url}}{{site.baseurl}}/images/agram/AgramIntelligent.png){:class="post-image"}

To investigate the potential for strategy in Agram, we ran simulations for 2 through 5 players, 
using one PIPMC with the remaining players random. We can see above the win percentage for the 
PIPMC player in comparison to the expected probability of winning for a random player, 
given the assumption that the game is balanced. PIPMC players are able to control their 
fate, outperforming the expected value by approximately 20 percentage points across all 
player sizes. However, there is still enough randomness in the game to confound their 
ability to win. 

### Advanced Heuristics

Explain elsewhere, on documentation page

![Agram One AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/agram/oneairankestimate.png){:class="post-image"}

![Agram All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/agram/allairankestimate.png){:class="post-image"}

![Agram Heuristics]({{site.url}}{{site.baseurl}}/images/agram/heuristics.png){:class="post-image"}

MeaningfulMoves

Variance

Fairness

Drama

Decisiveness

Clarity

Coolness

### Variants

We can easily explore variants of Agram by changing one number in the RECYCLE description. 
Our first set of variants altered **the number of cards dealt** to each player from one to six, 
while fixing the number of players at two. The next figure shows the results for each 
hand size using random players. We can see that with four, five or six cards, the game 
appears fair, however, a clear bias for the first player emerges as the number of cards is 
reduced. We believe that because the suit led becomes the highest precedence, it is very 
unlikely in such limited games that the following player is able to follow suit and 
thus is doomed to failure. 

![Agram Fairness]({{site.url}}{{site.baseurl}}/images/agram/agramone.png){:class="post-image"}
    
These results track with the known variants of Agram. In particular, the version in 
which players are dealt only five cards instead of six is known as [Sink-Sink](https://www.pagat.com/last/agram.html). 
There are no established variants of smaller size, perhaps due to a human player's refusal to repeatedly play a game that is unfair.

![Agram Fairness2]({{site.url}}{{site.baseurl}}/images/agram/agramtwo.png){:class="post-image"}

Our second set of variants retains the deal of six cards, but changes **the number of 
tricks played** before determining the winner. As above, we fix the number of players 
at two and run simulations with random players. In the above figure, we see that 
most variants are relatively balanced games, except for when the game is decided 
after playing only one trick.

### Conclusions


