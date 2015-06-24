;; GOPS in the GDL
(game
    (comp (() 

             ;; Game Locations and Storage
             (create loc game (STOCK Stack)
                              (AWARD Stack))

             ;; Set up the players
             (create players 2)

             ;; Player Locations and Storage
             (create loc player (HAND List)
                     (TRICK Stack)
                     (WON Stack))
             (create sto player (SCORE))
             
             ;; Create the deck source
             (initialize (game loc STOCK) (permdeck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                                     (color (red (suit (diamonds))))))
             (initialize ((current player) loc STOCK) (permdeck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                                     (color 
                                                            (black (suit (clubs))))))
             (initialize ((next player) loc STOCK) (permdeck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                                     (color 
                                                            (black (suit (spades))))))
             (shuffle (game loc STOCK))  
          )
   )
               
   ;; Stages of the game
   (stage player
      (end (== (size ((current player) loc HAND)) 0))
                     
                    
      ;; players play a card
      (choice
             
         (()
           (move (any ((current player) loc HAND))
                 (top ((current player) loc TRICK)))
         )
      )
      
      ;; if STOCK is empty, resupply from discard
      (comp
          
          ((== (size (game loc STOCK)) 0)
           (move (top (game loc DISCARD))
                 (top (game loc TEMP)))
           (move (top (game loc DISCARD))
                 (top (game loc STOCK)) all)
           (move (top (game loc TEMP))
                 (top (game loc DISCARD)))
           (shuffle (game loc STOCK)))              
       
      )
   )
         
   ;; determine player score
   (stage player
      (end (== (size ((all player) loc HAND)) 0))
      (comp
          
            (()
             (set ((current player) sto SCORE) (size ((current player) loc HAND)))
             (move (top ((current player) loc HAND))
                   (top (game loc DISCARD)) all))
      )
   )
)
         
         
      
