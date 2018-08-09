*******
RECYCLE
*******

Base Types
==========

String
------

All capital letters.  
STOCK HAND PILE TRICK SCORE GREEN SUIT HEARTS

.. parsed-literal::

    (cardatt [String_] [Card_])

Boolean
-------

Standard True and False idea. Only evaluated, never stated.

.. parsed-literal::

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


Integer
-------

Literal integers from digits
[0-9]+

[Table | Player | Team] sto [String] 

(+ [Integer] [Integer])
(* [Integer] [Integer])
(- [Integer] [Integer])
(// [Integer] [Integer])
(mod [Integer] [Integer])

(score [Card] using [PointMap])

(sum [CardCollection] using [PointMap])
(size [CardCollection])

Card
----

Set of maps between Strings => Strings

    RANK => KING
    COLOR => BLUE
    VALUE => FIVE
    
Can be hierarchical

(top [CardCollection])
(bottom [CardCollection])
([Integer] [CardCollection])

(max [CardCollection] using [PointMap])
(min [CardCollection] using [PointMap])

(actual [Card])

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

PointMap
--------

Map between String and Integer

String => Integer

Used for looking at a card and assigning point value based on attributes. See as part of a Using

Update and create with 

(put points [Variable] (([String] ([String])) [Int])



COLLECTIONS
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

InitializeAction
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

Scoring
=======
