---
layout: post
title:  "Agram Variants"
date:   2018-11-29 09:43:18 -0600
categories: TRICK-TAKING
image: images/playing-cards.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

### Variants

We can easily explore variants of Agram by changing one number in the RECYCLE description. 
Our first set of variants altered **the number of cards dealt** to each player from one to six, 
while fixing the number of players at two. The next figure shows the results for each 
hand size using random players. We can see that with four, five or six cards, the game 
appears fair, however, a clear bias for the first player emerges as the number of cards is 
reduced. We believe that because the suit led becomes the highest precedence, it is very 
unlikely in such limited games that the following player is able to follow suit and 
thus is doomed to failure. 

![Agram Fairness]({{site.url}}{{site.baseurl}}/images/agram/agramone.png){:class="post-image"}
    
These results track with the known variants of Agram. In particular, the version in 
which players are dealt only five cards instead of six is known as [Sink-Sink](https://www.pagat.com/last/agram.html). 
There are no established variants of smaller size, perhaps due to a human player's refusal to repeatedly play a game that is unfair.

![Agram Fairness2]({{site.url}}{{site.baseurl}}/images/agram/agramtwo.png){:class="post-image"}

Our second set of variants retains the deal of six cards, but changes **the number of 
tricks played** before determining the winner. As above, we fix the number of players 
at two and run simulations with random players. In the above figure, we see that 
most variants are relatively balanced games, except for when the game is decided 
after playing only one trick.

### Conclusions



