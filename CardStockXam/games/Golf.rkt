(game
    (setup
       (create players 2)
       (create teams (0) (1))
       (create deck (game iloc STOCK) (deck (rank (A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K))
                                          (color (red (suit (hearts, diamonds)))
                                                 (black (suit (clubs, spades))))))
    )
    (comp (()
          (initialize points PRECEDENCE (
	(all (rank (10)) 10)
TODO
           )
           (shuffle (game iloc STOCK))
           ;;(all players P (move (top (game iloc STOCK)
           ;; for all players, each of players four ilocs gets a card from stock
           
    )
    (stage player
        (end (== (size (game iloc STOCK) 0))
        (choice
            (()
               ;; for any 4 player ilocs, move card from iloc to DISCARD, then move card from STOCK to iloc
            )
            ((;;discard size greater than 0)
               ;;for any 4 player ilocs, move card from DISCARD to iloc top, then move card from bottom of iloc to DISCARD
    
)