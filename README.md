# Abstract Card Game Design and Analysis

## Project Goals

Card games have long been enjoyed by children and adults of all ages. However, some card games are more
popular than others. Our research goal is to computationally simulate various card games and quantify
their quality automatically. We have thus far developed two components: a card
game description language. and an interpreter for this language. Using these
components, we can generate sample run transcripts and analyze their game flow. 

First, we created a language, titled RECYCLE, in which turn-based games can be represented. We restrict
ourselves to games which use only cards and numeric tokens and where all card locations are spatially independent.
Second, we implemented a library, written in C#, called Card Stock, which contains the functions and
mechanisms necessary to run RECYCLE programs and executes the basic operations performed in these card
games. The games written in RECYCLE are simulated with random players to collect statistics, such as player
branching factor, average game length, game complexity, etc.

## Requirements

* Visual Studio (tested on Mac in https://www.visualstudio.com/vs/visual-studio-mac/)

## Setup

1. Open "CardStockXam" project.
2. Write up your game in RECYCLE.
3. Alter the Program.cs class to create an Experiment object for your game.
4. Run the program in either Release or Debug mode.
5. Choose "Release Mode" to only see the results, or "Debug Mode" to see all game actions (better logs in the future).

## References

(Automated Playtesting with RECYCLEd CardStock)[http://mark.goadrich.com/articles/issue-2-1-09-recycled.pdf]

Connor Bell and Mark Goadrich

Game & Puzzle Design Journal, Vol 2, Issue 1, July 2016

