AIPlayer
========

.. toctree::
   :maxdepth: 2

   random
   pipmc
   mcts
   ismcts
   
AIPlayer_ is an abstract class to be subclassed for all of the AI. It will 
know the number of players in the game, have a Perspective_ which
privatizes the hidden aspects of the game from this player, and 
a List that tracks the player's estimates of their current
game position.

Perspective
-----------

A Perspective_ is a wrapper around a GameIterator_ and an int which is the current
player's index in the game cycle.  An AIPlayer_ can ask the Perspective_ for their
view of the game through the GetPrivateGame_ method. This will return 
a Tuple of a CardGame_ and GameIterator_, where all the private Card_ information
hidden from this player is shuffled and replaced.

MakeAction
----------

The MakeAction_ method is the critical method that needs to be overridden in any subclass
of AIPlayer. When a choice is found in the game, the number of potential 
moves will be passed in. The AIPlayer_
is expected to return an int which is the index of their chosen move.

If your AIPlayer_ is being used in the Heuristics_ portion of CardStock, then within
MakeAction_, you should also create an array of doubles with the estimated inverse rank of the 
player for each possible move and pass this to RecordHeuristics_ for processing. 

