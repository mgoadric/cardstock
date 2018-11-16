---
layout: post
title:  "Pairs"
date:   2018-11-07 09:46:18 -0600
categories: PRESS-YOUR-LUCK
image: images/pairs.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

[Pairs](https://boardgamegeek.com/boardgame/152237/pairs) is a press-your-luck card game 
for 2 to 6 players, described by designers 
James Ernest and Paul Peterson as *a new classic pub game*.

### Rules

>Pairs uses a custom deck of 55 cards, containing one card of value 1, two cards of 
value 2, etc., up to ten cards of value 10. Each round players are dealt one card to a 
face-up hand, and then players cycle in turn order to either end the round by scoring 
the minimum value card in play or draw another card into their hand. If the drawn card 
is the same value as a card currently in their hand, the player scores that many points 
and the round is over. The first player to score a set number of points over multiple 
rounds is the loser, so players strive to minimize their points.

### RECYCLE Coding

To illustrate how the previous elements can be combined to create a complete game, 
on the following page we include a full encoding of Agram.

{% highlight racket %}
(game
 (declare 2 'NUMP)
 (setup  
  (create players 'NUMP)
  (create teams (0) (1))
  
  ;; Create the deck source
  (repeat 1 (create deck (game iloc STOCK) (deck (VALUE (ONE))))) 
  (repeat 2 (create deck (game iloc STOCK) (deck (VALUE (TWO)))))        
  (repeat 3 (create deck (game iloc STOCK) (deck (VALUE (THREE)))))         
  (repeat 4 (create deck (game iloc STOCK) (deck (VALUE (FOUR)))))       
  (repeat 5 (create deck (game iloc STOCK) (deck (VALUE (FIVE)))))        
  (repeat 6 (create deck (game iloc STOCK) (deck (VALUE (SIX)))))       
  (repeat 7 (create deck (game iloc STOCK) (deck (VALUE (SEVEN)))))         
  (repeat 8 (create deck (game iloc STOCK) (deck (VALUE (EIGHT)))))         
  (repeat 9 (create deck (game iloc STOCK) (deck (VALUE (NINE)))))       
  (repeat 10 (create deck (game iloc STOCK) (deck (VALUE (TEN))))))        
{% endhighlight %}
 
{% highlight racket %}
 (do 
     (
      (put points 'POINTS 
           (
            ((VALUE (TEN)) 10)
            ((VALUE (NINE)) 9)
            ((VALUE (EIGHT)) 8)
            ((VALUE (SEVEN)) 7)
            ((VALUE (SIX)) 6)
            ((VALUE (FIVE)) 5)
            ((VALUE (FOUR)) 4)
            ((VALUE (THREE)) 3)
            ((VALUE (TWO)) 2)
            ((VALUE (ONE)) 1)))
      
      (shuffle (game iloc STOCK))
      (repeat 5 
              (move (top (game iloc STOCK))
                    (top (game iloc THROWOUT)))))) 
{% endhighlight %}
 
{% highlight racket %}
 ;; Play the game until one player has enough points to lose
 (stage player
        (end 
         (any player 'P 
              (>= (sum ('P vloc SCORING) using 'POINTS) (+ (// 60 'NUMP) 1))))
        
{% endhighlight %}
 
{% highlight racket %}
        (do 
            (
             
             ;; Reset the deck if not enough cards
             ((< (size (game iloc STOCK)) 'NUMP)
              (do 
                  (
                   (repeat all
                           (move (top (game iloc THROWOUT))
                                 (top (game iloc STOCK))))
                   (repeat all
                           (move (top (game vloc DISCARD))
                                 (top (game iloc STOCK))))
                   (shuffle (game iloc STOCK))
                   (repeat 5 
                           (move (top (game iloc STOCK))
                                 (top (game iloc THROWOUT)))))))
{% endhighlight %}
 
{% highlight racket %}
             ;; Give each player a card
             (all player 'P 
                  (move (top (game iloc STOCK))
                        (top ('P vloc HAND))))
             
             ;; TODO Stage here, find the player with smallest card
             ;; if tied, deal new card and try again
             ;; Stage, for tied players if dealt a pair, then discard and do it again
             (cycle current (owner (min (union (all player 'P 
                                                    ('P vloc HAND))) using 'POINTS)))))
{% endhighlight %}
 
{% highlight racket %}
        ;; Players take turns pressing their luck until one has pair or stops
        (stage player
               (end 
                (== (game sto FINISHED) 1))
               
               (do   
                   (
                    
                    ;; Reset the deck if not enough cards
                    ((== (size (game iloc STOCK)) 0)
                     (do 
                         (
                          (repeat all
                                  (move (top (game iloc THROWOUT))
                                        (top (game iloc STOCK))))
                          (repeat all
                                  (move (top (game vloc DISCARD))
                                        (top (game iloc STOCK))))
                          (shuffle (game iloc STOCK))
                          (repeat 5 
                                  (move (top (game iloc STOCK))
                                        (top (game iloc THROWOUT)))))))))
{% endhighlight %}
 
{% highlight racket %}
               ;; players flip a card or bow out
               (choice 
                (
                 (do 
                     (
                      (move (actual (min (union (all player 'P ('P vloc HAND))) using 'POINTS))
                            (top ((current player) vloc SCORING)))
                      (set (game sto FINISHED) 1)))
                 
                 (move (top (game iloc STOCK))
                       (top ((current player) vloc HAND)))))
               
{% endhighlight %}
 
{% highlight racket %}
               ;; if pair, end the round
               ;; current player is similar to how all players was used previously, is this ok?
               (do 
                   (
                    ((> (size (tuples 2 ((current player) vloc HAND) using 'POINTS)) 0)
                     (do 
                         (
                          (set (game sto FINISHED) 1)
                          (move (actual (top (top (tuples 2 ((current player) vloc HAND) using 'POINTS))))
                                (top ((current player) vloc SCORING)))))))))
        
{% endhighlight %}
 
{% highlight racket %}
        ;; Move all cards back to the discard pile
        (do 
            (
             (all player 'P
                  (repeat all
                          (move (top ('P vloc HAND))
                                (top (game vloc DISCARD)))))
             (set (game sto FINISHED) 0))))
 
{% endhighlight %}
 
{% highlight racket %}
 ;; Player with the lowest sum of points in their scoring pile wins
 (scoring min (sum ((current player) vloc SCORING) using 'POINTS)))
{% endhighlight %}


### Basic Game Statistics

#### Are there sufficient choices for players?

Unlike Agram, Pairs is very consistent in the number of choices a player has on their turn: **always 2**.
A player can either end their turn, or flip up a new card from the `STOCK`.

#### Can players be strategic in Pairs?  

We ran simulations for 2 through 5 players, using one PIPMC and leaving the remaining 
players random. 

![Pairs Win Prob]({{site.url}}{{site.baseurl}}/images/pairs/winprob.png){:class="post-image"}

Since the goal in Pairs is to not lose as opposed to win, we show below 
the non-loss percentage for the PIPMC player in 
comparison to the expected probability of not losing for a random player, given 
the assumption that the game is fair. We can see the PIPMC is drastically better 
than the uniform random players, quickly approaching a non-loss probability of 1.

![Pairs Markov Gain]({{site.url}}{{site.baseurl}}/images/pairs/PairsMarkovGain.png){:class="post-image"}

#### How does game length vary with the number of players?

Note that the advertised game length for Pairs 
is 15 minutes. In the rules, the number of points necessary to lose a game of Pairs is 
scaled to the number of players, according to the formula "Take 60, divide by players, then add 1." 
To explore how this simple rule affects the length of the game, we simulated games with 
only random players for 2 through 5 players. We forgo estimating the clock time for each 
decision, and instead report below the average number of calls 
to a `choice` block for a player decision. 

![Pairs Length]({{site.url}}{{site.baseurl}}/images/pairs/PairsGameLength.png){:class="post-image"}
  
We found that there is a very consistent 
correspondence between the number of players and the length of the game, demonstrating 
that the scaling is having the desired effect. A different rule could be implemented 
to provide perfect consistency, however the loss of simplicity would not be worth 
the complication.

### Advanced Heuristics

#### How can turn order be manipulated to create a fair game?

We focused on games with four random players. In the four-person version, the game is 
over when one player earns at least 16 points. Initially, we found that all players 
have an expected value of slightly over 9 points. This points to a fair game, however, 
we found evidence of turn order bias within an individual round.

![Pairs Fairness]({{site.url}}{{site.baseurl}}/images/pairs/PairsFairness2.png){:class="post-image"}

The above figure shows the expected value for each player in one individual 
round. In these experiments, players were not given the option of stopping early, 
to isolate the effect of drawing another card. The rules of Pairs designate the player 
with the minimum valued card as the first player. This led to an unbalanced game, 
where the second player has the worst expected value. However, we can see the benefit 
of this approach in comparison to a variant where the first player is chosen randomly. 
For this variant, there is a strong disadvantage in being the first player, with an 
expected value of 2.75 points, as opposed to being the fourth player, with an expected 
value of 1.37. While both are unbalanced, the published rules provide a more uniform 
chance of wining for all players.

### Conclusion

WILL TALK ABOUT VARIANTS IN A FUTURE POST

### Variants

MAKE SEPARATE POST

Continuous Pairs

The designers of Pairs propose a continuous variant, where the round is not over when a 
player bows out or draws a pair. Instead, only the current player's hand is discarded, 
and on their next turn they must take a card
from the stock. This variant can be captured in RECYCLE with a single stage and much 
simpler structure. In simulated games with four players, we found this one-round 
variant to be well balanced. We also noted another property of the continuous variant; 
the expected value for each player rose from 9 points to 11.5 points. 
This variant could therefore have more tension, as all players are closer to the 
threshold for losing the game.

Calamity Continuous Pairs?