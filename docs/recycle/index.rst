*******
RECYCLE
*******

Function names are all lowercase, data types are capitalized, and Strings are
all caps.

Base Types
==========

String
------

Strings are used for text within RECYCLE games. They are composed of all capital letters.
Strings are the name portion of a CardCollection_, and the key/value pairs of a Card_. 

.. code-block:: python

   STOCK HAND PILE TRICK SCORE GREEN SUIT HEARTS

The cardatt function also will return a String. It is used to look up the value stored 
a Card_ for a given key. If the key is not found or the card does not exist, this
will return the empty String "".

.. code-block:: python

   (cardatt [String] [Card])

Integer
-------

Integer literals are contiguous sequences of digits from 0 to 9. Currently only
positive integers are supported with literals, but negative integers can be acheived
through various actions.

.. code-block:: python

   0 23 999

Integers are stored as part of the game, belonging either to 
the Game_, a Player_, or a Team_. These Integer storage locations are
named with a String_.

.. code-block:: python

   ([Game | Player | Team] sto [String])

Standard Integer operators can be applied to Integers to calculate new 
Integers, with addition, subtraction, multiplication, integer division (//) and 
modular division (mod).

.. code-block:: python

   (+ [Integer] [Integer])
   (- [Integer] [Integer])
   (* [Integer] [Integer])
   (// [Integer] [Integer])
   (mod [Integer] [Integer])

Three functions will return Integers. First, a Card_ can be scored using the values 
mapped through a PointMap_.

.. code-block:: python

   (score [Card] using [PointMap])

Similarly, each Card_ in a CardCollection_ can be individually scored with a 
PointMap_ and then these scores are summed.

.. code-block:: python

   (sum [CardCollection] using [PointMap])

Finally, the size of a CardCollection_ can be calculated and returned as an Integer.

.. code-block:: python

   (size [CardCollection])

Card
----

A card is a set of maps from a String_ key to a String_ value. A card can never
be directly described, only created through the CreateDeck_ setup or by referencing
locations in a CardCollection_.

    RANK => KING
    COLOR => BLUE
    VALUE => FIVE
    
Can be hierarchically described (does not matter in practice).

(top [CardCollection])
(bottom [CardCollection])
([Integer] [CardCollection])

(max [CardCollection] using [PointMap])
(min [CardCollection] using [PointMap])

(actual [Card])

PointMap
--------

Map between String and Integer

String => Integer

Used for looking at a card and assigning point value based on attributes. See as part of a Using

Update and create with 

(put points [Variable] (([String] ([String])) [Int])

Boolean
-------

Standard True and False idea. Only evaluated, never stated.

.. code-block:: python

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

Game
----

The game storage area, holds a map for 
String sto => Integer
    
String (vloc | iloc | hloc | mem) => CardCollection

Player
------

Each player also has a storage area, holds a map for 
String sto => Integer
    
String (vloc | iloc | hloc | mem) => CardCollection

([Integer] player)
(current player)
(previous player)
(next player)

(owner [Card])

Team
----

Each team also has a storage area, holds a map for 
String sto => Integer
    
String (vloc | iloc | hloc | mem) => CardCollection

([Integer] team)
(current team)
(previous team)
(next team)

(team [Player])


Collections
===========

StringCollection
----------------

Comma separated list of Strings

IntegerCollection
-----------------

(range [Integer] .. [Integer])

CardCollection
--------------

Ordered list of Card objects, found on the Game, Player, Team objects

([Game | Player | Team] (vloc | iloc | hloc | mem) [String])

vloc: visible to everyone
iloc: visible to owner, invisible to others
hloc: invisible to everyone, including owner
mem: copies of cards in memory, visible to all

(filter [CardCollection] [Boolean])

(union [CardCollection]*)

(top [CardCollectionCollection])
(bottom [CardCollectionCollection])
([Integer] [CardCollectionCollection])

CardCollectionCollection
------------------------

(tuples [Integer] [CardCollection] 'using' [PointMap])

PlayerCollection
----------------

Cycle of players, Denoted with the word “player”

(other player)

(filter [PlayerCollection] [Boolean])

TeamCollection
--------------

Cycle of teams, Denoted with the word “team”

(filter [TeamCollection] [Boolean])

Aggregation
===========

All
---

(all collection ‘V … [Boolean])
    Becomes an AND over the individual Booleans created
(all collection ‘V … multiaction)
    Becomes a sequence over the actions, in order of items in collection
(all collection ‘V … [CardCollection])
    Becomes a CardCollectionCollection
(all collection ‘V … [RawStorage])
    Becomes a sum of those storage bins

Any
---

(any collection ‘V … [Boolean])
    Becomes an OR over the individual Booleans created
(any collection ‘V … action)
    Becomes a choice over the actions, propagated up
(any collection ‘V … [CardCollection])
    Becomes a collection of locations??????
(any collection ‘V [Rawstorage])
    Becomes a choice between ints??

Variables
=========

LET
---

let [Type] [Variable] [Expression]

DECLARE
-------

declare [Type] [Variable]

Game Actions
============

TeamCreateAction
----------------

.. InitializeAction
   ----------------

ShuffleAction
-------------

CardMoveAction
--------------

CardRememberAction
------------------

CardForgetAction
----------------

IntAction
---------

NextAction
----------

SetPlayerAction
---------------

TurnAction
----------

Control flow
============


Do
--

Choice
------

Stage
-----

Setup
=====

CreatePlayers
-------------


CreateTeams
-----------

CreateDeck
----------

Scoring
=======

Example
=======

.. code-block:: python


	;; Agram in the GDL
	(game
	   (declare 4 'NUMP)
	   (setup 
		  ;; Set up the players
		  (create players 'NUMP)
		  (create teams (0) (1) (2) (3))
	  
		  ;; Create the deck source
	 
		  (create deck (game iloc STOCK) (deck (RANK (THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN))
											  (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
													 (BLACK (SUIT (SPADES, CLUBS)))
													 )))
		  (create deck (game iloc STOCK) (deck (RANK (ACE)) (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
																   (BLACK (SUIT (CLUBS)))
																   )))
	   )
		  (do (
			 (shuffle (game iloc STOCK))
			 (all player 'P 
				  (repeat 6 (move (top (game iloc STOCK))
								  (top ('P iloc HAND)))))
   
		  ))
		 
		  ;; players play a round 6 times     
		  (stage player
			 (end (all player 'P 
					   (== (size ('P iloc HAND)) 0)))
					
			 ;; players play a hand once
			 (stage player
				(end (all player 'P 
						  (> (size ('P vloc TRICK)) 0)))
			
			   (choice (
					;; if following player cannot follow SUIT
				   ;;   play any card, and end your turn
				 ((and (== (size (game mem LEAD)) 1)
					   (== (size (filter ((current player) iloc HAND) 'C (== (cardatt SUIT 'C)
																			(cardatt SUIT (top (game mem LEAD)))))) 0))
				   (any ((current player) iloc HAND) 'AC
					  (move 'AC 
						  (top ((current player) vloc TRICK)))))

				   ;; if following player and can follow SUIT
				   ;;   play any card that follows SUIT, and end your turn
				 (any (filter ((current player) iloc HAND) 'T (== (cardatt SUIT 'T)
																 (cardatt SUIT (top (game mem LEAD))))) 'C
				   ((== (size (game mem LEAD)) 1)
					   (move 'C (top ((current player) vloc TRICK)))))
					  
				   ;; if first player, play any card, remember it in the lead spot, and end your turn
				 ((== (size (game mem LEAD)) 0)                      
				  (any ((current player) iloc HAND) 'AC
					 (do (
						 (move 'AC
							   (top ((current player) vloc TRICK)))
						 (remember (top ((current player) vloc TRICK)) 
								   (top (game mem LEAD)))
					 ))
				 ))
			  ))
			 )
			  
			 ;; after players play hand, computer wraps up trick
			 (do (
					 ;; solidfy card recedence
					 (put points 'PRECEDENCE (
								   ((SUIT (cardatt SUIT (top (game mem LEAD)))) 100)
								   ((RANK (ACE)) 14)
								   ((RANK (TEN)) 10)
								   ((RANK (NINE)) 9)
								   ((RANK (EIGHT)) 8)
								   ((RANK (SEVEN)) 7)
								   ((RANK (SIX)) 6)
								   ((RANK (FIVE)) 5)
								   ((RANK (FOUR)) 4)
								   ((RANK (THREE)) 3)
								   )
								   )          
					  
					 ;; determine who won the hand, set them first next time
				(forget (top (game mem LEAD)))
				 
				 
		  
				(cycle next (owner (max (union (all player 'P ('P vloc TRICK))) using 'PRECEDENCE)))
				 
				(all player 'P 
					 (move (top ('P vloc TRICK)) 
						   (top (game vloc DISCARD))))
			 
				;; if that was the last round, give the winner a point
				((all player 'P
				   (== (size ('P iloc HAND)) 0))
					 (inc ((next player) sto SCORE) 1))      
			 ))
		  )
	   (scoring max ((current player) sto SCORE))
	)

