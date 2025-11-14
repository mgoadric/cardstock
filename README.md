# RECYCLEd CardStock V2.0

![slider-1](https://github.com/user-attachments/assets/64ad3161-8626-444d-9e3d-89c5ebadcf45)

## Project Goals

CardStock is a General Game Playing engine for card games implemented 
in C#. Games are written in RECYCLE, a card game description language, and
then simulations are run with random, simple, and complex AI players. CardStock can then
analyze the games to determine heuristics about the games
such as fairness, decisiveness, drama, or clarity, and generate transcripts of
each simulation for further study.

We are currently abstracting and refactoring CardStock to allow
for new game functionality and setting up a modular system for a
tournament of AI players. Please post any issues you find. 

## Games

There are currently 70+ games coded in RECYCLE, a mixture of classic and modern games, 
categorized by genre:

* Adding
    * [Caterpillar](http://www.parlettgames.uk/oricards/caterpil.html) (2p)
    * [Cribbage](https://www.pagat.com/adders/crib6.html) (2p)
    * [Ninety Eight](https://www.pagat.com/adders/98.html) (4p)
    * [Poison](https://reglur.spilavinir.is/Poison.pdf) (5p)
* Catch and Collect
    * [6 Nimmt](https://cdn.1j1ju.com/medias/c6/c2/f9-6-nimmt-rulebook.pdf) (5p)
    * Enchère (3p)
    * [GOPS](https://www.pagat.com/misc/gops.html) (2p)
    * [Go Fish](https://www.pagat.com/quartet/gofish.html) (2-4p)
    * Pico (2p)
        * Pico 2
    * [Trio](https://desktopgames.com.ua/games/8469/trio_rules_ua.pdf?srsltid=AfmBOoqfuC6zq1nDtEVy4m1z32k5_Pz76XzDyzoOJ94PuKZx0Ym-rgau) (4p)
    * [Turn the Tide](https://gamewright.com/pdfs/Rules/TurnTheTide-RULES.pdf) (3p)
* Climbing
    * [Comet](http://www.catsatcards.com/Games/Comet.html) (2p)
    * [Escalation!](https://boardgamegeek.com/boardgame/26884/escalation) (4p)
    * [LAMA](https://boardgamegeek.com/filepage/180052/lama-official-rules) (2-6p)
    * [President](https://www.pagat.com/climbing/president.html) (4-5p)
* Deck Building
    * [Abandon All Artichokes](https://gamewright.com/pdfs/Rules/AAArules_v2.pdf) (2p)
* Drafting
    * [Sushi Go!](https://cdn.1j1ju.com/medias/e5/92/74-sushi-go-rulebook.pdf) (4p)
* Draw and Discard (or Discard and Draw)
    * [Clocktowers](https://boardgamegeek.com/boardgame/12538/clocktowers) (2p)
    * [Golf Six](https://www.pagat.com/draw/golf.html) (2-4p)
    * [Lost Cities](https://cdn.1j1ju.com/medias/c8/66/47-lost-cities-rulebook.pdf) (2p)
    * [Love Letter](https://cdn.1j1ju.com/medias/83/b2/32-love-letter-rulebook.pdf) (3-4p)
    * [Rummy](https://www.pagat.com/rummy/rummy.html) (2p) 
    * [Spite and Malice](https://www.pagat.com/patience/spitemal.html) (2p)
* Exchange
    * [Cuckoo](https://www.pagat.com/cuckoo/cuckoo.html) (6p)
    * [Schwimmen](https://www.pagat.com/commerce/schwimmen.html) (5p)
* Fishing
    * [Escoba](https://www.pagat.com/fishing/escoba.html) (2p)
    * [Scopa](https://www.pagat.com/fishing/scopa.html) (2p)
    * [Stealing Bundles](https://www.pagat.com/fishing/bundle.html) (2-4p)
* Poker
    * [Kuhn Poker](https://en.wikipedia.org/wiki/Kuhn_poker) (2p)
    * [Leduc Poker](https://pettingzoo.farama.org/environments/classic/leduc_holdem/) (2p)
* Push Your Luck
    * [BlackJack](https://www.pagat.com/banking/blackjack.html) (2p)
    * [Diamant](https://cdn.1j1ju.com/medias/90/3c/55-diamant-rulebook.pdf) (8p)
    * [Gold Rush](https://boardgamegeek.com/boardgame/290/gold-digger) (3p)
    * [Nanuk](https://www.sjgames.com/nanuk/img/nanuk_rules.pdf) (6p)
    * [No Thanks](https://world-of-board-games.com.sg/docs/No-Thanks.pdf) (3-5p)
    * [Pairs](https://cheapass.com/wp-content/uploads/2018/02/PairsCompanionBookWebFeb2018.pdf) (2-5p)
        * Continuous Pairs (4p)
        * Calamity Continuous Pairs (4p)
        * Port (4p)
* Shedding
    * [Crazy Eights](https://www.pagat.com/eights/crazy8s.html) (4p)
        * Sane Eights (4p)
    * [Page One](https://www.pagat.com/inflation/page_one.html) (3p)
    * [Simon's Cat](https://www.sjgames.com/simonscat/Simons-Cat-Rules.pdf) (4p)
    * [Skittgube](https://www.pagat.com/beating/skitgubbe.html) (3p)
* Trick Taking
    * Ace-Ten
       * [Briscola](https://www.pagat.com/aceten/briscola.html) (2p)
           * [Trifle](https://docs.google.com/document/d/1iA_T4TFRV0yHf20Vufhqci0CJfEHRTM9alF2f76J-tE/edit?tab=t.0) (2p)
       * [Klaverjassen](https://www.pagat.com/jass/klaverjassen.html) (4p)
       * [Sheepshead](https://www.pagat.com/schafkopf/shep.html) (5p)
           * Cheesheads (5p)
       * [Sueca](https://www.pagat.com/aceten/sueca.html) (4p)
    * All Fours
        * [California Jack](https://www.bicyclecards.com/how-to-play/california-jack/) (2p)
        * [Pitch](https://www.pagat.com/allfours/pitch.html#players) (4p)
        * [Shasta Sam](https://www.bicyclecards.com/how-to-play/shasta-sam/) (4p)
    * Avoidance
        * [Hearts](https://www.pagat.com/reverse/hearts.html) (3-5p)
           * Omnibus Hearts (4p)
           * Broken Hearts (4p)
           * Pure Hearts (4p)
           * Grey Lady (4p)
           * Black Maria (4p)
           * Spot Hearts (4p)
        * [Knaves](http://whiteknucklecards.com/games/knaves.html) (3-4p)
        * [Polignac](http://whiteknucklecards.com/games/polignac.html) (4p)
        * [Slobberhannes](http://whiteknucklecards.com/games/slobberhannes.html) (4p)
    * Whist
       * [German Whist](https://www.pagat.com/whist/german_whist.html) (2p)
       * [Spades](https://www.pagat.com/auctionwhist/spades.html) (4p)
       * [Whist](https://www.pagat.com/whist/whist.html) (4p)
    * Others
       * [Agram](https://www.pagat.com/last/agram.html) (2-5p)
       * [Duck Soup](http://www.parlettgames.uk/oricards/ducksoup.html) (2p)
       * [Euchre](https://www.pagat.com/euchre/euchre.html) (4p)
       * [The Fox in the Forest](https://boardgamegeek.com/filepage/148606/official-english-rulebook)  (2p)
       * [The Bottle Imp](https://tesera.ru/images/items/11335/Bottle_Imp_Rules_EN.pdf) (3-4p)
* Unique
    * [Coloretto](https://www.riograndegames.com/wp-content/uploads/2013/02/Coloretto-Rules.pdf) (4p)
    * [Coup](http://boardgame.bg/coup%20rules%20pdf.pdf) (4p)

Please check the [wishlist](https://github.com/mgoadric/cardstock/issues/44) for games that we would love 
to have implemented in Recycle. Pull requests are welcome and encouraged!

## Requirements

* [Visual Studio Code](https://code.visualstudio.com/)
* [.NET Core v 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* [C# Dev Kit Extension](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csdevkit)
* [ANTLR4 grammar syntax support](https://marketplace.visualstudio.com/items/?itemName=mike-lischke.vscode-antlr4)

## Setup

1. Install .NET Install Tool Extension
2. Get .Net Core 9.0
3. Install C# Dev Kit Extension
4. Open `CardStock` folder in the project using Visual Studio Code.

## Usage

6. Open the CardStock subdirectory
7. Write up your game in RECYCLE in the `games` subdirectory.
8. Alter the `Program.cs` class to specify the name of your game.
9. Run the program in either Release or Debug mode.
    1. For Release mode, in the terminal type "dotnet run --configuration Release"
    2. Choose "Release Mode" to only see the results, or "Debug Mode" to see all game actions (better logs in the future).
10. Analyse your results (found in the `output` subdirectory) with the Jupyter Notebooks in the `Analysis` directory.

## References

* [The Shape of Card Games Blog](http://mgoadric.github.io/cardstock)
* [ReadTheDocs.io](http://cardstock.readthedocs.io)
* [Automated Playtesting with RECYCLEd CardStock](http://mark.goadrich.com/articles/issue-2-1-09-recycled.pdf), Connor Bell and Mark Goadrich, *Game & Puzzle Design Journal*, Vol 2, Issue 1, July 2016
* [Quantifying the Space of Hearts Variants](http://mark.goadrich.com/articles/Hearts_ACS_2021.pdf), Mark Goadrich and Collin Shaddox, *Advances in Computer Games 2021*, November 2021

## Citation

To cite this project, please use the following reference

```text
@article{Bell_Goadrich_2016,
         title={Automated Playtesting with RECYCLEd CardStock},
         author={Bell, Connor and Goadrich, Mark},
         journal={Game & Puzzle Design},
         volume={2}, number={1},
         year={2016}, pages={71–83}}
```
