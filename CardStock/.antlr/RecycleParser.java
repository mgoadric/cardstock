// Generated from /Users/goadrich/Github/cardstock/CardStock/Recycle.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class RecycleParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, T__33=34, T__34=35, T__35=36, T__36=37, T__37=38, 
		T__38=39, T__39=40, T__40=41, T__41=42, T__42=43, T__43=44, T__44=45, 
		T__45=46, T__46=47, T__47=48, T__48=49, T__49=50, T__50=51, T__51=52, 
		T__52=53, T__53=54, T__54=55, T__55=56, T__56=57, T__57=58, T__58=59, 
		T__59=60, T__60=61, T__61=62, T__62=63, T__63=64, T__64=65, T__65=66, 
		T__66=67, T__67=68, T__68=69, T__69=70, T__70=71, BOOLOP=72, COMPOP=73, 
		EQOP=74, UNOP=75, INTNUM=76, LETT=77, OPEN=78, CLOSE=79, WS=80, ANY=81;
	public static final int
		RULE_var = 0, RULE_game = 1, RULE_setup = 2, RULE_stage = 3, RULE_scoring = 4, 
		RULE_endcondition = 5, RULE_action = 6, RULE_multiaction = 7, RULE_multiaction2 = 8, 
		RULE_condact = 9, RULE_agg = 10, RULE_let = 11, RULE_declare = 12, RULE_playercreate = 13, 
		RULE_teamcreate = 14, RULE_deckcreate = 15, RULE_deck = 16, RULE_teams = 17, 
		RULE_attribute = 18, RULE_initpoints = 19, RULE_awards = 20, RULE_subaward = 21, 
		RULE_cycleaction = 22, RULE_setaction = 23, RULE_setstraction = 24, RULE_incaction = 25, 
		RULE_decaction = 26, RULE_moveaction = 27, RULE_copyaction = 28, RULE_removeaction = 29, 
		RULE_shuffleaction = 30, RULE_turnaction = 31, RULE_repeat = 32, RULE_card = 33, 
		RULE_actual = 34, RULE_rawstorage = 35, RULE_pointstorage = 36, RULE_strstorage = 37, 
		RULE_cstorage = 38, RULE_memstorage = 39, RULE_memset = 40, RULE_subset = 41, 
		RULE_tuple = 42, RULE_partition = 43, RULE_locpre = 44, RULE_locdesc = 45, 
		RULE_who = 46, RULE_whop = 47, RULE_whot = 48, RULE_whodesc = 49, RULE_owner = 50, 
		RULE_teamp = 51, RULE_other = 52, RULE_typed = 53, RULE_collection = 54, 
		RULE_strcollection = 55, RULE_cstoragecollection = 56, RULE_range = 57, 
		RULE_filter = 58, RULE_attrcomp = 59, RULE_cardatt = 60, RULE_boolean = 61, 
		RULE_intop = 62, RULE_add = 63, RULE_mult = 64, RULE_subtract = 65, RULE_mod = 66, 
		RULE_divide = 67, RULE_exponent = 68, RULE_triangular = 69, RULE_fibonacci = 70, 
		RULE_random = 71, RULE_sizeof = 72, RULE_maxof = 73, RULE_minof = 74, 
		RULE_sortof = 75, RULE_unionof = 76, RULE_intersectof = 77, RULE_disjunctionof = 78, 
		RULE_sum = 79, RULE_score = 80, RULE_int = 81, RULE_str = 82, RULE_namegr = 83;
	private static String[] makeRuleNames() {
		return new String[] {
			"var", "game", "setup", "stage", "scoring", "endcondition", "action", 
			"multiaction", "multiaction2", "condact", "agg", "let", "declare", "playercreate", 
			"teamcreate", "deckcreate", "deck", "teams", "attribute", "initpoints", 
			"awards", "subaward", "cycleaction", "setaction", "setstraction", "incaction", 
			"decaction", "moveaction", "copyaction", "removeaction", "shuffleaction", 
			"turnaction", "repeat", "card", "actual", "rawstorage", "pointstorage", 
			"strstorage", "cstorage", "memstorage", "memset", "subset", "tuple", 
			"partition", "locpre", "locdesc", "who", "whop", "whot", "whodesc", "owner", 
			"teamp", "other", "typed", "collection", "strcollection", "cstoragecollection", 
			"range", "filter", "attrcomp", "cardatt", "boolean", "intop", "add", 
			"mult", "subtract", "mod", "divide", "exponent", "triangular", "fibonacci", 
			"random", "sizeof", "maxof", "minof", "sortof", "unionof", "intersectof", 
			"disjunctionof", "sum", "score", "int", "str", "namegr"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'''", "'game'", "'setup'", "'stage'", "'player'", "'team'", "'scoring'", 
			"'min'", "'max'", "'end'", "'choice'", "'do'", "'any'", "'all'", "'let'", 
			"'declare'", "'create'", "'players'", "'teams'", "'deck'", "','", "'set'", 
			"'cycle'", "'next'", "'current'", "'previous'", "'inc'", "'dec'", "'move'", 
			"'remember'", "'forget'", "'shuffle'", "'turn'", "'pass'", "'repeat'", 
			"'top'", "'bottom'", "'actual'", "'sto'", "'points'", "'str'", "'subsets'", 
			"'tuples'", "'using'", "'partition'", "'vloc'", "'iloc'", "'hloc'", "'mem'", 
			"'owner'", "'other'", "'range'", "'..'", "'filter'", "'cardatt'", "'+'", 
			"'*'", "'-'", "'%'", "'//'", "'^'", "'tri'", "'fib'", "'random'", "'size'", 
			"'sort'", "'union'", "'intersect'", "'disjunction'", "'sum'", "'score'", 
			null, null, null, "'not'", null, null, "'('", "')'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"BOOLOP", "COMPOP", "EQOP", "UNOP", "INTNUM", "LETT", "OPEN", "CLOSE", 
			"WS", "ANY"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Recycle.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public RecycleParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class VarContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVar(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVar(this);
		}
	}

	public final VarContext var() throws RecognitionException {
		VarContext _localctx = new VarContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_var);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(168);
			match(T__0);
			setState(169);
			namegr();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class GameContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public SetupContext setup() {
			return getRuleContext(SetupContext.class,0);
		}
		public ScoringContext scoring() {
			return getRuleContext(ScoringContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<DeclareContext> declare() {
			return getRuleContexts(DeclareContext.class);
		}
		public DeclareContext declare(int i) {
			return getRuleContext(DeclareContext.class,i);
		}
		public List<MultiactionContext> multiaction() {
			return getRuleContexts(MultiactionContext.class);
		}
		public MultiactionContext multiaction(int i) {
			return getRuleContext(MultiactionContext.class,i);
		}
		public List<StageContext> stage() {
			return getRuleContexts(StageContext.class);
		}
		public StageContext stage(int i) {
			return getRuleContext(StageContext.class,i);
		}
		public GameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_game; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterGame(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitGame(this);
		}
	}

	public final GameContext game() throws RecognitionException {
		GameContext _localctx = new GameContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_game);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
			match(OPEN);
			setState(172);
			match(T__1);
			setState(176);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(173);
					declare();
					}
					} 
				}
				setState(178);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(179);
			setup();
			setState(182); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(182);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						setState(180);
						multiaction();
						}
						break;
					case 2:
						{
						setState(181);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(184); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(186);
			scoring();
			setState(187);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SetupContext extends ParserRuleContext {
		public List<TerminalNode> OPEN() { return getTokens(RecycleParser.OPEN); }
		public TerminalNode OPEN(int i) {
			return getToken(RecycleParser.OPEN, i);
		}
		public PlayercreateContext playercreate() {
			return getRuleContext(PlayercreateContext.class,0);
		}
		public List<TerminalNode> CLOSE() { return getTokens(RecycleParser.CLOSE); }
		public TerminalNode CLOSE(int i) {
			return getToken(RecycleParser.CLOSE, i);
		}
		public TeamcreateContext teamcreate() {
			return getRuleContext(TeamcreateContext.class,0);
		}
		public List<DeckcreateContext> deckcreate() {
			return getRuleContexts(DeckcreateContext.class);
		}
		public DeckcreateContext deckcreate(int i) {
			return getRuleContext(DeckcreateContext.class,i);
		}
		public List<RepeatContext> repeat() {
			return getRuleContexts(RepeatContext.class);
		}
		public RepeatContext repeat(int i) {
			return getRuleContext(RepeatContext.class,i);
		}
		public SetupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setup; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSetup(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSetup(this);
		}
	}

	public final SetupContext setup() throws RecognitionException {
		SetupContext _localctx = new SetupContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_setup);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			match(OPEN);
			setState(190);
			match(T__2);
			setState(191);
			playercreate();
			setState(193);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(192);
				teamcreate();
				}
				break;
			}
			setState(202); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(195);
					match(OPEN);
					setState(198);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__16:
						{
						setState(196);
						deckcreate();
						}
						break;
					case T__34:
						{
						setState(197);
						repeat();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(200);
					match(CLOSE);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(204); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(206);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public EndconditionContext endcondition() {
			return getRuleContext(EndconditionContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<MultiactionContext> multiaction() {
			return getRuleContexts(MultiactionContext.class);
		}
		public MultiactionContext multiaction(int i) {
			return getRuleContext(MultiactionContext.class,i);
		}
		public List<StageContext> stage() {
			return getRuleContexts(StageContext.class);
		}
		public StageContext stage(int i) {
			return getRuleContext(StageContext.class,i);
		}
		public StageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterStage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitStage(this);
		}
	}

	public final StageContext stage() throws RecognitionException {
		StageContext _localctx = new StageContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_stage);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(208);
			match(OPEN);
			setState(209);
			match(T__3);
			setState(210);
			_la = _input.LA(1);
			if ( !(_la==T__4 || _la==T__5) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(211);
			endcondition();
			setState(214); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(214);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
					case 1:
						{
						setState(212);
						multiaction();
						}
						break;
					case 2:
						{
						setState(213);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(216); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(218);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ScoringContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ScoringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scoring; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterScoring(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitScoring(this);
		}
	}

	public final ScoringContext scoring() throws RecognitionException {
		ScoringContext _localctx = new ScoringContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_scoring);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
			match(OPEN);
			setState(221);
			match(T__6);
			setState(222);
			_la = _input.LA(1);
			if ( !(_la==T__7 || _la==T__8) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(223);
			int_();
			setState(224);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class EndconditionContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public EndconditionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_endcondition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterEndcondition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitEndcondition(this);
		}
	}

	public final EndconditionContext endcondition() throws RecognitionException {
		EndconditionContext _localctx = new EndconditionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_endcondition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(226);
			match(OPEN);
			setState(227);
			match(T__9);
			setState(228);
			boolean_();
			setState(229);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ActionContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public InitpointsContext initpoints() {
			return getRuleContext(InitpointsContext.class,0);
		}
		public TeamcreateContext teamcreate() {
			return getRuleContext(TeamcreateContext.class,0);
		}
		public DeckcreateContext deckcreate() {
			return getRuleContext(DeckcreateContext.class,0);
		}
		public CycleactionContext cycleaction() {
			return getRuleContext(CycleactionContext.class,0);
		}
		public SetactionContext setaction() {
			return getRuleContext(SetactionContext.class,0);
		}
		public MoveactionContext moveaction() {
			return getRuleContext(MoveactionContext.class,0);
		}
		public CopyactionContext copyaction() {
			return getRuleContext(CopyactionContext.class,0);
		}
		public IncactionContext incaction() {
			return getRuleContext(IncactionContext.class,0);
		}
		public SetstractionContext setstraction() {
			return getRuleContext(SetstractionContext.class,0);
		}
		public DecactionContext decaction() {
			return getRuleContext(DecactionContext.class,0);
		}
		public RemoveactionContext removeaction() {
			return getRuleContext(RemoveactionContext.class,0);
		}
		public TurnactionContext turnaction() {
			return getRuleContext(TurnactionContext.class,0);
		}
		public ShuffleactionContext shuffleaction() {
			return getRuleContext(ShuffleactionContext.class,0);
		}
		public RepeatContext repeat() {
			return getRuleContext(RepeatContext.class,0);
		}
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public ActionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_action; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAction(this);
		}
	}

	public final ActionContext action() throws RecognitionException {
		ActionContext _localctx = new ActionContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_action);
		try {
			setState(251);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(231);
				match(OPEN);
				setState(246);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
				case 1:
					{
					setState(232);
					initpoints();
					}
					break;
				case 2:
					{
					setState(233);
					teamcreate();
					}
					break;
				case 3:
					{
					setState(234);
					deckcreate();
					}
					break;
				case 4:
					{
					setState(235);
					cycleaction();
					}
					break;
				case 5:
					{
					setState(236);
					setaction();
					}
					break;
				case 6:
					{
					setState(237);
					moveaction();
					}
					break;
				case 7:
					{
					setState(238);
					copyaction();
					}
					break;
				case 8:
					{
					setState(239);
					incaction();
					}
					break;
				case 9:
					{
					setState(240);
					setstraction();
					}
					break;
				case 10:
					{
					setState(241);
					decaction();
					}
					break;
				case 11:
					{
					setState(242);
					removeaction();
					}
					break;
				case 12:
					{
					setState(243);
					turnaction();
					}
					break;
				case 13:
					{
					setState(244);
					shuffleaction();
					}
					break;
				case 14:
					{
					setState(245);
					repeat();
					}
					break;
				}
				setState(248);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(250);
				agg();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MultiactionContext extends ParserRuleContext {
		public List<TerminalNode> OPEN() { return getTokens(RecycleParser.OPEN); }
		public TerminalNode OPEN(int i) {
			return getToken(RecycleParser.OPEN, i);
		}
		public List<TerminalNode> CLOSE() { return getTokens(RecycleParser.CLOSE); }
		public TerminalNode CLOSE(int i) {
			return getToken(RecycleParser.CLOSE, i);
		}
		public List<CondactContext> condact() {
			return getRuleContexts(CondactContext.class);
		}
		public CondactContext condact(int i) {
			return getRuleContext(CondactContext.class,i);
		}
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public LetContext let() {
			return getRuleContext(LetContext.class,0);
		}
		public MultiactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multiaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMultiaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMultiaction(this);
		}
	}

	public final MultiactionContext multiaction() throws RecognitionException {
		MultiactionContext _localctx = new MultiactionContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_multiaction);
		try {
			int _alt;
			setState(277);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(253);
				match(OPEN);
				setState(254);
				match(T__10);
				setState(255);
				match(OPEN);
				setState(257); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(256);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(259); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(261);
				match(CLOSE);
				setState(262);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(264);
				match(OPEN);
				setState(265);
				match(T__11);
				setState(266);
				match(OPEN);
				setState(268); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(267);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(270); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(272);
				match(CLOSE);
				setState(273);
				match(CLOSE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(275);
				agg();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(276);
				let();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Multiaction2Context extends ParserRuleContext {
		public List<TerminalNode> OPEN() { return getTokens(RecycleParser.OPEN); }
		public TerminalNode OPEN(int i) {
			return getToken(RecycleParser.OPEN, i);
		}
		public List<TerminalNode> CLOSE() { return getTokens(RecycleParser.CLOSE); }
		public TerminalNode CLOSE(int i) {
			return getToken(RecycleParser.CLOSE, i);
		}
		public List<CondactContext> condact() {
			return getRuleContexts(CondactContext.class);
		}
		public CondactContext condact(int i) {
			return getRuleContext(CondactContext.class,i);
		}
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public LetContext let() {
			return getRuleContext(LetContext.class,0);
		}
		public Multiaction2Context(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multiaction2; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMultiaction2(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMultiaction2(this);
		}
	}

	public final Multiaction2Context multiaction2() throws RecognitionException {
		Multiaction2Context _localctx = new Multiaction2Context(_ctx, getState());
		enterRule(_localctx, 16, RULE_multiaction2);
		try {
			int _alt;
			setState(292);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(279);
				match(OPEN);
				setState(280);
				match(T__11);
				setState(281);
				match(OPEN);
				setState(283); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(282);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(285); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(287);
				match(CLOSE);
				setState(288);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(290);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(291);
				let();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CondactContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
		}
		public Multiaction2Context multiaction2() {
			return getRuleContext(Multiaction2Context.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ActionContext action() {
			return getRuleContext(ActionContext.class,0);
		}
		public CondactContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_condact; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCondact(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCondact(this);
		}
	}

	public final CondactContext condact() throws RecognitionException {
		CondactContext _localctx = new CondactContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_condact);
		try {
			setState(306);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(294);
				match(OPEN);
				setState(295);
				boolean_();
				setState(296);
				multiaction2();
				setState(297);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(299);
				multiaction2();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(300);
				match(OPEN);
				setState(301);
				boolean_();
				setState(302);
				action();
				setState(303);
				match(CLOSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(305);
				action();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AggContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public CondactContext condact() {
			return getRuleContext(CondactContext.class,0);
		}
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public AggContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_agg; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAgg(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAgg(this);
		}
	}

	public final AggContext agg() throws RecognitionException {
		AggContext _localctx = new AggContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_agg);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(308);
			match(OPEN);
			setState(309);
			_la = _input.LA(1);
			if ( !(_la==T__12 || _la==T__13) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(310);
			collection();
			setState(311);
			var();
			setState(316);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(312);
				condact();
				}
				break;
			case 2:
				{
				setState(313);
				boolean_();
				}
				break;
			case 3:
				{
				setState(314);
				cstorage();
				}
				break;
			case 4:
				{
				setState(315);
				rawstorage();
				}
				break;
			}
			setState(318);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LetContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TypedContext typed() {
			return getRuleContext(TypedContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MultiactionContext multiaction() {
			return getRuleContext(MultiactionContext.class,0);
		}
		public ActionContext action() {
			return getRuleContext(ActionContext.class,0);
		}
		public CondactContext condact() {
			return getRuleContext(CondactContext.class,0);
		}
		public LetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_let; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterLet(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitLet(this);
		}
	}

	public final LetContext let() throws RecognitionException {
		LetContext _localctx = new LetContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_let);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(320);
			match(OPEN);
			setState(321);
			match(T__14);
			setState(322);
			typed();
			setState(323);
			var();
			setState(327);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				setState(324);
				multiaction();
				}
				break;
			case 2:
				{
				setState(325);
				action();
				}
				break;
			case 3:
				{
				setState(326);
				condact();
				}
				break;
			}
			setState(329);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DeclareContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TypedContext typed() {
			return getRuleContext(TypedContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public DeclareContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declare; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDeclare(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDeclare(this);
		}
	}

	public final DeclareContext declare() throws RecognitionException {
		DeclareContext _localctx = new DeclareContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_declare);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(331);
			match(OPEN);
			setState(332);
			match(T__15);
			setState(333);
			typed();
			setState(334);
			var();
			setState(335);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PlayercreateContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public PlayercreateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_playercreate; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterPlayercreate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitPlayercreate(this);
		}
	}

	public final PlayercreateContext playercreate() throws RecognitionException {
		PlayercreateContext _localctx = new PlayercreateContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_playercreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(337);
			match(OPEN);
			setState(338);
			match(T__16);
			setState(339);
			match(T__17);
			setState(342);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				setState(340);
				var();
				}
				break;
			case 2:
				{
				setState(341);
				int_();
				}
				break;
			}
			setState(344);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TeamcreateContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<TeamsContext> teams() {
			return getRuleContexts(TeamsContext.class);
		}
		public TeamsContext teams(int i) {
			return getRuleContext(TeamsContext.class,i);
		}
		public TeamcreateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_teamcreate; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTeamcreate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTeamcreate(this);
		}
	}

	public final TeamcreateContext teamcreate() throws RecognitionException {
		TeamcreateContext _localctx = new TeamcreateContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_teamcreate);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(346);
			match(OPEN);
			setState(347);
			match(T__16);
			setState(348);
			match(T__18);
			setState(350); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(349);
					teams();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(352); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(354);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DeckcreateContext extends ParserRuleContext {
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public DeckContext deck() {
			return getRuleContext(DeckContext.class,0);
		}
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public DeckcreateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_deckcreate; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDeckcreate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDeckcreate(this);
		}
	}

	public final DeckcreateContext deckcreate() throws RecognitionException {
		DeckcreateContext _localctx = new DeckcreateContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_deckcreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(356);
			match(T__16);
			setState(357);
			match(T__19);
			setState(359);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(358);
				str();
				}
				break;
			}
			setState(361);
			cstorage();
			setState(362);
			deck();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DeckContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public DeckContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_deck; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDeck(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDeck(this);
		}
	}

	public final DeckContext deck() throws RecognitionException {
		DeckContext _localctx = new DeckContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_deck);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(364);
			match(OPEN);
			setState(365);
			match(T__19);
			setState(367); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(366);
					attribute();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(369); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(371);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TeamsContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<TerminalNode> INTNUM() { return getTokens(RecycleParser.INTNUM); }
		public TerminalNode INTNUM(int i) {
			return getToken(RecycleParser.INTNUM, i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<TeamsContext> teams() {
			return getRuleContexts(TeamsContext.class);
		}
		public TeamsContext teams(int i) {
			return getRuleContext(TeamsContext.class,i);
		}
		public TeamsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_teams; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTeams(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTeams(this);
		}
	}

	public final TeamsContext teams() throws RecognitionException {
		TeamsContext _localctx = new TeamsContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_teams);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(373);
			match(OPEN);
			setState(378);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(374);
					match(INTNUM);
					setState(375);
					match(T__20);
					}
					} 
				}
				setState(380);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			setState(381);
			match(INTNUM);
			setState(385);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(382);
					teams();
					}
					} 
				}
				setState(387);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			}
			setState(388);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttributeContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<NamegrContext> namegr() {
			return getRuleContexts(NamegrContext.class);
		}
		public NamegrContext namegr(int i) {
			return getRuleContext(NamegrContext.class,i);
		}
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAttribute(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_attribute);
		try {
			int _alt;
			setState(412);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(390);
				match(OPEN);
				setState(391);
				var();
				setState(392);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(394);
				match(OPEN);
				setState(400);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1+1 ) {
						{
						{
						setState(395);
						namegr();
						setState(396);
						match(T__20);
						}
						} 
					}
					setState(402);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				}
				setState(403);
				namegr();
				setState(407);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
				while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1+1 ) {
						{
						{
						setState(404);
						attribute();
						}
						} 
					}
					setState(409);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
				}
				setState(410);
				match(CLOSE);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class InitpointsContext extends ParserRuleContext {
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<AwardsContext> awards() {
			return getRuleContexts(AwardsContext.class);
		}
		public AwardsContext awards(int i) {
			return getRuleContext(AwardsContext.class,i);
		}
		public InitpointsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_initpoints; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterInitpoints(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitInitpoints(this);
		}
	}

	public final InitpointsContext initpoints() throws RecognitionException {
		InitpointsContext _localctx = new InitpointsContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_initpoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(414);
			match(T__21);
			setState(415);
			pointstorage();
			setState(416);
			match(OPEN);
			setState(418); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(417);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(420); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(422);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AwardsContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<SubawardContext> subaward() {
			return getRuleContexts(SubawardContext.class);
		}
		public SubawardContext subaward(int i) {
			return getRuleContext(SubawardContext.class,i);
		}
		public AwardsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_awards; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAwards(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAwards(this);
		}
	}

	public final AwardsContext awards() throws RecognitionException {
		AwardsContext _localctx = new AwardsContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_awards);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(424);
			match(OPEN);
			setState(426); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(425);
					subaward();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(428); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(430);
			int_();
			setState(431);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SubawardContext extends ParserRuleContext {
		public List<TerminalNode> OPEN() { return getTokens(RecycleParser.OPEN); }
		public TerminalNode OPEN(int i) {
			return getToken(RecycleParser.OPEN, i);
		}
		public List<StrContext> str() {
			return getRuleContexts(StrContext.class);
		}
		public StrContext str(int i) {
			return getRuleContext(StrContext.class,i);
		}
		public List<TerminalNode> CLOSE() { return getTokens(RecycleParser.CLOSE); }
		public TerminalNode CLOSE(int i) {
			return getToken(RecycleParser.CLOSE, i);
		}
		public CardattContext cardatt() {
			return getRuleContext(CardattContext.class,0);
		}
		public SubawardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subaward; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSubaward(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSubaward(this);
		}
	}

	public final SubawardContext subaward() throws RecognitionException {
		SubawardContext _localctx = new SubawardContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_subaward);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(433);
			match(OPEN);
			setState(434);
			str();
			setState(440);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
			case 1:
				{
				setState(435);
				match(OPEN);
				setState(436);
				str();
				setState(437);
				match(CLOSE);
				}
				break;
			case 2:
				{
				setState(439);
				cardatt();
				}
				break;
			}
			setState(442);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CycleactionContext extends ParserRuleContext {
		public OwnerContext owner() {
			return getRuleContext(OwnerContext.class,0);
		}
		public CycleactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cycleaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCycleaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCycleaction(this);
		}
	}

	public final CycleactionContext cycleaction() throws RecognitionException {
		CycleactionContext _localctx = new CycleactionContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_cycleaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(444);
			match(T__22);
			setState(445);
			_la = _input.LA(1);
			if ( !(_la==T__23 || _la==T__24) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(450);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(446);
				owner();
				}
				break;
			case T__24:
				{
				setState(447);
				match(T__24);
				}
				break;
			case T__23:
				{
				setState(448);
				match(T__23);
				}
				break;
			case T__25:
				{
				setState(449);
				match(T__25);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SetactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public SetactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSetaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSetaction(this);
		}
	}

	public final SetactionContext setaction() throws RecognitionException {
		SetactionContext _localctx = new SetactionContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_setaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(452);
			match(T__21);
			setState(453);
			rawstorage();
			setState(454);
			int_();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SetstractionContext extends ParserRuleContext {
		public StrstorageContext strstorage() {
			return getRuleContext(StrstorageContext.class,0);
		}
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public SetstractionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setstraction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSetstraction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSetstraction(this);
		}
	}

	public final SetstractionContext setstraction() throws RecognitionException {
		SetstractionContext _localctx = new SetstractionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_setstraction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(456);
			match(T__21);
			setState(457);
			strstorage();
			setState(458);
			str();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IncactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public IncactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_incaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterIncaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitIncaction(this);
		}
	}

	public final IncactionContext incaction() throws RecognitionException {
		IncactionContext _localctx = new IncactionContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_incaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(460);
			match(T__26);
			setState(461);
			rawstorage();
			setState(462);
			int_();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DecactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public DecactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_decaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDecaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDecaction(this);
		}
	}

	public final DecactionContext decaction() throws RecognitionException {
		DecactionContext _localctx = new DecactionContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_decaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(464);
			match(T__27);
			setState(465);
			rawstorage();
			setState(466);
			int_();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MoveactionContext extends ParserRuleContext {
		public List<CardContext> card() {
			return getRuleContexts(CardContext.class);
		}
		public CardContext card(int i) {
			return getRuleContext(CardContext.class,i);
		}
		public MoveactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_moveaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMoveaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMoveaction(this);
		}
	}

	public final MoveactionContext moveaction() throws RecognitionException {
		MoveactionContext _localctx = new MoveactionContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_moveaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(468);
			match(T__28);
			setState(469);
			card();
			setState(470);
			card();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CopyactionContext extends ParserRuleContext {
		public List<CardContext> card() {
			return getRuleContexts(CardContext.class);
		}
		public CardContext card(int i) {
			return getRuleContext(CardContext.class,i);
		}
		public CopyactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_copyaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCopyaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCopyaction(this);
		}
	}

	public final CopyactionContext copyaction() throws RecognitionException {
		CopyactionContext _localctx = new CopyactionContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_copyaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(472);
			match(T__29);
			setState(473);
			card();
			setState(474);
			card();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RemoveactionContext extends ParserRuleContext {
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public RemoveactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_removeaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRemoveaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRemoveaction(this);
		}
	}

	public final RemoveactionContext removeaction() throws RecognitionException {
		RemoveactionContext _localctx = new RemoveactionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_removeaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(476);
			match(T__30);
			setState(477);
			card();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ShuffleactionContext extends ParserRuleContext {
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public ShuffleactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_shuffleaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterShuffleaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitShuffleaction(this);
		}
	}

	public final ShuffleactionContext shuffleaction() throws RecognitionException {
		ShuffleactionContext _localctx = new ShuffleactionContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_shuffleaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(479);
			match(T__31);
			setState(480);
			cstorage();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TurnactionContext extends ParserRuleContext {
		public TurnactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_turnaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTurnaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTurnaction(this);
		}
	}

	public final TurnactionContext turnaction() throws RecognitionException {
		TurnactionContext _localctx = new TurnactionContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_turnaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(482);
			match(T__32);
			setState(483);
			match(T__33);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RepeatContext extends ParserRuleContext {
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public ActionContext action() {
			return getRuleContext(ActionContext.class,0);
		}
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public MoveactionContext moveaction() {
			return getRuleContext(MoveactionContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RepeatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_repeat; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRepeat(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRepeat(this);
		}
	}

	public final RepeatContext repeat() throws RecognitionException {
		RepeatContext _localctx = new RepeatContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_repeat);
		try {
			setState(495);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,31,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(485);
				match(T__34);
				setState(486);
				int_();
				setState(487);
				action();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(489);
				match(T__34);
				setState(490);
				match(T__13);
				setState(491);
				match(OPEN);
				setState(492);
				moveaction();
				setState(493);
				match(CLOSE);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CardContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public MaxofContext maxof() {
			return getRuleContext(MaxofContext.class,0);
		}
		public MinofContext minof() {
			return getRuleContext(MinofContext.class,0);
		}
		public ActualContext actual() {
			return getRuleContext(ActualContext.class,0);
		}
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public CardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_card; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCard(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCard(this);
		}
	}

	public final CardContext card() throws RecognitionException {
		CardContext _localctx = new CardContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_card);
		try {
			setState(510);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(497);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(498);
				maxof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(499);
				minof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(500);
				actual();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(501);
				match(OPEN);
				setState(505);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__35:
					{
					setState(502);
					match(T__35);
					}
					break;
				case T__36:
					{
					setState(503);
					match(T__36);
					}
					break;
				case T__0:
				case INTNUM:
				case OPEN:
					{
					setState(504);
					int_();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(507);
				cstorage();
				setState(508);
				match(CLOSE);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ActualContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ActualContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_actual; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterActual(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitActual(this);
		}
	}

	public final ActualContext actual() throws RecognitionException {
		ActualContext _localctx = new ActualContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_actual);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(512);
			match(OPEN);
			setState(513);
			match(T__37);
			setState(514);
			card();
			setState(515);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RawstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public WhoContext who() {
			return getRuleContext(WhoContext.class,0);
		}
		public RawstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rawstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRawstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRawstorage(this);
		}
	}

	public final RawstorageContext rawstorage() throws RecognitionException {
		RawstorageContext _localctx = new RawstorageContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_rawstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(517);
			match(OPEN);
			setState(521);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(518);
				var();
				}
				break;
			case T__1:
				{
				setState(519);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(520);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(523);
			match(T__38);
			setState(524);
			str();
			setState(525);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PointstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public WhoContext who() {
			return getRuleContext(WhoContext.class,0);
		}
		public PointstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pointstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterPointstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitPointstorage(this);
		}
	}

	public final PointstorageContext pointstorage() throws RecognitionException {
		PointstorageContext _localctx = new PointstorageContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_pointstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(527);
			match(OPEN);
			setState(531);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(528);
				var();
				}
				break;
			case T__1:
				{
				setState(529);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(530);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(533);
			match(T__39);
			setState(534);
			str();
			setState(535);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StrstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public WhoContext who() {
			return getRuleContext(WhoContext.class,0);
		}
		public StrstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_strstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterStrstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitStrstorage(this);
		}
	}

	public final StrstorageContext strstorage() throws RecognitionException {
		StrstorageContext _localctx = new StrstorageContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_strstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(537);
			match(OPEN);
			setState(541);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(538);
				var();
				}
				break;
			case T__1:
				{
				setState(539);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(540);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(543);
			match(T__40);
			setState(544);
			str();
			setState(545);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CstorageContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public UnionofContext unionof() {
			return getRuleContext(UnionofContext.class,0);
		}
		public IntersectofContext intersectof() {
			return getRuleContext(IntersectofContext.class,0);
		}
		public DisjunctionofContext disjunctionof() {
			return getRuleContext(DisjunctionofContext.class,0);
		}
		public SortofContext sortof() {
			return getRuleContext(SortofContext.class,0);
		}
		public FilterContext filter() {
			return getRuleContext(FilterContext.class,0);
		}
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public LocpreContext locpre() {
			return getRuleContext(LocpreContext.class,0);
		}
		public LocdescContext locdesc() {
			return getRuleContext(LocdescContext.class,0);
		}
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MemstorageContext memstorage() {
			return getRuleContext(MemstorageContext.class,0);
		}
		public CstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCstorage(this);
		}
	}

	public final CstorageContext cstorage() throws RecognitionException {
		CstorageContext _localctx = new CstorageContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_cstorage);
		try {
			setState(560);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(547);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(548);
				unionof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(549);
				intersectof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(550);
				disjunctionof();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(551);
				sortof();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(552);
				filter();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(553);
				match(OPEN);
				setState(554);
				locpre();
				setState(555);
				locdesc();
				setState(556);
				str();
				setState(557);
				match(CLOSE);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(559);
				memstorage();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MemstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public MemsetContext memset() {
			return getRuleContext(MemsetContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public MemstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_memstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMemstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMemstorage(this);
		}
	}

	public final MemstorageContext memstorage() throws RecognitionException {
		MemstorageContext _localctx = new MemstorageContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_memstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(562);
			match(OPEN);
			setState(566);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__35:
				{
				setState(563);
				match(T__35);
				}
				break;
			case T__36:
				{
				setState(564);
				match(T__36);
				}
				break;
			case T__0:
			case INTNUM:
			case OPEN:
				{
				setState(565);
				int_();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(568);
			memset();
			setState(569);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MemsetContext extends ParserRuleContext {
		public TupleContext tuple() {
			return getRuleContext(TupleContext.class,0);
		}
		public PartitionContext partition() {
			return getRuleContext(PartitionContext.class,0);
		}
		public SubsetContext subset() {
			return getRuleContext(SubsetContext.class,0);
		}
		public MemsetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_memset; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMemset(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMemset(this);
		}
	}

	public final MemsetContext memset() throws RecognitionException {
		MemsetContext _localctx = new MemsetContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_memset);
		try {
			setState(574);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(571);
				tuple();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(572);
				partition();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(573);
				subset();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SubsetContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SubsetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subset; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSubset(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSubset(this);
		}
	}

	public final SubsetContext subset() throws RecognitionException {
		SubsetContext _localctx = new SubsetContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_subset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(576);
			match(OPEN);
			setState(577);
			match(T__41);
			setState(578);
			cstorage();
			setState(579);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TupleContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TupleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_tuple; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTuple(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTuple(this);
		}
	}

	public final TupleContext tuple() throws RecognitionException {
		TupleContext _localctx = new TupleContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_tuple);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(581);
			match(OPEN);
			setState(582);
			match(T__42);
			setState(583);
			int_();
			setState(584);
			cstorage();
			setState(585);
			match(T__43);
			setState(586);
			pointstorage();
			setState(587);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class PartitionContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public List<CstorageContext> cstorage() {
			return getRuleContexts(CstorageContext.class);
		}
		public CstorageContext cstorage(int i) {
			return getRuleContext(CstorageContext.class,i);
		}
		public PartitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_partition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterPartition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitPartition(this);
		}
	}

	public final PartitionContext partition() throws RecognitionException {
		PartitionContext _localctx = new PartitionContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_partition);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(589);
			match(OPEN);
			setState(590);
			match(T__44);
			setState(597);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
			case 1:
				{
				setState(591);
				agg();
				}
				break;
			case 2:
				{
				setState(593); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(592);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(595); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,40,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(599);
			str();
			setState(600);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LocpreContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public LocpreContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_locpre; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterLocpre(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitLocpre(this);
		}
	}

	public final LocpreContext locpre() throws RecognitionException {
		LocpreContext _localctx = new LocpreContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_locpre);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(605);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(602);
				var();
				}
				break;
			case T__1:
				{
				setState(603);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(604);
				whop();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LocdescContext extends ParserRuleContext {
		public LocdescContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_locdesc; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterLocdesc(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitLocdesc(this);
		}
	}

	public final LocdescContext locdesc() throws RecognitionException {
		LocdescContext _localctx = new LocdescContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_locdesc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(607);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1055531162664960L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhoContext extends ParserRuleContext {
		public WhotContext whot() {
			return getRuleContext(WhotContext.class,0);
		}
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public WhoContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_who; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterWho(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitWho(this);
		}
	}

	public final WhoContext who() throws RecognitionException {
		WhoContext _localctx = new WhoContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_who);
		try {
			setState(611);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(609);
				whot();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(610);
				whop();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhopContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public WhodescContext whodesc() {
			return getRuleContext(WhodescContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public OwnerContext owner() {
			return getRuleContext(OwnerContext.class,0);
		}
		public WhopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whop; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterWhop(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitWhop(this);
		}
	}

	public final WhopContext whop() throws RecognitionException {
		WhopContext _localctx = new WhopContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_whop);
		try {
			setState(619);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,44,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(613);
				match(OPEN);
				setState(614);
				whodesc();
				setState(615);
				match(T__4);
				setState(616);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(618);
				owner();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhotContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public WhodescContext whodesc() {
			return getRuleContext(WhodescContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TeampContext teamp() {
			return getRuleContext(TeampContext.class,0);
		}
		public WhotContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whot; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterWhot(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitWhot(this);
		}
	}

	public final WhotContext whot() throws RecognitionException {
		WhotContext _localctx = new WhotContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_whot);
		try {
			setState(627);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,45,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(621);
				match(OPEN);
				setState(622);
				whodesc();
				setState(623);
				match(T__5);
				setState(624);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(626);
				teamp();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhodescContext extends ParserRuleContext {
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public WhodescContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whodesc; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterWhodesc(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitWhodesc(this);
		}
	}

	public final WhodescContext whodesc() throws RecognitionException {
		WhodescContext _localctx = new WhodescContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_whodesc);
		try {
			setState(633);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case INTNUM:
			case OPEN:
				enterOuterAlt(_localctx, 1);
				{
				setState(629);
				int_();
				}
				break;
			case T__25:
				enterOuterAlt(_localctx, 2);
				{
				setState(630);
				match(T__25);
				}
				break;
			case T__23:
				enterOuterAlt(_localctx, 3);
				{
				setState(631);
				match(T__23);
				}
				break;
			case T__24:
				enterOuterAlt(_localctx, 4);
				{
				setState(632);
				match(T__24);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class OwnerContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public OwnerContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_owner; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterOwner(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitOwner(this);
		}
	}

	public final OwnerContext owner() throws RecognitionException {
		OwnerContext _localctx = new OwnerContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_owner);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(635);
			match(OPEN);
			setState(636);
			match(T__49);
			setState(637);
			card();
			setState(638);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TeampContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TeampContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_teamp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTeamp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTeamp(this);
		}
	}

	public final TeampContext teamp() throws RecognitionException {
		TeampContext _localctx = new TeampContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_teamp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(640);
			match(OPEN);
			setState(641);
			match(T__5);
			setState(642);
			whop();
			setState(643);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class OtherContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public OtherContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_other; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterOther(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitOther(this);
		}
	}

	public final OtherContext other() throws RecognitionException {
		OtherContext _localctx = new OtherContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_other);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(645);
			match(OPEN);
			setState(646);
			match(T__50);
			setState(647);
			_la = _input.LA(1);
			if ( !(_la==T__4 || _la==T__5) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(648);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypedContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
		}
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public TypedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typed; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTyped(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTyped(this);
		}
	}

	public final TypedContext typed() throws RecognitionException {
		TypedContext _localctx = new TypedContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_typed);
		try {
			setState(655);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(650);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(651);
				int_();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(652);
				boolean_();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(653);
				str();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(654);
				collection();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CollectionContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public StrcollectionContext strcollection() {
			return getRuleContext(StrcollectionContext.class,0);
		}
		public CstoragecollectionContext cstoragecollection() {
			return getRuleContext(CstoragecollectionContext.class,0);
		}
		public WhotContext whot() {
			return getRuleContext(WhotContext.class,0);
		}
		public OtherContext other() {
			return getRuleContext(OtherContext.class,0);
		}
		public RangeContext range() {
			return getRuleContext(RangeContext.class,0);
		}
		public FilterContext filter() {
			return getRuleContext(FilterContext.class,0);
		}
		public CollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collection; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCollection(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCollection(this);
		}
	}

	public final CollectionContext collection() throws RecognitionException {
		CollectionContext _localctx = new CollectionContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_collection);
		try {
			setState(667);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(657);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(658);
				cstorage();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(659);
				strcollection();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(660);
				cstoragecollection();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(661);
				match(T__4);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(662);
				match(T__5);
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(663);
				whot();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(664);
				other();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(665);
				range();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(666);
				filter();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StrcollectionContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<NamegrContext> namegr() {
			return getRuleContexts(NamegrContext.class);
		}
		public NamegrContext namegr(int i) {
			return getRuleContext(NamegrContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public StrcollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_strcollection; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterStrcollection(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitStrcollection(this);
		}
	}

	public final StrcollectionContext strcollection() throws RecognitionException {
		StrcollectionContext _localctx = new StrcollectionContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_strcollection);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(669);
			match(OPEN);
			setState(675);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,49,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(670);
					namegr();
					setState(671);
					match(T__20);
					}
					} 
				}
				setState(677);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,49,_ctx);
			}
			setState(678);
			namegr();
			setState(679);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CstoragecollectionContext extends ParserRuleContext {
		public MemsetContext memset() {
			return getRuleContext(MemsetContext.class,0);
		}
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public LetContext let() {
			return getRuleContext(LetContext.class,0);
		}
		public CstoragecollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cstoragecollection; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCstoragecollection(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCstoragecollection(this);
		}
	}

	public final CstoragecollectionContext cstoragecollection() throws RecognitionException {
		CstoragecollectionContext _localctx = new CstoragecollectionContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_cstoragecollection);
		try {
			setState(684);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(681);
				memset();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(682);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(683);
				let();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RangeContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RangeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_range; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRange(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRange(this);
		}
	}

	public final RangeContext range() throws RecognitionException {
		RangeContext _localctx = new RangeContext(_ctx, getState());
		enterRule(_localctx, 114, RULE_range);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(686);
			match(OPEN);
			setState(687);
			match(T__51);
			setState(688);
			int_();
			setState(689);
			match(T__52);
			setState(690);
			int_();
			setState(691);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FilterContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public FilterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filter; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterFilter(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitFilter(this);
		}
	}

	public final FilterContext filter() throws RecognitionException {
		FilterContext _localctx = new FilterContext(_ctx, getState());
		enterRule(_localctx, 116, RULE_filter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(693);
			match(OPEN);
			setState(694);
			match(T__53);
			setState(695);
			collection();
			setState(696);
			var();
			setState(697);
			boolean_();
			setState(698);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttrcompContext extends ParserRuleContext {
		public TerminalNode EQOP() { return getToken(RecycleParser.EQOP, 0); }
		public List<CardattContext> cardatt() {
			return getRuleContexts(CardattContext.class);
		}
		public CardattContext cardatt(int i) {
			return getRuleContext(CardattContext.class,i);
		}
		public AttrcompContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attrcomp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAttrcomp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAttrcomp(this);
		}
	}

	public final AttrcompContext attrcomp() throws RecognitionException {
		AttrcompContext _localctx = new AttrcompContext(_ctx, getState());
		enterRule(_localctx, 118, RULE_attrcomp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(700);
			match(EQOP);
			setState(701);
			cardatt();
			setState(702);
			cardatt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CardattContext extends ParserRuleContext {
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public CardattContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cardatt; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterCardatt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitCardatt(this);
		}
	}

	public final CardattContext cardatt() throws RecognitionException {
		CardattContext _localctx = new CardattContext(_ctx, getState());
		enterRule(_localctx, 120, RULE_cardatt);
		try {
			setState(711);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(704);
				str();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(705);
				match(OPEN);
				setState(706);
				match(T__54);
				setState(707);
				str();
				setState(708);
				card();
				setState(709);
				match(CLOSE);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BooleanContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TerminalNode BOOLOP() { return getToken(RecycleParser.BOOLOP, 0); }
		public List<BooleanContext> boolean_() {
			return getRuleContexts(BooleanContext.class);
		}
		public BooleanContext boolean_(int i) {
			return getRuleContext(BooleanContext.class,i);
		}
		public IntopContext intop() {
			return getRuleContext(IntopContext.class,0);
		}
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public AttrcompContext attrcomp() {
			return getRuleContext(AttrcompContext.class,0);
		}
		public TerminalNode EQOP() { return getToken(RecycleParser.EQOP, 0); }
		public List<CardContext> card() {
			return getRuleContexts(CardContext.class);
		}
		public CardContext card(int i) {
			return getRuleContext(CardContext.class,i);
		}
		public TerminalNode UNOP() { return getToken(RecycleParser.UNOP, 0); }
		public List<WhopContext> whop() {
			return getRuleContexts(WhopContext.class);
		}
		public WhopContext whop(int i) {
			return getRuleContext(WhopContext.class,i);
		}
		public List<WhotContext> whot() {
			return getRuleContexts(WhotContext.class);
		}
		public WhotContext whot(int i) {
			return getRuleContext(WhotContext.class,i);
		}
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public BooleanContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterBoolean(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitBoolean(this);
		}
	}

	public final BooleanContext boolean_() throws RecognitionException {
		BooleanContext _localctx = new BooleanContext(_ctx, getState());
		enterRule(_localctx, 122, RULE_boolean);
		try {
			int _alt;
			setState(745);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(713);
				match(OPEN);
				setState(740);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,53,_ctx) ) {
				case 1:
					{
					setState(714);
					match(BOOLOP);
					setState(715);
					boolean_();
					setState(717); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(716);
							boolean_();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(719); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,52,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				case 2:
					{
					setState(721);
					intop();
					setState(722);
					int_();
					setState(723);
					int_();
					}
					break;
				case 3:
					{
					setState(725);
					attrcomp();
					}
					break;
				case 4:
					{
					setState(726);
					match(EQOP);
					setState(727);
					card();
					setState(728);
					card();
					}
					break;
				case 5:
					{
					setState(730);
					match(UNOP);
					setState(731);
					boolean_();
					}
					break;
				case 6:
					{
					setState(732);
					match(EQOP);
					setState(733);
					whop();
					setState(734);
					whop();
					}
					break;
				case 7:
					{
					setState(736);
					match(EQOP);
					setState(737);
					whot();
					setState(738);
					whot();
					}
					break;
				}
				setState(742);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(744);
				agg();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IntopContext extends ParserRuleContext {
		public TerminalNode COMPOP() { return getToken(RecycleParser.COMPOP, 0); }
		public TerminalNode EQOP() { return getToken(RecycleParser.EQOP, 0); }
		public IntopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intop; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterIntop(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitIntop(this);
		}
	}

	public final IntopContext intop() throws RecognitionException {
		IntopContext _localctx = new IntopContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_intop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(747);
			_la = _input.LA(1);
			if ( !(_la==COMPOP || _la==EQOP) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AddContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AddContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_add; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAdd(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAdd(this);
		}
	}

	public final AddContext add() throws RecognitionException {
		AddContext _localctx = new AddContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_add);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(749);
			match(OPEN);
			setState(750);
			match(T__55);
			setState(751);
			int_();
			setState(752);
			int_();
			setState(753);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MultContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MultContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mult; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMult(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMult(this);
		}
	}

	public final MultContext mult() throws RecognitionException {
		MultContext _localctx = new MultContext(_ctx, getState());
		enterRule(_localctx, 128, RULE_mult);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(755);
			match(OPEN);
			setState(756);
			match(T__56);
			setState(757);
			int_();
			setState(758);
			int_();
			setState(759);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SubtractContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SubtractContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subtract; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSubtract(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSubtract(this);
		}
	}

	public final SubtractContext subtract() throws RecognitionException {
		SubtractContext _localctx = new SubtractContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_subtract);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(761);
			match(OPEN);
			setState(762);
			match(T__57);
			setState(763);
			int_();
			setState(764);
			int_();
			setState(765);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ModContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ModContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mod; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMod(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMod(this);
		}
	}

	public final ModContext mod() throws RecognitionException {
		ModContext _localctx = new ModContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_mod);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(767);
			match(OPEN);
			setState(768);
			match(T__58);
			setState(769);
			int_();
			setState(770);
			int_();
			setState(771);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DivideContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public DivideContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_divide; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDivide(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDivide(this);
		}
	}

	public final DivideContext divide() throws RecognitionException {
		DivideContext _localctx = new DivideContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_divide);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(773);
			match(OPEN);
			setState(774);
			match(T__59);
			setState(775);
			int_();
			setState(776);
			int_();
			setState(777);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExponentContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ExponentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exponent; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterExponent(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitExponent(this);
		}
	}

	public final ExponentContext exponent() throws RecognitionException {
		ExponentContext _localctx = new ExponentContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_exponent);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(779);
			match(OPEN);
			setState(780);
			match(T__60);
			setState(781);
			int_();
			setState(782);
			int_();
			setState(783);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TriangularContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TriangularContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_triangular; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTriangular(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTriangular(this);
		}
	}

	public final TriangularContext triangular() throws RecognitionException {
		TriangularContext _localctx = new TriangularContext(_ctx, getState());
		enterRule(_localctx, 138, RULE_triangular);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(785);
			match(OPEN);
			setState(786);
			match(T__61);
			setState(787);
			int_();
			setState(788);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FibonacciContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public FibonacciContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fibonacci; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterFibonacci(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitFibonacci(this);
		}
	}

	public final FibonacciContext fibonacci() throws RecognitionException {
		FibonacciContext _localctx = new FibonacciContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_fibonacci);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(790);
			match(OPEN);
			setState(791);
			match(T__62);
			setState(792);
			int_();
			setState(793);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class RandomContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RandomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_random; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRandom(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRandom(this);
		}
	}

	public final RandomContext random() throws RecognitionException {
		RandomContext _localctx = new RandomContext(_ctx, getState());
		enterRule(_localctx, 142, RULE_random);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(795);
			match(OPEN);
			setState(796);
			match(T__63);
			setState(797);
			int_();
			setState(800);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__52) {
				{
				setState(798);
				match(T__52);
				setState(799);
				int_();
				}
			}

			setState(802);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SizeofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public MemsetContext memset() {
			return getRuleContext(MemsetContext.class,0);
		}
		public SizeofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sizeof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSizeof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSizeof(this);
		}
	}

	public final SizeofContext sizeof() throws RecognitionException {
		SizeofContext _localctx = new SizeofContext(_ctx, getState());
		enterRule(_localctx, 144, RULE_sizeof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(804);
			match(OPEN);
			setState(805);
			match(T__64);
			setState(809);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,56,_ctx) ) {
			case 1:
				{
				setState(806);
				var();
				}
				break;
			case 2:
				{
				setState(807);
				cstorage();
				}
				break;
			case 3:
				{
				setState(808);
				memset();
				}
				break;
			}
			setState(811);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MaxofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MaxofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_maxof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMaxof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMaxof(this);
		}
	}

	public final MaxofContext maxof() throws RecognitionException {
		MaxofContext _localctx = new MaxofContext(_ctx, getState());
		enterRule(_localctx, 146, RULE_maxof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(813);
			match(OPEN);
			setState(814);
			match(T__8);
			setState(815);
			cstorage();
			setState(816);
			match(T__43);
			setState(817);
			pointstorage();
			setState(818);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MinofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MinofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_minof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterMinof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitMinof(this);
		}
	}

	public final MinofContext minof() throws RecognitionException {
		MinofContext _localctx = new MinofContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_minof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(820);
			match(OPEN);
			setState(821);
			match(T__7);
			setState(822);
			cstorage();
			setState(823);
			match(T__43);
			setState(824);
			pointstorage();
			setState(825);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SortofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SortofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sortof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSortof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSortof(this);
		}
	}

	public final SortofContext sortof() throws RecognitionException {
		SortofContext _localctx = new SortofContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_sortof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(827);
			match(OPEN);
			setState(828);
			match(T__65);
			setState(829);
			cstorage();
			setState(830);
			match(T__43);
			setState(831);
			pointstorage();
			setState(832);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class UnionofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public List<CstorageContext> cstorage() {
			return getRuleContexts(CstorageContext.class);
		}
		public CstorageContext cstorage(int i) {
			return getRuleContext(CstorageContext.class,i);
		}
		public UnionofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unionof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterUnionof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitUnionof(this);
		}
	}

	public final UnionofContext unionof() throws RecognitionException {
		UnionofContext _localctx = new UnionofContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_unionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(834);
			match(OPEN);
			setState(835);
			match(T__66);
			setState(842);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,58,_ctx) ) {
			case 1:
				{
				setState(836);
				agg();
				}
				break;
			case 2:
				{
				setState(838); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(837);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(840); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,57,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(844);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IntersectofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public List<CstorageContext> cstorage() {
			return getRuleContexts(CstorageContext.class);
		}
		public CstorageContext cstorage(int i) {
			return getRuleContext(CstorageContext.class,i);
		}
		public IntersectofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intersectof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterIntersectof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitIntersectof(this);
		}
	}

	public final IntersectofContext intersectof() throws RecognitionException {
		IntersectofContext _localctx = new IntersectofContext(_ctx, getState());
		enterRule(_localctx, 154, RULE_intersectof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(846);
			match(OPEN);
			setState(847);
			match(T__67);
			setState(854);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,60,_ctx) ) {
			case 1:
				{
				setState(848);
				agg();
				}
				break;
			case 2:
				{
				setState(850); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(849);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(852); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,59,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(856);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DisjunctionofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggContext agg() {
			return getRuleContext(AggContext.class,0);
		}
		public List<CstorageContext> cstorage() {
			return getRuleContexts(CstorageContext.class);
		}
		public CstorageContext cstorage(int i) {
			return getRuleContext(CstorageContext.class,i);
		}
		public DisjunctionofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_disjunctionof; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterDisjunctionof(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitDisjunctionof(this);
		}
	}

	public final DisjunctionofContext disjunctionof() throws RecognitionException {
		DisjunctionofContext _localctx = new DisjunctionofContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_disjunctionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(858);
			match(OPEN);
			setState(859);
			match(T__68);
			setState(866);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,62,_ctx) ) {
			case 1:
				{
				setState(860);
				agg();
				}
				break;
			case 2:
				{
				setState(862); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(861);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(864); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,61,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(868);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class SumContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SumContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sum; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSum(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSum(this);
		}
	}

	public final SumContext sum() throws RecognitionException {
		SumContext _localctx = new SumContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(870);
			match(OPEN);
			setState(871);
			match(T__69);
			setState(872);
			cstorage();
			setState(873);
			match(T__43);
			setState(874);
			pointstorage();
			setState(875);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ScoreContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ScoreContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_score; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterScore(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitScore(this);
		}
	}

	public final ScoreContext score() throws RecognitionException {
		ScoreContext _localctx = new ScoreContext(_ctx, getState());
		enterRule(_localctx, 160, RULE_score);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(877);
			match(OPEN);
			setState(878);
			match(T__70);
			setState(879);
			card();
			setState(880);
			match(T__43);
			setState(881);
			pointstorage();
			setState(882);
			match(CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IntContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public SizeofContext sizeof() {
			return getRuleContext(SizeofContext.class,0);
		}
		public MultContext mult() {
			return getRuleContext(MultContext.class,0);
		}
		public SubtractContext subtract() {
			return getRuleContext(SubtractContext.class,0);
		}
		public ModContext mod() {
			return getRuleContext(ModContext.class,0);
		}
		public AddContext add() {
			return getRuleContext(AddContext.class,0);
		}
		public DivideContext divide() {
			return getRuleContext(DivideContext.class,0);
		}
		public ExponentContext exponent() {
			return getRuleContext(ExponentContext.class,0);
		}
		public TriangularContext triangular() {
			return getRuleContext(TriangularContext.class,0);
		}
		public FibonacciContext fibonacci() {
			return getRuleContext(FibonacciContext.class,0);
		}
		public RandomContext random() {
			return getRuleContext(RandomContext.class,0);
		}
		public SumContext sum() {
			return getRuleContext(SumContext.class,0);
		}
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public ScoreContext score() {
			return getRuleContext(ScoreContext.class,0);
		}
		public List<TerminalNode> INTNUM() { return getTokens(RecycleParser.INTNUM); }
		public TerminalNode INTNUM(int i) {
			return getToken(RecycleParser.INTNUM, i);
		}
		public IntContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_int; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterInt(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitInt(this);
		}
	}

	public final IntContext int_() throws RecognitionException {
		IntContext _localctx = new IntContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_int);
		try {
			int _alt;
			setState(903);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,64,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(884);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(885);
				sizeof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(886);
				mult();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(887);
				subtract();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(888);
				mod();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(889);
				add();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(890);
				divide();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(891);
				exponent();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(892);
				triangular();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(893);
				fibonacci();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(894);
				random();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 12);
				{
				setState(895);
				sum();
				}
				break;
			case 13:
				enterOuterAlt(_localctx, 13);
				{
				setState(896);
				rawstorage();
				}
				break;
			case 14:
				enterOuterAlt(_localctx, 14);
				{
				setState(897);
				score();
				}
				break;
			case 15:
				enterOuterAlt(_localctx, 15);
				{
				setState(899); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(898);
						match(INTNUM);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(901); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,63,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StrContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public StrstorageContext strstorage() {
			return getRuleContext(StrstorageContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public StrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_str; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterStr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitStr(this);
		}
	}

	public final StrContext str() throws RecognitionException {
		StrContext _localctx = new StrContext(_ctx, getState());
		enterRule(_localctx, 164, RULE_str);
		try {
			setState(908);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LETT:
				enterOuterAlt(_localctx, 1);
				{
				setState(905);
				namegr();
				}
				break;
			case OPEN:
				enterOuterAlt(_localctx, 2);
				{
				setState(906);
				strstorage();
				}
				break;
			case T__0:
				enterOuterAlt(_localctx, 3);
				{
				setState(907);
				var();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class NamegrContext extends ParserRuleContext {
		public List<TerminalNode> LETT() { return getTokens(RecycleParser.LETT); }
		public TerminalNode LETT(int i) {
			return getToken(RecycleParser.LETT, i);
		}
		public NamegrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_namegr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterNamegr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitNamegr(this);
		}
	}

	public final NamegrContext namegr() throws RecognitionException {
		NamegrContext _localctx = new NamegrContext(_ctx, getState());
		enterRule(_localctx, 166, RULE_namegr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(911); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(910);
					match(LETT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(913); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,66,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\u0004\u0001Q\u0394\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0002\"\u0007\"\u0002"+
		"#\u0007#\u0002$\u0007$\u0002%\u0007%\u0002&\u0007&\u0002\'\u0007\'\u0002"+
		"(\u0007(\u0002)\u0007)\u0002*\u0007*\u0002+\u0007+\u0002,\u0007,\u0002"+
		"-\u0007-\u0002.\u0007.\u0002/\u0007/\u00020\u00070\u00021\u00071\u0002"+
		"2\u00072\u00023\u00073\u00024\u00074\u00025\u00075\u00026\u00076\u0002"+
		"7\u00077\u00028\u00078\u00029\u00079\u0002:\u0007:\u0002;\u0007;\u0002"+
		"<\u0007<\u0002=\u0007=\u0002>\u0007>\u0002?\u0007?\u0002@\u0007@\u0002"+
		"A\u0007A\u0002B\u0007B\u0002C\u0007C\u0002D\u0007D\u0002E\u0007E\u0002"+
		"F\u0007F\u0002G\u0007G\u0002H\u0007H\u0002I\u0007I\u0002J\u0007J\u0002"+
		"K\u0007K\u0002L\u0007L\u0002M\u0007M\u0002N\u0007N\u0002O\u0007O\u0002"+
		"P\u0007P\u0002Q\u0007Q\u0002R\u0007R\u0002S\u0007S\u0001\u0000\u0001\u0000"+
		"\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001\u0005\u0001\u00af\b\u0001"+
		"\n\u0001\f\u0001\u00b2\t\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0004"+
		"\u0001\u00b7\b\u0001\u000b\u0001\f\u0001\u00b8\u0001\u0001\u0001\u0001"+
		"\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0003\u0002"+
		"\u00c2\b\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0003\u0002\u00c7\b"+
		"\u0002\u0001\u0002\u0001\u0002\u0004\u0002\u00cb\b\u0002\u000b\u0002\f"+
		"\u0002\u00cc\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0004\u0003\u00d7\b\u0003\u000b\u0003"+
		"\f\u0003\u00d8\u0001\u0003\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0004"+
		"\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0005"+
		"\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0003\u0006"+
		"\u00f7\b\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0003\u0006\u00fc\b"+
		"\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0004\u0007\u0102"+
		"\b\u0007\u000b\u0007\f\u0007\u0103\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0004\u0007\u010d\b\u0007"+
		"\u000b\u0007\f\u0007\u010e\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0003\u0007\u0116\b\u0007\u0001\b\u0001\b\u0001\b\u0001\b"+
		"\u0004\b\u011c\b\b\u000b\b\f\b\u011d\u0001\b\u0001\b\u0001\b\u0001\b\u0001"+
		"\b\u0003\b\u0125\b\b\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001"+
		"\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0003\t\u0133\b\t\u0001\n\u0001"+
		"\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0003\n\u013d\b\n\u0001"+
		"\n\u0001\n\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b"+
		"\u0001\u000b\u0001\u000b\u0003\u000b\u0148\b\u000b\u0001\u000b\u0001\u000b"+
		"\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0001\r\u0003\r\u0157\b\r\u0001\r\u0001\r\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0004\u000e\u015f\b\u000e\u000b\u000e\f"+
		"\u000e\u0160\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001\u000f"+
		"\u0003\u000f\u0168\b\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0004\u0010\u0170\b\u0010\u000b\u0010\f\u0010"+
		"\u0171\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0005"+
		"\u0011\u0179\b\u0011\n\u0011\f\u0011\u017c\t\u0011\u0001\u0011\u0001\u0011"+
		"\u0005\u0011\u0180\b\u0011\n\u0011\f\u0011\u0183\t\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0005\u0012\u018f\b\u0012\n\u0012\f\u0012"+
		"\u0192\t\u0012\u0001\u0012\u0001\u0012\u0005\u0012\u0196\b\u0012\n\u0012"+
		"\f\u0012\u0199\t\u0012\u0001\u0012\u0001\u0012\u0003\u0012\u019d\b\u0012"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0004\u0013\u01a3\b\u0013"+
		"\u000b\u0013\f\u0013\u01a4\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014"+
		"\u0004\u0014\u01ab\b\u0014\u000b\u0014\f\u0014\u01ac\u0001\u0014\u0001"+
		"\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0003\u0015\u01b9\b\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0003\u0016\u01c3\b\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0019\u0001"+
		"\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001"+
		"\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0001\u001d\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		" \u0001 \u0001 \u0001 \u0001 \u0001 \u0001 \u0001 \u0001 \u0001 \u0003"+
		" \u01f0\b \u0001!\u0001!\u0001!\u0001!\u0001!\u0001!\u0001!\u0001!\u0003"+
		"!\u01fa\b!\u0001!\u0001!\u0001!\u0003!\u01ff\b!\u0001\"\u0001\"\u0001"+
		"\"\u0001\"\u0001\"\u0001#\u0001#\u0001#\u0001#\u0003#\u020a\b#\u0001#"+
		"\u0001#\u0001#\u0001#\u0001$\u0001$\u0001$\u0001$\u0003$\u0214\b$\u0001"+
		"$\u0001$\u0001$\u0001$\u0001%\u0001%\u0001%\u0001%\u0003%\u021e\b%\u0001"+
		"%\u0001%\u0001%\u0001%\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001"+
		"&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0003&\u0231\b&\u0001\'\u0001"+
		"\'\u0001\'\u0001\'\u0003\'\u0237\b\'\u0001\'\u0001\'\u0001\'\u0001(\u0001"+
		"(\u0001(\u0003(\u023f\b(\u0001)\u0001)\u0001)\u0001)\u0001)\u0001*\u0001"+
		"*\u0001*\u0001*\u0001*\u0001*\u0001*\u0001*\u0001+\u0001+\u0001+\u0001"+
		"+\u0004+\u0252\b+\u000b+\f+\u0253\u0003+\u0256\b+\u0001+\u0001+\u0001"+
		"+\u0001,\u0001,\u0001,\u0003,\u025e\b,\u0001-\u0001-\u0001.\u0001.\u0003"+
		".\u0264\b.\u0001/\u0001/\u0001/\u0001/\u0001/\u0001/\u0003/\u026c\b/\u0001"+
		"0\u00010\u00010\u00010\u00010\u00010\u00030\u0274\b0\u00011\u00011\u0001"+
		"1\u00011\u00031\u027a\b1\u00012\u00012\u00012\u00012\u00012\u00013\u0001"+
		"3\u00013\u00013\u00013\u00014\u00014\u00014\u00014\u00014\u00015\u0001"+
		"5\u00015\u00015\u00015\u00035\u0290\b5\u00016\u00016\u00016\u00016\u0001"+
		"6\u00016\u00016\u00016\u00016\u00016\u00036\u029c\b6\u00017\u00017\u0001"+
		"7\u00017\u00057\u02a2\b7\n7\f7\u02a5\t7\u00017\u00017\u00017\u00018\u0001"+
		"8\u00018\u00038\u02ad\b8\u00019\u00019\u00019\u00019\u00019\u00019\u0001"+
		"9\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001;\u0001;\u0001"+
		";\u0001;\u0001<\u0001<\u0001<\u0001<\u0001<\u0001<\u0001<\u0003<\u02c8"+
		"\b<\u0001=\u0001=\u0001=\u0001=\u0004=\u02ce\b=\u000b=\f=\u02cf\u0001"+
		"=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001"+
		"=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0001=\u0003=\u02e5"+
		"\b=\u0001=\u0001=\u0001=\u0003=\u02ea\b=\u0001>\u0001>\u0001?\u0001?\u0001"+
		"?\u0001?\u0001?\u0001?\u0001@\u0001@\u0001@\u0001@\u0001@\u0001@\u0001"+
		"A\u0001A\u0001A\u0001A\u0001A\u0001A\u0001B\u0001B\u0001B\u0001B\u0001"+
		"B\u0001B\u0001C\u0001C\u0001C\u0001C\u0001C\u0001C\u0001D\u0001D\u0001"+
		"D\u0001D\u0001D\u0001D\u0001E\u0001E\u0001E\u0001E\u0001E\u0001F\u0001"+
		"F\u0001F\u0001F\u0001F\u0001G\u0001G\u0001G\u0001G\u0001G\u0003G\u0321"+
		"\bG\u0001G\u0001G\u0001H\u0001H\u0001H\u0001H\u0001H\u0003H\u032a\bH\u0001"+
		"H\u0001H\u0001I\u0001I\u0001I\u0001I\u0001I\u0001I\u0001I\u0001J\u0001"+
		"J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001K\u0001K\u0001K\u0001K\u0001"+
		"K\u0001K\u0001K\u0001L\u0001L\u0001L\u0001L\u0004L\u0347\bL\u000bL\fL"+
		"\u0348\u0003L\u034b\bL\u0001L\u0001L\u0001M\u0001M\u0001M\u0001M\u0004"+
		"M\u0353\bM\u000bM\fM\u0354\u0003M\u0357\bM\u0001M\u0001M\u0001N\u0001"+
		"N\u0001N\u0001N\u0004N\u035f\bN\u000bN\fN\u0360\u0003N\u0363\bN\u0001"+
		"N\u0001N\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001P\u0001"+
		"P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001Q\u0001Q\u0001Q\u0001Q\u0001"+
		"Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001Q\u0001"+
		"Q\u0004Q\u0384\bQ\u000bQ\fQ\u0385\u0003Q\u0388\bQ\u0001R\u0001R\u0001"+
		"R\u0003R\u038d\bR\u0001S\u0004S\u0390\bS\u000bS\fS\u0391\u0001S\u0015"+
		"\u00b0\u00b8\u00cc\u00d8\u0103\u010e\u011d\u0160\u0171\u017a\u0181\u0190"+
		"\u0197\u01a4\u01ac\u0253\u02a3\u02cf\u0348\u0354\u0360\u0000T\u0000\u0002"+
		"\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e"+
		" \"$&(*,.02468:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086"+
		"\u0088\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098\u009a\u009c\u009e"+
		"\u00a0\u00a2\u00a4\u00a6\u0000\u0006\u0001\u0000\u0005\u0006\u0001\u0000"+
		"\b\t\u0001\u0000\r\u000e\u0001\u0000\u0018\u0019\u0001\u0000.1\u0001\u0000"+
		"IJ\u03ca\u0000\u00a8\u0001\u0000\u0000\u0000\u0002\u00ab\u0001\u0000\u0000"+
		"\u0000\u0004\u00bd\u0001\u0000\u0000\u0000\u0006\u00d0\u0001\u0000\u0000"+
		"\u0000\b\u00dc\u0001\u0000\u0000\u0000\n\u00e2\u0001\u0000\u0000\u0000"+
		"\f\u00fb\u0001\u0000\u0000\u0000\u000e\u0115\u0001\u0000\u0000\u0000\u0010"+
		"\u0124\u0001\u0000\u0000\u0000\u0012\u0132\u0001\u0000\u0000\u0000\u0014"+
		"\u0134\u0001\u0000\u0000\u0000\u0016\u0140\u0001\u0000\u0000\u0000\u0018"+
		"\u014b\u0001\u0000\u0000\u0000\u001a\u0151\u0001\u0000\u0000\u0000\u001c"+
		"\u015a\u0001\u0000\u0000\u0000\u001e\u0164\u0001\u0000\u0000\u0000 \u016c"+
		"\u0001\u0000\u0000\u0000\"\u0175\u0001\u0000\u0000\u0000$\u019c\u0001"+
		"\u0000\u0000\u0000&\u019e\u0001\u0000\u0000\u0000(\u01a8\u0001\u0000\u0000"+
		"\u0000*\u01b1\u0001\u0000\u0000\u0000,\u01bc\u0001\u0000\u0000\u0000."+
		"\u01c4\u0001\u0000\u0000\u00000\u01c8\u0001\u0000\u0000\u00002\u01cc\u0001"+
		"\u0000\u0000\u00004\u01d0\u0001\u0000\u0000\u00006\u01d4\u0001\u0000\u0000"+
		"\u00008\u01d8\u0001\u0000\u0000\u0000:\u01dc\u0001\u0000\u0000\u0000<"+
		"\u01df\u0001\u0000\u0000\u0000>\u01e2\u0001\u0000\u0000\u0000@\u01ef\u0001"+
		"\u0000\u0000\u0000B\u01fe\u0001\u0000\u0000\u0000D\u0200\u0001\u0000\u0000"+
		"\u0000F\u0205\u0001\u0000\u0000\u0000H\u020f\u0001\u0000\u0000\u0000J"+
		"\u0219\u0001\u0000\u0000\u0000L\u0230\u0001\u0000\u0000\u0000N\u0232\u0001"+
		"\u0000\u0000\u0000P\u023e\u0001\u0000\u0000\u0000R\u0240\u0001\u0000\u0000"+
		"\u0000T\u0245\u0001\u0000\u0000\u0000V\u024d\u0001\u0000\u0000\u0000X"+
		"\u025d\u0001\u0000\u0000\u0000Z\u025f\u0001\u0000\u0000\u0000\\\u0263"+
		"\u0001\u0000\u0000\u0000^\u026b\u0001\u0000\u0000\u0000`\u0273\u0001\u0000"+
		"\u0000\u0000b\u0279\u0001\u0000\u0000\u0000d\u027b\u0001\u0000\u0000\u0000"+
		"f\u0280\u0001\u0000\u0000\u0000h\u0285\u0001\u0000\u0000\u0000j\u028f"+
		"\u0001\u0000\u0000\u0000l\u029b\u0001\u0000\u0000\u0000n\u029d\u0001\u0000"+
		"\u0000\u0000p\u02ac\u0001\u0000\u0000\u0000r\u02ae\u0001\u0000\u0000\u0000"+
		"t\u02b5\u0001\u0000\u0000\u0000v\u02bc\u0001\u0000\u0000\u0000x\u02c7"+
		"\u0001\u0000\u0000\u0000z\u02e9\u0001\u0000\u0000\u0000|\u02eb\u0001\u0000"+
		"\u0000\u0000~\u02ed\u0001\u0000\u0000\u0000\u0080\u02f3\u0001\u0000\u0000"+
		"\u0000\u0082\u02f9\u0001\u0000\u0000\u0000\u0084\u02ff\u0001\u0000\u0000"+
		"\u0000\u0086\u0305\u0001\u0000\u0000\u0000\u0088\u030b\u0001\u0000\u0000"+
		"\u0000\u008a\u0311\u0001\u0000\u0000\u0000\u008c\u0316\u0001\u0000\u0000"+
		"\u0000\u008e\u031b\u0001\u0000\u0000\u0000\u0090\u0324\u0001\u0000\u0000"+
		"\u0000\u0092\u032d\u0001\u0000\u0000\u0000\u0094\u0334\u0001\u0000\u0000"+
		"\u0000\u0096\u033b\u0001\u0000\u0000\u0000\u0098\u0342\u0001\u0000\u0000"+
		"\u0000\u009a\u034e\u0001\u0000\u0000\u0000\u009c\u035a\u0001\u0000\u0000"+
		"\u0000\u009e\u0366\u0001\u0000\u0000\u0000\u00a0\u036d\u0001\u0000\u0000"+
		"\u0000\u00a2\u0387\u0001\u0000\u0000\u0000\u00a4\u038c\u0001\u0000\u0000"+
		"\u0000\u00a6\u038f\u0001\u0000\u0000\u0000\u00a8\u00a9\u0005\u0001\u0000"+
		"\u0000\u00a9\u00aa\u0003\u00a6S\u0000\u00aa\u0001\u0001\u0000\u0000\u0000"+
		"\u00ab\u00ac\u0005N\u0000\u0000\u00ac\u00b0\u0005\u0002\u0000\u0000\u00ad"+
		"\u00af\u0003\u0018\f\u0000\u00ae\u00ad\u0001\u0000\u0000\u0000\u00af\u00b2"+
		"\u0001\u0000\u0000\u0000\u00b0\u00b1\u0001\u0000\u0000\u0000\u00b0\u00ae"+
		"\u0001\u0000\u0000\u0000\u00b1\u00b3\u0001\u0000\u0000\u0000\u00b2\u00b0"+
		"\u0001\u0000\u0000\u0000\u00b3\u00b6\u0003\u0004\u0002\u0000\u00b4\u00b7"+
		"\u0003\u000e\u0007\u0000\u00b5\u00b7\u0003\u0006\u0003\u0000\u00b6\u00b4"+
		"\u0001\u0000\u0000\u0000\u00b6\u00b5\u0001\u0000\u0000\u0000\u00b7\u00b8"+
		"\u0001\u0000\u0000\u0000\u00b8\u00b9\u0001\u0000\u0000\u0000\u00b8\u00b6"+
		"\u0001\u0000\u0000\u0000\u00b9\u00ba\u0001\u0000\u0000\u0000\u00ba\u00bb"+
		"\u0003\b\u0004\u0000\u00bb\u00bc\u0005O\u0000\u0000\u00bc\u0003\u0001"+
		"\u0000\u0000\u0000\u00bd\u00be\u0005N\u0000\u0000\u00be\u00bf\u0005\u0003"+
		"\u0000\u0000\u00bf\u00c1\u0003\u001a\r\u0000\u00c0\u00c2\u0003\u001c\u000e"+
		"\u0000\u00c1\u00c0\u0001\u0000\u0000\u0000\u00c1\u00c2\u0001\u0000\u0000"+
		"\u0000\u00c2\u00ca\u0001\u0000\u0000\u0000\u00c3\u00c6\u0005N\u0000\u0000"+
		"\u00c4\u00c7\u0003\u001e\u000f\u0000\u00c5\u00c7\u0003@ \u0000\u00c6\u00c4"+
		"\u0001\u0000\u0000\u0000\u00c6\u00c5\u0001\u0000\u0000\u0000\u00c7\u00c8"+
		"\u0001\u0000\u0000\u0000\u00c8\u00c9\u0005O\u0000\u0000\u00c9\u00cb\u0001"+
		"\u0000\u0000\u0000\u00ca\u00c3\u0001\u0000\u0000\u0000\u00cb\u00cc\u0001"+
		"\u0000\u0000\u0000\u00cc\u00cd\u0001\u0000\u0000\u0000\u00cc\u00ca\u0001"+
		"\u0000\u0000\u0000\u00cd\u00ce\u0001\u0000\u0000\u0000\u00ce\u00cf\u0005"+
		"O\u0000\u0000\u00cf\u0005\u0001\u0000\u0000\u0000\u00d0\u00d1\u0005N\u0000"+
		"\u0000\u00d1\u00d2\u0005\u0004\u0000\u0000\u00d2\u00d3\u0007\u0000\u0000"+
		"\u0000\u00d3\u00d6\u0003\n\u0005\u0000\u00d4\u00d7\u0003\u000e\u0007\u0000"+
		"\u00d5\u00d7\u0003\u0006\u0003\u0000\u00d6\u00d4\u0001\u0000\u0000\u0000"+
		"\u00d6\u00d5\u0001\u0000\u0000\u0000\u00d7\u00d8\u0001\u0000\u0000\u0000"+
		"\u00d8\u00d9\u0001\u0000\u0000\u0000\u00d8\u00d6\u0001\u0000\u0000\u0000"+
		"\u00d9\u00da\u0001\u0000\u0000\u0000\u00da\u00db\u0005O\u0000\u0000\u00db"+
		"\u0007\u0001\u0000\u0000\u0000\u00dc\u00dd\u0005N\u0000\u0000\u00dd\u00de"+
		"\u0005\u0007\u0000\u0000\u00de\u00df\u0007\u0001\u0000\u0000\u00df\u00e0"+
		"\u0003\u00a2Q\u0000\u00e0\u00e1\u0005O\u0000\u0000\u00e1\t\u0001\u0000"+
		"\u0000\u0000\u00e2\u00e3\u0005N\u0000\u0000\u00e3\u00e4\u0005\n\u0000"+
		"\u0000\u00e4\u00e5\u0003z=\u0000\u00e5\u00e6\u0005O\u0000\u0000\u00e6"+
		"\u000b\u0001\u0000\u0000\u0000\u00e7\u00f6\u0005N\u0000\u0000\u00e8\u00f7"+
		"\u0003&\u0013\u0000\u00e9\u00f7\u0003\u001c\u000e\u0000\u00ea\u00f7\u0003"+
		"\u001e\u000f\u0000\u00eb\u00f7\u0003,\u0016\u0000\u00ec\u00f7\u0003.\u0017"+
		"\u0000\u00ed\u00f7\u00036\u001b\u0000\u00ee\u00f7\u00038\u001c\u0000\u00ef"+
		"\u00f7\u00032\u0019\u0000\u00f0\u00f7\u00030\u0018\u0000\u00f1\u00f7\u0003"+
		"4\u001a\u0000\u00f2\u00f7\u0003:\u001d\u0000\u00f3\u00f7\u0003>\u001f"+
		"\u0000\u00f4\u00f7\u0003<\u001e\u0000\u00f5\u00f7\u0003@ \u0000\u00f6"+
		"\u00e8\u0001\u0000\u0000\u0000\u00f6\u00e9\u0001\u0000\u0000\u0000\u00f6"+
		"\u00ea\u0001\u0000\u0000\u0000\u00f6\u00eb\u0001\u0000\u0000\u0000\u00f6"+
		"\u00ec\u0001\u0000\u0000\u0000\u00f6\u00ed\u0001\u0000\u0000\u0000\u00f6"+
		"\u00ee\u0001\u0000\u0000\u0000\u00f6\u00ef\u0001\u0000\u0000\u0000\u00f6"+
		"\u00f0\u0001\u0000\u0000\u0000\u00f6\u00f1\u0001\u0000\u0000\u0000\u00f6"+
		"\u00f2\u0001\u0000\u0000\u0000\u00f6\u00f3\u0001\u0000\u0000\u0000\u00f6"+
		"\u00f4\u0001\u0000\u0000\u0000\u00f6\u00f5\u0001\u0000\u0000\u0000\u00f7"+
		"\u00f8\u0001\u0000\u0000\u0000\u00f8\u00f9\u0005O\u0000\u0000\u00f9\u00fc"+
		"\u0001\u0000\u0000\u0000\u00fa\u00fc\u0003\u0014\n\u0000\u00fb\u00e7\u0001"+
		"\u0000\u0000\u0000\u00fb\u00fa\u0001\u0000\u0000\u0000\u00fc\r\u0001\u0000"+
		"\u0000\u0000\u00fd\u00fe\u0005N\u0000\u0000\u00fe\u00ff\u0005\u000b\u0000"+
		"\u0000\u00ff\u0101\u0005N\u0000\u0000\u0100\u0102\u0003\u0012\t\u0000"+
		"\u0101\u0100\u0001\u0000\u0000\u0000\u0102\u0103\u0001\u0000\u0000\u0000"+
		"\u0103\u0104\u0001\u0000\u0000\u0000\u0103\u0101\u0001\u0000\u0000\u0000"+
		"\u0104\u0105\u0001\u0000\u0000\u0000\u0105\u0106\u0005O\u0000\u0000\u0106"+
		"\u0107\u0005O\u0000\u0000\u0107\u0116\u0001\u0000\u0000\u0000\u0108\u0109"+
		"\u0005N\u0000\u0000\u0109\u010a\u0005\f\u0000\u0000\u010a\u010c\u0005"+
		"N\u0000\u0000\u010b\u010d\u0003\u0012\t\u0000\u010c\u010b\u0001\u0000"+
		"\u0000\u0000\u010d\u010e\u0001\u0000\u0000\u0000\u010e\u010f\u0001\u0000"+
		"\u0000\u0000\u010e\u010c\u0001\u0000\u0000\u0000\u010f\u0110\u0001\u0000"+
		"\u0000\u0000\u0110\u0111\u0005O\u0000\u0000\u0111\u0112\u0005O\u0000\u0000"+
		"\u0112\u0116\u0001\u0000\u0000\u0000\u0113\u0116\u0003\u0014\n\u0000\u0114"+
		"\u0116\u0003\u0016\u000b\u0000\u0115\u00fd\u0001\u0000\u0000\u0000\u0115"+
		"\u0108\u0001\u0000\u0000\u0000\u0115\u0113\u0001\u0000\u0000\u0000\u0115"+
		"\u0114\u0001\u0000\u0000\u0000\u0116\u000f\u0001\u0000\u0000\u0000\u0117"+
		"\u0118\u0005N\u0000\u0000\u0118\u0119\u0005\f\u0000\u0000\u0119\u011b"+
		"\u0005N\u0000\u0000\u011a\u011c\u0003\u0012\t\u0000\u011b\u011a\u0001"+
		"\u0000\u0000\u0000\u011c\u011d\u0001\u0000\u0000\u0000\u011d\u011e\u0001"+
		"\u0000\u0000\u0000\u011d\u011b\u0001\u0000\u0000\u0000\u011e\u011f\u0001"+
		"\u0000\u0000\u0000\u011f\u0120\u0005O\u0000\u0000\u0120\u0121\u0005O\u0000"+
		"\u0000\u0121\u0125\u0001\u0000\u0000\u0000\u0122\u0125\u0003\u0014\n\u0000"+
		"\u0123\u0125\u0003\u0016\u000b\u0000\u0124\u0117\u0001\u0000\u0000\u0000"+
		"\u0124\u0122\u0001\u0000\u0000\u0000\u0124\u0123\u0001\u0000\u0000\u0000"+
		"\u0125\u0011\u0001\u0000\u0000\u0000\u0126\u0127\u0005N\u0000\u0000\u0127"+
		"\u0128\u0003z=\u0000\u0128\u0129\u0003\u0010\b\u0000\u0129\u012a\u0005"+
		"O\u0000\u0000\u012a\u0133\u0001\u0000\u0000\u0000\u012b\u0133\u0003\u0010"+
		"\b\u0000\u012c\u012d\u0005N\u0000\u0000\u012d\u012e\u0003z=\u0000\u012e"+
		"\u012f\u0003\f\u0006\u0000\u012f\u0130\u0005O\u0000\u0000\u0130\u0133"+
		"\u0001\u0000\u0000\u0000\u0131\u0133\u0003\f\u0006\u0000\u0132\u0126\u0001"+
		"\u0000\u0000\u0000\u0132\u012b\u0001\u0000\u0000\u0000\u0132\u012c\u0001"+
		"\u0000\u0000\u0000\u0132\u0131\u0001\u0000\u0000\u0000\u0133\u0013\u0001"+
		"\u0000\u0000\u0000\u0134\u0135\u0005N\u0000\u0000\u0135\u0136\u0007\u0002"+
		"\u0000\u0000\u0136\u0137\u0003l6\u0000\u0137\u013c\u0003\u0000\u0000\u0000"+
		"\u0138\u013d\u0003\u0012\t\u0000\u0139\u013d\u0003z=\u0000\u013a\u013d"+
		"\u0003L&\u0000\u013b\u013d\u0003F#\u0000\u013c\u0138\u0001\u0000\u0000"+
		"\u0000\u013c\u0139\u0001\u0000\u0000\u0000\u013c\u013a\u0001\u0000\u0000"+
		"\u0000\u013c\u013b\u0001\u0000\u0000\u0000\u013d\u013e\u0001\u0000\u0000"+
		"\u0000\u013e\u013f\u0005O\u0000\u0000\u013f\u0015\u0001\u0000\u0000\u0000"+
		"\u0140\u0141\u0005N\u0000\u0000\u0141\u0142\u0005\u000f\u0000\u0000\u0142"+
		"\u0143\u0003j5\u0000\u0143\u0147\u0003\u0000\u0000\u0000\u0144\u0148\u0003"+
		"\u000e\u0007\u0000\u0145\u0148\u0003\f\u0006\u0000\u0146\u0148\u0003\u0012"+
		"\t\u0000\u0147\u0144\u0001\u0000\u0000\u0000\u0147\u0145\u0001\u0000\u0000"+
		"\u0000\u0147\u0146\u0001\u0000\u0000\u0000\u0148\u0149\u0001\u0000\u0000"+
		"\u0000\u0149\u014a\u0005O\u0000\u0000\u014a\u0017\u0001\u0000\u0000\u0000"+
		"\u014b\u014c\u0005N\u0000\u0000\u014c\u014d\u0005\u0010\u0000\u0000\u014d"+
		"\u014e\u0003j5\u0000\u014e\u014f\u0003\u0000\u0000\u0000\u014f\u0150\u0005"+
		"O\u0000\u0000\u0150\u0019\u0001\u0000\u0000\u0000\u0151\u0152\u0005N\u0000"+
		"\u0000\u0152\u0153\u0005\u0011\u0000\u0000\u0153\u0156\u0005\u0012\u0000"+
		"\u0000\u0154\u0157\u0003\u0000\u0000\u0000\u0155\u0157\u0003\u00a2Q\u0000"+
		"\u0156\u0154\u0001\u0000\u0000\u0000\u0156\u0155\u0001\u0000\u0000\u0000"+
		"\u0157\u0158\u0001\u0000\u0000\u0000\u0158\u0159\u0005O\u0000\u0000\u0159"+
		"\u001b\u0001\u0000\u0000\u0000\u015a\u015b\u0005N\u0000\u0000\u015b\u015c"+
		"\u0005\u0011\u0000\u0000\u015c\u015e\u0005\u0013\u0000\u0000\u015d\u015f"+
		"\u0003\"\u0011\u0000\u015e\u015d\u0001\u0000\u0000\u0000\u015f\u0160\u0001"+
		"\u0000\u0000\u0000\u0160\u0161\u0001\u0000\u0000\u0000\u0160\u015e\u0001"+
		"\u0000\u0000\u0000\u0161\u0162\u0001\u0000\u0000\u0000\u0162\u0163\u0005"+
		"O\u0000\u0000\u0163\u001d\u0001\u0000\u0000\u0000\u0164\u0165\u0005\u0011"+
		"\u0000\u0000\u0165\u0167\u0005\u0014\u0000\u0000\u0166\u0168\u0003\u00a4"+
		"R\u0000\u0167\u0166\u0001\u0000\u0000\u0000\u0167\u0168\u0001\u0000\u0000"+
		"\u0000\u0168\u0169\u0001\u0000\u0000\u0000\u0169\u016a\u0003L&\u0000\u016a"+
		"\u016b\u0003 \u0010\u0000\u016b\u001f\u0001\u0000\u0000\u0000\u016c\u016d"+
		"\u0005N\u0000\u0000\u016d\u016f\u0005\u0014\u0000\u0000\u016e\u0170\u0003"+
		"$\u0012\u0000\u016f\u016e\u0001\u0000\u0000\u0000\u0170\u0171\u0001\u0000"+
		"\u0000\u0000\u0171\u0172\u0001\u0000\u0000\u0000\u0171\u016f\u0001\u0000"+
		"\u0000\u0000\u0172\u0173\u0001\u0000\u0000\u0000\u0173\u0174\u0005O\u0000"+
		"\u0000\u0174!\u0001\u0000\u0000\u0000\u0175\u017a\u0005N\u0000\u0000\u0176"+
		"\u0177\u0005L\u0000\u0000\u0177\u0179\u0005\u0015\u0000\u0000\u0178\u0176"+
		"\u0001\u0000\u0000\u0000\u0179\u017c\u0001\u0000\u0000\u0000\u017a\u017b"+
		"\u0001\u0000\u0000\u0000\u017a\u0178\u0001\u0000\u0000\u0000\u017b\u017d"+
		"\u0001\u0000\u0000\u0000\u017c\u017a\u0001\u0000\u0000\u0000\u017d\u0181"+
		"\u0005L\u0000\u0000\u017e\u0180\u0003\"\u0011\u0000\u017f\u017e\u0001"+
		"\u0000\u0000\u0000\u0180\u0183\u0001\u0000\u0000\u0000\u0181\u0182\u0001"+
		"\u0000\u0000\u0000\u0181\u017f\u0001\u0000\u0000\u0000\u0182\u0184\u0001"+
		"\u0000\u0000\u0000\u0183\u0181\u0001\u0000\u0000\u0000\u0184\u0185\u0005"+
		"O\u0000\u0000\u0185#\u0001\u0000\u0000\u0000\u0186\u0187\u0005N\u0000"+
		"\u0000\u0187\u0188\u0003\u0000\u0000\u0000\u0188\u0189\u0005O\u0000\u0000"+
		"\u0189\u019d\u0001\u0000\u0000\u0000\u018a\u0190\u0005N\u0000\u0000\u018b"+
		"\u018c\u0003\u00a6S\u0000\u018c\u018d\u0005\u0015\u0000\u0000\u018d\u018f"+
		"\u0001\u0000\u0000\u0000\u018e\u018b\u0001\u0000\u0000\u0000\u018f\u0192"+
		"\u0001\u0000\u0000\u0000\u0190\u0191\u0001\u0000\u0000\u0000\u0190\u018e"+
		"\u0001\u0000\u0000\u0000\u0191\u0193\u0001\u0000\u0000\u0000\u0192\u0190"+
		"\u0001\u0000\u0000\u0000\u0193\u0197\u0003\u00a6S\u0000\u0194\u0196\u0003"+
		"$\u0012\u0000\u0195\u0194\u0001\u0000\u0000\u0000\u0196\u0199\u0001\u0000"+
		"\u0000\u0000\u0197\u0198\u0001\u0000\u0000\u0000\u0197\u0195\u0001\u0000"+
		"\u0000\u0000\u0198\u019a\u0001\u0000\u0000\u0000\u0199\u0197\u0001\u0000"+
		"\u0000\u0000\u019a\u019b\u0005O\u0000\u0000\u019b\u019d\u0001\u0000\u0000"+
		"\u0000\u019c\u0186\u0001\u0000\u0000\u0000\u019c\u018a\u0001\u0000\u0000"+
		"\u0000\u019d%\u0001\u0000\u0000\u0000\u019e\u019f\u0005\u0016\u0000\u0000"+
		"\u019f\u01a0\u0003H$\u0000\u01a0\u01a2\u0005N\u0000\u0000\u01a1\u01a3"+
		"\u0003(\u0014\u0000\u01a2\u01a1\u0001\u0000\u0000\u0000\u01a3\u01a4\u0001"+
		"\u0000\u0000\u0000\u01a4\u01a5\u0001\u0000\u0000\u0000\u01a4\u01a2\u0001"+
		"\u0000\u0000\u0000\u01a5\u01a6\u0001\u0000\u0000\u0000\u01a6\u01a7\u0005"+
		"O\u0000\u0000\u01a7\'\u0001\u0000\u0000\u0000\u01a8\u01aa\u0005N\u0000"+
		"\u0000\u01a9\u01ab\u0003*\u0015\u0000\u01aa\u01a9\u0001\u0000\u0000\u0000"+
		"\u01ab\u01ac\u0001\u0000\u0000\u0000\u01ac\u01ad\u0001\u0000\u0000\u0000"+
		"\u01ac\u01aa\u0001\u0000\u0000\u0000\u01ad\u01ae\u0001\u0000\u0000\u0000"+
		"\u01ae\u01af\u0003\u00a2Q\u0000\u01af\u01b0\u0005O\u0000\u0000\u01b0)"+
		"\u0001\u0000\u0000\u0000\u01b1\u01b2\u0005N\u0000\u0000\u01b2\u01b8\u0003"+
		"\u00a4R\u0000\u01b3\u01b4\u0005N\u0000\u0000\u01b4\u01b5\u0003\u00a4R"+
		"\u0000\u01b5\u01b6\u0005O\u0000\u0000\u01b6\u01b9\u0001\u0000\u0000\u0000"+
		"\u01b7\u01b9\u0003x<\u0000\u01b8\u01b3\u0001\u0000\u0000\u0000\u01b8\u01b7"+
		"\u0001\u0000\u0000\u0000\u01b9\u01ba\u0001\u0000\u0000\u0000\u01ba\u01bb"+
		"\u0005O\u0000\u0000\u01bb+\u0001\u0000\u0000\u0000\u01bc\u01bd\u0005\u0017"+
		"\u0000\u0000\u01bd\u01c2\u0007\u0003\u0000\u0000\u01be\u01c3\u0003d2\u0000"+
		"\u01bf\u01c3\u0005\u0019\u0000\u0000\u01c0\u01c3\u0005\u0018\u0000\u0000"+
		"\u01c1\u01c3\u0005\u001a\u0000\u0000\u01c2\u01be\u0001\u0000\u0000\u0000"+
		"\u01c2\u01bf\u0001\u0000\u0000\u0000\u01c2\u01c0\u0001\u0000\u0000\u0000"+
		"\u01c2\u01c1\u0001\u0000\u0000\u0000\u01c3-\u0001\u0000\u0000\u0000\u01c4"+
		"\u01c5\u0005\u0016\u0000\u0000\u01c5\u01c6\u0003F#\u0000\u01c6\u01c7\u0003"+
		"\u00a2Q\u0000\u01c7/\u0001\u0000\u0000\u0000\u01c8\u01c9\u0005\u0016\u0000"+
		"\u0000\u01c9\u01ca\u0003J%\u0000\u01ca\u01cb\u0003\u00a4R\u0000\u01cb"+
		"1\u0001\u0000\u0000\u0000\u01cc\u01cd\u0005\u001b\u0000\u0000\u01cd\u01ce"+
		"\u0003F#\u0000\u01ce\u01cf\u0003\u00a2Q\u0000\u01cf3\u0001\u0000\u0000"+
		"\u0000\u01d0\u01d1\u0005\u001c\u0000\u0000\u01d1\u01d2\u0003F#\u0000\u01d2"+
		"\u01d3\u0003\u00a2Q\u0000\u01d35\u0001\u0000\u0000\u0000\u01d4\u01d5\u0005"+
		"\u001d\u0000\u0000\u01d5\u01d6\u0003B!\u0000\u01d6\u01d7\u0003B!\u0000"+
		"\u01d77\u0001\u0000\u0000\u0000\u01d8\u01d9\u0005\u001e\u0000\u0000\u01d9"+
		"\u01da\u0003B!\u0000\u01da\u01db\u0003B!\u0000\u01db9\u0001\u0000\u0000"+
		"\u0000\u01dc\u01dd\u0005\u001f\u0000\u0000\u01dd\u01de\u0003B!\u0000\u01de"+
		";\u0001\u0000\u0000\u0000\u01df\u01e0\u0005 \u0000\u0000\u01e0\u01e1\u0003"+
		"L&\u0000\u01e1=\u0001\u0000\u0000\u0000\u01e2\u01e3\u0005!\u0000\u0000"+
		"\u01e3\u01e4\u0005\"\u0000\u0000\u01e4?\u0001\u0000\u0000\u0000\u01e5"+
		"\u01e6\u0005#\u0000\u0000\u01e6\u01e7\u0003\u00a2Q\u0000\u01e7\u01e8\u0003"+
		"\f\u0006\u0000\u01e8\u01f0\u0001\u0000\u0000\u0000\u01e9\u01ea\u0005#"+
		"\u0000\u0000\u01ea\u01eb\u0005\u000e\u0000\u0000\u01eb\u01ec\u0005N\u0000"+
		"\u0000\u01ec\u01ed\u00036\u001b\u0000\u01ed\u01ee\u0005O\u0000\u0000\u01ee"+
		"\u01f0\u0001\u0000\u0000\u0000\u01ef\u01e5\u0001\u0000\u0000\u0000\u01ef"+
		"\u01e9\u0001\u0000\u0000\u0000\u01f0A\u0001\u0000\u0000\u0000\u01f1\u01ff"+
		"\u0003\u0000\u0000\u0000\u01f2\u01ff\u0003\u0092I\u0000\u01f3\u01ff\u0003"+
		"\u0094J\u0000\u01f4\u01ff\u0003D\"\u0000\u01f5\u01f9\u0005N\u0000\u0000"+
		"\u01f6\u01fa\u0005$\u0000\u0000\u01f7\u01fa\u0005%\u0000\u0000\u01f8\u01fa"+
		"\u0003\u00a2Q\u0000\u01f9\u01f6\u0001\u0000\u0000\u0000\u01f9\u01f7\u0001"+
		"\u0000\u0000\u0000\u01f9\u01f8\u0001\u0000\u0000\u0000\u01fa\u01fb\u0001"+
		"\u0000\u0000\u0000\u01fb\u01fc\u0003L&\u0000\u01fc\u01fd\u0005O\u0000"+
		"\u0000\u01fd\u01ff\u0001\u0000\u0000\u0000\u01fe\u01f1\u0001\u0000\u0000"+
		"\u0000\u01fe\u01f2\u0001\u0000\u0000\u0000\u01fe\u01f3\u0001\u0000\u0000"+
		"\u0000\u01fe\u01f4\u0001\u0000\u0000\u0000\u01fe\u01f5\u0001\u0000\u0000"+
		"\u0000\u01ffC\u0001\u0000\u0000\u0000\u0200\u0201\u0005N\u0000\u0000\u0201"+
		"\u0202\u0005&\u0000\u0000\u0202\u0203\u0003B!\u0000\u0203\u0204\u0005"+
		"O\u0000\u0000\u0204E\u0001\u0000\u0000\u0000\u0205\u0209\u0005N\u0000"+
		"\u0000\u0206\u020a\u0003\u0000\u0000\u0000\u0207\u020a\u0005\u0002\u0000"+
		"\u0000\u0208\u020a\u0003\\.\u0000\u0209\u0206\u0001\u0000\u0000\u0000"+
		"\u0209\u0207\u0001\u0000\u0000\u0000\u0209\u0208\u0001\u0000\u0000\u0000"+
		"\u020a\u020b\u0001\u0000\u0000\u0000\u020b\u020c\u0005\'\u0000\u0000\u020c"+
		"\u020d\u0003\u00a4R\u0000\u020d\u020e\u0005O\u0000\u0000\u020eG\u0001"+
		"\u0000\u0000\u0000\u020f\u0213\u0005N\u0000\u0000\u0210\u0214\u0003\u0000"+
		"\u0000\u0000\u0211\u0214\u0005\u0002\u0000\u0000\u0212\u0214\u0003\\."+
		"\u0000\u0213\u0210\u0001\u0000\u0000\u0000\u0213\u0211\u0001\u0000\u0000"+
		"\u0000\u0213\u0212\u0001\u0000\u0000\u0000\u0214\u0215\u0001\u0000\u0000"+
		"\u0000\u0215\u0216\u0005(\u0000\u0000\u0216\u0217\u0003\u00a4R\u0000\u0217"+
		"\u0218\u0005O\u0000\u0000\u0218I\u0001\u0000\u0000\u0000\u0219\u021d\u0005"+
		"N\u0000\u0000\u021a\u021e\u0003\u0000\u0000\u0000\u021b\u021e\u0005\u0002"+
		"\u0000\u0000\u021c\u021e\u0003\\.\u0000\u021d\u021a\u0001\u0000\u0000"+
		"\u0000\u021d\u021b\u0001\u0000\u0000\u0000\u021d\u021c\u0001\u0000\u0000"+
		"\u0000\u021e\u021f\u0001\u0000\u0000\u0000\u021f\u0220\u0005)\u0000\u0000"+
		"\u0220\u0221\u0003\u00a4R\u0000\u0221\u0222\u0005O\u0000\u0000\u0222K"+
		"\u0001\u0000\u0000\u0000\u0223\u0231\u0003\u0000\u0000\u0000\u0224\u0231"+
		"\u0003\u0098L\u0000\u0225\u0231\u0003\u009aM\u0000\u0226\u0231\u0003\u009c"+
		"N\u0000\u0227\u0231\u0003\u0096K\u0000\u0228\u0231\u0003t:\u0000\u0229"+
		"\u022a\u0005N\u0000\u0000\u022a\u022b\u0003X,\u0000\u022b\u022c\u0003"+
		"Z-\u0000\u022c\u022d\u0003\u00a4R\u0000\u022d\u022e\u0005O\u0000\u0000"+
		"\u022e\u0231\u0001\u0000\u0000\u0000\u022f\u0231\u0003N\'\u0000\u0230"+
		"\u0223\u0001\u0000\u0000\u0000\u0230\u0224\u0001\u0000\u0000\u0000\u0230"+
		"\u0225\u0001\u0000\u0000\u0000\u0230\u0226\u0001\u0000\u0000\u0000\u0230"+
		"\u0227\u0001\u0000\u0000\u0000\u0230\u0228\u0001\u0000\u0000\u0000\u0230"+
		"\u0229\u0001\u0000\u0000\u0000\u0230\u022f\u0001\u0000\u0000\u0000\u0231"+
		"M\u0001\u0000\u0000\u0000\u0232\u0236\u0005N\u0000\u0000\u0233\u0237\u0005"+
		"$\u0000\u0000\u0234\u0237\u0005%\u0000\u0000\u0235\u0237\u0003\u00a2Q"+
		"\u0000\u0236\u0233\u0001\u0000\u0000\u0000\u0236\u0234\u0001\u0000\u0000"+
		"\u0000\u0236\u0235\u0001\u0000\u0000\u0000\u0237\u0238\u0001\u0000\u0000"+
		"\u0000\u0238\u0239\u0003P(\u0000\u0239\u023a\u0005O\u0000\u0000\u023a"+
		"O\u0001\u0000\u0000\u0000\u023b\u023f\u0003T*\u0000\u023c\u023f\u0003"+
		"V+\u0000\u023d\u023f\u0003R)\u0000\u023e\u023b\u0001\u0000\u0000\u0000"+
		"\u023e\u023c\u0001\u0000\u0000\u0000\u023e\u023d\u0001\u0000\u0000\u0000"+
		"\u023fQ\u0001\u0000\u0000\u0000\u0240\u0241\u0005N\u0000\u0000\u0241\u0242"+
		"\u0005*\u0000\u0000\u0242\u0243\u0003L&\u0000\u0243\u0244\u0005O\u0000"+
		"\u0000\u0244S\u0001\u0000\u0000\u0000\u0245\u0246\u0005N\u0000\u0000\u0246"+
		"\u0247\u0005+\u0000\u0000\u0247\u0248\u0003\u00a2Q\u0000\u0248\u0249\u0003"+
		"L&\u0000\u0249\u024a\u0005,\u0000\u0000\u024a\u024b\u0003H$\u0000\u024b"+
		"\u024c\u0005O\u0000\u0000\u024cU\u0001\u0000\u0000\u0000\u024d\u024e\u0005"+
		"N\u0000\u0000\u024e\u0255\u0005-\u0000\u0000\u024f\u0256\u0003\u0014\n"+
		"\u0000\u0250\u0252\u0003L&\u0000\u0251\u0250\u0001\u0000\u0000\u0000\u0252"+
		"\u0253\u0001\u0000\u0000\u0000\u0253\u0254\u0001\u0000\u0000\u0000\u0253"+
		"\u0251\u0001\u0000\u0000\u0000\u0254\u0256\u0001\u0000\u0000\u0000\u0255"+
		"\u024f\u0001\u0000\u0000\u0000\u0255\u0251\u0001\u0000\u0000\u0000\u0256"+
		"\u0257\u0001\u0000\u0000\u0000\u0257\u0258\u0003\u00a4R\u0000\u0258\u0259"+
		"\u0005O\u0000\u0000\u0259W\u0001\u0000\u0000\u0000\u025a\u025e\u0003\u0000"+
		"\u0000\u0000\u025b\u025e\u0005\u0002\u0000\u0000\u025c\u025e\u0003^/\u0000"+
		"\u025d\u025a\u0001\u0000\u0000\u0000\u025d\u025b\u0001\u0000\u0000\u0000"+
		"\u025d\u025c\u0001\u0000\u0000\u0000\u025eY\u0001\u0000\u0000\u0000\u025f"+
		"\u0260\u0007\u0004\u0000\u0000\u0260[\u0001\u0000\u0000\u0000\u0261\u0264"+
		"\u0003`0\u0000\u0262\u0264\u0003^/\u0000\u0263\u0261\u0001\u0000\u0000"+
		"\u0000\u0263\u0262\u0001\u0000\u0000\u0000\u0264]\u0001\u0000\u0000\u0000"+
		"\u0265\u0266\u0005N\u0000\u0000\u0266\u0267\u0003b1\u0000\u0267\u0268"+
		"\u0005\u0005\u0000\u0000\u0268\u0269\u0005O\u0000\u0000\u0269\u026c\u0001"+
		"\u0000\u0000\u0000\u026a\u026c\u0003d2\u0000\u026b\u0265\u0001\u0000\u0000"+
		"\u0000\u026b\u026a\u0001\u0000\u0000\u0000\u026c_\u0001\u0000\u0000\u0000"+
		"\u026d\u026e\u0005N\u0000\u0000\u026e\u026f\u0003b1\u0000\u026f\u0270"+
		"\u0005\u0006\u0000\u0000\u0270\u0271\u0005O\u0000\u0000\u0271\u0274\u0001"+
		"\u0000\u0000\u0000\u0272\u0274\u0003f3\u0000\u0273\u026d\u0001\u0000\u0000"+
		"\u0000\u0273\u0272\u0001\u0000\u0000\u0000\u0274a\u0001\u0000\u0000\u0000"+
		"\u0275\u027a\u0003\u00a2Q\u0000\u0276\u027a\u0005\u001a\u0000\u0000\u0277"+
		"\u027a\u0005\u0018\u0000\u0000\u0278\u027a\u0005\u0019\u0000\u0000\u0279"+
		"\u0275\u0001\u0000\u0000\u0000\u0279\u0276\u0001\u0000\u0000\u0000\u0279"+
		"\u0277\u0001\u0000\u0000\u0000\u0279\u0278\u0001\u0000\u0000\u0000\u027a"+
		"c\u0001\u0000\u0000\u0000\u027b\u027c\u0005N\u0000\u0000\u027c\u027d\u0005"+
		"2\u0000\u0000\u027d\u027e\u0003B!\u0000\u027e\u027f\u0005O\u0000\u0000"+
		"\u027fe\u0001\u0000\u0000\u0000\u0280\u0281\u0005N\u0000\u0000\u0281\u0282"+
		"\u0005\u0006\u0000\u0000\u0282\u0283\u0003^/\u0000\u0283\u0284\u0005O"+
		"\u0000\u0000\u0284g\u0001\u0000\u0000\u0000\u0285\u0286\u0005N\u0000\u0000"+
		"\u0286\u0287\u00053\u0000\u0000\u0287\u0288\u0007\u0000\u0000\u0000\u0288"+
		"\u0289\u0005O\u0000\u0000\u0289i\u0001\u0000\u0000\u0000\u028a\u0290\u0003"+
		"\u0000\u0000\u0000\u028b\u0290\u0003\u00a2Q\u0000\u028c\u0290\u0003z="+
		"\u0000\u028d\u0290\u0003\u00a4R\u0000\u028e\u0290\u0003l6\u0000\u028f"+
		"\u028a\u0001\u0000\u0000\u0000\u028f\u028b\u0001\u0000\u0000\u0000\u028f"+
		"\u028c\u0001\u0000\u0000\u0000\u028f\u028d\u0001\u0000\u0000\u0000\u028f"+
		"\u028e\u0001\u0000\u0000\u0000\u0290k\u0001\u0000\u0000\u0000\u0291\u029c"+
		"\u0003\u0000\u0000\u0000\u0292\u029c\u0003L&\u0000\u0293\u029c\u0003n"+
		"7\u0000\u0294\u029c\u0003p8\u0000\u0295\u029c\u0005\u0005\u0000\u0000"+
		"\u0296\u029c\u0005\u0006\u0000\u0000\u0297\u029c\u0003`0\u0000\u0298\u029c"+
		"\u0003h4\u0000\u0299\u029c\u0003r9\u0000\u029a\u029c\u0003t:\u0000\u029b"+
		"\u0291\u0001\u0000\u0000\u0000\u029b\u0292\u0001\u0000\u0000\u0000\u029b"+
		"\u0293\u0001\u0000\u0000\u0000\u029b\u0294\u0001\u0000\u0000\u0000\u029b"+
		"\u0295\u0001\u0000\u0000\u0000\u029b\u0296\u0001\u0000\u0000\u0000\u029b"+
		"\u0297\u0001\u0000\u0000\u0000\u029b\u0298\u0001\u0000\u0000\u0000\u029b"+
		"\u0299\u0001\u0000\u0000\u0000\u029b\u029a\u0001\u0000\u0000\u0000\u029c"+
		"m\u0001\u0000\u0000\u0000\u029d\u02a3\u0005N\u0000\u0000\u029e\u029f\u0003"+
		"\u00a6S\u0000\u029f\u02a0\u0005\u0015\u0000\u0000\u02a0\u02a2\u0001\u0000"+
		"\u0000\u0000\u02a1\u029e\u0001\u0000\u0000\u0000\u02a2\u02a5\u0001\u0000"+
		"\u0000\u0000\u02a3\u02a4\u0001\u0000\u0000\u0000\u02a3\u02a1\u0001\u0000"+
		"\u0000\u0000\u02a4\u02a6\u0001\u0000\u0000\u0000\u02a5\u02a3\u0001\u0000"+
		"\u0000\u0000\u02a6\u02a7\u0003\u00a6S\u0000\u02a7\u02a8\u0005O\u0000\u0000"+
		"\u02a8o\u0001\u0000\u0000\u0000\u02a9\u02ad\u0003P(\u0000\u02aa\u02ad"+
		"\u0003\u0014\n\u0000\u02ab\u02ad\u0003\u0016\u000b\u0000\u02ac\u02a9\u0001"+
		"\u0000\u0000\u0000\u02ac\u02aa\u0001\u0000\u0000\u0000\u02ac\u02ab\u0001"+
		"\u0000\u0000\u0000\u02adq\u0001\u0000\u0000\u0000\u02ae\u02af\u0005N\u0000"+
		"\u0000\u02af\u02b0\u00054\u0000\u0000\u02b0\u02b1\u0003\u00a2Q\u0000\u02b1"+
		"\u02b2\u00055\u0000\u0000\u02b2\u02b3\u0003\u00a2Q\u0000\u02b3\u02b4\u0005"+
		"O\u0000\u0000\u02b4s\u0001\u0000\u0000\u0000\u02b5\u02b6\u0005N\u0000"+
		"\u0000\u02b6\u02b7\u00056\u0000\u0000\u02b7\u02b8\u0003l6\u0000\u02b8"+
		"\u02b9\u0003\u0000\u0000\u0000\u02b9\u02ba\u0003z=\u0000\u02ba\u02bb\u0005"+
		"O\u0000\u0000\u02bbu\u0001\u0000\u0000\u0000\u02bc\u02bd\u0005J\u0000"+
		"\u0000\u02bd\u02be\u0003x<\u0000\u02be\u02bf\u0003x<\u0000\u02bfw\u0001"+
		"\u0000\u0000\u0000\u02c0\u02c8\u0003\u00a4R\u0000\u02c1\u02c2\u0005N\u0000"+
		"\u0000\u02c2\u02c3\u00057\u0000\u0000\u02c3\u02c4\u0003\u00a4R\u0000\u02c4"+
		"\u02c5\u0003B!\u0000\u02c5\u02c6\u0005O\u0000\u0000\u02c6\u02c8\u0001"+
		"\u0000\u0000\u0000\u02c7\u02c0\u0001\u0000\u0000\u0000\u02c7\u02c1\u0001"+
		"\u0000\u0000\u0000\u02c8y\u0001\u0000\u0000\u0000\u02c9\u02e4\u0005N\u0000"+
		"\u0000\u02ca\u02cb\u0005H\u0000\u0000\u02cb\u02cd\u0003z=\u0000\u02cc"+
		"\u02ce\u0003z=\u0000\u02cd\u02cc\u0001\u0000\u0000\u0000\u02ce\u02cf\u0001"+
		"\u0000\u0000\u0000\u02cf\u02d0\u0001\u0000\u0000\u0000\u02cf\u02cd\u0001"+
		"\u0000\u0000\u0000\u02d0\u02e5\u0001\u0000\u0000\u0000\u02d1\u02d2\u0003"+
		"|>\u0000\u02d2\u02d3\u0003\u00a2Q\u0000\u02d3\u02d4\u0003\u00a2Q\u0000"+
		"\u02d4\u02e5\u0001\u0000\u0000\u0000\u02d5\u02e5\u0003v;\u0000\u02d6\u02d7"+
		"\u0005J\u0000\u0000\u02d7\u02d8\u0003B!\u0000\u02d8\u02d9\u0003B!\u0000"+
		"\u02d9\u02e5\u0001\u0000\u0000\u0000\u02da\u02db\u0005K\u0000\u0000\u02db"+
		"\u02e5\u0003z=\u0000\u02dc\u02dd\u0005J\u0000\u0000\u02dd\u02de\u0003"+
		"^/\u0000\u02de\u02df\u0003^/\u0000\u02df\u02e5\u0001\u0000\u0000\u0000"+
		"\u02e0\u02e1\u0005J\u0000\u0000\u02e1\u02e2\u0003`0\u0000\u02e2\u02e3"+
		"\u0003`0\u0000\u02e3\u02e5\u0001\u0000\u0000\u0000\u02e4\u02ca\u0001\u0000"+
		"\u0000\u0000\u02e4\u02d1\u0001\u0000\u0000\u0000\u02e4\u02d5\u0001\u0000"+
		"\u0000\u0000\u02e4\u02d6\u0001\u0000\u0000\u0000\u02e4\u02da\u0001\u0000"+
		"\u0000\u0000\u02e4\u02dc\u0001\u0000\u0000\u0000\u02e4\u02e0\u0001\u0000"+
		"\u0000\u0000\u02e5\u02e6\u0001\u0000\u0000\u0000\u02e6\u02e7\u0005O\u0000"+
		"\u0000\u02e7\u02ea\u0001\u0000\u0000\u0000\u02e8\u02ea\u0003\u0014\n\u0000"+
		"\u02e9\u02c9\u0001\u0000\u0000\u0000\u02e9\u02e8\u0001\u0000\u0000\u0000"+
		"\u02ea{\u0001\u0000\u0000\u0000\u02eb\u02ec\u0007\u0005\u0000\u0000\u02ec"+
		"}\u0001\u0000\u0000\u0000\u02ed\u02ee\u0005N\u0000\u0000\u02ee\u02ef\u0005"+
		"8\u0000\u0000\u02ef\u02f0\u0003\u00a2Q\u0000\u02f0\u02f1\u0003\u00a2Q"+
		"\u0000\u02f1\u02f2\u0005O\u0000\u0000\u02f2\u007f\u0001\u0000\u0000\u0000"+
		"\u02f3\u02f4\u0005N\u0000\u0000\u02f4\u02f5\u00059\u0000\u0000\u02f5\u02f6"+
		"\u0003\u00a2Q\u0000\u02f6\u02f7\u0003\u00a2Q\u0000\u02f7\u02f8\u0005O"+
		"\u0000\u0000\u02f8\u0081\u0001\u0000\u0000\u0000\u02f9\u02fa\u0005N\u0000"+
		"\u0000\u02fa\u02fb\u0005:\u0000\u0000\u02fb\u02fc\u0003\u00a2Q\u0000\u02fc"+
		"\u02fd\u0003\u00a2Q\u0000\u02fd\u02fe\u0005O\u0000\u0000\u02fe\u0083\u0001"+
		"\u0000\u0000\u0000\u02ff\u0300\u0005N\u0000\u0000\u0300\u0301\u0005;\u0000"+
		"\u0000\u0301\u0302\u0003\u00a2Q\u0000\u0302\u0303\u0003\u00a2Q\u0000\u0303"+
		"\u0304\u0005O\u0000\u0000\u0304\u0085\u0001\u0000\u0000\u0000\u0305\u0306"+
		"\u0005N\u0000\u0000\u0306\u0307\u0005<\u0000\u0000\u0307\u0308\u0003\u00a2"+
		"Q\u0000\u0308\u0309\u0003\u00a2Q\u0000\u0309\u030a\u0005O\u0000\u0000"+
		"\u030a\u0087\u0001\u0000\u0000\u0000\u030b\u030c\u0005N\u0000\u0000\u030c"+
		"\u030d\u0005=\u0000\u0000\u030d\u030e\u0003\u00a2Q\u0000\u030e\u030f\u0003"+
		"\u00a2Q\u0000\u030f\u0310\u0005O\u0000\u0000\u0310\u0089\u0001\u0000\u0000"+
		"\u0000\u0311\u0312\u0005N\u0000\u0000\u0312\u0313\u0005>\u0000\u0000\u0313"+
		"\u0314\u0003\u00a2Q\u0000\u0314\u0315\u0005O\u0000\u0000\u0315\u008b\u0001"+
		"\u0000\u0000\u0000\u0316\u0317\u0005N\u0000\u0000\u0317\u0318\u0005?\u0000"+
		"\u0000\u0318\u0319\u0003\u00a2Q\u0000\u0319\u031a\u0005O\u0000\u0000\u031a"+
		"\u008d\u0001\u0000\u0000\u0000\u031b\u031c\u0005N\u0000\u0000\u031c\u031d"+
		"\u0005@\u0000\u0000\u031d\u0320\u0003\u00a2Q\u0000\u031e\u031f\u00055"+
		"\u0000\u0000\u031f\u0321\u0003\u00a2Q\u0000\u0320\u031e\u0001\u0000\u0000"+
		"\u0000\u0320\u0321\u0001\u0000\u0000\u0000\u0321\u0322\u0001\u0000\u0000"+
		"\u0000\u0322\u0323\u0005O\u0000\u0000\u0323\u008f\u0001\u0000\u0000\u0000"+
		"\u0324\u0325\u0005N\u0000\u0000\u0325\u0329\u0005A\u0000\u0000\u0326\u032a"+
		"\u0003\u0000\u0000\u0000\u0327\u032a\u0003L&\u0000\u0328\u032a\u0003P"+
		"(\u0000\u0329\u0326\u0001\u0000\u0000\u0000\u0329\u0327\u0001\u0000\u0000"+
		"\u0000\u0329\u0328\u0001\u0000\u0000\u0000\u032a\u032b\u0001\u0000\u0000"+
		"\u0000\u032b\u032c\u0005O\u0000\u0000\u032c\u0091\u0001\u0000\u0000\u0000"+
		"\u032d\u032e\u0005N\u0000\u0000\u032e\u032f\u0005\t\u0000\u0000\u032f"+
		"\u0330\u0003L&\u0000\u0330\u0331\u0005,\u0000\u0000\u0331\u0332\u0003"+
		"H$\u0000\u0332\u0333\u0005O\u0000\u0000\u0333\u0093\u0001\u0000\u0000"+
		"\u0000\u0334\u0335\u0005N\u0000\u0000\u0335\u0336\u0005\b\u0000\u0000"+
		"\u0336\u0337\u0003L&\u0000\u0337\u0338\u0005,\u0000\u0000\u0338\u0339"+
		"\u0003H$\u0000\u0339\u033a\u0005O\u0000\u0000\u033a\u0095\u0001\u0000"+
		"\u0000\u0000\u033b\u033c\u0005N\u0000\u0000\u033c\u033d\u0005B\u0000\u0000"+
		"\u033d\u033e\u0003L&\u0000\u033e\u033f\u0005,\u0000\u0000\u033f\u0340"+
		"\u0003H$\u0000\u0340\u0341\u0005O\u0000\u0000\u0341\u0097\u0001\u0000"+
		"\u0000\u0000\u0342\u0343\u0005N\u0000\u0000\u0343\u034a\u0005C\u0000\u0000"+
		"\u0344\u034b\u0003\u0014\n\u0000\u0345\u0347\u0003L&\u0000\u0346\u0345"+
		"\u0001\u0000\u0000\u0000\u0347\u0348\u0001\u0000\u0000\u0000\u0348\u0349"+
		"\u0001\u0000\u0000\u0000\u0348\u0346\u0001\u0000\u0000\u0000\u0349\u034b"+
		"\u0001\u0000\u0000\u0000\u034a\u0344\u0001\u0000\u0000\u0000\u034a\u0346"+
		"\u0001\u0000\u0000\u0000\u034b\u034c\u0001\u0000\u0000\u0000\u034c\u034d"+
		"\u0005O\u0000\u0000\u034d\u0099\u0001\u0000\u0000\u0000\u034e\u034f\u0005"+
		"N\u0000\u0000\u034f\u0356\u0005D\u0000\u0000\u0350\u0357\u0003\u0014\n"+
		"\u0000\u0351\u0353\u0003L&\u0000\u0352\u0351\u0001\u0000\u0000\u0000\u0353"+
		"\u0354\u0001\u0000\u0000\u0000\u0354\u0355\u0001\u0000\u0000\u0000\u0354"+
		"\u0352\u0001\u0000\u0000\u0000\u0355\u0357\u0001\u0000\u0000\u0000\u0356"+
		"\u0350\u0001\u0000\u0000\u0000\u0356\u0352\u0001\u0000\u0000\u0000\u0357"+
		"\u0358\u0001\u0000\u0000\u0000\u0358\u0359\u0005O\u0000\u0000\u0359\u009b"+
		"\u0001\u0000\u0000\u0000\u035a\u035b\u0005N\u0000\u0000\u035b\u0362\u0005"+
		"E\u0000\u0000\u035c\u0363\u0003\u0014\n\u0000\u035d\u035f\u0003L&\u0000"+
		"\u035e\u035d\u0001\u0000\u0000\u0000\u035f\u0360\u0001\u0000\u0000\u0000"+
		"\u0360\u0361\u0001\u0000\u0000\u0000\u0360\u035e\u0001\u0000\u0000\u0000"+
		"\u0361\u0363\u0001\u0000\u0000\u0000\u0362\u035c\u0001\u0000\u0000\u0000"+
		"\u0362\u035e\u0001\u0000\u0000\u0000\u0363\u0364\u0001\u0000\u0000\u0000"+
		"\u0364\u0365\u0005O\u0000\u0000\u0365\u009d\u0001\u0000\u0000\u0000\u0366"+
		"\u0367\u0005N\u0000\u0000\u0367\u0368\u0005F\u0000\u0000\u0368\u0369\u0003"+
		"L&\u0000\u0369\u036a\u0005,\u0000\u0000\u036a\u036b\u0003H$\u0000\u036b"+
		"\u036c\u0005O\u0000\u0000\u036c\u009f\u0001\u0000\u0000\u0000\u036d\u036e"+
		"\u0005N\u0000\u0000\u036e\u036f\u0005G\u0000\u0000\u036f\u0370\u0003B"+
		"!\u0000\u0370\u0371\u0005,\u0000\u0000\u0371\u0372\u0003H$\u0000\u0372"+
		"\u0373\u0005O\u0000\u0000\u0373\u00a1\u0001\u0000\u0000\u0000\u0374\u0388"+
		"\u0003\u0000\u0000\u0000\u0375\u0388\u0003\u0090H\u0000\u0376\u0388\u0003"+
		"\u0080@\u0000\u0377\u0388\u0003\u0082A\u0000\u0378\u0388\u0003\u0084B"+
		"\u0000\u0379\u0388\u0003~?\u0000\u037a\u0388\u0003\u0086C\u0000\u037b"+
		"\u0388\u0003\u0088D\u0000\u037c\u0388\u0003\u008aE\u0000\u037d\u0388\u0003"+
		"\u008cF\u0000\u037e\u0388\u0003\u008eG\u0000\u037f\u0388\u0003\u009eO"+
		"\u0000\u0380\u0388\u0003F#\u0000\u0381\u0388\u0003\u00a0P\u0000\u0382"+
		"\u0384\u0005L\u0000\u0000\u0383\u0382\u0001\u0000\u0000\u0000\u0384\u0385"+
		"\u0001\u0000\u0000\u0000\u0385\u0383\u0001\u0000\u0000\u0000\u0385\u0386"+
		"\u0001\u0000\u0000\u0000\u0386\u0388\u0001\u0000\u0000\u0000\u0387\u0374"+
		"\u0001\u0000\u0000\u0000\u0387\u0375\u0001\u0000\u0000\u0000\u0387\u0376"+
		"\u0001\u0000\u0000\u0000\u0387\u0377\u0001\u0000\u0000\u0000\u0387\u0378"+
		"\u0001\u0000\u0000\u0000\u0387\u0379\u0001\u0000\u0000\u0000\u0387\u037a"+
		"\u0001\u0000\u0000\u0000\u0387\u037b\u0001\u0000\u0000\u0000\u0387\u037c"+
		"\u0001\u0000\u0000\u0000\u0387\u037d\u0001\u0000\u0000\u0000\u0387\u037e"+
		"\u0001\u0000\u0000\u0000\u0387\u037f\u0001\u0000\u0000\u0000\u0387\u0380"+
		"\u0001\u0000\u0000\u0000\u0387\u0381\u0001\u0000\u0000\u0000\u0387\u0383"+
		"\u0001\u0000\u0000\u0000\u0388\u00a3\u0001\u0000\u0000\u0000\u0389\u038d"+
		"\u0003\u00a6S\u0000\u038a\u038d\u0003J%\u0000\u038b\u038d\u0003\u0000"+
		"\u0000\u0000\u038c\u0389\u0001\u0000\u0000\u0000\u038c\u038a\u0001\u0000"+
		"\u0000\u0000\u038c\u038b\u0001\u0000\u0000\u0000\u038d\u00a5\u0001\u0000"+
		"\u0000\u0000\u038e\u0390\u0005M\u0000\u0000\u038f\u038e\u0001\u0000\u0000"+
		"\u0000\u0390\u0391\u0001\u0000\u0000\u0000\u0391\u038f\u0001\u0000\u0000"+
		"\u0000\u0391\u0392\u0001\u0000\u0000\u0000\u0392\u00a7\u0001\u0000\u0000"+
		"\u0000C\u00b0\u00b6\u00b8\u00c1\u00c6\u00cc\u00d6\u00d8\u00f6\u00fb\u0103"+
		"\u010e\u0115\u011d\u0124\u0132\u013c\u0147\u0156\u0160\u0167\u0171\u017a"+
		"\u0181\u0190\u0197\u019c\u01a4\u01ac\u01b8\u01c2\u01ef\u01f9\u01fe\u0209"+
		"\u0213\u021d\u0230\u0236\u023e\u0253\u0255\u025d\u0263\u026b\u0273\u0279"+
		"\u028f\u029b\u02a3\u02ac\u02c7\u02cf\u02e4\u02e9\u0320\u0329\u0348\u034a"+
		"\u0354\u0356\u0360\u0362\u0385\u0387\u038c\u0391";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}