Collection
==========

Many of the base data types can be grouped into Collections_. Collections provide a way for
Aggregation_ to iterate through for actions to be taken or 
booleans to be processed with each Collection element.

StringCollection
----------------

A comma-separated list of String_ primitives is a StringCollection_.

.. code-block:: racket

  (YELLOW, GREEN, BLUE, RED, WHITE)

IntegerCollection
-----------------

Currently, the only way to write an IntegerCollection is as a range of 
Integer_ data, starting at a minimum value, and increasing by one up to but
not including the maximum value.

.. code-block:: racket

  (range [Integer] .. [Integer])

CardCollection
--------------

A CardCollection is an ordered list of Card_ objects, 
found on the Game_, Player_, and Team_ objects. These CardCollections can be directly
accessed using their Owner_, the visibility modifier, and the String_ name for that 
CardCollection.

.. code-block:: racket

  ([Game | Player | Team] (vloc | iloc | hloc | oloc | mem) [String])

Visibility modifiers can be one of 

* vloc: visible to everyone
* iloc: visible to owner, invisible to others
* hloc: invisible to everyone, including owner
* oloc: invisible to owner, visible to others
* mem: copies of cards in memory, visible to all

CardCollections can be indexed with Integers, allowing for ordered CardCollections
within a single name.

.. code-block:: racket

  ([Game | Player | Team] (vloc | iloc | hloc | oloc | mem) [String] [Integer])

The filter function can be used to create a CardCollection subset from another 
CardCollection. A Boolean_ statement will evaluate as true if an element of the original
CardCollection, denoted by a Variable_, will be included in the filter.

.. code-block:: racket

  (filter [CardCollection] [Variable] [Boolean])

A CardCollection can be created through the union of other CardCollections, for example,
we can create one CardCollection that will hold all the cards played by players to their
individual TRICK CardCollections so that we can determine the highest played card.

.. code-block:: racket

  (union [CardCollection]*)

Other set operations are also possible on CardCollection_. The intersection of two 
CardCollections will be the cards they have in common, while the disjunction of two
CardCollections will be the cards they do not have in common. Since cards can only be in
one location at a time, these are only useful for virtual collections.

.. code-block:: racket

  (intersect [CardCollection]*)
  (disjunction [CardCollection]*)

Sequences of a particular length from a CardCollection are subsets that either include the top or bottom element.

.. code-block:: racket

  (top [Integer] [CardCollection])
  (bottom [Integer] [CardCollection])

A run is the longest sequence from a CardCollection that is at least as long the Integer given.
The cards are ordered using a PointMap_, and the cards must be sequential in value (3, 4, 5) to
be counted as a run.

.. code-block:: racket

  (top [Integer] [CardCollection] using [PointMap])
  (bottom [Integer] [CardCollection] using [PointMap])

Finally, we can access individual elements of a CardCollectionCollection_ to obtain
a CardCollection, following the top, bottom, or index methodology.

.. code-block:: racket

  (top [CardCollectionCollection])
  (bottom [CardCollectionCollection])
  ([Integer] [CardCollectionCollection])

CardCollectionCollection
------------------------

A CardCollectionCollection can be created through the many functions. 

Runs, where cards are sequenced one after another, can be found in two ways. With the all
argument, every possible sequence will be returned in the collection. Using the largest
argument will limit the sequences to eliminate overlap. The runs found must be as large
as the Integer provided.

.. code-block:: racket

  (runs all [Integer] [CardCollection] using [PointMap])
  (runs largest [Integer] [CardCollection] using [PointMap])

The subsets function will return all possible subsets that can be made from the cards in 
a CardCollection.

.. code-block:: racket

  (subsets [CardCollection])

The partition function will divide up the Cards in a CardCollection
based on a particular String attribute of the cards. For example, this could be used to split 
the cards by SUIT, or find all cards with a particular RANK for making sets.

.. code-block:: racket

  (partition [String] [CardCollection])

All CardCollections with the same name MELD-0, MELD-1, etc, can be collected in with the indexed
function, by providing the base named CardCollection.

.. code-block:: racket

  (indexed [CardCollection])

The tuples function will 
return subsets of the given CardCollection_, where the Card_ elements are found to be 
equal according to a PointMap_. Only those subsets of size equal to the given 
Integer_ will be returned.

.. code-block:: racket

  (tuples [Integer] [CardCollection] using [PointMap])

PlayerCollection
----------------

The current players of the game can be referenced as a PlayerCollection. For all 
players, simply use the word "player".

Within a stage, players not equal to the current player can be referenced with

.. code-block:: racket

  (other player)

Alternately, players can be added to a collection based on Boolean_ attributes assessed
on each Variable_ from a PlayerCollection filter.

.. code-block:: racket

  (filter [PlayerCollection] [Variable] [Boolean])

TeamCollection
--------------

The current teams of the game can be referenced as a TeamCollection. For all 
teams, simply use the word "team".

Within a stage, teams not equal to the current team can be referenced with

.. code-block:: racket

  (other team)

Alternately, teams can be added to a collection based on Boolean_ attributes assessed
on each Variable_ from a TeamCollection filter.

Cycle of teams, Denoted with the word “team”

.. code-block:: racket

  (filter [TeamCollection] [Variable] [Boolean])

