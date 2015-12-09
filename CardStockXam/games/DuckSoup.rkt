;; Duck Soup in the GDL
(game
    (setup  
     ;; Set up the players, 2 players each on their own team
      (create players 2)
      (create teams (0) (1))

      ;; Create the deck source
      (create deck (game iloc STOCK) (deck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                                     (color (red (suit (hearts, diamonds)))
                                                            (black (suit (clubs, spades))))))         
    )
    (comp (() 
             
             (initialize points PRECEDENCE (
                               (all (rank (A)) 14)
                               (all (rank (2)) 13) 
                               (all (rank (3)) 12)
                               (all (rank (4)) 11)
                               (all (rank (5)) 10)
                               (all (rank (6)) 9)
                               (all (rank (7)) 8)
                               (all (rank (8)) 7)
                               (all (rank (9)) 6)
                               (all (rank (10)) 5)
                               (all (rank (J)) 4)
                               (all (rank (Q)) 3)
                               (all (rank (K)) 2)
                               )
             )                    
             (shuffle (game iloc STOCK))  
             (move (top (game iloc STOCK))
                   (top ((all player) iloc HAND)) 13)
          )
   )
               
   ;; Stages of the game
   (stage player
      (end (== (size ((any player) iloc HAND)) 0))
                           
      ;; Each player plays a card
      (stage player
          (end (>= (size ((all player) vloc TRICK)) 1))
                     
                    
          ;; players play a card
          (choice
             
              (()
               (move (top ((current player) iloc HAND))
                     (top ((current player) vloc TRICK)))
              )
              ((== (game sto WAR) 1)
               (move (top ((current player) iloc HAND))
                     (top (game iloc BOUNTY)) 3)
               (move (top ((current player) iloc HAND))
                     (top ((current player) vloc TRICK)))
              )
          )
      )

      (comp
          
          ((!= (cardatt rank (top ((current player) vloc TRICK)))
               (cardatt rank (top ((next player) vloc TRICK))))
           (move (top (game iloc BOUNTY))
                 (bottom (((owner (max (union ((all player) vloc TRICK)) using PRECEDENCE)) player) iloc HAND)) all)
           (move (top ((all player) vloc TRICK))
                 (bottom (((owner (max (union ((all player) vloc TRICK)) using PRECEDENCE)) player) iloc HAND)) all)
           (set (game sto WAR) 0)
          )
          ((== (cardatt rank (top ((current player) vloc TRICK)))
               (cardatt rank (top ((next player) vloc TRICK))))
           (move (top ((all player) vloc TRICK))
                 (top (game iloc BOUNTY)) all)
           (set (game sto WAR) 1)
          )
          
          ;; In Duck Phase draw new cards after each trick
          ((> (size (game vloc STOCK)) 0)
             (move (top (game iloc STOCK))
                   (top ((all player) iloc HAND)))           
          )
          
          ;; In Soup Phase rank high to low, Ace again highest
          ((== (size (game vloc STOCK)) 0)
                        (initialize points PRECEDENCE (
                               (all (rank (A)) 14)
                               (all (rank (K)) 13) 
                               (all (rank (Q)) 12)
                               (all (rank (J)) 11)
                               (all (rank (10)) 10)
                               (all (rank (9)) 9)
                               (all (rank (8)) 8)
                               (all (rank (7)) 7)
                               (all (rank (6)) 6)
                               (all (rank (5)) 5)
                               (all (rank (4)) 4)
                               (all (rank (3)) 3)
                               (all (rank (2)) 2)
                               )
             )
          )

      )
   )
         
   (scoring max (* ((current player) sto DUCK) ((current player) sto SOUP)))
)