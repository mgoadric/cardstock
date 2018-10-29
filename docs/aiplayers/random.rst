RandomPlayer
============

Random players are useful in many situations for CardStock. They can be deployed
for initial playtesting to ensure a game is robust to all player choices and
unbiased toward a particular seating arrangement. They can also be employed by
more advanced AIPlayer_ implementations within Monte Carlo simulations.

In RandomPlayer_, the MakeAction method simply returns a uniformly randomly chosen int
within the range of 0 to the number of choices given to the player.