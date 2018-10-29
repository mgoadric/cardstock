PIPMCPlayer
===========

Perfect Information Pure Monte Carlo Players are the current default AI players
for CardStock.

For each potential move in MakeAction_, the player simulates a set number
(defined in the NUMTESTS static variable) of random games. A unique subgame data structure
and subgame iterator are created for each test. The subgame iterator then constructs
all the possible GameActionCollection moves with the BuildOptions method, the
current move actions are all executed, and then the choice is popped from the subgame iterator.

All players in the subgame are assigned to make choices randomly, and then the 
game is played out to completion. Each player is assigned a score based on 
the inverse of their rank in the player list, where 1st place is the winning player.
These ranks are accumulated and averaged across all tests, and the index of the move
where the current player earned the highest rank is selected and returned.