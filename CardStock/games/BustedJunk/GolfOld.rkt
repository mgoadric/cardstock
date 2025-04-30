(game
 (declare (ONE, TWO, THREE, FOUR) 'PLOCS)
 (setup
  (create players 2)
  (create teams (0) (1))
  (create deck (game iloc STOCK) (deck (RANK (A, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, J, Q, K))
                                       (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                              (BLACK (SUIT (CLUBS, SPADES))))))
  )
 (do 
     (
      (put points 'PRECEDENCE 
           (
            ((RANK (K)) 12) 
            ((RANK (Q)) 11)
            ((RANK (J)) 0)
            ((RANK (TEN)) 10)
            ((RANK (NINE)) 9)
            ((RANK (EIGHT)) 8)
            ((RANK (SEVEN)) 7)
            ((RANK (SIX)) 6)
            ((RANK (FIVE)) 5)
            ((RANK (FOUR)) 4)
            ((RANK (THREE)) 3)
            ((RANK (TWO)) 2)
            ((RANK (A)) 1)
            )
           )
      
      ;; Shuffle the deck, give each player one card in each of their locations
      (shuffle (game iloc STOCK))    
      (all player 'P
           (all 'PLOCS 'L
                (move (top (game iloc STOCK)) 
                      (top ('P hloc 'L))
                      )
                )
           )
      )
   )
 
 (stage player
        (end 
         (== (size (game iloc STOCK)) 0)
         )

        ;; Draw a card
        (choice 
         (
          (move (top (game iloc STOCK)) 
                (top((current player) iloc HAND))
                )
          ((> (size (game vloc DISCARD)) 0)
           (do 
               (
                (move (top (game vloc DISCARD)) 
                      (top((current player) iloc HAND))
                      )
                (set ((current player) sto DISCARDED) 1))
             )
           )
          )
         )
        
        ;; Play a card
        (choice 
         (
          ((!= ((current player) sto DISCARDED) 1)
           (move (top ((current player) iloc HAND)) 
                 (top (game vloc DISCARD))
                 )
           )
          (any 'PLOCS 'L
               (do 
                   (
                    (move (top ((current player) hloc 'L))   
                          (top (game vloc DISCARD))
                          )
                    (move (top ((current player) iloc HAND)) 
                          (top ((current player) hloc 'L))
                          )
                    )
                 )
               )
          )
         )
        
        ;; Forget if you drew from the discard pile
        (do 
            (
             (set ((current player) sto DISCARDED) 0))
          )
        )
 (scoring min (sum (union (all 'PLOCS 'L
                               ((current player) hloc 'L))) using 'PRECEDENCE))
 )