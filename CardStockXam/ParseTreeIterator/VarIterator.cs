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
        public static object Get(String text){
            if (CardGame.Instance.vars.ContainsKey(text))
            {
                return CardGame.Instance.vars[text];
            }
            else
            {
                Console.WriteLine("failed to find var " + text);
                return null;
            }
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
                nonPhysical = true
            };
        }

        public static object ProcessAgg(RecycleParser.AggContext agg){
            if (agg.collection().cstorage() != null){
                var stor = CardIterator.ProcessLocation(agg.collection().cstorage());
                return IterateAgg<Card>(agg, stor.cardList.AllCards());
            }
            else if (agg.collection().var() != null){
                var stor = Get(agg.collection().var()) as FancyCardLocation;
                return IterateAgg<Card>(agg, stor.cardList.AllCards());
            }
            else if (agg.collection().strcollection() != null){
                var lst = ProcessStringCollection(agg.collection().strcollection());
                return IterateAgg(agg, lst);
            }
            else if (agg.collection().cstoragecollection() != null){
                var colls = CardIterator.ProcessCStorageCollection(agg.collection().cstoragecollection());
                return IterateAgg(agg, colls);
            }
            else if (agg.collection().whot() != null){
                var team = CardIterator.ProcessWhot(agg.collection().whot());
                return IterateAgg(agg, team.teamPlayers);
            }
            else if (agg.collection().range() != null){
                var range = IntIterator.ProcessRange(agg.collection().range());
                return IterateAgg(agg, range);
            }
            else if (agg.collection().filter() != null){
                var filter = ProcessCStorageFilter(agg.collection().filter());
                return IterateAgg(agg, filter.cardList.AllCards());
            }
            else if (agg.collection().GetText() == "player"){
                return IterateAgg(agg, CardGame.Instance.players);
            }
            else if (agg.collection().GetText() == "team"){
                return IterateAgg(agg, CardGame.Instance.teams);
            }
            else if (agg.collection().other() != null){
                var other = CardIterator.ProcessOther(agg.collection().other());
                return IterateAgg(agg, other);
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
            }
            else{ //any
                //same ifs, different responses
            }
            return ret;
        }

        private static object ProcessAggPost(IParseTree parseTree){//TODO, return type?
            if (parseTree is RecycleParser.MultiactionContext){
                StageIterator.ProcessSubStage(parseTree);
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

        public static void ProcessLet(RecycleParser.LetContext let){
            Put(let.var().GetText(), let.typed());
            if (let.multiaction() != null){
                StageIterator.ProcessSubStage(let.multiaction());
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
            var temp = Get(varContext);
            var raw = temp as FancyRawStorage;
            if (raw != null){
                return raw.Get();
            }
            int num = Convert.ToInt32(temp);
            return num;
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

        internal static object Get(RecycleParser.VarContext varContext)
        {
            return Get(varContext.GetText());
        }
        public static bool All(RecycleParser.AggContext agg){
            return agg.boolean().GetText() == "all";
        }
    }
}
