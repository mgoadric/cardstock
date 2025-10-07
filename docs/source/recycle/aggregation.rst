Aggregation
===========

One of the powerful things that Collections_ allow is iteration and aggregation. Two 
keywords, "all", and "any", can be used with collection with varying results. Each element
of the Collection_ will be assigned to a Variable_ that can be used in the final
portion.

All
---

When the final portion of the all aggregation is a Boolean_, the all will also be 
a Boolean, constructing an AND over the individual elements.    

.. code-block:: racket

  (all [Collection] [Variable] [Boolean])
  
For example, the following is a Boolean_ that will be True if all players have a Hand size
of zero.

.. code-block:: racket
  :linenos:
  
  (all player 'P 
      (== (size ('P iloc HAND)) 0))

When the final element is a MultiAction_, the all will become a sequence over the actions, 
in order of the items in the collection.

.. code-block:: racket

  (all [Collection] [Variable] [MultiAction])
    
We can see this in the following code to move each player's top Trick card to the Discard
pile.

.. code-block:: racket
  :linenos:
   
  (all player 'P 
      (move (top ('P vloc TRICK)) 
            (top (game vloc DISCARD))))    
    
When the final element is a CardCollection, the all will become a CardCollectionCollection_.

.. code-block:: racket

  (all [Collection] [Variable] [CardCollection])
    
This can be used to merge each player's individual CardCollection_ elements, such as 

.. code-block:: racket
  :linenos:
   
  (union (all player 'P ('P vloc TRICK)))

When the final element is an Integer_, the all will become a sum of those Integer_ 
elements. 

.. code-block:: racket

  (all [Collection] [Variable] [Integer])

This is particularly useful for Integer_ storage locations which 
are part of an Owner_.
    
TODO FIND EXAMPLE!    


Any
---

When the final portion of the any aggregation is a Boolean_, the any will also be 
a Boolean, constructing an ON over the individual elements.    

.. code-block:: racket

  (any [Collection] [Variable] [Boolean])
    
For example, the following is a Boolean_ that will be True if any player has 
Points greater than 10.

.. code-block:: racket
  :linenos:
   
  (any player 'P
      (> ('P sto POINTS) 10))

When the final element is a MultiAction_, the any will become a choice over the actions.

.. code-block:: racket

  (any [Collection] [Variable] [MultiAction])
  
For example, the following is how a player can choose to play any Card_ in their Hand
to the current Trick of a trick-taking game.  
  
.. code-block:: racket
  :linenos:
   
  (any ((current player) iloc HAND) 'AC
      (move 'AC 
            (top ((current player) vloc TRICK))))


