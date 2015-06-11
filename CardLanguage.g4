grammar CardLanguage;

computermoves : OPEN 'comp' multigameaction CLOSE ;
playermoves : OPEN 'actions' multigameaction CLOSE ;

multigameaction : gameaction+? ;
gameaction : OPEN boolean multiaction CLOSE ;
multiaction : action+? ;
action : OPEN (setaction | moveaction | copyaction | turnaction | shuffleaction | createaction) CLOSE ;

setaction : 'set' ('NEXTPLAYER' | rawstorage) int ;
intaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;
moveaction : 'move' card card (int | 'all')?;
copyaction : 'copy' card card ;
turnaction : 'turn' ('over' | 'pass') ;
shuffleaction : 'shuffle' locstorage ;
createaction : createsto | createloc ;
createsto : 'create' 'sto' (WHO | WHO2) namelist ;

namelist : OPEN name+? CLOSE ;
loclist : OPEN loc+? CLOSE ;
loc : OPEN name ('List' | 'Stack' | 'Queue') imag? CLOSE ;
imag : 'Memory' ;

card : maxof | (OPEN ('top' | 'bottom' | int | 'any') locstorage CLOSE);
owner : OPEN 'owner' card CLOSE;
rawstorage : OPEN (WHO | (WHO2 (posq | int))) 'sto' name CLOSE ;
locstorage : OPEN (WHO | (WHO2 (posq | int))) 'loc' name whereclause? CLOSE ;
WHO : 'game' | 'my' ;
WHO2 : 'player' | 'team' ;
name : ANY+? ;

whereclause : 'where' OPEN boolatt CLOSE ; 
boolatt : attrcomp ;
attrcomp : EQOP cardatt cardatt ;
cardatt : name | (OPEN 'cardatt' name ('this' | card ) CLOSE) ;
 
posq : 'any'| 'all' ;

boolean : (OPEN ((BOOLOP boolean boolean+?) | boolatt | (intop int  int) | (UNOP boolean)) CLOSE) | (OPEN CLOSE) ;
BOOLOP : 'and' | 'or' ;
intop : (COMPOP | EQOP) ;
COMPOP : '<' | '>' | '>=' | '<=' ;
EQOP : '!=' | '==' ;
UNOP : 'not' ;

sizeof : OPEN 'size' locstorage CLOSE ;
maxof : OPEN 'max' locstorage 'using' name CLOSE ;
unionof : OPEN 'union' locstorage locstorage+? CLOSE ;

int : owner | sizeof | rawstorage | INTNUM+? ;
INTNUM : [0-9] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;


