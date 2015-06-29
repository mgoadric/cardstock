grammar Recycle;

game : OPEN 'game' setup (computermoves|playermoves|stage)+? scoring CLOSE ;
setup : OPEN playercreate teamcreate? deckcreate+? CLOSE ;
stage : OPEN 'stage' ('game'|'player'|'team') endcondition (computermoves|playermoves|stage)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') rawstorage ;
endcondition : OPEN 'end' boolean CLOSE ;

computermoves : OPEN 'comp' multigameaction CLOSE ;
playermoves : OPEN 'choice' multigameaction CLOSE ;

multigameaction : gameaction+? ;
gameaction : OPEN boolean multiaction CLOSE ;
multiaction : action+? ;

action : OPEN (initpoints | teamcreate | cycleaction | setaction | moveaction | copyaction | incaction | decaction | removeaction | turnaction | shuffleaction ) CLOSE ;

playercreate : 'create' 'players' int ;
teamcreate : 'create' 'teams' int 'alternate'? ;
deckcreate : 'create' 'deck' locstorage deck ;
deck : OPEN 'permdeck' attribute+? CLOSE ;
attribute : (OPEN (trueany ',')*? trueany attribute*? CLOSE)  ;

initpoints : 'initialize' 'points' name OPEN awards+? CLOSE ;
awards : OPEN posq subaward+? int CLOSE ;
subaward : OPEN name ((OPEN trueany CLOSE) |(cardatt)) CLOSE ;

cycleaction : 'cycle' ('next' | 'current') int ;

setaction : 'set' rawstorage int ;
incaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;

moveaction : 'move' cardp cardp (int | 'all')?;
copyaction : 'remember' card cardm (int | 'all')? ;
removeaction : 'forget' cardm ;
shuffleaction : 'shuffle' cstorage ;
turnaction : 'turn' 'pass' ;

// Issue with 'any' showing up in comp actions. Needs to be refactored?

card : (cardp | cardm) ;
cardp : maxof | (OPEN ('top' | 'bottom' | int | 'any') locstorage CLOSE) ;
cardm : maxof | (OPEN ('top' | 'bottom' | int | 'any') memstorage CLOSE) ;
owner : OPEN 'owner' card CLOSE ;
rawstorage : OPEN (who | who2) 'sto' namegr CLOSE ;
cstorage : (locstorage | memstorage) ;
locstorage : unionof | OPEN (who | who2) 'loc' namegr whereclause? CLOSE ;
memstorage : unionof | OPEN (who | who2) 'mem' namegr whereclause? CLOSE ;
who : 'game' ;

// SHOULD THIS BE SPLIT INTO TWO SO YOU CAN'T SAY player player player??
who2 : OPEN (posq | int | 'previous' | 'next' | 'current' | who2) ('player' | 'team') CLOSE ;

trueany : (ANY|int|BOOLOP)+?;
whereclause : 'where' boolatt ; 
boolatt : OPEN attrcomp CLOSE ;

attrcomp : EQOP cardatt cardatt ;
// what about this out of context of where???
cardatt : name | (OPEN 'cardatt' name ('each' | card ) CLOSE) ;
 
posq : 'any' | 'all' ;
//need some way to talk about PLAYER EQUALITY/INEQUALITY
boolean : (OPEN ((BOOLOP boolean boolean+?) | attrcomp | (intop int  int) | (UNOP boolean)) CLOSE) | (OPEN CLOSE) ;
BOOLOP : 'and' | 'or' ;
intop : (COMPOP | EQOP) ;
COMPOP : '<' | '>' | '>=' | '<=' ;
EQOP : '!=' | '==' ;
UNOP : 'not' ;

add : OPEN '+' int int CLOSE ;
mult : OPEN '*' int int CLOSE ;
subtract : OPEN '-' int int CLOSE ;
mod : OPEN '%' int int CLOSE ;
divide : OPEN '//' int int CLOSE ;

sizeof : OPEN 'size' cstorage CLOSE ;
maxof : OPEN 'max' cstorage 'using' namegr CLOSE ;
unionof : OPEN 'union' cstorage+? CLOSE ;
sum : OPEN 'sum' (rawstorage | (cstorage 'using' namegr)) CLOSE ; 

int : owner | sizeof | mult | subtract | mod | divide | sum | rawstorage | INTNUM+ ;
INTNUM : [0-9] ;

namegr : ANY+ ;
name : ANY+? ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;