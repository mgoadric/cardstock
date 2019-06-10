---
layout: summary
title: Summary and Lead Histories
permalink: /leads/
---

Here is a summary of each game analyzed on this blog, with a reference to its RECYCLE
code, basic statistics, heuristics, and variants. For each game and variant, I've 
included a graph of the [lead histories]({% post_url 2018-12-11-heuristics %})
from the games where all players were AI. 
The histories of the winning players are colored by rank, where the first-place is 
red, second-place is purple, third-place is green, and fourth-place is blue.

### Agram

A simple Nigerian trick-taking card game.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2018-11-26-agram %})
* [Statistics]({{ site.baseurl }}{% post_url 2018-11-28-agram.statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-01-03-agram-heuristics %})

![Agram All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/agram/agram-trends-fixed.png){:class="post-image"}

### Pairs

A quick press-your-luck card game, a "new classic pub game."

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-01-04-pairs %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-01-09-pairs-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-04-pairs-heuristics %})

![Pairs All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/pairs/pairs-trends-fixed.png){:class="post-image"}

### Ninety-Eight

An adding game, simple for kids or as a drinking game.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-02-05-ninety-eight %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-02-05-ninetyeight-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-heuristics %})

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/ninetyeight-trends-fixed.png){:class="post-image"}

* [No King Variant]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-noking %})

![Ninety-Eight All AI Rank Estimate No Kings]({{site.url}}{{site.baseurl}}/images/ninetyeight/ninetyeightnoking-trends-fixed.png){:class="post-image"}

### Stealing Bundles

A fishing game with little complexity and wild point swings.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-03-06-stealing-bundles %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-03-11-bundles-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-03-12-bundles-heuristics %})

![Stealing Bundles All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/stealingbundles/bundles-trends-fixed.png){:class="post-image"}

### Hearts

A classic avoidance trick-taking game.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-03-13-hearts %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-03-18-hearts-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-03-15-hearts-heuristics %})
* [Variants]({{ site.baseurl }}{% post_url 2019-05-06-hearts-variants %})

![Hearts All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/hearts/hearts-trends-fixed.png){:class="post-image"}

### LAMA

A new shedding game with a few scoring twists.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-05-20-lama %})

![LAMA All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/lama/lama-trends4.png){:class="post-image"}

### Heuristics

Each game is also quantified with the following six 
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}), with the 
[Order heuristic]({{ site.baseurl }}{% post_url 2019-03-19-chaos-heuristic %}) added later.


|       Game       | Order | Fairness | Convergence | Spread | Drama | Security |
|------------------|:-----:|:--------:|:-----------:|:------:|:-----:|:--------:|
| Agram            |  0.28 |     0.95 |     0.56    |  0.03  |  0.27 | 0.27     |
| Pairs            |  0.56 |     0.97 |     0.50    |  0.21  |  0.41 | 0.24     |
| Ninety-Eight     |  0.91 |     0.98 |     0.50    |  0.37  |  0.39 | 0.60     |
| Stealing Bundles |  0.36 |     0.88 |     0.51    |  0.14  |  0.51 | 0.19     |
| Hearts           |  0.52 |     0.94 |     0.54    |  0.14  |  0.46 | 0.34     |
| LAMA             |  0.48 |     0.84 |     0.58    |  0.17  |  0.49 | 0.26     |

