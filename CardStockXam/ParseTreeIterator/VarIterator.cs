using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine;

namespace ParseTreeIterator
{
    class VarIterator
    {
        public static object ProcessWhoVar(RecycleParser.VarContext varContext)
        {
            throw new NotImplementedException();//TODO
        }

        public static String ProcessStringVar(RecycleParser.VarContext var){
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
                stor = ProcessCardStorageVar(filter.collection().var());
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
                cardList = cList,
                locIdentifier = "-1"
            };
        }

        public static object ProcessAgg(RecycleParser.AggContext agg){ //TODO
            FancyCardLocation stor;
            List<String> strings;
            Team team;
            if (agg.collection().cstorage() != null){
                stor = CardIterator.ProcessLocation(agg.collection().cstorage());
            }
            else if (agg.collection().var() != null){
                stor = ProcessCardStorageVar(agg.collection().var());
            }
            else if (agg.collection().strcollection() != null){
                strings = ProcessStringCollection(agg.collection().strcollection());
            }
            else if (agg.collection().cstoragecollection() != null){
                //TODO  ???
            }
            else if (agg.collection().whot() != null){
                team = CardIterator.ProcessWhot(agg.collection().whot());
            }
            else if (agg.collection().other() != null){
                var other = agg.collection().other();
                
            }
            else if (agg.collection().range() != null){

            }
            else if (agg.collection().filter() != null){

            }
            else if (agg.collection().GetText() == "player"){

            }
            else if (agg.collection().GetText() == "team"){

            }
            else{
                throw new NotSupportedException();
            }
            if (stor != null){
                foreach (Card card in stor.cardList.AllCards()){
                    CardGame.Instance.vars[agg.var().GetText()] = card;
                }
            }
            if (agg.GetChild(1).GetText() == "all"){}
            else{ //any

            }
            return null;
        }

        private static List<string> ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            //TODO, iterate through text splitting on commas
            throw new NotImplementedException();
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
    }
}
