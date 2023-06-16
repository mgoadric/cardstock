# RECYCLEd CardStock V2.0

![UML Diagram](CardStock.png)

## Project Goals

CardStock is a General Game Playing engine for card games implemented 
in C#. Games are written in RECYCLE, a card game description language, and
then simulations are run with random, simple, and complex AI players. CardStock can then
analyze the games to determine heuristics about the games
such as fairness, decisiveness, drama, or clarity, and generate transcripts of
each simulation for further study.

We are currently in the process of abstracting and refactoring CardStock to allow
for new game functionality and setting up a modular system for a
tournament of AI players. Please check back for further progress on these issues.

## Games

There are currently 41 games coded in RECYCLE

* Press Your Luck
    * [BlackJack](https://www.pagat.com/banking/blackjack.html) (2p)
    * [Pairs](https://cheapass.com/wp-content/uploads/2018/02/PairsCompanionBookWebFeb2018.pdf) (2-5p)
        * Continuous Pairs (4p)
        * Calamity Continuous Pairs (4p)
* Fishing
    * [Stealing Bundles](https://www.pagat.com/fishing/bundle.html) (2-5p)
* Shedding
    * [Comet](http://www.catsatcards.com/Games/Comet.html) (2p)
    * [Crazy Eights](https://www.pagat.com/eights/crazy8s.html) (4p)
        * Sane Eights (4p)
    * [Simon's Cat](https://www.sjgames.com/simonscat/Simons-Cat-Rules.pdf) (4p)
* Adding
    * [Caterpillar](http://www.parlettgames.uk/oricards/caterpil.html) (2p)
    * [Ninety Eight](https://www.pagat.com/adders/98.html) (4p)
* Draw and Discard
    * [Golf](https://www.pagat.com/draw/golf.html) (2p)
    * [Lost Cities](https://cdn.1j1ju.com/medias/c8/66/47-lost-cities-rulebook.pdf) (2p)
    * [Spite and Malice](https://www.pagat.com/patience/spitemal.html) (2p)
* Trick Taking
    * [Agram](https://www.pagat.com/last/agram.html) (2-5p)
    * [California Jack](https://www.bicyclecards.com/how-to-play/california-jack/) (2p)
    * [Duck Soup](http://www.parlettgames.uk/oricards/ducksoup.html) (2p)
    * [German Whist](https://www.pagat.com/whist/german_whist.html) (2p)
    * [Hearts](https://www.pagat.com/reverse/hearts.html) (3-5p)
        * Omnibus Hearts (4p)
        * Broken Hearts (4p)
        * Pure Hearts (4p)
        * Grey Lady (4p)
        * Black Maria (4p)
        * Spot Hearts (4p)
    * [Knaves](http://whiteknucklecards.com/games/knaves.html) (3-4p)
    * [Polignac](http://whiteknucklecards.com/games/polignac.html) (4p)
    * [Shasta Sam](https://www.bicyclecards.com/how-to-play/shasta-sam/) (4p)
    * [Sheepshead](https://www.pagat.com/schafkopf/shep.html) (5p)
        * Cheesheads (5p)
    * [Spades](https://www.pagat.com/auctionwhist/spades.html) (4p)
    * [Slobberhannes](http://whiteknucklecards.com/games/slobberhannes.html) (4p)
    * [The Bottle Imp](https://tesera.ru/images/items/11335/Bottle_Imp_Rules_EN.pdf) (3-4p)
    * [Whist](https://www.pagat.com/whist/whist.html) (4p)
* Catch and Collect
    * Enchère (3p)
    * [GOPS](https://www.pagat.com/misc/gops.html) (2p)
    * [Go Fish](https://www.pagat.com/quartet/gofish.html) (2p) *limited deck*
    * [Turn the Tide](https://gamewright.com/pdfs/Rules/TurnTheTide-RULES.pdf) (3p)
* Unique
    * [Coloretto](https://www.riograndegames.com/wp-content/uploads/2013/02/Coloretto-Rules.pdf) (4p)
    * [Coup](http://boardgame.bg/coup%20rules%20pdf.pdf) (4p)
    * [LAMA](https://boardgamegeek.com/filepage/180052/lama-official-rules) (2-6p)

## Requirements

* Visual Studio (tested on Mac in https://www.visualstudio.com/vs/visual-studio-mac/)

## Setup

1. Open "CardStockXam.sln" project.
2. Write up your game in RECYCLE.
3. Alter the Program.cs class to specify the name of your game.
4. Run the program in either Release or Debug mode.
5. Choose "Release Mode" to only see the results, or "Debug Mode" to see all game actions (better logs in the future).

## References

* [The Shape of Card Games Blog](http://mgoadric.github.io/cardstock)
* [ReadTheDocs.io](http://cardstock.readthedocs.io)
* [Automated Playtesting with RECYCLEd CardStock](http://mark.goadrich.com/articles/issue-2-1-09-recycled.pdf), Connor Bell and Mark Goadrich, *Game & Puzzle Design Journal*, Vol 2, Issue 1, July 2016
* [Quantifying the Space of Hearts Variants](http://mark.goadrich.com/articles/Hearts_ACS_2021.pdf), Mark Goadrich and Collin Shaddox, *Advances in Computer Games 2021*, November 2021
