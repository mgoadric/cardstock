grammar CardLanguage;

gameaction : OPEN boolean action CLOSE ;
action : OPEN (setaction | moveaction) CLOSE ;
setaction : 'set' rawstorage int ;
moveaction : 'move' card locstorage locstorage ;

card : 'top' | 'bottom' | int | OPEN 'any' name CLOSE;

rawstorage : OPEN (WHO | (WHO2 (POSQ | int))) 'sto' name CLOSE ;
locstorage : OPEN (WHO | (WHO2 (POSQ | int))) 'loc' name CLOSE ;
WHO : 'game' | 'my' ;
WHO2 : 'player' | 'team' ;
name : ANY+? ;

quantifier : POSQ | NEGQ ;
POSQ : 'any'| 'all' ;
NEGQ : 'none';

boolean : (OPEN ((BOOLOP boolean boolean) | (intOp int  int) | (UNOP boolean)) CLOSE) | (OPEN CLOSE) ;
BOOLOP : 'and' | 'or' ;
intOp : INTOP ;
INTOP : '<' | '>' | '>=' | '<=' | '!=' | '==' ;
UNOP : 'not' ;

int : rawstorage | INTNUM ;
INTNUM : [0-9]+? ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;


