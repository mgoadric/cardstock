using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
    class VarIterator
    {
        public static object Get(RecycleParser.VarContext var){
            return Get(var.GetText());
        }
        public static object Get(String text){
            if (CardGame.Instance.vars.ContainsKey(text)){
                return CardGame.Instance.vars[text];
            }
            return null;
        }
        public static void Put(string k, Object v){
            CardGame.Instance.vars[k] = v;
        }
        public static void Remove(string k){
            CardGame.Instance.vars.Remove(k);
        }
        public static FancyCardLocation ProcessCStorageFilter(RecycleParser.FilterContext filter){
            var cList = new CardListCollection();
            FancyCardLocation stor;
            if (filter.collection().cstorage() != null){
                stor = CardIterator.ProcessLocation(filter.collection().cstorage());
            }
            else if (filter.collection().var() != null){
                stor = Get(filter.collection().var()) as FancyCardLocation;
            }
            else{
                throw new NotSupportedException();
            }
            foreach (Card card in stor.cardList.AllCards())
            {
                Put(filter.var().GetText(), card);
                if (BooleanIterator.ProcessBoolean(filter.boolean())){
                    cList.Add(card);
                }

                Remove(filter.var().GetText());
            }
            return new FancyCardLocation
            {
                cardList = cList,
                nonPhysical = true,
                name = stor.name + "{filter}"
            };
        }

        public static object ProcessAgg(RecycleParser.AggContext agg){
            return IterateAgg(agg, ProcessCollection(agg.collection()));
        }

        private static IEnumerable<object> ProcessCollection(RecycleParser.CollectionContext collection){
            if (collection.cstorage() != null)
            {
                var stor = CardIterator.ProcessLocation(collection.cstorage());
                return stor.cardList.AllCards();
            }
            else if (collection.var() != null)
            {
                var stor = Get(collection.var()) as FancyCardLocation;
                return stor.cardList.AllCards();
            }
            else if (collection.strcollection() != null)
            {
                return ProcessStringCollection(collection.strcollection());
            }
            else if (collection.cstoragecollection() != null)
            {
                return CardIterator.ProcessCStorageCollection(collection.cstoragecollection());
            }
            else if (collection.whot() != null)
            {
                return CardIterator.ProcessWhot(collection.whot()).teamPlayers;
            }
            else if (collection.range() != null)
            {
                var lst = IntIterator.ProcessRange(collection.range());
                List<object> newlst = new List<object>();
                foreach (int num in lst)
                {
                    newlst.Add((object) num);
                }
                return newlst;
            }
            else if (collection.filter() != null)
            {
                var filter = ProcessCStorageFilter(collection.filter());
                return filter.cardList.AllCards();
            }
            else if (collection.GetText() == "player")
            {
                return CardGame.Instance.players;
            }
            else if (collection.GetText() == "team")
            {
                return CardGame.Instance.teams;
            }
            else if (collection.other() != null)
            {
                return CardIterator.ProcessOther(collection.other());
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static object IterateAgg<T>(RecycleParser.AggContext agg, IEnumerable<T> stor){
            var ret = new List<object>();
            foreach (T t in stor)
            {
                Put(agg.var().GetText(), t);
                ret.Add(ProcessAggPost(agg.GetChild(4)));
                Remove(agg.var().GetText());

            }
            if (All(agg)){
                //multiaction, action, etc
                if (agg.GetChild(4) is RecycleParser.MultiactionContext){//TODO
                    //??? no return value
                }
                else if (agg.GetChild(4) is RecycleParser.ActionContext){
                    return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.BooleanContext){
                    var all = true;
                    foreach (object obj in ret){
                        all &= (bool) obj;
                    }
                    return all;
                }
                else if (agg.GetChild(4) is RecycleParser.CstorageContext){
                    var coll = new List<FancyCardLocation>();
                    foreach (object obj in ret){
                        coll.Add((FancyCardLocation)obj);
                    }
                    return coll;
                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext){
                    var sum = 0;
                    foreach (object obj in ret){
                        var raw = (FancyRawStorage) obj;
                        sum += raw.Get();
                    }
                    return sum;
                }
            }
            else{ //any
                  //same ifs, different responses
                if (agg.GetChild(4) is RecycleParser.MultiactionContext){//TODO
                    //???
                }
                else if (agg.GetChild(4) is RecycleParser.ActionContext){
                    return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.BooleanContext){
                    var all = false;
                    foreach (object obj in ret)
                    {
                        all |= (bool)obj;
                    }
                    return all;
                }
                else if (agg.GetChild(4) is RecycleParser.CstorageContext){
                    var coll = new List<FancyCardLocation>();
                    foreach (object obj in ret)
                    {
                        coll.Add((FancyCardLocation)obj);
                    }
                    return coll;
                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext){
                    var lst = new List<int>();
                    foreach (object obj in ret)
                    {
                        var raw = (FancyRawStorage)obj;
                        lst.Add(raw.Get());
                    }
                    return lst;
                }
            }
            return ret;
        }

        private static object ProcessAggPost(IParseTree parseTree){
            if (parseTree is RecycleParser.Multiaction2Context){
                StageIterator.ProcessMultiaction(parseTree);
                return null;
            }
            else if (parseTree is RecycleParser.ActionContext){
                return ActionIterator.ProcessAction(parseTree as RecycleParser.ActionContext);
            }
            else if (parseTree is RecycleParser.BooleanContext){
                return BooleanIterator.ProcessBoolean(parseTree as RecycleParser.BooleanContext);
            }
            else if (parseTree is RecycleParser.CstorageContext){
                return CardIterator.ProcessLocation(parseTree as RecycleParser.CstorageContext);
            }
            else if (parseTree is RecycleParser.CondactContext){
                return ActionIterator.DoAction(parseTree as RecycleParser.CondactContext);
            }
            else if (parseTree is RecycleParser.RawstorageContext){
                return IntIterator.ProcessRawStorage(parseTree as RecycleParser.RawstorageContext);
            }
            throw new NotSupportedException();
        }

        public static void ProcessDeclare(RecycleParser.DeclareContext declare)
        {
            Put(declare.var().GetText(), ProcessTyped(declare.typed()));
        }

        public static object ProcessTyped(RecycleParser.TypedContext typed)
        {
            if (typed.@int() != null)
            {
                return IntIterator.ProcessInt(typed.@int());
            }
            else if (typed.boolean() != null)
            {
                return BooleanIterator.ProcessBoolean(typed.boolean());
            }
            else if (typed.namegr() != null)
            {
                return typed.namegr().GetText();
            }
            else if (typed.var() != null)
            {
                return Get(typed.var());
            }
            else if (typed.collection() != null)
            {
                return ProcessCollection(typed.collection());
            }
            throw new NotSupportedException();
        }

        public static void ProcessLet(RecycleParser.LetContext let){
            Put(let.var().GetText(), let.typed());
            if (let.multiaction2() != null){
                StageIterator.ProcessMultiaction(let.multiaction2());
            }
            else if (let.action() != null){
                ActionIterator.ProcessAction(let.action());
            }
            else if (let.condact() != null){
                ActionIterator.DoAction(let.condact());
            }
            Remove(let.var().GetText());
        }

        private static string[] ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            string text = strcollectionContext.GetText();
            char[] delimiter = { ',' };
            return text.Split(delimiter);
        }

        internal static int ProcessIntVar(RecycleParser.VarContext varContext)
        {
            var temp = Get(varContext.GetText());
            if (temp is FancyRawStorage){
                var raw = temp as FancyRawStorage;
                return raw.Get();
            }
            Console.WriteLine(varContext.GetText());
            Console.WriteLine(temp);
            return (int) temp;
        }

        internal static List<Node> ProcessAttrVar(RecycleParser.VarContext attr)
        {
            return Get(attr) as List<Node>;
        }

        public static FancyCardLocation ProcessCardVar(RecycleParser.VarContext card)
        {
            var ret = Get(card) as FancyCardLocation;
            if (ret.locIdentifier != "-1"){
                return ret;
            }
            return null;
        }
        public static FancyCardLocation ProcessLocVar(RecycleParser.VarContext card)
        {
            var ret = Get(card) as FancyCardLocation;
            if (ret.locIdentifier == "-1")
            {
                return ret;
            }
            return null;
        }
        public static string ProcessStringVar(RecycleParser.VarContext var)
        {
            return Get(var) as string;
        }
        public static bool All(RecycleParser.AggContext agg){
            return agg.boolean().GetText() == "all";
        }
    }
}
