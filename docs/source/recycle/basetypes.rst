Base Types
==========

There are four main base elements in RECYCLE, String_, Integer_, Card_, and Boolean_.

String
------

Strings are used for text within RECYCLE games. String literals are composed of all capital letters.

.. code-block:: racket

   STOCK HAND PILE TRICK SCORE GREEN SUIT HEARTS

Strings are used in many places across Recycle. For example, they are the name portion of a CardCollection_, 
and the key/value pairs of a Card_. 

The cardatt function will return a String. It is used to look up the value stored 
a Card_ for a given key. If the key is not found or the card does not exist, this
will return the empty String "".

.. code-block:: racket

   (cardatt [String] [Card])

StringStorage
_____________

Strings can be stored in a StringStorage_ for the Game_, Player_, or Team_.

.. code-block:: racket

   ([Game | Player | Team] str [String])

Integer
-------

Integer literals are contiguous sequences of digits from 0 to 9. Currently only
positive integers are supported with literals, but negative integers can be acheived
through various actions.

.. code-block:: racket

   0 23 999

Standard Integer operators can be applied to Integers to calculate new 
Integers, with addition, subtraction, multiplication, integer division (//), 
modular division (%), and exponentiation (^).

.. code-block:: racket

   (+ [Integer] [Integer])
   (- [Integer] [Integer])
   (* [Integer] [Integer])
   (// [Integer] [Integer])
   (% [Integer] [Integer])
   (^ [Integer] [Integer])


Two functions can be used to calculate the value from an integer sequence, either
triangular numbers (1, 3, 6, 10, 15, 21, ...) or fibonacci (1, 1, 2, 3, 5, 8, 13, ...).

.. code-block:: racket

    (tri [Integer])
    (fib [Integer])

Five functions will return Integers. 
First, a Card_ can be scored using the values 
mapped through a PointMap_.

.. code-block:: racket

   (score [Card] using [PointMap])

Similarly, each Card_ in a CardCollection_ can be individually scored with a 
PointMap_ and then these scores are summed.

.. code-block:: racket

   (sum [CardCollection] using [PointMap])

One can find either the minimum or maximum card in a collection when
given a PointMap_ from the card dictionaries to an integer, and the score
can be returned. If there is a tie,
the max or min is decided randomly among all tied cards.

.. code-block:: racket

   (scoremax [CardCollection] using [PointMap])
   (scoremin [CardCollection] using [PointMap])

The size of a CardCollection_ can be calculated and returned as an Integer.

.. code-block:: racket

   (size [CardCollection])

Random Integer_ can also be generated with the random function in two ways.
The first generates numbers between 0 and the Integer_ argument, exlcusive, and
the second, with two Integer_ arguments, generates a number between the two 
numbers.

.. code-block:: racket

   (random [Integer])
   (random [Integer] .. [Integer])

Each player and team has an id number (player 0, team 1, etc) that can be used as an _Integer.
The syntax for the id is as follows:

.. code-block:: racket

   (pid (current player))
   (tid (next team))

Integers are also derived from Aggregation_.

IntegerStorage
______________

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

Booleans are also derived from Aggregation_.
