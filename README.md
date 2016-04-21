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

* Xamarin Studio (https://www.xamarin.com/download)

## Setup

1. Open "CardStockXam" project.
2. Write up your game in RECYCLE.
3. Create an instance of the Experiment class.
4. Pass the above object to ParseEngine.
5. Choose "Release Mode" to only see the results, or "Debug Mode" to see all game actions (better logs in the future).
