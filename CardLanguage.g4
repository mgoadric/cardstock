grammar CardLanguage;

stage : OPEN 'stage' ('game'|'player'|'team') endcondition (computermoves|playermoves|stage)+? CLOSE ;
endcondition : OPEN 'end' (boolean | (('game'|'player'|'team') int)) CLOSE ;

computermoves : OPEN 'comp' multigameaction CLOSE ;
playermoves : OPEN 'actions' multigameaction CLOSE ;

multigameaction : gameaction+? ;
gameaction : OPEN boolean multiaction CLOSE ;
multiaction : action+? ;

action : OPEN (init | loccreate | storagecreate | setaction | moveaction | copyaction | turnaction | shuffleaction) CLOSE ;

loccreate : 'create' 'loc' obj locationdef+? ;
locationdef : OPEN name ('Stack'|'List'|'Queue') ('Imaginary')? CLOSE ;

storagecreate : 'create' 'sto' obj OPEN name+? CLOSE ;

obj : ('player'|'game'|'team') ;


init : 'initialize'  (playerinit | deckinit) ;
playerinit : 'players' int int ('alternate' | 'sequential') ;
deckinit : locstorage deck ;
deck : OPEN 'permdeck' attribute+? CLOSE ;
attribute : (OPEN trueany+? attribute*? CLOSE)  ;



setaction : 'set' rawstorage int ;

moveaction : 'move' card card (int | 'all')?;
copyaction : 'copy' card card (int | 'all')? ;
turnaction : 'turn' ('over' | 'pass') ;
shuffleaction : 'shuffle' locstorage ;
createaction : createsto | createloc ;
createsto : 'create' 'sto' (WHO | WHO2) namelist ;

namelist : OPEN name+? CLOSE ;
loclist : OPEN loc+? CLOSE ;
loc : OPEN name ('List' | 'Stack' | 'Queue') imag? CLOSE ;
imag : 'Memory' ;


rawstorage : OPEN (who | (who2 (posq | int))) 'sto' name CLOSE ;
locstorage : OPEN (who | (who2 (posq | int))) 'loc' name whereclause? CLOSE ;
who : 'game' | 'my' ;
who2 : 'player' | 'team' ;
name : ANY+? ;
trueany : (ANY|int|BOOLOP)+?;
whereclause : 'where' boolatt ; 
boolatt : OPEN attrcomp CLOSE;

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


