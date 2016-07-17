# Abstract Card Game Design and Analysis

## Project Goals

Card games have long been enjoyed by children and adults of all ages. However, some card games are more
popular than others. Our research goal is to computationally simulate various card games and quantify
their quality automatically. We have thus far developed two components: a card
game description language. and an interpreter for this language. Using these
components, we can generate sample run transcripts and analyze their game flow. 

First, we created a language, titled RECYCLE, in which turn-based games can be represented. We restrict
ourselves to games which use only cards and numeric tokens and where all card locations are spatially independent.
Second, we implemented a library, written in C#, called CardStock, which contains the functions and
mechanisms necessary to run RECYCLE programs and executes the basic operations performed in these card
games. The games written in RECYCLE are simulated with random or AI players to collect statistics, such as player
branching factor, average game length, game complexity, etc.

More details of RECYCLE and CardStock can be found in the article "Automated Playtesting with RECYCLEd CARDSTOCK"
by Connor Bell and Mark Goadrich, Game and Puzzle Design Journal, Volume 2 Issue 1 (http://gapdjournal.com/issues/)

## Requirements

* Xamarin Studio (https://www.xamarin.com/download)

## Setup

1. Open "CardStockXam" project.
2. Write up your game in RECYCLE.
3. Set the parameters of the Experiment class in Program.cs.
4. Choose "Release Mode" to only see the results, or "Debug Mode" to see the parsing.
5. Select the "Application Output" button in the lower-right corner to see the results.

When making an Experiment, the following parameters need to be initialized:

* *fileName* Name of game to be simulated.
* *numGames* How many games to simulate in total.
* *numEpochs* How many divisions of the games, useful for generating statistical significance of results.
* *logging* Set to "true" to record all game actions for visualization.
* *ai* Set to "true" to have the first player use the Partial Information Monte Carlo strategy. All other players remain random.
