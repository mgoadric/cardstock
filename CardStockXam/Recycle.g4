// Version 0.4 of our REcursive CYclic Card game LanguagE

grammar Recycle;

game : OPEN 'game' declare*? setup (multiaction|stage)+? scoring CLOSE ;
setup : OPEN 'setup' playercreate OPEN teamcreate CLOSE (OPEN deckcreate CLOSE)+? CLOSE ;
stage : OPEN 'stage' ('player'|'team') endcondition (multiaction | stage)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') int ;
endcondition : OPEN 'end' boolean CLOSE ;

action : OPEN (initpoints | teamcreate | deckcreate | cycleaction | setaction | moveaction | copyaction
         | incaction | decaction | removeaction | turnaction | shuffleaction | repeat) CLOSE ;
multiaction : OPEN 'choice' OPEN (condact)+? CLOSE CLOSE | OPEN 'do' OPEN (condact)+? CLOSE CLOSE
              | agg | let ;
condact : OPEN boolean multiaction CLOSE | multiaction | OPEN boolean action CLOSE | action ;

agg : OPEN ('any' | 'all') collection var (multiaction | action | boolean | cstorage) CLOSE ;
let : OPEN 'let' typed var (multiaction | action) CLOSE ;

playercreate : OPEN 'create' 'players' (int | var) CLOSE ;
teamcreate : 'create' 'teams' attribute+? ;
deckcreate : 'create' 'deck' cstorage deck | repeat ;
deck : OPEN 'deck' int? attribute+? CLOSE ;

initpoints : 'put' 'points' var OPEN awards+? CLOSE ;
awards : OPEN subaward+? int CLOSE ;
subaward : OPEN namegr ((OPEN trueany CLOSE) |(cardatt)) CLOSE ;

cycleaction : 'cycle' ('next' | 'current') (owner | 'current' | 'next' | 'previous') ;

setaction : 'set' rawstorage int ;
incaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;

moveaction : 'move' card card ;
copyaction : 'remember' card card ;
removeaction : 'forget' card ;
shuffleaction : 'shuffle' cstorage ;
turnaction : 'turn' 'pass' ;
repeat : 'repeat' int action ;

card : maxof | minof | var | actual | (OPEN ('top' | 'bottom' | int) cstorage CLOSE) ;
actual : OPEN 'actual' card CLOSE ;
rawstorage : OPEN ('game' | who) 'sto' namegr CLOSE ;
cstorage : unionof | wherefilter | OPEN locpre ('vloc'|'iloc'|'hloc'|'mem') namegr CLOSE | memstorage ;
memstorage :  (OPEN ('top' | 'bottom' | int) memset CLOSE) ;
memset : tuple ;
tuple : OPEN 'tuples' int cstorage 'using' var CLOSE ;
var : '\'' namegr ;

locpre :  'game' | who | var ;
who : OPEN (int | 'previous' | 'next' | 'current' | who) ('player' | 'team') CLOSE | owner;
owner : OPEN 'owner' card CLOSE ;

typed : int | boolean | namegr | var | collection ;
collection : cstorage | strcollection | cstoragecollection | pcollection ;
strcollection : OPEN (namegr ',')*? namegr CLOSE ;
cstoragecollection : memset | agg | let ;
pcollection : 'player' ;
declare : OPEN 'declare' typed var CLOSE ;

trueany : (ANY|int|BOOLOP)+?;

wherefilter : OPEN 'where' cstorage var boolean CLOSE ;

attrcomp : EQOP cardatt cardatt ;
cardatt : namegr | (OPEN 'cardatt' (var | namegr) card CLOSE) | var ;

//need some way to talk about PLAYER EQUALITY/INEQUALITY
boolean : (OPEN ((BOOLOP boolean boolean+?) | (intop int int ) | attrcomp | (EQOP card card)
          | (UNOP boolean)) CLOSE) | (OPEN CLOSE) | agg ;
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

sizeof : OPEN 'size' (cstorage | memset) CLOSE ;
maxof : OPEN 'max' cstorage 'using' var CLOSE ;
minof : OPEN 'min' cstorage 'using' var CLOSE ;
unionof : OPEN 'union' (cstorage+? | agg) CLOSE ;
sum : OPEN 'sum' cstorage 'using' var CLOSE ;
score : OPEN 'score' card 'using' var CLOSE ;

int : sizeof | mult | subtract | mod | add | divide | sum | rawstorage | score | INTNUM+ | var ;
INTNUM : [0-9] ;

namegr : (NAME)+? ;
NAME : [A-Z] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;
