# http://eli.thegreenplace.net/2010/01/28/generating-random-sentences-from-a-context-free-grammar/
import random
import re

# TODO doesn't generate dict entry for each option, only
# first option
# strings are randomly chosen from A-E
# nums randomly chosen from 0-5
# items that can have 1+ instances or 0+ instances
# instead occur once (recursion into teams was deleted)
# make new key for multiple instances of things like condact, etc
#
# to have option to make as many as u want, generate
# a new self-referential rule with the options (Null | thisRule)
# so that it could potentially create as many as needed but not
# more so
#

# make 52 card deck, 2 players on own team

import collections

class CFG(object):
    def __init__(self):
        self.prod = collections.defaultdict(list)

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


# the simple but bad version
    def gen_random(self, symbol):
        """ Generate a random sentence from the
            grammar, starting with the given
            symbol.
        """
        sentence = ''

        # select one production of this symbol randomly
        rand_prod = random.choice(self.prod[symbol])

        for sym in rand_prod:
            # for non-terminals, recurse
            if sym in self.prod:
                sentence += self.gen_random(sym)
            else:
                sentence += sym + ' '

        return sentence



    def gen_random_convergent(self,
                              symbol,
                              cfactor=0.05,
                              pcount=collections.defaultdict(int)
                              ):
        """ Generate a random sentence from the
            grammar, starting with the given symbol.

            Uses a convergent algorithm - productions
            that have already appeared in the
            derivation on each branch have a smaller
            chance to be selected.

            cfactor - controls how tight the
            convergence is. 0 < cfactor < 1.0

            pcount is used internally by the
            recursive calls to pass on the
            productions that have been used in the
            branch.
        """
        sentence = ''

        # The possible productions of this symbol are weighted
        # by their appearance in the branch that has led to this
        # symbol in the derivation
        #
        weights = []
        for prod in self.prod[symbol]:
            if prod in pcount:
                weights.append(cfactor ** (pcount[prod]))
            else:
                weights.append(1.0)
        rand_prod = self.prod[symbol][weighted_choice(weights)]

        # pcount is a single object (created in the first call to
        # this method) that's being passed around into recursive
        # calls to count how many times productions have been
        # used.
        # Before recursive calls the count is updated, and after
        # the sentence for this call is ready, it is rolled-back
        # to avoid modifying the parent's pcount.
        #
        pcount[rand_prod] += 1

        for sym in rand_prod:
            # for non-terminals, recurse
            if sym in self.prod:
                sentence += self.gen_random_convergent(
                    sym,
                    cfactor=cfactor,
                    pcount=pcount)
            else:
                sentence += sym + ' '

        # backtracking: clear the modification to pcount
        pcount[rand_prod] -= 1
        return sentence


def weighted_choice(weights):
    rnd = random.random() * sum(weights)
    for i, w in enumerate(weights):
        rnd -= w
        if rnd < 0:
            return i

def parseFile(f):
    keyValues = []
    file = open(f).read()
    s = file.split(';')

    for i, line in enumerate(s):
        if s[i] != '':
            s[i] = s[i].strip().split(" ")
            key = ""
            value = ""
            inPar = False
            inFirst = False
            replacement = ""
            for j, word in enumerate(s[i]):

                wordCopy = word
                wordCopy = wordCopy.replace('+?', '')
                wordCopy = wordCopy.replace('*?', '')
                if wordCopy == '|':
                    inFirst = False
                if inPar and not inFirst:
                    if wordCopy.endswith(')'):
                        inPar = False
                        inFirst = False
                else:
                    if wordCopy.startswith('\'') or wordCopy.endswith('\''):
                        if i == 0:
                            wordCopy = '\''
                        else:
                            wordCopy = wordCopy.replace('\'', '')
                    else:
                        wordCopy = wordCopy.upper()
                    if wordCopy.startswith('(') and wordCopy.endswith(')'):
                        wordCopy = wordCopy.replace('(', '')
                        wordCopy = wordCopy.replace(')', '')
                    elif wordCopy.startswith('(') and wordCopy != '(':
                        wordCopy = wordCopy.replace('(', '')
                        inPar = True
                        inFirst = True
                    elif wordCopy.endswith(')') and wordCopy != ')':
                        wordCopy = wordCopy.replace(')', '')
                    replacement += wordCopy + " "


            s[i] = replacement
            split = s[i].split(' : ')
            if len(split) == 2:
                key = split[0]
                value = split[1]
            keyValues.append([key, value])
    return keyValues

# needed to generate good games:
#   randomly get string/num
#   when accessing var, only select from
#   vars generated already


def main():
    recycle = CFG()
    #file = input("input: ")
    l = parseFile('/Users/anna/Desktop/recycleforparsing')
    toWrite = open('generated.gdl', 'w')
    for line in l:
        print(line[0], line[1])
        recycle.add_prod(line[0], line[1])

    result = recycle.gen_random_convergent('GAME')


    s = re.split(r"(\( [A-Za-z]+)", result)
    for line in s:
        toWrite.write(line + '\n')


    '''
    grammar = [
        ['VAR', '\' NAMEGR'],
        ['GAME', '( game DECLARE SETUP MULTIACTION SCORING ) |'
                 '( game SETUP STAGE SCORING )'],
        ['SETUP', '( setup PLAYERCREATE ( TEAMCREATE ) ( DECKCREATE ) )'],
        ['STAGE', '( stage player ENDCONDITION MULTIACTION )'],
        ['SCORING', '( scoring min INT )'],
        ['ENDCONDITION', '( end BOOLEAN )'],
        ['DECLARE', '( declare VAR )'],
        ['PLAYERCREATE', '( create players VAR ) | (create players INT )'],
        ['BOOLEAN', 'true | false'],
        ['INT', 'INTNUM'],
        ['NAMEGR', 'A|B|C|D|E'],
        ['INTNUM', '0|1|2|3|4|5|6|7|8|9'],
        ['MULTIACTION', '( choice ( condact ) )'],
    ]

    recycle = CFG()

    for item in grammar:
        recycle.add_prod(item[0], item[1])

    for i in range(10):
        print(recycle.gen_random('GAME'))
    '''
main()



