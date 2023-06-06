---
layout: post
title:  "Pairs Variants"
date:   2018-12-10 09:46:18 -0600
categories: PRESS-YOUR-LUCK
image: images/pairs.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

### Variants

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