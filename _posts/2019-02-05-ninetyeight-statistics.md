---
layout: post
title:  "Ninety-Eight: Basic Statistics"
date:   2019-02-06 8:46:18 -0600
categories: ADDER
image: images/playing-cards-discard.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

With the basic [Ninety-Eight coded in RECYCLE]({{ site.baseurl }}{% post_url 2019-02-05-ninety-eight %}), it is time to run many 
simulations in [CardStock](http://github.com/mgoadric/cardstock) with both random and 
[AI 
players](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html). 
To gather statistics for this and the next post on heuristics, we ran 100 games with all random players, 100 games with 
one AI and the rest random players, and 100 games with all AI players. We did these 
simulations for
2, 3, 4, and 5 players. Let's see if we can
answer some basic questions about the game.

#### Are there sufficient choices for players?

Ninety-Eight, like [Pairs]({% post_url 2019-01-09-pairs-statistics %}) is very consistent 
in the number of choices a player has on their turn: **always 4**.
A player can play any of their four cards, and then draw a new card from the `STOCK` location.

#### How does game length vary with the number of players?

Even though the choices are limited on each turn for a player, the length of the
game is undetermined. So, how long is an average game of Ninety-Eight? We'll again eschew real time estimates, since we are working with simulated games.
Instead we'll look at the average 
number of calls to a `choice` block for a player decision, since these should be well-correlated.

We can see in the image below that the game will last between
10 and 14 turns on average. This is pretty consistent no matter how many players are
in the game. 

![Ninety-Eight Length]({{site.url}}{{site.baseurl}}/images/ninetyeight/gamelength.png){:class="post-image"}
  
Unlike Pairs, we don't see evidence that the AI players make the game longer or shorter. 
I would have thought that the AI would be more adept at playing Kings to get to 98 faster, 
but perhaps this is offset by the other AI players knowing how to respond with a Ten, Jack,
or Queen. We'll see some hints of the AI strategies in the lead histories 

#### Can players be strategic in Ninety-Eight?  

Yes! The AI players are very likely to do well in Ninety-Eight! The goal is again to not lose,
so we compare the success of an AI player versus other random players to the expected non-loss
rate. While not as striking as in Pairs, the non-loss rate is quickly approaching 1.

![Pairs Markov Gain]({{site.url}}{{site.baseurl}}/images/ninetyeight/nonlossprob.png){:class="post-image"}

### Up Next

Next post, we'll see how Ninety-Eight measures up with our [heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %})
and look at the overall gameplay experience with all AI players. What else would you like to 
see analyzed about Ninety-Eight? Let me know in the
comments below, and I'll see if I can incorporate them in future posts. Thanks for reading!

(Image courtesy of https://www.publicdomainpictures.net/en/view-image.php?image=24744&picture=playing-cards](https://boardgamegeek.com/image/3667931/pairs))