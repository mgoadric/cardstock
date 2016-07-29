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
        public static string ProcessStringVar(RecycleParser.VarContext var){
            return Get(var) as string;
        }

        public static FancyCardLocation ProcessCardStorageVar(RecycleParser.VarContext varcontext)
        {
            throw new NotImplementedException();
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
                CardGame.Instance.vars[filter.var().GetText()] = card;
                if (BooleanIterator.ProcessBoolean(filter.boolean())){
                    cList.Add(card);
                }

                CardGame.Instance.vars.Remove(filter.var().GetText());
            }
            return new FancyCardLocation
            {
                cardList = cList
            };
        }

        public static object ProcessAgg(RecycleParser.AggContext agg){ //TODO
            if (agg.collection().cstorage() != null){
                var stor = CardIterator.ProcessLocation(agg.collection().cstorage());
                return IterateAgg<Card>(agg, stor.cardList.AllCards());
            }
            else if (agg.collection().var() != null){
                var stor = Get(agg.collection().var()) as FancyCardLocation;
                return IterateAgg<Card>(agg, stor.cardList.AllCards());
            }
            else if (agg.collection().strcollection() != null){//TODO check
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
            if (agg.GetChild(1).GetText() == "all"){}
            else{ //any

            }
            return null;
        }

        private static object IterateAgg<T>(RecycleParser.AggContext agg, IEnumerable<T> stor){
            var ret = new List<Object>();
            if (All(agg))
            {
                foreach (T t in stor)
                {
                    CardGame.Instance.vars[agg.var().GetText()] = t;
                    ret.Add(ProcessAggPost(agg.GetChild(4)));
                    CardGame.Instance.vars.Remove(agg.var().GetText());
                }
            }
            else
            { //any
                foreach (T t in stor)
                {
                    CardGame.Instance.vars[agg.var().GetText()] = t;
                    ret.Add(ProcessAggPost(agg.GetChild(4)));
                    CardGame.Instance.vars.Remove(agg.var().GetText());
                }
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



        private static string[] ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            //TODO, iterate through text splitting on commas
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

        internal static List<Node> ProcessAttrVar(RecycleParser.AttributeContext attr)
        {
            throw new NotImplementedException();
        }

        internal static FancyCardLocation ProcessCardVar(RecycleParser.VarContext card)
        {
            throw new NotImplementedException();
        }

        internal static object Get(RecycleParser.VarContext varContext)
        {
            return Get(varContext.GetText());
        }
        public static object Get(String text){
            if (CardGame.Instance.vars.ContainsKey(text)) {
                return CardGame.Instance.vars[text];
            }
            else{
                Console.WriteLine("failed to find var " + text);
                return null;
            }
        }

        public static bool All(RecycleParser.AggContext agg){
            return agg.boolean().GetText() == "all";
        }
    }
}
