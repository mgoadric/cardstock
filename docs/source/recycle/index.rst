*******
RECYCLE
*******

RECYCLE is a game description language that allows for an 
algorithmic representation of common  core  mechanisms  
and elements of card games. RECYCLE stands for REcursive  CYclic
Card game LanguagE, referring to the primary
feature of the language: the recursion of game
stages containing  cycles of player turns. The
language resembles the LISP programming language, often having a large number of nested
instructions that control the flow of the games.

Card game rules are often looser than board game rules, having more of a folk origin,
and are easily altered with house rules and variations.
Encoding a game in RECYCLE can be useful for illuminating the underlying formal structure of a
game design, providing insight into avenues for
targeted or large-scale refinement, and resolving
potential ambiguities.

In RECYCLE, function names are all lowercase, data types are capitalized, and Strings are
all caps.

.. toctree::
   :maxdepth: 2

   basetypes
   owners
   collections
   pointmaps
   aggregation
   variables
   actions
   gameflow
   setup
   scoring
   example

