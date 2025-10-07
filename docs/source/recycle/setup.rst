Setup
=====

Each game begins with a Setup_ section, following any Declare_ statements. The Setup_
section includes a CreatePlayers_ action, an optional CreateTeams_ action, and at least one 
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

See TeamCreateAction_ above. If no TeamCreateAction_ is included, every player will default
to be on a Team_ by themselves.

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
  
  (create deck (game iloc STOCK) (deck (RANK (ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN,
                                              EIGHT, NINE, TEN, JACK, QUEEN, KING))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (SPADES, CLUBS))))))

If you need to have different decks with different backs, for example a prize deck and player cards
which are separate and should not be mixed, you can add another String before the CardCollection.

.. code-block:: racket
  :linenos:
  
  (create deck PRIZE (game iloc STOCK) (deck (COLOR (RED, BLUE, GREEN))))

