---
title: 'Hearts: Variant Analysis'
date: 2019-05-05 15:10:18 Z
categories:
- TRICK-TAKING
layout: post
image: images/hearts-variants.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Our [last post]({{ site.baseurl }}{% post_url 2019-03-15-hearts-heuristics %}) 
on [Hearts](https://www.pagat.com/reverse/hearts.html)
showed that the Shoot The Moon strategy can actually be a viable option, with
9% of the simulations resulting in players collecting every penalty card. 
These games were very dramatic, but otherwise, Hearts scored poorly on our
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) with low game drama, 
a low spread of choices, and moderate stability. 

Can these scores be improved or altered with rule changes? This really start to get to
the heart (*pun intended*) of one of my eventual goals with this project, evolutionary
game design, such that computer can make edits and changes to the rules of a game, 
moving it toward a better experience for the players.

### Variants

Today, we'll look 
at **seven variants of Hearts**, some close relatives, some long-distant ancestors, and see
what effect they have on the game. This only touches the surface of the 
Hearts variants I came across while searching, so if another version interests you,
please let me know.

The graph below shows the 
[average trend graph]({{ site.baseurl }}{% post_url 2019-05-03-average-trend %})
for the aggregate 
lead histories in Hearts. When we put them all together, I think it is easier to follow the
game flow for each player. We'll be comparing each variant to the graph shown here. 

![Hearts All AI Rank Estimate 4p]({{site.url}}{{site.baseurl}}/images/hearts/hearts-trends-fixed.png){:class="post-image"}

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

Second, there are more peaks and jagged lines in the That's No Moon variant than Hearts, 
meaning that in this game, the player order becomes more set as the game progresses. 

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
to standard Hearts, at 11%.

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

This looks like it might keep the benefits from the Omnibus variant and add in a tighter early game! 
The periodic peaks in the endgame
from the Shoot the Moon strategy are still there, and are actually a little more pronounced. And, the first and second-place 
players are much closer for most of the game, only diverging in the last third.

Nice work, Sean!

#### Polignac

For the last three variants, we look back in time to early ancestors of Hearts.
In [Polignac](http://whiteknucklecards.com/games/polignac.html),
which uses a reduced deck of cards, only using 7 through Ace in each suit, leaving us
with 32 cards. Polignac is played like Knaves but with **another penalty for taking the first and last trick**.
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
the winner is above the drama threshold for most of the game.

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

### Heuristic Comparison

The graphs above are extremely useful for visualizing the differences between these variants.
But do these insights translate into any meaningful differences in the 
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}) summary values?
We'll focus on only four of our usual heuristics, since all of these variants score
similarly on Fairness and Convergence.

#### Spread

First, let's look at **Spread**, which is the average magnitude of differences
in choice for each player in the game. Games with more larger spread should mean games
with more important choices for the player. We'll plot and label the values for these seven 
variants on a simple line, as shown below, with Hearts highlighted in red.

![Variant Spread]({{site.url}}{{site.baseurl}}/images/hearts/variant-spread.png){:class="post-image"}

To the far left of Hearts, we see Polignac and Slobber Hannes. This makes sense, as the important choices in these games
are very infrequent, since they involve many tricks and only a few point cards.

Closer, yet still to the left, we see our first variants that removed critical rules: That's No Moon, and Black
Maria. 

To the right of Hearts, we see Grey Maria and Omnibus, showing that there are more important
choices to be made in these later games. 

Interesting, though, is the appearance of Knaves
on the far right! This could be an artifact of this game only involving 3 players, thus 
making the rank estimates harder to compare to the other four-player games. But it could
also be due to the mixture of incentives to take tricks but avoid certain cards. 
I will have to play a few rounds in person to see if there is something else going on.

I also think I need to add some more instrumentation to my CardStock system so I can make some better
graphs for spread. I'm still not sure why these numbers are consistently low (0.12 to 0.19) 
across all these different games, and more data could always help.

#### Drama

Next, we plot how the variants perform on **Drama**. Drama should capture the magnitude of 
dips below the "drama threshold" for the winning player.

![Variant Drama]({{site.url}}{{site.baseurl}}/images/hearts/variant-drama.png){:class="post-image"}

Again to the left of Hearts, we first find Slobber Hannes and Polignac. As the winners are clear
in these games early, there is less opportunity for dramatic wins. Next, we see That's No Moon, 
which also makes sense, since we removed the opportunity for the dramatic win-from-behind
scoring option.

We see only Omnibus contain much more Drama than Hearts, and this difference is minuscule. 
This variant keeps the scores tighter throughout the game and make the winner more uncertain. 

#### Order

Third, we find out how much **Order** is present in the games. High values for 
Order means than the AI players have an easy time beating random players, while
low values mean that beating random players is much more difficult.

![Variant Order]({{site.url}}{{site.baseurl}}/images/hearts/variant-order.png){:class="post-image"}

As expected, Slobber Hannes is an easy game to win for our AI players, followed by Knaves
as the second-easiest. The graph is hard to read in the middle, because
Polignac overlaps exactly with Hearts.

On the low end, we find Black Maria and Omnibus a significant
distance from Hearts. I can definitely see how a bad hand in Black Maria could prove
disastrous, with players playing their Hearts randomly messing up the potential 
for AI strategy. But I am confused as to why Omnibus shows up so low? I think because
the Jack of Diamonds is a high card, more likely to win a trick, and it is 
dealt randomly to a player, it is more the luck of the draw if this will
be available as a positive source.

#### Security

Finally, we'll look at the **Security** of each game, capturing how long the 
winning player believes they are winning.

![Variant Security]({{site.url}}{{site.baseurl}}/images/hearts/variant-security.png){:class="post-image"}

This heuristic tracks most closely with what the average trend graphs were showing us above.
Knaves, Polignac, and Slobber Hannes all have very high Security, with the winner above the
drama threshold and knowing they are the winner more than 75% of the game. On the other hand,
Grey Maria and Omnibus have a much lower value for Security. Original Hearts remains the least
secure of all the variants, though.

### Up Next - L.A.M.A.

This post was longer than usual, thanks for reading! I'd love to hear if you have 
any other unique variants that shouldn't be missed in this analysis.

Up next, w're emerging from the past to examine a much more recent game next!
[L.A.M.A](https://boardgamegeek.com/boardgame/266083/lama)
is a recent release from 
[Reiner Knizia](https://en.wikipedia.org/wiki/Reiner_Knizia) and 
[AMIGO Games](https://www.amigo.games/). In L.A.M.A, players must quickly shed
their hand, but can also bow out and bet they will earn less points than other 
players. And it involves llamas! It looks to be a combination of a few simple mechanics, tune in next
time to see how it fares in our system.

<hr>
<a href="http://www.freepik.com">The black hearts variant image designed by rawpixel.com / Freepik</a>