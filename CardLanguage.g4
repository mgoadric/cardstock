grammar CardLanguage;

computermoves : OPEN 'comp' multigameaction CLOSE ;
playermoves : OPEN 'actions' multigameaction CLOSE ;

multigameaction : gameaction+? ;
gameaction : OPEN boolean multiaction CLOSE ;
multiaction : action+? ;
action : OPEN (setaction | moveaction | copyaction | turnaction | shuffleaction) CLOSE ;
setaction : 'set' rawstorage int ;
moveaction : 'move' card card (int | 'all')?;
copyaction : 'copy' card card ;
turnaction : 'turn' ('over' | 'pass') ;
shuffleaction : 'shuffle' locstorage ;

card : OPEN ('top' | 'bottom' | int | 'any') locstorage CLOSE;

rawstorage : OPEN (WHO | (WHO2 (posq | int))) 'sto' name CLOSE ;
locstorage : OPEN (WHO | (WHO2 (posq | int))) 'loc' name whereclause? CLOSE ;
WHO : 'game' | 'my' ;
WHO2 : 'player' | 'team' ;
name : ANY+? ;

whereclause : 'where' boolatt ; 
boolatt : OPEN attrcomp CLOSE;
attrcomp : EQOP cardatt cardatt ;
cardatt : name | (OPEN 'cardatt' name ('this' | card ) CLOSE) ;
 

sizeof : OPEN 'size' locstorage CLOSE ;

posq : 'any'| 'all' ;

boolean : (OPEN ((BOOLOP boolean boolean+?) | (intop int  int) | (UNOP boolean)) CLOSE) | (OPEN CLOSE) ;
BOOLOP : 'and' | 'or' ;
intop : (COMPOP | EQOP) ;
COMPOP : '<' | '>' | '>=' | '<=' ;
EQOP : '!=' | '==' ;
UNOP : 'not' ;

int : sizeof | rawstorage | INTNUM+? ;
INTNUM : [0-9] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;


