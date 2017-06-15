﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using CardEngine;
using CardStockXam.CardEngine;

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
            Debug.WriteLine("Failure");
            throw new Exception("Object " + text + " could not be found");
        }
        public static void Put(string k, Object v){
            CardGame.Instance.vars[k] = v;
            //Debug.WriteLine("putting key " + k + " for " + v);
        }
        public static void Remove(string k){
            if (!CardGame.Instance.vars.ContainsKey(k)) {
                throw new KeyNotFoundException();
            }
            CardGame.Instance.vars.Remove(k);
        }
        public static FancyCardLocation ProcessCStorageFilter(RecycleParser.FilterContext filter)
        {
            var cList = new CardListCollection();
            FancyCardLocation stor;
            /*
            Debug.WriteLine(filter.GetText());
            Debug.WriteLine("parent:\n" + filter.Parent.GetText());
            Debug.WriteLine("parent's parent:\n" + filter.Parent.Parent.GetText());
            Debug.WriteLine("parent 3:\n" + filter.Parent.Parent.Parent.GetText());
            Debug.WriteLine("parent 4:\n" + filter.Parent.Parent.Parent.Parent.GetText());
            Debug.WriteLine("parent 5:\n" + filter.Parent.Parent.Parent.Parent.Parent.GetText());
            Debug.WriteLine("\n\n");*/
            IEnumerable<Card> stor2;
            String name2;

            if (filter.collection().cstorage() != null)
            {
                Debug.WriteLine("cstorage collection");
                stor = CardIterator.ProcessLocation(filter.collection().cstorage());
                stor2 = stor.cardList.AllCards();
                name2 = stor.name;
            }
            else if (filter.collection().var() != null)
            {
                Debug.WriteLine("variable collection");

                stor = Get(filter.collection().var()) as FancyCardLocation;
                if (stor != null)
                {
                    stor2 = stor.cardList.AllCards();

                    name2 = stor.name;
                }
                else
                {
                    stor2 = Get(filter.collection().var()) as List<Card>;
                    name2 = "blah";
                }
            }
            else
            {
                throw new NotSupportedException();
            }
            foreach (Card card in stor2)
            {
                Put(filter.var().GetText(), card);
                if (BooleanIterator.ProcessBoolean(filter.boolean()))
                {
                    cList.Add(card);
                }
                Remove(filter.var().GetText());
            }
            var fancy = new FancyCardLocation()
            {
                cardList = cList,
                nonPhysical = true,
                name = name2 + "{filter}"
            };
            fancy.cardList.loc = fancy;
            CardGame.AddToMap(fancy);
            return fancy;
        }
        // want to clean up & understand processagg TODO
        public static object ProcessAgg(RecycleParser.AggContext agg){
            return IterateAgg(agg, ProcessCollection(agg.collection()));
        }

        public static IEnumerable<object> ProcessCollection(RecycleParser.CollectionContext collection)
        {
          
            if (collection.var() != null){
				Console.WriteLine("Processing collection type: var.");
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
				Console.WriteLine("Processing collection type: Cstorage.");

				var stor = CardIterator.ProcessLocation(collection.cstorage());
                return stor.cardList.AllCards();
            }
            else if (collection.strcollection() != null)
            {
				Console.WriteLine("Processing collection type: string collection.");

				return ProcessStringCollection(collection.strcollection());
            }
            else if (collection.cstoragecollection() != null)
            {
				Console.WriteLine("Processing collection type: Cstorage collection.");

				return CardIterator.ProcessCStorageCollection(collection.cstoragecollection());
            }
            else if (collection.whot() != null)
            {
				Console.WriteLine("Processing collection type: whot.");

				return CardIterator.ProcessWhot(collection.whot()).teamPlayers;
            }
            else if (collection.range() != null)
            {
				Console.WriteLine("Processing collection type: range.");

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
				Console.WriteLine("Processing collection type: filter.");

				var filter = ProcessCStorageFilter(collection.filter());
                return filter.cardList.AllCards();
            }
            else if (collection.GetText() == "player")
            {
				Console.WriteLine("Processing collection type: players.");

				return CardGame.Instance.players;
            }
            else if (collection.GetText() == "team")
            {
				Console.WriteLine("Processing collection type: team.");

				return CardGame.Instance.teams;
            }
            else if (collection.other() != null)
            {
                return CardIterator.ProcessOther(collection.other());
            }
            else{//var
				Console.WriteLine("Processing collection type: var.");

				return (IEnumerable<object>) Get(collection.GetText());
            }
            throw new NotSupportedException();
        }

        private static object IterateAgg<T>(RecycleParser.AggContext agg, IEnumerable<T> stor){
            
            var ret = new List<object>();
            foreach (T t in stor)
            {
                Console.WriteLine("Iterating over aggregation of: " + t.GetType());
                Put(agg.var().GetText(), t);
                var post = ProcessAggPost(agg.GetChild(4));
                ret.Add(post);
                Remove(agg.var().GetText());
                // TODO never see these print statements???
                if (All(agg) && post is GameAction)
                {
					
					var act = post as GameAction;
                    Console.WriteLine("Executing game action: " + act.ToString());
                    act.ExecuteActual();
                }
                else if (post is GameActionCollection)
                {

                    foreach (GameAction act in (post as GameActionCollection))
                    {
						Console.WriteLine("Executing game action: " + act.ToString());
						act.ExecuteActual();
                    }
                }

                else { Debug.WriteLine("Unknown type "); }
                   // Debug.WriteLine(post.GetType()); }

            }
            // only difference is really in rawstorage & boolean
            Debug.WriteLine(ret.Count);
            // TODO - MULTIACTIONS & ACTIONS NEVER GET HERE... (any & all)
			// Multiaction2 & any actions are handled in processMultiaction & processAction respectively 
			if (All(agg)){
                //multiaction, action, etc
                // TODO - likely, these actions have already been processed - could just return "ret" (bc processed in actioniterator)
                if (agg.GetChild(4) is RecycleParser.ActionContext){
                    Console.WriteLine("Processing All + Action: " + ((RecycleParser.ActionContext)agg.GetChild(4)).GetText());

                    //var coll = new GameActionCollection();
                    //foreach (object obj in ret)
                    //{
                    //    var gameaction = obj as GameActionCollection;
                    //    coll.AddRange(gameaction);
                    //}
                    //return coll;
                    return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.Multiaction2Context){
                    Console.WriteLine("reached useless statement (all multiaction2)");


					return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.BooleanContext){
                    Console.WriteLine("Processing All + Boolean: " + (((RecycleParser.BooleanContext)agg.GetChild(4)).GetText()));
                    var all = true;
                    Debug.WriteLine(agg.GetText());
                    Debug.WriteLine("4: " + agg.GetChild(4).GetText());
                    foreach (object obj in ret){
                        Debug.WriteLine("i: " + obj.ToString());
                        all &= (bool) obj;
                    }
                    return all;
                }
                else if (agg.GetChild(4) is RecycleParser.CstorageContext){
                    Console.WriteLine("Processing All + Cstorage: " + (((RecycleParser.CstorageContext)agg.GetChild(4)).GetText()));
					var coll = new List<FancyCardLocation>();
                    foreach (object obj in ret){
                        coll.Add((FancyCardLocation)obj);
                    }
                    return coll;
                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext){
					Console.WriteLine("Processing All + Rawstorage: " + (((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText()));

					var sum = 0;
                    foreach (object obj in ret){
                        var raw = (FancyRawStorage) obj;
                        sum += raw.Get();
                    }
                    return sum;

                }
                Debug.WriteLine("End of loop");
            }
            else{ //any
              
                if (agg.GetChild(4) is RecycleParser.Multiaction2Context){//TODO 
                    Console.WriteLine("reached useless statement (any multiaction2)");
                    return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.ActionContext){
                    Console.WriteLine("reached useless statement (any action)");


					return ret;
                }
                else if (agg.GetChild(4) is RecycleParser.BooleanContext){
					Console.WriteLine("Processing Any + Boolean: " + (((RecycleParser.BooleanContext)agg.GetChild(4)).GetText()));

					var all = false;
                    foreach (object obj in ret)
                    {
                        all |= (bool)obj;
                    }
                    return all;
                }
                else if (agg.GetChild(4) is RecycleParser.CstorageContext){
					Console.WriteLine("Processing Any + Cstorage: " + (((RecycleParser.CstorageContext)agg.GetChild(4)).GetText()));

					var coll = new List<FancyCardLocation>();
                    foreach (object obj in ret)
                    {
                        coll.Add((FancyCardLocation)obj);
                    }
                    return coll;
                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext){
                    Console.WriteLine("Processing Any + Rawstorage: " + (((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText()));

					var lst = new List<int>();
                    foreach (object obj in ret)
                    {
                        var raw = (FancyRawStorage)obj;
                        lst.Add(raw.Get());
                    }
                    return lst;
                }
            }
        
			Debug.WriteLine(ret.Count);
            return ret;
        }

        private static object ProcessAggPost(IParseTree parseTree){
            if (parseTree is RecycleParser.Multiaction2Context){
                return (ICloneable) StageIterator.ProcessMultiaction(parseTree);
            }
            else if (parseTree is RecycleParser.ActionContext){
                Console.WriteLine("Processing action.");
                return ActionIterator.ProcessAction(parseTree as RecycleParser.ActionContext);
            }
            else if (parseTree is RecycleParser.BooleanContext){
                Console.WriteLine("Processing boolean.");
                return BooleanIterator.ProcessBoolean(parseTree as RecycleParser.BooleanContext);
            }
            else if (parseTree is RecycleParser.CstorageContext){
                Console.WriteLine("Finding card.");
                return CardIterator.ProcessLocation(parseTree as RecycleParser.CstorageContext);
            }
            else if (parseTree is RecycleParser.CondactContext){
                Console.WriteLine("Processing condition for conditional action(s).");
                ActionIterator.ProcessSingleDo(parseTree as RecycleParser.CondactContext);
			
                return null;
            }
            else if (parseTree is RecycleParser.RawstorageContext){
                return IntIterator.ProcessRawStorage(parseTree as RecycleParser.RawstorageContext);
            }
            Debug.WriteLine("error: Could not parse " + parseTree.GetText());
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
                Console.WriteLine("Processing type: int");
				return IntIterator.ProcessInt(typed.@int());
            }
            else if (typed.boolean() != null)
            {
				Console.WriteLine("Processing type: boolean");

				return BooleanIterator.ProcessBoolean(typed.boolean());
            }
            else if (typed.namegr() != null)
            {
				Console.WriteLine("Processing type: namegr");

				return typed.namegr().GetText();
            }
            else if (typed.var() != null)
            {
				Console.WriteLine("Processing type: var");

				return Get(typed.var());
            }
            else if (typed.collection() != null)
            {
				Console.WriteLine("Processing type: collection");

				return ProcessCollection(typed.collection());
            }
            throw new NotSupportedException();
        }

        public static List<GameActionCollection> ProcessLet(RecycleParser.LetContext let){
            var ret = new List<GameActionCollection>(); //TODO check this
            // maybe don't need ProcessTyped ? 
            Put(let.var().GetText(), ProcessTyped(let.typed()));
            if (let.multiaction() != null){
                Console.WriteLine("Processing let multiaction");
                ret.AddRange(StageIterator.ProcessMultiaction(let.multiaction()));
            }
            else if (let.action() != null){
                Console.WriteLine("Processing let action");
                ret.Add(ActionIterator.ProcessAction(let.action()));
            }
            else if (let.condact() != null){
                Console.WriteLine("Processing let conditional action " + let.condact().GetText());
                ActionIterator.ProcessSingleDo(let.condact());
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
            var newlst = text.Split(delimiter);
            return newlst;
        }

        public static int ProcessIntVar(RecycleParser.VarContext varContext){
            var temp = Get(varContext.GetText());
            if (temp is FancyRawStorage){
                var raw = temp as FancyRawStorage;
                return raw.Get();
            }
            else if (temp is int) { return (int)temp; }
            else { throw new Exception("Temp is " + temp.GetType()); }
        }

        public static FancyCardLocation ProcessCardVar(RecycleParser.VarContext card){ //TODO get card instead of just top card of location when ret is Card
            var ret = Get(card);
            if (ret is FancyCardLocation)
            {
                var loc = ret as FancyCardLocation;
                if (loc.locIdentifier != "-1")
                {
                    return loc.Clone();
                }
            }
            else if (ret is Card){
                var c = ret as Card;
                var loc = c.owner.loc.Clone();                
                loc.setLocId(c);
                return loc;
            }
            Debug.WriteLine("error, type is " + ret.GetType());
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
