﻿;; GoFish
;;
;; https://www.pagat.com/quartet/gofish.html

(game ;; MATCH START

 (declare (A, TWO, THREE, FOUR, FIVE, SIX) 'RANKS) ;;SIX, SEVEN, EIGHT, NINE, TEN, J, Q, K
    (setup  
     ;; Set up the players
      (create players 2)
      (create teams (0) (1))
      ;; Create the deck source
      (create deck (game iloc STOCK) (deck (RANK (A, TWO, THREE, FOUR, FIVE, SIX))
                                             (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                   (BLACK (SUIT (CLUBS, SPADES))))))
      )
												   
	;;(stage player  ;; ROUND LOOP START
	;;(end (== (game sto ROUNDS) 1))
	
	(do ( ;; DEALING START
		(shuffle (game iloc STOCK))
		(all player 'P (do (
                                    (repeat 5 (move (top (game iloc STOCK)) (top ('P iloc HAND))))
                                 (all 'RANKS 'R
			(let (filter ('P iloc HAND) 'MR (== (cardatt RANK 'MR) 'R)) 'MYRANK 
				((== (size 'MYRANK) 4)
				(do (
					(inc ('P sto SCORE) 1)
					(all 'MYRANK 'C
						(move 'C (top ('P iloc TRICKSTACK))))
	)))))))))) ;; DEALING END
        
	(stage player  ;; TURN LOOP START

	(end (or (== (size (game iloc STOCK)) 0) (any player 'P (== (size ('P iloc HAND)) 0))))	

		(choice (
		(any 'RANKS 'R    ;; CHOICE GENERATION START
		
		(let (filter ((current player) iloc HAND) 'MR (== (cardatt RANK 'MR) 'R)) 'MYRANK ;; save each card we have in rank R
			((> (size 'MYRANK) 0)
											
					(any (other player) 'P
                                             
						(let (filter ('P iloc HAND) 'TR (== (cardatt RANK 'TR) 'R)) 'THEIRRANK ;; Makes a collection of cards that player X has in rank R	
							(do (						
								
								;; If they don't have cards in rank R -- Draw
								((== (size 'THEIRRANK) 0)
								(do (
									(move (top (game iloc STOCK)) (top ((current player) iloc HAND))) 
									
									;; If the drawn card has rank R -- play another turn
									((== (cardatt RANK (top ((current player) iloc HAND))) 'R)
									(cycle next current)
									)
								)	)
								)
								;; If they have cards in rank R -- Take their cards and play another turn
								((> (size 'THEIRRANK) 0) 
								(do ( 
									(all 'THEIRRANK 'TRC 
										(move 'TRC (top ((current player) iloc HAND)))
									)
									(cycle next current)
								)	)				
							)	))
                                                        )
                                                  )
					)
                                  )
                                             
		)))
        ;; Go through all the ranks looking for tricks
		(do ( (all 'RANKS 'R
			(let (filter ((current player) iloc HAND) 'MR (== (cardatt RANK 'MR) 'R)) 'MYRANK 
				((== (size 'MYRANK) 4)
				(do (
					(inc ((current player) sto SCORE) 1)
					(all 'MYRANK 'C
						(move 'C (top ((current player) iloc TRICKSTACK))))
				)	)
                                )
			)
                 )))        ;; CHOICE GENERATION END
	) ;; TURN LOOP END
	 
	
	;; END OF GAME PROCESSING START -- Send cards back to deck
	;;(stage player 
	;;(end (all player 'P (== ('P sto PROC) 1)))
	
	;;	(repeat all
	;;		(move (top ((current player) iloc HAND)) (top (game iloc STOCK))))
	;;	)
	;;	(repeat all
	;;		(move (top ((current player) iloc 'TRICKSTACK)) (top (game iloc STOCK)))
	;;	)
	;;	(set ((current player) sto PROC) 1)
	;;) ;; END OF GAME PROCESSING END

	
	;;(do ( ;; GAME RESETTING
	;;	(all player 'P
    ;;       (set ('P sto PROC) 0)) 
	;;	)
	;;	(set (game sto 'TRICKSWON) 0)
	;;	(inc (game sto ROUNDS) 1)
	;;)	) ;; GAME RESETTING END

	
	;;) ;; ROUND LOOP END

	(scoring max ((current player) sto SCORE))
	) ;; MATCH END








	;; I might need to set-up a different structure for the players hand
	;; Rather than just a hand, a player could have a storage for each rank
	;; this could deal with the issue of moving cards because I could just move all cards out of a players location 'rank'
	
	
	