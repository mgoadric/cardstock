// Version 0.5.10 of our REcursive CYclic Card game LanguagE

// New in version 0.5.10
//  sequence to select the top or bottom x cards from a card collection
//  Runs for both the longest possible (revised from partitioned runs earlier) and all possible working
//  Largest Run that includes the top or bottom of a sequence is available

// New in version 0.5.9
//  Partitioned Runs are possible. The run will be the maximum size possible.
//   There should be no duplicates in the run possibilities.

// New in version 0.5.8
//  reworked partition to have string first, then collection, matching cardatt

// New in version 0.5.7
//  Remove mem locations
//  Removed the "remember" and "forget" actions
//  These can be replaced by string storage

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

//  TODO store other player as a storage variable?
//  TODO make a graph for the locations? Only make explicit if needed?
//     would also need ways to talk about neighbors (left, right, up, down) grammar
//      or by index (0, 0), (1, 0), etc...
//  TODO stages with count of number of times to cycle, this would avoid the awkward
//     counters currently used

grammar Recycle;

// Variables
var : '\'' namegr ;
vars : '\'' namegr ;
varo : '\'' namegr ;
varp : '\'' namegr ;
vari : '\'' namegr ;
varb : '\'' namegr ;
varc : '\'' namegr ;
varcs : '\'' namegr ;
varcard : '\'' namegr ;

// Game Setup
game : OPEN 'game' declare*? setup (multiaction | stage)+? scoring CLOSE ;
  declare : OPEN 'declare' typed var CLOSE ;
setup : OPEN 'setup' playercreate teamcreate? (OPEN (deckcreate | repeat) CLOSE)+? CLOSE ;
scoring : OPEN 'scoring' ('min' | 'max') int CLOSE ;

// Game Components
stage : OPEN 'stage' ('player' | 'team') endcondition (multiaction | stage)+? CLOSE ;
  endcondition : OPEN 'end' boolean CLOSE ;
multiaction : OPEN 'choice' OPEN (condact)+? CLOSE CLOSE | OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
multiaction2 : OPEN 'do' OPEN (condact)+? CLOSE CLOSE | agg | let ;
condact : OPEN boolean multiaction2 CLOSE | multiaction2 | OPEN boolean action CLOSE | action ;
agg : OPEN ('any' | 'all') collection var condact CLOSE ;
let : OPEN 'let' typed var (multiaction | action | condact) CLOSE ;

// Actions
action : OPEN (initpoints | teamcreate | deckcreate | cycleaction | setaction | moveaction | copyaction
         | incaction | setstraction | decaction | removeaction | turnaction | shuffleaction | repeat) CLOSE | agg ;
playercreate : OPEN 'create' 'players' int CLOSE ;
teamcreate : OPEN 'create' 'teams' teams+? CLOSE;
  teams : OPEN (INTNUM ',')*? INTNUM teams*? CLOSE ;
deckcreate : 'create' 'deck' str? cstorage deck ;
  deck : OPEN 'deck' attribute+? CLOSE ;
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
removeaction: 'forget' card ;
shuffleaction : 'shuffle' (cstorage | 'faro' cstorage cstorage) ;
turnaction : 'turn' 'pass' ;
repeat : 'repeat' int action | 'repeat' 'all' OPEN (moveaction | removeaction ) CLOSE ;

// Point Map
pointstorage : OPEN (varo | 'game' | who) 'points' str CLOSE ;

// Cards
card : varcard | maxof | minof | actual | OPEN ('top' | 'bottom' | int ) cstorage CLOSE ;
actual : OPEN 'actual' card CLOSE ;
maxof : OPEN 'max' cstorage 'using' pointstorage CLOSE ;
minof : OPEN 'min' cstorage 'using' pointstorage CLOSE ;

// Owners
locpre : 'game' | varp | whop ;
locdesc : 'vloc'|'iloc'|'hloc'|'oloc'|'mem' ;
who : whot | whop ;
whop : OPEN whodesc 'player' CLOSE | owner ;
whot : OPEN whodesc 'team' CLOSE | teamp ;
whodesc : int | 'previous' | 'next' | 'current' ;
owner : OPEN 'owner' card CLOSE ;
teamp : OPEN 'team' (varp | whop) CLOSE ;

// Things that can be variables in let or declare
typed : int | boolean | str | collection ;

// Collections
collection : varc | filter | cstorage | strcollection | cstoragecollection | 'player' | 'team'
             | whot | other | range ;
strcollection : OPEN (namegr ',')*? namegr CLOSE ;
range : OPEN 'range' int '..' int CLOSE ;
other : OPEN 'other' ('player' | 'team') CLOSE ;

// CardCollections
cstorage : varcs | unionof | intersectof | disjunctionof | sortof | filter | OPEN locpre locdesc (str | int | 'new') CLOSE | memstorage | sequence | runsequence ;
sortof : OPEN 'sort' cstorage 'using' pointstorage CLOSE ;
unionof : OPEN 'union' (aggcs | cstorage+?) CLOSE ;
intersectof : OPEN 'intersect' (aggcs | cstorage+?) CLOSE ;
disjunctionof : OPEN 'disjunction' (aggcs | cstorage+?) CLOSE ;
filter : OPEN 'filter' collection var boolean CLOSE ;
memstorage :  OPEN ('top' | 'bottom' | int) memset CLOSE ;
sequence: OPEN ('top' | 'bottom') int cstorage CLOSE ;
runsequence: OPEN 'run' ('top' | 'bottom') int cstorage 'using' pointstorage CLOSE;

// CardCollectionCollections
cstoragecollection : memset | aggcs | let ;
memset : tuple | partition | subset | run ;
run: OPEN 'runs' ('largest' | 'all') int cstorage 'using' pointstorage CLOSE ;
subset : OPEN 'subsets' cstorage CLOSE ; // add aggcs as in partition??
tuple : OPEN 'tuples' int cstorage 'using' pointstorage CLOSE ; // I want to remove this and replace with partition, errors though?
partition : OPEN 'partition' str (aggcs | cstorage+?) CLOSE ;
aggcs : OPEN 'all' collection var cstorage CLOSE ;

// Booleans
boolean : OPEN (BOOLOP boolean boolean+? | intop int int | EQOP str str | EQOP card card
          | UNOP boolean | EQOP whop whop | EQOP whot whot) CLOSE | aggb ;
BOOLOP : 'and' | 'or' ;
intop : COMPOP | EQOP ;
COMPOP : '<' | '>' | '>=' | '<=' ;
EQOP : '!=' | '==' ;
UNOP : 'not' ;
aggb : OPEN ('any' | 'all') collection var boolean CLOSE ;

// Integers
int : vari | sizeof | mult | subtract | mod | add | divide | exponent | triangular | fibonacci | random | sum | rawstorage | score | INTNUM+ ;
INTNUM : [0-9] ;
sum : OPEN 'sum' cstorage 'using' pointstorage CLOSE ;
score : OPEN 'score' card 'using' pointstorage CLOSE ;
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
aggi : OPEN 'all' collection var rawstorage CLOSE ;
rawstorage : OPEN (varo | 'game' | who) 'sto' str CLOSE ;

// Strings
str : namegr | strstorage | vars | cardatt ;
strstorage : OPEN (varo | 'game' | who) 'str' str CLOSE ;
cardatt : OPEN 'cardatt' str card CLOSE ;
namegr : (LETT)+ ;
LETT : [A-Z] ;

// Other syntax
OPEN : '(' ;
CLOSE : ')' ;
WS: [ \n\t\r]+ -> skip;
ANY : . ;
