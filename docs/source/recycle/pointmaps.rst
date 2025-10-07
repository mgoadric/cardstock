
PointMap
========

A Card_ is a map between String_ and String_ types, therefore we need another 
data structure to capture Integer_ values of cards for scoring or ranking. A PointMap_ 
is a map between two String_ pieces and an Integer_. The first String_ is the Card_ key
and the second is the Card_ value. When applied to a Card_, 
the points will be a sum of all of the key-value pairs that are found in this Card_.
PointMaps are stored as part of an Owner_, similar to Integer_ and String_ storage.

.. code-block:: racket

   ((([String]: [String]) [Int])*)

