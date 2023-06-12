---
layout: post
title:  "Enchère Code"
date:   2023-06-09 12:00:00 -0600
categories: TRICK-TAKING
image: images/enchere.jpg
author: Tyrone Mason
avatar: images/mason.png
authorhome: https://github.com/mason-t-demond
comments: true
---
# Enchère
`
    (game
        (declare 3 'NUMP)
        (setup 
            (create players 'NUMP)
            (create teams (0) (1) (2))  
    
            (create deck (game iloc CASH) (deck (RANK (TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK))
                                                (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                (BLACK (SUIT (SPADES, CLUBS))))))
            (create deck (game iloc PRIZE) (deck (RANK (QUEEN, KING, ACE))
                                                (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                (BLACK (SUIT (SPADES, CLUBS)))))))

        (do 
            (
                (shuffle (game iloc CASH))
                (shuffle (game iloc PRIZE))
                (all player 'P 
                    (repeat 12
                        (move (top (game iloc CASH))
                            (top ('P iloc HAND)))))))
            
        (stage player
            (end 
                (all player 'P 
                (== (size ('P iloc HAND)) 0)))
            
            (do 
                (
                    (move (top (game iloc PRIZE))
                        (top (game vloc AWARD)))))

            (stage player
                (end 
                    (all player 'P (== (size ('P iloc HIDDENTRICK)) 1))) 
                
                    (choice 
                        (
                            (do 
                                (
                                    (any ((current player) iloc HAND) 'C
                                        (move 'C 
                                        (top ((current player) iloc HIDDENTRICK)))))))))
            
            (do 
                (
                    (all player 'P 
                        (move (top ('P iloc HIDDENTRICK))
                            (top ('P vloc TRICK))))
                
                    (put points 'PRECEDENCE 
                        (
                            ((SUIT (cardatt SUIT (top (game vloc AWARD)))) 2)
                            ((COLOR (cardatt COLOR (top (game vloc AWARD)))) 1)
                            ((RANK (JACK)) 110)
                            ((RANK (TEN)) 100)
                            ((RANK (NINE)) 90)
                            ((RANK (EIGHT)) 80)
                            ((RANK (SEVEN)) 70)
                            ((RANK (SIX)) 60)
                            ((RANK (FIVE)) 50)
                            ((RANK (FOUR)) 40)
                            ((RANK (THREE)) 30)
                            ((RANK (TWO)) 20)
                            ))

                    ((> 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                    (move (top (game vloc AWARD))
                                    (top ((owner (min (union (all player 'PR 
                                                                ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))
                
                    ((<= 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                    (move (top (game vloc AWARD))
                                    (top ((owner (max (union (all player 'PR 
                                                                ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))
                
                    (all player 'P 
                        (move (top ('P vloc TRICK)) 
                                (top (game vloc DISCARD)))))))

        (do
            (
            (put points 'SCOREPOINTS 
                (
                    ((RANK (ACE)) 4)
                    ((RANK (KING)) 2)
                    ((RANK (QUEEN)) 1)))))
    
        (scoring max (sum ((current player) vloc WON) using 'SCOREPOINTS)))
`


# Enchère Avancée
`
    (game
        (declare 3 'NUMP)
        (setup 
            (create players 'NUMP)
            (create teams (0) (1) (2))  
        
            (create deck (game iloc CASH) (deck (RANK (TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK))
                                            (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                    (BLACK (SUIT (SPADES, CLUBS))))))
            (create deck (game iloc PRIZE) (deck (RANK (QUEEN, KING, ACE))
                                            (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                    (BLACK (SUIT (SPADES, CLUBS))))))
            (create deck (game iloc PRIZE) (deck (RANK (JOKER)))))

        (do 
        (
            (put points 'SCORE
                (
                    ((RANK (ACE)) 1)
                    ((RANK (KING)) 1)
                    ((RANK (QUEEN)) 1)

                    ((SUIT (HEARTS)) 1)

                    ((RANK (KING)) (SUIT (HEARTS)) 5)))

            (put points 'NEGSCORE
                (
                    ((RANK (JOKER)) 10)))

            (shuffle (game iloc CASH))
            (shuffle (game iloc PRIZE))
            
            (move (top (game iloc CASH))
                (top (game vloc SPARE)))
                
            (all player 'P 
                (repeat 13
                    (move (top (game iloc CASH))
                        (top ('P iloc HAND)))))))

        (stage player
            (end 
                (all player 'P 
                    (== (size ('P iloc HAND)) 0)))  
            
            (do 
                (
                    (move (top (game iloc PRIZE))
                        (top (game vloc AWARD)))))

            (stage player
                (end 
                    (all player 'P (== (size ('P iloc HIDDENTRICK)) 1))) 
                
                    (choice 
                        (
                            ((or (!= (size (filter ((current player) iloc HAND) 'H (== (cardatt SUIT 'H) (cardatt SUIT (top (game vloc AWARD)))))) 0)
                                (!= (size (filter ((current player) iloc HAND) 'H (== (cardatt RANK 'H) (cardatt RANK (top (game vloc SPARE)))))) 0))
                                    (any (filter ((current player) iloc HAND) 'NH 
                                    (or (== (cardatt SUIT 'NH) (cardatt SUIT (top (game vloc AWARD))))
                                    (== (cardatt RANK 'NH) (cardatt RANK (top (game vloc SPARE)))))) 
                            'C (move 'C (top ((current player) iloc HIDDENTRICK)))))

                            ((and (== (size (filter ((current player) iloc HAND) 'H (== (cardatt SUIT 'H) (cardatt SUIT (top (game vloc AWARD)))))) 0)
                                (== (size (filter ((current player) iloc HAND) 'H (== (cardatt RANK 'H) (cardatt RANK (top (game vloc SPARE)))))) 0))
                            (any ((current player) iloc HAND) 'C (move 'C (top ((current player) iloc HIDDENTRICK))))))))
            
            (do 
                (
                    (all player 'P 
                        (move (top ('P iloc HIDDENTRICK))
                            (top ('P vloc TRICK))))
                
                    (put points 'PRECEDENCE 
                        (
                            ((RANK (JACK)) 110)
                            ((RANK (TEN)) 100)
                            ((RANK (NINE)) 90)
                            ((RANK (EIGHT)) 80)
                            ((RANK (SEVEN)) 70)
                            ((RANK (SIX)) 60)
                            ((RANK (FIVE)) 50)
                            ((RANK (FOUR)) 40)
                            ((RANK (THREE)) 30)
                            ((RANK (TWO)) 20)
                            ((RANK (cardatt RANK (top (game vloc SPARE)))) 100)
                            ((SUIT (cardatt SUIT (top (game vloc AWARD)))) 2)
                            ((COLOR (cardatt COLOR (top (game vloc AWARD)))) 1)))
                        
                    ((> 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                    (move (top (game vloc AWARD))
                                    (top ((owner (min (union (all player 'PR 
                                                                ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))
                
                    ((<= 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                    (move (top (game vloc AWARD))
                                    (top ((owner (max (union (all player 'PR 
                                                                ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))
                
                (all player 'P 
                    (move (top ('P vloc TRICK)) 
                            (top (game vloc DISCARD)))))))

        (do 
            (
                (all player 'P (inc ('P sto SCORE) (sum ('P vloc WON) using 'SCORE)))))
        (do
            (
                (all player 'P (dec ('P sto SCORE) (sum ('P vloc WON) using 'NEGSCORE)))))
    


        (scoring max ((current player) sto SCORE)))
`

# Enchère Originale
`
(game
    (declare 3 'NUMP)
    (setup 
    (create players 'NUMP)
    (create teams (0) (1) (2))  
  
    (create deck (game iloc CASH) (deck (RANK (TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK))
                                        (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                (BLACK (SUIT (SPADES, CLUBS))))))
    (create deck (game iloc PRIZE) (deck (RANK (QUEEN, KING, ACE))
                                        (COLOR (RED (SUIT (HEARTS, DIAMONDS)))
                                                (BLACK (SUIT (SPADES, CLUBS)))))))

    (do 
        (
            (shuffle (game iloc CASH))

            (shuffle (game iloc PRIZE))
            
            (move (top (game iloc CASH))
                (top (game vloc SPARE)))
            
            (all player 'P 
                (repeat 12
                    (move (top (game iloc CASH))
                          (top ('P iloc HAND)))))))

    (stage player
        (end 
            (all player 'P 
                (== (size ('P iloc HAND)) 0)))
    
        (do 
            (
                (move (top (game iloc PRIZE))
                    (top (game vloc AWARD)))))

        (stage player
            (end 
                (all player 'P (== (size ('P iloc HIDDENTRICK)) 1)))
                
                (choice 
                    (
                        ((or (!= (size (filter ((current player) iloc HAND) 'H (== (cardatt SUIT 'H) (cardatt SUIT (top (game vloc AWARD)))))) 0)
                                (!= (size (filter ((current player) iloc HAND) 'H (== (cardatt RANK 'H) (cardatt RANK (top (game vloc SPARE)))))) 0))
                                (any (filter ((current player) iloc HAND) 'NH 
                                (or (== (cardatt SUIT 'NH) (cardatt SUIT (top (game vloc AWARD))))
                                (== (cardatt RANK 'NH) (cardatt RANK (top (game vloc SPARE)))))) 
                            'C (move 'C (top ((current player) iloc HIDDENTRICK)))))

                        ((and (== (size (filter ((current player) iloc HAND) 'H (== (cardatt SUIT 'H) (cardatt SUIT (top (game vloc AWARD)))))) 0)
                                (== (size (filter ((current player) iloc HAND) 'H (== (cardatt RANK 'H) (cardatt RANK (top (game vloc SPARE)))))) 0))
                            (any ((current player) iloc HAND) 'C (move 'C (top ((current player) iloc HIDDENTRICK))))))))
        
        (do 
            (
                (all player 'P 
                    (move (top ('P iloc HIDDENTRICK))
                        (top ('P vloc TRICK))))
                        
                (put points 'PRECEDENCE 
                    (
                        ((RANK (JACK)) 110)
                        ((RANK (TEN)) 100)
                        ((RANK (NINE)) 90)
                        ((RANK (EIGHT)) 80)
                        ((RANK (SEVEN)) 70)
                        ((RANK (SIX)) 60)
                        ((RANK (FIVE)) 50)
                        ((RANK (FOUR)) 40)
                        ((RANK (THREE)) 30)
                        ((RANK (TWO)) 20)
                        ((RANK (cardatt RANK (top (game vloc SPARE)))) 100)
                        ((SUIT (cardatt SUIT (top (game vloc AWARD)))) 2)
                        ((COLOR (cardatt COLOR (top (game vloc AWARD)))) 1)))

                ((> 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC 
                (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                (move (top (game vloc AWARD))
                            (top ((owner (min (union (all player 'PR 
                                                            ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))

                ((<= 1 (size (filter (union (all player 'P ('P vloc TRICK))) 'TC
                (== (score 'TC using 'PRECEDENCE) (score (max (union (all player 'PP ('PP vloc TRICK))) using 'PRECEDENCE) using 'PRECEDENCE)))))
                (move (top (game vloc AWARD))
                    (top ((owner (max (union (all player 'PR 
                                                        ('PR vloc TRICK))) using 'PRECEDENCE)) vloc WON))))

                (all player 'P 
                    (move (top ('P vloc TRICK)) 
                        (top (game vloc DISCARD)))))))

    (stage player
        (end (all player 'P (== (size ('P vloc WON)) 0)))

        (do
            (
                (put points 'SCORE (
                    ((RANK (ACE))   12)
                    ((RANK (KING))  11) 
                    ((RANK (QUEEN)) 10)))
        
                (put points 'CLUBS (
                            ((SUIT (CLUBS))    1)))
                (put points 'DIAMONDS (
                            ((SUIT (DIAMONDS)) 1)))           
                (put points 'HEARTS (
                            ((SUIT (HEARTS))   1)))  
                (put points 'SPADES (
                            ((SUIT (SPADES))   1)))

                (put points 'QUEENS (
                            ((RANK (QUEEN)) 1)))           
                (put points 'KINGS (
                            ((RANK (KING))  1)))  
                (put points 'ACES (
                            ((RANK (ACE))   1)))
                    
            ((== (size ((current player) vloc WON)) 0)
                (set ((current player) sto POINTS) 0))
            
            ((>= (size ((current player) vloc WON)) 1)
                (do 
                    (
                        (set ((current player) sto POINTS) (score (max ((current player) vloc WON) using 'SCORE) using 'SCORE))
                        
                        (any ((current player) vloc WON) 'P 
                        ((== (size (filter ((current player) vloc WON) 'PP 
                            (== (cardatt RANK 'PP) (cardatt RANK 'P)))) 2)
                            (set ((current player) sto POINTS) (+ (score 'P using 'SCORE) 13))))

                        ((and (>= (sum ((current player) vloc WON) using 'QUEENS) 2) (>= (sum ((current player) vloc WON) using 'KINGS) 2)) 
                        (set ((current player) sto POINTS) 179))
                        ((and (>= (sum ((current player) vloc WON) using 'QUEENS) 2) (>= (sum ((current player) vloc WON) using 'ACES) 2)) 
                        (set ((current player) sto POINTS) 180))
                        ((and (>= (sum ((current player) vloc WON) using 'KINGS) 2) (>= (sum ((current player) vloc WON) using 'ACES) 2)) 
                        (set ((current player) sto POINTS) 181))

                        ((and (and (and (>= (sum ((current player) vloc WON) using 'QUEENS) 1) 
                                        (>= (sum ((current player) vloc WON) using 'KINGS)  1))
                                        (>= (sum ((current player) vloc WON) using 'ACES)   1))
                                (or (or (or (>= (sum ((current player) vloc WON) using 'CLUBS)    3) 
                                            (>= (sum ((current player) vloc WON) using 'SPADES)   3)) 
                                            (>= (sum ((current player) vloc WON) using 'DIAMONDS) 3)) 
                                            (>= (sum ((current player) vloc WON) using 'HEARTS)   3)))
                            (set ((current player) sto POINTS) 182))

                        (any ((current player) vloc WON) 'R 
                        ((== (size (filter ((current player) vloc WON) 'RR 
                            (== (cardatt RANK 'RR) (cardatt RANK 'R)))) 3)
                        (set ((current player) sto POINTS) (+ (score 'R using 'SCORE) 183))))

                        (any ((current player) vloc WON) 'Y 
                        ((== (size (filter ((current player) vloc WON) 'YY (== (cardatt RANK 'YY) (cardatt RANK 'Y)))) 3)
                        (any ((current player) vloc WON) 'X 
                            ((== (size (filter ((current player) vloc WON) 'XX (== (cardatt RANK 'XX) (cardatt RANK 'X)))) 2)
                            (set ((current player) sto POINTS) (+ (score 'Y using 'SCORE) 196))))))

                        (any ((current player) vloc WON) 'U 
                        ((== (size (filter ((current player) vloc WON) 'UU 
                        (== (cardatt RANK 'UU) (cardatt RANK 'U)))) 4)
                        (set ((current player) sto POINTS) (+ (score 'U using 'SCORE) 209))))

                        ((and (>= (sum ((current player) vloc WON) using 'ACES) 3)
                            (>= (sum ((current player) vloc WON) using 'KINGS) 2))
                        (set ((current player) sto POINTS) 222))

                        ((== (sum ((current player) vloc WON) using 'ACES) 4)
                        (set ((current player) sto POINTS) 223))

                        (repeat all (move (top ((current player) vloc WON)) 
                                        (top (game vloc DISCARD))))))))))

    (scoring max ((current player) sto POINTS)))
`

# Additional Note
Games are only coded for a single round at the moment. They will likely be updated later.