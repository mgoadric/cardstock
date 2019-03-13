---
layout: summary
title: Summary and Lead Histories
permalink: /leads/
---

Here is a summary of each game analyzed on this blog, with a reference to its RECYCLE
code, basic statistics, heuristics, and variants. For each game and variant, I've 
included a graph of the [lead histories]({% post_url 2018-12-11-heuristics %})
from the games where all players were AI. 
The histories of the winning players are in red, while losing players are in black.

### Agram

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2018-11-26-agram %})
* [Statistics]({{ site.baseurl }}{% post_url 2018-11-28-agram.statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-01-03-agram-heuristics %})

![Agram All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/agram/allairankestimatewinnerbig.png){:class="post-image"}

### Pairs

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-01-04-pairs %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-01-09-pairs-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-04-pairs-heuristics %})

![Pairs All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/pairs/allairankestimatewinner.png){:class="post-image"}

### Ninety-Eight

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-02-05-ninety-eight %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-02-05-ninetyeight-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-heuristics %})

![Ninety-Eight All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatewinner4p.png){:class="post-image"}

* [No King Variant]({{ site.baseurl }}{% post_url 2019-02-06-ninetyeight-noking %})

![Ninety-Eight All AI Rank Estimate No Kings]({{site.url}}{{site.baseurl}}/images/ninetyeight/allairankestimatenoking.png){:class="post-image"}

### Stealing Bundles

* [RECYCLE coding]({{ site.baseurl }}{% post_url 2019-03-06-stealing-bundles %})
* [Statistics]({{ site.baseurl }}{% post_url 2019-03-11-bundles-statistics %})
* [Heuristics]({{ site.baseurl }}{% post_url 2019-03-12-bundles-heuristics %})

![Stealing Bundles All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/stealingbundles/allairankestimatewinner4p.png){:class="post-image"}

### Hearts

![Hearts All AI Rank Estimate]({{site.url}}{{site.baseurl}}/images/hearts/allairankestimatewinner4p.png){:class="post-image"}

### Heuristics

Each game is also quantified with the following five 
[heuristics]({% post_url 2018-12-11-heuristics %}).


|       Game       | Fairness | Convergence | Spread | Drama | Security |
|------------------|:--------:|:-----------:|:------:|:-----:|:--------:|
| Agram            |     0.80 |     0.56    |  0.04  |  0.24 | 0.46     |
| Pairs            |     0.99 |     0.50    |  0.27  |  0.32 | 0.51     |
| Ninety-Eight     |     0.97 |     0.50    |  0.31  |  0.32 | 0.87     |
| Stealing Bundles |     0.98 |     0.51    |  0.14  |  0.36 | 0.29     |
| Hearts           |          |             |        |       |          |
