Owner
=====

There are three main Owners of data in Recycle: the Game_, each Player_, and each Team_.
The Player_ and Team_ types are more specific types of Owners_, allowing
different functionality.

Game
----

The Game holds storage for Integer_, String_, PointMap_, or CardCollection_ data. These are referenced
by a String_ name. For example an Integer_ storage for the number of total chips in the
game could be

.. code-block:: racket
    
  (game sto CHIPS)

And a CardCollection_ for the stock of face-down cards would be 

.. code-block:: racket
    
  (game iloc STOCK)

Player
------

As above, a Player tracks storage for Integer_, String_, PointMap_, or CardCollection_ data. These are referenced
by a String_ name. To reference an individual Player, we can directly refer to the initial
index of a Player, starting with 1.

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

As above, a Player tracks storage for Integer_, String_, PointMap_, or CardCollection_ data. These are referenced
by a String_ name. To reference an individual Team, we can directly refer to the 
initial index of a Team, starting with 1.

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

