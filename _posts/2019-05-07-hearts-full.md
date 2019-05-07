---
layout: post
title:  "Comparing Variants of Hearts using Monte Carlo Simulations"
date:   2019-05-07 08:10:18 -0600
categories: TRICK-TAKING
image: images/hearts-variants.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Our fifth card game for analysis is [Hearts](https://www.pagat.com/reverse/hearts.html), 
a classic [trick-taking game](https://www.pagat.com/class/trick.html)!
Hearts, and its family of games, focuses on [avoiding tricks](https://www.pagat.com/reverse/)
rather than collecting them, making them a nice counterpoint to other classics
such as [Whist](https://www.pagat.com/whist/)
and [Spades](https://www.pagat.com/auctionwhist/spades.html). 

Hearts as played today was 
slowly evolved and mutated from earlier games, such as
[Knaves](http://whiteknucklecards.com/games/knaves.html),
[Polignac](http://whiteknucklecards.com/games/polignac.html), 
[SlobberHannes](http://whiteknucklecards.com/games/slobberhannes.html), and 
and [Black Maria](http://whiteknucklecards.com/games/blackmaria.html). Each of them 
still has the central goal of avoiding points, but they either alter the point values,
remove card play restrictions, or find additional things to avoid. 

What makes each variant unique for the players, and why would
someone choose to play one versus another? 
Is our current iteration Hearts an improvement over these older version? 
To answer these questions, we'll dive deep into writing code for Hearts, simulate
hundreds of games with random and Monte Carlo AI players, 
evaluate these runs with [heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}),
then compare our results to those from several variants. Let's get started! 

### Rules

First, here's the rules in English for how you play the basic game of Hearts.

>Play proceeds
in rounds, with each round consisting of thirteen tricks. Each round, 
shuffle a standard deck of cards. Each player receives thirteen cards. For each trick, players play 
one card to a central trick on the board. The first player will set the lead suit for the
trick, which subsequent players must follow suit if they can, otherwise they may play 
any card from their hand (called being short of a suit). Also, the first player is 
restricted to not play a card from the Hearts suit unless one has already been played 
through short-suiting in a previous trick. Once all cards have been played, the player
who played the highest card that matches the suit of the led card will win all the 
cards in the trick and become the first player for the next trick. Once all tricks
have been played, players earn one point for each Heart collected in tricks, plus
13 points if they collected the Queen of Spades. If a 
player happens to collect all the Hearts and the Queen of Spades, then
they will "Shoot the Moon" and instead subtract 26 points from their score.
The game ends when one player earns a total of 100 points; at that point 
the player with the lowest point value wins the game.

### RECYCLE Coding

To prepare Hearts for our computational simulations, we use the 
[RECYCLE](https://cardstock.readthedocs.io/en/latest/recycle/index.html) 
game description language. 

First, we create the players and the teams, followed by the standard
[French deck](https://en.wikipedia.org/wiki/French_playing_cards) of 52 cards. Initally 
these cards are added to the `DISCARD` location, to facilitate multiple rounds.

{% highlight racket %}
(game
 (setup  
  (create players 4)
  (create teams (0) (1) (2) (3))
  (create deck (game vloc DISCARD) (deck (RANK (A, TWO, THREE, FOUR, FIVE, SIX, 
                                                SEVEN, EIGHT, NINE, TEN, J, Q, K))
                                         (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                (BLACK (SUIT (CLUBS, SPADES)))))))       
{% endhighlight %}
 
The first stage of the game captures the large game loop, where players repeatedly
play their hands until one player reaches a certain score, usually 100 points.

However, as coded here, the game will only play one round, saying that it is over
when at least one player does not have a score of 0. This one round will help with
our analysis, and also increase the speed of our simulations.

In the first iteration of coding this game for one round, we erroneously listed
this as ending when any player has a score greater than 0. But this turned out
to conflict with the "Shoot The Moon" scoring possibility, discussed later.
 
{% highlight racket %}
 (stage player
        (end 
         (any player 'P (!= ('P sto SCORE) 0)))

{% endhighlight %}
 
Each round, we need to move all the cards back to the `STOCK` from the `DISCARD` location.

We create a point map for scoring called `'SCORE`, where each Heart is given a score of 1,
and the Queen of Spades is given a score of 13.

The cards in the `STOCK` are shuffled, and each player is dealt 13 cards into their `HAND`.

Finally, we set an integer called `BROKEN` to track if any Hearts have been played. At 
the beginning of each round, this is set to 0.
 
{% highlight racket %}

(do 
    (
     (repeat all
             (move (top (game vloc DISCARD)) 
                   (top (game iloc STOCK))))
     (put points 'SCORE 
          (
           ((SUIT (HEARTS)) 1) 
           ((RANK (Q)) (SUIT (SPADES)) 13)))
     (shuffle (game iloc STOCK))
     (all player 'P
          (repeat 13
                  (move (top (game iloc STOCK))
                        (top ('P iloc HAND)))))
     (set (game sto BROKEN) 0)))
        
{% endhighlight %}

For the hand stage, we end when all the players have no cards left in their `HAND` location. 
Inside this stage, we have another stage, which cycles for the trick. It will end when each player has
played one card to their `TRICK` location.

{% highlight racket %}
(stage player
       (end 
        (all player 'P 
             (== (size ('P iloc HAND)) 0)))
       
       (stage player
              (end 
               (all player 'P 
                    (== (size ('P vloc TRICK)) 1)))
                      
{% endhighlight %}
 
Recall in [Agram]({{ site.baseurl }}{% post_url 2018-11-26-agram %}), there
were three options for a player in a trick taking game: play any card if the first player,
follow suit if a following player, or play any card when unable to follow suit if a following
player.
In Hearts, the current player now has a choice between **five** distinct exclusive options.
First, if they are the first player (determined by asking if there is a card
in the memory location `LEAD`), and Hearts have not been broken (still has a 
value of 0), we try to make a filter that contains all cards from their `HAND` 
where the suit is not Hearts. When processed, these cards
will get the temporary variable name `'C`. The current player can 
play any one of these cards to their `TRICK` location.

After they play their card, they ask the game to remember it in the `LEAD`
location, for everyone to reference as the trick progresses around the table.

{% highlight racket %}
  (choice  
   (         
    ((and (== (size (game mem LEAD)) 0)
          (== (game sto BROKEN) 0))
     (any (filter ((current player) iloc HAND) 'NH 
                  (!= (cardatt SUIT 'NH) HEARTS))
          'C     
          (do 
              (
               (move 'C  
                     (top ((current player) vloc TRICK)))               
               (remember (top ((current player) vloc TRICK)) 
                         (top (game mem LEAD)))))))
                        
{% endhighlight %}
 
Second, if they are the first player, and Hearts have not been broken,
but they have no cards that are not Hearts, then they can play any card 
from their `HAND` to their `TRICK` location.

Again, after they play their card, they ask the game to remember it in the `LEAD`
location, for everyone to reference as the trick progresses around the table.

{% highlight racket %}
((and (== (size (game mem LEAD)) 0)
      (== (game sto BROKEN) 0)
      (== (size (filter ((current player) iloc HAND) 'NH 
                        (!= (cardatt SUIT 'NH) HEARTS))) 0))

      (any ((current player) iloc HAND) 'C
         (do 
             (
                (move 'C 
                      (top ((current player) vloc TRICK)))
                  (remember (top ((current player) vloc TRICK)) 
                          (top (game mem LEAD)))))))
                        
{% endhighlight %}
 
Third, if they are the first player, but Hearts *has* been broken, then they can play any card 
from their `HAND` to their `TRICK` location.

Again, after they play their card, they ask the game to remember it in the `LEAD`
location, for everyone to reference as the trick progresses around the table.

{% highlight racket %}
((and (== (size (game mem LEAD)) 0)
      (== (game sto BROKEN) 1))
      (any ((current player) iloc HAND) 'C
         (do 
             (
                (move 'C 
                      (top ((current player) vloc TRICK)))
                (remember (top ((current player) vloc TRICK)) 
                          (top (game mem LEAD)))))))

{% endhighlight %}
 
Fourth, if they are not the first player (determined by seeing that there is
already a card in the `LEAD` memory location), and they cannot follow the 
suit of the card that was led, then they can play any card 
from their `HAND` to their `TRICK` location.

{% highlight racket %}
((and (== (size (game mem LEAD)) 1)
      (== (size (filter ((current player) iloc HAND) 'H 
                        (== (cardatt SUIT 'H) 
                            (cardatt SUIT (top (game mem LEAD)))))) 0))
 (any ((current player) iloc HAND) 'C
      (move 'C 
            (top ((current player) vloc TRICK)))))
                        
{% endhighlight %}
 
Finally, if they are not the first player, and they *do* have a card that 
can follow suit, then they can play one of these card with a matching suit
to their `TRICK` location.

{% highlight racket %}
(any (filter ((current player) iloc HAND) 'H 
             (== (cardatt SUIT 'H)
                 (cardatt SUIT (top (game mem LEAD)))))
     'C
     ((== (size (game mem LEAD)) 1)
      (move 'C 
            (top ((current player) vloc TRICK))))))))
               
{% endhighlight %}
 
Once the inner trick stage ends, then the game determines the winner of the trick.
We make another PointMap called `'PRECEDENCE` to sort the cards from highest to lowest
rank. In this map, we add in an extra 100 points for the suit that was led,
so that this initial card and cards that follow suit will be ranked higher than 
other cards that did not follow suit.

With the map created, we no longer need to remember the `LEAD` card, so we forget it.
Finally, we use the `'PRECEDENCE` map to determine who won, by finding the owner of
the card that gets the maximum value of all cards played to `TRICK` locations. This player
is then set to be the next player in the cycle for this round stage, and will go first next 
trick.
                    
{% highlight racket %}
   (do ( 
        (put points 'PRECEDENCE 
             (
              ((SUIT (cardatt SUIT (top (game mem LEAD)))) 100)
              ((RANK (A)) 14)
              ((RANK (K)) 13) 
              ((RANK (Q)) 12)
              ((RANK (J)) 11)
              ((RANK (TEN)) 10)
              ((RANK (NINE)) 9)
              ((RANK (EIGHT)) 8)
              ((RANK (SEVEN)) 7)
              ((RANK (SIX)) 6)
              ((RANK (FIVE)) 5)
              ((RANK (FOUR)) 4)
              ((RANK (THREE)) 3)
              ((RANK (TWO)) 2)))
        
        (forget (top (game mem LEAD)))
        (cycle next (owner (max (union (all player 'P 
                                            ('P vloc TRICK))) using 'PRECEDENCE)))
                    
{% endhighlight %}
 
If anyone played Hearts this trick, and Hearts has not been broken, then it is now
broken by setting the `BROKEN` variable to 1.
                    
Next, all players will move their `TRICK` card to the `TRICKSWON` location of the
winning player for scoring.
                    
{% highlight racket %}
((and (== (size (filter (union (all player 'P ('P vloc TRICK))) 
                 'PH (== (cardatt SUIT 'H) HEARTS))) 0)
      (== (game sto BROKEN) 0))
 (set (game sto BROKEN) 1))

(all player 'P
     (move (top ('P vloc TRICK)) 
           (top ((next player) vloc TRICKSWON)))))))
        
{% endhighlight %}

The 13 rounds are over, and it is time to determine each player's score. We make one more stage
to cycle through the players, ending when they have each tabulated their own score.

If the current player has scored 26 points this turn, using the `'SCORE` map from above,
they have collected every Heart and the Queen of Spades, thus **Shoot the Moon**. In this case,
their score will be decremented by 26 points. In all other cases of scoring less than 26, 
their points will be added to their `SCORE`. The last step of scoring is to move all 
their cards from `TRICKSWON` to the general `DISCARD` pile, to be ready for the next round.

{% highlight racket %}
(stage player
       (end 
        (all player 'P (== (size ('P vloc TRICKSWON)) 0)))
       (do 
           (                  
            ((== (sum ((current player) vloc TRICKSWON) using 'SCORE) 26)
             (dec ((current player) sto SCORE) 26))
            
            ((!= (sum ((current player) vloc TRICKSWON) using 'SCORE) 26)
             (inc ((current player) sto SCORE) (sum ((current player) vloc TRICKSWON) using 'SCORE)))
            
            (repeat all
                    (move (top ((current player) vloc TRICKSWON))
                          (top (game vloc DISCARD))))))))
{% endhighlight %}
 
Hearts, like 
[Pairs]({{ site.baseurl }}{% post_url 2019-01-04-pairs %}),
is a game where you win by having the least points.

{% highlight racket %}
 (scoring min ((current player) sto SCORE)))
{% endhighlight %}

The full RECYCLE code for Hearts can be found in our 
[github project](https://github.com/mgoadric/cardstock/blob/master/CardStockXam/games/Hearts4.gdl). 

### CardStock Simulations

With the standard game of Hearts coded in RECYCLE,
we can start up our simulations in [CardStock](http://github.com/mgoadric/cardstock) with both random and 
AI players. 

Random players make a choice in the 
game using a uniform distribution across each choice, while the AI players use 
statistics of random simulations for each choice to determine their
best chance of winning. The AI strategy we use most often is 
called a *Perfect Information Pure Monte Carlo Player* ([PIPMC](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html)).

Our AI player will estimate the best move in a very simple manner. It will 
try out each move, followed by running a 
bunch of random simulations to the end of the game and see if it wins. It averages
these results for each move, and will pick 
the move that looks to have the best chance of winning with these estimates.

To gather statistics, we ran 100 games with all random players, 100 games with 
one AI and the rest random players, and 100 games with all AI players. 

For Hearts, we did these simulations for
3, 4, and 5 players. To alter the game for 3 players, we removed the 2 of Diamonds, and 
dealt each player 17 cards. To modify for 5 players, we removed the 2 of Diamonds and 2 of Spades, 
and dealt each player 10 cards. 

### Heuristic Analysis

It's graph time! I really love these graphs, since each one illuminates 
some very interesting properties of Hearts.
Let's see how it scores on our 
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) of 
**Fairness, Convergence, Order, Spread, Drama, and Security**. 

#### Fairness = 0.99

With all random players, we find that Hearts is a very fair game, scoring very close to the 
expected value for 4 players. This graph shows the probability that the first player
will win the game.

![Hearts Fairness]({{site.url}}{{site.baseurl}}/images/hearts/fairness.png){:class="post-image"}

However, we see that for 5 players, the first-player wins 
more often than expected. This is most likely due to the limited number of Hearts in the game,
which make it more likely that players will be able to avoid taking any, thus scoring
the least for first place. I would expect this rising trend to continue if Hearts were extended
to a 6-player game.

#### Convergence = 0.54

Convergence captures how much the game trends toward limited choices at the end
of the game. This helps us determine if the game is coming 
to a conclusion when it ends, with higher scores mapping to steeper negative slopes. 

At the most, a player in Hearts will be able to play any card in their hand to the trick. But 
this is restricted in two ways. First, players that are not the lead player will need to 
follow suit if possible, and this is a great way for the lead player to limit other player's 
choices to their advantage. The following graph for the
four-player simulations shows the number of choices for the 
players in Hearts, with the lead in blue and the other players in red. The other player's 
options are averaged into one value, with the standard deviation error bars plotted.  

![Hearts Choices]({{site.url}}{{site.baseurl}}/images/hearts/choices.png){:class="post-image"}

If we think of a hand of cards in Hearts being evenly distributed, we would expect to see on 
average 3.5 cards of each suit. Of course part of what makes the game interesting is
the uneven distribution of these cards and managing the altered probabilities, but this
gives us a starting place to examine the graph. 

Following suit should then limit the other players to on average
3.5 cards. This is exactly what happens, and it is borne out across the whole round! (Until the last few 
tricks when players will have less than 3 cards remaining in their hand.)  Another point to 
notice about the other player's choices is that the standard deviation starts is much larger
for tricks 5 and 6. This is due to the players starting to become short-suited and thus having
more options for play.

Second, unlike most trick-taking games, the lead player
will be restricted to not lead a Heart until one has been played in a previous 
round by a following player, thus "breaking" Hearts open for play. When does
this happen? Interestingly, we also see the same 3.5 cards in one suit effect for the lead player in 
the above graph. 
The limitation of Hearts not being broken
cuts the average choices for the lead player from 13 to approximately 10 for the 
first trick, with similar effect for the second, third, and fourth trick. 
But then, we see a shift happen. In tricks 5 and 6, the 
lead player choices level off around 7. This must be where Hearts is most likely to be broken!
The shift continues for the next few tricks, until trick 10, when the number of 
lead choices matches exactly the number of cards remaining in the player's hand.

To make this shift from unbroken to broken Hearts more visually clear, I've added two lines in the next 
graph. The green line shows the expected number of choices for the lead player if Hearts 
is never broken, while the black line shows the expected number of choices if Hearts 
are allowed on every trick. We start out following the slope of the green line, and slowly 
shift to follow the black line as the game progresses.

![Hearts line Choices]({{site.url}}{{site.baseurl}}/images/hearts/choices-lines.png){:class="post-image"}

So, to determine convergence, we graph here the number of choices for
each player for all 100 games and each regression line
found. The choices are shown overlapping, where darker blue circles mean that more 
games were found to have this exact number of choices for at this point in the game.

![Hearts Convergence]({{site.url}}{{site.baseurl}}/images/hearts/convergence.png){:class="post-image"}

There is a definite convergence toward the end of the game, however, the slope
is decreased because of the earlier seen effect of the Hearts suit not being broken
until around the fourth or fifth turn of the game. 

#### Order = 0.48

Next up, our new heuristic, [order]({{ site.baseurl }}{% post_url 2019-03-19-chaos-heuristic %}),
measuring how easy it is for AI players to beat random players. Here's
a graph showing the win probability of the AI player when pitted against all random
players.

![Hearts Markov Gain]({{site.url}}{{site.baseurl}}/images/hearts/winprob.png){:class="post-image"}

For the 4-player game, the AI was able to win about 60% of the time, improving on the random 
expectation of 25%. This works out to an Order score of 0.48. Compared to the 
[other games]({{site.url}}{{site.baseurl}}/leads) analyzed, this is higher than
Agram, about equal to Stealing Bundles, and lower than both Ninety-Eight and Pairs.

#### Spread = 0.13

When looking at the choices available for each player in the game, 
Spread captures how different these options look in terms of their expected win/loss outcome.
Games with larger spread should mean games with more important choices for the player, 
as it will be critical they pick the right choices. 

Time to look at the [lead histories]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %})! 
Here we see a typical game of Hearts played out with four
AI players. Let's see what we can notice visually from this graph.

![Hearts Spread]({{site.url}}{{site.baseurl}}/images/hearts/allaionegame.png){:class="post-image"}

The game starts out with all players believing they are doing OK, but at around one-third
of the way through, one player's estimate is consistently low, with very little or no 
chance of success. What happened here?

At this point in the game, the purple player won a trick containing the *Queen of Spades*!
With this card conveying 13 points to the player who wins it, this becomes an 
insurmountable penalty.  The other players become even more confident in their positions
of winning, until the rest of the Hearts cards play out and their scores are settled.

This settling of scores after two-thirds of the game is complete is a large
contributor to Hearts earning a low spread score. There are definite points in the 
game where a player will see a broad spectrum of choices, but much of the time, 
a player's path seems determined (stuck at the bottom) and therefore uninteresting.

#### Drama = 0.33

However, a static trajectory is not always the case.
Below is another lead history graph. Can you determine what happened in this game?

![Hearts One Run Shoot the Moon]({{site.url}}{{site.baseurl}}/images/hearts/allaionegameshootthemoon.png){:class="post-image"}

This game of Hearts starts out similar to our previous game, with
one player taking the Queen of Spades at around the one-fifth point in the game, spelling 
doom for their chances of winning. But wait. Could it be? Yes! The red player collected 
all of the penalty cards to **Shoot the Moon** and win the game! 

The Drama heuristic tries capture the magnitude of 
dips below the "drama threshold" (the dashed horizontal line) for the winning player.
This is what a dramatic game looks like, with the winner underwater for most of the game
and coming back at the end, pulling it off in the last trick. And, none of the other players 
believe this is going to happen, consistently estimating the red player's chances of 
winning very low.

In fact, this happens in 10% of our simulations of games with all AI players! Here is 
the aggregate graph of these games where the winning player shot the moon, with the
winning player shown in red.

![Hearts Shoot the Moon]({{site.url}}{{site.baseurl}}/images/hearts/allaishootthemoon.png){:class="post-image"}

But at only 10% of the games being so dramatic, the other 90% show a more stable
game with consistently high estimates for the winner, bringing the overall 
drama score down to 0.33, in line with the other games we have analyzed. The graph
below shows the lead histories for all 100 simulations with all AI players.

![Hearts All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/hearts/allairankestimate.png){:class="post-image"}

One other interesting point: in simulations with only one AI player, 
where the rest are random, we see that the AI only shoots the moon twice. The following
graph shows these lead histories. These are more consistent due to them being just from 
the perspective of one player.

![Hearts One AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/hearts/oneairankestimatewinner.png){:class="post-image"}

It appears that random players are much more likely to destroy the shoot the moon strategy 
by picking up a Heart card by accident, whereas the AI players mostly try to 
avoid taking any Hearts at all.

#### Security = 0.56

Security measures how long the 
winning player believes they are winning. 
Again, since most of the simulations show the winning player performing well, the
security of Hearts is somewhat high at 0.56. The graph below shows the 
aggregate lead histories for all AI player simulations, with the winner 
shown in red, while all other players are in black.

![Hearts  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/hearts/allairankestimatewinner4p.png){:class="post-image"}

Note the dark bands that start to show up for players in the latter half of the game.
The trajectory for the player with the worst score solidifies first, followed by the 
next lowest, and finally the top two positions are determined. This helps
increase the security of the game, and contributes to the low spread found earlier.

For completeness, here is the three player graph:

![Hearts All AI Rank Estimate 3p]({{site.url}}{{site.baseurl}}/images/hearts/allairankestimatewinner3p.png){:class="post-image"}

and the five-player graph:

![Hearts All AI Rank Estimate 2p]({{site.url}}{{site.baseurl}}/images/hearts/allairankestimatewinner5p.png){:class="post-image"}

Each of these graphs for Hearts show the slow drop-off of players to losing positions and the 
consistently rising trend across the remaining player estimates, which is especially pronounced
in the five-player game.

One last thing we can see in these graphs is the effect of turn order on the win estimates.
When looking at the five-player game above, we see that the estimates are almost completely 
consistent at the start of the trick for the last few tricks of the game. Note the way 
the graphs converge at when 80% of the game is complete, this is when the lead player
makes their move and estimates. And again at 90% of the game, the graphs converge again, and 
mostly stay consistent to the end of the game.

#### Summary

Here is our summary graph of all the heuristics for Hearts, showing visually the low spread
and high fairness.

![Ninety-Eight Heuristics]({{site.url}}{{site.baseurl}}/images/hearts/heuristics.png){:class="post-image"}

So, can we conclude that 10% of the time in Hearts, a player will shoot the moon? 
Not exactly. It is worth noting that this estimate of 10% is based on the current weak AI model
used in our CardStock simulations, which makes no assumptions about the 
intelligence of the other players when deciding on a move. More advanced AI players
may be able to detect the Shoot the Moon strategy being attempted and thwart it
by sacrificing a few points.

### Seven Hearts Variants

Can these heuristic scores be improved or altered with rule changes? We'll look 
at **seven variants of Hearts**, some close relatives, some long-distant ancestors, and see
what effect they have on the game. This only touches the surface of the 
Hearts variants I came across while searching, so if another version interests you,
please let me know.

The graph below shows the 
[average trend graph]({{ site.baseurl }}{% post_url 2019-05-03-average-trend %})
for the aggregate 
lead histories in Hearts. When we put them all together, I think it is easier to follow the
game flow for each player. We'll be comparing each variant to the graph shown here. 

![Hearts All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/hearts/hearts-trends.png){:class="post-image"}

#### That's No Moon

First, since it was such an interesting find to see the effects of the **Shoot the Moon** 
strategy last time, what happens when this is not an option? We can make a slight change in the 
[RECYCLE code]({{ site.baseurl }}{% post_url 2019-03-13-hearts %})
at the end of the round to simply sum up the scores for each player. Here is the 
average trend graph for what I call the **That's No Moon** variant, using four AI players.

![No Moon]({{site.url}}{{site.baseurl}}/images/hearts/nomoon-trends.png){:class="post-image"}

A few things can be seen that are different from the standard Hearts in That's No Moon. First, the 
drop-off for the fourth-place player is much faster, and more final. Their average here is 
consistently lower than what it was in Hearts, across the whole game. And without the
advantage of ties, they trend down very close to 0 for their final rank estimate.

Second, the third-place player stays tighter with the first and second-place players, only
making a clear divergence in the latter half of the game. 

Third, the periodic peaks in the winning player graph have smoothed out, which means that
the drama of thinking they will win while being underestimated by the other players is
lost. 

So, while this is a very small rule change, it will definitely affect the experience
of the game for the worse. We'll try to quantify exactly how at the end of this post.

#### Black Maria

Next up is [Black Maria](http://whiteknucklecards.com/games/blackmaria.html). 
Unlike the standard rule where the Hearts suit must be 'broken' and played by a non-lead player before 
it can be led, in this variant, there is **no restriction on when Hearts can be played**.

Since this is an ancestor of Hearts, can we see why the "breaking hearts" rule was added
and became popular? Here is the average trends for four-player games of Black Maria with 
all AI players.

![Black Maria Moon]({{site.url}}{{site.baseurl}}/images/hearts/blackmaria-trends.png){:class="post-image"}

It is interesting to see that the top two players separate from the bottom two players 
early. This variant is especially different for the third-place player, who is no 
longer competitive in the early game. With hearts showing up earlier, we might expect
there to be less chance to Shoot the Moon, but the percentage of moon games is very close
to standard Hearts, at 8%.

With the game becoming a foregone conclusion much earlier than in standard 
Hearts, this will only add to our problems of low spread, low drama, and high security!
So, it appears that standard Hearts benefits from the "breaking hearts" rule.

#### Omnibus Hearts

We've seen the negative effects of removing current rules from Hearts, but can we find changes 
to make Hearts better? The
[Omnibus](https://forum.boardgamearena.com/viewtopic.php?t=5427) variant adds a
rule where the **Jack of Diamonds is worth -10 points**. 

Can this new point arrangement, counteract the negative effects from the Queen of Spades?
Here's the average trend graph once the Jack of Diamonds points are adjusted.

![Hearts Omnibus]({{site.url}}{{site.baseurl}}/images/hearts/omnibus-trends.png){:class="post-image"}

As expected, we see that the Queen of Spades has been tempered. While the losing player 
still separates from the rest of the players, we see the slope is gradual rather than steep.

The moment when the winner is clearly over the 
drama threshold is also delayed, moving from 60% to near 70% of the game being played. This should 
increase the possibility of more drama and less stability in the game.

Thanks to [P.D. Magnus](https://www.fecundity.com/pmagnus/) for suggesting I look at this variant!

#### Grey Maria

Another way to lessen the impact of the Queen of Spades is to **change its point value directly**.
[Sean Ross](https://boardgamegeek.com/user/seandavidross) commented over on 
[BoardGameGeek](https://boardgamegeek.com/blogpost/88496/hearts-heuristics-and-shooting-moon#comments)
on the last post about weakening the Queen of Spades penalty:

>I'd be curious to see if there is a more balanced penalty value for the 
Queen of Spades that reduces the spread caused by capturing it, yet maintains the fear of 
capturing it. I'm thinking 7 might be a better value."

I've dubbed this variant the **Grey Maria**, or Hearts7Q, and we can see below the resulting 
aggregate lead history graph.

![Hearts Queen is 7]({{site.url}}{{site.baseurl}}/images/hearts/hearts7q-trends.png){:class="post-image"}

This looks like it might keep the benefits from the Omnibus variant, such the delayed
point of winning, and add in a tighter early game! The periodic peaks in the endgame
from the Shoot the Moon strategy are still there, and are actually a little more pronounced,
as 13% of these games result in a Shoot the Moon win. And, the first and second-place 
players are much closer for most of the game, only diverging in the last third.

Nice work, Sean!

#### Polignac

For the last three variants, we look back in time to early ancestors of Hearts.
In [Polignac](http://whiteknucklecards.com/games/polignac.html),
which uses a reduced deck of cards, only using 7 through Ace in each suit, leaving us
with 32 cards. Players in Polignac are **penalized for winning tricks with Jacks, 
plus another penalty for taking the first and last trick**.
This harks back to our earlier discussion of [Agram]({{ site.baseurl }}{% post_url 2019-01-03-agram-heuristics %}),
where only winning the last trick of the game mattered for scoring.

![Polignac]({{site.url}}{{site.baseurl}}/images/hearts/polignac-trends.png){:class="post-image"}

Faintly in the background, there is a sharp drop for some players at the end of the
first trick, corresponding to someone scoring a point. While this point make it likely
this player will lose, it does not seem to be as severe as the Queen of Spades
in Hearts, since there are many other places to score points. But as with Knaves,
there is an early divergence in player ranks. 

One interesting observation, 
there appear to be many ties in this game. The average second-place end rank is
much closer to the first-place end rank, and the second-place player actually
exceeds the drama threshold! The third-place player also has a higher-than-expected
end rank, pointing to even more ties.

#### Slobber Hannes

Next, we look at possibly the simplest ancestor of Hearts, 
[Slobber Hannes](http://whiteknucklecards.com/games/slobberhannes.html).
In this variant, **only one card
should be avoided (Queen of Clubs), plus the first and last trick**. 

![SlobberHannes]({{site.url}}{{site.baseurl}}/images/hearts/slobberhannes-trends.png){:class="post-image"}

Besides being the simplest ruleset, this looks like the least-interesting variant yet.
Following the dramatic dip after the first trick, the player ranks are relatively flat
until the last trick finally settles the outcome. With only three penalty points, ties
are even more likely, with the first and second-place players almost evenly ranked, and
both above the drama threshold for most of the game.

#### Knaves

Finally, we look at another ancestor, [Knaves](http://whiteknucklecards.com/games/knaves.html).
Knaves is similar in spirit to Hearts in that there are cards to avoid, but it also keeps some elements of 
standard trick-taking games. Players earn **one point for each trick won** in the game.
However, negative penalties are given for
**only the four Jacks** instead of all 13 hearts, with some Jacks giving more penalties than others. 
And, there is no penalty at all associated with the Queen of Spades.

There are a few other differences in Knaves. The game is typically played by only three players,
dealing 17 cards to each player. Also, the remaining card is turned face-up and used
to identify the trump suit for trick-scoring purposes. 

![Knaves]({{site.url}}{{site.baseurl}}/images/hearts/knaves-trends.png){:class="post-image"}

We can see in the average trend graph above that these simple rules for Knaves have more in common
with the Black Maria variant. The ranks for the players diverge quickly, since there is 
no way of recovering from taking points. This looks to be a much different game
than Hearts, although, there is a lot of movement up and down the ranks within individual games.

### Heuristic Variant Comparison

The graphs above are extremely useful for visualizing the differences between these variants.
But do these insights translate into any meaningful differences in the 
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) summary values?
We'll focus on only four of our usual heuristics, since all of these variants score
similarly on Fairness and Convergence.

#### Spread

First, let's look again at **Spread**. We'll plot and label the values for these seven 
variants on a simple line, as shown below, with Hearts highlighted in red.

![Variant Spread]({{site.url}}{{site.baseurl}}/images/hearts/variant-spread.png){:class="post-image"}

To the left of Hearts, we see Polignac and Slobber Hannes. This makes sense, as the important choices in these games
are very infrequent, since they involve many tricks and only a few point cards.

To the right of Hearts, we see first our variants that removed critical rules: That's No Moon, and Black
Maria. These are followed by Grey Maria and Omnibus, showing that there are more important
choices to be made in these later games. 

Interesting, though, is the appearance of Knaves
on the far right! This could be an artifact of this game only involving 3 players, thus 
making the rank estimates harder to compare to the other four-player games. But it could
also be due to the mixture of incentives to take tricks but avoid certain cards. 
I will have to play a few rounds in person to see if there is something else going on.

I also think I need to add some more instrumentation to my CardStock system so I can make some better
graphs for spread. I'm still not sure why these numbers are consistently low (0.11 to 0.18) 
across all these different games, and more data could always help.

#### Drama

Next, we plot how the variants perform on **Drama**. 

![Variant Drama]({{site.url}}{{site.baseurl}}/images/hearts/variant-drama.png){:class="post-image"}

Again to the left of Hearts, we first find Slobber Hannes and Polignac. As the winners are clear
in these games early, there is less opportunity for dramatic wins. Next, we see That's No Moon, 
which also makes sense, since we removed the opportunity for the dramatic win-from-behind
scoring option.

We see Grey Maria and Omnibus contain much more Drama than Hearts. Both of these variants
keep the scores tighter throughout the game and make the winner more uncertain. Knaves 
continues to confound me, with more Drama than I expected. Again, this is most 
likely due to the combination of winning and losing points.

#### Order

Third, we find out how much **Order** is present in the variants. High values for 
Order means than the AI players have an easy time beating random players, while
low values mean that beating random players is much more difficult.

![Variant Order]({{site.url}}{{site.baseurl}}/images/hearts/variant-order.png){:class="post-image"}

As expected, Slobber Hannes is an easy game to win for our AI players, followed by Knaves
as the second-easiest. On the low end, we find Black Maria and Omnibus a significant
distance from Hearts. I can definitely see how a bad hand in Black Maria could prove
disastrous, with players playing their Hearts randomly messing up the potential 
for AI strategy. But I am confused as to why Omnibus shows up so low?

#### Security

Finally, we'll compare the **Security** of each variant.

![Variant Security]({{site.url}}{{site.baseurl}}/images/hearts/variant-security.png){:class="post-image"}

This heuristic tracks most closely with what the average trend graphs were showing us above.
Knaves, Polignac, and Slobber Hannes all have very high Security, with the winner above the
drama threshold and knowing they are the winner more than 75% of the game. On the other hand,
Grey Maria and Omnibus have a much lower value for Security, and making more a much more
interesting midgame than Hearts.

### Up Next - L.A.M.A

Thanks for reading! I'd love to hear if you have 
any other unique variants that shouldn't be missed in this analysis.
This post is finally start to get to
the heart (*pun intended*) of one of my eventual goals with this project: 
[evolutionary game design](https://boardgamegeek.com/blogpost/2814/yavalath-evolutionary-game-design). 
By studying small variants of a card game that has evolved naturally and measuring the 
quantitative effects of these variants, I'm hoping one day our system can automatically make edits and 
changes to the rules of a card game, moving it toward a better experience for the players.

Up next, we're emerging from the past to examine a much more recent game next!
[L.A.M.A](https://boardgamegeek.com/boardgame/266083/lama)
is a recent release from 
[Reiner Knizia](https://en.wikipedia.org/wiki/Reiner_Knizia) and 
[AMIGO Games](https://www.amigo.games/). In L.A.M.A, players must quickly shed
their hand, but can also bow out and bet they will earn less points than other 
players. And it involves llamas! It looks to be a combination of a few simple mechanics, tune in next
time to see how it fares in our system.

<hr>
<a href="http://www.freepik.com">The black hearts variant image designed by rawpixel.com / Freepik</a>