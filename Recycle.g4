// Version 0.3 of our REcursive CYclic Card game LanguagE

grammar Recycle;

game : OPEN 'game' setup (computermoves|playermoves|stage)+? scoring CLOSE ;
setup : OPEN 'setup' playercreate OPEN teamcreate CLOSE deckcreate+? CLOSE ;
stage : OPEN 'stage' ('game'|'player'|'team') endcondition (computermoves|playermoves|stage)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') rawstorage ;
endcondition : OPEN 'end' boolean CLOSE ;

computermoves : OPEN 'comp' multigameaction CLOSE ;
playermoves : OPEN 'choice' multigameaction CLOSE ;

multigameaction : gameaction+? ;
gameaction : OPEN boolean multiaction CLOSE ;
multiaction : action+? ;

action : OPEN (initpoints | teamcreate | cycleaction | setaction | moveaction | copyaction | incaction | decaction | removeaction | turnaction | shuffleaction ) CLOSE ;

playercreate : OPEN 'create' 'players' int CLOSE ;
teamcreate : 'create' 'teams' attribute+? ;
deckcreate : OPEN 'create' 'deck' locstorage deck CLOSE ;
deck : OPEN 'permdeck' int? attribute+? CLOSE ;
attribute : (OPEN (trueany ',')*? trueany attribute*? CLOSE)  ;

initpoints : 'initialize' 'points' name OPEN awards+? CLOSE ;
awards : OPEN posq subaward+? int CLOSE ;
subaward : OPEN name ((OPEN trueany CLOSE) |(cardatt)) CLOSE ;

cycleaction : 'cycle' ('next' | 'current') (int | 'current' | 'next' | 'previous') ;

setaction : 'set' rawstorage int ;
incaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;

moveaction : 'move' cardp cardp (int | 'all')?;
copyaction : 'remember' card cardm (int | 'all')? ;
removeaction : 'forget' cardm ;
shuffleaction : 'shuffle' cstorage ;
turnaction : 'turn' 'pass' ;

// Issue with 'any' showing up in comp actions. Needs to be refactored?

card : maxof | (cardp | cardm) ;
cardp : (OPEN ('top' | 'bottom' | int | 'any') locstorage CLOSE) ;
cardm : (OPEN ('top' | 'bottom' | int | 'any') memstorage CLOSE) ;
owner : OPEN 'owner' card CLOSE ;
rawstorage : OPEN (who | who2) 'sto' namegr CLOSE ;
cstorage : unionof | (locstorage | memstorage) ;
locstorage : OPEN locpre 'loc' locpost CLOSE ;
memstorage : OPEN locpre 'mem' locpost CLOSE;
locpre :  (who | who2) ;
locpost : namegr whereclause? ;

who : 'game' ;

// SHOULD THIS BE SPLIT INTO TWO SO YOU CAN'T SAY player player player??
who2 : OPEN (posq | int | 'previous' | 'next' | 'current' | who2) ('player' | 'team') CLOSE ;

trueany : (ANY|int|BOOLOP)+?;
whereclause : 'where' booleanwhere ; 

attrcomp : EQOP cardatt cardatt ;
attrcompwhere : EQOP (cardatt | cardattwhere) (cardatt | cardattwhere) ;
// what about this out of context of where???
cardatt : name | (OPEN 'cardatt' name card  CLOSE) ;
cardattwhere : name | (OPEN 'cardatt' name 'each' CLOSE) ;
 
posq : 'any' | 'all' ;
//need some way to talk about PLAYER EQUALITY/INEQUALITY
booleanwhere : (OPEN ((BOOLOP booleanwhere booleanwhere+?) | attrcompwhere | (intop intwhere intwhere ) | (UNOP booleanwhere)) CLOSE) | (OPEN CLOSE) ;
boolean : (OPEN ((BOOLOP boolean boolean+?) | (intop int int ) | attrcomp | (UNOP boolean)) CLOSE) | (OPEN CLOSE) ;
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
scorewhere : OPEN 'score' 'each' 'using' namegr CLOSE ;
score : OPEN 'score' card 'using' namegr CLOSE ;

intwhere : scorewhere | int ;
int : owner | sizeof | mult | subtract | mod | divide | sum | rawstorage | score | INTNUM+ ;
INTNUM : [0-9] ;

namegr : ANY+ ;
name : ANY+? ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;