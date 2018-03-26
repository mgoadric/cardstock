import random
import pythonds.basic.stack as Stack
import re
import string
from collections import defaultdict
import os
import copy


import subprocess
'''
notes:
got rid of putting points
not using attribute yet
should hardcode cardatts for right now
since they aren't being created programatically

removed team stuff

hardcode varinitpoints to be ''POINTS'

not using declare yet

typednamegr = grab any type of
var u have (just don't make a new one)

namegr removed b/c should be handling them the same
    -ie when you see varnamegr in a certain context,
    should be less & less likely to make a new one

varnamegr only should exist for when you have the
possibility of creating a new variable or not, which only
happens when accessing rawstorage / cstorage

strcollection is only thing with just namegr
because its literally a collection of strings

got rid of namegr option in typed bc whatever!!!!

to check for:
    cstoname & rawstoname: in whichever context, get less & less likely
        to make a new one
        once created, should be stored in respective
        area

    should only look for these, if not found go back
    up a level & don't come down again:
    varcstorage
    varinitpoints
    varwhop
    varcardatt (hardcoded (RANK, etc))
    varcstorage (encompasses locpre & locdesc & name)
    varint


let, agg, cstoname & rawstoname are only things that
can create variables

simple_recycle notes:

let - assign variable for int, player collection or card collection
    varint, varwhop, varcstorage
agg - create player or card collection
    varwhop, varcstorage

cstoname & rawname - same as above - gen strings if
dont exist, try to stick to same names if do exist


'''

# clean file, create new rules out of non-terminals
# to avoid infinite recursion
# https://en.wikipedia.org/wiki/Chomsky_normal_form

class Bunch():
    # source for this class >> http://code.activestate.com/recipes/52308-the-simple-but-handy-collector-of-a-bunch-of-named/?in=user-97991

    def __init__(self, **kwds):
        self.__dict__.update(kwds)

    def toString(self):
        toPrint = ""
        for k, v in self.__dict__.items():
            toPrint = toPrint + str(k) + ' ' + str(v) + ' | '
        return toPrint

class SymbolTable():
    def __init__(self):
        self.conStack = Stack.Stack()
        self.conStack.push("None")
        self.graph = defaultdict(list)
        self.cards = Stack.Stack()
        # need context for

            # strcollection
            # cardatt
            # rawstorage
            # cstorage
            # attribute (RANK, etc is what this is)

        self.stack = Stack.Stack()
        newDict = defaultdict(list)
        self.stack.push(newDict)
        self.current = self.stack.peek()

    def start_scope(self):
        # type defaultdict
        d = self.stack.peek()
        newCurrent = defaultdict(list)
        for k in d.keys():
            newCurrent[k] = d.get(k)
        self.stack.push(newCurrent)
        self.current = self.stack.peek()

    def end_scope(self):
        self.stack.pop()
        self.current = self.stack.peek()


class Generate():

    def __init__(self):
        self.table = SymbolTable()
        self.prod = defaultdict(list)
        self.pcount = defaultdict(int)
        self.cstrings = ["A", "B", "C"]
        self.table.graph["( top ( game vloc A ) )"] = ["( top ( ( current player ) vloc B ) )"]
        self.rawstrings = ["POINTS"]
        self.cfactor = .2
        self.tabs = 0
        self.endconditions = ["( end ( all player 'P ( == ( size ( 'P vloc B)) 0)))", "( end ( == ( size ( game vloc A ) 0)))",
                              "( end ( all player 'P ( > ( size ( 'P vloc C )) 0)))"]


    def gen_random(self, symbol):

        sentence = ''
        rand_prod = ''
        type = ''

        weights = []

        for prod in self.prod[symbol + '_']:
            # if a var doesn't exist, set its weight to 0
            if prod[0] in ["varwhop", "varcard", "varint"]:
                if prod[0] not in self.table.current.keys():
                    weights.append(0.0)
                elif prod in self.pcount:
                    weights.append(self.cfactor ** (self.pcount[prod]))
                else:
                    weights.append(1.0)
            elif prod in self.pcount:
                weights.append(self.cfactor ** (self.pcount[prod]))
            else:
                weights.append(1.0)
        rand_prod = self.prod[symbol + '_'][weighted_choice(weights)]

        if len(rand_prod) == 1 and rand_prod[0] in ["varwhop", "varcard", "varint"]:

            if rand_prod[0] in self.table.current.keys():


                rand_prod = random.choice(self.table.current[rand_prod[0]])
                sentence += rand_prod

                return sentence



        self.pcount[rand_prod] += 1
        # if in let context & see typed - add it to let context on stack
        # then if you're in let context and see var -- pull type from

        # same with agg. pop them off at end of their time in loop



        for sym in rand_prod:


            if symbol in ["typed", "collection"] and sym != "collection":
                self.table.conStack.push(sym.replace("\'", ""))
            if sym == "OPEN":
                sentence += "\n"
                sentence += ("\t" * self.tabs)
                self.tabs += 1
                self.table.start_scope()
            elif sym == "CLOSE":

                self.tabs -= 1
                self.table.end_scope()


            if sym == "var":
                myType = self.table.conStack.pop()
                if myType == "player":
                    myType = "varwhop"
                elif myType == "int":
                    myType = "varint"
                elif myType == "cstorage":
                    myType = "varcard"
                var = self.create_var(myType)
                self.table.current[myType].append(var)
                sentence += var

            elif sym + "_" in self.prod:

                sen = self.gen_random(sym)
                # picks up full name of card 4 graph stuff
                if symbol == 'moveaction' and sym == 'card':
                    self.table.cards.push(sen.replace('\t', '').replace('\n', ''))
                else:
                    sentence += sen
            elif sym in ["cstoname", "rawname"]:
                var = self.gen_string(sym)
                sentence += var
            elif sym == 'lambda':
                pass
            else:
                sym = sym.replace("'", "")
                sentence += str(sym) + ' '



        '''if (symbol == 'moveaction'):
            print("this " + sentence.strip("\n"))
            self.table.cards.push(sentence.join('\n'))
        '''
        # generate graph
        # chance to add new connection
        # most of time, re-enforce old connection
        # by adding another random instance
        # of an already existing connection
        if symbol == 'moveaction':
            # add A and B to graph at beginning
            # don't allow to pick a v1 that isn't already in the graph

            # for presentation:
            #   here is the graph i will get (just draw it)
                # talk about properties
                # talk about algorithm
                # how are names / moves generated? trying to match things we see in real games
                # compare rules vs actual movements in games
            v2 = self.table.cards.pop()
            v1 = self.table.cards.pop()
            if not v1 in self.table.graph.keys():
                v1 = random.choice(list(self.table.graph.keys()))
            i = random.randint(0, 2 * len(self.table.graph[v1]))
            if i == 0:
                self.table.graph[v1].append(v2)
            else:
                v2 = random.choice(self.table.graph[v1])
                self.table.graph[v1].append(v2)
            if v2 not in self.table.graph.keys():
                self.table.graph[v2] = []
            sentence += v1 + v2
            #print(v1 + " -> " + v2)

        if symbol == 'endcondition':
            print(sentence)
        self.pcount[rand_prod] -= 1
        # return type based on symbol

        return sentence


    def create_var(self, type):
        # store value assoc with variables so that its
        # stack of dicts of lists of pairs (var, value)
        rand_str = ''
        for i in range(5):
            rand_str += random.choice(string.ascii_uppercase)
        while rand_str in self.table.current[type]:
            rand_str = ''
            for i in range(5):
                rand_str += random.choice(string.ascii_uppercase)
        return "'" + rand_str + " "



    def gen_string(self, sym):
        rand_str = ''
        stringfrom = []
        if sym == "cstoname":

            # just sticking w basic rn
            return random.choice(self.cstrings) + " "
            #stringfrom = self.cstrings
        elif sym == "rawname":
            # just basic rn
            return random.choice(self.rawstrings) + " "
            #stringfrom = self.rawstrings
        if len(stringfrom) == 0:
            i = 0
        else:
            i = random.randrange(0, len(stringfrom))
        if i == 0:
            for i in range(5):
                rand_str += random.choice(string.ascii_uppercase)
            stringfrom.append(rand_str)
        else:
            rand_str = random.choice(stringfrom)

        return rand_str + " "


    def add_prod(self, lhs, rhs):
        """ Add production to the grammar. 'rhs' can
            be several productions separated by '|'.
            Each production is a sequence of symbols
            separated by whitespace.

            Usage:
                grammar.add_prod('NT', 'VP PP')
                grammar.add_prod('Digit', '1|2|3|4')
        """
        prods = rhs.split('|')
        for prod in prods:
            self.prod[lhs].append(tuple(prod.split()))



def weighted_choice(weights):
    rnd = random.random() * sum(weights)
    for i, w in enumerate(weights):
        rnd -= w
        if rnd < 0:
            return i




def parseFile(f):
    keyValues = []
    file = open(f).read()
    rulecount = 1
    s = file.split(';')
    keyValues = []
    for i, line in enumerate(s):
        if s[i] != '':
            newline = line
            name = re.search(".*?:", newline)
            sentence = re.search(":.*", newline)

            # one or more
            if bool(re.search("\(([^)]*)\)\+\?", newline)):
                matches = re.findall("\(([^)]*)\)\+\?", newline)
                for newrule in matches:
                    newname = "rule" + str(rulecount)
                    rulecount += 1
                    newname2 = "rule" + str(rulecount)
                    rulecount += 1
                    tempsentence = newline.replace("("+newrule+")+?", newname2)
                    keyValues.append([newname2 + '_', newname + " | " + newname + " " + newname2 + " "])
                    keyValues.append([newname + '_', newrule])
                    sentence = re.search(":.*", tempsentence)
                    newline = tempsentence

            # zero or more
            if bool(re.search("\(([^)]*)\)\*\?", newline)):
                matches = re.findall("\(([^)]*)\)\*\?", newline)
                for newrule in matches:
                    newname = "rule" + str(rulecount)
                    rulecount += 1
                    newname2 = "rule" + str(rulecount)
                    rulecount += 1
                    tempsentence = newline.replace("("+newrule+")*?", newname2)
                    keyValues.append([newname2 + '_', "lambda | " + newname + " " + newname2 + " "])
                    keyValues.append([newname + '_', newrule])
                    sentence = re.search(":.*", tempsentence)
                    newline = tempsentence

            # regular parenthesis
            if bool(re.search("\(([^)]*)\)", newline)):
                matches = re.findall("\(([^)]*)\)", newline)
                for newrule in matches:
                    newname = "rule" + str(rulecount)
                    rulecount += 1
                    tempsentence = newline.replace("("+newrule+")", newname)

                    sentence = re.search(":.*", tempsentence)
                    keyValues.append([newname + '_', newrule])
                    newline = tempsentence
            # TODO handle +?, *?, + in single words



            if name and sentence:
                keyValues.append([name.group(0)[:-2] + '_', sentence.group(0)[2:]])
    return keyValues

def control_generate():
    n = 0
    for i in range(103):
        recycle = Generate()

        f = parseFile('simple_recycle')
        for line in f:
            recycle.add_prod(str(line[0]), str(line[1]))
        base = open('base').read()
        scoring = open('scoring').read()
        result = recycle.gen_random('stage')

        toWrite = open('/Users/anna/Desktop/cardstock/CardStockXam/games/generated/Gen_' + str(i) + '.gdl', 'w')
        #toWrite2 = open('test', 'w')
        #typesWrite = open('types', 'w')
        for line2 in base:
            toWrite.write(line2)
        #    toWrite2.write(line2)

        #s = re.split(r"(\(.*?\))", result)
        for line in result:
            toWrite.write(line)
        #    toWrite2.write(line)
        toWrite.write("\n")
        #toWrite2.write("\n")
        for line3 in scoring:
            toWrite.write(line3)
        #    toWrite2.write(line3)
        i += 1
        output = subprocess.call(['/Library/Frameworks/Mono.framework/Versions/5.0.1/bin/mono32',
                                  '/Users/anna/Desktop/cardstock/CardStockXam/bin/Release/CardStockXam.exe',
                                  '/Users/anna/Desktop/cardstock/CardStockXam/games/generated/' + 'Gen_' + str(i) + ".gdl"])
        print(output)


# eventually will be able to:
# generate game in sections,
# score each time a new section is added
# only save highest scoring to build on next game section

def control_vs():
    output = subprocess.call(['/Library/Frameworks/Mono.framework/Versions/5.0.1/bin/mono32',
                              '/Users/anna/Desktop/cardstock/CardStockXam/bin/Release/CardStockXam.exe',
                              '/Users/anna/Desktop/cardstock/CardStockXam/games/Agram.gdl'])
    print(output)
    # generate 10 games
    # score all games
    # only keep highest-scoring game




control_generate()
#control_vs()