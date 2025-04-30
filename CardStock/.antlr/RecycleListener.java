// Generated from /Users/goadrich/Github/cardstock/CardStock/Recycle.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link RecycleParser}.
 */
public interface RecycleListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link RecycleParser#var}.
	 * @param ctx the parse tree
	 */
	void enterVar(RecycleParser.VarContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#var}.
	 * @param ctx the parse tree
	 */
	void exitVar(RecycleParser.VarContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#game}.
	 * @param ctx the parse tree
	 */
	void enterGame(RecycleParser.GameContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#game}.
	 * @param ctx the parse tree
	 */
	void exitGame(RecycleParser.GameContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#setup}.
	 * @param ctx the parse tree
	 */
	void enterSetup(RecycleParser.SetupContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#setup}.
	 * @param ctx the parse tree
	 */
	void exitSetup(RecycleParser.SetupContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#stage}.
	 * @param ctx the parse tree
	 */
	void enterStage(RecycleParser.StageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#stage}.
	 * @param ctx the parse tree
	 */
	void exitStage(RecycleParser.StageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#scoring}.
	 * @param ctx the parse tree
	 */
	void enterScoring(RecycleParser.ScoringContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#scoring}.
	 * @param ctx the parse tree
	 */
	void exitScoring(RecycleParser.ScoringContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#endcondition}.
	 * @param ctx the parse tree
	 */
	void enterEndcondition(RecycleParser.EndconditionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#endcondition}.
	 * @param ctx the parse tree
	 */
	void exitEndcondition(RecycleParser.EndconditionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#action}.
	 * @param ctx the parse tree
	 */
	void enterAction(RecycleParser.ActionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#action}.
	 * @param ctx the parse tree
	 */
	void exitAction(RecycleParser.ActionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#multiaction}.
	 * @param ctx the parse tree
	 */
	void enterMultiaction(RecycleParser.MultiactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#multiaction}.
	 * @param ctx the parse tree
	 */
	void exitMultiaction(RecycleParser.MultiactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#multiaction2}.
	 * @param ctx the parse tree
	 */
	void enterMultiaction2(RecycleParser.Multiaction2Context ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#multiaction2}.
	 * @param ctx the parse tree
	 */
	void exitMultiaction2(RecycleParser.Multiaction2Context ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#condact}.
	 * @param ctx the parse tree
	 */
	void enterCondact(RecycleParser.CondactContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#condact}.
	 * @param ctx the parse tree
	 */
	void exitCondact(RecycleParser.CondactContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#agg}.
	 * @param ctx the parse tree
	 */
	void enterAgg(RecycleParser.AggContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#agg}.
	 * @param ctx the parse tree
	 */
	void exitAgg(RecycleParser.AggContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#let}.
	 * @param ctx the parse tree
	 */
	void enterLet(RecycleParser.LetContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#let}.
	 * @param ctx the parse tree
	 */
	void exitLet(RecycleParser.LetContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#declare}.
	 * @param ctx the parse tree
	 */
	void enterDeclare(RecycleParser.DeclareContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#declare}.
	 * @param ctx the parse tree
	 */
	void exitDeclare(RecycleParser.DeclareContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#playercreate}.
	 * @param ctx the parse tree
	 */
	void enterPlayercreate(RecycleParser.PlayercreateContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#playercreate}.
	 * @param ctx the parse tree
	 */
	void exitPlayercreate(RecycleParser.PlayercreateContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#teamcreate}.
	 * @param ctx the parse tree
	 */
	void enterTeamcreate(RecycleParser.TeamcreateContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#teamcreate}.
	 * @param ctx the parse tree
	 */
	void exitTeamcreate(RecycleParser.TeamcreateContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#deckcreate}.
	 * @param ctx the parse tree
	 */
	void enterDeckcreate(RecycleParser.DeckcreateContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#deckcreate}.
	 * @param ctx the parse tree
	 */
	void exitDeckcreate(RecycleParser.DeckcreateContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#deck}.
	 * @param ctx the parse tree
	 */
	void enterDeck(RecycleParser.DeckContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#deck}.
	 * @param ctx the parse tree
	 */
	void exitDeck(RecycleParser.DeckContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#teams}.
	 * @param ctx the parse tree
	 */
	void enterTeams(RecycleParser.TeamsContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#teams}.
	 * @param ctx the parse tree
	 */
	void exitTeams(RecycleParser.TeamsContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(RecycleParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(RecycleParser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#initpoints}.
	 * @param ctx the parse tree
	 */
	void enterInitpoints(RecycleParser.InitpointsContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#initpoints}.
	 * @param ctx the parse tree
	 */
	void exitInitpoints(RecycleParser.InitpointsContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#awards}.
	 * @param ctx the parse tree
	 */
	void enterAwards(RecycleParser.AwardsContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#awards}.
	 * @param ctx the parse tree
	 */
	void exitAwards(RecycleParser.AwardsContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#subaward}.
	 * @param ctx the parse tree
	 */
	void enterSubaward(RecycleParser.SubawardContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#subaward}.
	 * @param ctx the parse tree
	 */
	void exitSubaward(RecycleParser.SubawardContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#cycleaction}.
	 * @param ctx the parse tree
	 */
	void enterCycleaction(RecycleParser.CycleactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#cycleaction}.
	 * @param ctx the parse tree
	 */
	void exitCycleaction(RecycleParser.CycleactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#setaction}.
	 * @param ctx the parse tree
	 */
	void enterSetaction(RecycleParser.SetactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#setaction}.
	 * @param ctx the parse tree
	 */
	void exitSetaction(RecycleParser.SetactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#setstraction}.
	 * @param ctx the parse tree
	 */
	void enterSetstraction(RecycleParser.SetstractionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#setstraction}.
	 * @param ctx the parse tree
	 */
	void exitSetstraction(RecycleParser.SetstractionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#incaction}.
	 * @param ctx the parse tree
	 */
	void enterIncaction(RecycleParser.IncactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#incaction}.
	 * @param ctx the parse tree
	 */
	void exitIncaction(RecycleParser.IncactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#decaction}.
	 * @param ctx the parse tree
	 */
	void enterDecaction(RecycleParser.DecactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#decaction}.
	 * @param ctx the parse tree
	 */
	void exitDecaction(RecycleParser.DecactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#moveaction}.
	 * @param ctx the parse tree
	 */
	void enterMoveaction(RecycleParser.MoveactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#moveaction}.
	 * @param ctx the parse tree
	 */
	void exitMoveaction(RecycleParser.MoveactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#copyaction}.
	 * @param ctx the parse tree
	 */
	void enterCopyaction(RecycleParser.CopyactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#copyaction}.
	 * @param ctx the parse tree
	 */
	void exitCopyaction(RecycleParser.CopyactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#removeaction}.
	 * @param ctx the parse tree
	 */
	void enterRemoveaction(RecycleParser.RemoveactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#removeaction}.
	 * @param ctx the parse tree
	 */
	void exitRemoveaction(RecycleParser.RemoveactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#shuffleaction}.
	 * @param ctx the parse tree
	 */
	void enterShuffleaction(RecycleParser.ShuffleactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#shuffleaction}.
	 * @param ctx the parse tree
	 */
	void exitShuffleaction(RecycleParser.ShuffleactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#turnaction}.
	 * @param ctx the parse tree
	 */
	void enterTurnaction(RecycleParser.TurnactionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#turnaction}.
	 * @param ctx the parse tree
	 */
	void exitTurnaction(RecycleParser.TurnactionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#repeat}.
	 * @param ctx the parse tree
	 */
	void enterRepeat(RecycleParser.RepeatContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#repeat}.
	 * @param ctx the parse tree
	 */
	void exitRepeat(RecycleParser.RepeatContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#card}.
	 * @param ctx the parse tree
	 */
	void enterCard(RecycleParser.CardContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#card}.
	 * @param ctx the parse tree
	 */
	void exitCard(RecycleParser.CardContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#actual}.
	 * @param ctx the parse tree
	 */
	void enterActual(RecycleParser.ActualContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#actual}.
	 * @param ctx the parse tree
	 */
	void exitActual(RecycleParser.ActualContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#rawstorage}.
	 * @param ctx the parse tree
	 */
	void enterRawstorage(RecycleParser.RawstorageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#rawstorage}.
	 * @param ctx the parse tree
	 */
	void exitRawstorage(RecycleParser.RawstorageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#pointstorage}.
	 * @param ctx the parse tree
	 */
	void enterPointstorage(RecycleParser.PointstorageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#pointstorage}.
	 * @param ctx the parse tree
	 */
	void exitPointstorage(RecycleParser.PointstorageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#strstorage}.
	 * @param ctx the parse tree
	 */
	void enterStrstorage(RecycleParser.StrstorageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#strstorage}.
	 * @param ctx the parse tree
	 */
	void exitStrstorage(RecycleParser.StrstorageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#cstorage}.
	 * @param ctx the parse tree
	 */
	void enterCstorage(RecycleParser.CstorageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#cstorage}.
	 * @param ctx the parse tree
	 */
	void exitCstorage(RecycleParser.CstorageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#memstorage}.
	 * @param ctx the parse tree
	 */
	void enterMemstorage(RecycleParser.MemstorageContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#memstorage}.
	 * @param ctx the parse tree
	 */
	void exitMemstorage(RecycleParser.MemstorageContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#memset}.
	 * @param ctx the parse tree
	 */
	void enterMemset(RecycleParser.MemsetContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#memset}.
	 * @param ctx the parse tree
	 */
	void exitMemset(RecycleParser.MemsetContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#tuple}.
	 * @param ctx the parse tree
	 */
	void enterTuple(RecycleParser.TupleContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#tuple}.
	 * @param ctx the parse tree
	 */
	void exitTuple(RecycleParser.TupleContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#partition}.
	 * @param ctx the parse tree
	 */
	void enterPartition(RecycleParser.PartitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#partition}.
	 * @param ctx the parse tree
	 */
	void exitPartition(RecycleParser.PartitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#locpre}.
	 * @param ctx the parse tree
	 */
	void enterLocpre(RecycleParser.LocpreContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#locpre}.
	 * @param ctx the parse tree
	 */
	void exitLocpre(RecycleParser.LocpreContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#locdesc}.
	 * @param ctx the parse tree
	 */
	void enterLocdesc(RecycleParser.LocdescContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#locdesc}.
	 * @param ctx the parse tree
	 */
	void exitLocdesc(RecycleParser.LocdescContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#who}.
	 * @param ctx the parse tree
	 */
	void enterWho(RecycleParser.WhoContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#who}.
	 * @param ctx the parse tree
	 */
	void exitWho(RecycleParser.WhoContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#whop}.
	 * @param ctx the parse tree
	 */
	void enterWhop(RecycleParser.WhopContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#whop}.
	 * @param ctx the parse tree
	 */
	void exitWhop(RecycleParser.WhopContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#whot}.
	 * @param ctx the parse tree
	 */
	void enterWhot(RecycleParser.WhotContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#whot}.
	 * @param ctx the parse tree
	 */
	void exitWhot(RecycleParser.WhotContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#whodesc}.
	 * @param ctx the parse tree
	 */
	void enterWhodesc(RecycleParser.WhodescContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#whodesc}.
	 * @param ctx the parse tree
	 */
	void exitWhodesc(RecycleParser.WhodescContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#owner}.
	 * @param ctx the parse tree
	 */
	void enterOwner(RecycleParser.OwnerContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#owner}.
	 * @param ctx the parse tree
	 */
	void exitOwner(RecycleParser.OwnerContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#teamp}.
	 * @param ctx the parse tree
	 */
	void enterTeamp(RecycleParser.TeampContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#teamp}.
	 * @param ctx the parse tree
	 */
	void exitTeamp(RecycleParser.TeampContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#other}.
	 * @param ctx the parse tree
	 */
	void enterOther(RecycleParser.OtherContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#other}.
	 * @param ctx the parse tree
	 */
	void exitOther(RecycleParser.OtherContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#typed}.
	 * @param ctx the parse tree
	 */
	void enterTyped(RecycleParser.TypedContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#typed}.
	 * @param ctx the parse tree
	 */
	void exitTyped(RecycleParser.TypedContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#collection}.
	 * @param ctx the parse tree
	 */
	void enterCollection(RecycleParser.CollectionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#collection}.
	 * @param ctx the parse tree
	 */
	void exitCollection(RecycleParser.CollectionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#strcollection}.
	 * @param ctx the parse tree
	 */
	void enterStrcollection(RecycleParser.StrcollectionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#strcollection}.
	 * @param ctx the parse tree
	 */
	void exitStrcollection(RecycleParser.StrcollectionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#cstoragecollection}.
	 * @param ctx the parse tree
	 */
	void enterCstoragecollection(RecycleParser.CstoragecollectionContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#cstoragecollection}.
	 * @param ctx the parse tree
	 */
	void exitCstoragecollection(RecycleParser.CstoragecollectionContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#range}.
	 * @param ctx the parse tree
	 */
	void enterRange(RecycleParser.RangeContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#range}.
	 * @param ctx the parse tree
	 */
	void exitRange(RecycleParser.RangeContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#filter}.
	 * @param ctx the parse tree
	 */
	void enterFilter(RecycleParser.FilterContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#filter}.
	 * @param ctx the parse tree
	 */
	void exitFilter(RecycleParser.FilterContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#attrcomp}.
	 * @param ctx the parse tree
	 */
	void enterAttrcomp(RecycleParser.AttrcompContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#attrcomp}.
	 * @param ctx the parse tree
	 */
	void exitAttrcomp(RecycleParser.AttrcompContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#cardatt}.
	 * @param ctx the parse tree
	 */
	void enterCardatt(RecycleParser.CardattContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#cardatt}.
	 * @param ctx the parse tree
	 */
	void exitCardatt(RecycleParser.CardattContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#boolean}.
	 * @param ctx the parse tree
	 */
	void enterBoolean(RecycleParser.BooleanContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#boolean}.
	 * @param ctx the parse tree
	 */
	void exitBoolean(RecycleParser.BooleanContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#intop}.
	 * @param ctx the parse tree
	 */
	void enterIntop(RecycleParser.IntopContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#intop}.
	 * @param ctx the parse tree
	 */
	void exitIntop(RecycleParser.IntopContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#add}.
	 * @param ctx the parse tree
	 */
	void enterAdd(RecycleParser.AddContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#add}.
	 * @param ctx the parse tree
	 */
	void exitAdd(RecycleParser.AddContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#mult}.
	 * @param ctx the parse tree
	 */
	void enterMult(RecycleParser.MultContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#mult}.
	 * @param ctx the parse tree
	 */
	void exitMult(RecycleParser.MultContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#subtract}.
	 * @param ctx the parse tree
	 */
	void enterSubtract(RecycleParser.SubtractContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#subtract}.
	 * @param ctx the parse tree
	 */
	void exitSubtract(RecycleParser.SubtractContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#mod}.
	 * @param ctx the parse tree
	 */
	void enterMod(RecycleParser.ModContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#mod}.
	 * @param ctx the parse tree
	 */
	void exitMod(RecycleParser.ModContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#divide}.
	 * @param ctx the parse tree
	 */
	void enterDivide(RecycleParser.DivideContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#divide}.
	 * @param ctx the parse tree
	 */
	void exitDivide(RecycleParser.DivideContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#exponent}.
	 * @param ctx the parse tree
	 */
	void enterExponent(RecycleParser.ExponentContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#exponent}.
	 * @param ctx the parse tree
	 */
	void exitExponent(RecycleParser.ExponentContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#triangular}.
	 * @param ctx the parse tree
	 */
	void enterTriangular(RecycleParser.TriangularContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#triangular}.
	 * @param ctx the parse tree
	 */
	void exitTriangular(RecycleParser.TriangularContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#fibonacci}.
	 * @param ctx the parse tree
	 */
	void enterFibonacci(RecycleParser.FibonacciContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#fibonacci}.
	 * @param ctx the parse tree
	 */
	void exitFibonacci(RecycleParser.FibonacciContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#random}.
	 * @param ctx the parse tree
	 */
	void enterRandom(RecycleParser.RandomContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#random}.
	 * @param ctx the parse tree
	 */
	void exitRandom(RecycleParser.RandomContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#sizeof}.
	 * @param ctx the parse tree
	 */
	void enterSizeof(RecycleParser.SizeofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#sizeof}.
	 * @param ctx the parse tree
	 */
	void exitSizeof(RecycleParser.SizeofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#maxof}.
	 * @param ctx the parse tree
	 */
	void enterMaxof(RecycleParser.MaxofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#maxof}.
	 * @param ctx the parse tree
	 */
	void exitMaxof(RecycleParser.MaxofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#minof}.
	 * @param ctx the parse tree
	 */
	void enterMinof(RecycleParser.MinofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#minof}.
	 * @param ctx the parse tree
	 */
	void exitMinof(RecycleParser.MinofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#sortof}.
	 * @param ctx the parse tree
	 */
	void enterSortof(RecycleParser.SortofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#sortof}.
	 * @param ctx the parse tree
	 */
	void exitSortof(RecycleParser.SortofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#unionof}.
	 * @param ctx the parse tree
	 */
	void enterUnionof(RecycleParser.UnionofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#unionof}.
	 * @param ctx the parse tree
	 */
	void exitUnionof(RecycleParser.UnionofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#intersectof}.
	 * @param ctx the parse tree
	 */
	void enterIntersectof(RecycleParser.IntersectofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#intersectof}.
	 * @param ctx the parse tree
	 */
	void exitIntersectof(RecycleParser.IntersectofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#disjunctionof}.
	 * @param ctx the parse tree
	 */
	void enterDisjunctionof(RecycleParser.DisjunctionofContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#disjunctionof}.
	 * @param ctx the parse tree
	 */
	void exitDisjunctionof(RecycleParser.DisjunctionofContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#sum}.
	 * @param ctx the parse tree
	 */
	void enterSum(RecycleParser.SumContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#sum}.
	 * @param ctx the parse tree
	 */
	void exitSum(RecycleParser.SumContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#score}.
	 * @param ctx the parse tree
	 */
	void enterScore(RecycleParser.ScoreContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#score}.
	 * @param ctx the parse tree
	 */
	void exitScore(RecycleParser.ScoreContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#int}.
	 * @param ctx the parse tree
	 */
	void enterInt(RecycleParser.IntContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#int}.
	 * @param ctx the parse tree
	 */
	void exitInt(RecycleParser.IntContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#str}.
	 * @param ctx the parse tree
	 */
	void enterStr(RecycleParser.StrContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#str}.
	 * @param ctx the parse tree
	 */
	void exitStr(RecycleParser.StrContext ctx);
	/**
	 * Enter a parse tree produced by {@link RecycleParser#namegr}.
	 * @param ctx the parse tree
	 */
	void enterNamegr(RecycleParser.NamegrContext ctx);
	/**
	 * Exit a parse tree produced by {@link RecycleParser#namegr}.
	 * @param ctx the parse tree
	 */
	void exitNamegr(RecycleParser.NamegrContext ctx);
}