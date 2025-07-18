// Version 0.5.6 of our REcursive CYclic Card game LanguagE

// New in version 0.5.6
//  agg separated into action, boolean, cstorage, int

// New in version 0.5.5
//  revised the way variables are parsed, using type to distinguish
//  removed attrcomp and made it just a string comparison

// New in version 0.5.4
//  sizeof works for all collections, not just card collections

// New in version 0.5.3
//  var options for teamp and cycleaction

// New in version 0.5.2
//  cardatt is a type of str, instead of reverse
//  removing extraneous () from subawards in points

// New in version 0.5.1
//  subset operator makes all possible subsets

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

//  TODO store other player as a variable?
//  TODO make a graph for the locations? Only make explicit if needed?
//     would also need ways to talk about neighbors (left, right, up, down) grammar
//      or by index (0, 0), (1, 0), etc...
//  TODO stages with count of number of times to cycle, this would avoid the awkward
//     counters currently used
//  TODO a way to calculate runs in cards. Maybe like a partition? 
//       But do we want all possible sets?

grammar Recycle;
var : '\'' namegr ;
vars : '\'' namegr ;
varo : '\'' namegr ;
varp : '\'' namegr ;
vari : '\'' namegr ;
varb : '\'' namegr ;
varc : '\'' namegr ;
varcs : '\'' namegr ;
varcard : '\'' namegr ;

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

agg : OPEN ('any' | 'all') collection var condact CLOSE ;
aggb : OPEN ('any' | 'all') collection var boolean CLOSE ;
aggcs : OPEN 'all' collection var cstorage CLOSE ;
aggi : OPEN 'all' collection var rawstorage CLOSE ;
let : OPEN 'let' typed var (multiaction | action | condact) CLOSE ;
declare : OPEN 'declare' typed var CLOSE ;

playercreate : OPEN 'create' 'players' int CLOSE ;
teamcreate : OPEN 'create' 'teams' teams+? CLOSE;
deckcreate : 'create' 'deck' str? cstorage deck ;
deck : OPEN 'deck' attribute+? CLOSE ;
teams : OPEN (INTNUM ',')*? INTNUM teams*? CLOSE ;
attribute : OPEN (namegr ',')*? namegr attribute*? CLOSE ;

initpoints : 'set' pointstorage OPEN awards+? CLOSE ;
awards : OPEN subaward+? int CLOSE ;
subaward : OPEN str ':' str CLOSE ;

cycleaction : 'cycle' ('next' | 'current') (owner | 'current' | 'next' | 'previous' | varo ) ;

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

card : varcard | maxof | minof | actual | OPEN ('top' | 'bottom' | int ) cstorage CLOSE ;
actual : OPEN 'actual' card CLOSE ;

rawstorage : OPEN (varo | 'game' | who) 'sto' str CLOSE ;
pointstorage : OPEN (varo | 'game' | who) 'points' str CLOSE ;
strstorage : OPEN (varo | 'game' | who) 'str' str CLOSE ;
cstorage : varcs | unionof | intersectof | disjunctionof | sortof | filter | OPEN locpre locdesc str CLOSE | memstorage ;
memstorage :  OPEN ('top' | 'bottom' | int) memset CLOSE ;

memset : tuple | partition | subset ;
subset : OPEN 'subsets' cstorage CLOSE ;
tuple : OPEN 'tuples' int cstorage 'using' pointstorage CLOSE ;
partition : OPEN 'partition' (aggcs | cstorage+?) str CLOSE ;

locpre : ('game' | varp | whop) ;
locdesc : 'vloc'|'iloc'|'hloc'|'mem' ;
who : whot | whop ;
whop : OPEN whodesc 'player' CLOSE | owner ;
whot : OPEN whodesc 'team' CLOSE | teamp ;
whodesc : int | 'previous' | 'next' | 'current' ;
owner : OPEN 'owner' card CLOSE ;
teamp : OPEN 'team' (varp | whop) CLOSE ;

other : OPEN 'other' ('player' | 'team') CLOSE ;

typed : int | boolean | str | collection ;
collection : varc | filter | cstorage | strcollection | cstoragecollection | 'player' | 'team'
             | whot | other | range ;
strcollection : OPEN (namegr ',')*? namegr CLOSE ;
cstoragecollection : memset | aggcs | let ;
range : OPEN 'range' int '..' int CLOSE ;

filter : OPEN 'filter' collection var boolean CLOSE ;

cardatt : OPEN 'cardatt' str card CLOSE ;

boolean : OPEN (BOOLOP boolean boolean+? | intop int int | EQOP str str | EQOP card card
          | UNOP boolean | EQOP whop whop | EQOP whot whot) CLOSE | aggb ;
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

sizeof : OPEN 'size' collection CLOSE ;
maxof : OPEN 'max' cstorage 'using' pointstorage CLOSE ;
minof : OPEN 'min' cstorage 'using' pointstorage CLOSE ;
sortof : OPEN 'sort' cstorage 'using' pointstorage CLOSE ;
unionof : OPEN 'union' (aggcs | cstorage+?) CLOSE ;
intersectof : OPEN 'intersect' (aggcs | cstorage+?) CLOSE ;
disjunctionof : OPEN 'disjunction' (aggcs | cstorage+?) CLOSE ;

sum : OPEN 'sum' cstorage 'using' pointstorage CLOSE ;
score : OPEN 'score' card 'using' pointstorage CLOSE ;

int : vari | sizeof | mult | subtract | mod | add | divide | exponent | triangular | fibonacci | random | sum | rawstorage | score | INTNUM+ ;
INTNUM : [0-9] ;

str : namegr | strstorage | vars | cardatt ;
namegr : (LETT)+ ;
LETT : [A-Z] ;

OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;
