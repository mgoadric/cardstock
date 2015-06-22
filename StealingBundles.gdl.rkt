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
                                (BUNDLE Stack))
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
      (end (== (size (game loc STOCK) 0)))
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
              (move (top (game loc POOL where (== (cardatt rank this)
                                                (cardatt rank (top ((current player) loc TRICK))) 0)))
                    (top ((current player) loc BUNDLE)) all)
              (set ((current player) sto MOVED) 1))
             
             ;; BROKE HERE< NEED MORE LANGUANGE STUFF
             ((== (cardatt rank (top ((any player) loc BUNDLE)))
                  (cardatt rank (top ((current player) loc TRICK))))
              (move (top ((any player where (== (cardatt rank (top ((this player) loc BUNDLE)))
                                                (cardatt rank (top ((current player) loc TRICK)))))) loc BUNDLE)
                    (top ((current player) loc BUNDLE)) all)
              (set ((current player) sto MOVED) 1))
              
             ((== ((current player) sto MOVED) 0)      
              (move (top ((current player) loc TRICK))
                    (top (game loc POOL))))

             ((== ((current player) sto MOVED) 1)
              (move (top ((current player) loc TRICK))
                    (top ((current player) loc BUNDLE)))
              (set ((current player) sto MOVED) 0))
                                   
         )
      )    
      (comp (() (set next current))
      ) 
   )
         
   ;; determine team score
   (stage player
      (end (== (size ((all player) loc BUNDLE)) 0))
      (comp
          
         ;; ADD REAL SCORING HERE TODO
            (()
             (set ((current player) sto SCORE) (size ((current player) loc BUNDLE)))
             (move (top ((current player) loc BUNDLE))
                   (top (game loc DISCARD)) all))
      )
   )
)
         
         
      
