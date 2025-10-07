GameFlow
========

ConditionalAction
-----------------

Action_ blocks can also be prefaced with a boolean condition
to make the execution of the action dependent on the current state of the game.

.. code-block:: racket
  :linenos:
  
  ([Boolean] [Action])

MultiAction
-----------

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

