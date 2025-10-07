Variable
========

Variables, like String_ constants, must be all caps. They also must begin with a ' character.

.. code-block:: racket

  'C 'AC 'COLOR 'P

Variables can be implicitly assigned from a Collection_ inside the filter 
function or Aggregation_ functions.

There are two other ways to create Variables, with declare_ or let_.

declare
-------

The declare function must be at the beginning of a RECYCLE program. It is useful for
creating program-wide constants or data that cannot be altered through the game. The 
data can be anything explicitly defined, commonly String_ and Integer_, or a
StringCollection_ type.

.. code-block:: racket

  (declare [Type] [Variable])


let
---

The let function is a local declaration of a Variable, followed by a segment of code where
this Variable will be valid.

.. code-block:: racket

  (let [Type] [Variable] [Expression])


