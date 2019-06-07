---
layout: post
title:  "Ninety-Eight: Advanced Heuristics"
date:   2019-02-06 10:10:18 -0600
categories: ADDER
image: images/deck_of_playing_cards.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Ninety-Eight is looking like a quick game with some strategy for the players and a
consistent number of choices, given our previous [statistical analysis]({{ site.baseurl }}{% post_url 2019-02-05-ninetyeight-statistics %}),
Now let's see how it scores on our heuristics of **Fairness, Convergence, Spread, Drama, and Security**. 

(See this previous post for a [review of the heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) I'll be 
discussing.)

#### Fairness = 0.98

To determine fairness here, we'll need to do something different. In Pairs, 
even though the goal was to not lose, a player accumulated points and could
be differentiate into ranks, allowing for a "winner" with the lowest point 
total. But in Ninety-Nine, we just have the tipping point of the 
discard `PILE` growing larger than 98, so it is harder to differentiate
the players. Instead, we will compare the chance that a random player will not lose to the
expected chance based on the number of players. The image below shows that 
random players behave as expected, giving no advantage or disadvantage to the
first player.

![Ninety-Eight Fairness]({{site.url}}{{site.baseurl}}/images/ninetyeight/fairness.png){:class="post-image"}

#### Convergence = 0.50

As discussed before, the convergence score for Ninety-Eight is a solid 0.5, with players getting
exactly 4 choices each turn, with no change throughout the game.

![Ninety-Eight Convergence]({{site.url}}{{site.baseurl}}/images/ninetyeight/convergence.png){:class="post-image"}

#### Spread = 0.37

There is a moderate spread for the player choices in Ninety-Eight, showing that there are
some good and some bad options, but they are not always present. In the middle of the game,
there is not much difference between playing a 4 versus a 7, however, a King can be all-powerful,
and a Jack or Ten could save the day for you. Here's a sample run with four players, where 
you can see the tight estimates for everyone near the top of the ranks until the end of the game.

![Low Spread]({{site.url}}{{site.baseurl}}/images/ninetyeight/allaionegame.png){:class="post-image"}

#### Drama = 0.39

The more players you have in Ninety-Eight, the more likely you feel like you are winning. 
With only one player losing, your chances of winning go up with more players. 
Most of the rank estimates in the lead histories for Ninety-Eight are very high, above
the drama threshold, confirming this intuition.

The end of the game comes quite suddenly, usually when someone plays a King to bring 
the total to 98, causing the next player to stumble. This is particularly true
in games with one AI player versus other random players, as seen here.

![Ninety-Eight One AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/oneairankestimatewinner.png){:class="post-image"}

But AI can recover quickly with the right cards. Saving and playing at Ten, Jack, or Queen
after the previous player plays a King can put off the loss to the next player. We see this
in the full four-player AI games below with the seesaw dips under the drama threshold, and they continue 
for each subsequent player until one cannot stave off defeat any longer.

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimate.png){:class="post-image"}

Here's a sample run that shows this repeated delay of the inevitable loss, in a game with only 10 turns.
Each player in sequence dips below the threshold until Purple is forced to take the final hit
and lose the game.

![Low Spread]({{site.url}}{{site.baseurl}}/images/ninetyeight/allaionegame2.png){:class="post-image"}

#### Security = 0.60

In Ninety-Eight, games can be quick, with just
two cards played, or continue on for many rounds. But unlike the slow recover of Pairs scores
if a player takes a hit, in Ninety-Eight, the player either quickly rebounds or the game is over.
Here is the two-player lead histories for games with all AI players.
![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner2p.png){:class="post-image"}

Overall, players feel very confident in their chances of winning for most of the game, and thus
the security score is very high. For completeness, here is the three player graph:

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner.png){:class="post-image"}

the four-player graph:

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner4p.png){:class="post-image"}

and the five-player graph.

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner5p.png){:class="post-image"}

#### Summary

Here is our summary graph of all the heuristics for Ninety-Eight. Fairness and convergence are
typical of what we've seen before, but the high value for security makes it stand out.
Although, it is worth noting that it is not just the winner that feels secure, but every player.
Maybe there should be a heuristic for false hope, which is how long the losing players 
believe they are above the drama threshold? This is precisely the reason I'm writing these
posts, so I can start to get a better handle on what makes card games of different styles 
and families tick, and settle on the correct heuristics for analysis.

![Ninety-Eight Heuristics]({{site.url}}{{site.baseurl}}/images/ninetyeight/heuristics.png){:class="post-image"}

#### Up Next - The King Effect

It looks like the King card is extremely powerful in Ninety-Eight. What would the game 
look like without it? Would the game still work? I'll explore a variant without the 
superpowered Kings to see what insights the simulations can bring us.