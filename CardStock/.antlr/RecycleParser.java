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
		T__66=67, T__67=68, T__68=69, T__69=70, T__70=71, T__71=72, T__72=73, 
		T__73=74, T__74=75, T__75=76, T__76=77, T__77=78, BOOLOP=79, COMPOP=80, 
		EQOP=81, UNOP=82, INTNUM=83, LETT=84, OPEN=85, CLOSE=86, WS=87, ANY=88;
	public static final int
		RULE_var = 0, RULE_vars = 1, RULE_varo = 2, RULE_varp = 3, RULE_vari = 4, 
		RULE_varb = 5, RULE_varc = 6, RULE_varcs = 7, RULE_varcsc = 8, RULE_varcard = 9, 
		RULE_game = 10, RULE_declare = 11, RULE_setup = 12, RULE_scoring = 13, 
		RULE_stage = 14, RULE_endcondition = 15, RULE_multiaction = 16, RULE_multiaction2 = 17, 
		RULE_condact = 18, RULE_agg = 19, RULE_let = 20, RULE_action = 21, RULE_playercreate = 22, 
		RULE_teamcreate = 23, RULE_teams = 24, RULE_deckcreate = 25, RULE_deck = 26, 
		RULE_attribute = 27, RULE_initpoints = 28, RULE_awards = 29, RULE_subaward = 30, 
		RULE_cycleaction = 31, RULE_setaction = 32, RULE_setstraction = 33, RULE_incaction = 34, 
		RULE_decaction = 35, RULE_moveaction = 36, RULE_copyaction = 37, RULE_removeaction = 38, 
		RULE_shuffleaction = 39, RULE_turnaction = 40, RULE_repeat = 41, RULE_pointstorage = 42, 
		RULE_card = 43, RULE_actual = 44, RULE_maxof = 45, RULE_minof = 46, RULE_locpre = 47, 
		RULE_locdesc = 48, RULE_who = 49, RULE_whop = 50, RULE_whot = 51, RULE_whodesc = 52, 
		RULE_owner = 53, RULE_teamp = 54, RULE_typed = 55, RULE_collection = 56, 
		RULE_strcollection = 57, RULE_range = 58, RULE_other = 59, RULE_cstorage = 60, 
		RULE_sortof = 61, RULE_unionof = 62, RULE_intersectof = 63, RULE_disjunctionof = 64, 
		RULE_filter = 65, RULE_memstorage = 66, RULE_sequence = 67, RULE_runsequence = 68, 
		RULE_cstoragecollection = 69, RULE_run = 70, RULE_subset = 71, RULE_tuple = 72, 
		RULE_partition = 73, RULE_aggcs = 74, RULE_indexed = 75, RULE_boolean = 76, 
		RULE_intop = 77, RULE_aggb = 78, RULE_int = 79, RULE_sum = 80, RULE_score = 81, 
		RULE_add = 82, RULE_mult = 83, RULE_subtract = 84, RULE_mod = 85, RULE_divide = 86, 
		RULE_exponent = 87, RULE_triangular = 88, RULE_fibonacci = 89, RULE_random = 90, 
		RULE_sizeof = 91, RULE_aggi = 92, RULE_rawstorage = 93, RULE_str = 94, 
		RULE_strstorage = 95, RULE_cardatt = 96, RULE_namegr = 97;
	private static String[] makeRuleNames() {
		return new String[] {
			"var", "vars", "varo", "varp", "vari", "varb", "varc", "varcs", "varcsc", 
			"varcard", "game", "declare", "setup", "scoring", "stage", "endcondition", 
			"multiaction", "multiaction2", "condact", "agg", "let", "action", "playercreate", 
			"teamcreate", "teams", "deckcreate", "deck", "attribute", "initpoints", 
			"awards", "subaward", "cycleaction", "setaction", "setstraction", "incaction", 
			"decaction", "moveaction", "copyaction", "removeaction", "shuffleaction", 
			"turnaction", "repeat", "pointstorage", "card", "actual", "maxof", "minof", 
			"locpre", "locdesc", "who", "whop", "whot", "whodesc", "owner", "teamp", 
			"typed", "collection", "strcollection", "range", "other", "cstorage", 
			"sortof", "unionof", "intersectof", "disjunctionof", "filter", "memstorage", 
			"sequence", "runsequence", "cstoragecollection", "run", "subset", "tuple", 
			"partition", "aggcs", "indexed", "boolean", "intop", "aggb", "int", "sum", 
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
			"'inc'", "'dec'", "'move'", "'remember'", "'forget'", "'shuffle'", "'faro'", 
			"'turn'", "'pass'", "'repeat'", "'points'", "'top'", "'bottom'", "'actual'", 
			"'using'", "'vloc'", "'iloc'", "'hloc'", "'oloc'", "'mem'", "'owner'", 
			"'range'", "'..'", "'other'", "'sort'", "'union'", "'intersect'", "'disjunction'", 
			"'filter'", "'run'", "'runs'", "'largest'", "'subsets'", "'tuples'", 
			"'partition'", "'indexed'", "'sum'", "'score'", "'+'", "'*'", "'-'", 
			"'%'", "'//'", "'^'", "'tri'", "'fib'", "'random'", "'size'", "'sto'", 
			"'str'", "'cardatt'", null, null, null, "'not'", null, null, "'('", "')'"
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
			null, null, null, null, null, null, null, "BOOLOP", "COMPOP", "EQOP", 
			"UNOP", "INTNUM", "LETT", "OPEN", "CLOSE", "WS", "ANY"
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
			setState(196);
			match(T__0);
			setState(197);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVars(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVars(this);
		}
	}

	public final VarsContext vars() throws RecognitionException {
		VarsContext _localctx = new VarsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_vars);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(199);
			match(T__0);
			setState(200);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVaro(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVaro(this);
		}
	}

	public final VaroContext varo() throws RecognitionException {
		VaroContext _localctx = new VaroContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_varo);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(202);
			match(T__0);
			setState(203);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarp(this);
		}
	}

	public final VarpContext varp() throws RecognitionException {
		VarpContext _localctx = new VarpContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_varp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(205);
			match(T__0);
			setState(206);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVari(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVari(this);
		}
	}

	public final VariContext vari() throws RecognitionException {
		VariContext _localctx = new VariContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_vari);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(208);
			match(T__0);
			setState(209);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarb(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarb(this);
		}
	}

	public final VarbContext varb() throws RecognitionException {
		VarbContext _localctx = new VarbContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_varb);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(211);
			match(T__0);
			setState(212);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarc(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarc(this);
		}
	}

	public final VarcContext varc() throws RecognitionException {
		VarcContext _localctx = new VarcContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_varc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(214);
			match(T__0);
			setState(215);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarcs(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarcs(this);
		}
	}

	public final VarcsContext varcs() throws RecognitionException {
		VarcsContext _localctx = new VarcsContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_varcs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(217);
			match(T__0);
			setState(218);
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
	public static class VarcscContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VarcscContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_varcsc; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarcsc(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarcsc(this);
		}
	}

	public final VarcscContext varcsc() throws RecognitionException {
		VarcscContext _localctx = new VarcscContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_varcsc);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
			match(T__0);
			setState(221);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVarcard(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVarcard(this);
		}
	}

	public final VarcardContext varcard() throws RecognitionException {
		VarcardContext _localctx = new VarcardContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_varcard);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(223);
			match(T__0);
			setState(224);
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
		enterRule(_localctx, 20, RULE_game);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(226);
			match(OPEN);
			setState(227);
			match(T__1);
			setState(231);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(228);
					declare();
					}
					} 
				}
				setState(233);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(234);
			setup();
			setState(237); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(237);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						setState(235);
						multiaction();
						}
						break;
					case 2:
						{
						setState(236);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(239); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(241);
			scoring();
			setState(242);
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
		enterRule(_localctx, 22, RULE_declare);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(244);
			match(OPEN);
			setState(245);
			match(T__2);
			setState(246);
			typed();
			setState(247);
			var();
			setState(248);
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
		enterRule(_localctx, 24, RULE_setup);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(250);
			match(OPEN);
			setState(251);
			match(T__3);
			setState(252);
			playercreate();
			setState(254);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(253);
				teamcreate();
				}
				break;
			}
			setState(263); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(256);
					match(OPEN);
					setState(259);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__16:
						{
						setState(257);
						deckcreate();
						}
						break;
					case T__36:
						{
						setState(258);
						repeat();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(261);
					match(CLOSE);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(265); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(267);
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
		enterRule(_localctx, 26, RULE_scoring);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(269);
			match(OPEN);
			setState(270);
			match(T__4);
			setState(271);
			_la = _input.LA(1);
			if ( !(_la==T__5 || _la==T__6) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(272);
			int_();
			setState(273);
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
		enterRule(_localctx, 28, RULE_stage);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(275);
			match(OPEN);
			setState(276);
			match(T__7);
			setState(277);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(278);
			endcondition();
			setState(281); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(281);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
					case 1:
						{
						setState(279);
						multiaction();
						}
						break;
					case 2:
						{
						setState(280);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(283); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(285);
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
		enterRule(_localctx, 30, RULE_endcondition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(287);
			match(OPEN);
			setState(288);
			match(T__10);
			setState(289);
			boolean_();
			setState(290);
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
		enterRule(_localctx, 32, RULE_multiaction);
		try {
			int _alt;
			setState(316);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(292);
				match(OPEN);
				setState(293);
				match(T__11);
				setState(294);
				match(OPEN);
				setState(296); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(295);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(298); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(300);
				match(CLOSE);
				setState(301);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(303);
				match(OPEN);
				setState(304);
				match(T__12);
				setState(305);
				match(OPEN);
				setState(307); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(306);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(309); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(311);
				match(CLOSE);
				setState(312);
				match(CLOSE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(314);
				agg();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(315);
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
		enterRule(_localctx, 34, RULE_multiaction2);
		try {
			int _alt;
			setState(331);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(318);
				match(OPEN);
				setState(319);
				match(T__12);
				setState(320);
				match(OPEN);
				setState(322); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(321);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(324); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(326);
				match(CLOSE);
				setState(327);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(329);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(330);
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
		enterRule(_localctx, 36, RULE_condact);
		try {
			setState(345);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(333);
				match(OPEN);
				setState(334);
				boolean_();
				setState(335);
				multiaction2();
				setState(336);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(338);
				multiaction2();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(339);
				match(OPEN);
				setState(340);
				boolean_();
				setState(341);
				action();
				setState(342);
				match(CLOSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(344);
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
		enterRule(_localctx, 38, RULE_agg);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(347);
			match(OPEN);
			setState(348);
			_la = _input.LA(1);
			if ( !(_la==T__13 || _la==T__14) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(349);
			collection();
			setState(350);
			var();
			setState(351);
			condact();
			setState(352);
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
		enterRule(_localctx, 40, RULE_let);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(354);
			match(OPEN);
			setState(355);
			match(T__15);
			setState(356);
			typed();
			setState(357);
			var();
			setState(361);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(358);
				multiaction();
				}
				break;
			case 2:
				{
				setState(359);
				action();
				}
				break;
			case 3:
				{
				setState(360);
				condact();
				}
				break;
			}
			setState(363);
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
		enterRule(_localctx, 42, RULE_action);
		try {
			setState(385);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(365);
				match(OPEN);
				setState(380);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
				case 1:
					{
					setState(366);
					initpoints();
					}
					break;
				case 2:
					{
					setState(367);
					teamcreate();
					}
					break;
				case 3:
					{
					setState(368);
					deckcreate();
					}
					break;
				case 4:
					{
					setState(369);
					cycleaction();
					}
					break;
				case 5:
					{
					setState(370);
					setaction();
					}
					break;
				case 6:
					{
					setState(371);
					moveaction();
					}
					break;
				case 7:
					{
					setState(372);
					copyaction();
					}
					break;
				case 8:
					{
					setState(373);
					incaction();
					}
					break;
				case 9:
					{
					setState(374);
					setstraction();
					}
					break;
				case 10:
					{
					setState(375);
					decaction();
					}
					break;
				case 11:
					{
					setState(376);
					removeaction();
					}
					break;
				case 12:
					{
					setState(377);
					turnaction();
					}
					break;
				case 13:
					{
					setState(378);
					shuffleaction();
					}
					break;
				case 14:
					{
					setState(379);
					repeat();
					}
					break;
				}
				setState(382);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(384);
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
		enterRule(_localctx, 44, RULE_playercreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(387);
			match(OPEN);
			setState(388);
			match(T__16);
			setState(389);
			match(T__17);
			setState(390);
			int_();
			setState(391);
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
		enterRule(_localctx, 46, RULE_teamcreate);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(393);
			match(OPEN);
			setState(394);
			match(T__16);
			setState(395);
			match(T__18);
			setState(397); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(396);
					teams();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(399); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(401);
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
		enterRule(_localctx, 48, RULE_teams);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(403);
			match(OPEN);
			setState(408);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(404);
					match(INTNUM);
					setState(405);
					match(T__19);
					}
					} 
				}
				setState(410);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			}
			setState(411);
			match(INTNUM);
			setState(415);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(412);
					teams();
					}
					} 
				}
				setState(417);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			}
			setState(418);
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
		enterRule(_localctx, 50, RULE_deckcreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(420);
			match(T__16);
			setState(421);
			match(T__20);
			setState(423);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
			case 1:
				{
				setState(422);
				str();
				}
				break;
			}
			setState(425);
			cstorage();
			setState(426);
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
		enterRule(_localctx, 52, RULE_deck);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(428);
			match(OPEN);
			setState(429);
			match(T__20);
			setState(431); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(430);
					attribute();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(433); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(435);
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
		enterRule(_localctx, 54, RULE_attribute);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(437);
			match(OPEN);
			setState(443);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(438);
					namegr();
					setState(439);
					match(T__19);
					}
					} 
				}
				setState(445);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,22,_ctx);
			}
			setState(446);
			namegr();
			setState(450);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(447);
					attribute();
					}
					} 
				}
				setState(452);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			}
			setState(453);
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
		enterRule(_localctx, 56, RULE_initpoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(455);
			match(T__21);
			setState(456);
			pointstorage();
			setState(457);
			match(OPEN);
			setState(459); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(458);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(461); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
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
		enterRule(_localctx, 58, RULE_awards);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(465);
			match(OPEN);
			setState(467); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(466);
					subaward();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(469); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(471);
			int_();
			setState(472);
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
		enterRule(_localctx, 60, RULE_subaward);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(474);
			match(OPEN);
			setState(475);
			str();
			setState(476);
			match(T__22);
			setState(477);
			str();
			setState(478);
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
		enterRule(_localctx, 62, RULE_cycleaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(480);
			match(T__23);
			setState(481);
			_la = _input.LA(1);
			if ( !(_la==T__24 || _la==T__25) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(487);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(482);
				owner();
				}
				break;
			case T__25:
				{
				setState(483);
				match(T__25);
				}
				break;
			case T__24:
				{
				setState(484);
				match(T__24);
				}
				break;
			case T__26:
				{
				setState(485);
				match(T__26);
				}
				break;
			case T__0:
				{
				setState(486);
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
		enterRule(_localctx, 64, RULE_setaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(489);
			match(T__21);
			setState(490);
			rawstorage();
			setState(491);
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
		enterRule(_localctx, 66, RULE_setstraction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(493);
			match(T__21);
			setState(494);
			strstorage();
			setState(495);
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
		enterRule(_localctx, 68, RULE_incaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(497);
			match(T__27);
			setState(498);
			rawstorage();
			setState(499);
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
		enterRule(_localctx, 70, RULE_decaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(501);
			match(T__28);
			setState(502);
			rawstorage();
			setState(503);
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
		enterRule(_localctx, 72, RULE_moveaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(505);
			match(T__29);
			setState(506);
			card();
			setState(507);
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
		enterRule(_localctx, 74, RULE_copyaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(509);
			match(T__30);
			setState(510);
			card();
			setState(511);
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
		enterRule(_localctx, 76, RULE_removeaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(513);
			match(T__31);
			setState(514);
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
		public List<CstorageContext> cstorage() {
			return getRuleContexts(CstorageContext.class);
		}
		public CstorageContext cstorage(int i) {
			return getRuleContext(CstorageContext.class,i);
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
		enterRule(_localctx, 78, RULE_shuffleaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(516);
			match(T__32);
			setState(522);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case OPEN:
				{
				setState(517);
				cstorage();
				}
				break;
			case T__33:
				{
				setState(518);
				match(T__33);
				setState(519);
				cstorage();
				setState(520);
				cstorage();
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
		enterRule(_localctx, 80, RULE_turnaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(524);
			match(T__34);
			setState(525);
			match(T__35);
			}
		}
		catch (RecognitionException re) {
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
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public MoveactionContext moveaction() {
			return getRuleContext(MoveactionContext.class,0);
		}
		public RemoveactionContext removeaction() {
			return getRuleContext(RemoveactionContext.class,0);
		}
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
		enterRule(_localctx, 82, RULE_repeat);
		try {
			setState(540);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(527);
				match(T__36);
				setState(528);
				int_();
				setState(529);
				action();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(531);
				match(T__36);
				setState(532);
				match(T__14);
				setState(533);
				match(OPEN);
				setState(536);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__29:
					{
					setState(534);
					moveaction();
					}
					break;
				case T__31:
					{
					setState(535);
					removeaction();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(538);
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
		enterRule(_localctx, 84, RULE_pointstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(542);
			match(OPEN);
			setState(546);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(543);
				varo();
				}
				break;
			case T__1:
				{
				setState(544);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(545);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(548);
			match(T__37);
			setState(549);
			str();
			setState(550);
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
		enterRule(_localctx, 86, RULE_card);
		try {
			setState(565);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(552);
				varcard();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(553);
				maxof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(554);
				minof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(555);
				actual();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(556);
				match(OPEN);
				setState(560);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__38:
					{
					setState(557);
					match(T__38);
					}
					break;
				case T__39:
					{
					setState(558);
					match(T__39);
					}
					break;
				case T__0:
				case INTNUM:
				case OPEN:
					{
					setState(559);
					int_();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(562);
				cstorage();
				setState(563);
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
		enterRule(_localctx, 88, RULE_actual);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(567);
			match(OPEN);
			setState(568);
			match(T__40);
			setState(569);
			card();
			setState(570);
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
		enterRule(_localctx, 90, RULE_maxof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(572);
			match(OPEN);
			setState(573);
			match(T__6);
			setState(574);
			cstorage();
			setState(575);
			match(T__41);
			setState(576);
			pointstorage();
			setState(577);
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
		enterRule(_localctx, 92, RULE_minof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(579);
			match(OPEN);
			setState(580);
			match(T__5);
			setState(581);
			cstorage();
			setState(582);
			match(T__41);
			setState(583);
			pointstorage();
			setState(584);
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
		enterRule(_localctx, 94, RULE_locpre);
		try {
			setState(589);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				enterOuterAlt(_localctx, 1);
				{
				setState(586);
				match(T__1);
				}
				break;
			case T__0:
				enterOuterAlt(_localctx, 2);
				{
				setState(587);
				varp();
				}
				break;
			case OPEN:
				enterOuterAlt(_localctx, 3);
				{
				setState(588);
				whop();
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
		enterRule(_localctx, 96, RULE_locdesc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(591);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 272678883688448L) != 0)) ) {
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
		enterRule(_localctx, 98, RULE_who);
		try {
			setState(595);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(593);
				whot();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(594);
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
		enterRule(_localctx, 100, RULE_whop);
		try {
			setState(603);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(597);
				match(OPEN);
				setState(598);
				whodesc();
				setState(599);
				match(T__8);
				setState(600);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(602);
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
		enterRule(_localctx, 102, RULE_whot);
		try {
			setState(611);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,36,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(605);
				match(OPEN);
				setState(606);
				whodesc();
				setState(607);
				match(T__9);
				setState(608);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(610);
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
		enterRule(_localctx, 104, RULE_whodesc);
		try {
			setState(617);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case INTNUM:
			case OPEN:
				enterOuterAlt(_localctx, 1);
				{
				setState(613);
				int_();
				}
				break;
			case T__26:
				enterOuterAlt(_localctx, 2);
				{
				setState(614);
				match(T__26);
				}
				break;
			case T__24:
				enterOuterAlt(_localctx, 3);
				{
				setState(615);
				match(T__24);
				}
				break;
			case T__25:
				enterOuterAlt(_localctx, 4);
				{
				setState(616);
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
		enterRule(_localctx, 106, RULE_owner);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(619);
			match(OPEN);
			setState(620);
			match(T__47);
			setState(621);
			card();
			setState(622);
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
		enterRule(_localctx, 108, RULE_teamp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(624);
			match(OPEN);
			setState(625);
			match(T__9);
			setState(628);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(626);
				varp();
				}
				break;
			case OPEN:
				{
				setState(627);
				whop();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
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
		enterRule(_localctx, 110, RULE_typed);
		try {
			setState(636);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(632);
				int_();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(633);
				boolean_();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(634);
				str();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(635);
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
		enterRule(_localctx, 112, RULE_collection);
		try {
			setState(648);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(638);
				varc();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(639);
				filter();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(640);
				cstorage();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(641);
				strcollection();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(642);
				cstoragecollection();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(643);
				match(T__8);
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(644);
				match(T__9);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(645);
				whot();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(646);
				other();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(647);
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
		enterRule(_localctx, 114, RULE_strcollection);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(650);
			match(OPEN);
			setState(656);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(651);
					namegr();
					setState(652);
					match(T__19);
					}
					} 
				}
				setState(658);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			}
			setState(659);
			namegr();
			setState(660);
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
		enterRule(_localctx, 116, RULE_range);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(662);
			match(OPEN);
			setState(663);
			match(T__48);
			setState(664);
			int_();
			setState(665);
			match(T__49);
			setState(666);
			int_();
			setState(667);
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
		enterRule(_localctx, 118, RULE_other);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(669);
			match(OPEN);
			setState(670);
			match(T__50);
			setState(671);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(672);
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
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public MemstorageContext memstorage() {
			return getRuleContext(MemstorageContext.class,0);
		}
		public SequenceContext sequence() {
			return getRuleContext(SequenceContext.class,0);
		}
		public RunsequenceContext runsequence() {
			return getRuleContext(RunsequenceContext.class,0);
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
		enterRule(_localctx, 120, RULE_cstorage);
		int _la;
		try {
			setState(692);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,43,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(674);
				varcs();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(675);
				unionof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(676);
				intersectof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(677);
				disjunctionof();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(678);
				sortof();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(679);
				filter();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(680);
				match(OPEN);
				setState(681);
				locpre();
				setState(682);
				locdesc();
				setState(683);
				str();
				setState(685);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__0 || _la==INTNUM || _la==OPEN) {
					{
					setState(684);
					int_();
					}
				}

				setState(687);
				match(CLOSE);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(689);
				memstorage();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(690);
				sequence();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(691);
				runsequence();
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
		enterRule(_localctx, 122, RULE_sortof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(694);
			match(OPEN);
			setState(695);
			match(T__51);
			setState(696);
			cstorage();
			setState(697);
			match(T__41);
			setState(698);
			pointstorage();
			setState(699);
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
		enterRule(_localctx, 124, RULE_unionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(701);
			match(OPEN);
			setState(702);
			match(T__52);
			setState(709);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,45,_ctx) ) {
			case 1:
				{
				setState(703);
				aggcs();
				}
				break;
			case 2:
				{
				setState(705); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(704);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(707); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,44,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(711);
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
		enterRule(_localctx, 126, RULE_intersectof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(713);
			match(OPEN);
			setState(714);
			match(T__53);
			setState(721);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
			case 1:
				{
				setState(715);
				aggcs();
				}
				break;
			case 2:
				{
				setState(717); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(716);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(719); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,46,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(723);
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
		enterRule(_localctx, 128, RULE_disjunctionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(725);
			match(OPEN);
			setState(726);
			match(T__54);
			setState(733);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,49,_ctx) ) {
			case 1:
				{
				setState(727);
				aggcs();
				}
				break;
			case 2:
				{
				setState(729); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(728);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(731); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,48,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(735);
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
		enterRule(_localctx, 130, RULE_filter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(737);
			match(OPEN);
			setState(738);
			match(T__55);
			setState(739);
			collection();
			setState(740);
			var();
			setState(741);
			boolean_();
			setState(742);
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
		public CstoragecollectionContext cstoragecollection() {
			return getRuleContext(CstoragecollectionContext.class,0);
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
		enterRule(_localctx, 132, RULE_memstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(744);
			match(OPEN);
			setState(748);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__38:
				{
				setState(745);
				match(T__38);
				}
				break;
			case T__39:
				{
				setState(746);
				match(T__39);
				}
				break;
			case T__0:
			case INTNUM:
			case OPEN:
				{
				setState(747);
				int_();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(750);
			cstoragecollection();
			setState(751);
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
	public static class SequenceContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public SequenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sequence; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSequence(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSequence(this);
		}
	}

	public final SequenceContext sequence() throws RecognitionException {
		SequenceContext _localctx = new SequenceContext(_ctx, getState());
		enterRule(_localctx, 134, RULE_sequence);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(753);
			match(OPEN);
			setState(754);
			_la = _input.LA(1);
			if ( !(_la==T__38 || _la==T__39) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(755);
			int_();
			setState(756);
			cstorage();
			setState(757);
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
	public static class RunsequenceContext extends ParserRuleContext {
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
		public RunsequenceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_runsequence; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRunsequence(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRunsequence(this);
		}
	}

	public final RunsequenceContext runsequence() throws RecognitionException {
		RunsequenceContext _localctx = new RunsequenceContext(_ctx, getState());
		enterRule(_localctx, 136, RULE_runsequence);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(759);
			match(OPEN);
			setState(760);
			match(T__56);
			setState(761);
			_la = _input.LA(1);
			if ( !(_la==T__38 || _la==T__39) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(762);
			int_();
			setState(763);
			cstorage();
			setState(764);
			match(T__41);
			setState(765);
			pointstorage();
			setState(766);
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
		public TupleContext tuple() {
			return getRuleContext(TupleContext.class,0);
		}
		public PartitionContext partition() {
			return getRuleContext(PartitionContext.class,0);
		}
		public SubsetContext subset() {
			return getRuleContext(SubsetContext.class,0);
		}
		public RunContext run() {
			return getRuleContext(RunContext.class,0);
		}
		public AggcsContext aggcs() {
			return getRuleContext(AggcsContext.class,0);
		}
		public VarcscContext varcsc() {
			return getRuleContext(VarcscContext.class,0);
		}
		public IndexedContext indexed() {
			return getRuleContext(IndexedContext.class,0);
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
		enterRule(_localctx, 138, RULE_cstoragecollection);
		try {
			setState(775);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(768);
				tuple();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(769);
				partition();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(770);
				subset();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(771);
				run();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(772);
				aggcs();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(773);
				varcsc();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(774);
				indexed();
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
		public RunContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_run; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterRun(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitRun(this);
		}
	}

	public final RunContext run() throws RecognitionException {
		RunContext _localctx = new RunContext(_ctx, getState());
		enterRule(_localctx, 140, RULE_run);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(777);
			match(OPEN);
			setState(778);
			match(T__57);
			setState(779);
			_la = _input.LA(1);
			if ( !(_la==T__14 || _la==T__58) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(780);
			int_();
			setState(781);
			cstorage();
			setState(782);
			match(T__41);
			setState(783);
			pointstorage();
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
		enterRule(_localctx, 142, RULE_subset);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(786);
			match(OPEN);
			setState(787);
			match(T__59);
			setState(788);
			cstorage();
			setState(789);
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
		enterRule(_localctx, 144, RULE_tuple);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(791);
			match(OPEN);
			setState(792);
			match(T__60);
			setState(793);
			int_();
			setState(794);
			cstorage();
			setState(795);
			match(T__41);
			setState(796);
			pointstorage();
			setState(797);
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
		enterRule(_localctx, 146, RULE_partition);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(799);
			match(OPEN);
			setState(800);
			match(T__61);
			setState(801);
			str();
			setState(808);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,53,_ctx) ) {
			case 1:
				{
				setState(802);
				aggcs();
				}
				break;
			case 2:
				{
				setState(804); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(803);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(806); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,52,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(810);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAggcs(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAggcs(this);
		}
	}

	public final AggcsContext aggcs() throws RecognitionException {
		AggcsContext _localctx = new AggcsContext(_ctx, getState());
		enterRule(_localctx, 148, RULE_aggcs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(812);
			match(OPEN);
			setState(813);
			match(T__14);
			setState(814);
			collection();
			setState(815);
			var();
			setState(816);
			cstorage();
			setState(817);
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
	public static class IndexedContext extends ParserRuleContext {
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
		public IndexedContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_indexed; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterIndexed(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitIndexed(this);
		}
	}

	public final IndexedContext indexed() throws RecognitionException {
		IndexedContext _localctx = new IndexedContext(_ctx, getState());
		enterRule(_localctx, 150, RULE_indexed);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(819);
			match(OPEN);
			setState(820);
			match(T__62);
			setState(821);
			locpre();
			setState(822);
			locdesc();
			setState(823);
			str();
			setState(824);
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
		enterRule(_localctx, 152, RULE_boolean);
		try {
			int _alt;
			setState(861);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,56,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(826);
				match(OPEN);
				setState(856);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,55,_ctx) ) {
				case 1:
					{
					setState(827);
					match(BOOLOP);
					setState(828);
					boolean_();
					setState(830); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(829);
							boolean_();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(832); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,54,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				case 2:
					{
					setState(834);
					intop();
					setState(835);
					int_();
					setState(836);
					int_();
					}
					break;
				case 3:
					{
					setState(838);
					match(EQOP);
					setState(839);
					str();
					setState(840);
					str();
					}
					break;
				case 4:
					{
					setState(842);
					match(EQOP);
					setState(843);
					card();
					setState(844);
					card();
					}
					break;
				case 5:
					{
					setState(846);
					match(UNOP);
					setState(847);
					boolean_();
					}
					break;
				case 6:
					{
					setState(848);
					match(EQOP);
					setState(849);
					whop();
					setState(850);
					whop();
					}
					break;
				case 7:
					{
					setState(852);
					match(EQOP);
					setState(853);
					whot();
					setState(854);
					whot();
					}
					break;
				}
				setState(858);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(860);
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
		enterRule(_localctx, 154, RULE_intop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(863);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAggb(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAggb(this);
		}
	}

	public final AggbContext aggb() throws RecognitionException {
		AggbContext _localctx = new AggbContext(_ctx, getState());
		enterRule(_localctx, 156, RULE_aggb);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(865);
			match(OPEN);
			setState(866);
			_la = _input.LA(1);
			if ( !(_la==T__13 || _la==T__14) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(867);
			collection();
			setState(868);
			var();
			setState(869);
			boolean_();
			setState(870);
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
		enterRule(_localctx, 158, RULE_int);
		try {
			int _alt;
			setState(891);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,58,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(872);
				vari();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(873);
				sizeof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(874);
				mult();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(875);
				subtract();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(876);
				mod();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(877);
				add();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(878);
				divide();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(879);
				exponent();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(880);
				triangular();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(881);
				fibonacci();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(882);
				random();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 12);
				{
				setState(883);
				sum();
				}
				break;
			case 13:
				enterOuterAlt(_localctx, 13);
				{
				setState(884);
				rawstorage();
				}
				break;
			case 14:
				enterOuterAlt(_localctx, 14);
				{
				setState(885);
				score();
				}
				break;
			case 15:
				enterOuterAlt(_localctx, 15);
				{
				setState(887); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(886);
						match(INTNUM);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(889); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,57,_ctx);
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
		enterRule(_localctx, 160, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(893);
			match(OPEN);
			setState(894);
			match(T__63);
			setState(895);
			cstorage();
			setState(896);
			match(T__41);
			setState(897);
			pointstorage();
			setState(898);
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
		enterRule(_localctx, 162, RULE_score);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(900);
			match(OPEN);
			setState(901);
			match(T__64);
			setState(902);
			card();
			setState(903);
			match(T__41);
			setState(904);
			pointstorage();
			setState(905);
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
		enterRule(_localctx, 164, RULE_add);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(907);
			match(OPEN);
			setState(908);
			match(T__65);
			setState(909);
			int_();
			setState(910);
			int_();
			setState(911);
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
		enterRule(_localctx, 166, RULE_mult);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(913);
			match(OPEN);
			setState(914);
			match(T__66);
			setState(915);
			int_();
			setState(916);
			int_();
			setState(917);
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
		enterRule(_localctx, 168, RULE_subtract);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(919);
			match(OPEN);
			setState(920);
			match(T__67);
			setState(921);
			int_();
			setState(922);
			int_();
			setState(923);
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
		enterRule(_localctx, 170, RULE_mod);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(925);
			match(OPEN);
			setState(926);
			match(T__68);
			setState(927);
			int_();
			setState(928);
			int_();
			setState(929);
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
		enterRule(_localctx, 172, RULE_divide);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(931);
			match(OPEN);
			setState(932);
			match(T__69);
			setState(933);
			int_();
			setState(934);
			int_();
			setState(935);
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
		enterRule(_localctx, 174, RULE_exponent);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(937);
			match(OPEN);
			setState(938);
			match(T__70);
			setState(939);
			int_();
			setState(940);
			int_();
			setState(941);
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
		enterRule(_localctx, 176, RULE_triangular);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(943);
			match(OPEN);
			setState(944);
			match(T__71);
			setState(945);
			int_();
			setState(946);
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
		enterRule(_localctx, 178, RULE_fibonacci);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(948);
			match(OPEN);
			setState(949);
			match(T__72);
			setState(950);
			int_();
			setState(951);
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
		enterRule(_localctx, 180, RULE_random);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(953);
			match(OPEN);
			setState(954);
			match(T__73);
			setState(955);
			int_();
			setState(958);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__49) {
				{
				setState(956);
				match(T__49);
				setState(957);
				int_();
				}
			}

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
		enterRule(_localctx, 182, RULE_sizeof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(962);
			match(OPEN);
			setState(963);
			match(T__74);
			setState(964);
			collection();
			setState(965);
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
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterAggi(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitAggi(this);
		}
	}

	public final AggiContext aggi() throws RecognitionException {
		AggiContext _localctx = new AggiContext(_ctx, getState());
		enterRule(_localctx, 184, RULE_aggi);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(967);
			match(OPEN);
			setState(968);
			match(T__14);
			setState(969);
			collection();
			setState(970);
			var();
			setState(971);
			rawstorage();
			setState(972);
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
		enterRule(_localctx, 186, RULE_rawstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(974);
			match(OPEN);
			setState(978);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(975);
				varo();
				}
				break;
			case T__1:
				{
				setState(976);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(977);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(980);
			match(T__75);
			setState(981);
			str();
			setState(982);
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
		enterRule(_localctx, 188, RULE_str);
		try {
			setState(988);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,61,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(984);
				namegr();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(985);
				strstorage();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(986);
				vars();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(987);
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
		enterRule(_localctx, 190, RULE_strstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(990);
			match(OPEN);
			setState(994);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(991);
				varo();
				}
				break;
			case T__1:
				{
				setState(992);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(993);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(996);
			match(T__76);
			setState(997);
			str();
			setState(998);
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
		enterRule(_localctx, 192, RULE_cardatt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1000);
			match(OPEN);
			setState(1001);
			match(T__77);
			setState(1002);
			str();
			setState(1003);
			card();
			setState(1004);
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
		enterRule(_localctx, 194, RULE_namegr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1007); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(1006);
					match(LETT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1009); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,63,_ctx);
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
		"\u0004\u0001X\u03f4\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
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
		"Z\u0007Z\u0002[\u0007[\u0002\\\u0007\\\u0002]\u0007]\u0002^\u0007^\u0002"+
		"_\u0007_\u0002`\u0007`\u0002a\u0007a\u0001\u0000\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0004"+
		"\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\b\u0001\t\u0001"+
		"\t\u0001\t\u0001\n\u0001\n\u0001\n\u0005\n\u00e6\b\n\n\n\f\n\u00e9\t\n"+
		"\u0001\n\u0001\n\u0001\n\u0004\n\u00ee\b\n\u000b\n\f\n\u00ef\u0001\n\u0001"+
		"\n\u0001\n\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b"+
		"\u0001\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0003\f\u00ff\b\f\u0001\f"+
		"\u0001\f\u0001\f\u0003\f\u0104\b\f\u0001\f\u0001\f\u0004\f\u0108\b\f\u000b"+
		"\f\f\f\u0109\u0001\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0004\u000e\u011a\b\u000e\u000b\u000e\f\u000e\u011b\u0001\u000e\u0001"+
		"\u000e\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0004\u0010\u0129\b\u0010\u000b"+
		"\u0010\f\u0010\u012a\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0004\u0010\u0134\b\u0010\u000b\u0010\f"+
		"\u0010\u0135\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0003\u0010\u013d\b\u0010\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011"+
		"\u0004\u0011\u0143\b\u0011\u000b\u0011\f\u0011\u0144\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0003\u0011\u014c\b\u0011\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0003"+
		"\u0012\u015a\b\u0012\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0003\u0014\u016a\b\u0014\u0001"+
		"\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0003\u0015\u017d"+
		"\b\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0003\u0015\u0182\b\u0015"+
		"\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016"+
		"\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0004\u0017\u018e\b\u0017"+
		"\u000b\u0017\f\u0017\u018f\u0001\u0017\u0001\u0017\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0005\u0018\u0197\b\u0018\n\u0018\f\u0018\u019a\t\u0018\u0001"+
		"\u0018\u0001\u0018\u0005\u0018\u019e\b\u0018\n\u0018\f\u0018\u01a1\t\u0018"+
		"\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0003\u0019"+
		"\u01a8\b\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a"+
		"\u0001\u001a\u0004\u001a\u01b0\b\u001a\u000b\u001a\f\u001a\u01b1\u0001"+
		"\u001a\u0001\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0005"+
		"\u001b\u01ba\b\u001b\n\u001b\f\u001b\u01bd\t\u001b\u0001\u001b\u0001\u001b"+
		"\u0005\u001b\u01c1\b\u001b\n\u001b\f\u001b\u01c4\t\u001b\u0001\u001b\u0001"+
		"\u001b\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0004\u001c\u01cc"+
		"\b\u001c\u000b\u001c\f\u001c\u01cd\u0001\u001c\u0001\u001c\u0001\u001d"+
		"\u0001\u001d\u0004\u001d\u01d4\b\u001d\u000b\u001d\f\u001d\u01d5\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0001\u001e\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0003\u001f\u01e8\b\u001f\u0001"+
		" \u0001 \u0001 \u0001 \u0001!\u0001!\u0001!\u0001!\u0001\"\u0001\"\u0001"+
		"\"\u0001\"\u0001#\u0001#\u0001#\u0001#\u0001$\u0001$\u0001$\u0001$\u0001"+
		"%\u0001%\u0001%\u0001%\u0001&\u0001&\u0001&\u0001\'\u0001\'\u0001\'\u0001"+
		"\'\u0001\'\u0001\'\u0003\'\u020b\b\'\u0001(\u0001(\u0001(\u0001)\u0001"+
		")\u0001)\u0001)\u0001)\u0001)\u0001)\u0001)\u0001)\u0003)\u0219\b)\u0001"+
		")\u0001)\u0003)\u021d\b)\u0001*\u0001*\u0001*\u0001*\u0003*\u0223\b*\u0001"+
		"*\u0001*\u0001*\u0001*\u0001+\u0001+\u0001+\u0001+\u0001+\u0001+\u0001"+
		"+\u0001+\u0003+\u0231\b+\u0001+\u0001+\u0001+\u0003+\u0236\b+\u0001,\u0001"+
		",\u0001,\u0001,\u0001,\u0001-\u0001-\u0001-\u0001-\u0001-\u0001-\u0001"+
		"-\u0001.\u0001.\u0001.\u0001.\u0001.\u0001.\u0001.\u0001/\u0001/\u0001"+
		"/\u0003/\u024e\b/\u00010\u00010\u00011\u00011\u00031\u0254\b1\u00012\u0001"+
		"2\u00012\u00012\u00012\u00012\u00032\u025c\b2\u00013\u00013\u00013\u0001"+
		"3\u00013\u00013\u00033\u0264\b3\u00014\u00014\u00014\u00014\u00034\u026a"+
		"\b4\u00015\u00015\u00015\u00015\u00015\u00016\u00016\u00016\u00016\u0003"+
		"6\u0275\b6\u00016\u00016\u00017\u00017\u00017\u00017\u00037\u027d\b7\u0001"+
		"8\u00018\u00018\u00018\u00018\u00018\u00018\u00018\u00018\u00018\u0003"+
		"8\u0289\b8\u00019\u00019\u00019\u00019\u00059\u028f\b9\n9\f9\u0292\t9"+
		"\u00019\u00019\u00019\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001"+
		":\u0001;\u0001;\u0001;\u0001;\u0001;\u0001<\u0001<\u0001<\u0001<\u0001"+
		"<\u0001<\u0001<\u0001<\u0001<\u0001<\u0001<\u0003<\u02ae\b<\u0001<\u0001"+
		"<\u0001<\u0001<\u0001<\u0003<\u02b5\b<\u0001=\u0001=\u0001=\u0001=\u0001"+
		"=\u0001=\u0001=\u0001>\u0001>\u0001>\u0001>\u0004>\u02c2\b>\u000b>\f>"+
		"\u02c3\u0003>\u02c6\b>\u0001>\u0001>\u0001?\u0001?\u0001?\u0001?\u0004"+
		"?\u02ce\b?\u000b?\f?\u02cf\u0003?\u02d2\b?\u0001?\u0001?\u0001@\u0001"+
		"@\u0001@\u0001@\u0004@\u02da\b@\u000b@\f@\u02db\u0003@\u02de\b@\u0001"+
		"@\u0001@\u0001A\u0001A\u0001A\u0001A\u0001A\u0001A\u0001A\u0001B\u0001"+
		"B\u0001B\u0001B\u0003B\u02ed\bB\u0001B\u0001B\u0001B\u0001C\u0001C\u0001"+
		"C\u0001C\u0001C\u0001C\u0001D\u0001D\u0001D\u0001D\u0001D\u0001D\u0001"+
		"D\u0001D\u0001D\u0001E\u0001E\u0001E\u0001E\u0001E\u0001E\u0001E\u0003"+
		"E\u0308\bE\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001"+
		"F\u0001G\u0001G\u0001G\u0001G\u0001G\u0001H\u0001H\u0001H\u0001H\u0001"+
		"H\u0001H\u0001H\u0001H\u0001I\u0001I\u0001I\u0001I\u0001I\u0004I\u0325"+
		"\bI\u000bI\fI\u0326\u0003I\u0329\bI\u0001I\u0001I\u0001J\u0001J\u0001"+
		"J\u0001J\u0001J\u0001J\u0001J\u0001K\u0001K\u0001K\u0001K\u0001K\u0001"+
		"K\u0001K\u0001L\u0001L\u0001L\u0001L\u0004L\u033f\bL\u000bL\fL\u0340\u0001"+
		"L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001"+
		"L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001L\u0001"+
		"L\u0001L\u0003L\u0359\bL\u0001L\u0001L\u0001L\u0003L\u035e\bL\u0001M\u0001"+
		"M\u0001N\u0001N\u0001N\u0001N\u0001N\u0001N\u0001N\u0001O\u0001O\u0001"+
		"O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001"+
		"O\u0001O\u0001O\u0004O\u0378\bO\u000bO\fO\u0379\u0003O\u037c\bO\u0001"+
		"P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001Q\u0001Q\u0001Q\u0001"+
		"Q\u0001Q\u0001Q\u0001Q\u0001R\u0001R\u0001R\u0001R\u0001R\u0001R\u0001"+
		"S\u0001S\u0001S\u0001S\u0001S\u0001S\u0001T\u0001T\u0001T\u0001T\u0001"+
		"T\u0001T\u0001U\u0001U\u0001U\u0001U\u0001U\u0001U\u0001V\u0001V\u0001"+
		"V\u0001V\u0001V\u0001V\u0001W\u0001W\u0001W\u0001W\u0001W\u0001W\u0001"+
		"X\u0001X\u0001X\u0001X\u0001X\u0001Y\u0001Y\u0001Y\u0001Y\u0001Y\u0001"+
		"Z\u0001Z\u0001Z\u0001Z\u0001Z\u0003Z\u03bf\bZ\u0001Z\u0001Z\u0001[\u0001"+
		"[\u0001[\u0001[\u0001[\u0001\\\u0001\\\u0001\\\u0001\\\u0001\\\u0001\\"+
		"\u0001\\\u0001]\u0001]\u0001]\u0001]\u0003]\u03d3\b]\u0001]\u0001]\u0001"+
		"]\u0001]\u0001^\u0001^\u0001^\u0001^\u0003^\u03dd\b^\u0001_\u0001_\u0001"+
		"_\u0001_\u0003_\u03e3\b_\u0001_\u0001_\u0001_\u0001_\u0001`\u0001`\u0001"+
		"`\u0001`\u0001`\u0001`\u0001a\u0004a\u03f0\ba\u000ba\fa\u03f1\u0001a\u0015"+
		"\u00e7\u00ef\u0109\u011b\u012a\u0135\u0144\u018f\u0198\u019f\u01b1\u01bb"+
		"\u01c2\u01cd\u01d5\u0290\u02c3\u02cf\u02db\u0326\u0340\u0000b\u0000\u0002"+
		"\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e"+
		" \"$&(*,.02468:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086"+
		"\u0088\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098\u009a\u009c\u009e"+
		"\u00a0\u00a2\u00a4\u00a6\u00a8\u00aa\u00ac\u00ae\u00b0\u00b2\u00b4\u00b6"+
		"\u00b8\u00ba\u00bc\u00be\u00c0\u00c2\u0000\b\u0001\u0000\u0006\u0007\u0001"+
		"\u0000\t\n\u0001\u0000\u000e\u000f\u0001\u0000\u0019\u001a\u0001\u0000"+
		"+/\u0001\u0000\'(\u0002\u0000\u000f\u000f;;\u0001\u0000PQ\u041c\u0000"+
		"\u00c4\u0001\u0000\u0000\u0000\u0002\u00c7\u0001\u0000\u0000\u0000\u0004"+
		"\u00ca\u0001\u0000\u0000\u0000\u0006\u00cd\u0001\u0000\u0000\u0000\b\u00d0"+
		"\u0001\u0000\u0000\u0000\n\u00d3\u0001\u0000\u0000\u0000\f\u00d6\u0001"+
		"\u0000\u0000\u0000\u000e\u00d9\u0001\u0000\u0000\u0000\u0010\u00dc\u0001"+
		"\u0000\u0000\u0000\u0012\u00df\u0001\u0000\u0000\u0000\u0014\u00e2\u0001"+
		"\u0000\u0000\u0000\u0016\u00f4\u0001\u0000\u0000\u0000\u0018\u00fa\u0001"+
		"\u0000\u0000\u0000\u001a\u010d\u0001\u0000\u0000\u0000\u001c\u0113\u0001"+
		"\u0000\u0000\u0000\u001e\u011f\u0001\u0000\u0000\u0000 \u013c\u0001\u0000"+
		"\u0000\u0000\"\u014b\u0001\u0000\u0000\u0000$\u0159\u0001\u0000\u0000"+
		"\u0000&\u015b\u0001\u0000\u0000\u0000(\u0162\u0001\u0000\u0000\u0000*"+
		"\u0181\u0001\u0000\u0000\u0000,\u0183\u0001\u0000\u0000\u0000.\u0189\u0001"+
		"\u0000\u0000\u00000\u0193\u0001\u0000\u0000\u00002\u01a4\u0001\u0000\u0000"+
		"\u00004\u01ac\u0001\u0000\u0000\u00006\u01b5\u0001\u0000\u0000\u00008"+
		"\u01c7\u0001\u0000\u0000\u0000:\u01d1\u0001\u0000\u0000\u0000<\u01da\u0001"+
		"\u0000\u0000\u0000>\u01e0\u0001\u0000\u0000\u0000@\u01e9\u0001\u0000\u0000"+
		"\u0000B\u01ed\u0001\u0000\u0000\u0000D\u01f1\u0001\u0000\u0000\u0000F"+
		"\u01f5\u0001\u0000\u0000\u0000H\u01f9\u0001\u0000\u0000\u0000J\u01fd\u0001"+
		"\u0000\u0000\u0000L\u0201\u0001\u0000\u0000\u0000N\u0204\u0001\u0000\u0000"+
		"\u0000P\u020c\u0001\u0000\u0000\u0000R\u021c\u0001\u0000\u0000\u0000T"+
		"\u021e\u0001\u0000\u0000\u0000V\u0235\u0001\u0000\u0000\u0000X\u0237\u0001"+
		"\u0000\u0000\u0000Z\u023c\u0001\u0000\u0000\u0000\\\u0243\u0001\u0000"+
		"\u0000\u0000^\u024d\u0001\u0000\u0000\u0000`\u024f\u0001\u0000\u0000\u0000"+
		"b\u0253\u0001\u0000\u0000\u0000d\u025b\u0001\u0000\u0000\u0000f\u0263"+
		"\u0001\u0000\u0000\u0000h\u0269\u0001\u0000\u0000\u0000j\u026b\u0001\u0000"+
		"\u0000\u0000l\u0270\u0001\u0000\u0000\u0000n\u027c\u0001\u0000\u0000\u0000"+
		"p\u0288\u0001\u0000\u0000\u0000r\u028a\u0001\u0000\u0000\u0000t\u0296"+
		"\u0001\u0000\u0000\u0000v\u029d\u0001\u0000\u0000\u0000x\u02b4\u0001\u0000"+
		"\u0000\u0000z\u02b6\u0001\u0000\u0000\u0000|\u02bd\u0001\u0000\u0000\u0000"+
		"~\u02c9\u0001\u0000\u0000\u0000\u0080\u02d5\u0001\u0000\u0000\u0000\u0082"+
		"\u02e1\u0001\u0000\u0000\u0000\u0084\u02e8\u0001\u0000\u0000\u0000\u0086"+
		"\u02f1\u0001\u0000\u0000\u0000\u0088\u02f7\u0001\u0000\u0000\u0000\u008a"+
		"\u0307\u0001\u0000\u0000\u0000\u008c\u0309\u0001\u0000\u0000\u0000\u008e"+
		"\u0312\u0001\u0000\u0000\u0000\u0090\u0317\u0001\u0000\u0000\u0000\u0092"+
		"\u031f\u0001\u0000\u0000\u0000\u0094\u032c\u0001\u0000\u0000\u0000\u0096"+
		"\u0333\u0001\u0000\u0000\u0000\u0098\u035d\u0001\u0000\u0000\u0000\u009a"+
		"\u035f\u0001\u0000\u0000\u0000\u009c\u0361\u0001\u0000\u0000\u0000\u009e"+
		"\u037b\u0001\u0000\u0000\u0000\u00a0\u037d\u0001\u0000\u0000\u0000\u00a2"+
		"\u0384\u0001\u0000\u0000\u0000\u00a4\u038b\u0001\u0000\u0000\u0000\u00a6"+
		"\u0391\u0001\u0000\u0000\u0000\u00a8\u0397\u0001\u0000\u0000\u0000\u00aa"+
		"\u039d\u0001\u0000\u0000\u0000\u00ac\u03a3\u0001\u0000\u0000\u0000\u00ae"+
		"\u03a9\u0001\u0000\u0000\u0000\u00b0\u03af\u0001\u0000\u0000\u0000\u00b2"+
		"\u03b4\u0001\u0000\u0000\u0000\u00b4\u03b9\u0001\u0000\u0000\u0000\u00b6"+
		"\u03c2\u0001\u0000\u0000\u0000\u00b8\u03c7\u0001\u0000\u0000\u0000\u00ba"+
		"\u03ce\u0001\u0000\u0000\u0000\u00bc\u03dc\u0001\u0000\u0000\u0000\u00be"+
		"\u03de\u0001\u0000\u0000\u0000\u00c0\u03e8\u0001\u0000\u0000\u0000\u00c2"+
		"\u03ef\u0001\u0000\u0000\u0000\u00c4\u00c5\u0005\u0001\u0000\u0000\u00c5"+
		"\u00c6\u0003\u00c2a\u0000\u00c6\u0001\u0001\u0000\u0000\u0000\u00c7\u00c8"+
		"\u0005\u0001\u0000\u0000\u00c8\u00c9\u0003\u00c2a\u0000\u00c9\u0003\u0001"+
		"\u0000\u0000\u0000\u00ca\u00cb\u0005\u0001\u0000\u0000\u00cb\u00cc\u0003"+
		"\u00c2a\u0000\u00cc\u0005\u0001\u0000\u0000\u0000\u00cd\u00ce\u0005\u0001"+
		"\u0000\u0000\u00ce\u00cf\u0003\u00c2a\u0000\u00cf\u0007\u0001\u0000\u0000"+
		"\u0000\u00d0\u00d1\u0005\u0001\u0000\u0000\u00d1\u00d2\u0003\u00c2a\u0000"+
		"\u00d2\t\u0001\u0000\u0000\u0000\u00d3\u00d4\u0005\u0001\u0000\u0000\u00d4"+
		"\u00d5\u0003\u00c2a\u0000\u00d5\u000b\u0001\u0000\u0000\u0000\u00d6\u00d7"+
		"\u0005\u0001\u0000\u0000\u00d7\u00d8\u0003\u00c2a\u0000\u00d8\r\u0001"+
		"\u0000\u0000\u0000\u00d9\u00da\u0005\u0001\u0000\u0000\u00da\u00db\u0003"+
		"\u00c2a\u0000\u00db\u000f\u0001\u0000\u0000\u0000\u00dc\u00dd\u0005\u0001"+
		"\u0000\u0000\u00dd\u00de\u0003\u00c2a\u0000\u00de\u0011\u0001\u0000\u0000"+
		"\u0000\u00df\u00e0\u0005\u0001\u0000\u0000\u00e0\u00e1\u0003\u00c2a\u0000"+
		"\u00e1\u0013\u0001\u0000\u0000\u0000\u00e2\u00e3\u0005U\u0000\u0000\u00e3"+
		"\u00e7\u0005\u0002\u0000\u0000\u00e4\u00e6\u0003\u0016\u000b\u0000\u00e5"+
		"\u00e4\u0001\u0000\u0000\u0000\u00e6\u00e9\u0001\u0000\u0000\u0000\u00e7"+
		"\u00e8\u0001\u0000\u0000\u0000\u00e7\u00e5\u0001\u0000\u0000\u0000\u00e8"+
		"\u00ea\u0001\u0000\u0000\u0000\u00e9\u00e7\u0001\u0000\u0000\u0000\u00ea"+
		"\u00ed\u0003\u0018\f\u0000\u00eb\u00ee\u0003 \u0010\u0000\u00ec\u00ee"+
		"\u0003\u001c\u000e\u0000\u00ed\u00eb\u0001\u0000\u0000\u0000\u00ed\u00ec"+
		"\u0001\u0000\u0000\u0000\u00ee\u00ef\u0001\u0000\u0000\u0000\u00ef\u00f0"+
		"\u0001\u0000\u0000\u0000\u00ef\u00ed\u0001\u0000\u0000\u0000\u00f0\u00f1"+
		"\u0001\u0000\u0000\u0000\u00f1\u00f2\u0003\u001a\r\u0000\u00f2\u00f3\u0005"+
		"V\u0000\u0000\u00f3\u0015\u0001\u0000\u0000\u0000\u00f4\u00f5\u0005U\u0000"+
		"\u0000\u00f5\u00f6\u0005\u0003\u0000\u0000\u00f6\u00f7\u0003n7\u0000\u00f7"+
		"\u00f8\u0003\u0000\u0000\u0000\u00f8\u00f9\u0005V\u0000\u0000\u00f9\u0017"+
		"\u0001\u0000\u0000\u0000\u00fa\u00fb\u0005U\u0000\u0000\u00fb\u00fc\u0005"+
		"\u0004\u0000\u0000\u00fc\u00fe\u0003,\u0016\u0000\u00fd\u00ff\u0003.\u0017"+
		"\u0000\u00fe\u00fd\u0001\u0000\u0000\u0000\u00fe\u00ff\u0001\u0000\u0000"+
		"\u0000\u00ff\u0107\u0001\u0000\u0000\u0000\u0100\u0103\u0005U\u0000\u0000"+
		"\u0101\u0104\u00032\u0019\u0000\u0102\u0104\u0003R)\u0000\u0103\u0101"+
		"\u0001\u0000\u0000\u0000\u0103\u0102\u0001\u0000\u0000\u0000\u0104\u0105"+
		"\u0001\u0000\u0000\u0000\u0105\u0106\u0005V\u0000\u0000\u0106\u0108\u0001"+
		"\u0000\u0000\u0000\u0107\u0100\u0001\u0000\u0000\u0000\u0108\u0109\u0001"+
		"\u0000\u0000\u0000\u0109\u010a\u0001\u0000\u0000\u0000\u0109\u0107\u0001"+
		"\u0000\u0000\u0000\u010a\u010b\u0001\u0000\u0000\u0000\u010b\u010c\u0005"+
		"V\u0000\u0000\u010c\u0019\u0001\u0000\u0000\u0000\u010d\u010e\u0005U\u0000"+
		"\u0000\u010e\u010f\u0005\u0005\u0000\u0000\u010f\u0110\u0007\u0000\u0000"+
		"\u0000\u0110\u0111\u0003\u009eO\u0000\u0111\u0112\u0005V\u0000\u0000\u0112"+
		"\u001b\u0001\u0000\u0000\u0000\u0113\u0114\u0005U\u0000\u0000\u0114\u0115"+
		"\u0005\b\u0000\u0000\u0115\u0116\u0007\u0001\u0000\u0000\u0116\u0119\u0003"+
		"\u001e\u000f\u0000\u0117\u011a\u0003 \u0010\u0000\u0118\u011a\u0003\u001c"+
		"\u000e\u0000\u0119\u0117\u0001\u0000\u0000\u0000\u0119\u0118\u0001\u0000"+
		"\u0000\u0000\u011a\u011b\u0001\u0000\u0000\u0000\u011b\u011c\u0001\u0000"+
		"\u0000\u0000\u011b\u0119\u0001\u0000\u0000\u0000\u011c\u011d\u0001\u0000"+
		"\u0000\u0000\u011d\u011e\u0005V\u0000\u0000\u011e\u001d\u0001\u0000\u0000"+
		"\u0000\u011f\u0120\u0005U\u0000\u0000\u0120\u0121\u0005\u000b\u0000\u0000"+
		"\u0121\u0122\u0003\u0098L\u0000\u0122\u0123\u0005V\u0000\u0000\u0123\u001f"+
		"\u0001\u0000\u0000\u0000\u0124\u0125\u0005U\u0000\u0000\u0125\u0126\u0005"+
		"\f\u0000\u0000\u0126\u0128\u0005U\u0000\u0000\u0127\u0129\u0003$\u0012"+
		"\u0000\u0128\u0127\u0001\u0000\u0000\u0000\u0129\u012a\u0001\u0000\u0000"+
		"\u0000\u012a\u012b\u0001\u0000\u0000\u0000\u012a\u0128\u0001\u0000\u0000"+
		"\u0000\u012b\u012c\u0001\u0000\u0000\u0000\u012c\u012d\u0005V\u0000\u0000"+
		"\u012d\u012e\u0005V\u0000\u0000\u012e\u013d\u0001\u0000\u0000\u0000\u012f"+
		"\u0130\u0005U\u0000\u0000\u0130\u0131\u0005\r\u0000\u0000\u0131\u0133"+
		"\u0005U\u0000\u0000\u0132\u0134\u0003$\u0012\u0000\u0133\u0132\u0001\u0000"+
		"\u0000\u0000\u0134\u0135\u0001\u0000\u0000\u0000\u0135\u0136\u0001\u0000"+
		"\u0000\u0000\u0135\u0133\u0001\u0000\u0000\u0000\u0136\u0137\u0001\u0000"+
		"\u0000\u0000\u0137\u0138\u0005V\u0000\u0000\u0138\u0139\u0005V\u0000\u0000"+
		"\u0139\u013d\u0001\u0000\u0000\u0000\u013a\u013d\u0003&\u0013\u0000\u013b"+
		"\u013d\u0003(\u0014\u0000\u013c\u0124\u0001\u0000\u0000\u0000\u013c\u012f"+
		"\u0001\u0000\u0000\u0000\u013c\u013a\u0001\u0000\u0000\u0000\u013c\u013b"+
		"\u0001\u0000\u0000\u0000\u013d!\u0001\u0000\u0000\u0000\u013e\u013f\u0005"+
		"U\u0000\u0000\u013f\u0140\u0005\r\u0000\u0000\u0140\u0142\u0005U\u0000"+
		"\u0000\u0141\u0143\u0003$\u0012\u0000\u0142\u0141\u0001\u0000\u0000\u0000"+
		"\u0143\u0144\u0001\u0000\u0000\u0000\u0144\u0145\u0001\u0000\u0000\u0000"+
		"\u0144\u0142\u0001\u0000\u0000\u0000\u0145\u0146\u0001\u0000\u0000\u0000"+
		"\u0146\u0147\u0005V\u0000\u0000\u0147\u0148\u0005V\u0000\u0000\u0148\u014c"+
		"\u0001\u0000\u0000\u0000\u0149\u014c\u0003&\u0013\u0000\u014a\u014c\u0003"+
		"(\u0014\u0000\u014b\u013e\u0001\u0000\u0000\u0000\u014b\u0149\u0001\u0000"+
		"\u0000\u0000\u014b\u014a\u0001\u0000\u0000\u0000\u014c#\u0001\u0000\u0000"+
		"\u0000\u014d\u014e\u0005U\u0000\u0000\u014e\u014f\u0003\u0098L\u0000\u014f"+
		"\u0150\u0003\"\u0011\u0000\u0150\u0151\u0005V\u0000\u0000\u0151\u015a"+
		"\u0001\u0000\u0000\u0000\u0152\u015a\u0003\"\u0011\u0000\u0153\u0154\u0005"+
		"U\u0000\u0000\u0154\u0155\u0003\u0098L\u0000\u0155\u0156\u0003*\u0015"+
		"\u0000\u0156\u0157\u0005V\u0000\u0000\u0157\u015a\u0001\u0000\u0000\u0000"+
		"\u0158\u015a\u0003*\u0015\u0000\u0159\u014d\u0001\u0000\u0000\u0000\u0159"+
		"\u0152\u0001\u0000\u0000\u0000\u0159\u0153\u0001\u0000\u0000\u0000\u0159"+
		"\u0158\u0001\u0000\u0000\u0000\u015a%\u0001\u0000\u0000\u0000\u015b\u015c"+
		"\u0005U\u0000\u0000\u015c\u015d\u0007\u0002\u0000\u0000\u015d\u015e\u0003"+
		"p8\u0000\u015e\u015f\u0003\u0000\u0000\u0000\u015f\u0160\u0003$\u0012"+
		"\u0000\u0160\u0161\u0005V\u0000\u0000\u0161\'\u0001\u0000\u0000\u0000"+
		"\u0162\u0163\u0005U\u0000\u0000\u0163\u0164\u0005\u0010\u0000\u0000\u0164"+
		"\u0165\u0003n7\u0000\u0165\u0169\u0003\u0000\u0000\u0000\u0166\u016a\u0003"+
		" \u0010\u0000\u0167\u016a\u0003*\u0015\u0000\u0168\u016a\u0003$\u0012"+
		"\u0000\u0169\u0166\u0001\u0000\u0000\u0000\u0169\u0167\u0001\u0000\u0000"+
		"\u0000\u0169\u0168\u0001\u0000\u0000\u0000\u016a\u016b\u0001\u0000\u0000"+
		"\u0000\u016b\u016c\u0005V\u0000\u0000\u016c)\u0001\u0000\u0000\u0000\u016d"+
		"\u017c\u0005U\u0000\u0000\u016e\u017d\u00038\u001c\u0000\u016f\u017d\u0003"+
		".\u0017\u0000\u0170\u017d\u00032\u0019\u0000\u0171\u017d\u0003>\u001f"+
		"\u0000\u0172\u017d\u0003@ \u0000\u0173\u017d\u0003H$\u0000\u0174\u017d"+
		"\u0003J%\u0000\u0175\u017d\u0003D\"\u0000\u0176\u017d\u0003B!\u0000\u0177"+
		"\u017d\u0003F#\u0000\u0178\u017d\u0003L&\u0000\u0179\u017d\u0003P(\u0000"+
		"\u017a\u017d\u0003N\'\u0000\u017b\u017d\u0003R)\u0000\u017c\u016e\u0001"+
		"\u0000\u0000\u0000\u017c\u016f\u0001\u0000\u0000\u0000\u017c\u0170\u0001"+
		"\u0000\u0000\u0000\u017c\u0171\u0001\u0000\u0000\u0000\u017c\u0172\u0001"+
		"\u0000\u0000\u0000\u017c\u0173\u0001\u0000\u0000\u0000\u017c\u0174\u0001"+
		"\u0000\u0000\u0000\u017c\u0175\u0001\u0000\u0000\u0000\u017c\u0176\u0001"+
		"\u0000\u0000\u0000\u017c\u0177\u0001\u0000\u0000\u0000\u017c\u0178\u0001"+
		"\u0000\u0000\u0000\u017c\u0179\u0001\u0000\u0000\u0000\u017c\u017a\u0001"+
		"\u0000\u0000\u0000\u017c\u017b\u0001\u0000\u0000\u0000\u017d\u017e\u0001"+
		"\u0000\u0000\u0000\u017e\u017f\u0005V\u0000\u0000\u017f\u0182\u0001\u0000"+
		"\u0000\u0000\u0180\u0182\u0003&\u0013\u0000\u0181\u016d\u0001\u0000\u0000"+
		"\u0000\u0181\u0180\u0001\u0000\u0000\u0000\u0182+\u0001\u0000\u0000\u0000"+
		"\u0183\u0184\u0005U\u0000\u0000\u0184\u0185\u0005\u0011\u0000\u0000\u0185"+
		"\u0186\u0005\u0012\u0000\u0000\u0186\u0187\u0003\u009eO\u0000\u0187\u0188"+
		"\u0005V\u0000\u0000\u0188-\u0001\u0000\u0000\u0000\u0189\u018a\u0005U"+
		"\u0000\u0000\u018a\u018b\u0005\u0011\u0000\u0000\u018b\u018d\u0005\u0013"+
		"\u0000\u0000\u018c\u018e\u00030\u0018\u0000\u018d\u018c\u0001\u0000\u0000"+
		"\u0000\u018e\u018f\u0001\u0000\u0000\u0000\u018f\u0190\u0001\u0000\u0000"+
		"\u0000\u018f\u018d\u0001\u0000\u0000\u0000\u0190\u0191\u0001\u0000\u0000"+
		"\u0000\u0191\u0192\u0005V\u0000\u0000\u0192/\u0001\u0000\u0000\u0000\u0193"+
		"\u0198\u0005U\u0000\u0000\u0194\u0195\u0005S\u0000\u0000\u0195\u0197\u0005"+
		"\u0014\u0000\u0000\u0196\u0194\u0001\u0000\u0000\u0000\u0197\u019a\u0001"+
		"\u0000\u0000\u0000\u0198\u0199\u0001\u0000\u0000\u0000\u0198\u0196\u0001"+
		"\u0000\u0000\u0000\u0199\u019b\u0001\u0000\u0000\u0000\u019a\u0198\u0001"+
		"\u0000\u0000\u0000\u019b\u019f\u0005S\u0000\u0000\u019c\u019e\u00030\u0018"+
		"\u0000\u019d\u019c\u0001\u0000\u0000\u0000\u019e\u01a1\u0001\u0000\u0000"+
		"\u0000\u019f\u01a0\u0001\u0000\u0000\u0000\u019f\u019d\u0001\u0000\u0000"+
		"\u0000\u01a0\u01a2\u0001\u0000\u0000\u0000\u01a1\u019f\u0001\u0000\u0000"+
		"\u0000\u01a2\u01a3\u0005V\u0000\u0000\u01a31\u0001\u0000\u0000\u0000\u01a4"+
		"\u01a5\u0005\u0011\u0000\u0000\u01a5\u01a7\u0005\u0015\u0000\u0000\u01a6"+
		"\u01a8\u0003\u00bc^\u0000\u01a7\u01a6\u0001\u0000\u0000\u0000\u01a7\u01a8"+
		"\u0001\u0000\u0000\u0000\u01a8\u01a9\u0001\u0000\u0000\u0000\u01a9\u01aa"+
		"\u0003x<\u0000\u01aa\u01ab\u00034\u001a\u0000\u01ab3\u0001\u0000\u0000"+
		"\u0000\u01ac\u01ad\u0005U\u0000\u0000\u01ad\u01af\u0005\u0015\u0000\u0000"+
		"\u01ae\u01b0\u00036\u001b\u0000\u01af\u01ae\u0001\u0000\u0000\u0000\u01b0"+
		"\u01b1\u0001\u0000\u0000\u0000\u01b1\u01b2\u0001\u0000\u0000\u0000\u01b1"+
		"\u01af\u0001\u0000\u0000\u0000\u01b2\u01b3\u0001\u0000\u0000\u0000\u01b3"+
		"\u01b4\u0005V\u0000\u0000\u01b45\u0001\u0000\u0000\u0000\u01b5\u01bb\u0005"+
		"U\u0000\u0000\u01b6\u01b7\u0003\u00c2a\u0000\u01b7\u01b8\u0005\u0014\u0000"+
		"\u0000\u01b8\u01ba\u0001\u0000\u0000\u0000\u01b9\u01b6\u0001\u0000\u0000"+
		"\u0000\u01ba\u01bd\u0001\u0000\u0000\u0000\u01bb\u01bc\u0001\u0000\u0000"+
		"\u0000\u01bb\u01b9\u0001\u0000\u0000\u0000\u01bc\u01be\u0001\u0000\u0000"+
		"\u0000\u01bd\u01bb\u0001\u0000\u0000\u0000\u01be\u01c2\u0003\u00c2a\u0000"+
		"\u01bf\u01c1\u00036\u001b\u0000\u01c0\u01bf\u0001\u0000\u0000\u0000\u01c1"+
		"\u01c4\u0001\u0000\u0000\u0000\u01c2\u01c3\u0001\u0000\u0000\u0000\u01c2"+
		"\u01c0\u0001\u0000\u0000\u0000\u01c3\u01c5\u0001\u0000\u0000\u0000\u01c4"+
		"\u01c2\u0001\u0000\u0000\u0000\u01c5\u01c6\u0005V\u0000\u0000\u01c67\u0001"+
		"\u0000\u0000\u0000\u01c7\u01c8\u0005\u0016\u0000\u0000\u01c8\u01c9\u0003"+
		"T*\u0000\u01c9\u01cb\u0005U\u0000\u0000\u01ca\u01cc\u0003:\u001d\u0000"+
		"\u01cb\u01ca\u0001\u0000\u0000\u0000\u01cc\u01cd\u0001\u0000\u0000\u0000"+
		"\u01cd\u01ce\u0001\u0000\u0000\u0000\u01cd\u01cb\u0001\u0000\u0000\u0000"+
		"\u01ce\u01cf\u0001\u0000\u0000\u0000\u01cf\u01d0\u0005V\u0000\u0000\u01d0"+
		"9\u0001\u0000\u0000\u0000\u01d1\u01d3\u0005U\u0000\u0000\u01d2\u01d4\u0003"+
		"<\u001e\u0000\u01d3\u01d2\u0001\u0000\u0000\u0000\u01d4\u01d5\u0001\u0000"+
		"\u0000\u0000\u01d5\u01d6\u0001\u0000\u0000\u0000\u01d5\u01d3\u0001\u0000"+
		"\u0000\u0000\u01d6\u01d7\u0001\u0000\u0000\u0000\u01d7\u01d8\u0003\u009e"+
		"O\u0000\u01d8\u01d9\u0005V\u0000\u0000\u01d9;\u0001\u0000\u0000\u0000"+
		"\u01da\u01db\u0005U\u0000\u0000\u01db\u01dc\u0003\u00bc^\u0000\u01dc\u01dd"+
		"\u0005\u0017\u0000\u0000\u01dd\u01de\u0003\u00bc^\u0000\u01de\u01df\u0005"+
		"V\u0000\u0000\u01df=\u0001\u0000\u0000\u0000\u01e0\u01e1\u0005\u0018\u0000"+
		"\u0000\u01e1\u01e7\u0007\u0003\u0000\u0000\u01e2\u01e8\u0003j5\u0000\u01e3"+
		"\u01e8\u0005\u001a\u0000\u0000\u01e4\u01e8\u0005\u0019\u0000\u0000\u01e5"+
		"\u01e8\u0005\u001b\u0000\u0000\u01e6\u01e8\u0003\u0004\u0002\u0000\u01e7"+
		"\u01e2\u0001\u0000\u0000\u0000\u01e7\u01e3\u0001\u0000\u0000\u0000\u01e7"+
		"\u01e4\u0001\u0000\u0000\u0000\u01e7\u01e5\u0001\u0000\u0000\u0000\u01e7"+
		"\u01e6\u0001\u0000\u0000\u0000\u01e8?\u0001\u0000\u0000\u0000\u01e9\u01ea"+
		"\u0005\u0016\u0000\u0000\u01ea\u01eb\u0003\u00ba]\u0000\u01eb\u01ec\u0003"+
		"\u009eO\u0000\u01ecA\u0001\u0000\u0000\u0000\u01ed\u01ee\u0005\u0016\u0000"+
		"\u0000\u01ee\u01ef\u0003\u00be_\u0000\u01ef\u01f0\u0003\u00bc^\u0000\u01f0"+
		"C\u0001\u0000\u0000\u0000\u01f1\u01f2\u0005\u001c\u0000\u0000\u01f2\u01f3"+
		"\u0003\u00ba]\u0000\u01f3\u01f4\u0003\u009eO\u0000\u01f4E\u0001\u0000"+
		"\u0000\u0000\u01f5\u01f6\u0005\u001d\u0000\u0000\u01f6\u01f7\u0003\u00ba"+
		"]\u0000\u01f7\u01f8\u0003\u009eO\u0000\u01f8G\u0001\u0000\u0000\u0000"+
		"\u01f9\u01fa\u0005\u001e\u0000\u0000\u01fa\u01fb\u0003V+\u0000\u01fb\u01fc"+
		"\u0003V+\u0000\u01fcI\u0001\u0000\u0000\u0000\u01fd\u01fe\u0005\u001f"+
		"\u0000\u0000\u01fe\u01ff\u0003V+\u0000\u01ff\u0200\u0003V+\u0000\u0200"+
		"K\u0001\u0000\u0000\u0000\u0201\u0202\u0005 \u0000\u0000\u0202\u0203\u0003"+
		"V+\u0000\u0203M\u0001\u0000\u0000\u0000\u0204\u020a\u0005!\u0000\u0000"+
		"\u0205\u020b\u0003x<\u0000\u0206\u0207\u0005\"\u0000\u0000\u0207\u0208"+
		"\u0003x<\u0000\u0208\u0209\u0003x<\u0000\u0209\u020b\u0001\u0000\u0000"+
		"\u0000\u020a\u0205\u0001\u0000\u0000\u0000\u020a\u0206\u0001\u0000\u0000"+
		"\u0000\u020bO\u0001\u0000\u0000\u0000\u020c\u020d\u0005#\u0000\u0000\u020d"+
		"\u020e\u0005$\u0000\u0000\u020eQ\u0001\u0000\u0000\u0000\u020f\u0210\u0005"+
		"%\u0000\u0000\u0210\u0211\u0003\u009eO\u0000\u0211\u0212\u0003*\u0015"+
		"\u0000\u0212\u021d\u0001\u0000\u0000\u0000\u0213\u0214\u0005%\u0000\u0000"+
		"\u0214\u0215\u0005\u000f\u0000\u0000\u0215\u0218\u0005U\u0000\u0000\u0216"+
		"\u0219\u0003H$\u0000\u0217\u0219\u0003L&\u0000\u0218\u0216\u0001\u0000"+
		"\u0000\u0000\u0218\u0217\u0001\u0000\u0000\u0000\u0219\u021a\u0001\u0000"+
		"\u0000\u0000\u021a\u021b\u0005V\u0000\u0000\u021b\u021d\u0001\u0000\u0000"+
		"\u0000\u021c\u020f\u0001\u0000\u0000\u0000\u021c\u0213\u0001\u0000\u0000"+
		"\u0000\u021dS\u0001\u0000\u0000\u0000\u021e\u0222\u0005U\u0000\u0000\u021f"+
		"\u0223\u0003\u0004\u0002\u0000\u0220\u0223\u0005\u0002\u0000\u0000\u0221"+
		"\u0223\u0003b1\u0000\u0222\u021f\u0001\u0000\u0000\u0000\u0222\u0220\u0001"+
		"\u0000\u0000\u0000\u0222\u0221\u0001\u0000\u0000\u0000\u0223\u0224\u0001"+
		"\u0000\u0000\u0000\u0224\u0225\u0005&\u0000\u0000\u0225\u0226\u0003\u00bc"+
		"^\u0000\u0226\u0227\u0005V\u0000\u0000\u0227U\u0001\u0000\u0000\u0000"+
		"\u0228\u0236\u0003\u0012\t\u0000\u0229\u0236\u0003Z-\u0000\u022a\u0236"+
		"\u0003\\.\u0000\u022b\u0236\u0003X,\u0000\u022c\u0230\u0005U\u0000\u0000"+
		"\u022d\u0231\u0005\'\u0000\u0000\u022e\u0231\u0005(\u0000\u0000\u022f"+
		"\u0231\u0003\u009eO\u0000\u0230\u022d\u0001\u0000\u0000\u0000\u0230\u022e"+
		"\u0001\u0000\u0000\u0000\u0230\u022f\u0001\u0000\u0000\u0000\u0231\u0232"+
		"\u0001\u0000\u0000\u0000\u0232\u0233\u0003x<\u0000\u0233\u0234\u0005V"+
		"\u0000\u0000\u0234\u0236\u0001\u0000\u0000\u0000\u0235\u0228\u0001\u0000"+
		"\u0000\u0000\u0235\u0229\u0001\u0000\u0000\u0000\u0235\u022a\u0001\u0000"+
		"\u0000\u0000\u0235\u022b\u0001\u0000\u0000\u0000\u0235\u022c\u0001\u0000"+
		"\u0000\u0000\u0236W\u0001\u0000\u0000\u0000\u0237\u0238\u0005U\u0000\u0000"+
		"\u0238\u0239\u0005)\u0000\u0000\u0239\u023a\u0003V+\u0000\u023a\u023b"+
		"\u0005V\u0000\u0000\u023bY\u0001\u0000\u0000\u0000\u023c\u023d\u0005U"+
		"\u0000\u0000\u023d\u023e\u0005\u0007\u0000\u0000\u023e\u023f\u0003x<\u0000"+
		"\u023f\u0240\u0005*\u0000\u0000\u0240\u0241\u0003T*\u0000\u0241\u0242"+
		"\u0005V\u0000\u0000\u0242[\u0001\u0000\u0000\u0000\u0243\u0244\u0005U"+
		"\u0000\u0000\u0244\u0245\u0005\u0006\u0000\u0000\u0245\u0246\u0003x<\u0000"+
		"\u0246\u0247\u0005*\u0000\u0000\u0247\u0248\u0003T*\u0000\u0248\u0249"+
		"\u0005V\u0000\u0000\u0249]\u0001\u0000\u0000\u0000\u024a\u024e\u0005\u0002"+
		"\u0000\u0000\u024b\u024e\u0003\u0006\u0003\u0000\u024c\u024e\u0003d2\u0000"+
		"\u024d\u024a\u0001\u0000\u0000\u0000\u024d\u024b\u0001\u0000\u0000\u0000"+
		"\u024d\u024c\u0001\u0000\u0000\u0000\u024e_\u0001\u0000\u0000\u0000\u024f"+
		"\u0250\u0007\u0004\u0000\u0000\u0250a\u0001\u0000\u0000\u0000\u0251\u0254"+
		"\u0003f3\u0000\u0252\u0254\u0003d2\u0000\u0253\u0251\u0001\u0000\u0000"+
		"\u0000\u0253\u0252\u0001\u0000\u0000\u0000\u0254c\u0001\u0000\u0000\u0000"+
		"\u0255\u0256\u0005U\u0000\u0000\u0256\u0257\u0003h4\u0000\u0257\u0258"+
		"\u0005\t\u0000\u0000\u0258\u0259\u0005V\u0000\u0000\u0259\u025c\u0001"+
		"\u0000\u0000\u0000\u025a\u025c\u0003j5\u0000\u025b\u0255\u0001\u0000\u0000"+
		"\u0000\u025b\u025a\u0001\u0000\u0000\u0000\u025ce\u0001\u0000\u0000\u0000"+
		"\u025d\u025e\u0005U\u0000\u0000\u025e\u025f\u0003h4\u0000\u025f\u0260"+
		"\u0005\n\u0000\u0000\u0260\u0261\u0005V\u0000\u0000\u0261\u0264\u0001"+
		"\u0000\u0000\u0000\u0262\u0264\u0003l6\u0000\u0263\u025d\u0001\u0000\u0000"+
		"\u0000\u0263\u0262\u0001\u0000\u0000\u0000\u0264g\u0001\u0000\u0000\u0000"+
		"\u0265\u026a\u0003\u009eO\u0000\u0266\u026a\u0005\u001b\u0000\u0000\u0267"+
		"\u026a\u0005\u0019\u0000\u0000\u0268\u026a\u0005\u001a\u0000\u0000\u0269"+
		"\u0265\u0001\u0000\u0000\u0000\u0269\u0266\u0001\u0000\u0000\u0000\u0269"+
		"\u0267\u0001\u0000\u0000\u0000\u0269\u0268\u0001\u0000\u0000\u0000\u026a"+
		"i\u0001\u0000\u0000\u0000\u026b\u026c\u0005U\u0000\u0000\u026c\u026d\u0005"+
		"0\u0000\u0000\u026d\u026e\u0003V+\u0000\u026e\u026f\u0005V\u0000\u0000"+
		"\u026fk\u0001\u0000\u0000\u0000\u0270\u0271\u0005U\u0000\u0000\u0271\u0274"+
		"\u0005\n\u0000\u0000\u0272\u0275\u0003\u0006\u0003\u0000\u0273\u0275\u0003"+
		"d2\u0000\u0274\u0272\u0001\u0000\u0000\u0000\u0274\u0273\u0001\u0000\u0000"+
		"\u0000\u0275\u0276\u0001\u0000\u0000\u0000\u0276\u0277\u0005V\u0000\u0000"+
		"\u0277m\u0001\u0000\u0000\u0000\u0278\u027d\u0003\u009eO\u0000\u0279\u027d"+
		"\u0003\u0098L\u0000\u027a\u027d\u0003\u00bc^\u0000\u027b\u027d\u0003p"+
		"8\u0000\u027c\u0278\u0001\u0000\u0000\u0000\u027c\u0279\u0001\u0000\u0000"+
		"\u0000\u027c\u027a\u0001\u0000\u0000\u0000\u027c\u027b\u0001\u0000\u0000"+
		"\u0000\u027do\u0001\u0000\u0000\u0000\u027e\u0289\u0003\f\u0006\u0000"+
		"\u027f\u0289\u0003\u0082A\u0000\u0280\u0289\u0003x<\u0000\u0281\u0289"+
		"\u0003r9\u0000\u0282\u0289\u0003\u008aE\u0000\u0283\u0289\u0005\t\u0000"+
		"\u0000\u0284\u0289\u0005\n\u0000\u0000\u0285\u0289\u0003f3\u0000\u0286"+
		"\u0289\u0003v;\u0000\u0287\u0289\u0003t:\u0000\u0288\u027e\u0001\u0000"+
		"\u0000\u0000\u0288\u027f\u0001\u0000\u0000\u0000\u0288\u0280\u0001\u0000"+
		"\u0000\u0000\u0288\u0281\u0001\u0000\u0000\u0000\u0288\u0282\u0001\u0000"+
		"\u0000\u0000\u0288\u0283\u0001\u0000\u0000\u0000\u0288\u0284\u0001\u0000"+
		"\u0000\u0000\u0288\u0285\u0001\u0000\u0000\u0000\u0288\u0286\u0001\u0000"+
		"\u0000\u0000\u0288\u0287\u0001\u0000\u0000\u0000\u0289q\u0001\u0000\u0000"+
		"\u0000\u028a\u0290\u0005U\u0000\u0000\u028b\u028c\u0003\u00c2a\u0000\u028c"+
		"\u028d\u0005\u0014\u0000\u0000\u028d\u028f\u0001\u0000\u0000\u0000\u028e"+
		"\u028b\u0001\u0000\u0000\u0000\u028f\u0292\u0001\u0000\u0000\u0000\u0290"+
		"\u0291\u0001\u0000\u0000\u0000\u0290\u028e\u0001\u0000\u0000\u0000\u0291"+
		"\u0293\u0001\u0000\u0000\u0000\u0292\u0290\u0001\u0000\u0000\u0000\u0293"+
		"\u0294\u0003\u00c2a\u0000\u0294\u0295\u0005V\u0000\u0000\u0295s\u0001"+
		"\u0000\u0000\u0000\u0296\u0297\u0005U\u0000\u0000\u0297\u0298\u00051\u0000"+
		"\u0000\u0298\u0299\u0003\u009eO\u0000\u0299\u029a\u00052\u0000\u0000\u029a"+
		"\u029b\u0003\u009eO\u0000\u029b\u029c\u0005V\u0000\u0000\u029cu\u0001"+
		"\u0000\u0000\u0000\u029d\u029e\u0005U\u0000\u0000\u029e\u029f\u00053\u0000"+
		"\u0000\u029f\u02a0\u0007\u0001\u0000\u0000\u02a0\u02a1\u0005V\u0000\u0000"+
		"\u02a1w\u0001\u0000\u0000\u0000\u02a2\u02b5\u0003\u000e\u0007\u0000\u02a3"+
		"\u02b5\u0003|>\u0000\u02a4\u02b5\u0003~?\u0000\u02a5\u02b5\u0003\u0080"+
		"@\u0000\u02a6\u02b5\u0003z=\u0000\u02a7\u02b5\u0003\u0082A\u0000\u02a8"+
		"\u02a9\u0005U\u0000\u0000\u02a9\u02aa\u0003^/\u0000\u02aa\u02ab\u0003"+
		"`0\u0000\u02ab\u02ad\u0003\u00bc^\u0000\u02ac\u02ae\u0003\u009eO\u0000"+
		"\u02ad\u02ac\u0001\u0000\u0000\u0000\u02ad\u02ae\u0001\u0000\u0000\u0000"+
		"\u02ae\u02af\u0001\u0000\u0000\u0000\u02af\u02b0\u0005V\u0000\u0000\u02b0"+
		"\u02b5\u0001\u0000\u0000\u0000\u02b1\u02b5\u0003\u0084B\u0000\u02b2\u02b5"+
		"\u0003\u0086C\u0000\u02b3\u02b5\u0003\u0088D\u0000\u02b4\u02a2\u0001\u0000"+
		"\u0000\u0000\u02b4\u02a3\u0001\u0000\u0000\u0000\u02b4\u02a4\u0001\u0000"+
		"\u0000\u0000\u02b4\u02a5\u0001\u0000\u0000\u0000\u02b4\u02a6\u0001\u0000"+
		"\u0000\u0000\u02b4\u02a7\u0001\u0000\u0000\u0000\u02b4\u02a8\u0001\u0000"+
		"\u0000\u0000\u02b4\u02b1\u0001\u0000\u0000\u0000\u02b4\u02b2\u0001\u0000"+
		"\u0000\u0000\u02b4\u02b3\u0001\u0000\u0000\u0000\u02b5y\u0001\u0000\u0000"+
		"\u0000\u02b6\u02b7\u0005U\u0000\u0000\u02b7\u02b8\u00054\u0000\u0000\u02b8"+
		"\u02b9\u0003x<\u0000\u02b9\u02ba\u0005*\u0000\u0000\u02ba\u02bb\u0003"+
		"T*\u0000\u02bb\u02bc\u0005V\u0000\u0000\u02bc{\u0001\u0000\u0000\u0000"+
		"\u02bd\u02be\u0005U\u0000\u0000\u02be\u02c5\u00055\u0000\u0000\u02bf\u02c6"+
		"\u0003\u0094J\u0000\u02c0\u02c2\u0003x<\u0000\u02c1\u02c0\u0001\u0000"+
		"\u0000\u0000\u02c2\u02c3\u0001\u0000\u0000\u0000\u02c3\u02c4\u0001\u0000"+
		"\u0000\u0000\u02c3\u02c1\u0001\u0000\u0000\u0000\u02c4\u02c6\u0001\u0000"+
		"\u0000\u0000\u02c5\u02bf\u0001\u0000\u0000\u0000\u02c5\u02c1\u0001\u0000"+
		"\u0000\u0000\u02c6\u02c7\u0001\u0000\u0000\u0000\u02c7\u02c8\u0005V\u0000"+
		"\u0000\u02c8}\u0001\u0000\u0000\u0000\u02c9\u02ca\u0005U\u0000\u0000\u02ca"+
		"\u02d1\u00056\u0000\u0000\u02cb\u02d2\u0003\u0094J\u0000\u02cc\u02ce\u0003"+
		"x<\u0000\u02cd\u02cc\u0001\u0000\u0000\u0000\u02ce\u02cf\u0001\u0000\u0000"+
		"\u0000\u02cf\u02d0\u0001\u0000\u0000\u0000\u02cf\u02cd\u0001\u0000\u0000"+
		"\u0000\u02d0\u02d2\u0001\u0000\u0000\u0000\u02d1\u02cb\u0001\u0000\u0000"+
		"\u0000\u02d1\u02cd\u0001\u0000\u0000\u0000\u02d2\u02d3\u0001\u0000\u0000"+
		"\u0000\u02d3\u02d4\u0005V\u0000\u0000\u02d4\u007f\u0001\u0000\u0000\u0000"+
		"\u02d5\u02d6\u0005U\u0000\u0000\u02d6\u02dd\u00057\u0000\u0000\u02d7\u02de"+
		"\u0003\u0094J\u0000\u02d8\u02da\u0003x<\u0000\u02d9\u02d8\u0001\u0000"+
		"\u0000\u0000\u02da\u02db\u0001\u0000\u0000\u0000\u02db\u02dc\u0001\u0000"+
		"\u0000\u0000\u02db\u02d9\u0001\u0000\u0000\u0000\u02dc\u02de\u0001\u0000"+
		"\u0000\u0000\u02dd\u02d7\u0001\u0000\u0000\u0000\u02dd\u02d9\u0001\u0000"+
		"\u0000\u0000\u02de\u02df\u0001\u0000\u0000\u0000\u02df\u02e0\u0005V\u0000"+
		"\u0000\u02e0\u0081\u0001\u0000\u0000\u0000\u02e1\u02e2\u0005U\u0000\u0000"+
		"\u02e2\u02e3\u00058\u0000\u0000\u02e3\u02e4\u0003p8\u0000\u02e4\u02e5"+
		"\u0003\u0000\u0000\u0000\u02e5\u02e6\u0003\u0098L\u0000\u02e6\u02e7\u0005"+
		"V\u0000\u0000\u02e7\u0083\u0001\u0000\u0000\u0000\u02e8\u02ec\u0005U\u0000"+
		"\u0000\u02e9\u02ed\u0005\'\u0000\u0000\u02ea\u02ed\u0005(\u0000\u0000"+
		"\u02eb\u02ed\u0003\u009eO\u0000\u02ec\u02e9\u0001\u0000\u0000\u0000\u02ec"+
		"\u02ea\u0001\u0000\u0000\u0000\u02ec\u02eb\u0001\u0000\u0000\u0000\u02ed"+
		"\u02ee\u0001\u0000\u0000\u0000\u02ee\u02ef\u0003\u008aE\u0000\u02ef\u02f0"+
		"\u0005V\u0000\u0000\u02f0\u0085\u0001\u0000\u0000\u0000\u02f1\u02f2\u0005"+
		"U\u0000\u0000\u02f2\u02f3\u0007\u0005\u0000\u0000\u02f3\u02f4\u0003\u009e"+
		"O\u0000\u02f4\u02f5\u0003x<\u0000\u02f5\u02f6\u0005V\u0000\u0000\u02f6"+
		"\u0087\u0001\u0000\u0000\u0000\u02f7\u02f8\u0005U\u0000\u0000\u02f8\u02f9"+
		"\u00059\u0000\u0000\u02f9\u02fa\u0007\u0005\u0000\u0000\u02fa\u02fb\u0003"+
		"\u009eO\u0000\u02fb\u02fc\u0003x<\u0000\u02fc\u02fd\u0005*\u0000\u0000"+
		"\u02fd\u02fe\u0003T*\u0000\u02fe\u02ff\u0005V\u0000\u0000\u02ff\u0089"+
		"\u0001\u0000\u0000\u0000\u0300\u0308\u0003\u0090H\u0000\u0301\u0308\u0003"+
		"\u0092I\u0000\u0302\u0308\u0003\u008eG\u0000\u0303\u0308\u0003\u008cF"+
		"\u0000\u0304\u0308\u0003\u0094J\u0000\u0305\u0308\u0003\u0010\b\u0000"+
		"\u0306\u0308\u0003\u0096K\u0000\u0307\u0300\u0001\u0000\u0000\u0000\u0307"+
		"\u0301\u0001\u0000\u0000\u0000\u0307\u0302\u0001\u0000\u0000\u0000\u0307"+
		"\u0303\u0001\u0000\u0000\u0000\u0307\u0304\u0001\u0000\u0000\u0000\u0307"+
		"\u0305\u0001\u0000\u0000\u0000\u0307\u0306\u0001\u0000\u0000\u0000\u0308"+
		"\u008b\u0001\u0000\u0000\u0000\u0309\u030a\u0005U\u0000\u0000\u030a\u030b"+
		"\u0005:\u0000\u0000\u030b\u030c\u0007\u0006\u0000\u0000\u030c\u030d\u0003"+
		"\u009eO\u0000\u030d\u030e\u0003x<\u0000\u030e\u030f\u0005*\u0000\u0000"+
		"\u030f\u0310\u0003T*\u0000\u0310\u0311\u0005V\u0000\u0000\u0311\u008d"+
		"\u0001\u0000\u0000\u0000\u0312\u0313\u0005U\u0000\u0000\u0313\u0314\u0005"+
		"<\u0000\u0000\u0314\u0315\u0003x<\u0000\u0315\u0316\u0005V\u0000\u0000"+
		"\u0316\u008f\u0001\u0000\u0000\u0000\u0317\u0318\u0005U\u0000\u0000\u0318"+
		"\u0319\u0005=\u0000\u0000\u0319\u031a\u0003\u009eO\u0000\u031a\u031b\u0003"+
		"x<\u0000\u031b\u031c\u0005*\u0000\u0000\u031c\u031d\u0003T*\u0000\u031d"+
		"\u031e\u0005V\u0000\u0000\u031e\u0091\u0001\u0000\u0000\u0000\u031f\u0320"+
		"\u0005U\u0000\u0000\u0320\u0321\u0005>\u0000\u0000\u0321\u0328\u0003\u00bc"+
		"^\u0000\u0322\u0329\u0003\u0094J\u0000\u0323\u0325\u0003x<\u0000\u0324"+
		"\u0323\u0001\u0000\u0000\u0000\u0325\u0326\u0001\u0000\u0000\u0000\u0326"+
		"\u0327\u0001\u0000\u0000\u0000\u0326\u0324\u0001\u0000\u0000\u0000\u0327"+
		"\u0329\u0001\u0000\u0000\u0000\u0328\u0322\u0001\u0000\u0000\u0000\u0328"+
		"\u0324\u0001\u0000\u0000\u0000\u0329\u032a\u0001\u0000\u0000\u0000\u032a"+
		"\u032b\u0005V\u0000\u0000\u032b\u0093\u0001\u0000\u0000\u0000\u032c\u032d"+
		"\u0005U\u0000\u0000\u032d\u032e\u0005\u000f\u0000\u0000\u032e\u032f\u0003"+
		"p8\u0000\u032f\u0330\u0003\u0000\u0000\u0000\u0330\u0331\u0003x<\u0000"+
		"\u0331\u0332\u0005V\u0000\u0000\u0332\u0095\u0001\u0000\u0000\u0000\u0333"+
		"\u0334\u0005U\u0000\u0000\u0334\u0335\u0005?\u0000\u0000\u0335\u0336\u0003"+
		"^/\u0000\u0336\u0337\u0003`0\u0000\u0337\u0338\u0003\u00bc^\u0000\u0338"+
		"\u0339\u0005V\u0000\u0000\u0339\u0097\u0001\u0000\u0000\u0000\u033a\u0358"+
		"\u0005U\u0000\u0000\u033b\u033c\u0005O\u0000\u0000\u033c\u033e\u0003\u0098"+
		"L\u0000\u033d\u033f\u0003\u0098L\u0000\u033e\u033d\u0001\u0000\u0000\u0000"+
		"\u033f\u0340\u0001\u0000\u0000\u0000\u0340\u0341\u0001\u0000\u0000\u0000"+
		"\u0340\u033e\u0001\u0000\u0000\u0000\u0341\u0359\u0001\u0000\u0000\u0000"+
		"\u0342\u0343\u0003\u009aM\u0000\u0343\u0344\u0003\u009eO\u0000\u0344\u0345"+
		"\u0003\u009eO\u0000\u0345\u0359\u0001\u0000\u0000\u0000\u0346\u0347\u0005"+
		"Q\u0000\u0000\u0347\u0348\u0003\u00bc^\u0000\u0348\u0349\u0003\u00bc^"+
		"\u0000\u0349\u0359\u0001\u0000\u0000\u0000\u034a\u034b\u0005Q\u0000\u0000"+
		"\u034b\u034c\u0003V+\u0000\u034c\u034d\u0003V+\u0000\u034d\u0359\u0001"+
		"\u0000\u0000\u0000\u034e\u034f\u0005R\u0000\u0000\u034f\u0359\u0003\u0098"+
		"L\u0000\u0350\u0351\u0005Q\u0000\u0000\u0351\u0352\u0003d2\u0000\u0352"+
		"\u0353\u0003d2\u0000\u0353\u0359\u0001\u0000\u0000\u0000\u0354\u0355\u0005"+
		"Q\u0000\u0000\u0355\u0356\u0003f3\u0000\u0356\u0357\u0003f3\u0000\u0357"+
		"\u0359\u0001\u0000\u0000\u0000\u0358\u033b\u0001\u0000\u0000\u0000\u0358"+
		"\u0342\u0001\u0000\u0000\u0000\u0358\u0346\u0001\u0000\u0000\u0000\u0358"+
		"\u034a\u0001\u0000\u0000\u0000\u0358\u034e\u0001\u0000\u0000\u0000\u0358"+
		"\u0350\u0001\u0000\u0000\u0000\u0358\u0354\u0001\u0000\u0000\u0000\u0359"+
		"\u035a\u0001\u0000\u0000\u0000\u035a\u035b\u0005V\u0000\u0000\u035b\u035e"+
		"\u0001\u0000\u0000\u0000\u035c\u035e\u0003\u009cN\u0000\u035d\u033a\u0001"+
		"\u0000\u0000\u0000\u035d\u035c\u0001\u0000\u0000\u0000\u035e\u0099\u0001"+
		"\u0000\u0000\u0000\u035f\u0360\u0007\u0007\u0000\u0000\u0360\u009b\u0001"+
		"\u0000\u0000\u0000\u0361\u0362\u0005U\u0000\u0000\u0362\u0363\u0007\u0002"+
		"\u0000\u0000\u0363\u0364\u0003p8\u0000\u0364\u0365\u0003\u0000\u0000\u0000"+
		"\u0365\u0366\u0003\u0098L\u0000\u0366\u0367\u0005V\u0000\u0000\u0367\u009d"+
		"\u0001\u0000\u0000\u0000\u0368\u037c\u0003\b\u0004\u0000\u0369\u037c\u0003"+
		"\u00b6[\u0000\u036a\u037c\u0003\u00a6S\u0000\u036b\u037c\u0003\u00a8T"+
		"\u0000\u036c\u037c\u0003\u00aaU\u0000\u036d\u037c\u0003\u00a4R\u0000\u036e"+
		"\u037c\u0003\u00acV\u0000\u036f\u037c\u0003\u00aeW\u0000\u0370\u037c\u0003"+
		"\u00b0X\u0000\u0371\u037c\u0003\u00b2Y\u0000\u0372\u037c\u0003\u00b4Z"+
		"\u0000\u0373\u037c\u0003\u00a0P\u0000\u0374\u037c\u0003\u00ba]\u0000\u0375"+
		"\u037c\u0003\u00a2Q\u0000\u0376\u0378\u0005S\u0000\u0000\u0377\u0376\u0001"+
		"\u0000\u0000\u0000\u0378\u0379\u0001\u0000\u0000\u0000\u0379\u0377\u0001"+
		"\u0000\u0000\u0000\u0379\u037a\u0001\u0000\u0000\u0000\u037a\u037c\u0001"+
		"\u0000\u0000\u0000\u037b\u0368\u0001\u0000\u0000\u0000\u037b\u0369\u0001"+
		"\u0000\u0000\u0000\u037b\u036a\u0001\u0000\u0000\u0000\u037b\u036b\u0001"+
		"\u0000\u0000\u0000\u037b\u036c\u0001\u0000\u0000\u0000\u037b\u036d\u0001"+
		"\u0000\u0000\u0000\u037b\u036e\u0001\u0000\u0000\u0000\u037b\u036f\u0001"+
		"\u0000\u0000\u0000\u037b\u0370\u0001\u0000\u0000\u0000\u037b\u0371\u0001"+
		"\u0000\u0000\u0000\u037b\u0372\u0001\u0000\u0000\u0000\u037b\u0373\u0001"+
		"\u0000\u0000\u0000\u037b\u0374\u0001\u0000\u0000\u0000\u037b\u0375\u0001"+
		"\u0000\u0000\u0000\u037b\u0377\u0001\u0000\u0000\u0000\u037c\u009f\u0001"+
		"\u0000\u0000\u0000\u037d\u037e\u0005U\u0000\u0000\u037e\u037f\u0005@\u0000"+
		"\u0000\u037f\u0380\u0003x<\u0000\u0380\u0381\u0005*\u0000\u0000\u0381"+
		"\u0382\u0003T*\u0000\u0382\u0383\u0005V\u0000\u0000\u0383\u00a1\u0001"+
		"\u0000\u0000\u0000\u0384\u0385\u0005U\u0000\u0000\u0385\u0386\u0005A\u0000"+
		"\u0000\u0386\u0387\u0003V+\u0000\u0387\u0388\u0005*\u0000\u0000\u0388"+
		"\u0389\u0003T*\u0000\u0389\u038a\u0005V\u0000\u0000\u038a\u00a3\u0001"+
		"\u0000\u0000\u0000\u038b\u038c\u0005U\u0000\u0000\u038c\u038d\u0005B\u0000"+
		"\u0000\u038d\u038e\u0003\u009eO\u0000\u038e\u038f\u0003\u009eO\u0000\u038f"+
		"\u0390\u0005V\u0000\u0000\u0390\u00a5\u0001\u0000\u0000\u0000\u0391\u0392"+
		"\u0005U\u0000\u0000\u0392\u0393\u0005C\u0000\u0000\u0393\u0394\u0003\u009e"+
		"O\u0000\u0394\u0395\u0003\u009eO\u0000\u0395\u0396\u0005V\u0000\u0000"+
		"\u0396\u00a7\u0001\u0000\u0000\u0000\u0397\u0398\u0005U\u0000\u0000\u0398"+
		"\u0399\u0005D\u0000\u0000\u0399\u039a\u0003\u009eO\u0000\u039a\u039b\u0003"+
		"\u009eO\u0000\u039b\u039c\u0005V\u0000\u0000\u039c\u00a9\u0001\u0000\u0000"+
		"\u0000\u039d\u039e\u0005U\u0000\u0000\u039e\u039f\u0005E\u0000\u0000\u039f"+
		"\u03a0\u0003\u009eO\u0000\u03a0\u03a1\u0003\u009eO\u0000\u03a1\u03a2\u0005"+
		"V\u0000\u0000\u03a2\u00ab\u0001\u0000\u0000\u0000\u03a3\u03a4\u0005U\u0000"+
		"\u0000\u03a4\u03a5\u0005F\u0000\u0000\u03a5\u03a6\u0003\u009eO\u0000\u03a6"+
		"\u03a7\u0003\u009eO\u0000\u03a7\u03a8\u0005V\u0000\u0000\u03a8\u00ad\u0001"+
		"\u0000\u0000\u0000\u03a9\u03aa\u0005U\u0000\u0000\u03aa\u03ab\u0005G\u0000"+
		"\u0000\u03ab\u03ac\u0003\u009eO\u0000\u03ac\u03ad\u0003\u009eO\u0000\u03ad"+
		"\u03ae\u0005V\u0000\u0000\u03ae\u00af\u0001\u0000\u0000\u0000\u03af\u03b0"+
		"\u0005U\u0000\u0000\u03b0\u03b1\u0005H\u0000\u0000\u03b1\u03b2\u0003\u009e"+
		"O\u0000\u03b2\u03b3\u0005V\u0000\u0000\u03b3\u00b1\u0001\u0000\u0000\u0000"+
		"\u03b4\u03b5\u0005U\u0000\u0000\u03b5\u03b6\u0005I\u0000\u0000\u03b6\u03b7"+
		"\u0003\u009eO\u0000\u03b7\u03b8\u0005V\u0000\u0000\u03b8\u00b3\u0001\u0000"+
		"\u0000\u0000\u03b9\u03ba\u0005U\u0000\u0000\u03ba\u03bb\u0005J\u0000\u0000"+
		"\u03bb\u03be\u0003\u009eO\u0000\u03bc\u03bd\u00052\u0000\u0000\u03bd\u03bf"+
		"\u0003\u009eO\u0000\u03be\u03bc\u0001\u0000\u0000\u0000\u03be\u03bf\u0001"+
		"\u0000\u0000\u0000\u03bf\u03c0\u0001\u0000\u0000\u0000\u03c0\u03c1\u0005"+
		"V\u0000\u0000\u03c1\u00b5\u0001\u0000\u0000\u0000\u03c2\u03c3\u0005U\u0000"+
		"\u0000\u03c3\u03c4\u0005K\u0000\u0000\u03c4\u03c5\u0003p8\u0000\u03c5"+
		"\u03c6\u0005V\u0000\u0000\u03c6\u00b7\u0001\u0000\u0000\u0000\u03c7\u03c8"+
		"\u0005U\u0000\u0000\u03c8\u03c9\u0005\u000f\u0000\u0000\u03c9\u03ca\u0003"+
		"p8\u0000\u03ca\u03cb\u0003\u0000\u0000\u0000\u03cb\u03cc\u0003\u00ba]"+
		"\u0000\u03cc\u03cd\u0005V\u0000\u0000\u03cd\u00b9\u0001\u0000\u0000\u0000"+
		"\u03ce\u03d2\u0005U\u0000\u0000\u03cf\u03d3\u0003\u0004\u0002\u0000\u03d0"+
		"\u03d3\u0005\u0002\u0000\u0000\u03d1\u03d3\u0003b1\u0000\u03d2\u03cf\u0001"+
		"\u0000\u0000\u0000\u03d2\u03d0\u0001\u0000\u0000\u0000\u03d2\u03d1\u0001"+
		"\u0000\u0000\u0000\u03d3\u03d4\u0001\u0000\u0000\u0000\u03d4\u03d5\u0005"+
		"L\u0000\u0000\u03d5\u03d6\u0003\u00bc^\u0000\u03d6\u03d7\u0005V\u0000"+
		"\u0000\u03d7\u00bb\u0001\u0000\u0000\u0000\u03d8\u03dd\u0003\u00c2a\u0000"+
		"\u03d9\u03dd\u0003\u00be_\u0000\u03da\u03dd\u0003\u0002\u0001\u0000\u03db"+
		"\u03dd\u0003\u00c0`\u0000\u03dc\u03d8\u0001\u0000\u0000\u0000\u03dc\u03d9"+
		"\u0001\u0000\u0000\u0000\u03dc\u03da\u0001\u0000\u0000\u0000\u03dc\u03db"+
		"\u0001\u0000\u0000\u0000\u03dd\u00bd\u0001\u0000\u0000\u0000\u03de\u03e2"+
		"\u0005U\u0000\u0000\u03df\u03e3\u0003\u0004\u0002\u0000\u03e0\u03e3\u0005"+
		"\u0002\u0000\u0000\u03e1\u03e3\u0003b1\u0000\u03e2\u03df\u0001\u0000\u0000"+
		"\u0000\u03e2\u03e0\u0001\u0000\u0000\u0000\u03e2\u03e1\u0001\u0000\u0000"+
		"\u0000\u03e3\u03e4\u0001\u0000\u0000\u0000\u03e4\u03e5\u0005M\u0000\u0000"+
		"\u03e5\u03e6\u0003\u00bc^\u0000\u03e6\u03e7\u0005V\u0000\u0000\u03e7\u00bf"+
		"\u0001\u0000\u0000\u0000\u03e8\u03e9\u0005U\u0000\u0000\u03e9\u03ea\u0005"+
		"N\u0000\u0000\u03ea\u03eb\u0003\u00bc^\u0000\u03eb\u03ec\u0003V+\u0000"+
		"\u03ec\u03ed\u0005V\u0000\u0000\u03ed\u00c1\u0001\u0000\u0000\u0000\u03ee"+
		"\u03f0\u0005T\u0000\u0000\u03ef\u03ee\u0001\u0000\u0000\u0000\u03f0\u03f1"+
		"\u0001\u0000\u0000\u0000\u03f1\u03ef\u0001\u0000\u0000\u0000\u03f1\u03f2"+
		"\u0001\u0000\u0000\u0000\u03f2\u00c3\u0001\u0000\u0000\u0000@\u00e7\u00ed"+
		"\u00ef\u00fe\u0103\u0109\u0119\u011b\u012a\u0135\u013c\u0144\u014b\u0159"+
		"\u0169\u017c\u0181\u018f\u0198\u019f\u01a7\u01b1\u01bb\u01c2\u01cd\u01d5"+
		"\u01e7\u020a\u0218\u021c\u0222\u0230\u0235\u024d\u0253\u025b\u0263\u0269"+
		"\u0274\u027c\u0288\u0290\u02ad\u02b4\u02c3\u02c5\u02cf\u02d1\u02db\u02dd"+
		"\u02ec\u0307\u0326\u0328\u0340\u0358\u035d\u0379\u037b\u03be\u03d2\u03dc"+
		"\u03e2\u03f1";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}