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


