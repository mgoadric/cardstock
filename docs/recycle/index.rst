*******
RECYCLE
*******

RECYCLE is a game description language that allows for an 
algorithmic representation of common  core  mechanisms  
and  elements  of  card games. RECYCLE
stands  for  REcursive  CYclic
Card game LanguagE, referring to the primary
feature of the language:  the recursion of game
stages  containing  cycles  of  player  turns.   The
language resembles the LISP programming language, often having a large number of nested
instructions that control the flow of the games.

The process of writing game rules in a natural language can be fraught with ambiguities,
often necessitating clarifications after publication.
Encoding a game in RECYCLE can be useful for illuminating the underlying formal structure of a
game design, providing insight into avenues for
targeted or large-scale refinement, and resolving
potential ambiguities.

In RECYCLE, function names are all lowercase, data types are capitalized, and Strings are
all caps.

Base Types
==========

There are four main base elements in RECYCLE, String_, Integer_, Card_, and Boolean_.

String
------

Strings are used for text within RECYCLE games. They are composed of all capital letters.
Strings are the name portion of a CardCollection_, and the key/value pairs of a Card_. 

.. code-block:: racket

   STOCK HAND PILE TRICK SCORE GREEN SUIT HEARTS

The cardatt function also will return a String. It is used to look up the value stored 
a Card_ for a given key. If the key is not found or the card does not exist, this
will return the empty String "".

.. code-block:: racket

   (cardatt [String] [Card])

Integer
-------

Integer literals are contiguous sequences of digits from 0 to 9. Currently only
positive integers are supported with literals, but negative integers can be acheived
through various actions.

.. code-block:: racket

   0 23 999

Standard Integer operators can be applied to Integers to calculate new 
Integers, with addition, subtraction, multiplication, integer division (//) and 
modular division (mod).

.. code-block:: racket

   (+ [Integer] [Integer])
   (- [Integer] [Integer])
   (* [Integer] [Integer])
   (// [Integer] [Integer])
   (mod [Integer] [Integer])

Three functions will return Integers. First, a Card_ can be scored using the values 
mapped through a PointMap_.

.. code-block:: racket

   (score [Card] using [PointMap])

Similarly, each Card_ in a CardCollection_ can be individually scored with a 
PointMap_ and then these scores are summed.

.. code-block:: racket

   (sum [CardCollection] using [PointMap])

The size of a CardCollection_ can be calculated and returned as an Integer.

.. code-block:: racket

   (size [CardCollection])

Integers are stored as part of the game, belonging either to 
the Game_, a Player_, or a Team_. These IntegerStorage_ locations are
named with a String_.

.. code-block:: racket

   ([Game | Player | Team] sto [String])


Card
----

A card is a set of maps from a String_ key to a String_ value, such as RANK => KING, COLOR => BLUE, and 
VALUE => FIVE.
    
A card can never be directly described, but is created through the CreateDeck_ setup and referenced
through locations in a CardCollection_.

.. code-block:: racket

   (top [CardCollection])
   (bottom [CardCollection])
   ([Integer] [CardCollection])

Besides using references to individual specific cards in the CardCollection_, two
functions can find either the minimum or maximum card in a collection when
given a PointMap_ from the card dictionaries to an integer. If there is a tie,
the max or min is decided randomly among all tied cards.

.. code-block:: racket

   (max [CardCollection] using [PointMap])
   (min [CardCollection] using [PointMap])

Finally, a virtual card (for example from a minimum or union operation) can be 
converted into an actual card, so that any move operation moves the card in the 
CardCollection_ to which it belongs.

.. code-block:: racket

   (actual [Card])

Boolean
-------

Booleans in RECYCLE comprise the standard True and False, derived mainly from 
comparisons between other data types, or conjunctions and disjunctions of other
Booleans. They are only evaluated, never explicitly stated as literal True or False.

.. code-block:: racket

	(and [Boolean] [Boolean]+)
	(or [Boolean] [Boolean]+)
	(not [Boolean])

	(> [Integer] [Integer])
	(< [Integer] [Integer])
	(>= [Integer] [Integer])
	(<= [Integer] [Integer])
	(== [Integer] [Integer])
	(!= [Integer] [Integer])

	(== [Card] [Card])
	(!= [Card] [Card])

	(== [String] [String])
	(!= [String] [String])

	(== [Player] [Player])
	(!= [Player] [Player])

	(== [Team] [Team])
	(!= [Team] [Team])

Owners
======

There are three main Owners of data in Recycle: the Game_, each Player_, and each Team_.
The Player_ and Team_ types are more specific types of Owners_, allowing
different functionality.

Game
----

The Game holds storage for both Integer_ or CardCollection_ data. These are referenced
by a String_ name. For example an Integer_ storage for the number of total chips in the
game could be

.. code-block:: racket
    
  (game sto CHIPS)

And a CardCollection_ for the stock of face-down cards would be 

.. code-block:: racket
    
  (game iloc STOCK)

Player
------

As above, a Player tracks storage for both Integer_ or CardCollection_ data. These are referenced
by a String_ name. To reference an individual Player, we can directly refer to the 
turn order of a Player.

.. code-block:: racket
    
  ([Integer] player)

Also, based on the current turn within a stage, we can referentially talk to the current,
previous, and next player. Turn order is determined clock-wise, and the 
previous player will always use this turn order. The next player also uses this turn order
by default, but could be altered within this stage by a NextAction_ queueing up a different
player to go next.

.. code-block:: racket
    
  (current player)
  (previous player)
  (next player)

A Player can also be found by determining the owner of a Card_.

.. code-block:: racket
    
  (owner [Card])

Team
----

As above, a Player tracks storage for both Integer_ or CardCollection_ data. These are referenced
by a String_ name. To reference an individual Team, we can directly refer to the 
turn order of a Team.

.. code-block:: racket

  ([Integer] team)

Also, based on the current turn within a stage, we can referentially talk to the current,
previous, and next team. Turn order is determined clock-wise, and the 
previous team will always use this turn order. The next team also uses this turn order
by default, but could be altered within this stage by a NextAction_ queueing up a different
team to go next.

.. code-block:: racket
    
  (current team)
  (previous team)
  (next team)

Finally, a Team can be found by asking a Player_ what team they are on. A Player_ can 
only be on one Team at a time.

.. code-block:: racket
    
  (team [Player])

Collections
===========

Many of the base data types can be grouped into Collections_. Collections provide a way for
Aggregation_ to iterate through for actions to be taken or 
booleans to be processed with each Collection element.

StringCollection
----------------

A comma-separated list of String_ primitives is a StringCollection_.

.. code-block:: racket

  (YELLOW, GREEN, BLUE, RED, WHITE)

IntegerCollection
-----------------

Currently, the only way to write an IntegerCollection is as a range of 
Integer_ data, starting at a minimum value, and increasing by one up to but
not including the maximum value.

.. code-block:: racket

  (range [Integer] .. [Integer])

CardCollection
--------------

A CardCollection is an ordered list of Card_ objects, 
found on the Game_, Player_, and Team_ objects. These CardCollections can be directly
accessed using their Owner_, the visibility modifier, and the String_ name for that 
CardCollection.

.. code-block:: racket

  ([Game | Player | Team] (vloc | iloc | hloc | mem) [String])

Visibility modifiers can be one of 

* vloc: visible to everyone
* iloc: visible to owner, invisible to others
* hloc: invisible to everyone, including owner
* mem: copies of cards in memory, visible to all

The filter function can be used to create a CardCollection subset from another 
CardCollection. A Boolean_ statement will evaluate as true if an element of the original
CardCollection, denoted by a Variable_, will be included in the filter.

.. code-block:: racket

  (filter [CardCollection] [Variable] [Boolean])

A CardCollection can be created through the union of other CardCollections, for example,
we can create one CardCollection that will hold all the cards played by players to their
individual TRICK CardCollections so that we can determine the highest played card.

.. code-block:: racket

  (union [CardCollection]*)

Finally, we can access individual elements of a CardCollectionCollection_ to obtain
a CardCollection, following the top, bottom, or index methodology.

.. code-block:: racket

  (top [CardCollectionCollection])
  (bottom [CardCollectionCollection])
  ([Integer] [CardCollectionCollection])

CardCollectionCollection
------------------------

A CardCollectionCollection can be created through the tuples function. This will 
return subsets of the given CardCollection_, where the Card_ elements are found to be 
equal according to a PointMap_. Only those subsets of size equal to the given 
Integer_ will be returned.

.. code-block:: racket

  (tuples [Integer] [CardCollection] 'using' [PointMap])

PlayerCollection
----------------

The current players of the game can be referenced as a PlayerCollection. For all 
players, simply use the word "player".

Within a stage, players not equal to the current player can be referenced with

.. code-block:: racket

  (other player)

Alternately, players can be added to a collection based on Boolean_ attributes assessed
on each Variable_ from a PlayerCollection filter.

.. code-block:: racket

  (filter [PlayerCollection] [Variable] [Boolean])

TeamCollection
--------------

The current teams of the game can be referenced as a TeamCollection. For all 
teams, simply use the word "team".

Within a stage, teams not equal to the current team can be referenced with

.. code-block:: racket

  (other team)

Alternately, teams can be added to a collection based on Boolean_ attributes assessed
on each Variable_ from a TeamCollection filter.

Cycle of teams, Denoted with the word “team”

.. code-block:: racket

  (filter [TeamCollection] [Variable] [Boolean])

PointMap
========

A Card_ is a map between String_ and String_ types, therefore we need another 
data structure to capture Integer_ values of cards for scoring or ranking. A PointMap_ 
is a map between two String_ pieces and an Integer_. The first String_ is the Card_ key
and the second is the Card_ value. When applied to a Card_, 
the points will be a sum of all of the key-value pairs that are found in this Card_.
PointMaps are stored in a Variable_.

.. code-block:: racket

   (put points [Variable] (([String] ([String])) [Int])

Aggregation
===========

One of the powerful things that Collections_ allow is iteration and aggregation. Two 
keywords, "all", and "any", can be used with collection with varying results. Each element
of the Collection_ will be assigned to a Variable_ that can be used in the final
portion.

All
---

When the final portion of the all aggregation is a Boolean_, the all will also be 
a Boolean, constructing an AND over the individual elements.    

.. code-block:: racket

  (all [Collection] [Variable] [Boolean])
  
For example, the following is a Boolean_ that will be True if all players have a Hand size
of zero.

.. code-block:: racket
  :linenos:
  
  (all player 'P 
      (== (size ('P iloc HAND)) 0))

When the final element is a MultiAction_, the all will become a sequence over the actions, 
in order of the items in the collection.

.. code-block:: racket

  (all [Collection] [Variable] [MultiAction])
    
We can see this in the following code to move each player's top Trick card to the Discard
pile.

.. code-block:: racket
  :linenos:
   
  (all player 'P 
      (move (top ('P vloc TRICK)) 
            (top (game vloc DISCARD))))    
    
When the final element is a CardCollection, the all will become a CardCollectionCollection_.

.. code-block:: racket

  (all [Collection] [Variable] [CardCollection])
    
This can be used to merge each player's individual CardCollection_ elements, such as 

.. code-block:: racket
  :linenos:
   
  (union (all player 'P ('P vloc TRICK)))

When the final element is an Integer_, the all will become a sum of those Integer_ 
elements. 

.. code-block:: racket

  (all [Collection] [Variable] [Integer])

This is particularly useful for Integer_ storage locations which 
are part of an Owner_.
    
TODO FIND EXAMPLE!    


Any
---

When the final portion of the any aggregation is a Boolean_, the any will also be 
a Boolean, constructing an ON over the individual elements.    

.. code-block:: racket

  (any [Collection] [Variable] [Boolean])
    
For example, the following is a Boolean_ that will be True if any player has 
Points greater than 10.

.. code-block:: racket
  :linenos:
   
  (any player 'P
      (> ('P sto POINTS) 10))

When the final element is a MultiAction_, the any will become a choice over the actions.

.. code-block:: racket

  (any [Collection] [Variable] [MultiAction])
  
For example, the following is how a player can choose to play any Card_ in their Hand
to the current Trick of a trick-taking game.  
  
.. code-block:: racket
  :linenos:
   
  (any ((current player) iloc HAND) 'AC
      (move 'AC 
            (top ((current player) vloc TRICK))))


Variable
========

Variables, like String_ constants, must be all caps. They also must begin with a ' character.

.. code-block:: racket

  'C 'AC 'COLOR 'P

Variables can be implicitly assigned from a Collection_ inside the filter 
function or Aggregation_ functions.

There are two other ways to create Variables, with declare_ or let_.

declare
-------

The declare function must be at the beginning of a RECYCLE program. It is useful for
creating program-wide constants or data that cannot be altered through the game. The 
data can be anything explicitly defined, commonly String_ and Integer_, or a
StringCollection_ type.

.. code-block:: racket

  (declare [Type] [Variable])


let
---

The let function is a local declaration of a Variable, followed by a segment of code where
this Variable will be valid.

.. code-block:: racket

  (let [Type] [Variable] [Expression])


Action
======

Actions are the way that RECYCLE allows either the players or the game to update
the data structures and rearrange the cards in the game.

TeamCreateAction
----------------

Teams can be created at any time during the game, and must be created in the initialization
section of the game. The following code will make four teams, one for each player, in a 
four-person game. Players are indexed starting at 0.

.. code-block:: racket
  :linenos:
  
  (create teams (0) (1) (2) (3))  

To add more than one player to a team, write a comma-separated list with each
team member. This code will create two teams in a four-person game, where team
members are seated opposite each other.

.. code-block:: racket
  :linenos:
  
  (create teams (0, 2) (1, 3))


.. InitializeAction
   ----------------

ShuffleAction
-------------

A CardCollection_ can be shuffled at any time into a new random permutation of the 
Card_ objects.

.. code-block:: racket

  (shuffle [CardCollection])

CardMoveAction
--------------

Once created, Card_ objects can be moved from location to location with the move
action. The first Card_ must not refer to a memory location, and the second card
cannot be a memory or a virtual location.

.. code-block:: racket

  (move [Card] [Card])

CardRememberAction
------------------

Card_ objects can also be copied into memory, for example to remember which 
card was led, or what suit is trump. The second Card_ must refer to a memory
location.

.. code-block:: racket

  (remember [Card] [Card])

CardForgetAction
----------------

Since memory locations hold Card_ objects that are copies, they should not be 
moved but instead forgotten when they are no longer needed. 

.. code-block:: racket

  (forget [Card])

IntAction
---------

IntegerStorage locations can be changed in three ways. We can set the storage
to be a particular Integer_, increment the current value by an Integer_, or 
decrement the current value by an Integer_.

.. code-block:: racket

  (set [IntegerStorage] [Integer])
  (inc [IntegerStorage] [Integer])
  (dec [IntegerStorage] [Integer])


NextAction
----------

The order in the current cycle can be altered in two ways. The first is to change
the player that is queued to go next. This can be the current player, which will give the 
player another turn, the previous player to reverse the play direction, or the owner
of a particular Card_, such as the winning card of a trick.

.. code-block:: racket

  (cycle next (owner [Card]))
  (cycle next current)
  (cycle next previous)

SetPlayerAction
---------------

Second, the current player in the cycle can be altered immediately with the following 
similar actions.

.. code-block:: racket

  (cycle current (owner [Card]))
  (cycle current next)
  (cycle current previous)

TurnAction
----------

A player sometimes needs the opportunity to pass. This Action is a way to have
the player taken an action that makes no change to the game state.

.. code-block:: racket

  (turn pass)
  
RepeatAction
------------

Actions can be repeated with the repeat action. The action will be repeated for an
Integer_ number of times. 

.. code-block:: racket

  (repeat [Integer] [Action])

One additional way to repeat an action is the "repeat all" for a MoveAction_. This will 
move cards one by one until there are no more Card_ objects in the first location.

.. code-block:: racket

  (repeat all [MoveAction])

GameFlow
========

ConditionalAction
-----------------

Action_ blocks can also be prefaced with a boolean condition
to make the execution of the action dependent on the current state of the game.

.. code-block:: racket
  :linenos:
  
  ([Boolean] [Action])

Do
--

Action_ blocks can be combined to form a sequence of actions. These can also
be ConditionalAction_ objects. The aggregate of these actions is called a Do_, and
can also have nested inside more Do_ blocks. These actions will be executed 
one after another in order from top to bottom.

.. code-block:: racket

  (do ([ConditionalAction | Action | Do]*))
  
Choice
------

A Choice_ block is a way to set up options for the player in the game. Instead of
operating sequentially, the Action_ objects found to be valid based on their
conditions will be grouped and presented to the player, who then must 
make a choice among them for the game to proceed. A Do_ can be within a Choice_, 
giving the player an option of choosing a set of sequential actions.

.. code-block:: racket

  (choice ([ConditionalAction | Action | Do]*))
  

Stage
-----

A Stage_ block activates either a Player_ or Team_ cycle. The components of a
Stage will be evaluated, with each member of the cycle becoming the "current" member,
until the Boolean_ end condition is met. The order of members in the cycle can be altered
with the NextAction_ and SetPlayerAction_ described above.

.. code-block:: racket

  (stage player [Boolean] [Do | Choice | Stage]*)
  (stage team [Boolean] [Do | Choice | Stage]*)

Setup
=====

Each game begins with a Setup_ section, following any Declare_ statements. The Setup_
section includes a CreatePlayers_ action, a CreateTeams_ action, and at least one 
CreateDeck_ action. Multiple decks can be added with either multiple CreateDeck_ actions
or through a RepeatAction_ containing a CreateDeck_ action.

CreatePlayers
-------------

In the Setup_, each player is created identical, so we only need to know the number of 
players in the game to create each player. A Player_ is placed into the player cycle.

.. code-block:: racket

  (create players [Integer])
  
CreateTeams
-----------

See TeamCreateAction_ above.

CreateDeck
----------

Card_ objects are created and placed in a CardCollection_ with the CreateDeck_ function.
A single key can be listed for a Card_, followed by all values of that attribute,
and a Card_ will be made with one of each value. The following code will make three Card_
objects.

.. code-block:: racket
  :linenos:
  
  (create deck (game iloc STOCK) (deck (COLOR (RED, BLUE, GREEN))))

More complicated decks can be made by adding more keys. If multiple keys are
listed, each with their own values, then a Card_ will be created for each permutation
of these values. Here, will will create six Card_ objects, RED-SMALL, RED-LARGE, BLUE-SMALL,
BLUE-LARGE, GREEN-SMALL, and GREEN-LARGE.

.. code-block:: racket
  :linenos:
  
  (create deck (game iloc STOCK) (deck (COLOR (RED, BLUE, GREEN))
  									   (SIZE (SMALL, LARGE))))

Keys can also be nested inside as values inside other key lists. The 
following code is used to make a full 52 Card_ deck, with RANK, COLOR, and SUIT keys.

.. code-block:: racket
  :linenos:
  
  (create deck (game iloc STOCK) (deck (RANK (ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, 
                                              NINE, TEN, JACK, QUEEN, KING))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (SPADES, CLUBS))))))

Scoring
=======

The Scoring section of the game details how to determine the ranking of players once
the game is complete. The scores can be based on any Integer_ in the game, commonly
an IntegerStorage, but possibly the size of a CardCollection or any other
Integer that can be calculated. The (current player) can be used to denote that this
scoring will be applied to each player in the game. 

You can either sort these scores from highest to lowest so that the max is 
regarded as the best score, or lowest to highest so that the min is the best score.

.. code-block:: racket

  (scoring max [Integer])
  (scoring min [Integer])


Example
=======

The following is an example game written in RECYCLE called Agram.
Agram is a simple Nigerian trick-taking card
game for 2 to 6 players.  Players are dealt six
cards from a reduced French deck, and play six
tricks. To win a trick, players must follow the
suit of the lead player with a higher card; there
is no trump suit.  The object of the game is to
win the last trick.

.. code-block:: racket
    :linenos:

    ;; Agram
    ;;
    ;; https://www.pagat.com/last/agram.html

    (game
     (declare 4 'NUMP)
     (setup 
      (create players 'NUMP)
      (create teams (0) (1) (2) (3))  
  
      ;; Create the deck source 
      (create deck (game iloc STOCK) (deck (RANK (THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN))
                                           (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                  (BLACK (SUIT (SPADES, CLUBS))))))
      (create deck (game iloc STOCK) (deck (RANK (ACE)) 
                                           (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                  (BLACK (SUIT (CLUBS)))))))

 
     ;; Shuffle and deal each player 6 cards
     (do 
         (
          (shuffle (game iloc STOCK))
          (all player 'P 
               (repeat 6 
                       (move (top (game iloc STOCK))
                             (top ('P iloc HAND)))))))
   
     ;; players play a round 6 times         
     (stage player
            (end 
             (all player 'P 
                  (== (size ('P iloc HAND)) 0)))

            ;; players play a hand once     
            (stage player
                   (end 
                    (all player 'P 
                         (> (size ('P vloc TRICK)) 0)))
               
                   (choice 
                    (
                 
                     ;; if following player cannot follow SUIT
                     ;;   play any card, and end your turn   
                     ((and (== (size (game mem LEAD)) 1)
                           (== (size (filter ((current player) iloc HAND) 'C 
                                             (== (cardatt SUIT 'C)
                                                 (cardatt SUIT (top (game mem LEAD)))))) 0))
                      (any ((current player) iloc HAND) 'AC
                           (move 'AC 
                                 (top ((current player) vloc TRICK)))))
                 
                     ;; if following player and can follow SUIT
                     ;;   play any card that follows SUIT, and end your turn
                     (any (filter ((current player) iloc HAND) 'T 
                                  (== (cardatt SUIT 'T)
                                      (cardatt SUIT (top (game mem LEAD)))))
                          'C
                                    ((== (size (game mem LEAD)) 1)
                                     (move 'C 
                                           (top ((current player) vloc TRICK)))))
                
                     ;; if first player, play any card, remember it in the lead spot, and end your turn
                     ((== (size (game mem LEAD)) 0)                      
                      (any ((current player) iloc HAND) 'AC
                           (do 
                               (
                                (move 'AC
                                      (top ((current player) vloc TRICK)))
                                (remember (top ((current player) vloc TRICK)) 
                                          (top (game mem LEAD))))))))))
        
            ;; after players play hand, computer wraps up trick
            (do 
                (
                 ;; solidfy card precedence
                 (put points 'PRECEDENCE 
                      (
                       ((SUIT (cardatt SUIT (top (game mem LEAD)))) 100)
                       ((RANK (ACE)) 14)
                       ((RANK (TEN)) 10)
                       ((RANK (NINE)) 9)
                       ((RANK (EIGHT)) 8)
                       ((RANK (SEVEN)) 7)
                       ((RANK (SIX)) 6)
                       ((RANK (FIVE)) 5)
                       ((RANK (FOUR)) 4)
                       ((RANK (THREE)) 3)))
             
                 ;; determine who won the hand, set them first next time
                 (forget (top (game mem LEAD)))
             
                 (cycle next (owner (max (union (all player 'P ('P vloc TRICK))) using 'PRECEDENCE)))
             
                 (all player 'P 
                      (move (top ('P vloc TRICK)) 
                            (top (game vloc DISCARD))))
             
                 ;; if that was the last round, give the winner a point
                 ((all player 'P
                       (== (size ('P iloc HAND)) 0))
                  (inc ((next player) sto SCORE) 1)))))
 
     (scoring max ((current player) sto SCORE)))
