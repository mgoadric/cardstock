// Generated from /Users/goadrich/Github/cardstock/CardStockXam/Recycle.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class RecycleParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

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
		T__66=67, T__67=68, T__68=69, T__69=70, BOOLOP=71, COMPOP=72, EQOP=73, 
		UNOP=74, INTNUM=75, LETT=76, OPEN=77, CLOSE=78, WS=79, ANY=80;
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
		RULE_cstorage = 38, RULE_memstorage = 39, RULE_memset = 40, RULE_tuple = 41, 
		RULE_partition = 42, RULE_locpre = 43, RULE_locdesc = 44, RULE_who = 45, 
		RULE_whop = 46, RULE_whot = 47, RULE_whodesc = 48, RULE_owner = 49, RULE_teamp = 50, 
		RULE_other = 51, RULE_typed = 52, RULE_collection = 53, RULE_strcollection = 54, 
		RULE_cstoragecollection = 55, RULE_range = 56, RULE_filter = 57, RULE_attrcomp = 58, 
		RULE_cardatt = 59, RULE_boolean = 60, RULE_intop = 61, RULE_add = 62, 
		RULE_mult = 63, RULE_subtract = 64, RULE_mod = 65, RULE_divide = 66, RULE_exponent = 67, 
		RULE_triangular = 68, RULE_fibonacci = 69, RULE_random = 70, RULE_sizeof = 71, 
		RULE_maxof = 72, RULE_minof = 73, RULE_sortof = 74, RULE_unionof = 75, 
		RULE_intersectof = 76, RULE_disjunctionof = 77, RULE_sum = 78, RULE_score = 79, 
		RULE_int = 80, RULE_str = 81, RULE_namegr = 82;
	private static String[] makeRuleNames() {
		return new String[] {
			"var", "game", "setup", "stage", "scoring", "endcondition", "action", 
			"multiaction", "multiaction2", "condact", "agg", "let", "declare", "playercreate", 
			"teamcreate", "deckcreate", "deck", "teams", "attribute", "initpoints", 
			"awards", "subaward", "cycleaction", "setaction", "setstraction", "incaction", 
			"decaction", "moveaction", "copyaction", "removeaction", "shuffleaction", 
			"turnaction", "repeat", "card", "actual", "rawstorage", "pointstorage", 
			"strstorage", "cstorage", "memstorage", "memset", "tuple", "partition", 
			"locpre", "locdesc", "who", "whop", "whot", "whodesc", "owner", "teamp", 
			"other", "typed", "collection", "strcollection", "cstoragecollection", 
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
			"'top'", "'bottom'", "'actual'", "'sto'", "'points'", "'str'", "'tuples'", 
			"'using'", "'partition'", "'vloc'", "'iloc'", "'hloc'", "'mem'", "'owner'", 
			"'other'", "'range'", "'..'", "'filter'", "'cardatt'", "'+'", "'*'", 
			"'-'", "'%'", "'//'", "'^'", "'tri'", "'fib'", "'random'", "'size'", 
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
			null, null, null, null, null, null, null, null, null, null, null, "BOOLOP", 
			"COMPOP", "EQOP", "UNOP", "INTNUM", "LETT", "OPEN", "CLOSE", "WS", "ANY"
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

	public static class VarContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var; }
	}

	public final VarContext var() throws RecognitionException {
		VarContext _localctx = new VarContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_var);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			match(T__0);
			setState(167);
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
	}

	public final GameContext game() throws RecognitionException {
		GameContext _localctx = new GameContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_game);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(169);
			match(OPEN);
			setState(170);
			match(T__1);
			setState(174);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(171);
					declare();
					}
					} 
				}
				setState(176);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(177);
			setup();
			setState(180); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(180);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						setState(178);
						multiaction();
						}
						break;
					case 2:
						{
						setState(179);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(182); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(184);
			scoring();
			setState(185);
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
	}

	public final SetupContext setup() throws RecognitionException {
		SetupContext _localctx = new SetupContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_setup);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			match(OPEN);
			setState(188);
			match(T__2);
			setState(189);
			playercreate();
			setState(191);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(190);
				teamcreate();
				}
				break;
			}
			setState(200); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(193);
					match(OPEN);
					setState(196);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__16:
						{
						setState(194);
						deckcreate();
						}
						break;
					case T__34:
						{
						setState(195);
						repeat();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(198);
					match(CLOSE);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(202); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(204);
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
	}

	public final StageContext stage() throws RecognitionException {
		StageContext _localctx = new StageContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_stage);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(206);
			match(OPEN);
			setState(207);
			match(T__3);
			setState(208);
			_la = _input.LA(1);
			if ( !(_la==T__4 || _la==T__5) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(209);
			endcondition();
			setState(212); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(212);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
					case 1:
						{
						setState(210);
						multiaction();
						}
						break;
					case 2:
						{
						setState(211);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(214); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(216);
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

	public static class ScoringContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ScoringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scoring; }
	}

	public final ScoringContext scoring() throws RecognitionException {
		ScoringContext _localctx = new ScoringContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_scoring);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(218);
			match(OPEN);
			setState(219);
			match(T__6);
			setState(220);
			_la = _input.LA(1);
			if ( !(_la==T__7 || _la==T__8) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(221);
			int();
			setState(222);
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

	public static class EndconditionContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public BooleanContext boolean() {
			return getRuleContext(BooleanContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public EndconditionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_endcondition; }
	}

	public final EndconditionContext endcondition() throws RecognitionException {
		EndconditionContext _localctx = new EndconditionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_endcondition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(224);
			match(OPEN);
			setState(225);
			match(T__9);
			setState(226);
			boolean();
			setState(227);
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
	}

	public final ActionContext action() throws RecognitionException {
		ActionContext _localctx = new ActionContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_action);
		try {
			setState(248);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(229);
				match(OPEN);
				setState(243);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
				case 1:
					{
					setState(230);
					initpoints();
					}
					break;
				case 2:
					{
					setState(231);
					teamcreate();
					}
					break;
				case 3:
					{
					setState(232);
					deckcreate();
					}
					break;
				case 4:
					{
					setState(233);
					cycleaction();
					}
					break;
				case 5:
					{
					setState(234);
					setaction();
					}
					break;
				case 6:
					{
					setState(235);
					moveaction();
					}
					break;
				case 7:
					{
					setState(236);
					copyaction();
					}
					break;
				case 8:
					{
					setState(237);
					incaction();
					}
					break;
				case 9:
					{
					setState(238);
					decaction();
					}
					break;
				case 10:
					{
					setState(239);
					removeaction();
					}
					break;
				case 11:
					{
					setState(240);
					turnaction();
					}
					break;
				case 12:
					{
					setState(241);
					shuffleaction();
					}
					break;
				case 13:
					{
					setState(242);
					repeat();
					}
					break;
				}
				setState(245);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(247);
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
	}

	public final MultiactionContext multiaction() throws RecognitionException {
		MultiactionContext _localctx = new MultiactionContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_multiaction);
		try {
			int _alt;
			setState(274);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(250);
				match(OPEN);
				setState(251);
				match(T__10);
				setState(252);
				match(OPEN);
				setState(254); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(253);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(256); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(258);
				match(CLOSE);
				setState(259);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(261);
				match(OPEN);
				setState(262);
				match(T__11);
				setState(263);
				match(OPEN);
				setState(265); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(264);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(267); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(269);
				match(CLOSE);
				setState(270);
				match(CLOSE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(272);
				agg();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(273);
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
	}

	public final Multiaction2Context multiaction2() throws RecognitionException {
		Multiaction2Context _localctx = new Multiaction2Context(_ctx, getState());
		enterRule(_localctx, 16, RULE_multiaction2);
		try {
			int _alt;
			setState(289);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(276);
				match(OPEN);
				setState(277);
				match(T__11);
				setState(278);
				match(OPEN);
				setState(280); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(279);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(282); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(284);
				match(CLOSE);
				setState(285);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(287);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(288);
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

	public static class CondactContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public BooleanContext boolean() {
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
	}

	public final CondactContext condact() throws RecognitionException {
		CondactContext _localctx = new CondactContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_condact);
		try {
			setState(303);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(291);
				match(OPEN);
				setState(292);
				boolean();
				setState(293);
				multiaction2();
				setState(294);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(296);
				multiaction2();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(297);
				match(OPEN);
				setState(298);
				boolean();
				setState(299);
				action();
				setState(300);
				match(CLOSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(302);
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
		public BooleanContext boolean() {
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
	}

	public final AggContext agg() throws RecognitionException {
		AggContext _localctx = new AggContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_agg);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(305);
			match(OPEN);
			setState(306);
			_la = _input.LA(1);
			if ( !(_la==T__12 || _la==T__13) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(307);
			collection();
			setState(308);
			var();
			setState(313);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(309);
				condact();
				}
				break;
			case 2:
				{
				setState(310);
				boolean();
				}
				break;
			case 3:
				{
				setState(311);
				cstorage();
				}
				break;
			case 4:
				{
				setState(312);
				rawstorage();
				}
				break;
			}
			setState(315);
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
	}

	public final LetContext let() throws RecognitionException {
		LetContext _localctx = new LetContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_let);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(317);
			match(OPEN);
			setState(318);
			match(T__14);
			setState(319);
			typed();
			setState(320);
			var();
			setState(324);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				setState(321);
				multiaction();
				}
				break;
			case 2:
				{
				setState(322);
				action();
				}
				break;
			case 3:
				{
				setState(323);
				condact();
				}
				break;
			}
			setState(326);
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
	}

	public final DeclareContext declare() throws RecognitionException {
		DeclareContext _localctx = new DeclareContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_declare);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(328);
			match(OPEN);
			setState(329);
			match(T__15);
			setState(330);
			typed();
			setState(331);
			var();
			setState(332);
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

	public static class PlayercreateContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public PlayercreateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_playercreate; }
	}

	public final PlayercreateContext playercreate() throws RecognitionException {
		PlayercreateContext _localctx = new PlayercreateContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_playercreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(334);
			match(OPEN);
			setState(335);
			match(T__16);
			setState(336);
			match(T__17);
			setState(339);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				setState(337);
				var();
				}
				break;
			case 2:
				{
				setState(338);
				int();
				}
				break;
			}
			setState(341);
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
	}

	public final TeamcreateContext teamcreate() throws RecognitionException {
		TeamcreateContext _localctx = new TeamcreateContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_teamcreate);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(343);
			match(OPEN);
			setState(344);
			match(T__16);
			setState(345);
			match(T__18);
			setState(347); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(346);
					teams();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(349); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(351);
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
	}

	public final DeckcreateContext deckcreate() throws RecognitionException {
		DeckcreateContext _localctx = new DeckcreateContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_deckcreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(353);
			match(T__16);
			setState(354);
			match(T__19);
			setState(356);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(355);
				str();
				}
				break;
			}
			setState(358);
			cstorage();
			setState(359);
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
	}

	public final DeckContext deck() throws RecognitionException {
		DeckContext _localctx = new DeckContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_deck);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(361);
			match(OPEN);
			setState(362);
			match(T__19);
			setState(364); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(363);
					attribute();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(366); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(368);
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
	}

	public final TeamsContext teams() throws RecognitionException {
		TeamsContext _localctx = new TeamsContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_teams);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(370);
			match(OPEN);
			setState(375);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(371);
					match(INTNUM);
					setState(372);
					match(T__20);
					}
					} 
				}
				setState(377);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			setState(378);
			match(INTNUM);
			setState(382);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(379);
					teams();
					}
					} 
				}
				setState(384);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			}
			setState(385);
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
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_attribute);
		try {
			int _alt;
			setState(409);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(387);
				match(OPEN);
				setState(388);
				var();
				setState(389);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(391);
				match(OPEN);
				setState(397);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1+1 ) {
						{
						{
						setState(392);
						namegr();
						setState(393);
						match(T__20);
						}
						} 
					}
					setState(399);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
				}
				setState(400);
				namegr();
				setState(404);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
				while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1+1 ) {
						{
						{
						setState(401);
						attribute();
						}
						} 
					}
					setState(406);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
				}
				setState(407);
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
	}

	public final InitpointsContext initpoints() throws RecognitionException {
		InitpointsContext _localctx = new InitpointsContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_initpoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(411);
			match(T__21);
			setState(412);
			pointstorage();
			setState(413);
			match(OPEN);
			setState(415); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(414);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(417); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(419);
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

	public static class AwardsContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int() {
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
	}

	public final AwardsContext awards() throws RecognitionException {
		AwardsContext _localctx = new AwardsContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_awards);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(421);
			match(OPEN);
			setState(423); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(422);
					subaward();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(425); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(427);
			int();
			setState(428);
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
	}

	public final SubawardContext subaward() throws RecognitionException {
		SubawardContext _localctx = new SubawardContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_subaward);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(430);
			match(OPEN);
			setState(431);
			str();
			setState(437);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
			case 1:
				{
				setState(432);
				match(OPEN);
				setState(433);
				str();
				setState(434);
				match(CLOSE);
				}
				break;
			case 2:
				{
				setState(436);
				cardatt();
				}
				break;
			}
			setState(439);
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

	public static class CycleactionContext extends ParserRuleContext {
		public OwnerContext owner() {
			return getRuleContext(OwnerContext.class,0);
		}
		public CycleactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cycleaction; }
	}

	public final CycleactionContext cycleaction() throws RecognitionException {
		CycleactionContext _localctx = new CycleactionContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_cycleaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(441);
			match(T__22);
			setState(442);
			_la = _input.LA(1);
			if ( !(_la==T__23 || _la==T__24) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(447);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(443);
				owner();
				}
				break;
			case T__24:
				{
				setState(444);
				match(T__24);
				}
				break;
			case T__23:
				{
				setState(445);
				match(T__23);
				}
				break;
			case T__25:
				{
				setState(446);
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

	public static class SetactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public SetactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_setaction; }
	}

	public final SetactionContext setaction() throws RecognitionException {
		SetactionContext _localctx = new SetactionContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_setaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(449);
			match(T__21);
			setState(450);
			rawstorage();
			setState(451);
			int();
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
	}

	public final SetstractionContext setstraction() throws RecognitionException {
		SetstractionContext _localctx = new SetstractionContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_setstraction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(453);
			match(T__21);
			setState(454);
			strstorage();
			setState(455);
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

	public static class IncactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public IncactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_incaction; }
	}

	public final IncactionContext incaction() throws RecognitionException {
		IncactionContext _localctx = new IncactionContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_incaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(457);
			match(T__26);
			setState(458);
			rawstorage();
			setState(459);
			int();
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

	public static class DecactionContext extends ParserRuleContext {
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public DecactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_decaction; }
	}

	public final DecactionContext decaction() throws RecognitionException {
		DecactionContext _localctx = new DecactionContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_decaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(461);
			match(T__27);
			setState(462);
			rawstorage();
			setState(463);
			int();
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
	}

	public final MoveactionContext moveaction() throws RecognitionException {
		MoveactionContext _localctx = new MoveactionContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_moveaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(465);
			match(T__28);
			setState(466);
			card();
			setState(467);
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
	}

	public final CopyactionContext copyaction() throws RecognitionException {
		CopyactionContext _localctx = new CopyactionContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_copyaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(469);
			match(T__29);
			setState(470);
			card();
			setState(471);
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

	public static class RemoveactionContext extends ParserRuleContext {
		public CardContext card() {
			return getRuleContext(CardContext.class,0);
		}
		public RemoveactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_removeaction; }
	}

	public final RemoveactionContext removeaction() throws RecognitionException {
		RemoveactionContext _localctx = new RemoveactionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_removeaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(473);
			match(T__30);
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

	public static class ShuffleactionContext extends ParserRuleContext {
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public ShuffleactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_shuffleaction; }
	}

	public final ShuffleactionContext shuffleaction() throws RecognitionException {
		ShuffleactionContext _localctx = new ShuffleactionContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_shuffleaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(476);
			match(T__31);
			setState(477);
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

	public static class TurnactionContext extends ParserRuleContext {
		public TurnactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_turnaction; }
	}

	public final TurnactionContext turnaction() throws RecognitionException {
		TurnactionContext _localctx = new TurnactionContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_turnaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(479);
			match(T__32);
			setState(480);
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

	public static class RepeatContext extends ParserRuleContext {
		public IntContext int() {
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
	}

	public final RepeatContext repeat() throws RecognitionException {
		RepeatContext _localctx = new RepeatContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_repeat);
		try {
			setState(492);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,31,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(482);
				match(T__34);
				setState(483);
				int();
				setState(484);
				action();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(486);
				match(T__34);
				setState(487);
				match(T__13);
				setState(488);
				match(OPEN);
				setState(489);
				moveaction();
				setState(490);
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
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public CardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_card; }
	}

	public final CardContext card() throws RecognitionException {
		CardContext _localctx = new CardContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_card);
		try {
			setState(507);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(494);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(495);
				maxof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(496);
				minof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(497);
				actual();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(498);
				match(OPEN);
				setState(502);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__35:
					{
					setState(499);
					match(T__35);
					}
					break;
				case T__36:
					{
					setState(500);
					match(T__36);
					}
					break;
				case T__0:
				case INTNUM:
				case OPEN:
					{
					setState(501);
					int();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(504);
				cstorage();
				setState(505);
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
	}

	public final ActualContext actual() throws RecognitionException {
		ActualContext _localctx = new ActualContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_actual);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(509);
			match(OPEN);
			setState(510);
			match(T__37);
			setState(511);
			card();
			setState(512);
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
	}

	public final RawstorageContext rawstorage() throws RecognitionException {
		RawstorageContext _localctx = new RawstorageContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_rawstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(514);
			match(OPEN);
			setState(518);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(515);
				var();
				}
				break;
			case T__1:
				{
				setState(516);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(517);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(520);
			match(T__38);
			setState(521);
			str();
			setState(522);
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
	}

	public final PointstorageContext pointstorage() throws RecognitionException {
		PointstorageContext _localctx = new PointstorageContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_pointstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(524);
			match(OPEN);
			setState(528);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(525);
				var();
				}
				break;
			case T__1:
				{
				setState(526);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(527);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(530);
			match(T__39);
			setState(531);
			str();
			setState(532);
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
	}

	public final StrstorageContext strstorage() throws RecognitionException {
		StrstorageContext _localctx = new StrstorageContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_strstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(534);
			match(OPEN);
			setState(538);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(535);
				var();
				}
				break;
			case T__1:
				{
				setState(536);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(537);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(540);
			match(T__40);
			setState(541);
			str();
			setState(542);
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
	}

	public final CstorageContext cstorage() throws RecognitionException {
		CstorageContext _localctx = new CstorageContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_cstorage);
		try {
			setState(557);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(544);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(545);
				unionof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(546);
				intersectof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(547);
				disjunctionof();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(548);
				sortof();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(549);
				filter();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(550);
				match(OPEN);
				setState(551);
				locpre();
				setState(552);
				locdesc();
				setState(553);
				str();
				setState(554);
				match(CLOSE);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(556);
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

	public static class MemstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public MemsetContext memset() {
			return getRuleContext(MemsetContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public MemstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_memstorage; }
	}

	public final MemstorageContext memstorage() throws RecognitionException {
		MemstorageContext _localctx = new MemstorageContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_memstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(559);
			match(OPEN);
			setState(563);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__35:
				{
				setState(560);
				match(T__35);
				}
				break;
			case T__36:
				{
				setState(561);
				match(T__36);
				}
				break;
			case T__0:
			case INTNUM:
			case OPEN:
				{
				setState(562);
				int();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(565);
			memset();
			setState(566);
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

	public static class MemsetContext extends ParserRuleContext {
		public TupleContext tuple() {
			return getRuleContext(TupleContext.class,0);
		}
		public PartitionContext partition() {
			return getRuleContext(PartitionContext.class,0);
		}
		public MemsetContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_memset; }
	}

	public final MemsetContext memset() throws RecognitionException {
		MemsetContext _localctx = new MemsetContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_memset);
		try {
			setState(570);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(568);
				tuple();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(569);
				partition();
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

	public static class TupleContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int() {
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
	}

	public final TupleContext tuple() throws RecognitionException {
		TupleContext _localctx = new TupleContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_tuple);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(572);
			match(OPEN);
			setState(573);
			match(T__41);
			setState(574);
			int();
			setState(575);
			cstorage();
			setState(576);
			match(T__42);
			setState(577);
			pointstorage();
			setState(578);
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
	}

	public final PartitionContext partition() throws RecognitionException {
		PartitionContext _localctx = new PartitionContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_partition);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(580);
			match(OPEN);
			setState(581);
			match(T__43);
			setState(588);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
			case 1:
				{
				setState(582);
				agg();
				}
				break;
			case 2:
				{
				setState(584); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(583);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(586); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,40,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(590);
			str();
			setState(591);
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
	}

	public final LocpreContext locpre() throws RecognitionException {
		LocpreContext _localctx = new LocpreContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_locpre);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(596);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(593);
				var();
				}
				break;
			case T__1:
				{
				setState(594);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(595);
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

	public static class LocdescContext extends ParserRuleContext {
		public LocdescContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_locdesc; }
	}

	public final LocdescContext locdesc() throws RecognitionException {
		LocdescContext _localctx = new LocdescContext(_ctx, getState());
		enterRule(_localctx, 88, RULE_locdesc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(598);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__44) | (1L << T__45) | (1L << T__46) | (1L << T__47))) != 0)) ) {
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
	}

	public final WhoContext who() throws RecognitionException {
		WhoContext _localctx = new WhoContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_who);
		try {
			setState(602);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(600);
				whot();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(601);
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
	}

	public final WhopContext whop() throws RecognitionException {
		WhopContext _localctx = new WhopContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_whop);
		try {
			setState(610);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,44,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(604);
				match(OPEN);
				setState(605);
				whodesc();
				setState(606);
				match(T__4);
				setState(607);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(609);
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
	}

	public final WhotContext whot() throws RecognitionException {
		WhotContext _localctx = new WhotContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_whot);
		try {
			setState(618);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,45,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(612);
				match(OPEN);
				setState(613);
				whodesc();
				setState(614);
				match(T__5);
				setState(615);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(617);
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

	public static class WhodescContext extends ParserRuleContext {
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public WhodescContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whodesc; }
	}

	public final WhodescContext whodesc() throws RecognitionException {
		WhodescContext _localctx = new WhodescContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_whodesc);
		try {
			setState(624);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case INTNUM:
			case OPEN:
				enterOuterAlt(_localctx, 1);
				{
				setState(620);
				int();
				}
				break;
			case T__25:
				enterOuterAlt(_localctx, 2);
				{
				setState(621);
				match(T__25);
				}
				break;
			case T__23:
				enterOuterAlt(_localctx, 3);
				{
				setState(622);
				match(T__23);
				}
				break;
			case T__24:
				enterOuterAlt(_localctx, 4);
				{
				setState(623);
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
	}

	public final OwnerContext owner() throws RecognitionException {
		OwnerContext _localctx = new OwnerContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_owner);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(626);
			match(OPEN);
			setState(627);
			match(T__48);
			setState(628);
			card();
			setState(629);
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
	}

	public final TeampContext teamp() throws RecognitionException {
		TeampContext _localctx = new TeampContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_teamp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(631);
			match(OPEN);
			setState(632);
			match(T__5);
			setState(633);
			whop();
			setState(634);
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

	public static class OtherContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public OtherContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_other; }
	}

	public final OtherContext other() throws RecognitionException {
		OtherContext _localctx = new OtherContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_other);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(636);
			match(OPEN);
			setState(637);
			match(T__49);
			setState(638);
			_la = _input.LA(1);
			if ( !(_la==T__4 || _la==T__5) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(639);
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

	public static class TypedContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public BooleanContext boolean() {
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
	}

	public final TypedContext typed() throws RecognitionException {
		TypedContext _localctx = new TypedContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_typed);
		try {
			setState(646);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(641);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(642);
				int();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(643);
				boolean();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(644);
				str();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(645);
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
	}

	public final CollectionContext collection() throws RecognitionException {
		CollectionContext _localctx = new CollectionContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_collection);
		try {
			setState(658);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(648);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(649);
				cstorage();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(650);
				strcollection();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(651);
				cstoragecollection();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(652);
				match(T__4);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(653);
				match(T__5);
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(654);
				whot();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(655);
				other();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(656);
				range();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(657);
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
	}

	public final StrcollectionContext strcollection() throws RecognitionException {
		StrcollectionContext _localctx = new StrcollectionContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_strcollection);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(660);
			match(OPEN);
			setState(666);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,49,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(661);
					namegr();
					setState(662);
					match(T__20);
					}
					} 
				}
				setState(668);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,49,_ctx);
			}
			setState(669);
			namegr();
			setState(670);
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
	}

	public final CstoragecollectionContext cstoragecollection() throws RecognitionException {
		CstoragecollectionContext _localctx = new CstoragecollectionContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_cstoragecollection);
		try {
			setState(675);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(672);
				memset();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(673);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(674);
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

	public static class RangeContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RangeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_range; }
	}

	public final RangeContext range() throws RecognitionException {
		RangeContext _localctx = new RangeContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_range);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(677);
			match(OPEN);
			setState(678);
			match(T__50);
			setState(679);
			int();
			setState(680);
			match(T__51);
			setState(681);
			int();
			setState(682);
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

	public static class FilterContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public BooleanContext boolean() {
			return getRuleContext(BooleanContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public FilterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_filter; }
	}

	public final FilterContext filter() throws RecognitionException {
		FilterContext _localctx = new FilterContext(_ctx, getState());
		enterRule(_localctx, 114, RULE_filter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(684);
			match(OPEN);
			setState(685);
			match(T__52);
			setState(686);
			collection();
			setState(687);
			var();
			setState(688);
			boolean();
			setState(689);
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
	}

	public final AttrcompContext attrcomp() throws RecognitionException {
		AttrcompContext _localctx = new AttrcompContext(_ctx, getState());
		enterRule(_localctx, 116, RULE_attrcomp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(691);
			match(EQOP);
			setState(692);
			cardatt();
			setState(693);
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
	}

	public final CardattContext cardatt() throws RecognitionException {
		CardattContext _localctx = new CardattContext(_ctx, getState());
		enterRule(_localctx, 118, RULE_cardatt);
		try {
			setState(702);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(695);
				str();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(696);
				match(OPEN);
				setState(697);
				match(T__53);
				setState(698);
				str();
				setState(699);
				card();
				setState(700);
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

	public static class BooleanContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TerminalNode BOOLOP() { return getToken(RecycleParser.BOOLOP, 0); }
		public List<BooleanContext> boolean() {
			return getRuleContexts(BooleanContext.class);
		}
		public BooleanContext boolean(int i) {
			return getRuleContext(BooleanContext.class,i);
		}
		public IntopContext intop() {
			return getRuleContext(IntopContext.class,0);
		}
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
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
	}

	public final BooleanContext boolean() throws RecognitionException {
		BooleanContext _localctx = new BooleanContext(_ctx, getState());
		enterRule(_localctx, 120, RULE_boolean);
		try {
			int _alt;
			setState(736);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(704);
				match(OPEN);
				setState(731);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,53,_ctx) ) {
				case 1:
					{
					setState(705);
					match(BOOLOP);
					setState(706);
					boolean();
					setState(708); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(707);
							boolean();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(710); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,52,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				case 2:
					{
					setState(712);
					intop();
					setState(713);
					int();
					setState(714);
					int();
					}
					break;
				case 3:
					{
					setState(716);
					attrcomp();
					}
					break;
				case 4:
					{
					setState(717);
					match(EQOP);
					setState(718);
					card();
					setState(719);
					card();
					}
					break;
				case 5:
					{
					setState(721);
					match(UNOP);
					setState(722);
					boolean();
					}
					break;
				case 6:
					{
					setState(723);
					match(EQOP);
					setState(724);
					whop();
					setState(725);
					whop();
					}
					break;
				case 7:
					{
					setState(727);
					match(EQOP);
					setState(728);
					whot();
					setState(729);
					whot();
					}
					break;
				}
				setState(733);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(735);
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

	public static class IntopContext extends ParserRuleContext {
		public TerminalNode COMPOP() { return getToken(RecycleParser.COMPOP, 0); }
		public TerminalNode EQOP() { return getToken(RecycleParser.EQOP, 0); }
		public IntopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intop; }
	}

	public final IntopContext intop() throws RecognitionException {
		IntopContext _localctx = new IntopContext(_ctx, getState());
		enterRule(_localctx, 122, RULE_intop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(738);
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

	public static class AddContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AddContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_add; }
	}

	public final AddContext add() throws RecognitionException {
		AddContext _localctx = new AddContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_add);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(740);
			match(OPEN);
			setState(741);
			match(T__54);
			setState(742);
			int();
			setState(743);
			int();
			setState(744);
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

	public static class MultContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MultContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mult; }
	}

	public final MultContext mult() throws RecognitionException {
		MultContext _localctx = new MultContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_mult);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(746);
			match(OPEN);
			setState(747);
			match(T__55);
			setState(748);
			int();
			setState(749);
			int();
			setState(750);
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

	public static class SubtractContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SubtractContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subtract; }
	}

	public final SubtractContext subtract() throws RecognitionException {
		SubtractContext _localctx = new SubtractContext(_ctx, getState());
		enterRule(_localctx, 128, RULE_subtract);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(752);
			match(OPEN);
			setState(753);
			match(T__56);
			setState(754);
			int();
			setState(755);
			int();
			setState(756);
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

	public static class ModContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ModContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mod; }
	}

	public final ModContext mod() throws RecognitionException {
		ModContext _localctx = new ModContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_mod);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(758);
			match(OPEN);
			setState(759);
			match(T__57);
			setState(760);
			int();
			setState(761);
			int();
			setState(762);
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

	public static class DivideContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public DivideContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_divide; }
	}

	public final DivideContext divide() throws RecognitionException {
		DivideContext _localctx = new DivideContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_divide);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(764);
			match(OPEN);
			setState(765);
			match(T__58);
			setState(766);
			int();
			setState(767);
			int();
			setState(768);
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

	public static class ExponentContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ExponentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exponent; }
	}

	public final ExponentContext exponent() throws RecognitionException {
		ExponentContext _localctx = new ExponentContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_exponent);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(770);
			match(OPEN);
			setState(771);
			match(T__59);
			setState(772);
			int();
			setState(773);
			int();
			setState(774);
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

	public static class TriangularContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public TriangularContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_triangular; }
	}

	public final TriangularContext triangular() throws RecognitionException {
		TriangularContext _localctx = new TriangularContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_triangular);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(776);
			match(OPEN);
			setState(777);
			match(T__60);
			setState(778);
			int();
			setState(779);
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

	public static class FibonacciContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public FibonacciContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fibonacci; }
	}

	public final FibonacciContext fibonacci() throws RecognitionException {
		FibonacciContext _localctx = new FibonacciContext(_ctx, getState());
		enterRule(_localctx, 138, RULE_fibonacci);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(781);
			match(OPEN);
			setState(782);
			match(T__61);
			setState(783);
			int();
			setState(784);
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

	public static class RandomContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<IntContext> int() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RandomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_random; }
	}

	public final RandomContext random() throws RecognitionException {
		RandomContext _localctx = new RandomContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_random);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(786);
			match(OPEN);
			setState(787);
			match(T__62);
			setState(788);
			int();
			setState(789);
			match(T__51);
			setState(791);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__0 || _la==INTNUM || _la==OPEN) {
				{
				setState(790);
				int();
				}
			}

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
	}

	public final SizeofContext sizeof() throws RecognitionException {
		SizeofContext _localctx = new SizeofContext(_ctx, getState());
		enterRule(_localctx, 142, RULE_sizeof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(795);
			match(OPEN);
			setState(796);
			match(T__63);
			setState(800);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,56,_ctx) ) {
			case 1:
				{
				setState(797);
				var();
				}
				break;
			case 2:
				{
				setState(798);
				cstorage();
				}
				break;
			case 3:
				{
				setState(799);
				memset();
				}
				break;
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
	}

	public final MaxofContext maxof() throws RecognitionException {
		MaxofContext _localctx = new MaxofContext(_ctx, getState());
		enterRule(_localctx, 144, RULE_maxof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(804);
			match(OPEN);
			setState(805);
			match(T__8);
			setState(806);
			cstorage();
			setState(807);
			match(T__42);
			setState(808);
			pointstorage();
			setState(809);
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
	}

	public final MinofContext minof() throws RecognitionException {
		MinofContext _localctx = new MinofContext(_ctx, getState());
		enterRule(_localctx, 146, RULE_minof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(811);
			match(OPEN);
			setState(812);
			match(T__7);
			setState(813);
			cstorage();
			setState(814);
			match(T__42);
			setState(815);
			pointstorage();
			setState(816);
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
	}

	public final SortofContext sortof() throws RecognitionException {
		SortofContext _localctx = new SortofContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_sortof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(818);
			match(OPEN);
			setState(819);
			match(T__64);
			setState(820);
			cstorage();
			setState(821);
			match(T__42);
			setState(822);
			pointstorage();
			setState(823);
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
	}

	public final UnionofContext unionof() throws RecognitionException {
		UnionofContext _localctx = new UnionofContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_unionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(825);
			match(OPEN);
			setState(826);
			match(T__65);
			setState(833);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,58,_ctx) ) {
			case 1:
				{
				setState(827);
				agg();
				}
				break;
			case 2:
				{
				setState(829); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(828);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(831); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,57,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(835);
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

	public static class IntersectofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<AggContext> agg() {
			return getRuleContexts(AggContext.class);
		}
		public AggContext agg(int i) {
			return getRuleContext(AggContext.class,i);
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
	}

	public final IntersectofContext intersectof() throws RecognitionException {
		IntersectofContext _localctx = new IntersectofContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_intersectof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(837);
			match(OPEN);
			setState(838);
			match(T__66);
			setState(845);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,60,_ctx) ) {
			case 1:
				{
				setState(839);
				agg();
				}
				break;
			case 2:
				{
				setState(841); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(840);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(843); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,59,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(853);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,62,_ctx) ) {
			case 1:
				{
				setState(847);
				agg();
				}
				break;
			case 2:
				{
				setState(849); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(848);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(851); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,61,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(855);
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

	public static class DisjunctionofContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public List<AggContext> agg() {
			return getRuleContexts(AggContext.class);
		}
		public AggContext agg(int i) {
			return getRuleContext(AggContext.class,i);
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
	}

	public final DisjunctionofContext disjunctionof() throws RecognitionException {
		DisjunctionofContext _localctx = new DisjunctionofContext(_ctx, getState());
		enterRule(_localctx, 154, RULE_disjunctionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(857);
			match(OPEN);
			setState(858);
			match(T__67);
			setState(865);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,64,_ctx) ) {
			case 1:
				{
				setState(859);
				agg();
				}
				break;
			case 2:
				{
				setState(861); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(860);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(863); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,63,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(873);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,66,_ctx) ) {
			case 1:
				{
				setState(867);
				agg();
				}
				break;
			case 2:
				{
				setState(869); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(868);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(871); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,65,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
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
	}

	public final SumContext sum() throws RecognitionException {
		SumContext _localctx = new SumContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(877);
			match(OPEN);
			setState(878);
			match(T__68);
			setState(879);
			cstorage();
			setState(880);
			match(T__42);
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
	}

	public final ScoreContext score() throws RecognitionException {
		ScoreContext _localctx = new ScoreContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_score);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(884);
			match(OPEN);
			setState(885);
			match(T__69);
			setState(886);
			card();
			setState(887);
			match(T__42);
			setState(888);
			pointstorage();
			setState(889);
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
	}

	public final IntContext int() throws RecognitionException {
		IntContext _localctx = new IntContext(_ctx, getState());
		enterRule(_localctx, 160, RULE_int);
		try {
			int _alt;
			setState(910);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,68,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(891);
				var();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(892);
				sizeof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(893);
				mult();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(894);
				subtract();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(895);
				mod();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(896);
				add();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(897);
				divide();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(898);
				exponent();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(899);
				triangular();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(900);
				fibonacci();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(901);
				random();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 12);
				{
				setState(902);
				sum();
				}
				break;
			case 13:
				enterOuterAlt(_localctx, 13);
				{
				setState(903);
				rawstorage();
				}
				break;
			case 14:
				enterOuterAlt(_localctx, 14);
				{
				setState(904);
				score();
				}
				break;
			case 15:
				enterOuterAlt(_localctx, 15);
				{
				setState(906); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(905);
						match(INTNUM);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(908); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,67,_ctx);
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
	}

	public final StrContext str() throws RecognitionException {
		StrContext _localctx = new StrContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_str);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(915);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LETT:
				{
				setState(912);
				namegr();
				}
				break;
			case OPEN:
				{
				setState(913);
				strstorage();
				}
				break;
			case T__0:
				{
				setState(914);
				var();
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

	public static class NamegrContext extends ParserRuleContext {
		public List<TerminalNode> LETT() { return getTokens(RecycleParser.LETT); }
		public TerminalNode LETT(int i) {
			return getToken(RecycleParser.LETT, i);
		}
		public NamegrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_namegr; }
	}

	public final NamegrContext namegr() throws RecognitionException {
		NamegrContext _localctx = new NamegrContext(_ctx, getState());
		enterRule(_localctx, 164, RULE_namegr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(918); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(917);
					match(LETT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(920); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,70,_ctx);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3R\u039d\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\4I"+
		"\tI\4J\tJ\4K\tK\4L\tL\4M\tM\4N\tN\4O\tO\4P\tP\4Q\tQ\4R\tR\4S\tS\4T\tT"+
		"\3\2\3\2\3\2\3\3\3\3\3\3\7\3\u00af\n\3\f\3\16\3\u00b2\13\3\3\3\3\3\3\3"+
		"\6\3\u00b7\n\3\r\3\16\3\u00b8\3\3\3\3\3\3\3\4\3\4\3\4\3\4\5\4\u00c2\n"+
		"\4\3\4\3\4\3\4\5\4\u00c7\n\4\3\4\3\4\6\4\u00cb\n\4\r\4\16\4\u00cc\3\4"+
		"\3\4\3\5\3\5\3\5\3\5\3\5\3\5\6\5\u00d7\n\5\r\5\16\5\u00d8\3\5\3\5\3\6"+
		"\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\3\b\3\b\3\b\3\b\3\b\5\b\u00f6\n\b\3\b\3\b\3\b\5\b\u00fb\n\b\3\t"+
		"\3\t\3\t\3\t\6\t\u0101\n\t\r\t\16\t\u0102\3\t\3\t\3\t\3\t\3\t\3\t\3\t"+
		"\6\t\u010c\n\t\r\t\16\t\u010d\3\t\3\t\3\t\3\t\3\t\5\t\u0115\n\t\3\n\3"+
		"\n\3\n\3\n\6\n\u011b\n\n\r\n\16\n\u011c\3\n\3\n\3\n\3\n\3\n\5\n\u0124"+
		"\n\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\5\13"+
		"\u0132\n\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\5\f\u013c\n\f\3\f\3\f\3\r"+
		"\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u0147\n\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\17\3\17\3\17\3\17\3\17\5\17\u0156\n\17\3\17\3\17\3\20\3\20\3\20"+
		"\3\20\6\20\u015e\n\20\r\20\16\20\u015f\3\20\3\20\3\21\3\21\3\21\5\21\u0167"+
		"\n\21\3\21\3\21\3\21\3\22\3\22\3\22\6\22\u016f\n\22\r\22\16\22\u0170\3"+
		"\22\3\22\3\23\3\23\3\23\7\23\u0178\n\23\f\23\16\23\u017b\13\23\3\23\3"+
		"\23\7\23\u017f\n\23\f\23\16\23\u0182\13\23\3\23\3\23\3\24\3\24\3\24\3"+
		"\24\3\24\3\24\3\24\3\24\7\24\u018e\n\24\f\24\16\24\u0191\13\24\3\24\3"+
		"\24\7\24\u0195\n\24\f\24\16\24\u0198\13\24\3\24\3\24\5\24\u019c\n\24\3"+
		"\25\3\25\3\25\3\25\6\25\u01a2\n\25\r\25\16\25\u01a3\3\25\3\25\3\26\3\26"+
		"\6\26\u01aa\n\26\r\26\16\26\u01ab\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3"+
		"\27\3\27\3\27\5\27\u01b8\n\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\30"+
		"\5\30\u01c2\n\30\3\31\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\33\3\33\3\33"+
		"\3\33\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\37"+
		"\3\37\3\37\3 \3 \3 \3!\3!\3!\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\3\"\5"+
		"\"\u01ef\n\"\3#\3#\3#\3#\3#\3#\3#\3#\5#\u01f9\n#\3#\3#\3#\5#\u01fe\n#"+
		"\3$\3$\3$\3$\3$\3%\3%\3%\3%\5%\u0209\n%\3%\3%\3%\3%\3&\3&\3&\3&\5&\u0213"+
		"\n&\3&\3&\3&\3&\3\'\3\'\3\'\3\'\5\'\u021d\n\'\3\'\3\'\3\'\3\'\3(\3(\3"+
		"(\3(\3(\3(\3(\3(\3(\3(\3(\3(\3(\5(\u0230\n(\3)\3)\3)\3)\5)\u0236\n)\3"+
		")\3)\3)\3*\3*\5*\u023d\n*\3+\3+\3+\3+\3+\3+\3+\3+\3,\3,\3,\3,\6,\u024b"+
		"\n,\r,\16,\u024c\5,\u024f\n,\3,\3,\3,\3-\3-\3-\5-\u0257\n-\3.\3.\3/\3"+
		"/\5/\u025d\n/\3\60\3\60\3\60\3\60\3\60\3\60\5\60\u0265\n\60\3\61\3\61"+
		"\3\61\3\61\3\61\3\61\5\61\u026d\n\61\3\62\3\62\3\62\3\62\5\62\u0273\n"+
		"\62\3\63\3\63\3\63\3\63\3\63\3\64\3\64\3\64\3\64\3\64\3\65\3\65\3\65\3"+
		"\65\3\65\3\66\3\66\3\66\3\66\3\66\5\66\u0289\n\66\3\67\3\67\3\67\3\67"+
		"\3\67\3\67\3\67\3\67\3\67\3\67\5\67\u0295\n\67\38\38\38\38\78\u029b\n"+
		"8\f8\168\u029e\138\38\38\38\39\39\39\59\u02a6\n9\3:\3:\3:\3:\3:\3:\3:"+
		"\3;\3;\3;\3;\3;\3;\3;\3<\3<\3<\3<\3=\3=\3=\3=\3=\3=\3=\5=\u02c1\n=\3>"+
		"\3>\3>\3>\6>\u02c7\n>\r>\16>\u02c8\3>\3>\3>\3>\3>\3>\3>\3>\3>\3>\3>\3"+
		">\3>\3>\3>\3>\3>\3>\3>\5>\u02de\n>\3>\3>\3>\5>\u02e3\n>\3?\3?\3@\3@\3"+
		"@\3@\3@\3@\3A\3A\3A\3A\3A\3A\3B\3B\3B\3B\3B\3B\3C\3C\3C\3C\3C\3C\3D\3"+
		"D\3D\3D\3D\3D\3E\3E\3E\3E\3E\3E\3F\3F\3F\3F\3F\3G\3G\3G\3G\3G\3H\3H\3"+
		"H\3H\3H\5H\u031a\nH\3H\3H\3I\3I\3I\3I\3I\5I\u0323\nI\3I\3I\3J\3J\3J\3"+
		"J\3J\3J\3J\3K\3K\3K\3K\3K\3K\3K\3L\3L\3L\3L\3L\3L\3L\3M\3M\3M\3M\6M\u0340"+
		"\nM\rM\16M\u0341\5M\u0344\nM\3M\3M\3N\3N\3N\3N\6N\u034c\nN\rN\16N\u034d"+
		"\5N\u0350\nN\3N\3N\6N\u0354\nN\rN\16N\u0355\5N\u0358\nN\3N\3N\3O\3O\3"+
		"O\3O\6O\u0360\nO\rO\16O\u0361\5O\u0364\nO\3O\3O\6O\u0368\nO\rO\16O\u0369"+
		"\5O\u036c\nO\3O\3O\3P\3P\3P\3P\3P\3P\3P\3Q\3Q\3Q\3Q\3Q\3Q\3Q\3R\3R\3R"+
		"\3R\3R\3R\3R\3R\3R\3R\3R\3R\3R\3R\3R\6R\u038d\nR\rR\16R\u038e\5R\u0391"+
		"\nR\3S\3S\3S\5S\u0396\nS\3T\6T\u0399\nT\rT\16T\u039a\3T\31\u00b0\u00b8"+
		"\u00cc\u00d8\u0102\u010d\u011c\u015f\u0170\u0179\u0180\u018f\u0196\u01a3"+
		"\u01ab\u024c\u029c\u02c8\u0341\u034d\u0355\u0361\u0369\2U\2\4\6\b\n\f"+
		"\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@BDFHJLNPRTVXZ\\^"+
		"`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086\u0088\u008a\u008c\u008e\u0090"+
		"\u0092\u0094\u0096\u0098\u009a\u009c\u009e\u00a0\u00a2\u00a4\u00a6\2\b"+
		"\3\2\7\b\3\2\n\13\3\2\17\20\3\2\32\33\3\2/\62\3\2JK\2\u03d6\2\u00a8\3"+
		"\2\2\2\4\u00ab\3\2\2\2\6\u00bd\3\2\2\2\b\u00d0\3\2\2\2\n\u00dc\3\2\2\2"+
		"\f\u00e2\3\2\2\2\16\u00fa\3\2\2\2\20\u0114\3\2\2\2\22\u0123\3\2\2\2\24"+
		"\u0131\3\2\2\2\26\u0133\3\2\2\2\30\u013f\3\2\2\2\32\u014a\3\2\2\2\34\u0150"+
		"\3\2\2\2\36\u0159\3\2\2\2 \u0163\3\2\2\2\"\u016b\3\2\2\2$\u0174\3\2\2"+
		"\2&\u019b\3\2\2\2(\u019d\3\2\2\2*\u01a7\3\2\2\2,\u01b0\3\2\2\2.\u01bb"+
		"\3\2\2\2\60\u01c3\3\2\2\2\62\u01c7\3\2\2\2\64\u01cb\3\2\2\2\66\u01cf\3"+
		"\2\2\28\u01d3\3\2\2\2:\u01d7\3\2\2\2<\u01db\3\2\2\2>\u01de\3\2\2\2@\u01e1"+
		"\3\2\2\2B\u01ee\3\2\2\2D\u01fd\3\2\2\2F\u01ff\3\2\2\2H\u0204\3\2\2\2J"+
		"\u020e\3\2\2\2L\u0218\3\2\2\2N\u022f\3\2\2\2P\u0231\3\2\2\2R\u023c\3\2"+
		"\2\2T\u023e\3\2\2\2V\u0246\3\2\2\2X\u0256\3\2\2\2Z\u0258\3\2\2\2\\\u025c"+
		"\3\2\2\2^\u0264\3\2\2\2`\u026c\3\2\2\2b\u0272\3\2\2\2d\u0274\3\2\2\2f"+
		"\u0279\3\2\2\2h\u027e\3\2\2\2j\u0288\3\2\2\2l\u0294\3\2\2\2n\u0296\3\2"+
		"\2\2p\u02a5\3\2\2\2r\u02a7\3\2\2\2t\u02ae\3\2\2\2v\u02b5\3\2\2\2x\u02c0"+
		"\3\2\2\2z\u02e2\3\2\2\2|\u02e4\3\2\2\2~\u02e6\3\2\2\2\u0080\u02ec\3\2"+
		"\2\2\u0082\u02f2\3\2\2\2\u0084\u02f8\3\2\2\2\u0086\u02fe\3\2\2\2\u0088"+
		"\u0304\3\2\2\2\u008a\u030a\3\2\2\2\u008c\u030f\3\2\2\2\u008e\u0314\3\2"+
		"\2\2\u0090\u031d\3\2\2\2\u0092\u0326\3\2\2\2\u0094\u032d\3\2\2\2\u0096"+
		"\u0334\3\2\2\2\u0098\u033b\3\2\2\2\u009a\u0347\3\2\2\2\u009c\u035b\3\2"+
		"\2\2\u009e\u036f\3\2\2\2\u00a0\u0376\3\2\2\2\u00a2\u0390\3\2\2\2\u00a4"+
		"\u0395\3\2\2\2\u00a6\u0398\3\2\2\2\u00a8\u00a9\7\3\2\2\u00a9\u00aa\5\u00a6"+
		"T\2\u00aa\3\3\2\2\2\u00ab\u00ac\7O\2\2\u00ac\u00b0\7\4\2\2\u00ad\u00af"+
		"\5\32\16\2\u00ae\u00ad\3\2\2\2\u00af\u00b2\3\2\2\2\u00b0\u00b1\3\2\2\2"+
		"\u00b0\u00ae\3\2\2\2\u00b1\u00b3\3\2\2\2\u00b2\u00b0\3\2\2\2\u00b3\u00b6"+
		"\5\6\4\2\u00b4\u00b7\5\20\t\2\u00b5\u00b7\5\b\5\2\u00b6\u00b4\3\2\2\2"+
		"\u00b6\u00b5\3\2\2\2\u00b7\u00b8\3\2\2\2\u00b8\u00b9\3\2\2\2\u00b8\u00b6"+
		"\3\2\2\2\u00b9\u00ba\3\2\2\2\u00ba\u00bb\5\n\6\2\u00bb\u00bc\7P\2\2\u00bc"+
		"\5\3\2\2\2\u00bd\u00be\7O\2\2\u00be\u00bf\7\5\2\2\u00bf\u00c1\5\34\17"+
		"\2\u00c0\u00c2\5\36\20\2\u00c1\u00c0\3\2\2\2\u00c1\u00c2\3\2\2\2\u00c2"+
		"\u00ca\3\2\2\2\u00c3\u00c6\7O\2\2\u00c4\u00c7\5 \21\2\u00c5\u00c7\5B\""+
		"\2\u00c6\u00c4\3\2\2\2\u00c6\u00c5\3\2\2\2\u00c7\u00c8\3\2\2\2\u00c8\u00c9"+
		"\7P\2\2\u00c9\u00cb\3\2\2\2\u00ca\u00c3\3\2\2\2\u00cb\u00cc\3\2\2\2\u00cc"+
		"\u00cd\3\2\2\2\u00cc\u00ca\3\2\2\2\u00cd\u00ce\3\2\2\2\u00ce\u00cf\7P"+
		"\2\2\u00cf\7\3\2\2\2\u00d0\u00d1\7O\2\2\u00d1\u00d2\7\6\2\2\u00d2\u00d3"+
		"\t\2\2\2\u00d3\u00d6\5\f\7\2\u00d4\u00d7\5\20\t\2\u00d5\u00d7\5\b\5\2"+
		"\u00d6\u00d4\3\2\2\2\u00d6\u00d5\3\2\2\2\u00d7\u00d8\3\2\2\2\u00d8\u00d9"+
		"\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00da\3\2\2\2\u00da\u00db\7P\2\2\u00db"+
		"\t\3\2\2\2\u00dc\u00dd\7O\2\2\u00dd\u00de\7\t\2\2\u00de\u00df\t\3\2\2"+
		"\u00df\u00e0\5\u00a2R\2\u00e0\u00e1\7P\2\2\u00e1\13\3\2\2\2\u00e2\u00e3"+
		"\7O\2\2\u00e3\u00e4\7\f\2\2\u00e4\u00e5\5z>\2\u00e5\u00e6\7P\2\2\u00e6"+
		"\r\3\2\2\2\u00e7\u00f5\7O\2\2\u00e8\u00f6\5(\25\2\u00e9\u00f6\5\36\20"+
		"\2\u00ea\u00f6\5 \21\2\u00eb\u00f6\5.\30\2\u00ec\u00f6\5\60\31\2\u00ed"+
		"\u00f6\58\35\2\u00ee\u00f6\5:\36\2\u00ef\u00f6\5\64\33\2\u00f0\u00f6\5"+
		"\66\34\2\u00f1\u00f6\5<\37\2\u00f2\u00f6\5@!\2\u00f3\u00f6\5> \2\u00f4"+
		"\u00f6\5B\"\2\u00f5\u00e8\3\2\2\2\u00f5\u00e9\3\2\2\2\u00f5\u00ea\3\2"+
		"\2\2\u00f5\u00eb\3\2\2\2\u00f5\u00ec\3\2\2\2\u00f5\u00ed\3\2\2\2\u00f5"+
		"\u00ee\3\2\2\2\u00f5\u00ef\3\2\2\2\u00f5\u00f0\3\2\2\2\u00f5\u00f1\3\2"+
		"\2\2\u00f5\u00f2\3\2\2\2\u00f5\u00f3\3\2\2\2\u00f5\u00f4\3\2\2\2\u00f6"+
		"\u00f7\3\2\2\2\u00f7\u00f8\7P\2\2\u00f8\u00fb\3\2\2\2\u00f9\u00fb\5\26"+
		"\f\2\u00fa\u00e7\3\2\2\2\u00fa\u00f9\3\2\2\2\u00fb\17\3\2\2\2\u00fc\u00fd"+
		"\7O\2\2\u00fd\u00fe\7\r\2\2\u00fe\u0100\7O\2\2\u00ff\u0101\5\24\13\2\u0100"+
		"\u00ff\3\2\2\2\u0101\u0102\3\2\2\2\u0102\u0103\3\2\2\2\u0102\u0100\3\2"+
		"\2\2\u0103\u0104\3\2\2\2\u0104\u0105\7P\2\2\u0105\u0106\7P\2\2\u0106\u0115"+
		"\3\2\2\2\u0107\u0108\7O\2\2\u0108\u0109\7\16\2\2\u0109\u010b\7O\2\2\u010a"+
		"\u010c\5\24\13\2\u010b\u010a\3\2\2\2\u010c\u010d\3\2\2\2\u010d\u010e\3"+
		"\2\2\2\u010d\u010b\3\2\2\2\u010e\u010f\3\2\2\2\u010f\u0110\7P\2\2\u0110"+
		"\u0111\7P\2\2\u0111\u0115\3\2\2\2\u0112\u0115\5\26\f\2\u0113\u0115\5\30"+
		"\r\2\u0114\u00fc\3\2\2\2\u0114\u0107\3\2\2\2\u0114\u0112\3\2\2\2\u0114"+
		"\u0113\3\2\2\2\u0115\21\3\2\2\2\u0116\u0117\7O\2\2\u0117\u0118\7\16\2"+
		"\2\u0118\u011a\7O\2\2\u0119\u011b\5\24\13\2\u011a\u0119\3\2\2\2\u011b"+
		"\u011c\3\2\2\2\u011c\u011d\3\2\2\2\u011c\u011a\3\2\2\2\u011d\u011e\3\2"+
		"\2\2\u011e\u011f\7P\2\2\u011f\u0120\7P\2\2\u0120\u0124\3\2\2\2\u0121\u0124"+
		"\5\26\f\2\u0122\u0124\5\30\r\2\u0123\u0116\3\2\2\2\u0123\u0121\3\2\2\2"+
		"\u0123\u0122\3\2\2\2\u0124\23\3\2\2\2\u0125\u0126\7O\2\2\u0126\u0127\5"+
		"z>\2\u0127\u0128\5\22\n\2\u0128\u0129\7P\2\2\u0129\u0132\3\2\2\2\u012a"+
		"\u0132\5\22\n\2\u012b\u012c\7O\2\2\u012c\u012d\5z>\2\u012d\u012e\5\16"+
		"\b\2\u012e\u012f\7P\2\2\u012f\u0132\3\2\2\2\u0130\u0132\5\16\b\2\u0131"+
		"\u0125\3\2\2\2\u0131\u012a\3\2\2\2\u0131\u012b\3\2\2\2\u0131\u0130\3\2"+
		"\2\2\u0132\25\3\2\2\2\u0133\u0134\7O\2\2\u0134\u0135\t\4\2\2\u0135\u0136"+
		"\5l\67\2\u0136\u013b\5\2\2\2\u0137\u013c\5\24\13\2\u0138\u013c\5z>\2\u0139"+
		"\u013c\5N(\2\u013a\u013c\5H%\2\u013b\u0137\3\2\2\2\u013b\u0138\3\2\2\2"+
		"\u013b\u0139\3\2\2\2\u013b\u013a\3\2\2\2\u013c\u013d\3\2\2\2\u013d\u013e"+
		"\7P\2\2\u013e\27\3\2\2\2\u013f\u0140\7O\2\2\u0140\u0141\7\21\2\2\u0141"+
		"\u0142\5j\66\2\u0142\u0146\5\2\2\2\u0143\u0147\5\20\t\2\u0144\u0147\5"+
		"\16\b\2\u0145\u0147\5\24\13\2\u0146\u0143\3\2\2\2\u0146\u0144\3\2\2\2"+
		"\u0146\u0145\3\2\2\2\u0147\u0148\3\2\2\2\u0148\u0149\7P\2\2\u0149\31\3"+
		"\2\2\2\u014a\u014b\7O\2\2\u014b\u014c\7\22\2\2\u014c\u014d\5j\66\2\u014d"+
		"\u014e\5\2\2\2\u014e\u014f\7P\2\2\u014f\33\3\2\2\2\u0150\u0151\7O\2\2"+
		"\u0151\u0152\7\23\2\2\u0152\u0155\7\24\2\2\u0153\u0156\5\2\2\2\u0154\u0156"+
		"\5\u00a2R\2\u0155\u0153\3\2\2\2\u0155\u0154\3\2\2\2\u0156\u0157\3\2\2"+
		"\2\u0157\u0158\7P\2\2\u0158\35\3\2\2\2\u0159\u015a\7O\2\2\u015a\u015b"+
		"\7\23\2\2\u015b\u015d\7\25\2\2\u015c\u015e\5$\23\2\u015d\u015c\3\2\2\2"+
		"\u015e\u015f\3\2\2\2\u015f\u0160\3\2\2\2\u015f\u015d\3\2\2\2\u0160\u0161"+
		"\3\2\2\2\u0161\u0162\7P\2\2\u0162\37\3\2\2\2\u0163\u0164\7\23\2\2\u0164"+
		"\u0166\7\26\2\2\u0165\u0167\5\u00a4S\2\u0166\u0165\3\2\2\2\u0166\u0167"+
		"\3\2\2\2\u0167\u0168\3\2\2\2\u0168\u0169\5N(\2\u0169\u016a\5\"\22\2\u016a"+
		"!\3\2\2\2\u016b\u016c\7O\2\2\u016c\u016e\7\26\2\2\u016d\u016f\5&\24\2"+
		"\u016e\u016d\3\2\2\2\u016f\u0170\3\2\2\2\u0170\u0171\3\2\2\2\u0170\u016e"+
		"\3\2\2\2\u0171\u0172\3\2\2\2\u0172\u0173\7P\2\2\u0173#\3\2\2\2\u0174\u0179"+
		"\7O\2\2\u0175\u0176\7M\2\2\u0176\u0178\7\27\2\2\u0177\u0175\3\2\2\2\u0178"+
		"\u017b\3\2\2\2\u0179\u017a\3\2\2\2\u0179\u0177\3\2\2\2\u017a\u017c\3\2"+
		"\2\2\u017b\u0179\3\2\2\2\u017c\u0180\7M\2\2\u017d\u017f\5$\23\2\u017e"+
		"\u017d\3\2\2\2\u017f\u0182\3\2\2\2\u0180\u0181\3\2\2\2\u0180\u017e\3\2"+
		"\2\2\u0181\u0183\3\2\2\2\u0182\u0180\3\2\2\2\u0183\u0184\7P\2\2\u0184"+
		"%\3\2\2\2\u0185\u0186\7O\2\2\u0186\u0187\5\2\2\2\u0187\u0188\7P\2\2\u0188"+
		"\u019c\3\2\2\2\u0189\u018f\7O\2\2\u018a\u018b\5\u00a6T\2\u018b\u018c\7"+
		"\27\2\2\u018c\u018e\3\2\2\2\u018d\u018a\3\2\2\2\u018e\u0191\3\2\2\2\u018f"+
		"\u0190\3\2\2\2\u018f\u018d\3\2\2\2\u0190\u0192\3\2\2\2\u0191\u018f\3\2"+
		"\2\2\u0192\u0196\5\u00a6T\2\u0193\u0195\5&\24\2\u0194\u0193\3\2\2\2\u0195"+
		"\u0198\3\2\2\2\u0196\u0197\3\2\2\2\u0196\u0194\3\2\2\2\u0197\u0199\3\2"+
		"\2\2\u0198\u0196\3\2\2\2\u0199\u019a\7P\2\2\u019a\u019c\3\2\2\2\u019b"+
		"\u0185\3\2\2\2\u019b\u0189\3\2\2\2\u019c\'\3\2\2\2\u019d\u019e\7\30\2"+
		"\2\u019e\u019f\5J&\2\u019f\u01a1\7O\2\2\u01a0\u01a2\5*\26\2\u01a1\u01a0"+
		"\3\2\2\2\u01a2\u01a3\3\2\2\2\u01a3\u01a4\3\2\2\2\u01a3\u01a1\3\2\2\2\u01a4"+
		"\u01a5\3\2\2\2\u01a5\u01a6\7P\2\2\u01a6)\3\2\2\2\u01a7\u01a9\7O\2\2\u01a8"+
		"\u01aa\5,\27\2\u01a9\u01a8\3\2\2\2\u01aa\u01ab\3\2\2\2\u01ab\u01ac\3\2"+
		"\2\2\u01ab\u01a9\3\2\2\2\u01ac\u01ad\3\2\2\2\u01ad\u01ae\5\u00a2R\2\u01ae"+
		"\u01af\7P\2\2\u01af+\3\2\2\2\u01b0\u01b1\7O\2\2\u01b1\u01b7\5\u00a4S\2"+
		"\u01b2\u01b3\7O\2\2\u01b3\u01b4\5\u00a4S\2\u01b4\u01b5\7P\2\2\u01b5\u01b8"+
		"\3\2\2\2\u01b6\u01b8\5x=\2\u01b7\u01b2\3\2\2\2\u01b7\u01b6\3\2\2\2\u01b8"+
		"\u01b9\3\2\2\2\u01b9\u01ba\7P\2\2\u01ba-\3\2\2\2\u01bb\u01bc\7\31\2\2"+
		"\u01bc\u01c1\t\5\2\2\u01bd\u01c2\5d\63\2\u01be\u01c2\7\33\2\2\u01bf\u01c2"+
		"\7\32\2\2\u01c0\u01c2\7\34\2\2\u01c1\u01bd\3\2\2\2\u01c1\u01be\3\2\2\2"+
		"\u01c1\u01bf\3\2\2\2\u01c1\u01c0\3\2\2\2\u01c2/\3\2\2\2\u01c3\u01c4\7"+
		"\30\2\2\u01c4\u01c5\5H%\2\u01c5\u01c6\5\u00a2R\2\u01c6\61\3\2\2\2\u01c7"+
		"\u01c8\7\30\2\2\u01c8\u01c9\5L\'\2\u01c9\u01ca\5\u00a4S\2\u01ca\63\3\2"+
		"\2\2\u01cb\u01cc\7\35\2\2\u01cc\u01cd\5H%\2\u01cd\u01ce\5\u00a2R\2\u01ce"+
		"\65\3\2\2\2\u01cf\u01d0\7\36\2\2\u01d0\u01d1\5H%\2\u01d1\u01d2\5\u00a2"+
		"R\2\u01d2\67\3\2\2\2\u01d3\u01d4\7\37\2\2\u01d4\u01d5\5D#\2\u01d5\u01d6"+
		"\5D#\2\u01d69\3\2\2\2\u01d7\u01d8\7 \2\2\u01d8\u01d9\5D#\2\u01d9\u01da"+
		"\5D#\2\u01da;\3\2\2\2\u01db\u01dc\7!\2\2\u01dc\u01dd\5D#\2\u01dd=\3\2"+
		"\2\2\u01de\u01df\7\"\2\2\u01df\u01e0\5N(\2\u01e0?\3\2\2\2\u01e1\u01e2"+
		"\7#\2\2\u01e2\u01e3\7$\2\2\u01e3A\3\2\2\2\u01e4\u01e5\7%\2\2\u01e5\u01e6"+
		"\5\u00a2R\2\u01e6\u01e7\5\16\b\2\u01e7\u01ef\3\2\2\2\u01e8\u01e9\7%\2"+
		"\2\u01e9\u01ea\7\20\2\2\u01ea\u01eb\7O\2\2\u01eb\u01ec\58\35\2\u01ec\u01ed"+
		"\7P\2\2\u01ed\u01ef\3\2\2\2\u01ee\u01e4\3\2\2\2\u01ee\u01e8\3\2\2\2\u01ef"+
		"C\3\2\2\2\u01f0\u01fe\5\2\2\2\u01f1\u01fe\5\u0092J\2\u01f2\u01fe\5\u0094"+
		"K\2\u01f3\u01fe\5F$\2\u01f4\u01f8\7O\2\2\u01f5\u01f9\7&\2\2\u01f6\u01f9"+
		"\7\'\2\2\u01f7\u01f9\5\u00a2R\2\u01f8\u01f5\3\2\2\2\u01f8\u01f6\3\2\2"+
		"\2\u01f8\u01f7\3\2\2\2\u01f9\u01fa\3\2\2\2\u01fa\u01fb\5N(\2\u01fb\u01fc"+
		"\7P\2\2\u01fc\u01fe\3\2\2\2\u01fd\u01f0\3\2\2\2\u01fd\u01f1\3\2\2\2\u01fd"+
		"\u01f2\3\2\2\2\u01fd\u01f3\3\2\2\2\u01fd\u01f4\3\2\2\2\u01feE\3\2\2\2"+
		"\u01ff\u0200\7O\2\2\u0200\u0201\7(\2\2\u0201\u0202\5D#\2\u0202\u0203\7"+
		"P\2\2\u0203G\3\2\2\2\u0204\u0208\7O\2\2\u0205\u0209\5\2\2\2\u0206\u0209"+
		"\7\4\2\2\u0207\u0209\5\\/\2\u0208\u0205\3\2\2\2\u0208\u0206\3\2\2\2\u0208"+
		"\u0207\3\2\2\2\u0209\u020a\3\2\2\2\u020a\u020b\7)\2\2\u020b\u020c\5\u00a4"+
		"S\2\u020c\u020d\7P\2\2\u020dI\3\2\2\2\u020e\u0212\7O\2\2\u020f\u0213\5"+
		"\2\2\2\u0210\u0213\7\4\2\2\u0211\u0213\5\\/\2\u0212\u020f\3\2\2\2\u0212"+
		"\u0210\3\2\2\2\u0212\u0211\3\2\2\2\u0213\u0214\3\2\2\2\u0214\u0215\7*"+
		"\2\2\u0215\u0216\5\u00a4S\2\u0216\u0217\7P\2\2\u0217K\3\2\2\2\u0218\u021c"+
		"\7O\2\2\u0219\u021d\5\2\2\2\u021a\u021d\7\4\2\2\u021b\u021d\5\\/\2\u021c"+
		"\u0219\3\2\2\2\u021c\u021a\3\2\2\2\u021c\u021b\3\2\2\2\u021d\u021e\3\2"+
		"\2\2\u021e\u021f\7+\2\2\u021f\u0220\5\u00a4S\2\u0220\u0221\7P\2\2\u0221"+
		"M\3\2\2\2\u0222\u0230\5\2\2\2\u0223\u0230\5\u0098M\2\u0224\u0230\5\u009a"+
		"N\2\u0225\u0230\5\u009cO\2\u0226\u0230\5\u0096L\2\u0227\u0230\5t;\2\u0228"+
		"\u0229\7O\2\2\u0229\u022a\5X-\2\u022a\u022b\5Z.\2\u022b\u022c\5\u00a4"+
		"S\2\u022c\u022d\7P\2\2\u022d\u0230\3\2\2\2\u022e\u0230\5P)\2\u022f\u0222"+
		"\3\2\2\2\u022f\u0223\3\2\2\2\u022f\u0224\3\2\2\2\u022f\u0225\3\2\2\2\u022f"+
		"\u0226\3\2\2\2\u022f\u0227\3\2\2\2\u022f\u0228\3\2\2\2\u022f\u022e\3\2"+
		"\2\2\u0230O\3\2\2\2\u0231\u0235\7O\2\2\u0232\u0236\7&\2\2\u0233\u0236"+
		"\7\'\2\2\u0234\u0236\5\u00a2R\2\u0235\u0232\3\2\2\2\u0235\u0233\3\2\2"+
		"\2\u0235\u0234\3\2\2\2\u0236\u0237\3\2\2\2\u0237\u0238\5R*\2\u0238\u0239"+
		"\7P\2\2\u0239Q\3\2\2\2\u023a\u023d\5T+\2\u023b\u023d\5V,\2\u023c\u023a"+
		"\3\2\2\2\u023c\u023b\3\2\2\2\u023dS\3\2\2\2\u023e\u023f\7O\2\2\u023f\u0240"+
		"\7,\2\2\u0240\u0241\5\u00a2R\2\u0241\u0242\5N(\2\u0242\u0243\7-\2\2\u0243"+
		"\u0244\5J&\2\u0244\u0245\7P\2\2\u0245U\3\2\2\2\u0246\u0247\7O\2\2\u0247"+
		"\u024e\7.\2\2\u0248\u024f\5\26\f\2\u0249\u024b\5N(\2\u024a\u0249\3\2\2"+
		"\2\u024b\u024c\3\2\2\2\u024c\u024d\3\2\2\2\u024c\u024a\3\2\2\2\u024d\u024f"+
		"\3\2\2\2\u024e\u0248\3\2\2\2\u024e\u024a\3\2\2\2\u024f\u0250\3\2\2\2\u0250"+
		"\u0251\5\u00a4S\2\u0251\u0252\7P\2\2\u0252W\3\2\2\2\u0253\u0257\5\2\2"+
		"\2\u0254\u0257\7\4\2\2\u0255\u0257\5^\60\2\u0256\u0253\3\2\2\2\u0256\u0254"+
		"\3\2\2\2\u0256\u0255\3\2\2\2\u0257Y\3\2\2\2\u0258\u0259\t\6\2\2\u0259"+
		"[\3\2\2\2\u025a\u025d\5`\61\2\u025b\u025d\5^\60\2\u025c\u025a\3\2\2\2"+
		"\u025c\u025b\3\2\2\2\u025d]\3\2\2\2\u025e\u025f\7O\2\2\u025f\u0260\5b"+
		"\62\2\u0260\u0261\7\7\2\2\u0261\u0262\7P\2\2\u0262\u0265\3\2\2\2\u0263"+
		"\u0265\5d\63\2\u0264\u025e\3\2\2\2\u0264\u0263\3\2\2\2\u0265_\3\2\2\2"+
		"\u0266\u0267\7O\2\2\u0267\u0268\5b\62\2\u0268\u0269\7\b\2\2\u0269\u026a"+
		"\7P\2\2\u026a\u026d\3\2\2\2\u026b\u026d\5f\64\2\u026c\u0266\3\2\2\2\u026c"+
		"\u026b\3\2\2\2\u026da\3\2\2\2\u026e\u0273\5\u00a2R\2\u026f\u0273\7\34"+
		"\2\2\u0270\u0273\7\32\2\2\u0271\u0273\7\33\2\2\u0272\u026e\3\2\2\2\u0272"+
		"\u026f\3\2\2\2\u0272\u0270\3\2\2\2\u0272\u0271\3\2\2\2\u0273c\3\2\2\2"+
		"\u0274\u0275\7O\2\2\u0275\u0276\7\63\2\2\u0276\u0277\5D#\2\u0277\u0278"+
		"\7P\2\2\u0278e\3\2\2\2\u0279\u027a\7O\2\2\u027a\u027b\7\b\2\2\u027b\u027c"+
		"\5^\60\2\u027c\u027d\7P\2\2\u027dg\3\2\2\2\u027e\u027f\7O\2\2\u027f\u0280"+
		"\7\64\2\2\u0280\u0281\t\2\2\2\u0281\u0282\7P\2\2\u0282i\3\2\2\2\u0283"+
		"\u0289\5\2\2\2\u0284\u0289\5\u00a2R\2\u0285\u0289\5z>\2\u0286\u0289\5"+
		"\u00a4S\2\u0287\u0289\5l\67\2\u0288\u0283\3\2\2\2\u0288\u0284\3\2\2\2"+
		"\u0288\u0285\3\2\2\2\u0288\u0286\3\2\2\2\u0288\u0287\3\2\2\2\u0289k\3"+
		"\2\2\2\u028a\u0295\5\2\2\2\u028b\u0295\5N(\2\u028c\u0295\5n8\2\u028d\u0295"+
		"\5p9\2\u028e\u0295\7\7\2\2\u028f\u0295\7\b\2\2\u0290\u0295\5`\61\2\u0291"+
		"\u0295\5h\65\2\u0292\u0295\5r:\2\u0293\u0295\5t;\2\u0294\u028a\3\2\2\2"+
		"\u0294\u028b\3\2\2\2\u0294\u028c\3\2\2\2\u0294\u028d\3\2\2\2\u0294\u028e"+
		"\3\2\2\2\u0294\u028f\3\2\2\2\u0294\u0290\3\2\2\2\u0294\u0291\3\2\2\2\u0294"+
		"\u0292\3\2\2\2\u0294\u0293\3\2\2\2\u0295m\3\2\2\2\u0296\u029c\7O\2\2\u0297"+
		"\u0298\5\u00a6T\2\u0298\u0299\7\27\2\2\u0299\u029b\3\2\2\2\u029a\u0297"+
		"\3\2\2\2\u029b\u029e\3\2\2\2\u029c\u029d\3\2\2\2\u029c\u029a\3\2\2\2\u029d"+
		"\u029f\3\2\2\2\u029e\u029c\3\2\2\2\u029f\u02a0\5\u00a6T\2\u02a0\u02a1"+
		"\7P\2\2\u02a1o\3\2\2\2\u02a2\u02a6\5R*\2\u02a3\u02a6\5\26\f\2\u02a4\u02a6"+
		"\5\30\r\2\u02a5\u02a2\3\2\2\2\u02a5\u02a3\3\2\2\2\u02a5\u02a4\3\2\2\2"+
		"\u02a6q\3\2\2\2\u02a7\u02a8\7O\2\2\u02a8\u02a9\7\65\2\2\u02a9\u02aa\5"+
		"\u00a2R\2\u02aa\u02ab\7\66\2\2\u02ab\u02ac\5\u00a2R\2\u02ac\u02ad\7P\2"+
		"\2\u02ads\3\2\2\2\u02ae\u02af\7O\2\2\u02af\u02b0\7\67\2\2\u02b0\u02b1"+
		"\5l\67\2\u02b1\u02b2\5\2\2\2\u02b2\u02b3\5z>\2\u02b3\u02b4\7P\2\2\u02b4"+
		"u\3\2\2\2\u02b5\u02b6\7K\2\2\u02b6\u02b7\5x=\2\u02b7\u02b8\5x=\2\u02b8"+
		"w\3\2\2\2\u02b9\u02c1\5\u00a4S\2\u02ba\u02bb\7O\2\2\u02bb\u02bc\78\2\2"+
		"\u02bc\u02bd\5\u00a4S\2\u02bd\u02be\5D#\2\u02be\u02bf\7P\2\2\u02bf\u02c1"+
		"\3\2\2\2\u02c0\u02b9\3\2\2\2\u02c0\u02ba\3\2\2\2\u02c1y\3\2\2\2\u02c2"+
		"\u02dd\7O\2\2\u02c3\u02c4\7I\2\2\u02c4\u02c6\5z>\2\u02c5\u02c7\5z>\2\u02c6"+
		"\u02c5\3\2\2\2\u02c7\u02c8\3\2\2\2\u02c8\u02c9\3\2\2\2\u02c8\u02c6\3\2"+
		"\2\2\u02c9\u02de\3\2\2\2\u02ca\u02cb\5|?\2\u02cb\u02cc\5\u00a2R\2\u02cc"+
		"\u02cd\5\u00a2R\2\u02cd\u02de\3\2\2\2\u02ce\u02de\5v<\2\u02cf\u02d0\7"+
		"K\2\2\u02d0\u02d1\5D#\2\u02d1\u02d2\5D#\2\u02d2\u02de\3\2\2\2\u02d3\u02d4"+
		"\7L\2\2\u02d4\u02de\5z>\2\u02d5\u02d6\7K\2\2\u02d6\u02d7\5^\60\2\u02d7"+
		"\u02d8\5^\60\2\u02d8\u02de\3\2\2\2\u02d9\u02da\7K\2\2\u02da\u02db\5`\61"+
		"\2\u02db\u02dc\5`\61\2\u02dc\u02de\3\2\2\2\u02dd\u02c3\3\2\2\2\u02dd\u02ca"+
		"\3\2\2\2\u02dd\u02ce\3\2\2\2\u02dd\u02cf\3\2\2\2\u02dd\u02d3\3\2\2\2\u02dd"+
		"\u02d5\3\2\2\2\u02dd\u02d9\3\2\2\2\u02de\u02df\3\2\2\2\u02df\u02e0\7P"+
		"\2\2\u02e0\u02e3\3\2\2\2\u02e1\u02e3\5\26\f\2\u02e2\u02c2\3\2\2\2\u02e2"+
		"\u02e1\3\2\2\2\u02e3{\3\2\2\2\u02e4\u02e5\t\7\2\2\u02e5}\3\2\2\2\u02e6"+
		"\u02e7\7O\2\2\u02e7\u02e8\79\2\2\u02e8\u02e9\5\u00a2R\2\u02e9\u02ea\5"+
		"\u00a2R\2\u02ea\u02eb\7P\2\2\u02eb\177\3\2\2\2\u02ec\u02ed\7O\2\2\u02ed"+
		"\u02ee\7:\2\2\u02ee\u02ef\5\u00a2R\2\u02ef\u02f0\5\u00a2R\2\u02f0\u02f1"+
		"\7P\2\2\u02f1\u0081\3\2\2\2\u02f2\u02f3\7O\2\2\u02f3\u02f4\7;\2\2\u02f4"+
		"\u02f5\5\u00a2R\2\u02f5\u02f6\5\u00a2R\2\u02f6\u02f7\7P\2\2\u02f7\u0083"+
		"\3\2\2\2\u02f8\u02f9\7O\2\2\u02f9\u02fa\7<\2\2\u02fa\u02fb\5\u00a2R\2"+
		"\u02fb\u02fc\5\u00a2R\2\u02fc\u02fd\7P\2\2\u02fd\u0085\3\2\2\2\u02fe\u02ff"+
		"\7O\2\2\u02ff\u0300\7=\2\2\u0300\u0301\5\u00a2R\2\u0301\u0302\5\u00a2"+
		"R\2\u0302\u0303\7P\2\2\u0303\u0087\3\2\2\2\u0304\u0305\7O\2\2\u0305\u0306"+
		"\7>\2\2\u0306\u0307\5\u00a2R\2\u0307\u0308\5\u00a2R\2\u0308\u0309\7P\2"+
		"\2\u0309\u0089\3\2\2\2\u030a\u030b\7O\2\2\u030b\u030c\7?\2\2\u030c\u030d"+
		"\5\u00a2R\2\u030d\u030e\7P\2\2\u030e\u008b\3\2\2\2\u030f\u0310\7O\2\2"+
		"\u0310\u0311\7@\2\2\u0311\u0312\5\u00a2R\2\u0312\u0313\7P\2\2\u0313\u008d"+
		"\3\2\2\2\u0314\u0315\7O\2\2\u0315\u0316\7A\2\2\u0316\u0317\5\u00a2R\2"+
		"\u0317\u0319\7\66\2\2\u0318\u031a\5\u00a2R\2\u0319\u0318\3\2\2\2\u0319"+
		"\u031a\3\2\2\2\u031a\u031b\3\2\2\2\u031b\u031c\7P\2\2\u031c\u008f\3\2"+
		"\2\2\u031d\u031e\7O\2\2\u031e\u0322\7B\2\2\u031f\u0323\5\2\2\2\u0320\u0323"+
		"\5N(\2\u0321\u0323\5R*\2\u0322\u031f\3\2\2\2\u0322\u0320\3\2\2\2\u0322"+
		"\u0321\3\2\2\2\u0323\u0324\3\2\2\2\u0324\u0325\7P\2\2\u0325\u0091\3\2"+
		"\2\2\u0326\u0327\7O\2\2\u0327\u0328\7\13\2\2\u0328\u0329\5N(\2\u0329\u032a"+
		"\7-\2\2\u032a\u032b\5J&\2\u032b\u032c\7P\2\2\u032c\u0093\3\2\2\2\u032d"+
		"\u032e\7O\2\2\u032e\u032f\7\n\2\2\u032f\u0330\5N(\2\u0330\u0331\7-\2\2"+
		"\u0331\u0332\5J&\2\u0332\u0333\7P\2\2\u0333\u0095\3\2\2\2\u0334\u0335"+
		"\7O\2\2\u0335\u0336\7C\2\2\u0336\u0337\5N(\2\u0337\u0338\7-\2\2\u0338"+
		"\u0339\5J&\2\u0339\u033a\7P\2\2\u033a\u0097\3\2\2\2\u033b\u033c\7O\2\2"+
		"\u033c\u0343\7D\2\2\u033d\u0344\5\26\f\2\u033e\u0340\5N(\2\u033f\u033e"+
		"\3\2\2\2\u0340\u0341\3\2\2\2\u0341\u0342\3\2\2\2\u0341\u033f\3\2\2\2\u0342"+
		"\u0344\3\2\2\2\u0343\u033d\3\2\2\2\u0343\u033f\3\2\2\2\u0344\u0345\3\2"+
		"\2\2\u0345\u0346\7P\2\2\u0346\u0099\3\2\2\2\u0347\u0348\7O\2\2\u0348\u034f"+
		"\7E\2\2\u0349\u0350\5\26\f\2\u034a\u034c\5N(\2\u034b\u034a\3\2\2\2\u034c"+
		"\u034d\3\2\2\2\u034d\u034e\3\2\2\2\u034d\u034b\3\2\2\2\u034e\u0350\3\2"+
		"\2\2\u034f\u0349\3\2\2\2\u034f\u034b\3\2\2\2\u0350\u0357\3\2\2\2\u0351"+
		"\u0358\5\26\f\2\u0352\u0354\5N(\2\u0353\u0352\3\2\2\2\u0354\u0355\3\2"+
		"\2\2\u0355\u0356\3\2\2\2\u0355\u0353\3\2\2\2\u0356\u0358\3\2\2\2\u0357"+
		"\u0351\3\2\2\2\u0357\u0353\3\2\2\2\u0358\u0359\3\2\2\2\u0359\u035a\7P"+
		"\2\2\u035a\u009b\3\2\2\2\u035b\u035c\7O\2\2\u035c\u0363\7F\2\2\u035d\u0364"+
		"\5\26\f\2\u035e\u0360\5N(\2\u035f\u035e\3\2\2\2\u0360\u0361\3\2\2\2\u0361"+
		"\u0362\3\2\2\2\u0361\u035f\3\2\2\2\u0362\u0364\3\2\2\2\u0363\u035d\3\2"+
		"\2\2\u0363\u035f\3\2\2\2\u0364\u036b\3\2\2\2\u0365\u036c\5\26\f\2\u0366"+
		"\u0368\5N(\2\u0367\u0366\3\2\2\2\u0368\u0369\3\2\2\2\u0369\u036a\3\2\2"+
		"\2\u0369\u0367\3\2\2\2\u036a\u036c\3\2\2\2\u036b\u0365\3\2\2\2\u036b\u0367"+
		"\3\2\2\2\u036c\u036d\3\2\2\2\u036d\u036e\7P\2\2\u036e\u009d\3\2\2\2\u036f"+
		"\u0370\7O\2\2\u0370\u0371\7G\2\2\u0371\u0372\5N(\2\u0372\u0373\7-\2\2"+
		"\u0373\u0374\5J&\2\u0374\u0375\7P\2\2\u0375\u009f\3\2\2\2\u0376\u0377"+
		"\7O\2\2\u0377\u0378\7H\2\2\u0378\u0379\5D#\2\u0379\u037a\7-\2\2\u037a"+
		"\u037b\5J&\2\u037b\u037c\7P\2\2\u037c\u00a1\3\2\2\2\u037d\u0391\5\2\2"+
		"\2\u037e\u0391\5\u0090I\2\u037f\u0391\5\u0080A\2\u0380\u0391\5\u0082B"+
		"\2\u0381\u0391\5\u0084C\2\u0382\u0391\5~@\2\u0383\u0391\5\u0086D\2\u0384"+
		"\u0391\5\u0088E\2\u0385\u0391\5\u008aF\2\u0386\u0391\5\u008cG\2\u0387"+
		"\u0391\5\u008eH\2\u0388\u0391\5\u009eP\2\u0389\u0391\5H%\2\u038a\u0391"+
		"\5\u00a0Q\2\u038b\u038d\7M\2\2\u038c\u038b\3\2\2\2\u038d\u038e\3\2\2\2"+
		"\u038e\u038c\3\2\2\2\u038e\u038f\3\2\2\2\u038f\u0391\3\2\2\2\u0390\u037d"+
		"\3\2\2\2\u0390\u037e\3\2\2\2\u0390\u037f\3\2\2\2\u0390\u0380\3\2\2\2\u0390"+
		"\u0381\3\2\2\2\u0390\u0382\3\2\2\2\u0390\u0383\3\2\2\2\u0390\u0384\3\2"+
		"\2\2\u0390\u0385\3\2\2\2\u0390\u0386\3\2\2\2\u0390\u0387\3\2\2\2\u0390"+
		"\u0388\3\2\2\2\u0390\u0389\3\2\2\2\u0390\u038a\3\2\2\2\u0390\u038c\3\2"+
		"\2\2\u0391\u00a3\3\2\2\2\u0392\u0396\5\u00a6T\2\u0393\u0396\5L\'\2\u0394"+
		"\u0396\5\2\2\2\u0395\u0392\3\2\2\2\u0395\u0393\3\2\2\2\u0395\u0394\3\2"+
		"\2\2\u0396\u00a5\3\2\2\2\u0397\u0399\7N\2\2\u0398\u0397\3\2\2\2\u0399"+
		"\u039a\3\2\2\2\u039a\u0398\3\2\2\2\u039a\u039b\3\2\2\2\u039b\u00a7\3\2"+
		"\2\2I\u00b0\u00b6\u00b8\u00c1\u00c6\u00cc\u00d6\u00d8\u00f5\u00fa\u0102"+
		"\u010d\u0114\u011c\u0123\u0131\u013b\u0146\u0155\u015f\u0166\u0170\u0179"+
		"\u0180\u018f\u0196\u019b\u01a3\u01ab\u01b7\u01c1\u01ee\u01f8\u01fd\u0208"+
		"\u0212\u021c\u022f\u0235\u023c\u024c\u024e\u0256\u025c\u0264\u026c\u0272"+
		"\u0288\u0294\u029c\u02a5\u02c0\u02c8\u02dd\u02e2\u0319\u0322\u0341\u0343"+
		"\u034d\u034f\u0355\u0357\u0361\u0363\u0369\u036b\u038e\u0390\u0395\u039a";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}