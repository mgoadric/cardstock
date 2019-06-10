---
layout: post
title:  "LAMA: One Round"
date:   2019-06-04 09:10:18 -0600
categories: SHEDDING
image: images/lamaplay.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

LAMA is now [coded in RECYCLE]({{ site.baseurl }}{% post_url 2019-05-20-lama %}), so 
we are ready to begin our simulations in [CardStock](http://github.com/mgoadric/cardstock) with both random and 
[AI players](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html). 
The full game of LAMA takes place over multiple rounds, ending when one player
passes 40 points. However, in this first post I'll be simulating only a single round,
to get a feel for how the game is played, and the compare these results to the
full game in a later post.

As before, to gather statistics for this post, we ran 100 games with all random players, 100 games with 
one AI and the rest random players, and 100 games with all AI players. 
For LAMA, we did these simulations for
2, 3, 4, 5, and 6 players. Let's see how it scores on our 
heuristics of **Order, Fairness, Convergence, Spread, Drama, and Security**. 

(See this previous post for a [review of the heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) I'll be 
discussing.)

#### Order = 0.48

First, we'll see how the AI players fare against chaos. Order captures the gain of the 
AI player when pitted against random players.

![LAMA Markov Gain]({{site.url}}{{site.baseurl}}/images/lama/aiwinrate.png){:class="post-image"}

We can see that in LAMA, the AI players perform quite well! I suspect that the random players are 
folding more often when they should be playing their cards to the discard pile.

#### Fairness = 0.84



![LAMA Fairness]({{site.url}}{{site.baseurl}}/images/lama/fairness.png){:class="post-image"}


#### Convergence = 0.58

![LAMA Convergence]({{site.url}}{{site.baseurl}}/images/lama/convergence.png){:class="post-image"}

![LAMA Game Length]({{site.url}}{{site.baseurl}}/images/lama/gamelength.png){:class="post-image"}

#### Spread = 0.17


![LAMA Spread]({{site.url}}{{site.baseurl}}/images/lama/allaionegame4.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/color-history4.png){:class="post-image"}


#### Drama = 0.49


#### Security = 0.26

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/leadhistory4.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/lama-trends4.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/lama-trends2.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/lama-trends3.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/lama-trends5.png){:class="post-image"}

![LAMA  All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/lama/lama-trends6.png){:class="post-image"}

#### Summary

Here is our summary graph of all the heuristics for LAMA, showing visually the low spread
and high fairness.

![LAMA Heuristics]({{site.url}}{{site.baseurl}}/images/lama/heuristics.png){:class="post-image"}

So, can we conclude that 10% of the time in Hearts, a player will shoot the moon? 
Not exactly. It is worth noting that this estimate of 10% is based on the current weak AI model
used in our CardStock simulations, which makes no assumptions about the 
intelligence of the other players when deciding on a move. More advanced AI players
may be able to detect the Shoot the Moon strategy being attempted and thwart it
by sacrificing a few points.

#### Up Next - Full Game

