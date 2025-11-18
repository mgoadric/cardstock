Action
======

Actions are the way that RECYCLE allows either the players or the game to update
the data structures and rearrange the cards in the game.

CreateTeamAction
----------------

Teams can be created at any time during the game, and can be created in the initialization
section of the game. If there is no team declaration, the default will be for every 
player to be on their own team. The following code will do the same, make four teams, 
one for each player, in a four-person game. Players are indexed starting at 1.

.. code-block:: racket
  :linenos:
  
  (create teams (1) (2) (3) (4))  


To add more than one player to a team, use a comma-separated list with each
team member. This code will create two teams in a four-person game, where team
members are seated opposite each other.

.. code-block:: racket
  :linenos:
  
  (create teams (1, 3) (2, 4))


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


CardSwapAction
--------------

Card_ objects can also be swapped from location to location. 
The first Card_ must not refer to a memory location, and the second card
cannot be a memory or a virtual location. Whole Card_ locations can be swapped,
for when players trade their hands, or swap with a pool of cards in the middle.

.. code-block:: racket

  (swap [Card] [Card])
  (swap [CardCollection] [CardCollection])

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

IntegerStorage_ locations can be changed in three ways. We can set the storage
to be a particular Integer_, increment the current value by an Integer_, or 
decrement the current value by an Integer_.

.. code-block:: racket

  (set [IntegerStorage] [Integer])
  (inc [IntegerStorage] [Integer])
  (dec [IntegerStorage] [Integer])

StrAction
---------

StringStorage_ locations can be changed in one way. We can set the storage
to be a particular String_.

.. code-block:: racket

  (set [StringStorage] [String])

PointsAction
------------

PointMap_ locations can be created in one way. We can set the storage
to be a particular PointMap_.

.. code-block:: racket

  (set [PointMapStorage] [PointMap])


PlayerNextAction
----------

The order in the current cycle can be altered in two ways. The first is to change
the player that is queued to go next. This can be the current player, which will give the 
player another turn, the previous player to reverse the play direction, or the owner
of a particular Card_, such as the winning card of a trick.

.. code-block:: racket

  (cycle next (owner [Card]))
  (cycle next (current player))
  (cycle next (previous player))
  (cycle next (1 player))

PlayerNowAction
---------------

Second, the current player in the cycle can be altered immediately with the following 
similar actions.

.. code-block:: racket

  (cycle current (owner [Card]))
  (cycle current (next player))
  (cycle current (previous player))
  (cycle current (0 player))

PassAction
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

