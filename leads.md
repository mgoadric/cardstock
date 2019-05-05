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

![Agram All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/agram/agram-trends.png){:class="post-image"}

### Pairs

A quick press-your-luck card game, a "new classic pub game."

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-01-04-pairs %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-01-09-pairs-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-04-pairs-heuristics %})

![Pairs All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/pairs/pairs-trends.png){:class="post-image"}

### Ninety-Eight

An adding game, simple for kids or as a drinking game.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-02-05-ninety-eight %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-02-05-ninetyeight-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-heuristics %})

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/ninetyeight-trends.png){:class="post-image"}

* [No King Variant]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-noking %})

![Ninety-Eight All AI Rank Estimate No Kings]({{site.url}}{{site.baseurl}}/images/ninetyeight/ninetyeightnoking-trends.png){:class="post-image"}

### Stealing Bundles

A fishing game with little complexity and wild point swings.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-03-06-stealing-bundles %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-03-11-bundles-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-03-12-bundles-heuristics %})

![Stealing Bundles All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/stealingbundles/bundles-trends.png){:class="post-image"}

### Hearts

A classic avoidance trick-taking game.

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-03-13-hearts %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-03-18-hearts-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-03-15-hearts-heuristics %})

![Hearts All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/hearts/hearts-trends.png){:class="post-image"}

### Heuristics

Each game is also quantified with the following six 
[heuristics]({{ site.baseurl }}{% post_url 2018-12-11-heuristics %}), with the 
[Order heuristic]({{ site.baseurl }}{% post_url 2019-03-19-chaos-heuristic %}) added later.


|       Game       | Order | Fairness | Convergence | Spread | Drama | Security |
|------------------|:-----:|:--------:|:-----------:|:------:|:-----:|:--------:|
| Agram            |  0.19 |     0.80 |     0.56    |  0.04  |  0.24 | 0.46     |
| Pairs            |  0.56 |     0.99 |     0.50    |  0.27  |  0.32 | 0.51     |
| Ninety-Eight     |  0.88 |     0.97 |     0.50    |  0.31  |  0.32 | 0.87     |
| Stealing Bundles |  0.45 |     0.98 |     0.51    |  0.14  |  0.36 | 0.29     |
| Hearts           |  0.48 |     0.99 |     0.54    |  0.13  |  0.33 | 0.56     |
