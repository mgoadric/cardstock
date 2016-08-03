// Version 0.4 of our REcursive CYclic Card game LanguagE

grammar Recycle;

game : OPEN 'game' declare*? setup (multiaction|stage)+? scoring CLOSE ;
setup : OPEN 'setup' playercreate OPEN teamcreate CLOSE (OPEN (deckcreate | repeat) CLOSE)+? CLOSE ;
stage : OPEN 'stage' ('player'|'team') endcondition (multiaction | stage)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') int ;
endcondition : OPEN 'end' boolean CLOSE ;

action : OPEN (initpoints | teamcreate | deckcreate | cycleaction | setaction | moveaction | copyaction
         | incaction | decaction | removeaction | turnaction | shuffleaction | repeat) CLOSE | agg ;
multiaction : OPEN 'choice' OPEN (condact)+? CLOSE CLOSE | OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
multiaction2 : OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
condact : OPEN boolean multiaction2 CLOSE | multiaction2 | OPEN boolean action CLOSE | action ;

agg : OPEN ('any' | 'all') collection var (multiaction2 | action | boolean | cstorage | rawstorage) CLOSE ;
let : OPEN 'let' typed var (multiaction2 | action | condact) CLOSE ;
declare : OPEN 'declare' typed var CLOSE ;

playercreate : OPEN 'create' 'players' (int | var) CLOSE ;
teamcreate : 'create' 'teams' teams+? ;
deckcreate : 'create' 'deck' cstorage deck ;
deck : OPEN 'deck' attribute+? CLOSE ;
teams : OPEN (INTNUM ',')*? INTNUM teams*? CLOSE ;
attribute : var | OPEN (namegr ',')*? namegr attribute*? CLOSE ;

initpoints : 'put' 'points' var OPEN awards+? CLOSE ;
awards : OPEN subaward+? int CLOSE ;
subaward : OPEN namegr ((OPEN namegr CLOSE) | (cardatt)) CLOSE ;

cycleaction : 'cycle' ('next' | 'current') (owner | 'current' | 'next' | 'previous') ;

setaction : 'set' rawstorage int ;
incaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;

moveaction : 'move' card card ;
copyaction : 'remember' card card ;
removeaction : 'forget' card ;
shuffleaction : 'shuffle' cstorage ;
turnaction : 'turn' 'pass' ;
repeat : 'repeat' int action | 'repeat' 'all' moveaction ;


card : maxof | minof | var | actual | (OPEN ('top' | 'bottom' | int) cstorage CLOSE) ;
actual : OPEN 'actual' card CLOSE ;

rawstorage : OPEN ('game' | who | var) 'sto' (namegr | var) CLOSE ;
cstorage : unionof | filter | OPEN locpre locdesc (namegr | var) CLOSE | memstorage  | var;
memstorage :  OPEN ('top' | 'bottom' | int) memset CLOSE ;

memset : tuple ;
tuple : OPEN 'tuples' int cstorage 'using' var CLOSE ;
var : '\'' namegr ;

locpre : ('game' | whop | var) ;
locdesc : 'vloc'|'iloc'|'hloc'|'mem' ;
who : whot | whop ;
whop : OPEN whodesc 'player' CLOSE | owner ;
whot : OPEN whodesc 'team' CLOSE | teamp ;
whodesc : int | 'previous' | 'next' | 'current' ;
owner : OPEN 'owner' card CLOSE ;
teamp : OPEN 'team' whop CLOSE ;

other : OPEN 'other' ('player' | 'team') CLOSE ;

typed : int | boolean | namegr | var | collection ;
collection : cstorage | strcollection | cstoragecollection | 'player' | 'team'
             | whot | var | other | range | filter ;
strcollection : OPEN (namegr ',')*? namegr CLOSE ;
cstoragecollection : memset | agg | let ;
range : OPEN 'range' int '..' int CLOSE ;

filter : OPEN 'filter' collection var boolean CLOSE ;

attrcomp : EQOP cardatt cardatt ;
cardatt : namegr | var | (OPEN 'cardatt' (var | namegr) card CLOSE) ;

boolean : (OPEN ((BOOLOP boolean boolean+?) | (intop int int ) | attrcomp | (EQOP card card)
          | (UNOP boolean) | (EQOP whop whop) | (EQOP whot whot)) CLOSE) | agg ;
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

sizeof : OPEN 'size' (cstorage | memset | var) CLOSE ;
maxof : OPEN 'max' cstorage 'using' var CLOSE ;
minof : OPEN 'min' cstorage 'using' var CLOSE ;
unionof : OPEN 'union' (cstorage+? | agg) CLOSE ;
sum : OPEN 'sum' cstorage 'using' var CLOSE ;
score : OPEN 'score' card 'using' var CLOSE ;

int : sizeof | mult | subtract | mod | add | divide | sum | rawstorage | score | INTNUM+ | var ;
INTNUM : [0-9] ;

namegr : (LETT)+ ;
LETT : [A-Z] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;
