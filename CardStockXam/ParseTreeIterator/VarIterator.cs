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
            var fancy = new FancyCardLocation
            {
                cardList = cList,
                nonPhysical = true,
                name = stor.name + "{filter}"
            };
            fancy.cardList.loc = fancy;
            return fancy;
        }

        public static object ProcessAgg(RecycleParser.AggContext agg){
            return IterateAgg(agg, ProcessCollection(agg.collection()));
        }

        public static IEnumerable<object> ProcessCollection(RecycleParser.CollectionContext collection)
        {
            Console.WriteLine(collection.GetText());
             if (collection.var() != null){
                var stor = Get(collection.var());
                if (stor is FancyCardLocation){
                    var card = stor as FancyCardLocation;
                    return card.cardList.AllCards();
                }
                if (stor is string[])
                {
                    return stor as string[];
                }
                if (stor is List<FancyCardLocation>)
                {
                    return stor as List<FancyCardLocation>;
                }
                if (stor is Team)
                {
                    var team = stor as Team;
                    return team.teamPlayers;
                }
                if (stor is List<int>)
                {
                    return stor as List<object>;
                }
            }
            if (collection.cstorage() != null)
            {
                var stor = CardIterator.ProcessLocation(collection.cstorage());
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
                    newlst.Add((object)num);
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
            else{//var
                Console.WriteLine(Get(collection.GetText()).GetType());
                return (IEnumerable<object>) Get(collection.GetText());
            }
            throw new NotSupportedException();
        }

        private static object IterateAgg<T>(RecycleParser.AggContext agg, IEnumerable<T> stor){
            var ret = new List<object>();
            foreach (T t in stor)
            {
                Put(agg.var().GetText(), t);
                var post = ProcessAggPost(agg.GetChild(4));
                ret.Add(post);
                Remove(agg.var().GetText());
                if (All(agg) && post is GameAction){
                    var act = post as GameAction;
                    act.ExecuteActual();
                }
                else if (post is GameActionCollection){
                    foreach (GameAction act in (post as GameActionCollection)){
                        act.ExecuteActual();
                    }
                }

            }
            if (All(agg)){
                //multiaction, action, etc
                if (agg.GetChild(4) is RecycleParser.ActionContext){
                    var coll = new GameActionCollection();
                    foreach (object obj in ret){
                        var gameaction = obj as GameActionCollection;
                        coll.AddRange(gameaction);
                    }
                    return coll;
                }
                if (agg.GetChild(4) is RecycleParser.Multiaction2Context){
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
                if (agg.GetChild(4) is RecycleParser.Multiaction2Context){//TODO
                    return ret;
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
                return StageIterator.ProcessMultiaction(parseTree);
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
                ActionIterator.DoAction(parseTree as RecycleParser.CondactContext);
                return null;
            }
            else if (parseTree is RecycleParser.RawstorageContext){
                return IntIterator.ProcessRawStorage(parseTree as RecycleParser.RawstorageContext);
            }
            Console.WriteLine("error: Could not parse " + parseTree.GetText());
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

        public static List<GameActionCollection> ProcessLet(RecycleParser.LetContext let){
            var ret = new List<GameActionCollection>();
            Put(let.var().GetText(), let.typed());
            if (let.multiaction() != null){
                ret.AddRange(StageIterator.ProcessMultiaction(let.multiaction()));
            }
            else if (let.action() != null){
                ret.Add(ActionIterator.ProcessAction(let.action()));
            }
            else if (let.condact() != null){
                ActionIterator.DoAction(let.condact());
            }
            Remove(let.var().GetText());
            return ret;
        }

        private static string[] ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            string text = strcollectionContext.GetText();
            char[] delimiter = { ',' };
            text = text.Replace("(", string.Empty) ;
            text = text.Replace(")", string.Empty) ;
            return text.Split(delimiter);
        }

        public static int ProcessIntVar(RecycleParser.VarContext varContext){
            var temp = Get(varContext.GetText());
            if (temp is FancyRawStorage){
                var raw = temp as FancyRawStorage;
                return raw.Get();
            }
            return (int) temp;
        }

        public static FancyCardLocation ProcessCardVar(RecycleParser.VarContext card){
            var ret = Get(card);
            Console.WriteLine(ret.GetType());
            if (ret is FancyCardLocation)
            {
                var loc = ret as FancyCardLocation;
                if (loc.locIdentifier != "-1")
                {
                    return loc;
                }
            }
            else if (ret is Card){
                var c = ret as Card;
                Console.WriteLine(c);
                return c.owner.loc;
            }
            Console.WriteLine("error, type is " + ret.GetType());
            return null;
        }
        public static string ProcessStringVar(RecycleParser.VarContext var)
        {
            return Get(var) as string;
        }
        public static bool All(RecycleParser.AggContext agg){
            return agg.GetChild(1).GetText() == "all";
        }
    }
}
