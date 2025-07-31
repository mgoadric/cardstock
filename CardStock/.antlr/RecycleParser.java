// Generated from /Users/markgoadrich/Github/cardstock/CardStock/Recycle.g4 by ANTLR 4.13.1
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
		T__66=67, T__67=68, T__68=69, T__69=70, BOOLOP=71, COMPOP=72, EQOP=73, 
		UNOP=74, INTNUM=75, LETT=76, OPEN=77, CLOSE=78, WS=79, ANY=80;
	public static final int
		RULE_var = 0, RULE_vars = 1, RULE_varo = 2, RULE_varp = 3, RULE_vari = 4, 
		RULE_varb = 5, RULE_varc = 6, RULE_varcs = 7, RULE_varcard = 8, RULE_game = 9, 
		RULE_declare = 10, RULE_setup = 11, RULE_scoring = 12, RULE_stage = 13, 
		RULE_endcondition = 14, RULE_multiaction = 15, RULE_multiaction2 = 16, 
		RULE_condact = 17, RULE_agg = 18, RULE_let = 19, RULE_action = 20, RULE_playercreate = 21, 
		RULE_teamcreate = 22, RULE_teams = 23, RULE_deckcreate = 24, RULE_deck = 25, 
		RULE_attribute = 26, RULE_initpoints = 27, RULE_awards = 28, RULE_subaward = 29, 
		RULE_cycleaction = 30, RULE_setaction = 31, RULE_setstraction = 32, RULE_incaction = 33, 
		RULE_decaction = 34, RULE_moveaction = 35, RULE_shuffleaction = 36, RULE_turnaction = 37, 
		RULE_repeat = 38, RULE_pointstorage = 39, RULE_card = 40, RULE_actual = 41, 
		RULE_maxof = 42, RULE_minof = 43, RULE_locpre = 44, RULE_locdesc = 45, 
		RULE_who = 46, RULE_whop = 47, RULE_whot = 48, RULE_whodesc = 49, RULE_owner = 50, 
		RULE_teamp = 51, RULE_typed = 52, RULE_collection = 53, RULE_strcollection = 54, 
		RULE_range = 55, RULE_other = 56, RULE_cstorage = 57, RULE_sortof = 58, 
		RULE_unionof = 59, RULE_intersectof = 60, RULE_disjunctionof = 61, RULE_filter = 62, 
		RULE_memstorage = 63, RULE_cstoragecollection = 64, RULE_memset = 65, 
		RULE_run = 66, RULE_subset = 67, RULE_tuple = 68, RULE_partition = 69, 
		RULE_aggcs = 70, RULE_boolean = 71, RULE_intop = 72, RULE_aggb = 73, RULE_int = 74, 
		RULE_sum = 75, RULE_score = 76, RULE_add = 77, RULE_mult = 78, RULE_subtract = 79, 
		RULE_mod = 80, RULE_divide = 81, RULE_exponent = 82, RULE_triangular = 83, 
		RULE_fibonacci = 84, RULE_random = 85, RULE_sizeof = 86, RULE_aggi = 87, 
		RULE_rawstorage = 88, RULE_str = 89, RULE_strstorage = 90, RULE_cardatt = 91, 
		RULE_namegr = 92;
	private static String[] makeRuleNames() {
		return new String[] {
			"var", "vars", "varo", "varp", "vari", "varb", "varc", "varcs", "varcard", 
			"game", "declare", "setup", "scoring", "stage", "endcondition", "multiaction", 
			"multiaction2", "condact", "agg", "let", "action", "playercreate", "teamcreate", 
			"teams", "deckcreate", "deck", "attribute", "initpoints", "awards", "subaward", 
			"cycleaction", "setaction", "setstraction", "incaction", "decaction", 
			"moveaction", "shuffleaction", "turnaction", "repeat", "pointstorage", 
			"card", "actual", "maxof", "minof", "locpre", "locdesc", "who", "whop", 
			"whot", "whodesc", "owner", "teamp", "typed", "collection", "strcollection", 
			"range", "other", "cstorage", "sortof", "unionof", "intersectof", "disjunctionof", 
			"filter", "memstorage", "cstoragecollection", "memset", "run", "subset", 
			"tuple", "partition", "aggcs", "boolean", "intop", "aggb", "int", "sum", 
			"score", "add", "mult", "subtract", "mod", "divide", "exponent", "triangular", 
			"fibonacci", "random", "sizeof", "aggi", "rawstorage", "str", "strstorage", 
			"cardatt", "namegr"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'''", "'game'", "'declare'", "'setup'", "'scoring'", "'min'", 
			"'max'", "'stage'", "'player'", "'team'", "'end'", "'choice'", "'do'", 
			"'any'", "'all'", "'let'", "'create'", "'players'", "'teams'", "','", 
			"'deck'", "'set'", "':'", "'cycle'", "'next'", "'current'", "'previous'", 
			"'inc'", "'dec'", "'move'", "'shuffle'", "'turn'", "'pass'", "'repeat'", 
			"'points'", "'top'", "'bottom'", "'actual'", "'using'", "'vloc'", "'iloc'", 
			"'hloc'", "'owner'", "'range'", "'..'", "'other'", "'sort'", "'union'", 
			"'intersect'", "'disjunction'", "'filter'", "'runs'", "'subsets'", "'tuples'", 
			"'partition'", "'sum'", "'score'", "'+'", "'*'", "'-'", "'%'", "'//'", 
			"'^'", "'tri'", "'fib'", "'random'", "'size'", "'sto'", "'str'", "'cardatt'", 
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

	@SuppressWarnings("CheckReturnValue")
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
			setState(186);
			match(T__0);
			setState(187);
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
	public static class VarsContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_vars; }
	}

	public final VarsContext vars() throws RecognitionException {
		VarsContext _localctx = new VarsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_vars);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			match(T__0);
			setState(190);
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
	public static class VaroContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VaroContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varo; }
	}

	public final VaroContext varo() throws RecognitionException {
		VaroContext _localctx = new VaroContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_varo);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(T__0);
			setState(193);
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
	public static class VarpContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varp; }
	}

	public final VarpContext varp() throws RecognitionException {
		VarpContext _localctx = new VarpContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_varp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			match(T__0);
			setState(196);
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
	public static class VariContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VariContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_vari; }
	}

	public final VariContext vari() throws RecognitionException {
		VariContext _localctx = new VariContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_vari);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(198);
			match(T__0);
			setState(199);
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
	public static class VarbContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarbContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varb; }
	}

	public final VarbContext varb() throws RecognitionException {
		VarbContext _localctx = new VarbContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_varb);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(201);
			match(T__0);
			setState(202);
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
	public static class VarcContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarcContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varc; }
	}

	public final VarcContext varc() throws RecognitionException {
		VarcContext _localctx = new VarcContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_varc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(204);
			match(T__0);
			setState(205);
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
	public static class VarcsContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarcsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varcs; }
	}

	public final VarcsContext varcs() throws RecognitionException {
		VarcsContext _localctx = new VarcsContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_varcs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			match(T__0);
			setState(208);
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
	public static class VarcardContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarcardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varcard; }
	}

	public final VarcardContext varcard() throws RecognitionException {
		VarcardContext _localctx = new VarcardContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_varcard);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(210);
			match(T__0);
			setState(211);
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
	}

	public final GameContext game() throws RecognitionException {
		GameContext _localctx = new GameContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_game);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(213);
			match(OPEN);
			setState(214);
			match(T__1);
			setState(218);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(215);
					declare();
					}
					} 
				}
				setState(220);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(221);
			setup();
			setState(224); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(224);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						setState(222);
						multiaction();
						}
						break;
					case 2:
						{
						setState(223);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(226); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(228);
			scoring();
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
		enterRule(_localctx, 20, RULE_declare);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(231);
			match(OPEN);
			setState(232);
			match(T__2);
			setState(233);
			typed();
			setState(234);
			var();
			setState(235);
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
	}

	public final SetupContext setup() throws RecognitionException {
		SetupContext _localctx = new SetupContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_setup);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(237);
			match(OPEN);
			setState(238);
			match(T__3);
			setState(239);
			playercreate();
			setState(241);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(240);
				teamcreate();
				}
				break;
			}
			setState(250); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(243);
					match(OPEN);
					setState(246);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__16:
						{
						setState(244);
						deckcreate();
						}
						break;
					case T__33:
						{
						setState(245);
						repeat();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(248);
					match(CLOSE);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(252); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(254);
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
	}

	public final ScoringContext scoring() throws RecognitionException {
		ScoringContext _localctx = new ScoringContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_scoring);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(256);
			match(OPEN);
			setState(257);
			match(T__4);
			setState(258);
			_la = _input.LA(1);
			if ( !(_la==T__5 || _la==T__6) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(259);
			int_();
			setState(260);
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
	}

	public final StageContext stage() throws RecognitionException {
		StageContext _localctx = new StageContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_stage);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(262);
			match(OPEN);
			setState(263);
			match(T__7);
			setState(264);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(265);
			endcondition();
			setState(268); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(268);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
					case 1:
						{
						setState(266);
						multiaction();
						}
						break;
					case 2:
						{
						setState(267);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(270); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(272);
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
	}

	public final EndconditionContext endcondition() throws RecognitionException {
		EndconditionContext _localctx = new EndconditionContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_endcondition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(274);
			match(OPEN);
			setState(275);
			match(T__10);
			setState(276);
			boolean_();
			setState(277);
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
		enterRule(_localctx, 30, RULE_multiaction);
		try {
			int _alt;
			setState(303);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
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
					_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
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
				match(OPEN);
				setState(291);
				match(T__12);
				setState(292);
				match(OPEN);
				setState(294); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(293);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(296); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(298);
				match(CLOSE);
				setState(299);
				match(CLOSE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(301);
				agg();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(302);
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
	}

	public final Multiaction2Context multiaction2() throws RecognitionException {
		Multiaction2Context _localctx = new Multiaction2Context(_ctx, getState());
		enterRule(_localctx, 32, RULE_multiaction2);
		try {
			int _alt;
			setState(318);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(305);
				match(OPEN);
				setState(306);
				match(T__12);
				setState(307);
				match(OPEN);
				setState(309); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(308);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(311); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(313);
				match(CLOSE);
				setState(314);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(316);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(317);
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
	}

	public final CondactContext condact() throws RecognitionException {
		CondactContext _localctx = new CondactContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_condact);
		try {
			setState(332);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(320);
				match(OPEN);
				setState(321);
				boolean_();
				setState(322);
				multiaction2();
				setState(323);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(325);
				multiaction2();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(326);
				match(OPEN);
				setState(327);
				boolean_();
				setState(328);
				action();
				setState(329);
				match(CLOSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(331);
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
		public CondactContext condact() {
			return getRuleContext(CondactContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_agg; }
	}

	public final AggContext agg() throws RecognitionException {
		AggContext _localctx = new AggContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_agg);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(334);
			match(OPEN);
			setState(335);
			_la = _input.LA(1);
			if ( !(_la==T__13 || _la==T__14) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(336);
			collection();
			setState(337);
			var();
			setState(338);
			condact();
			setState(339);
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
	}

	public final LetContext let() throws RecognitionException {
		LetContext _localctx = new LetContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_let);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(341);
			match(OPEN);
			setState(342);
			match(T__15);
			setState(343);
			typed();
			setState(344);
			var();
			setState(348);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(345);
				multiaction();
				}
				break;
			case 2:
				{
				setState(346);
				action();
				}
				break;
			case 3:
				{
				setState(347);
				condact();
				}
				break;
			}
			setState(350);
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
		public IncactionContext incaction() {
			return getRuleContext(IncactionContext.class,0);
		}
		public SetstractionContext setstraction() {
			return getRuleContext(SetstractionContext.class,0);
		}
		public DecactionContext decaction() {
			return getRuleContext(DecactionContext.class,0);
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
		enterRule(_localctx, 40, RULE_action);
		try {
			setState(370);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(352);
				match(OPEN);
				setState(365);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
				case 1:
					{
					setState(353);
					initpoints();
					}
					break;
				case 2:
					{
					setState(354);
					teamcreate();
					}
					break;
				case 3:
					{
					setState(355);
					deckcreate();
					}
					break;
				case 4:
					{
					setState(356);
					cycleaction();
					}
					break;
				case 5:
					{
					setState(357);
					setaction();
					}
					break;
				case 6:
					{
					setState(358);
					moveaction();
					}
					break;
				case 7:
					{
					setState(359);
					incaction();
					}
					break;
				case 8:
					{
					setState(360);
					setstraction();
					}
					break;
				case 9:
					{
					setState(361);
					decaction();
					}
					break;
				case 10:
					{
					setState(362);
					turnaction();
					}
					break;
				case 11:
					{
					setState(363);
					shuffleaction();
					}
					break;
				case 12:
					{
					setState(364);
					repeat();
					}
					break;
				}
				setState(367);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(369);
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
	public static class PlayercreateContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public PlayercreateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_playercreate; }
	}

	public final PlayercreateContext playercreate() throws RecognitionException {
		PlayercreateContext _localctx = new PlayercreateContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_playercreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(372);
			match(OPEN);
			setState(373);
			match(T__16);
			setState(374);
			match(T__17);
			setState(375);
			int_();
			setState(376);
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
	}

	public final TeamcreateContext teamcreate() throws RecognitionException {
		TeamcreateContext _localctx = new TeamcreateContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_teamcreate);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(378);
			match(OPEN);
			setState(379);
			match(T__16);
			setState(380);
			match(T__18);
			setState(382); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(381);
					teams();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(384); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(386);
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
	}

	public final TeamsContext teams() throws RecognitionException {
		TeamsContext _localctx = new TeamsContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_teams);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(388);
			match(OPEN);
			setState(393);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(389);
					match(INTNUM);
					setState(390);
					match(T__19);
					}
					} 
				}
				setState(395);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			}
			setState(396);
			match(INTNUM);
			setState(400);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(397);
					teams();
					}
					} 
				}
				setState(402);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			setState(403);
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
	}

	public final DeckcreateContext deckcreate() throws RecognitionException {
		DeckcreateContext _localctx = new DeckcreateContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_deckcreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(405);
			match(T__16);
			setState(406);
			match(T__20);
			setState(408);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(407);
				str();
				}
				break;
			}
			setState(410);
			cstorage();
			setState(411);
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
	}

	public final DeckContext deck() throws RecognitionException {
		DeckContext _localctx = new DeckContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_deck);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(413);
			match(OPEN);
			setState(414);
			match(T__20);
			setState(416); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(415);
					attribute();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(418); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(420);
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
		public List<NamegrContext> namegr() {
			return getRuleContexts(NamegrContext.class);
		}
		public NamegrContext namegr(int i) {
			return getRuleContext(NamegrContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
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
		enterRule(_localctx, 52, RULE_attribute);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(422);
			match(OPEN);
			setState(428);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(423);
					namegr();
					setState(424);
					match(T__19);
					}
					} 
				}
				setState(430);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			setState(431);
			namegr();
			setState(435);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(432);
					attribute();
					}
					} 
				}
				setState(437);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			}
			setState(438);
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
		enterRule(_localctx, 54, RULE_initpoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(440);
			match(T__21);
			setState(441);
			pointstorage();
			setState(442);
			match(OPEN);
			setState(444); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(443);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(446); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(448);
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
	}

	public final AwardsContext awards() throws RecognitionException {
		AwardsContext _localctx = new AwardsContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_awards);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(450);
			match(OPEN);
			setState(452); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(451);
					subaward();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(454); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(456);
			int_();
			setState(457);
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
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public List<StrContext> str() {
			return getRuleContexts(StrContext.class);
		}
		public StrContext str(int i) {
			return getRuleContext(StrContext.class,i);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SubawardContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subaward; }
	}

	public final SubawardContext subaward() throws RecognitionException {
		SubawardContext _localctx = new SubawardContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_subaward);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(459);
			match(OPEN);
			setState(460);
			str();
			setState(461);
			match(T__22);
			setState(462);
			str();
			setState(463);
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
		public VaroContext varo() {
			return getRuleContext(VaroContext.class,0);
		}
		public CycleactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_cycleaction; }
	}

	public final CycleactionContext cycleaction() throws RecognitionException {
		CycleactionContext _localctx = new CycleactionContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_cycleaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(465);
			match(T__23);
			setState(466);
			_la = _input.LA(1);
			if ( !(_la==T__24 || _la==T__25) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(472);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(467);
				owner();
				}
				break;
			case T__25:
				{
				setState(468);
				match(T__25);
				}
				break;
			case T__24:
				{
				setState(469);
				match(T__24);
				}
				break;
			case T__26:
				{
				setState(470);
				match(T__26);
				}
				break;
			case T__0:
				{
				setState(471);
				varo();
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
	}

	public final SetactionContext setaction() throws RecognitionException {
		SetactionContext _localctx = new SetactionContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_setaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(474);
			match(T__21);
			setState(475);
			rawstorage();
			setState(476);
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
	}

	public final SetstractionContext setstraction() throws RecognitionException {
		SetstractionContext _localctx = new SetstractionContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_setstraction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(478);
			match(T__21);
			setState(479);
			strstorage();
			setState(480);
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
	}

	public final IncactionContext incaction() throws RecognitionException {
		IncactionContext _localctx = new IncactionContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_incaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(482);
			match(T__27);
			setState(483);
			rawstorage();
			setState(484);
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
	}

	public final DecactionContext decaction() throws RecognitionException {
		DecactionContext _localctx = new DecactionContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_decaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(486);
			match(T__28);
			setState(487);
			rawstorage();
			setState(488);
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
	}

	public final MoveactionContext moveaction() throws RecognitionException {
		MoveactionContext _localctx = new MoveactionContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_moveaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(490);
			match(T__29);
			setState(491);
			card();
			setState(492);
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
	}

	public final ShuffleactionContext shuffleaction() throws RecognitionException {
		ShuffleactionContext _localctx = new ShuffleactionContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_shuffleaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(494);
			match(T__30);
			setState(495);
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
	}

	public final TurnactionContext turnaction() throws RecognitionException {
		TurnactionContext _localctx = new TurnactionContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_turnaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(497);
			match(T__31);
			setState(498);
			match(T__32);
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
	}

	public final RepeatContext repeat() throws RecognitionException {
		RepeatContext _localctx = new RepeatContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_repeat);
		try {
			setState(510);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(500);
				match(T__33);
				setState(501);
				int_();
				setState(502);
				action();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(504);
				match(T__33);
				setState(505);
				match(T__14);
				setState(506);
				match(OPEN);
				setState(507);
				moveaction();
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
	public static class PointstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VaroContext varo() {
			return getRuleContext(VaroContext.class,0);
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
		enterRule(_localctx, 78, RULE_pointstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(512);
			match(OPEN);
			setState(516);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(513);
				varo();
				}
				break;
			case T__1:
				{
				setState(514);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(515);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(518);
			match(T__34);
			setState(519);
			str();
			setState(520);
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
	public static class CardContext extends ParserRuleContext {
		public VarcardContext varcard() {
			return getRuleContext(VarcardContext.class,0);
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
	}

	public final CardContext card() throws RecognitionException {
		CardContext _localctx = new CardContext(_ctx, getState());
		enterRule(_localctx, 80, RULE_card);
		try {
			setState(535);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(522);
				varcard();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(523);
				maxof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(524);
				minof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(525);
				actual();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(526);
				match(OPEN);
				setState(530);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__35:
					{
					setState(527);
					match(T__35);
					}
					break;
				case T__36:
					{
					setState(528);
					match(T__36);
					}
					break;
				case T__0:
				case INTNUM:
				case OPEN:
					{
					setState(529);
					int_();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(532);
				cstorage();
				setState(533);
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
	}

	public final ActualContext actual() throws RecognitionException {
		ActualContext _localctx = new ActualContext(_ctx, getState());
		enterRule(_localctx, 82, RULE_actual);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(537);
			match(OPEN);
			setState(538);
			match(T__37);
			setState(539);
			card();
			setState(540);
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
	}

	public final MaxofContext maxof() throws RecognitionException {
		MaxofContext _localctx = new MaxofContext(_ctx, getState());
		enterRule(_localctx, 84, RULE_maxof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(542);
			match(OPEN);
			setState(543);
			match(T__6);
			setState(544);
			cstorage();
			setState(545);
			match(T__38);
			setState(546);
			pointstorage();
			setState(547);
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
	}

	public final MinofContext minof() throws RecognitionException {
		MinofContext _localctx = new MinofContext(_ctx, getState());
		enterRule(_localctx, 86, RULE_minof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(549);
			match(OPEN);
			setState(550);
			match(T__5);
			setState(551);
			cstorage();
			setState(552);
			match(T__38);
			setState(553);
			pointstorage();
			setState(554);
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
		public VarpContext varp() {
			return getRuleContext(VarpContext.class,0);
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
		enterRule(_localctx, 88, RULE_locpre);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(559);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				{
				setState(556);
				match(T__1);
				}
				break;
			case T__0:
				{
				setState(557);
				varp();
				}
				break;
			case OPEN:
				{
				setState(558);
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
	}

	public final LocdescContext locdesc() throws RecognitionException {
		LocdescContext _localctx = new LocdescContext(_ctx, getState());
		enterRule(_localctx, 90, RULE_locdesc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(561);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 7696581394432L) != 0)) ) {
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
	}

	public final WhoContext who() throws RecognitionException {
		WhoContext _localctx = new WhoContext(_ctx, getState());
		enterRule(_localctx, 92, RULE_who);
		try {
			setState(565);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(563);
				whot();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(564);
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
	}

	public final WhopContext whop() throws RecognitionException {
		WhopContext _localctx = new WhopContext(_ctx, getState());
		enterRule(_localctx, 94, RULE_whop);
		try {
			setState(573);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(567);
				match(OPEN);
				setState(568);
				whodesc();
				setState(569);
				match(T__8);
				setState(570);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(572);
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
	}

	public final WhotContext whot() throws RecognitionException {
		WhotContext _localctx = new WhotContext(_ctx, getState());
		enterRule(_localctx, 96, RULE_whot);
		try {
			setState(581);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(575);
				match(OPEN);
				setState(576);
				whodesc();
				setState(577);
				match(T__9);
				setState(578);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(580);
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
	}

	public final WhodescContext whodesc() throws RecognitionException {
		WhodescContext _localctx = new WhodescContext(_ctx, getState());
		enterRule(_localctx, 98, RULE_whodesc);
		try {
			setState(587);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case INTNUM:
			case OPEN:
				enterOuterAlt(_localctx, 1);
				{
				setState(583);
				int_();
				}
				break;
			case T__26:
				enterOuterAlt(_localctx, 2);
				{
				setState(584);
				match(T__26);
				}
				break;
			case T__24:
				enterOuterAlt(_localctx, 3);
				{
				setState(585);
				match(T__24);
				}
				break;
			case T__25:
				enterOuterAlt(_localctx, 4);
				{
				setState(586);
				match(T__25);
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
	}

	public final OwnerContext owner() throws RecognitionException {
		OwnerContext _localctx = new OwnerContext(_ctx, getState());
		enterRule(_localctx, 100, RULE_owner);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(589);
			match(OPEN);
			setState(590);
			match(T__42);
			setState(591);
			card();
			setState(592);
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
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarpContext varp() {
			return getRuleContext(VarpContext.class,0);
		}
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public TeampContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_teamp; }
	}

	public final TeampContext teamp() throws RecognitionException {
		TeampContext _localctx = new TeampContext(_ctx, getState());
		enterRule(_localctx, 102, RULE_teamp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(594);
			match(OPEN);
			setState(595);
			match(T__9);
			setState(598);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(596);
				varp();
				}
				break;
			case OPEN:
				{
				setState(597);
				whop();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
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
	public static class TypedContext extends ParserRuleContext {
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
	}

	public final TypedContext typed() throws RecognitionException {
		TypedContext _localctx = new TypedContext(_ctx, getState());
		enterRule(_localctx, 104, RULE_typed);
		try {
			setState(606);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(602);
				int_();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(603);
				boolean_();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(604);
				str();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(605);
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
		public VarcContext varc() {
			return getRuleContext(VarcContext.class,0);
		}
		public FilterContext filter() {
			return getRuleContext(FilterContext.class,0);
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
		public CollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_collection; }
	}

	public final CollectionContext collection() throws RecognitionException {
		CollectionContext _localctx = new CollectionContext(_ctx, getState());
		enterRule(_localctx, 106, RULE_collection);
		try {
			setState(618);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,38,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(608);
				varc();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(609);
				filter();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(610);
				cstorage();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(611);
				strcollection();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(612);
				cstoragecollection();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(613);
				match(T__8);
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(614);
				match(T__9);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(615);
				whot();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(616);
				other();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(617);
				range();
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
	}

	public final StrcollectionContext strcollection() throws RecognitionException {
		StrcollectionContext _localctx = new StrcollectionContext(_ctx, getState());
		enterRule(_localctx, 108, RULE_strcollection);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(620);
			match(OPEN);
			setState(626);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(621);
					namegr();
					setState(622);
					match(T__19);
					}
					} 
				}
				setState(628);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
			}
			setState(629);
			namegr();
			setState(630);
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
	}

	public final RangeContext range() throws RecognitionException {
		RangeContext _localctx = new RangeContext(_ctx, getState());
		enterRule(_localctx, 110, RULE_range);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(632);
			match(OPEN);
			setState(633);
			match(T__43);
			setState(634);
			int_();
			setState(635);
			match(T__44);
			setState(636);
			int_();
			setState(637);
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
	}

	public final OtherContext other() throws RecognitionException {
		OtherContext _localctx = new OtherContext(_ctx, getState());
		enterRule(_localctx, 112, RULE_other);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(639);
			match(OPEN);
			setState(640);
			match(T__45);
			setState(641);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(642);
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
		public VarcsContext varcs() {
			return getRuleContext(VarcsContext.class,0);
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
		enterRule(_localctx, 114, RULE_cstorage);
		try {
			setState(657);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(644);
				varcs();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(645);
				unionof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(646);
				intersectof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(647);
				disjunctionof();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(648);
				sortof();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(649);
				filter();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(650);
				match(OPEN);
				setState(651);
				locpre();
				setState(652);
				locdesc();
				setState(653);
				str();
				setState(654);
				match(CLOSE);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(656);
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
		enterRule(_localctx, 116, RULE_sortof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(659);
			match(OPEN);
			setState(660);
			match(T__46);
			setState(661);
			cstorage();
			setState(662);
			match(T__38);
			setState(663);
			pointstorage();
			setState(664);
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
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
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
		enterRule(_localctx, 118, RULE_unionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(666);
			match(OPEN);
			setState(667);
			match(T__47);
			setState(674);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,42,_ctx) ) {
			case 1:
				{
				setState(668);
				aggcs();
				}
				break;
			case 2:
				{
				setState(670); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(669);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(672); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(676);
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
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
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
		enterRule(_localctx, 120, RULE_intersectof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(678);
			match(OPEN);
			setState(679);
			match(T__48);
			setState(686);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,44,_ctx) ) {
			case 1:
				{
				setState(680);
				aggcs();
				}
				break;
			case 2:
				{
				setState(682); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(681);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(684); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,43,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(688);
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
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
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
		enterRule(_localctx, 122, RULE_disjunctionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(690);
			match(OPEN);
			setState(691);
			match(T__49);
			setState(698);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,46,_ctx) ) {
			case 1:
				{
				setState(692);
				aggcs();
				}
				break;
			case 2:
				{
				setState(694); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(693);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(696); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,45,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(700);
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
	}

	public final FilterContext filter() throws RecognitionException {
		FilterContext _localctx = new FilterContext(_ctx, getState());
		enterRule(_localctx, 124, RULE_filter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(702);
			match(OPEN);
			setState(703);
			match(T__50);
			setState(704);
			collection();
			setState(705);
			var();
			setState(706);
			boolean_();
			setState(707);
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
	}

	public final MemstorageContext memstorage() throws RecognitionException {
		MemstorageContext _localctx = new MemstorageContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_memstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(709);
			match(OPEN);
			setState(713);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__35:
				{
				setState(710);
				match(T__35);
				}
				break;
			case T__36:
				{
				setState(711);
				match(T__36);
				}
				break;
			case T__0:
			case INTNUM:
			case OPEN:
				{
				setState(712);
				int_();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(715);
			memset();
			setState(716);
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
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
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
		enterRule(_localctx, 128, RULE_cstoragecollection);
		try {
			setState(721);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(718);
				memset();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(719);
				aggcs();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(720);
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
	}

	public final MemsetContext memset() throws RecognitionException {
		MemsetContext _localctx = new MemsetContext(_ctx, getState());
		enterRule(_localctx, 130, RULE_memset);
		try {
			setState(726);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,49,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(723);
				tuple();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(724);
				partition();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(725);
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
	public static class RunContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public RunContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_run; }
	}

	public final RunContext run() throws RecognitionException {
		RunContext _localctx = new RunContext(_ctx, getState());
		enterRule(_localctx, 132, RULE_run);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(728);
			match(OPEN);
			setState(729);
			match(T__51);
			setState(730);
			cstorage();
			setState(731);
			match(T__38);
			setState(732);
			pointstorage();
			setState(733);
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
	}

	public final SubsetContext subset() throws RecognitionException {
		SubsetContext _localctx = new SubsetContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_subset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(735);
			match(OPEN);
			setState(736);
			match(T__52);
			setState(737);
			cstorage();
			setState(738);
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
	}

	public final TupleContext tuple() throws RecognitionException {
		TupleContext _localctx = new TupleContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_tuple);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(740);
			match(OPEN);
			setState(741);
			match(T__53);
			setState(742);
			int_();
			setState(743);
			cstorage();
			setState(744);
			match(T__38);
			setState(745);
			pointstorage();
			setState(746);
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
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
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
		enterRule(_localctx, 138, RULE_partition);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(748);
			match(OPEN);
			setState(749);
			match(T__54);
			setState(771);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case LETT:
			case OPEN:
				{
				{
				setState(750);
				str();
				setState(757);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
				case 1:
					{
					setState(751);
					aggcs();
					}
					break;
				case 2:
					{
					setState(753); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(752);
							cstorage();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(755); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,50,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				}
				}
				}
				break;
			case T__51:
				{
				{
				setState(759);
				match(T__51);
				setState(766);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,53,_ctx) ) {
				case 1:
					{
					setState(760);
					aggcs();
					}
					break;
				case 2:
					{
					setState(762); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(761);
							cstorage();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(764); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,52,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				}
				setState(768);
				match(T__38);
				setState(769);
				pointstorage();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(773);
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
	public static class AggcsContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggcsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggcs; }
	}

	public final AggcsContext aggcs() throws RecognitionException {
		AggcsContext _localctx = new AggcsContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_aggcs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(775);
			match(OPEN);
			setState(776);
			match(T__14);
			setState(777);
			collection();
			setState(778);
			var();
			setState(779);
			cstorage();
			setState(780);
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
		public TerminalNode EQOP() { return getToken(RecycleParser.EQOP, 0); }
		public List<StrContext> str() {
			return getRuleContexts(StrContext.class);
		}
		public StrContext str(int i) {
			return getRuleContext(StrContext.class,i);
		}
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
		public AggbContext aggb() {
			return getRuleContext(AggbContext.class,0);
		}
		public BooleanContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean; }
	}

	public final BooleanContext boolean_() throws RecognitionException {
		BooleanContext _localctx = new BooleanContext(_ctx, getState());
		enterRule(_localctx, 142, RULE_boolean);
		try {
			int _alt;
			setState(817);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,57,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(782);
				match(OPEN);
				setState(812);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,56,_ctx) ) {
				case 1:
					{
					setState(783);
					match(BOOLOP);
					setState(784);
					boolean_();
					setState(786); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(785);
							boolean_();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(788); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,55,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				case 2:
					{
					setState(790);
					intop();
					setState(791);
					int_();
					setState(792);
					int_();
					}
					break;
				case 3:
					{
					setState(794);
					match(EQOP);
					setState(795);
					str();
					setState(796);
					str();
					}
					break;
				case 4:
					{
					setState(798);
					match(EQOP);
					setState(799);
					card();
					setState(800);
					card();
					}
					break;
				case 5:
					{
					setState(802);
					match(UNOP);
					setState(803);
					boolean_();
					}
					break;
				case 6:
					{
					setState(804);
					match(EQOP);
					setState(805);
					whop();
					setState(806);
					whop();
					}
					break;
				case 7:
					{
					setState(808);
					match(EQOP);
					setState(809);
					whot();
					setState(810);
					whot();
					}
					break;
				}
				setState(814);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(816);
				aggb();
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
	}

	public final IntopContext intop() throws RecognitionException {
		IntopContext _localctx = new IntopContext(_ctx, getState());
		enterRule(_localctx, 144, RULE_intop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(819);
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
	public static class AggbContext extends ParserRuleContext {
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
		public AggbContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggb; }
	}

	public final AggbContext aggb() throws RecognitionException {
		AggbContext _localctx = new AggbContext(_ctx, getState());
		enterRule(_localctx, 146, RULE_aggb);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(821);
			match(OPEN);
			setState(822);
			_la = _input.LA(1);
			if ( !(_la==T__13 || _la==T__14) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(823);
			collection();
			setState(824);
			var();
			setState(825);
			boolean_();
			setState(826);
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
		public VariContext vari() {
			return getRuleContext(VariContext.class,0);
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

	public final IntContext int_() throws RecognitionException {
		IntContext _localctx = new IntContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_int);
		try {
			int _alt;
			setState(847);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,59,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(828);
				vari();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(829);
				sizeof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(830);
				mult();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(831);
				subtract();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(832);
				mod();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(833);
				add();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(834);
				divide();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(835);
				exponent();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(836);
				triangular();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(837);
				fibonacci();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(838);
				random();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 12);
				{
				setState(839);
				sum();
				}
				break;
			case 13:
				enterOuterAlt(_localctx, 13);
				{
				setState(840);
				rawstorage();
				}
				break;
			case 14:
				enterOuterAlt(_localctx, 14);
				{
				setState(841);
				score();
				}
				break;
			case 15:
				enterOuterAlt(_localctx, 15);
				{
				setState(843); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(842);
						match(INTNUM);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(845); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,58,_ctx);
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
		enterRule(_localctx, 150, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(849);
			match(OPEN);
			setState(850);
			match(T__55);
			setState(851);
			cstorage();
			setState(852);
			match(T__38);
			setState(853);
			pointstorage();
			setState(854);
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
	}

	public final ScoreContext score() throws RecognitionException {
		ScoreContext _localctx = new ScoreContext(_ctx, getState());
		enterRule(_localctx, 152, RULE_score);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(856);
			match(OPEN);
			setState(857);
			match(T__56);
			setState(858);
			card();
			setState(859);
			match(T__38);
			setState(860);
			pointstorage();
			setState(861);
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
	}

	public final AddContext add() throws RecognitionException {
		AddContext _localctx = new AddContext(_ctx, getState());
		enterRule(_localctx, 154, RULE_add);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(863);
			match(OPEN);
			setState(864);
			match(T__57);
			setState(865);
			int_();
			setState(866);
			int_();
			setState(867);
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
	}

	public final MultContext mult() throws RecognitionException {
		MultContext _localctx = new MultContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_mult);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(869);
			match(OPEN);
			setState(870);
			match(T__58);
			setState(871);
			int_();
			setState(872);
			int_();
			setState(873);
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
	}

	public final SubtractContext subtract() throws RecognitionException {
		SubtractContext _localctx = new SubtractContext(_ctx, getState());
		enterRule(_localctx, 158, RULE_subtract);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(875);
			match(OPEN);
			setState(876);
			match(T__59);
			setState(877);
			int_();
			setState(878);
			int_();
			setState(879);
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
	}

	public final ModContext mod() throws RecognitionException {
		ModContext _localctx = new ModContext(_ctx, getState());
		enterRule(_localctx, 160, RULE_mod);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(881);
			match(OPEN);
			setState(882);
			match(T__60);
			setState(883);
			int_();
			setState(884);
			int_();
			setState(885);
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
	}

	public final DivideContext divide() throws RecognitionException {
		DivideContext _localctx = new DivideContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_divide);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(887);
			match(OPEN);
			setState(888);
			match(T__61);
			setState(889);
			int_();
			setState(890);
			int_();
			setState(891);
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
	}

	public final ExponentContext exponent() throws RecognitionException {
		ExponentContext _localctx = new ExponentContext(_ctx, getState());
		enterRule(_localctx, 164, RULE_exponent);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(893);
			match(OPEN);
			setState(894);
			match(T__62);
			setState(895);
			int_();
			setState(896);
			int_();
			setState(897);
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
	}

	public final TriangularContext triangular() throws RecognitionException {
		TriangularContext _localctx = new TriangularContext(_ctx, getState());
		enterRule(_localctx, 166, RULE_triangular);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(899);
			match(OPEN);
			setState(900);
			match(T__63);
			setState(901);
			int_();
			setState(902);
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
	}

	public final FibonacciContext fibonacci() throws RecognitionException {
		FibonacciContext _localctx = new FibonacciContext(_ctx, getState());
		enterRule(_localctx, 168, RULE_fibonacci);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(904);
			match(OPEN);
			setState(905);
			match(T__64);
			setState(906);
			int_();
			setState(907);
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
	}

	public final RandomContext random() throws RecognitionException {
		RandomContext _localctx = new RandomContext(_ctx, getState());
		enterRule(_localctx, 170, RULE_random);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(909);
			match(OPEN);
			setState(910);
			match(T__65);
			setState(911);
			int_();
			setState(914);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__44) {
				{
				setState(912);
				match(T__44);
				setState(913);
				int_();
				}
			}

			setState(916);
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
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SizeofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sizeof; }
	}

	public final SizeofContext sizeof() throws RecognitionException {
		SizeofContext _localctx = new SizeofContext(_ctx, getState());
		enterRule(_localctx, 172, RULE_sizeof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(918);
			match(OPEN);
			setState(919);
			match(T__66);
			setState(920);
			collection();
			setState(921);
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
	public static class AggiContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CollectionContext collection() {
			return getRuleContext(CollectionContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public RawstorageContext rawstorage() {
			return getRuleContext(RawstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public AggiContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggi; }
	}

	public final AggiContext aggi() throws RecognitionException {
		AggiContext _localctx = new AggiContext(_ctx, getState());
		enterRule(_localctx, 174, RULE_aggi);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(923);
			match(OPEN);
			setState(924);
			match(T__14);
			setState(925);
			collection();
			setState(926);
			var();
			setState(927);
			rawstorage();
			setState(928);
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
		public VaroContext varo() {
			return getRuleContext(VaroContext.class,0);
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
		enterRule(_localctx, 176, RULE_rawstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(930);
			match(OPEN);
			setState(934);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(931);
				varo();
				}
				break;
			case T__1:
				{
				setState(932);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(933);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(936);
			match(T__67);
			setState(937);
			str();
			setState(938);
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
	public static class StrContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public StrstorageContext strstorage() {
			return getRuleContext(StrstorageContext.class,0);
		}
		public VarsContext vars() {
			return getRuleContext(VarsContext.class,0);
		}
		public CardattContext cardatt() {
			return getRuleContext(CardattContext.class,0);
		}
		public StrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_str; }
	}

	public final StrContext str() throws RecognitionException {
		StrContext _localctx = new StrContext(_ctx, getState());
		enterRule(_localctx, 178, RULE_str);
		try {
			setState(944);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,62,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(940);
				namegr();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(941);
				strstorage();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(942);
				vars();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(943);
				cardatt();
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
	public static class StrstorageContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VaroContext varo() {
			return getRuleContext(VaroContext.class,0);
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
		enterRule(_localctx, 180, RULE_strstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(946);
			match(OPEN);
			setState(950);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(947);
				varo();
				}
				break;
			case T__1:
				{
				setState(948);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(949);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(952);
			match(T__68);
			setState(953);
			str();
			setState(954);
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
	public static class CardattContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public StrContext str() {
			return getRuleContext(StrContext.class,0);
		}
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
		enterRule(_localctx, 182, RULE_cardatt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(956);
			match(OPEN);
			setState(957);
			match(T__69);
			setState(958);
			str();
			setState(959);
			card();
			setState(960);
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
		enterRule(_localctx, 184, RULE_namegr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(963); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(962);
					match(LETT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(965); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,64,_ctx);
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
		"\u0004\u0001P\u03c8\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
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
		"P\u0007P\u0002Q\u0007Q\u0002R\u0007R\u0002S\u0007S\u0002T\u0007T\u0002"+
		"U\u0007U\u0002V\u0007V\u0002W\u0007W\u0002X\u0007X\u0002Y\u0007Y\u0002"+
		"Z\u0007Z\u0002[\u0007[\u0002\\\u0007\\\u0001\u0000\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0004"+
		"\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\b\u0001\t\u0001"+
		"\t\u0001\t\u0005\t\u00d9\b\t\n\t\f\t\u00dc\t\t\u0001\t\u0001\t\u0001\t"+
		"\u0004\t\u00e1\b\t\u000b\t\f\t\u00e2\u0001\t\u0001\t\u0001\t\u0001\n\u0001"+
		"\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001\u000b"+
		"\u0001\u000b\u0003\u000b\u00f2\b\u000b\u0001\u000b\u0001\u000b\u0001\u000b"+
		"\u0003\u000b\u00f7\b\u000b\u0001\u000b\u0001\u000b\u0004\u000b\u00fb\b"+
		"\u000b\u000b\u000b\f\u000b\u00fc\u0001\u000b\u0001\u000b\u0001\f\u0001"+
		"\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0004\r\u010d\b\r\u000b\r\f\r\u010e\u0001\r\u0001\r\u0001\u000e"+
		"\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f"+
		"\u0001\u000f\u0001\u000f\u0004\u000f\u011c\b\u000f\u000b\u000f\f\u000f"+
		"\u011d\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0004\u000f\u0127\b\u000f\u000b\u000f\f\u000f\u0128"+
		"\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0003\u000f"+
		"\u0130\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0004\u0010"+
		"\u0136\b\u0010\u000b\u0010\f\u0010\u0137\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0003\u0010\u013f\b\u0010\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0003\u0011\u014d"+
		"\b\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u015d\b\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0001\u0014\u0003\u0014\u016e\b\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0003\u0014\u0173\b\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0004\u0016\u017f\b\u0016\u000b\u0016\f\u0016\u0180\u0001\u0016"+
		"\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0005\u0017\u0188\b\u0017"+
		"\n\u0017\f\u0017\u018b\t\u0017\u0001\u0017\u0001\u0017\u0005\u0017\u018f"+
		"\b\u0017\n\u0017\f\u0017\u0192\t\u0017\u0001\u0017\u0001\u0017\u0001\u0018"+
		"\u0001\u0018\u0001\u0018\u0003\u0018\u0199\b\u0018\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0004\u0019\u01a1\b\u0019"+
		"\u000b\u0019\f\u0019\u01a2\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a"+
		"\u0001\u001a\u0001\u001a\u0005\u001a\u01ab\b\u001a\n\u001a\f\u001a\u01ae"+
		"\t\u001a\u0001\u001a\u0001\u001a\u0005\u001a\u01b2\b\u001a\n\u001a\f\u001a"+
		"\u01b5\t\u001a\u0001\u001a\u0001\u001a\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0001\u001b\u0004\u001b\u01bd\b\u001b\u000b\u001b\f\u001b\u01be\u0001"+
		"\u001b\u0001\u001b\u0001\u001c\u0001\u001c\u0004\u001c\u01c5\b\u001c\u000b"+
		"\u001c\f\u001c\u01c6\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0003"+
		"\u001e\u01d9\b\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		" \u0001 \u0001 \u0001 \u0001!\u0001!\u0001!\u0001!\u0001\"\u0001\"\u0001"+
		"\"\u0001\"\u0001#\u0001#\u0001#\u0001#\u0001$\u0001$\u0001$\u0001%\u0001"+
		"%\u0001%\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001&\u0001"+
		"&\u0001&\u0003&\u01ff\b&\u0001\'\u0001\'\u0001\'\u0001\'\u0003\'\u0205"+
		"\b\'\u0001\'\u0001\'\u0001\'\u0001\'\u0001(\u0001(\u0001(\u0001(\u0001"+
		"(\u0001(\u0001(\u0001(\u0003(\u0213\b(\u0001(\u0001(\u0001(\u0003(\u0218"+
		"\b(\u0001)\u0001)\u0001)\u0001)\u0001)\u0001*\u0001*\u0001*\u0001*\u0001"+
		"*\u0001*\u0001*\u0001+\u0001+\u0001+\u0001+\u0001+\u0001+\u0001+\u0001"+
		",\u0001,\u0001,\u0003,\u0230\b,\u0001-\u0001-\u0001.\u0001.\u0003.\u0236"+
		"\b.\u0001/\u0001/\u0001/\u0001/\u0001/\u0001/\u0003/\u023e\b/\u00010\u0001"+
		"0\u00010\u00010\u00010\u00010\u00030\u0246\b0\u00011\u00011\u00011\u0001"+
		"1\u00031\u024c\b1\u00012\u00012\u00012\u00012\u00012\u00013\u00013\u0001"+
		"3\u00013\u00033\u0257\b3\u00013\u00013\u00014\u00014\u00014\u00014\u0003"+
		"4\u025f\b4\u00015\u00015\u00015\u00015\u00015\u00015\u00015\u00015\u0001"+
		"5\u00015\u00035\u026b\b5\u00016\u00016\u00016\u00016\u00056\u0271\b6\n"+
		"6\f6\u0274\t6\u00016\u00016\u00016\u00017\u00017\u00017\u00017\u00017"+
		"\u00017\u00017\u00018\u00018\u00018\u00018\u00018\u00019\u00019\u0001"+
		"9\u00019\u00019\u00019\u00019\u00019\u00019\u00019\u00019\u00019\u0001"+
		"9\u00039\u0292\b9\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001"+
		";\u0001;\u0001;\u0001;\u0004;\u029f\b;\u000b;\f;\u02a0\u0003;\u02a3\b"+
		";\u0001;\u0001;\u0001<\u0001<\u0001<\u0001<\u0004<\u02ab\b<\u000b<\f<"+
		"\u02ac\u0003<\u02af\b<\u0001<\u0001<\u0001=\u0001=\u0001=\u0001=\u0004"+
		"=\u02b7\b=\u000b=\f=\u02b8\u0003=\u02bb\b=\u0001=\u0001=\u0001>\u0001"+
		">\u0001>\u0001>\u0001>\u0001>\u0001>\u0001?\u0001?\u0001?\u0001?\u0003"+
		"?\u02ca\b?\u0001?\u0001?\u0001?\u0001@\u0001@\u0001@\u0003@\u02d2\b@\u0001"+
		"A\u0001A\u0001A\u0003A\u02d7\bA\u0001B\u0001B\u0001B\u0001B\u0001B\u0001"+
		"B\u0001B\u0001C\u0001C\u0001C\u0001C\u0001C\u0001D\u0001D\u0001D\u0001"+
		"D\u0001D\u0001D\u0001D\u0001D\u0001E\u0001E\u0001E\u0001E\u0001E\u0004"+
		"E\u02f2\bE\u000bE\fE\u02f3\u0003E\u02f6\bE\u0001E\u0001E\u0001E\u0004"+
		"E\u02fb\bE\u000bE\fE\u02fc\u0003E\u02ff\bE\u0001E\u0001E\u0001E\u0003"+
		"E\u0304\bE\u0001E\u0001E\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001"+
		"F\u0001G\u0001G\u0001G\u0001G\u0004G\u0313\bG\u000bG\fG\u0314\u0001G\u0001"+
		"G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001"+
		"G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001G\u0001"+
		"G\u0003G\u032d\bG\u0001G\u0001G\u0001G\u0003G\u0332\bG\u0001H\u0001H\u0001"+
		"I\u0001I\u0001I\u0001I\u0001I\u0001I\u0001I\u0001J\u0001J\u0001J\u0001"+
		"J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001J\u0001"+
		"J\u0001J\u0004J\u034c\bJ\u000bJ\fJ\u034d\u0003J\u0350\bJ\u0001K\u0001"+
		"K\u0001K\u0001K\u0001K\u0001K\u0001K\u0001L\u0001L\u0001L\u0001L\u0001"+
		"L\u0001L\u0001L\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001N\u0001"+
		"N\u0001N\u0001N\u0001N\u0001N\u0001O\u0001O\u0001O\u0001O\u0001O\u0001"+
		"O\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001Q\u0001Q\u0001Q\u0001"+
		"Q\u0001Q\u0001Q\u0001R\u0001R\u0001R\u0001R\u0001R\u0001R\u0001S\u0001"+
		"S\u0001S\u0001S\u0001S\u0001T\u0001T\u0001T\u0001T\u0001T\u0001U\u0001"+
		"U\u0001U\u0001U\u0001U\u0003U\u0393\bU\u0001U\u0001U\u0001V\u0001V\u0001"+
		"V\u0001V\u0001V\u0001W\u0001W\u0001W\u0001W\u0001W\u0001W\u0001W\u0001"+
		"X\u0001X\u0001X\u0001X\u0003X\u03a7\bX\u0001X\u0001X\u0001X\u0001X\u0001"+
		"Y\u0001Y\u0001Y\u0001Y\u0003Y\u03b1\bY\u0001Z\u0001Z\u0001Z\u0001Z\u0003"+
		"Z\u03b7\bZ\u0001Z\u0001Z\u0001Z\u0001Z\u0001[\u0001[\u0001[\u0001[\u0001"+
		"[\u0001[\u0001\\\u0004\\\u03c4\b\\\u000b\\\f\\\u03c5\u0001\\\u0016\u00da"+
		"\u00e2\u00fc\u010e\u011d\u0128\u0137\u0180\u0189\u0190\u01a2\u01ac\u01b3"+
		"\u01be\u01c6\u0272\u02a0\u02ac\u02b8\u02f3\u02fc\u0314\u0000]\u0000\u0002"+
		"\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e"+
		" \"$&(*,.02468:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086"+
		"\u0088\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098\u009a\u009c\u009e"+
		"\u00a0\u00a2\u00a4\u00a6\u00a8\u00aa\u00ac\u00ae\u00b0\u00b2\u00b4\u00b6"+
		"\u00b8\u0000\u0006\u0001\u0000\u0006\u0007\u0001\u0000\t\n\u0001\u0000"+
		"\u000e\u000f\u0001\u0000\u0019\u001a\u0001\u0000(*\u0001\u0000HI\u03ef"+
		"\u0000\u00ba\u0001\u0000\u0000\u0000\u0002\u00bd\u0001\u0000\u0000\u0000"+
		"\u0004\u00c0\u0001\u0000\u0000\u0000\u0006\u00c3\u0001\u0000\u0000\u0000"+
		"\b\u00c6\u0001\u0000\u0000\u0000\n\u00c9\u0001\u0000\u0000\u0000\f\u00cc"+
		"\u0001\u0000\u0000\u0000\u000e\u00cf\u0001\u0000\u0000\u0000\u0010\u00d2"+
		"\u0001\u0000\u0000\u0000\u0012\u00d5\u0001\u0000\u0000\u0000\u0014\u00e7"+
		"\u0001\u0000\u0000\u0000\u0016\u00ed\u0001\u0000\u0000\u0000\u0018\u0100"+
		"\u0001\u0000\u0000\u0000\u001a\u0106\u0001\u0000\u0000\u0000\u001c\u0112"+
		"\u0001\u0000\u0000\u0000\u001e\u012f\u0001\u0000\u0000\u0000 \u013e\u0001"+
		"\u0000\u0000\u0000\"\u014c\u0001\u0000\u0000\u0000$\u014e\u0001\u0000"+
		"\u0000\u0000&\u0155\u0001\u0000\u0000\u0000(\u0172\u0001\u0000\u0000\u0000"+
		"*\u0174\u0001\u0000\u0000\u0000,\u017a\u0001\u0000\u0000\u0000.\u0184"+
		"\u0001\u0000\u0000\u00000\u0195\u0001\u0000\u0000\u00002\u019d\u0001\u0000"+
		"\u0000\u00004\u01a6\u0001\u0000\u0000\u00006\u01b8\u0001\u0000\u0000\u0000"+
		"8\u01c2\u0001\u0000\u0000\u0000:\u01cb\u0001\u0000\u0000\u0000<\u01d1"+
		"\u0001\u0000\u0000\u0000>\u01da\u0001\u0000\u0000\u0000@\u01de\u0001\u0000"+
		"\u0000\u0000B\u01e2\u0001\u0000\u0000\u0000D\u01e6\u0001\u0000\u0000\u0000"+
		"F\u01ea\u0001\u0000\u0000\u0000H\u01ee\u0001\u0000\u0000\u0000J\u01f1"+
		"\u0001\u0000\u0000\u0000L\u01fe\u0001\u0000\u0000\u0000N\u0200\u0001\u0000"+
		"\u0000\u0000P\u0217\u0001\u0000\u0000\u0000R\u0219\u0001\u0000\u0000\u0000"+
		"T\u021e\u0001\u0000\u0000\u0000V\u0225\u0001\u0000\u0000\u0000X\u022f"+
		"\u0001\u0000\u0000\u0000Z\u0231\u0001\u0000\u0000\u0000\\\u0235\u0001"+
		"\u0000\u0000\u0000^\u023d\u0001\u0000\u0000\u0000`\u0245\u0001\u0000\u0000"+
		"\u0000b\u024b\u0001\u0000\u0000\u0000d\u024d\u0001\u0000\u0000\u0000f"+
		"\u0252\u0001\u0000\u0000\u0000h\u025e\u0001\u0000\u0000\u0000j\u026a\u0001"+
		"\u0000\u0000\u0000l\u026c\u0001\u0000\u0000\u0000n\u0278\u0001\u0000\u0000"+
		"\u0000p\u027f\u0001\u0000\u0000\u0000r\u0291\u0001\u0000\u0000\u0000t"+
		"\u0293\u0001\u0000\u0000\u0000v\u029a\u0001\u0000\u0000\u0000x\u02a6\u0001"+
		"\u0000\u0000\u0000z\u02b2\u0001\u0000\u0000\u0000|\u02be\u0001\u0000\u0000"+
		"\u0000~\u02c5\u0001\u0000\u0000\u0000\u0080\u02d1\u0001\u0000\u0000\u0000"+
		"\u0082\u02d6\u0001\u0000\u0000\u0000\u0084\u02d8\u0001\u0000\u0000\u0000"+
		"\u0086\u02df\u0001\u0000\u0000\u0000\u0088\u02e4\u0001\u0000\u0000\u0000"+
		"\u008a\u02ec\u0001\u0000\u0000\u0000\u008c\u0307\u0001\u0000\u0000\u0000"+
		"\u008e\u0331\u0001\u0000\u0000\u0000\u0090\u0333\u0001\u0000\u0000\u0000"+
		"\u0092\u0335\u0001\u0000\u0000\u0000\u0094\u034f\u0001\u0000\u0000\u0000"+
		"\u0096\u0351\u0001\u0000\u0000\u0000\u0098\u0358\u0001\u0000\u0000\u0000"+
		"\u009a\u035f\u0001\u0000\u0000\u0000\u009c\u0365\u0001\u0000\u0000\u0000"+
		"\u009e\u036b\u0001\u0000\u0000\u0000\u00a0\u0371\u0001\u0000\u0000\u0000"+
		"\u00a2\u0377\u0001\u0000\u0000\u0000\u00a4\u037d\u0001\u0000\u0000\u0000"+
		"\u00a6\u0383\u0001\u0000\u0000\u0000\u00a8\u0388\u0001\u0000\u0000\u0000"+
		"\u00aa\u038d\u0001\u0000\u0000\u0000\u00ac\u0396\u0001\u0000\u0000\u0000"+
		"\u00ae\u039b\u0001\u0000\u0000\u0000\u00b0\u03a2\u0001\u0000\u0000\u0000"+
		"\u00b2\u03b0\u0001\u0000\u0000\u0000\u00b4\u03b2\u0001\u0000\u0000\u0000"+
		"\u00b6\u03bc\u0001\u0000\u0000\u0000\u00b8\u03c3\u0001\u0000\u0000\u0000"+
		"\u00ba\u00bb\u0005\u0001\u0000\u0000\u00bb\u00bc\u0003\u00b8\\\u0000\u00bc"+
		"\u0001\u0001\u0000\u0000\u0000\u00bd\u00be\u0005\u0001\u0000\u0000\u00be"+
		"\u00bf\u0003\u00b8\\\u0000\u00bf\u0003\u0001\u0000\u0000\u0000\u00c0\u00c1"+
		"\u0005\u0001\u0000\u0000\u00c1\u00c2\u0003\u00b8\\\u0000\u00c2\u0005\u0001"+
		"\u0000\u0000\u0000\u00c3\u00c4\u0005\u0001\u0000\u0000\u00c4\u00c5\u0003"+
		"\u00b8\\\u0000\u00c5\u0007\u0001\u0000\u0000\u0000\u00c6\u00c7\u0005\u0001"+
		"\u0000\u0000\u00c7\u00c8\u0003\u00b8\\\u0000\u00c8\t\u0001\u0000\u0000"+
		"\u0000\u00c9\u00ca\u0005\u0001\u0000\u0000\u00ca\u00cb\u0003\u00b8\\\u0000"+
		"\u00cb\u000b\u0001\u0000\u0000\u0000\u00cc\u00cd\u0005\u0001\u0000\u0000"+
		"\u00cd\u00ce\u0003\u00b8\\\u0000\u00ce\r\u0001\u0000\u0000\u0000\u00cf"+
		"\u00d0\u0005\u0001\u0000\u0000\u00d0\u00d1\u0003\u00b8\\\u0000\u00d1\u000f"+
		"\u0001\u0000\u0000\u0000\u00d2\u00d3\u0005\u0001\u0000\u0000\u00d3\u00d4"+
		"\u0003\u00b8\\\u0000\u00d4\u0011\u0001\u0000\u0000\u0000\u00d5\u00d6\u0005"+
		"M\u0000\u0000\u00d6\u00da\u0005\u0002\u0000\u0000\u00d7\u00d9\u0003\u0014"+
		"\n\u0000\u00d8\u00d7\u0001\u0000\u0000\u0000\u00d9\u00dc\u0001\u0000\u0000"+
		"\u0000\u00da\u00db\u0001\u0000\u0000\u0000\u00da\u00d8\u0001\u0000\u0000"+
		"\u0000\u00db\u00dd\u0001\u0000\u0000\u0000\u00dc\u00da\u0001\u0000\u0000"+
		"\u0000\u00dd\u00e0\u0003\u0016\u000b\u0000\u00de\u00e1\u0003\u001e\u000f"+
		"\u0000\u00df\u00e1\u0003\u001a\r\u0000\u00e0\u00de\u0001\u0000\u0000\u0000"+
		"\u00e0\u00df\u0001\u0000\u0000\u0000\u00e1\u00e2\u0001\u0000\u0000\u0000"+
		"\u00e2\u00e3\u0001\u0000\u0000\u0000\u00e2\u00e0\u0001\u0000\u0000\u0000"+
		"\u00e3\u00e4\u0001\u0000\u0000\u0000\u00e4\u00e5\u0003\u0018\f\u0000\u00e5"+
		"\u00e6\u0005N\u0000\u0000\u00e6\u0013\u0001\u0000\u0000\u0000\u00e7\u00e8"+
		"\u0005M\u0000\u0000\u00e8\u00e9\u0005\u0003\u0000\u0000\u00e9\u00ea\u0003"+
		"h4\u0000\u00ea\u00eb\u0003\u0000\u0000\u0000\u00eb\u00ec\u0005N\u0000"+
		"\u0000\u00ec\u0015\u0001\u0000\u0000\u0000\u00ed\u00ee\u0005M\u0000\u0000"+
		"\u00ee\u00ef\u0005\u0004\u0000\u0000\u00ef\u00f1\u0003*\u0015\u0000\u00f0"+
		"\u00f2\u0003,\u0016\u0000\u00f1\u00f0\u0001\u0000\u0000\u0000\u00f1\u00f2"+
		"\u0001\u0000\u0000\u0000\u00f2\u00fa\u0001\u0000\u0000\u0000\u00f3\u00f6"+
		"\u0005M\u0000\u0000\u00f4\u00f7\u00030\u0018\u0000\u00f5\u00f7\u0003L"+
		"&\u0000\u00f6\u00f4\u0001\u0000\u0000\u0000\u00f6\u00f5\u0001\u0000\u0000"+
		"\u0000\u00f7\u00f8\u0001\u0000\u0000\u0000\u00f8\u00f9\u0005N\u0000\u0000"+
		"\u00f9\u00fb\u0001\u0000\u0000\u0000\u00fa\u00f3\u0001\u0000\u0000\u0000"+
		"\u00fb\u00fc\u0001\u0000\u0000\u0000\u00fc\u00fd\u0001\u0000\u0000\u0000"+
		"\u00fc\u00fa\u0001\u0000\u0000\u0000\u00fd\u00fe\u0001\u0000\u0000\u0000"+
		"\u00fe\u00ff\u0005N\u0000\u0000\u00ff\u0017\u0001\u0000\u0000\u0000\u0100"+
		"\u0101\u0005M\u0000\u0000\u0101\u0102\u0005\u0005\u0000\u0000\u0102\u0103"+
		"\u0007\u0000\u0000\u0000\u0103\u0104\u0003\u0094J\u0000\u0104\u0105\u0005"+
		"N\u0000\u0000\u0105\u0019\u0001\u0000\u0000\u0000\u0106\u0107\u0005M\u0000"+
		"\u0000\u0107\u0108\u0005\b\u0000\u0000\u0108\u0109\u0007\u0001\u0000\u0000"+
		"\u0109\u010c\u0003\u001c\u000e\u0000\u010a\u010d\u0003\u001e\u000f\u0000"+
		"\u010b\u010d\u0003\u001a\r\u0000\u010c\u010a\u0001\u0000\u0000\u0000\u010c"+
		"\u010b\u0001\u0000\u0000\u0000\u010d\u010e\u0001\u0000\u0000\u0000\u010e"+
		"\u010f\u0001\u0000\u0000\u0000\u010e\u010c\u0001\u0000\u0000\u0000\u010f"+
		"\u0110\u0001\u0000\u0000\u0000\u0110\u0111\u0005N\u0000\u0000\u0111\u001b"+
		"\u0001\u0000\u0000\u0000\u0112\u0113\u0005M\u0000\u0000\u0113\u0114\u0005"+
		"\u000b\u0000\u0000\u0114\u0115\u0003\u008eG\u0000\u0115\u0116\u0005N\u0000"+
		"\u0000\u0116\u001d\u0001\u0000\u0000\u0000\u0117\u0118\u0005M\u0000\u0000"+
		"\u0118\u0119\u0005\f\u0000\u0000\u0119\u011b\u0005M\u0000\u0000\u011a"+
		"\u011c\u0003\"\u0011\u0000\u011b\u011a\u0001\u0000\u0000\u0000\u011c\u011d"+
		"\u0001\u0000\u0000\u0000\u011d\u011e\u0001\u0000\u0000\u0000\u011d\u011b"+
		"\u0001\u0000\u0000\u0000\u011e\u011f\u0001\u0000\u0000\u0000\u011f\u0120"+
		"\u0005N\u0000\u0000\u0120\u0121\u0005N\u0000\u0000\u0121\u0130\u0001\u0000"+
		"\u0000\u0000\u0122\u0123\u0005M\u0000\u0000\u0123\u0124\u0005\r\u0000"+
		"\u0000\u0124\u0126\u0005M\u0000\u0000\u0125\u0127\u0003\"\u0011\u0000"+
		"\u0126\u0125\u0001\u0000\u0000\u0000\u0127\u0128\u0001\u0000\u0000\u0000"+
		"\u0128\u0129\u0001\u0000\u0000\u0000\u0128\u0126\u0001\u0000\u0000\u0000"+
		"\u0129\u012a\u0001\u0000\u0000\u0000\u012a\u012b\u0005N\u0000\u0000\u012b"+
		"\u012c\u0005N\u0000\u0000\u012c\u0130\u0001\u0000\u0000\u0000\u012d\u0130"+
		"\u0003$\u0012\u0000\u012e\u0130\u0003&\u0013\u0000\u012f\u0117\u0001\u0000"+
		"\u0000\u0000\u012f\u0122\u0001\u0000\u0000\u0000\u012f\u012d\u0001\u0000"+
		"\u0000\u0000\u012f\u012e\u0001\u0000\u0000\u0000\u0130\u001f\u0001\u0000"+
		"\u0000\u0000\u0131\u0132\u0005M\u0000\u0000\u0132\u0133\u0005\r\u0000"+
		"\u0000\u0133\u0135\u0005M\u0000\u0000\u0134\u0136\u0003\"\u0011\u0000"+
		"\u0135\u0134\u0001\u0000\u0000\u0000\u0136\u0137\u0001\u0000\u0000\u0000"+
		"\u0137\u0138\u0001\u0000\u0000\u0000\u0137\u0135\u0001\u0000\u0000\u0000"+
		"\u0138\u0139\u0001\u0000\u0000\u0000\u0139\u013a\u0005N\u0000\u0000\u013a"+
		"\u013b\u0005N\u0000\u0000\u013b\u013f\u0001\u0000\u0000\u0000\u013c\u013f"+
		"\u0003$\u0012\u0000\u013d\u013f\u0003&\u0013\u0000\u013e\u0131\u0001\u0000"+
		"\u0000\u0000\u013e\u013c\u0001\u0000\u0000\u0000\u013e\u013d\u0001\u0000"+
		"\u0000\u0000\u013f!\u0001\u0000\u0000\u0000\u0140\u0141\u0005M\u0000\u0000"+
		"\u0141\u0142\u0003\u008eG\u0000\u0142\u0143\u0003 \u0010\u0000\u0143\u0144"+
		"\u0005N\u0000\u0000\u0144\u014d\u0001\u0000\u0000\u0000\u0145\u014d\u0003"+
		" \u0010\u0000\u0146\u0147\u0005M\u0000\u0000\u0147\u0148\u0003\u008eG"+
		"\u0000\u0148\u0149\u0003(\u0014\u0000\u0149\u014a\u0005N\u0000\u0000\u014a"+
		"\u014d\u0001\u0000\u0000\u0000\u014b\u014d\u0003(\u0014\u0000\u014c\u0140"+
		"\u0001\u0000\u0000\u0000\u014c\u0145\u0001\u0000\u0000\u0000\u014c\u0146"+
		"\u0001\u0000\u0000\u0000\u014c\u014b\u0001\u0000\u0000\u0000\u014d#\u0001"+
		"\u0000\u0000\u0000\u014e\u014f\u0005M\u0000\u0000\u014f\u0150\u0007\u0002"+
		"\u0000\u0000\u0150\u0151\u0003j5\u0000\u0151\u0152\u0003\u0000\u0000\u0000"+
		"\u0152\u0153\u0003\"\u0011\u0000\u0153\u0154\u0005N\u0000\u0000\u0154"+
		"%\u0001\u0000\u0000\u0000\u0155\u0156\u0005M\u0000\u0000\u0156\u0157\u0005"+
		"\u0010\u0000\u0000\u0157\u0158\u0003h4\u0000\u0158\u015c\u0003\u0000\u0000"+
		"\u0000\u0159\u015d\u0003\u001e\u000f\u0000\u015a\u015d\u0003(\u0014\u0000"+
		"\u015b\u015d\u0003\"\u0011\u0000\u015c\u0159\u0001\u0000\u0000\u0000\u015c"+
		"\u015a\u0001\u0000\u0000\u0000\u015c\u015b\u0001\u0000\u0000\u0000\u015d"+
		"\u015e\u0001\u0000\u0000\u0000\u015e\u015f\u0005N\u0000\u0000\u015f\'"+
		"\u0001\u0000\u0000\u0000\u0160\u016d\u0005M\u0000\u0000\u0161\u016e\u0003"+
		"6\u001b\u0000\u0162\u016e\u0003,\u0016\u0000\u0163\u016e\u00030\u0018"+
		"\u0000\u0164\u016e\u0003<\u001e\u0000\u0165\u016e\u0003>\u001f\u0000\u0166"+
		"\u016e\u0003F#\u0000\u0167\u016e\u0003B!\u0000\u0168\u016e\u0003@ \u0000"+
		"\u0169\u016e\u0003D\"\u0000\u016a\u016e\u0003J%\u0000\u016b\u016e\u0003"+
		"H$\u0000\u016c\u016e\u0003L&\u0000\u016d\u0161\u0001\u0000\u0000\u0000"+
		"\u016d\u0162\u0001\u0000\u0000\u0000\u016d\u0163\u0001\u0000\u0000\u0000"+
		"\u016d\u0164\u0001\u0000\u0000\u0000\u016d\u0165\u0001\u0000\u0000\u0000"+
		"\u016d\u0166\u0001\u0000\u0000\u0000\u016d\u0167\u0001\u0000\u0000\u0000"+
		"\u016d\u0168\u0001\u0000\u0000\u0000\u016d\u0169\u0001\u0000\u0000\u0000"+
		"\u016d\u016a\u0001\u0000\u0000\u0000\u016d\u016b\u0001\u0000\u0000\u0000"+
		"\u016d\u016c\u0001\u0000\u0000\u0000\u016e\u016f\u0001\u0000\u0000\u0000"+
		"\u016f\u0170\u0005N\u0000\u0000\u0170\u0173\u0001\u0000\u0000\u0000\u0171"+
		"\u0173\u0003$\u0012\u0000\u0172\u0160\u0001\u0000\u0000\u0000\u0172\u0171"+
		"\u0001\u0000\u0000\u0000\u0173)\u0001\u0000\u0000\u0000\u0174\u0175\u0005"+
		"M\u0000\u0000\u0175\u0176\u0005\u0011\u0000\u0000\u0176\u0177\u0005\u0012"+
		"\u0000\u0000\u0177\u0178\u0003\u0094J\u0000\u0178\u0179\u0005N\u0000\u0000"+
		"\u0179+\u0001\u0000\u0000\u0000\u017a\u017b\u0005M\u0000\u0000\u017b\u017c"+
		"\u0005\u0011\u0000\u0000\u017c\u017e\u0005\u0013\u0000\u0000\u017d\u017f"+
		"\u0003.\u0017\u0000\u017e\u017d\u0001\u0000\u0000\u0000\u017f\u0180\u0001"+
		"\u0000\u0000\u0000\u0180\u0181\u0001\u0000\u0000\u0000\u0180\u017e\u0001"+
		"\u0000\u0000\u0000\u0181\u0182\u0001\u0000\u0000\u0000\u0182\u0183\u0005"+
		"N\u0000\u0000\u0183-\u0001\u0000\u0000\u0000\u0184\u0189\u0005M\u0000"+
		"\u0000\u0185\u0186\u0005K\u0000\u0000\u0186\u0188\u0005\u0014\u0000\u0000"+
		"\u0187\u0185\u0001\u0000\u0000\u0000\u0188\u018b\u0001\u0000\u0000\u0000"+
		"\u0189\u018a\u0001\u0000\u0000\u0000\u0189\u0187\u0001\u0000\u0000\u0000"+
		"\u018a\u018c\u0001\u0000\u0000\u0000\u018b\u0189\u0001\u0000\u0000\u0000"+
		"\u018c\u0190\u0005K\u0000\u0000\u018d\u018f\u0003.\u0017\u0000\u018e\u018d"+
		"\u0001\u0000\u0000\u0000\u018f\u0192\u0001\u0000\u0000\u0000\u0190\u0191"+
		"\u0001\u0000\u0000\u0000\u0190\u018e\u0001\u0000\u0000\u0000\u0191\u0193"+
		"\u0001\u0000\u0000\u0000\u0192\u0190\u0001\u0000\u0000\u0000\u0193\u0194"+
		"\u0005N\u0000\u0000\u0194/\u0001\u0000\u0000\u0000\u0195\u0196\u0005\u0011"+
		"\u0000\u0000\u0196\u0198\u0005\u0015\u0000\u0000\u0197\u0199\u0003\u00b2"+
		"Y\u0000\u0198\u0197\u0001\u0000\u0000\u0000\u0198\u0199\u0001\u0000\u0000"+
		"\u0000\u0199\u019a\u0001\u0000\u0000\u0000\u019a\u019b\u0003r9\u0000\u019b"+
		"\u019c\u00032\u0019\u0000\u019c1\u0001\u0000\u0000\u0000\u019d\u019e\u0005"+
		"M\u0000\u0000\u019e\u01a0\u0005\u0015\u0000\u0000\u019f\u01a1\u00034\u001a"+
		"\u0000\u01a0\u019f\u0001\u0000\u0000\u0000\u01a1\u01a2\u0001\u0000\u0000"+
		"\u0000\u01a2\u01a3\u0001\u0000\u0000\u0000\u01a2\u01a0\u0001\u0000\u0000"+
		"\u0000\u01a3\u01a4\u0001\u0000\u0000\u0000\u01a4\u01a5\u0005N\u0000\u0000"+
		"\u01a53\u0001\u0000\u0000\u0000\u01a6\u01ac\u0005M\u0000\u0000\u01a7\u01a8"+
		"\u0003\u00b8\\\u0000\u01a8\u01a9\u0005\u0014\u0000\u0000\u01a9\u01ab\u0001"+
		"\u0000\u0000\u0000\u01aa\u01a7\u0001\u0000\u0000\u0000\u01ab\u01ae\u0001"+
		"\u0000\u0000\u0000\u01ac\u01ad\u0001\u0000\u0000\u0000\u01ac\u01aa\u0001"+
		"\u0000\u0000\u0000\u01ad\u01af\u0001\u0000\u0000\u0000\u01ae\u01ac\u0001"+
		"\u0000\u0000\u0000\u01af\u01b3\u0003\u00b8\\\u0000\u01b0\u01b2\u00034"+
		"\u001a\u0000\u01b1\u01b0\u0001\u0000\u0000\u0000\u01b2\u01b5\u0001\u0000"+
		"\u0000\u0000\u01b3\u01b4\u0001\u0000\u0000\u0000\u01b3\u01b1\u0001\u0000"+
		"\u0000\u0000\u01b4\u01b6\u0001\u0000\u0000\u0000\u01b5\u01b3\u0001\u0000"+
		"\u0000\u0000\u01b6\u01b7\u0005N\u0000\u0000\u01b75\u0001\u0000\u0000\u0000"+
		"\u01b8\u01b9\u0005\u0016\u0000\u0000\u01b9\u01ba\u0003N\'\u0000\u01ba"+
		"\u01bc\u0005M\u0000\u0000\u01bb\u01bd\u00038\u001c\u0000\u01bc\u01bb\u0001"+
		"\u0000\u0000\u0000\u01bd\u01be\u0001\u0000\u0000\u0000\u01be\u01bf\u0001"+
		"\u0000\u0000\u0000\u01be\u01bc\u0001\u0000\u0000\u0000\u01bf\u01c0\u0001"+
		"\u0000\u0000\u0000\u01c0\u01c1\u0005N\u0000\u0000\u01c17\u0001\u0000\u0000"+
		"\u0000\u01c2\u01c4\u0005M\u0000\u0000\u01c3\u01c5\u0003:\u001d\u0000\u01c4"+
		"\u01c3\u0001\u0000\u0000\u0000\u01c5\u01c6\u0001\u0000\u0000\u0000\u01c6"+
		"\u01c7\u0001\u0000\u0000\u0000\u01c6\u01c4\u0001\u0000\u0000\u0000\u01c7"+
		"\u01c8\u0001\u0000\u0000\u0000\u01c8\u01c9\u0003\u0094J\u0000\u01c9\u01ca"+
		"\u0005N\u0000\u0000\u01ca9\u0001\u0000\u0000\u0000\u01cb\u01cc\u0005M"+
		"\u0000\u0000\u01cc\u01cd\u0003\u00b2Y\u0000\u01cd\u01ce\u0005\u0017\u0000"+
		"\u0000\u01ce\u01cf\u0003\u00b2Y\u0000\u01cf\u01d0\u0005N\u0000\u0000\u01d0"+
		";\u0001\u0000\u0000\u0000\u01d1\u01d2\u0005\u0018\u0000\u0000\u01d2\u01d8"+
		"\u0007\u0003\u0000\u0000\u01d3\u01d9\u0003d2\u0000\u01d4\u01d9\u0005\u001a"+
		"\u0000\u0000\u01d5\u01d9\u0005\u0019\u0000\u0000\u01d6\u01d9\u0005\u001b"+
		"\u0000\u0000\u01d7\u01d9\u0003\u0004\u0002\u0000\u01d8\u01d3\u0001\u0000"+
		"\u0000\u0000\u01d8\u01d4\u0001\u0000\u0000\u0000\u01d8\u01d5\u0001\u0000"+
		"\u0000\u0000\u01d8\u01d6\u0001\u0000\u0000\u0000\u01d8\u01d7\u0001\u0000"+
		"\u0000\u0000\u01d9=\u0001\u0000\u0000\u0000\u01da\u01db\u0005\u0016\u0000"+
		"\u0000\u01db\u01dc\u0003\u00b0X\u0000\u01dc\u01dd\u0003\u0094J\u0000\u01dd"+
		"?\u0001\u0000\u0000\u0000\u01de\u01df\u0005\u0016\u0000\u0000\u01df\u01e0"+
		"\u0003\u00b4Z\u0000\u01e0\u01e1\u0003\u00b2Y\u0000\u01e1A\u0001\u0000"+
		"\u0000\u0000\u01e2\u01e3\u0005\u001c\u0000\u0000\u01e3\u01e4\u0003\u00b0"+
		"X\u0000\u01e4\u01e5\u0003\u0094J\u0000\u01e5C\u0001\u0000\u0000\u0000"+
		"\u01e6\u01e7\u0005\u001d\u0000\u0000\u01e7\u01e8\u0003\u00b0X\u0000\u01e8"+
		"\u01e9\u0003\u0094J\u0000\u01e9E\u0001\u0000\u0000\u0000\u01ea\u01eb\u0005"+
		"\u001e\u0000\u0000\u01eb\u01ec\u0003P(\u0000\u01ec\u01ed\u0003P(\u0000"+
		"\u01edG\u0001\u0000\u0000\u0000\u01ee\u01ef\u0005\u001f\u0000\u0000\u01ef"+
		"\u01f0\u0003r9\u0000\u01f0I\u0001\u0000\u0000\u0000\u01f1\u01f2\u0005"+
		" \u0000\u0000\u01f2\u01f3\u0005!\u0000\u0000\u01f3K\u0001\u0000\u0000"+
		"\u0000\u01f4\u01f5\u0005\"\u0000\u0000\u01f5\u01f6\u0003\u0094J\u0000"+
		"\u01f6\u01f7\u0003(\u0014\u0000\u01f7\u01ff\u0001\u0000\u0000\u0000\u01f8"+
		"\u01f9\u0005\"\u0000\u0000\u01f9\u01fa\u0005\u000f\u0000\u0000\u01fa\u01fb"+
		"\u0005M\u0000\u0000\u01fb\u01fc\u0003F#\u0000\u01fc\u01fd\u0005N\u0000"+
		"\u0000\u01fd\u01ff\u0001\u0000\u0000\u0000\u01fe\u01f4\u0001\u0000\u0000"+
		"\u0000\u01fe\u01f8\u0001\u0000\u0000\u0000\u01ffM\u0001\u0000\u0000\u0000"+
		"\u0200\u0204\u0005M\u0000\u0000\u0201\u0205\u0003\u0004\u0002\u0000\u0202"+
		"\u0205\u0005\u0002\u0000\u0000\u0203\u0205\u0003\\.\u0000\u0204\u0201"+
		"\u0001\u0000\u0000\u0000\u0204\u0202\u0001\u0000\u0000\u0000\u0204\u0203"+
		"\u0001\u0000\u0000\u0000\u0205\u0206\u0001\u0000\u0000\u0000\u0206\u0207"+
		"\u0005#\u0000\u0000\u0207\u0208\u0003\u00b2Y\u0000\u0208\u0209\u0005N"+
		"\u0000\u0000\u0209O\u0001\u0000\u0000\u0000\u020a\u0218\u0003\u0010\b"+
		"\u0000\u020b\u0218\u0003T*\u0000\u020c\u0218\u0003V+\u0000\u020d\u0218"+
		"\u0003R)\u0000\u020e\u0212\u0005M\u0000\u0000\u020f\u0213\u0005$\u0000"+
		"\u0000\u0210\u0213\u0005%\u0000\u0000\u0211\u0213\u0003\u0094J\u0000\u0212"+
		"\u020f\u0001\u0000\u0000\u0000\u0212\u0210\u0001\u0000\u0000\u0000\u0212"+
		"\u0211\u0001\u0000\u0000\u0000\u0213\u0214\u0001\u0000\u0000\u0000\u0214"+
		"\u0215\u0003r9\u0000\u0215\u0216\u0005N\u0000\u0000\u0216\u0218\u0001"+
		"\u0000\u0000\u0000\u0217\u020a\u0001\u0000\u0000\u0000\u0217\u020b\u0001"+
		"\u0000\u0000\u0000\u0217\u020c\u0001\u0000\u0000\u0000\u0217\u020d\u0001"+
		"\u0000\u0000\u0000\u0217\u020e\u0001\u0000\u0000\u0000\u0218Q\u0001\u0000"+
		"\u0000\u0000\u0219\u021a\u0005M\u0000\u0000\u021a\u021b\u0005&\u0000\u0000"+
		"\u021b\u021c\u0003P(\u0000\u021c\u021d\u0005N\u0000\u0000\u021dS\u0001"+
		"\u0000\u0000\u0000\u021e\u021f\u0005M\u0000\u0000\u021f\u0220\u0005\u0007"+
		"\u0000\u0000\u0220\u0221\u0003r9\u0000\u0221\u0222\u0005\'\u0000\u0000"+
		"\u0222\u0223\u0003N\'\u0000\u0223\u0224\u0005N\u0000\u0000\u0224U\u0001"+
		"\u0000\u0000\u0000\u0225\u0226\u0005M\u0000\u0000\u0226\u0227\u0005\u0006"+
		"\u0000\u0000\u0227\u0228\u0003r9\u0000\u0228\u0229\u0005\'\u0000\u0000"+
		"\u0229\u022a\u0003N\'\u0000\u022a\u022b\u0005N\u0000\u0000\u022bW\u0001"+
		"\u0000\u0000\u0000\u022c\u0230\u0005\u0002\u0000\u0000\u022d\u0230\u0003"+
		"\u0006\u0003\u0000\u022e\u0230\u0003^/\u0000\u022f\u022c\u0001\u0000\u0000"+
		"\u0000\u022f\u022d\u0001\u0000\u0000\u0000\u022f\u022e\u0001\u0000\u0000"+
		"\u0000\u0230Y\u0001\u0000\u0000\u0000\u0231\u0232\u0007\u0004\u0000\u0000"+
		"\u0232[\u0001\u0000\u0000\u0000\u0233\u0236\u0003`0\u0000\u0234\u0236"+
		"\u0003^/\u0000\u0235\u0233\u0001\u0000\u0000\u0000\u0235\u0234\u0001\u0000"+
		"\u0000\u0000\u0236]\u0001\u0000\u0000\u0000\u0237\u0238\u0005M\u0000\u0000"+
		"\u0238\u0239\u0003b1\u0000\u0239\u023a\u0005\t\u0000\u0000\u023a\u023b"+
		"\u0005N\u0000\u0000\u023b\u023e\u0001\u0000\u0000\u0000\u023c\u023e\u0003"+
		"d2\u0000\u023d\u0237\u0001\u0000\u0000\u0000\u023d\u023c\u0001\u0000\u0000"+
		"\u0000\u023e_\u0001\u0000\u0000\u0000\u023f\u0240\u0005M\u0000\u0000\u0240"+
		"\u0241\u0003b1\u0000\u0241\u0242\u0005\n\u0000\u0000\u0242\u0243\u0005"+
		"N\u0000\u0000\u0243\u0246\u0001\u0000\u0000\u0000\u0244\u0246\u0003f3"+
		"\u0000\u0245\u023f\u0001\u0000\u0000\u0000\u0245\u0244\u0001\u0000\u0000"+
		"\u0000\u0246a\u0001\u0000\u0000\u0000\u0247\u024c\u0003\u0094J\u0000\u0248"+
		"\u024c\u0005\u001b\u0000\u0000\u0249\u024c\u0005\u0019\u0000\u0000\u024a"+
		"\u024c\u0005\u001a\u0000\u0000\u024b\u0247\u0001\u0000\u0000\u0000\u024b"+
		"\u0248\u0001\u0000\u0000\u0000\u024b\u0249\u0001\u0000\u0000\u0000\u024b"+
		"\u024a\u0001\u0000\u0000\u0000\u024cc\u0001\u0000\u0000\u0000\u024d\u024e"+
		"\u0005M\u0000\u0000\u024e\u024f\u0005+\u0000\u0000\u024f\u0250\u0003P"+
		"(\u0000\u0250\u0251\u0005N\u0000\u0000\u0251e\u0001\u0000\u0000\u0000"+
		"\u0252\u0253\u0005M\u0000\u0000\u0253\u0256\u0005\n\u0000\u0000\u0254"+
		"\u0257\u0003\u0006\u0003\u0000\u0255\u0257\u0003^/\u0000\u0256\u0254\u0001"+
		"\u0000\u0000\u0000\u0256\u0255\u0001\u0000\u0000\u0000\u0257\u0258\u0001"+
		"\u0000\u0000\u0000\u0258\u0259\u0005N\u0000\u0000\u0259g\u0001\u0000\u0000"+
		"\u0000\u025a\u025f\u0003\u0094J\u0000\u025b\u025f\u0003\u008eG\u0000\u025c"+
		"\u025f\u0003\u00b2Y\u0000\u025d\u025f\u0003j5\u0000\u025e\u025a\u0001"+
		"\u0000\u0000\u0000\u025e\u025b\u0001\u0000\u0000\u0000\u025e\u025c\u0001"+
		"\u0000\u0000\u0000\u025e\u025d\u0001\u0000\u0000\u0000\u025fi\u0001\u0000"+
		"\u0000\u0000\u0260\u026b\u0003\f\u0006\u0000\u0261\u026b\u0003|>\u0000"+
		"\u0262\u026b\u0003r9\u0000\u0263\u026b\u0003l6\u0000\u0264\u026b\u0003"+
		"\u0080@\u0000\u0265\u026b\u0005\t\u0000\u0000\u0266\u026b\u0005\n\u0000"+
		"\u0000\u0267\u026b\u0003`0\u0000\u0268\u026b\u0003p8\u0000\u0269\u026b"+
		"\u0003n7\u0000\u026a\u0260\u0001\u0000\u0000\u0000\u026a\u0261\u0001\u0000"+
		"\u0000\u0000\u026a\u0262\u0001\u0000\u0000\u0000\u026a\u0263\u0001\u0000"+
		"\u0000\u0000\u026a\u0264\u0001\u0000\u0000\u0000\u026a\u0265\u0001\u0000"+
		"\u0000\u0000\u026a\u0266\u0001\u0000\u0000\u0000\u026a\u0267\u0001\u0000"+
		"\u0000\u0000\u026a\u0268\u0001\u0000\u0000\u0000\u026a\u0269\u0001\u0000"+
		"\u0000\u0000\u026bk\u0001\u0000\u0000\u0000\u026c\u0272\u0005M\u0000\u0000"+
		"\u026d\u026e\u0003\u00b8\\\u0000\u026e\u026f\u0005\u0014\u0000\u0000\u026f"+
		"\u0271\u0001\u0000\u0000\u0000\u0270\u026d\u0001\u0000\u0000\u0000\u0271"+
		"\u0274\u0001\u0000\u0000\u0000\u0272\u0273\u0001\u0000\u0000\u0000\u0272"+
		"\u0270\u0001\u0000\u0000\u0000\u0273\u0275\u0001\u0000\u0000\u0000\u0274"+
		"\u0272\u0001\u0000\u0000\u0000\u0275\u0276\u0003\u00b8\\\u0000\u0276\u0277"+
		"\u0005N\u0000\u0000\u0277m\u0001\u0000\u0000\u0000\u0278\u0279\u0005M"+
		"\u0000\u0000\u0279\u027a\u0005,\u0000\u0000\u027a\u027b\u0003\u0094J\u0000"+
		"\u027b\u027c\u0005-\u0000\u0000\u027c\u027d\u0003\u0094J\u0000\u027d\u027e"+
		"\u0005N\u0000\u0000\u027eo\u0001\u0000\u0000\u0000\u027f\u0280\u0005M"+
		"\u0000\u0000\u0280\u0281\u0005.\u0000\u0000\u0281\u0282\u0007\u0001\u0000"+
		"\u0000\u0282\u0283\u0005N\u0000\u0000\u0283q\u0001\u0000\u0000\u0000\u0284"+
		"\u0292\u0003\u000e\u0007\u0000\u0285\u0292\u0003v;\u0000\u0286\u0292\u0003"+
		"x<\u0000\u0287\u0292\u0003z=\u0000\u0288\u0292\u0003t:\u0000\u0289\u0292"+
		"\u0003|>\u0000\u028a\u028b\u0005M\u0000\u0000\u028b\u028c\u0003X,\u0000"+
		"\u028c\u028d\u0003Z-\u0000\u028d\u028e\u0003\u00b2Y\u0000\u028e\u028f"+
		"\u0005N\u0000\u0000\u028f\u0292\u0001\u0000\u0000\u0000\u0290\u0292\u0003"+
		"~?\u0000\u0291\u0284\u0001\u0000\u0000\u0000\u0291\u0285\u0001\u0000\u0000"+
		"\u0000\u0291\u0286\u0001\u0000\u0000\u0000\u0291\u0287\u0001\u0000\u0000"+
		"\u0000\u0291\u0288\u0001\u0000\u0000\u0000\u0291\u0289\u0001\u0000\u0000"+
		"\u0000\u0291\u028a\u0001\u0000\u0000\u0000\u0291\u0290\u0001\u0000\u0000"+
		"\u0000\u0292s\u0001\u0000\u0000\u0000\u0293\u0294\u0005M\u0000\u0000\u0294"+
		"\u0295\u0005/\u0000\u0000\u0295\u0296\u0003r9\u0000\u0296\u0297\u0005"+
		"\'\u0000\u0000\u0297\u0298\u0003N\'\u0000\u0298\u0299\u0005N\u0000\u0000"+
		"\u0299u\u0001\u0000\u0000\u0000\u029a\u029b\u0005M\u0000\u0000\u029b\u02a2"+
		"\u00050\u0000\u0000\u029c\u02a3\u0003\u008cF\u0000\u029d\u029f\u0003r"+
		"9\u0000\u029e\u029d\u0001\u0000\u0000\u0000\u029f\u02a0\u0001\u0000\u0000"+
		"\u0000\u02a0\u02a1\u0001\u0000\u0000\u0000\u02a0\u029e\u0001\u0000\u0000"+
		"\u0000\u02a1\u02a3\u0001\u0000\u0000\u0000\u02a2\u029c\u0001\u0000\u0000"+
		"\u0000\u02a2\u029e\u0001\u0000\u0000\u0000\u02a3\u02a4\u0001\u0000\u0000"+
		"\u0000\u02a4\u02a5\u0005N\u0000\u0000\u02a5w\u0001\u0000\u0000\u0000\u02a6"+
		"\u02a7\u0005M\u0000\u0000\u02a7\u02ae\u00051\u0000\u0000\u02a8\u02af\u0003"+
		"\u008cF\u0000\u02a9\u02ab\u0003r9\u0000\u02aa\u02a9\u0001\u0000\u0000"+
		"\u0000\u02ab\u02ac\u0001\u0000\u0000\u0000\u02ac\u02ad\u0001\u0000\u0000"+
		"\u0000\u02ac\u02aa\u0001\u0000\u0000\u0000\u02ad\u02af\u0001\u0000\u0000"+
		"\u0000\u02ae\u02a8\u0001\u0000\u0000\u0000\u02ae\u02aa\u0001\u0000\u0000"+
		"\u0000\u02af\u02b0\u0001\u0000\u0000\u0000\u02b0\u02b1\u0005N\u0000\u0000"+
		"\u02b1y\u0001\u0000\u0000\u0000\u02b2\u02b3\u0005M\u0000\u0000\u02b3\u02ba"+
		"\u00052\u0000\u0000\u02b4\u02bb\u0003\u008cF\u0000\u02b5\u02b7\u0003r"+
		"9\u0000\u02b6\u02b5\u0001\u0000\u0000\u0000\u02b7\u02b8\u0001\u0000\u0000"+
		"\u0000\u02b8\u02b9\u0001\u0000\u0000\u0000\u02b8\u02b6\u0001\u0000\u0000"+
		"\u0000\u02b9\u02bb\u0001\u0000\u0000\u0000\u02ba\u02b4\u0001\u0000\u0000"+
		"\u0000\u02ba\u02b6\u0001\u0000\u0000\u0000\u02bb\u02bc\u0001\u0000\u0000"+
		"\u0000\u02bc\u02bd\u0005N\u0000\u0000\u02bd{\u0001\u0000\u0000\u0000\u02be"+
		"\u02bf\u0005M\u0000\u0000\u02bf\u02c0\u00053\u0000\u0000\u02c0\u02c1\u0003"+
		"j5\u0000\u02c1\u02c2\u0003\u0000\u0000\u0000\u02c2\u02c3\u0003\u008eG"+
		"\u0000\u02c3\u02c4\u0005N\u0000\u0000\u02c4}\u0001\u0000\u0000\u0000\u02c5"+
		"\u02c9\u0005M\u0000\u0000\u02c6\u02ca\u0005$\u0000\u0000\u02c7\u02ca\u0005"+
		"%\u0000\u0000\u02c8\u02ca\u0003\u0094J\u0000\u02c9\u02c6\u0001\u0000\u0000"+
		"\u0000\u02c9\u02c7\u0001\u0000\u0000\u0000\u02c9\u02c8\u0001\u0000\u0000"+
		"\u0000\u02ca\u02cb\u0001\u0000\u0000\u0000\u02cb\u02cc\u0003\u0082A\u0000"+
		"\u02cc\u02cd\u0005N\u0000\u0000\u02cd\u007f\u0001\u0000\u0000\u0000\u02ce"+
		"\u02d2\u0003\u0082A\u0000\u02cf\u02d2\u0003\u008cF\u0000\u02d0\u02d2\u0003"+
		"&\u0013\u0000\u02d1\u02ce\u0001\u0000\u0000\u0000\u02d1\u02cf\u0001\u0000"+
		"\u0000\u0000\u02d1\u02d0\u0001\u0000\u0000\u0000\u02d2\u0081\u0001\u0000"+
		"\u0000\u0000\u02d3\u02d7\u0003\u0088D\u0000\u02d4\u02d7\u0003\u008aE\u0000"+
		"\u02d5\u02d7\u0003\u0086C\u0000\u02d6\u02d3\u0001\u0000\u0000\u0000\u02d6"+
		"\u02d4\u0001\u0000\u0000\u0000\u02d6\u02d5\u0001\u0000\u0000\u0000\u02d7"+
		"\u0083\u0001\u0000\u0000\u0000\u02d8\u02d9\u0005M\u0000\u0000\u02d9\u02da"+
		"\u00054\u0000\u0000\u02da\u02db\u0003r9\u0000\u02db\u02dc\u0005\'\u0000"+
		"\u0000\u02dc\u02dd\u0003N\'\u0000\u02dd\u02de\u0005N\u0000\u0000\u02de"+
		"\u0085\u0001\u0000\u0000\u0000\u02df\u02e0\u0005M\u0000\u0000\u02e0\u02e1"+
		"\u00055\u0000\u0000\u02e1\u02e2\u0003r9\u0000\u02e2\u02e3\u0005N\u0000"+
		"\u0000\u02e3\u0087\u0001\u0000\u0000\u0000\u02e4\u02e5\u0005M\u0000\u0000"+
		"\u02e5\u02e6\u00056\u0000\u0000\u02e6\u02e7\u0003\u0094J\u0000\u02e7\u02e8"+
		"\u0003r9\u0000\u02e8\u02e9\u0005\'\u0000\u0000\u02e9\u02ea\u0003N\'\u0000"+
		"\u02ea\u02eb\u0005N\u0000\u0000\u02eb\u0089\u0001\u0000\u0000\u0000\u02ec"+
		"\u02ed\u0005M\u0000\u0000\u02ed\u0303\u00057\u0000\u0000\u02ee\u02f5\u0003"+
		"\u00b2Y\u0000\u02ef\u02f6\u0003\u008cF\u0000\u02f0\u02f2\u0003r9\u0000"+
		"\u02f1\u02f0\u0001\u0000\u0000\u0000\u02f2\u02f3\u0001\u0000\u0000\u0000"+
		"\u02f3\u02f4\u0001\u0000\u0000\u0000\u02f3\u02f1\u0001\u0000\u0000\u0000"+
		"\u02f4\u02f6\u0001\u0000\u0000\u0000\u02f5\u02ef\u0001\u0000\u0000\u0000"+
		"\u02f5\u02f1\u0001\u0000\u0000\u0000\u02f6\u0304\u0001\u0000\u0000\u0000"+
		"\u02f7\u02fe\u00054\u0000\u0000\u02f8\u02ff\u0003\u008cF\u0000\u02f9\u02fb"+
		"\u0003r9\u0000\u02fa\u02f9\u0001\u0000\u0000\u0000\u02fb\u02fc\u0001\u0000"+
		"\u0000\u0000\u02fc\u02fd\u0001\u0000\u0000\u0000\u02fc\u02fa\u0001\u0000"+
		"\u0000\u0000\u02fd\u02ff\u0001\u0000\u0000\u0000\u02fe\u02f8\u0001\u0000"+
		"\u0000\u0000\u02fe\u02fa\u0001\u0000\u0000\u0000\u02ff\u0300\u0001\u0000"+
		"\u0000\u0000\u0300\u0301\u0005\'\u0000\u0000\u0301\u0302\u0003N\'\u0000"+
		"\u0302\u0304\u0001\u0000\u0000\u0000\u0303\u02ee\u0001\u0000\u0000\u0000"+
		"\u0303\u02f7\u0001\u0000\u0000\u0000\u0304\u0305\u0001\u0000\u0000\u0000"+
		"\u0305\u0306\u0005N\u0000\u0000\u0306\u008b\u0001\u0000\u0000\u0000\u0307"+
		"\u0308\u0005M\u0000\u0000\u0308\u0309\u0005\u000f\u0000\u0000\u0309\u030a"+
		"\u0003j5\u0000\u030a\u030b\u0003\u0000\u0000\u0000\u030b\u030c\u0003r"+
		"9\u0000\u030c\u030d\u0005N\u0000\u0000\u030d\u008d\u0001\u0000\u0000\u0000"+
		"\u030e\u032c\u0005M\u0000\u0000\u030f\u0310\u0005G\u0000\u0000\u0310\u0312"+
		"\u0003\u008eG\u0000\u0311\u0313\u0003\u008eG\u0000\u0312\u0311\u0001\u0000"+
		"\u0000\u0000\u0313\u0314\u0001\u0000\u0000\u0000\u0314\u0315\u0001\u0000"+
		"\u0000\u0000\u0314\u0312\u0001\u0000\u0000\u0000\u0315\u032d\u0001\u0000"+
		"\u0000\u0000\u0316\u0317\u0003\u0090H\u0000\u0317\u0318\u0003\u0094J\u0000"+
		"\u0318\u0319\u0003\u0094J\u0000\u0319\u032d\u0001\u0000\u0000\u0000\u031a"+
		"\u031b\u0005I\u0000\u0000\u031b\u031c\u0003\u00b2Y\u0000\u031c\u031d\u0003"+
		"\u00b2Y\u0000\u031d\u032d\u0001\u0000\u0000\u0000\u031e\u031f\u0005I\u0000"+
		"\u0000\u031f\u0320\u0003P(\u0000\u0320\u0321\u0003P(\u0000\u0321\u032d"+
		"\u0001\u0000\u0000\u0000\u0322\u0323\u0005J\u0000\u0000\u0323\u032d\u0003"+
		"\u008eG\u0000\u0324\u0325\u0005I\u0000\u0000\u0325\u0326\u0003^/\u0000"+
		"\u0326\u0327\u0003^/\u0000\u0327\u032d\u0001\u0000\u0000\u0000\u0328\u0329"+
		"\u0005I\u0000\u0000\u0329\u032a\u0003`0\u0000\u032a\u032b\u0003`0\u0000"+
		"\u032b\u032d\u0001\u0000\u0000\u0000\u032c\u030f\u0001\u0000\u0000\u0000"+
		"\u032c\u0316\u0001\u0000\u0000\u0000\u032c\u031a\u0001\u0000\u0000\u0000"+
		"\u032c\u031e\u0001\u0000\u0000\u0000\u032c\u0322\u0001\u0000\u0000\u0000"+
		"\u032c\u0324\u0001\u0000\u0000\u0000\u032c\u0328\u0001\u0000\u0000\u0000"+
		"\u032d\u032e\u0001\u0000\u0000\u0000\u032e\u032f\u0005N\u0000\u0000\u032f"+
		"\u0332\u0001\u0000\u0000\u0000\u0330\u0332\u0003\u0092I\u0000\u0331\u030e"+
		"\u0001\u0000\u0000\u0000\u0331\u0330\u0001\u0000\u0000\u0000\u0332\u008f"+
		"\u0001\u0000\u0000\u0000\u0333\u0334\u0007\u0005\u0000\u0000\u0334\u0091"+
		"\u0001\u0000\u0000\u0000\u0335\u0336\u0005M\u0000\u0000\u0336\u0337\u0007"+
		"\u0002\u0000\u0000\u0337\u0338\u0003j5\u0000\u0338\u0339\u0003\u0000\u0000"+
		"\u0000\u0339\u033a\u0003\u008eG\u0000\u033a\u033b\u0005N\u0000\u0000\u033b"+
		"\u0093\u0001\u0000\u0000\u0000\u033c\u0350\u0003\b\u0004\u0000\u033d\u0350"+
		"\u0003\u00acV\u0000\u033e\u0350\u0003\u009cN\u0000\u033f\u0350\u0003\u009e"+
		"O\u0000\u0340\u0350\u0003\u00a0P\u0000\u0341\u0350\u0003\u009aM\u0000"+
		"\u0342\u0350\u0003\u00a2Q\u0000\u0343\u0350\u0003\u00a4R\u0000\u0344\u0350"+
		"\u0003\u00a6S\u0000\u0345\u0350\u0003\u00a8T\u0000\u0346\u0350\u0003\u00aa"+
		"U\u0000\u0347\u0350\u0003\u0096K\u0000\u0348\u0350\u0003\u00b0X\u0000"+
		"\u0349\u0350\u0003\u0098L\u0000\u034a\u034c\u0005K\u0000\u0000\u034b\u034a"+
		"\u0001\u0000\u0000\u0000\u034c\u034d\u0001\u0000\u0000\u0000\u034d\u034b"+
		"\u0001\u0000\u0000\u0000\u034d\u034e\u0001\u0000\u0000\u0000\u034e\u0350"+
		"\u0001\u0000\u0000\u0000\u034f\u033c\u0001\u0000\u0000\u0000\u034f\u033d"+
		"\u0001\u0000\u0000\u0000\u034f\u033e\u0001\u0000\u0000\u0000\u034f\u033f"+
		"\u0001\u0000\u0000\u0000\u034f\u0340\u0001\u0000\u0000\u0000\u034f\u0341"+
		"\u0001\u0000\u0000\u0000\u034f\u0342\u0001\u0000\u0000\u0000\u034f\u0343"+
		"\u0001\u0000\u0000\u0000\u034f\u0344\u0001\u0000\u0000\u0000\u034f\u0345"+
		"\u0001\u0000\u0000\u0000\u034f\u0346\u0001\u0000\u0000\u0000\u034f\u0347"+
		"\u0001\u0000\u0000\u0000\u034f\u0348\u0001\u0000\u0000\u0000\u034f\u0349"+
		"\u0001\u0000\u0000\u0000\u034f\u034b\u0001\u0000\u0000\u0000\u0350\u0095"+
		"\u0001\u0000\u0000\u0000\u0351\u0352\u0005M\u0000\u0000\u0352\u0353\u0005"+
		"8\u0000\u0000\u0353\u0354\u0003r9\u0000\u0354\u0355\u0005\'\u0000\u0000"+
		"\u0355\u0356\u0003N\'\u0000\u0356\u0357\u0005N\u0000\u0000\u0357\u0097"+
		"\u0001\u0000\u0000\u0000\u0358\u0359\u0005M\u0000\u0000\u0359\u035a\u0005"+
		"9\u0000\u0000\u035a\u035b\u0003P(\u0000\u035b\u035c\u0005\'\u0000\u0000"+
		"\u035c\u035d\u0003N\'\u0000\u035d\u035e\u0005N\u0000\u0000\u035e\u0099"+
		"\u0001\u0000\u0000\u0000\u035f\u0360\u0005M\u0000\u0000\u0360\u0361\u0005"+
		":\u0000\u0000\u0361\u0362\u0003\u0094J\u0000\u0362\u0363\u0003\u0094J"+
		"\u0000\u0363\u0364\u0005N\u0000\u0000\u0364\u009b\u0001\u0000\u0000\u0000"+
		"\u0365\u0366\u0005M\u0000\u0000\u0366\u0367\u0005;\u0000\u0000\u0367\u0368"+
		"\u0003\u0094J\u0000\u0368\u0369\u0003\u0094J\u0000\u0369\u036a\u0005N"+
		"\u0000\u0000\u036a\u009d\u0001\u0000\u0000\u0000\u036b\u036c\u0005M\u0000"+
		"\u0000\u036c\u036d\u0005<\u0000\u0000\u036d\u036e\u0003\u0094J\u0000\u036e"+
		"\u036f\u0003\u0094J\u0000\u036f\u0370\u0005N\u0000\u0000\u0370\u009f\u0001"+
		"\u0000\u0000\u0000\u0371\u0372\u0005M\u0000\u0000\u0372\u0373\u0005=\u0000"+
		"\u0000\u0373\u0374\u0003\u0094J\u0000\u0374\u0375\u0003\u0094J\u0000\u0375"+
		"\u0376\u0005N\u0000\u0000\u0376\u00a1\u0001\u0000\u0000\u0000\u0377\u0378"+
		"\u0005M\u0000\u0000\u0378\u0379\u0005>\u0000\u0000\u0379\u037a\u0003\u0094"+
		"J\u0000\u037a\u037b\u0003\u0094J\u0000\u037b\u037c\u0005N\u0000\u0000"+
		"\u037c\u00a3\u0001\u0000\u0000\u0000\u037d\u037e\u0005M\u0000\u0000\u037e"+
		"\u037f\u0005?\u0000\u0000\u037f\u0380\u0003\u0094J\u0000\u0380\u0381\u0003"+
		"\u0094J\u0000\u0381\u0382\u0005N\u0000\u0000\u0382\u00a5\u0001\u0000\u0000"+
		"\u0000\u0383\u0384\u0005M\u0000\u0000\u0384\u0385\u0005@\u0000\u0000\u0385"+
		"\u0386\u0003\u0094J\u0000\u0386\u0387\u0005N\u0000\u0000\u0387\u00a7\u0001"+
		"\u0000\u0000\u0000\u0388\u0389\u0005M\u0000\u0000\u0389\u038a\u0005A\u0000"+
		"\u0000\u038a\u038b\u0003\u0094J\u0000\u038b\u038c\u0005N\u0000\u0000\u038c"+
		"\u00a9\u0001\u0000\u0000\u0000\u038d\u038e\u0005M\u0000\u0000\u038e\u038f"+
		"\u0005B\u0000\u0000\u038f\u0392\u0003\u0094J\u0000\u0390\u0391\u0005-"+
		"\u0000\u0000\u0391\u0393\u0003\u0094J\u0000\u0392\u0390\u0001\u0000\u0000"+
		"\u0000\u0392\u0393\u0001\u0000\u0000\u0000\u0393\u0394\u0001\u0000\u0000"+
		"\u0000\u0394\u0395\u0005N\u0000\u0000\u0395\u00ab\u0001\u0000\u0000\u0000"+
		"\u0396\u0397\u0005M\u0000\u0000\u0397\u0398\u0005C\u0000\u0000\u0398\u0399"+
		"\u0003j5\u0000\u0399\u039a\u0005N\u0000\u0000\u039a\u00ad\u0001\u0000"+
		"\u0000\u0000\u039b\u039c\u0005M\u0000\u0000\u039c\u039d\u0005\u000f\u0000"+
		"\u0000\u039d\u039e\u0003j5\u0000\u039e\u039f\u0003\u0000\u0000\u0000\u039f"+
		"\u03a0\u0003\u00b0X\u0000\u03a0\u03a1\u0005N\u0000\u0000\u03a1\u00af\u0001"+
		"\u0000\u0000\u0000\u03a2\u03a6\u0005M\u0000\u0000\u03a3\u03a7\u0003\u0004"+
		"\u0002\u0000\u03a4\u03a7\u0005\u0002\u0000\u0000\u03a5\u03a7\u0003\\."+
		"\u0000\u03a6\u03a3\u0001\u0000\u0000\u0000\u03a6\u03a4\u0001\u0000\u0000"+
		"\u0000\u03a6\u03a5\u0001\u0000\u0000\u0000\u03a7\u03a8\u0001\u0000\u0000"+
		"\u0000\u03a8\u03a9\u0005D\u0000\u0000\u03a9\u03aa\u0003\u00b2Y\u0000\u03aa"+
		"\u03ab\u0005N\u0000\u0000\u03ab\u00b1\u0001\u0000\u0000\u0000\u03ac\u03b1"+
		"\u0003\u00b8\\\u0000\u03ad\u03b1\u0003\u00b4Z\u0000\u03ae\u03b1\u0003"+
		"\u0002\u0001\u0000\u03af\u03b1\u0003\u00b6[\u0000\u03b0\u03ac\u0001\u0000"+
		"\u0000\u0000\u03b0\u03ad\u0001\u0000\u0000\u0000\u03b0\u03ae\u0001\u0000"+
		"\u0000\u0000\u03b0\u03af\u0001\u0000\u0000\u0000\u03b1\u00b3\u0001\u0000"+
		"\u0000\u0000\u03b2\u03b6\u0005M\u0000\u0000\u03b3\u03b7\u0003\u0004\u0002"+
		"\u0000\u03b4\u03b7\u0005\u0002\u0000\u0000\u03b5\u03b7\u0003\\.\u0000"+
		"\u03b6\u03b3\u0001\u0000\u0000\u0000\u03b6\u03b4\u0001\u0000\u0000\u0000"+
		"\u03b6\u03b5\u0001\u0000\u0000\u0000\u03b7\u03b8\u0001\u0000\u0000\u0000"+
		"\u03b8\u03b9\u0005E\u0000\u0000\u03b9\u03ba\u0003\u00b2Y\u0000\u03ba\u03bb"+
		"\u0005N\u0000\u0000\u03bb\u00b5\u0001\u0000\u0000\u0000\u03bc\u03bd\u0005"+
		"M\u0000\u0000\u03bd\u03be\u0005F\u0000\u0000\u03be\u03bf\u0003\u00b2Y"+
		"\u0000\u03bf\u03c0\u0003P(\u0000\u03c0\u03c1\u0005N\u0000\u0000\u03c1"+
		"\u00b7\u0001\u0000\u0000\u0000\u03c2\u03c4\u0005L\u0000\u0000\u03c3\u03c2"+
		"\u0001\u0000\u0000\u0000\u03c4\u03c5\u0001\u0000\u0000\u0000\u03c5\u03c3"+
		"\u0001\u0000\u0000\u0000\u03c5\u03c6\u0001\u0000\u0000\u0000\u03c6\u00b9"+
		"\u0001\u0000\u0000\u0000A\u00da\u00e0\u00e2\u00f1\u00f6\u00fc\u010c\u010e"+
		"\u011d\u0128\u012f\u0137\u013e\u014c\u015c\u016d\u0172\u0180\u0189\u0190"+
		"\u0198\u01a2\u01ac\u01b3\u01be\u01c6\u01d8\u01fe\u0204\u0212\u0217\u022f"+
		"\u0235\u023d\u0245\u024b\u0256\u025e\u026a\u0272\u0291\u02a0\u02a2\u02ac"+
		"\u02ae\u02b8\u02ba\u02c9\u02d1\u02d6\u02f3\u02f5\u02fc\u02fe\u0303\u0314"+
		"\u032c\u0331\u034d\u034f\u0392\u03a6\u03b0\u03b6\u03c5";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}