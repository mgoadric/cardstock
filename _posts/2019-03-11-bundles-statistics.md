---
layout: post
title:  "Stealing Bundles: Basic Statistics"
date:   2019-03-10 8:46:18 -0600
categories: FISHING
image: images/bundle-paper.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

With the basic [Stealing Bundles coded in RECYCLE]({% post_url 2019-03-06-stealing-bundles %}), it is time to run many 
simulations in [CardStock](http://github.com/mgoadric/cardstock) with both random and 
[AI 
players](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html). 
As before, to gather statistics for this and the next post on heuristics, we ran 100 games with all random players, 100 games with 
one AI and the rest random players, and 100 games with all AI players. We did these 
simulations for
2, 3, and 4 players. Let's see if we can
answer some basic questions about the game.

#### Are there sufficient choices for players?

Stealing Bundles follows the trick-taking mechanic of "everyone plays one card each round", but
has a different method of distributing the cards. With only four cards being dealt to the players
at a time, it feels like you are always in the last few rounds of a trick taking game. We can see
the pattern of card choices in the image below showing the choices per player in a four-player game.

![Stealing Bundles Choices]({{site.url}}{{site.baseurl}}/images/stealingbundles/choices.png){:class="post-image"}

Without any restriction to follow suit, each player has the same number of choices each round, and this
decreases by one each round.
However, in the beginning of the game, players have very little knowledge of the total card landscape, 
so the results of any decisions are hard to quantify. We'll see more of how this repeated dealing
affects game play when we 
discuss heuristics in a future post.

#### How does game length vary with the number of players?

The game length of Stealing Bundles does not depend on the number of players, 
as it will always take the same number of turns, namely 48, one for each card not dealt to 
the `POOL` at the start of the game.  So, players will have fewer turns per game when 
there are more players, making the two-player game feel longer than the four-player game.

#### Can players be strategic in Stealing Bundles?  

With the fog of knowledge created by having the cards dealt out piecemeal, are players able to make
strategic choices? The image below shows the win rates of AI players versus random players averaged across the 
2, 3, and 4-player games simulated.

![Stealing Bundles Markov Gain]({{site.url}}{{site.baseurl}}/images/stealingbundles/winprob.png){:class="post-image"}

In comparison with the expected random win rate, shown by the blue line, AI players can perform admirably,
winning on average between 60% and 70%. This rate is much lower than 
[Pairs]({% post_url 2019-01-04-pairs %}) and
[Ninety-Eight]({% post_url 2019-02-05-ninety-eight %}), looking more like the results
we found in [Agram]({% post_url 2018-11-26-agram %}). A player's ability to win in Stealing Bundles is 
dependent on the cards they are dealt, such that even optimal choices by the player can result
in a loss.

### Up Next

Next post, we'll see how Stealing Bundles measures up with our [heuristics]({% post_url 2018-12-11-heuristics %})
and look at the overall gameplay experience with all AI players. What else would you like to 
see analyzed about Stealing Bundles? Let me know in the
comments below, and I'll see if I can incorporate them in future posts. Thanks for reading!