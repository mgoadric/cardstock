using CardEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreezeFrame
{
    class RecycleVariables
    {
        private Dictionary<String, object> vars; 

        public RecycleVariables()
        {
            vars = new Dictionary<string, object>();
        }

        public RecycleVariables Clone(CardGame cg)
        {
            var ret = new RecycleVariables();
            ret.vars = CloneDictionary(cg);
            return ret;
        }

        public object Get(RecycleParser.VarContext var)
        {
            return Get(var.GetText());
        }
        public object Get(String text)
        {
            if (vars.ContainsKey(text))
            {
                return vars[text];
            }
            throw new Exception("Object " + text + " could not be found");
        }
        public void Put(string k, Object v)
        {
            vars[k] = v;
        }
        public void Remove(string k)
        {
            if (!vars.ContainsKey(k))
            {
                throw new KeyNotFoundException();
            }
            vars.Remove(k);
        }

        public Dictionary<String, object> CloneDictionary(CardGame newgame)
        {

            Dictionary<String, object> ret = new Dictionary<String, object>();

            foreach (KeyValuePair<String, object> entry in vars)
            {
                var key = entry.Key;
                var o = entry.Value;
                if (o is int i) { ret.Add(key, i); }
                else if (o is bool b) { ret.Add(key, b); }
                else if (o is string s) { ret.Add(key, s); }
                else if (o is string[] sa)
                {
                    string[] str = (string[])sa.Clone();
                    ret.Add(key, str);
                }
                else if (o is Player p)
                {
                    ret.Add(key, newgame.players[p.id]);
                }
                else if (o is List<Player> lp)
                {
                    List<Player> newlist = new List<Player>();
                    foreach (Player player in lp)
                    {
                        int idx = player.id;
                        newlist.Add(newgame.players[idx]);
                    }
                    ret.Add(key, newlist);
                }
                else if (o is Team t)
                {
                    ret.Add(key, newgame.teams[t.id]);
                }
                else if (o is List<Team> lt) // NEED TO TEST
                {
                    List<Team> newlist = new List<Team>();
                    foreach (Team team in lt)
                    {
                        int idx = team.id;
                        newlist.Add(newgame.teams[idx]);
                    }
                    ret.Add(key, newlist);
                }

                else if (o is Card c)
                {
                    ret.Add(key, newgame.sourceDeck[c.id]);
                }
                else if (o is List<Card>)
                {
                    List<Card> l = new List<Card>();
                    foreach (Card card in o as List<Card>)
                    {
                        l.Add(newgame.sourceDeck[card.id]);
                    }
                    ret.Add(key, l);

                }
                else if (o is CardCollection cc) // NEED TO TEST XX
                {
                    string tempcc = cc.name;
                    CCType temptype = cc.type;

                    if (temptype == CCType.VIRTUAL)
                    {
                        CardCollection ccclone = cc.Clone();
                        foreach (Card oldc in cc.AllCards())
                        {
                            ccclone.Add(newgame.sourceDeck[oldc.id]);
                        }
                        ret.Add(key, ccclone);

                    }
                    else
                    {

                        CardStorage collectionowner = cc.owner;
                        Owner owner = collectionowner.owner;
                        int idx = owner.id;

                        Owner newowner;
                        if (owner as Player != null)
                        { newowner = newgame.players[owner.id]; }
                        else if (owner as Team != null)
                        { newowner = newgame.teams[owner.id]; }
                        else
                        {
                            if (idx == 0)
                            { newowner = newgame.table[0]; }
                            else { throw new Exception(); } // NOT IMPLEMENTED OTHER TYPES OF OWNER
                        }
                        ret.Add(key, newowner.cardBins[temptype][tempcc]);
                    }
                }
                /*else if (o is CardLocReference)
                {
                    throw new NotImplementedException();
                    var l = fancyCardLocMap[(o as CardLocReference).name];
                    ret.Add(key, l);
                }
                else if (o is IntStorageReference)
                {
                    throw new NotImplementedException();
                    var rs = FancyIntStorageMap[(o as IntStorageReference).key];
                    ret.Add(key, rs);
                }
                else if (o is GameActionCollection) //TODO what do i do here?
                {
                    throw new NotImplementedException();
                    Console.WriteLine("You're copying a GameActionCollection???");
                    var coll = o as GameActionCollection;
                    var newcoll = new GameActionCollection();
                    foreach (GameAction ac in coll)
                    {
                        newcoll.Add(ac);
                    }
                    ret.Add(key, newcoll);
                }*/
                
                else { Console.WriteLine("Error: object " + o + " is  type " + o.GetType()); throw new Exception(); }
            }
            /*Console.WriteLine("original:");
            foreach (object o in original){
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine(original.Count);
            Console.WriteLine("new:");
            foreach (object o in original){
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine(ret.Count);*/

            return ret;

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }

            RecycleVariables other = obj as RecycleVariables;
            if (other == null)
            { return false; }

            foreach (String key in vars.Keys)
            {
                var thistemp = vars[key];
                var othertemp = other.vars[key];
                if (thistemp is int i)
                { if (i != (int)othertemp) { Console.WriteLine("Ints not equal in vars"); return false; } }
                else if (thistemp is bool b)
                { if (b != (bool)othertemp) { Console.WriteLine("Bool not equal in vars"); return false; } }
                else if (thistemp is string s)
                { if (!s.Equals(othertemp as string)) { Console.WriteLine("String not equal in vars"); return false; } }
                else if (thistemp is String[] sa)
                { if (!sa.SequenceEqual(othertemp as String[])) { Console.WriteLine("String Arrays not equal in vars"); return false; } }
                else if (thistemp is Player p)
                { if (!p.Equals(othertemp as Player)) { Console.WriteLine("Player not equal in vars"); return false; } }
                else if (thistemp is List<Player> lp)
                { if (!lp.SequenceEqual(othertemp as List<Player>)) { Console.WriteLine("List Player not equal in vars"); return false; } }
                else if (thistemp is List<Team> lt)
                { if (!lt.SequenceEqual(othertemp as List<Team>)) { Console.WriteLine("List Team not equal in vars"); return false; } }
                else if (thistemp is Team t)
                { if (!t.Equals(othertemp as Team)) { Console.WriteLine("Team not equal in vars"); return false; } }
                else if (thistemp is Card c)
                { if (!c.Equals(othertemp as Card)) { Console.WriteLine("Card not equal in vars"); return false; } }
                else if (thistemp is List<Card> lc)
                { if (!lc.SequenceEqual(othertemp as List<Card>)) { Console.WriteLine("List Card not equal in vars"); return false; } }
                else if (thistemp is CardCollection cc)
                { if (!cc.Equals(othertemp as CardCollection)) { Console.WriteLine("CardCollection not equal in vars"); return false; } }
                else { throw new NotImplementedException(); }
            }


            // if (!other.vars.SequenceEqual(vars))
            //{  // UNFORTUNATELY NEED TO HARDCODE HOW TO DEAL WITH CERTAIN THINGS
            //return false; }

            return true;
        }
    }
}

/**Console.WriteLine("Vars don't equal:");
                Console.WriteLine("First mapping:");
                foreach (string key in vars.Keys)
                {
                    
                    if (vars[key].Equals(other.vars[key]))
                    { Console.WriteLine("this one is okay"); }
                    Console.WriteLine(key + " --> " + vars[key].ToString());
                    if (vars[key] is String[] s)
                    {
                        for (int i = 0; i<s.Length; i++)
                        {
                            if (!s[i].Equals((other.vars[key] as String[])[i]))
                                    { Console.WriteLine(s[i].ToString()); }
                        }
                    }
                }
                Console.WriteLine("Second mapping:");
                foreach (string key in other.vars.Keys)
                {
                    Console.WriteLine(key + " --> " + vars[key].ToString());
                }
    */