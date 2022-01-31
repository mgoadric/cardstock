---
title: Welcome to The Shape of Card Games!
date: 2018-11-26 15:43:18 Z
categories:
- GENERAL
layout: post
image: images/all-cards.jpg
author: Mark Goadrich
avatar: images/goadrich.png
authorhome: http://mark.goadrich.com
comments: true
---

Welcome! I've always been fascinated with card games. Both sides of my family would routinely play
games when we gathered, with our favorites being [Euchre](https://www.pagat.com/euchre/euchre.html),
[Tock](https://en.wikipedia.org/wiki/Tock), [Louse Your Neighbor](https://wizardofodds.com/games/screw-your-neighbor/),
and [Gin Rummy](https://www.pagat.com/rummy/ginrummy.html). It amazed me that such 
variation could arise from the same deck of cards, and when I started [designing
my own games](http://games.goadrich.com/), inevitably, I would end up exploring new methods 
of creating a deck of cards and the interesting mechanics these changes allowed.

For the past four years, I've been working
with some amazing students ([Connor Bell](https://github.com/connorbelll), 
[Colin Shaddox](https://github.com/shaddoxac), 
[Anna Holmes](https://github.com/annaholmes), and 
[Daniel Sweeney](https://github.com/DxSweeney1)) to build a card game simulation engine called
[CardStock](http://github.com/mgoadric/cardstock), along with a new
language for programming card games named [RECYCLE](https://cardstock.readthedocs.io/en/latest/recycle/index.html).
This blog is a culmination and continuation of this research project
investigating the structure, dynamics, and mechanics of card games. 

The first few years were just getting things to work and laying our 
our framework. By now, we've implemented and explored many card games, 
from classics such as [Spades](https://en.wikipedia.org/wiki/Spades) and 
[Hearts](https://en.wikipedia.org/wiki/Hearts) to modern card games such as [Coloretto](https://boardgamegeek.com/boardgame/5782/coloretto), 
[Lost Cities](https://boardgamegeek.com/boardgame/50/lost-cities), and 
[The Bottle Imp](https://boardgamegeek.com/boardgame/619/bottle-imp). And with over 26 games written in RECYCLE, it is time
to start diving deeper to find connections and see how these computational tools can
help us understand how card games work and maybe how to make better ones.

I'll be writing articles about once a week, addressing a particular game
we've simulated with our system, and plan to continue posting for at least a year.
For each game, we'll walk through how it's coded in RECYCLE,
some basic summary statistics, more advanced heuristics for capturing
player behavior, and finally discuss any common variants. 
First up will be [Agram](https://www.pagat.com/last/agram.html), a simple Nigerian 
trick-taking card game for 2 to 6 players. Go ahead and play a few rounds, before
next week's post is up, and see what you think of how it works.

Through this process, there are a number of research questions I hope to answer:

* At a minimum, is each game fair, balanced, and interesting?
* Can we cluster card games by their rules, structure, or behavior?
* What AI techniques are most feasible for general card game playing?
* Can insights from studying natural card game evolution help computers create new games?
* What are appropriate heuristics for evaluating card games?

Thanks for joining me on this project, let me know if there are other questions 
you think we could answer, or games you want to see covered!