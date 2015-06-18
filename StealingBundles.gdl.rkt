;; Stealing Bundles in the GDL
(game
    (comp (() 

             ;; Game Locations and Storage
             (create loc game (STOCK Stack)
                              (DISCARD Stack)
                              (POOL Stack))

             ;; Set up the players
             (create players 2)

             ;; Player Locations and Storage
             (create loc player (HAND List)
                                (TRICK Stack)
                                (WON Stack))
             (create sto player (SCORE))
             
             ;; Create the deck source
             (initialize (game loc STOCK) (permdeck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                                     (color (red (suit (hearts, diamonds)))
                                                            (black (suit (clubs, spades))))))
             (shuffle (game loc STOCK))
             (move (top (game loc STOCK))
                   (top (game loc POOL)) 4)  
          )
   )
               
   ;; Stages of the game
   (stage player
      (end (== (size (game loc STOCK) 0))
      (comp (() (move (top (game loc STOCK))
                      (top ((all player) loc HAND)) 4)
             )
      ) 
                     
      ;; players play a round      
      (stage player
         (end (== (size ((all player) loc HAND)) 0))
                    
         ;; players play a card
         (choice
             
            (()
                (move (any ((current player) loc HAND)) 
                      (top ((current player) loc TRICK))))

         )
              
         ;; after players play hand, computer wraps up trick
         (comp
             ((== (cardatt rank (any (game loc POOL)))
                  (cardatt rank (top ((current player) loc TRICK))))
              (move (all (game loc POOL where (== (cardatt rank this)
                                                (cardatt rank (top ((current player) loc TRICK))) 0)))
                    (top ((current player) loc WON)))
              (set ((current player) sto MOVED) 1))
             
             ;; BROKE HERE< NEED MORE LANGUANGE STUFF
             ((== (cardatt rank (top ((any player) loc WON)))
                  (cardatt rank (top ((current player) loc TRICK))))
              (move (all ((any player) loc WON where (== (cardatt rank this)
                                                         (cardatt rank (top ((current player) loc TRICK))))))
                    (top ((current player) loc WON)))
              (set ((current player) sto MOVED) 1))
              
              
              (move (top ((current player) loc TRICK))
                    (top ((current player) loc WON)))
                    
                      
                 ;; determine who won the hand, set them first next time, and give them a point
                 (remove (top (game loc LEAD)))
                 (set next (owner (max (union ((all player) loc TRICK)) using PRECEDENCE)))

             )
                  
             ;; if winner played trump and trump not broken, trump is now broken
             ((and (== (cardatt suit (top ((next player) loc TRICK))) 
                       (cardatt suit (top (game loc TRUMP))))
                   (== (game sto BROKEN) 0))
              (set (game sto BROKEN) 1))
                  
             ;; discard all the played cards
             (() (move (top ((all player) loc TRICK)) 
                       (top ((next player) loc TRICKSWON))))
             
         )
      )
         
      ;; determine team score
      (stage player
         (end (== (size ((all player) loc TRICKSWON)) 0))
         (comp
          
            ;; ADD REAL SCORING HERE TODO
            ((== (sum ((current player) loc TRICKSWON) using SCORE) 26)
             (dec ((current player) sto SCORE) 26))
            
            ((!= (sum ((current player) loc TRICKSWON) using SCORE) 26)
             (inc ((current player) sto SCORE) (sum ((current player) loc TRICKSWON) using SCORE)))
          
            (() (move (top ((current player) loc TRICKSWON))
                      (top (game loc DISCARD))))
         )
      )
   )
)
         
         
      
