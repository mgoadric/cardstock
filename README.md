# RECYCLEd CardStock V2.0

![UML Diagram](CardStock.png)

## Project Goals

CardStock is a General Game Playing engine for card games implemented 
in C#. Games are written in RECYCLE, a card game description language, and
then simulations are run with random, simple, and complex AI players. CardStock can then
analyze the games to determine heuristics about the games
such as fairness, decisiveness, drama, or clarity, and generate transcripts of
each simulation for further study.

There are currently 30 games coded in RECYCLE, from genres such as 
press-your-luck, fishing, adding, draw-and-discard, and trick-taking
games. We are currently in the process of abstracting and refactoring CardStock to allow
for new game functionality and setting up a modular system for a
tournament of AI players. Please check back for further progress on these issues.

## Requirements

* Visual Studio (tested on Mac in https://www.visualstudio.com/vs/visual-studio-mac/)

## Setup

1. Open "CardStockXam" project.
2. Write up your game in RECYCLE.
3. Alter the Program.cs class to create an Experiment object for your game.
4. Run the program in either Release or Debug mode.
5. Choose "Release Mode" to only see the results, or "Debug Mode" to see all game actions (better logs in the future).

## References

[Automated Playtesting with RECYCLEd CardStock](http://mark.goadrich.com/articles/issue-2-1-09-recycled.pdf)

Connor Bell and Mark Goadrich

Game & Puzzle Design Journal, Vol 2, Issue 1, July 2016
