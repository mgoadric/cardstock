---
layout: post
title:  "Enchère Heuristics"
date:   2023-06-09 12:00:00 -0600
categories: TRICK-TAKING
image: images/enchere/enchere.jpg
author: Tyrone Mason
avatar: images/mason.png
authorhome: https://github.com/mason-t-demond
comments: true
---
Enchère is a game conceived during my first meeting with Dr. Goadrich. There, I was assigned my first goal of research: to create games in the RECYCLE language and become more familiar with it. 

# <u>**Enchère**</u>
## Requirements
- 3 Players
- A standard 52-card deck

## Rules
- Separate the Queens, Kings and Aces from the deck. This deck is known as the prize pile. The remaining cards are known as the cash pile.
- Shuffle each deck.
- Deal 12 cards to each player from the cash pile, the other 4 are set aside.
- Flip the top card of the prize pile so it is face up. This is known as the prize.
- Each player places a card face down as a bid for the prize.
- When all three players have placed a bid, the cards are then flipped over. The winner of the prize is determined as follows.
    - The card with the highest rank wins the bid
    - In the case of the tie, priority is given to the bid whose suit matches the prize's suit.
    - If two players are tied and neither match the suit, the winner is the lowest bidding player.
    - If all three players are tied and neither match the suit, the winner is the player with the off-card (same color as the prize).
- Repeat bidding on prizes until the prize pile is exhausted. Points are given based on a player's possessed prizes.
    - 4 points per Ace
    - 2 points per King
    - 1 point per Queen
- The winner is the first player to reach 50 points.


This game suffers heavily from players with worse cards being disadvantaged. Dr. Goadrich mentioned this to me and suggested that I alter Enchère to create more interesting statistics. This led to the birth of Enchère Avancée.

# <u>**Enchère Avancée**</u>
## Requirements
- 3 Players
- A standard 52-card deck and a Joker card

## Rule Changes from Enchère
- Players are dealt 13 cards from the cash pile.
- The remaining card is known as the spare.
    - Players can bid a card with the same rank as the spare for more priority than matching the prize's suit.
    - If the spare has a very low rank, players with very low cards may benefit.
- Players must now follow the suit of the prize if they can.
    - Before it was optional, now it is necessary if possible.
    - Shifts focus from having high cards to having a balance of suits in hand.
- The Joker is added to the prize pile
    - Helps to penalize players with too good of hands.
- New Scoring System
    - 1 point per card, except
        - 2 points for any Heart
        - 7 points for the King of Hearts
        - -10 points for the Joker
- The winner is the first player to reach 42 points.

While this version of Enchère was much more fleshed out than the first one, it still was not the original idea I came up with for this game. That would be known as Enchère Originale.

# <u>**Enchère Originale**</u>
Enchère Originale was originally going to be excluded but was added in later on after some help from Noah Morris, another researcher in the CardStock project. Enchère was not meant to be a points-based game, but a hand-building game more akin to Poker. The cards that are won are evaluated similar to Poker hands which influences players to try and collect more cards in the same rank. Noah helped me in the scoring of the game, as I had no clue how to go about implementing a Poker-style evaluation in RECYCLE.

I believe this creates more uncertainty in a winner near the beginning of the game, as players need to collect a few cards before a clear leader is determined. Additionally, players do not need to win a majority of the cards to win, as the highest possible hand is a 4-of-a-kind using Aces. Additionally, it is not beneficial for players to target random cards as they may not be able to make a high-scoring hand.

## Requirements
- 3 Players
- A standard 52-card deck

## Rule Changes from Enchère Avancée
This version retains most of the same rules as Enchère Avancée, like the spare and suit following. However, the following changes were made:
- Jokers are removed from the prize pile
- Players are only dealt 12 cards
- Scoring System as follows:
    | Points    | Name        | Description                                 |
    | --------- | ----------- | ------------------------------------------- |
    | 1 point   | 1-Pair      | Two cards of the same rank.                 |
    | 2 points  | 2-Pair      | 2 1-Pairs.                                  |
    | 4 points  | Royal Trio  | 1 Queen, 1 King and 1 Ace in the same suit. |
    | 6 points  | 3-of-a-kind | Possess three cards of the same rank.       |
    | 8 points  | Full House  | 1-Pair + 3-of-a-kind.                       |
    | 10 points | 4-of-a-Kind | Possess every card of one rank.             |
    | 12 points | Max Enchère | Full House using 3 Aces and 2 Kings.        |
    | 15 points | Ace Out     | 4-of-a-kind using 4 Aces.                   |

# <u>**Heuristics**</u>
![Heuristics for the three versions of Enchère](images/enchere/enchere-heuristics.jpg)

## Lead History
![Lead history for the three versions of Enchère](images/enchere/enchere-lead-history.jpg)
For all three games, the lead history was relatively the same in that the winner is known from the beginning of the round and remains the predicted winner throughout the game. The only visible difference is that in Enchère Avancée, the predicted winner changes a bit near the beginning.

## Convergence
Enchère has a much higher convergence than Enchère Avancée and Enchère Originale. This shows that Enchère tends to have more decisions at the end of the game as opposed to the others???

## Drama
Drama for all three versions of the game is relatively similar, however, Enchère was the highest of the three. I believe Enchère has the highest drama of the three due to having a relatively low scoring system. Therefore, getting multiple aces can easily decide the winner of the game. Enchère Avancée can easily have the winner decided by whoever gets the King of Hearts, and Enchère Originale can easily be decided by whoever can simply get the most cards, even if hand-building is a bit different.

## Security
The three versions of the game all have similar security metrics, and all are relatively high, indicating that the players in the lead tend to remain there. Enchère has the highest, as the low-scoring points system makes it harder for players to come back from being down, especially if the aces are gone.

Enchère Originale is the lowest, which makes sense as well. When it comes to hand-building, players who are relying on one specific card (and are lucky enough to win it) can turn the tide of the game in an instant. Originale is also very close to Enchère Avancée in terms of security, where a player can easily lose a game if they end up receiving the Joker.

All three games are high as they are decided by the player’s starting hands, which also heavily affects the next heuristic.

## Fairness
The fairness of all three versions is 0, which makes sense. All versions of Enchère are typically decided by whoever is dealt the best cards, so all other players are at a disadvantage for the rest of the game.

## Spread
Spread is significantly higher in Enchère, indicating that there is more variation between the worst possible choice and the best possible choice in this game. In Enchère Originale, a player does not have to collect too many cards to create a hand worthy of winning and some winning hands can easily substitute certain cards for others (two pairs can use any suit of card). Enchère Avancée is a surprise in the middle as the King of Hearts and the Joker skew the highest and lowest possible points in opposite directions.

## Order
Order is a very diverse heuristic among the three versions. AI players in Enchère Originale struggle heavily against random players while AI players in Enchère Avancée are not affected much.

In Enchère Originale, AI players may have a plan to attain a specific set of cards and benefit from playing other AI players who may not need similar cards and purposefully play low to wait for better ones. When playing other randoms, however, the AI must deal with random players who may end up taking cards that they need without reason, assembling random hands in the process. This would affect the AI’s ability to properly build the hand that they want.

In Enchère Avancée, random players would not have as much of an effect on the AI as in the other games due to the reliance on attaining the King of Hearts and avoiding the Joker. As the game is a lot more structured around these cards, the AI player will succeed more often against random players in achieving those goals. The other cards don’t have nearly as much of an effect, allowing the AI to do just enough to keep their lead.

## Additional Note
Due to a bug that affects how AI players simulate games when deciding moves, the heuristics may not be entirely accurate. This article may later be edited to include more accurate heuristic metrics.