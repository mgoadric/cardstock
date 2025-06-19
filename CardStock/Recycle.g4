// Version 0.5.1 of our REcursive CYclic Card game LanguagE

// New in version 0.5.1
//  subset operator makes all possible subsets
//  TODO store other player as a variable?
//  TODO make a graph for the locations? Only make explicit if needed?
//     would also need ways to talk about neighbors (left, right, up, down) grammar
//      or by index (0, 0), (1, 0), etc...

// New in version 0.5
//  abstracted namegr into str for strings
//  teamcreate is default one per team, those not mentioned put on separate team
//  string storage for team, player, game
//  points for team, player, game
//  partition for card storages by name
//  set operations intersect and disjunction
//  exponent, triangular, and fibonacci numbers
//  random number (0-?) or (?-?) with ? inclusive
//  change range to be inclusive

grammar Recycle;
var : '\'' namegr ;
game : OPEN 'game' declare*? setup (multiaction | stage)+? scoring CLOSE ;
setup : OPEN 'setup' playercreate teamcreate? (OPEN (deckcreate | repeat) CLOSE)+? CLOSE ;
stage : OPEN 'stage' ('player' | 'team') endcondition (multiaction | stage)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') int CLOSE ;
endcondition : OPEN 'end' boolean CLOSE ;

action : OPEN (initpoints | teamcreate | deckcreate | cycleaction | setaction | moveaction | copyaction
         | incaction | setstraction | decaction | removeaction | turnaction | shuffleaction | repeat) CLOSE | agg ;
multiaction : OPEN 'choice' OPEN (condact)+? CLOSE CLOSE | OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
multiaction2 : OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
condact : OPEN boolean multiaction2 CLOSE | multiaction2 | OPEN boolean action CLOSE | action ;

agg : OPEN ('any' | 'all') collection var (condact | boolean | cstorage | rawstorage) CLOSE ;
let : OPEN 'let' typed var (multiaction | action | condact) CLOSE ;
declare : OPEN 'declare' typed var CLOSE ;

playercreate : OPEN 'create' 'players' (var | int) CLOSE ;
teamcreate : OPEN 'create' 'teams' teams+? CLOSE;
deckcreate : 'create' 'deck' str? cstorage deck ;
deck : OPEN 'deck' attribute+? CLOSE ;
teams : OPEN (INTNUM ',')*? INTNUM teams*? CLOSE ;
attribute : OPEN var CLOSE | OPEN (namegr ',')*? namegr attribute*? CLOSE ;

initpoints : 'set' pointstorage OPEN awards+? CLOSE ;
awards : OPEN subaward+? int CLOSE ;
subaward : OPEN str (OPEN str CLOSE | cardatt) CLOSE ;

cycleaction : 'cycle' ('next' | 'current') (owner | 'current' | 'next' | 'previous') ;

setaction : 'set' rawstorage int ;
setstraction : 'set' strstorage str ;
incaction : 'inc' rawstorage int ;
decaction : 'dec' rawstorage int ;

moveaction : 'move' card card ;
copyaction : 'remember' card card ;
removeaction : 'forget' card ;
shuffleaction : 'shuffle' cstorage ;
turnaction : 'turn' 'pass' ;
repeat : 'repeat' int action | 'repeat' 'all' OPEN moveaction CLOSE ;

card : var | maxof | minof | actual | OPEN ('top' | 'bottom' | int) cstorage CLOSE ;
actual : OPEN 'actual' card CLOSE ;

rawstorage : OPEN (var | 'game' | who) 'sto' str CLOSE ;
pointstorage : OPEN (var | 'game' | who) 'points' str CLOSE ;
strstorage : OPEN (var | 'game' | who) 'str' str CLOSE ;
cstorage : var | unionof | intersectof | disjunctionof | sortof | filter | OPEN locpre locdesc str CLOSE | memstorage ;
memstorage :  OPEN ('top' | 'bottom' | int) memset CLOSE ;

memset : tuple | partition | subset ;
subset : OPEN 'subsets' cstorage CLOSE ;
tuple : OPEN 'tuples' int cstorage 'using' pointstorage CLOSE ;
partition : OPEN 'partition' (agg | cstorage+?) str CLOSE ;

locpre : (var | 'game' | whop) ;
locdesc : 'vloc'|'iloc'|'hloc'|'mem' ;
who : whot | whop ;
whop : OPEN whodesc 'player' CLOSE | owner ;
whot : OPEN whodesc 'team' CLOSE | teamp ;
whodesc : int | 'previous' | 'next' | 'current' ;
owner : OPEN 'owner' card CLOSE ;
teamp : OPEN 'team' whop CLOSE ;

other : OPEN 'other' ('player' | 'team') CLOSE ;

typed : var | int | boolean | str | collection ;
collection : var | cstorage | strcollection | cstoragecollection | 'player' | 'team'
             | whot | other | range | filter ;
strcollection : OPEN (namegr ',')*? namegr CLOSE ;
cstoragecollection : memset | agg | let ;
range : OPEN 'range' int '..' int CLOSE ;

filter : OPEN 'filter' collection var boolean CLOSE ;

attrcomp : EQOP cardatt cardatt ;
cardatt : str | OPEN 'cardatt' str card CLOSE ;

boolean : OPEN (BOOLOP boolean boolean+? | intop int int  | attrcomp | EQOP card card
          | UNOP boolean | EQOP whop whop | EQOP whot whot) CLOSE | agg ;
BOOLOP : 'and' | 'or' ;
intop : COMPOP | EQOP ;
COMPOP : '<' | '>' | '>=' | '<=' ;
EQOP : '!=' | '==' ;
UNOP : 'not' ;

add : OPEN '+' int int CLOSE ;
mult : OPEN '*' int int CLOSE ;
subtract : OPEN '-' int int CLOSE ;
mod : OPEN '%' int int CLOSE ;
divide : OPEN '//' int int CLOSE ;
exponent : OPEN '^' int int CLOSE ;
triangular : OPEN 'tri' int CLOSE ;
fibonacci : OPEN 'fib' int CLOSE ;
random : OPEN 'random' int ('..' int)? CLOSE ;

sizeof : OPEN 'size' (var | cstorage | memset) CLOSE ;
maxof : OPEN 'max' cstorage 'using' pointstorage CLOSE ;
minof : OPEN 'min' cstorage 'using' pointstorage CLOSE ;
sortof : OPEN 'sort' cstorage 'using' pointstorage CLOSE ;
unionof : OPEN 'union' (agg | cstorage+?) CLOSE ;
intersectof : OPEN 'intersect' (agg | cstorage+?) CLOSE ;
disjunctionof : OPEN 'disjunction' (agg | cstorage+?) CLOSE ;

sum : OPEN 'sum' cstorage 'using' pointstorage CLOSE ;
score : OPEN 'score' card 'using' pointstorage CLOSE ;

int : var | sizeof | mult | subtract | mod | add | divide | exponent | triangular | fibonacci | random | sum | rawstorage | score | INTNUM+ ;
INTNUM : [0-9] ;

str : namegr | strstorage | var ;
namegr : (LETT)+ ;
LETT : [A-Z] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;
