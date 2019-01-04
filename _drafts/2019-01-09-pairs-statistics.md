---
layout: post
title:  "Pairs: Basic Statistics"
date:   2019-01-03 11:46:18 -0600
categories: PRESS-YOUR-LUCK
image: images/pairs.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Intro BLAH

#### Are there sufficient choices for players?

Unlike Agram, Pairs is very consistent in the number of choices a player has on their turn: **always 2**.
A player can either end their turn, or flip up a new card from the `STOCK`.

#### Can players be strategic in Pairs?  

We ran simulations for 2 through 5 players, using one AI player and leaving the remaining 
players random. 

![Pairs Win Prob]({{site.url}}{{site.baseurl}}/images/pairs/winprob.png){:class="post-image"}

Since the goal in Pairs is to not lose as opposed to win, we show below 
the non-loss percentage for the AI player in 
comparison to the expected probability of not losing for a random player, given 
the assumption that the game is fair. We can see the AI is drastically better 
than the random players, quickly approaching a non-loss probability of 1.

![Pairs Markov Gain]({{site.url}}{{site.baseurl}}/images/pairs/PairsMarkovGain.png){:class="post-image"}

#### How does game length vary with the number of players?

Note that the advertised game length for Pairs 
is 15 minutes. In the rules, the number of points necessary to lose a game of Pairs is 
scaled to the number of players, according to the formula "Take 60, divide by the number 
of players, then add 1." To explore how this simple rule affects the length of the game, 
we simulated games for 2 through 5 players. We forgo 
estimating the clock time for each decision, and instead report below the average 
number of calls to a `choice` block for a player decision. 

![Pairs Length]({{site.url}}{{site.baseurl}}/images/pairs/PairsGameLength.png){:class="post-image"}
  
We found that there is a consistent 
correspondence between the number of players and the length of the game, demonstrating 
that the scaling is having the desired effect. A different rule could be implemented 
to provide perfect consistency, however the loss of simplicity would not be worth 
the complication.

GAME LENGTH OF ALL AI VS ALL RANDOM???

### Up Next

