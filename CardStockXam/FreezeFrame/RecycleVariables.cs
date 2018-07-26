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
        public Dictionary<string, Card> fancyCardMap = new Dictionary<string, Card>();
        public Dictionary<string, CardLocReference> fancyCardLocMap = new Dictionary<string, CardLocReference>();
        public Dictionary<string, IntStorageReference> FancyIntStorageMap = new Dictionary<string, IntStorageReference>();

        public RecycleVariables()
        {
            vars = new Dictionary<string, object>();
        }

        public RecycleVariables Clone(CardGame cg)
        {
            var ret = new RecycleVariables();
            ret.vars = CloneDictionary(cg);
            return ret;
        } // TODO

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
            // Console.WriteLine("putting key " + k + " for " + v);
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
            //TODO:
            //remove all non-primitive copies
            //use hashtables (name/hashcode/whatever -> object)

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
                else if (o is Team t)
                {
                    ret.Add(key, newgame.teams[t.id]);
                }

                else if (o is Card c)
                 {
                     var idx = newgame.cardIdxs[c];
                     ret.Add(key, newgame.sourceDeck[idx]);
                 }
                else if (o is CardLocReference)
                {
                    var l = fancyCardLocMap[(o as CardLocReference).name];
                    ret.Add(key, l);
                }
                else if (o is IntStorageReference)
                {
                    var rs = FancyIntStorageMap[(o as IntStorageReference).key];
                    ret.Add(key, rs);
                }
                else if (o is GameActionCollection) //TODO what do i do here?
                {
                    Console.WriteLine("You're copying a GameActionCollection???");
                    var coll = o as GameActionCollection;
                    var newcoll = new GameActionCollection();
                    foreach (GameAction ac in coll)
                    {
                        newcoll.Add(ac);
                    }
                    ret.Add(key, newcoll);
                }
    
                else if (o is List<Card>)
                {
                    List<Card> l = new List<Card>();
                    foreach (Card card in o as List<Card>)
                    {
                        var idx = newgame.cardIdxs[card];
                        l.Add(newgame.sourceDeck[idx]);
                    }
                    ret.Add(key, l);

                }
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

        public void AddToMap(object o)
        {
            IDictionary dict = null;
            string id = "";
            if (o is CardLocReference)
            {
                dict = fancyCardLocMap;
                id = (o as CardLocReference).name;
            }
            else if (o is IntStorageReference)
            {
                dict = FancyIntStorageMap;
                id = (o as IntStorageReference).GetName();
                //Console.WriteLine(id);
            }
            else { Console.WriteLine("unknown type in AddToMap: " + o.GetType()); }
            if (!dict.Contains(id)) { dict.Add(id, o); }
            //else { Console.WriteLine("dict already contains " + id); }
        }
    }
}
