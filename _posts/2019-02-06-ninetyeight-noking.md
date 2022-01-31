---
title: 'Ninety-Eight: King Effect'
date: 2019-02-06 18:10:18 Z
categories:
- ADDER
layout: post
image: images/king.png
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Bonus post! To fully test a few of the observations in the last post related to the Kings, I coded up a four-player
version of Ninety-Eight that changed the value of Kings to 0 instead of making them set the total
discard pile value to 98. It had a striking effect in three areas!

First, it looks like the games are longer, and they are! Here's a bar chart comparison
of the average game lengths. The version with no King superpowers is about three to four
times as long, and the all AI games are slightly longer with the players playing 
more carefully to get to 98 slower.

![Ninety-Eight Length]({{site.url}}{{site.baseurl}}/images/ninetyeight/gamelengthnoking.png){:class="post-image"}

With longer games, should we worry that the cards will run out? Some other games
shuffle the discard pile, but here every card in the discard contributes in some way
to the total value, so we should hesitate to do that. Luckily, if we sum up all the 
point values for individual number cards, and subtract 40 for the 4 Tens, we get
104, which will just barely put us over the needed 98 before we run out of cards. 
Thus, the rule where a player can only draw if there are still cards will be fine.

![Ninety-Eight Convergence]({{site.url}}{{site.baseurl}}/images/ninetyeight/convergencenoking.png){:class="post-image"}

Finally, while most of the players still believe they will win the game, our quick game ends are now missing.
Only small blips appear in the middle of the game, most likely due to some noise in the
random simulations that the AI players use. In the latter quarter of the game, we start to see the
discard pile total rise close to 98, with players expecting others to fail with their
random simulations, but these other players actually recovering with intelligent play. 
The game is not fully decided until the last few turns of the game.

![Ninety-Eight All AI Rank Estimate No Kings]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatenoking.png){:class="post-image"}

Compare this to the previous lead history graph for four players, and we can see how
the Kings bring an unexpected element to the game.

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner4p.png){:class="post-image"}

With the ability of the Kings to completely change the effect of the game, and the 
amount of instability and fun they add, I'll look later into more variants 
to see how other superpowered
cards like you see in UNO (Skip, Reverse, etc) can start to counteract the King.

#### Up Next - Stealing Bundles

Our next game will be [Stealing Bundles](https://www.pagat.com/fishing/bundle.html),
a simple [fishing game](https://www.pagat.com/fishing/) related to more popular
and complicated games like [Casino](https://www.pagat.com/fishing/casino.html)
and [Scopa](https://www.pagat.com/fishing/scopone.html), which has recently
been studied with [Monte Carlo Tree Search](https://arxiv.org/abs/1807.06813v1)
AI techniques.

Give the rules a try, and
I'll walk through the RECYCLE coding for Stealing Bundles next! 

(Image courtesy of [BoardGameGeek](https://boardgamegeek.com/image/3677019/pairs))