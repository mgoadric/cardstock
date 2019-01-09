---
layout: post
title:  "Pairs: Basic Statistics"
date:   2019-01-09 08:46:18 -0600
categories: PRESS-YOUR-LUCK
image: images/pairs2.png
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Now that [Pairs is coded in RECYCLE]({% post_url 2019-01-04-pairs %}), we can run many 
simulations in [CardStock](http://github.com/mgoadric/cardstock) with both random and 
[AI 
players](https://cardstock.readthedocs.io/en/latest/aiplayers/pipmc.html). 
To gather statistics for this and the next post on heuristics, we ran 100 games with all random players, 100 games with 
one AI and the rest random players, and 100 games with all AI players. We did these 
simulations for
2, 3, 4, and 5 players. Let's see if we can
answer some basic questions about the game.

#### Are there sufficient choices for players?

Unlike Agram, Pairs is very consistent in the number of choices a player has on their turn: **always 2**.
A player can either end their turn, or flip up a new card from the `STOCK` location.

#### How does game length vary with the number of players?

Even though the choices are limited on each turn for a player, the length of the
game is undetermined. This is the nature of many press-your-luck games; you never really
know if you've gone too far unless you try. 

So, how long is an average game of Pairs? Sometimes you will find a game published with a range of times 
for game length (30-60 minutes), or that each player additional player adds a certain amount of time, say 10 minutes. 
But the advertised game length for Pairs 
is a definitive **15 minutes**. Since we are working with simulated games, we won't try to estimate the actual clock 
time, and instead look at the average 
number of calls to a `choice` block for a player decision, since these should be well-correlated.

In the rules, the number of points necessary to lose a game of Pairs is 
scaled to the number of players, according to the formula "Take 60, divide by the number 
of players, then add 1." Hopefully, there is also a correlation between these ending points
and the length of the game. If done well, we should see that the number of choices,
thus the length of the game, is consistent for any number of players.

![Pairs Length]({{site.url}}{{site.baseurl}}/images/pairs/PairsGameLength.png){:class="post-image"}
  
We can see in the graph above that there is good 
correspondence between the number of players and the length of the game, demonstrating 
that the scaling is having the desired effect. Maybe a different rule could be implemented 
to provide perfect consistency, however the loss of simplicity would not be worth 
the complication.

Interestingly, we also see that **intelligent play make the game longer**! In fact, the 
games with all AI players, have nearly twice as many decisions as those with all random players!

What could be causing this? For a random player, each choice, they are 
essentially flipping a coin, which means they will be more and more likely to 
have ended their turn as a round progresses. However, the AI players are much more likely to push their luck
and keep drawing another card into their hand. With their Monte Carlo simulations, the
AI players are actually playing the odds and betting many times that they will not get a
pair if they keep drawing.

#### Can players be strategic in Pairs?  

We see that AI players change the game length above, but does this correspond to 
improved performance? By looking at the results below, based on simulations with one AI player versus all other
random players, we see the AI performed much better than expected! The AI is the lowest-scoring player
in a majority of the games no matter how many players were playing.

![Pairs Win Prob]({{site.url}}{{site.baseurl}}/images/pairs/winprob.png){:class="post-image"}

And, this appears to be better than the [AI performance in Agram]({% post_url 2018-11-28-agram.statistics %})!
This could mean one of two things: either Pairs is an easier game for an AI to play than Agram, 
or there is more control over the luck and less chaos in Pairs than in Agram. See this
great early article, [Chaos Reigns by Larry Levy](http://web.archive.org/web/20030821212212/http://www.huzonfirstgames.com/ChaosReigns.html)
for more on control, chaos, and luck. I think this idea of chaos and luck could be formulated into another heuristic;
I should have a better handle on how after examining a few more games.

Actually, since the **goal in Pairs is to not lose** as opposed to win outright with the lowest score, our next graph shows
the "non-loss percentage" for the AI player in 
comparison to the expected probability of not losing for a random player. 
We can see the AI is drastically better 
than the random players, quickly approaching a non-loss probability of 1.

![Pairs Markov Gain]({{site.url}}{{site.baseurl}}/images/pairs/PairsMarkovGain.png){:class="post-image"}

### Up Next

Next post, we'll see how Pairs measures up with our [heuristics]({% post_url 2018-12-11-heuristics %})
and look at the overall gameplay experience with all AI players. I'm pretty excited about what we will find.

Are there other questions or statistics you want to see about Pairs? Let me know in the
comments below, and I'll see if I can incorporate them in future posts. Thanks for reading!
