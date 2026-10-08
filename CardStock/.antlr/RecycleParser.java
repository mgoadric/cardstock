// Generated from /Users/lukespeer/Documents/projects/cardstock/CardStock/Recycle.g4 by ANTLR 4.13.1
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
		T__73=74, T__74=75, T__75=76, T__76=77, T__77=78, T__78=79, T__79=80, 
		T__80=81, T__81=82, T__82=83, BOOLOP=84, COMPOP=85, EQOP=86, UNOP=87, 
		INTNUM=88, LETT=89, OPEN=90, CLOSE=91, WS=92, ANY=93;
	public static final int
		RULE_var = 0, RULE_vars = 1, RULE_varo = 2, RULE_varp = 3, RULE_vari = 4, 
		RULE_varb = 5, RULE_varc = 6, RULE_varcs = 7, RULE_varcsc = 8, RULE_varcard = 9, 
		RULE_vart = 10, RULE_game = 11, RULE_declare = 12, RULE_setup = 13, RULE_scoring = 14, 
		RULE_stage = 15, RULE_endcondition = 16, RULE_multiaction = 17, RULE_multiaction2 = 18, 
		RULE_condact = 19, RULE_agg = 20, RULE_let = 21, RULE_action = 22, RULE_playercreate = 23, 
		RULE_teamcreate = 24, RULE_teams = 25, RULE_deckcreate = 26, RULE_deck = 27, 
		RULE_attribute = 28, RULE_initpoints = 29, RULE_updatepoints = 30, RULE_awards = 31, 
		RULE_subaward = 32, RULE_cycleaction = 33, RULE_setaction = 34, RULE_setstraction = 35, 
		RULE_incaction = 36, RULE_decaction = 37, RULE_moveaction = 38, RULE_swapaction = 39, 
		RULE_copyaction = 40, RULE_removeaction = 41, RULE_shuffleaction = 42, 
		RULE_turnaction = 43, RULE_repeat = 44, RULE_pointstorage = 45, RULE_card = 46, 
		RULE_maxof = 47, RULE_minof = 48, RULE_locpre = 49, RULE_locdesc = 50, 
		RULE_who = 51, RULE_whop = 52, RULE_whot = 53, RULE_whodesc = 54, RULE_owner = 55, 
		RULE_teamp = 56, RULE_typed = 57, RULE_collection = 58, RULE_strcollection = 59, 
		RULE_range = 60, RULE_other = 61, RULE_cstorage = 62, RULE_basecstorage = 63, 
		RULE_unionof = 64, RULE_intersectof = 65, RULE_disjunctionof = 66, RULE_filter = 67, 
		RULE_memstorage = 68, RULE_sequence = 69, RULE_runsequence = 70, RULE_cstoragecollection = 71, 
		RULE_run = 72, RULE_subset = 73, RULE_partition = 74, RULE_aggcs = 75, 
		RULE_indexed = 76, RULE_boolean = 77, RULE_intop = 78, RULE_aggb = 79, 
		RULE_int = 80, RULE_intgr = 81, RULE_sum = 82, RULE_scoremax = 83, RULE_scoremin = 84, 
		RULE_score = 85, RULE_add = 86, RULE_mult = 87, RULE_subtract = 88, RULE_mod = 89, 
		RULE_divide = 90, RULE_exponent = 91, RULE_triangular = 92, RULE_fibonacci = 93, 
		RULE_random = 94, RULE_sizeof = 95, RULE_aggi = 96, RULE_rawstorage = 97, 
		RULE_pid = 98, RULE_tid = 99, RULE_str = 100, RULE_strstorage = 101, RULE_cardatt = 102, 
		RULE_namegr = 103;
	private static String[] makeRuleNames() {
		return new String[] {
			"var", "vars", "varo", "varp", "vari", "varb", "varc", "varcs", "varcsc", 
			"varcard", "vart", "game", "declare", "setup", "scoring", "stage", "endcondition", 
			"multiaction", "multiaction2", "condact", "agg", "let", "action", "playercreate", 
			"teamcreate", "teams", "deckcreate", "deck", "attribute", "initpoints", 
			"updatepoints", "awards", "subaward", "cycleaction", "setaction", "setstraction", 
			"incaction", "decaction", "moveaction", "swapaction", "copyaction", "removeaction", 
			"shuffleaction", "turnaction", "repeat", "pointstorage", "card", "maxof", 
			"minof", "locpre", "locdesc", "who", "whop", "whot", "whodesc", "owner", 
			"teamp", "typed", "collection", "strcollection", "range", "other", "cstorage", 
			"basecstorage", "unionof", "intersectof", "disjunctionof", "filter", 
			"memstorage", "sequence", "runsequence", "cstoragecollection", "run", 
			"subset", "partition", "aggcs", "indexed", "boolean", "intop", "aggb", 
			"int", "intgr", "sum", "scoremax", "scoremin", "score", "add", "mult", 
			"subtract", "mod", "divide", "exponent", "triangular", "fibonacci", "random", 
			"sizeof", "aggi", "rawstorage", "pid", "tid", "str", "strstorage", "cardatt", 
			"namegr"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'''", "'game'", "'declare'", "'setup'", "'scoring'", "'min'", 
			"'max'", "'stage'", "'player'", "'team'", "'simultaneous'", "'once'", 
			"'end'", "'choice'", "'do'", "'any'", "'all'", "'let'", "'create'", "'players'", 
			"'teams'", "','", "'deck'", "'set'", "'update'", "':'", "'cycle'", "'next'", 
			"'current'", "'inc'", "'dec'", "'move'", "'swap'", "'remember'", "'forget'", 
			"'shuffle'", "'faro'", "'turn'", "'pass'", "'repeat'", "'points'", "'top'", 
			"'bottom'", "'using'", "'vloc'", "'iloc'", "'hloc'", "'oloc'", "'mem'", 
			"'previous'", "'owner'", "'range'", "'..'", "'other'", "'union'", "'intersect'", 
			"'disjunction'", "'filter'", "'run'", "'runs'", "'largest'", "'subsets'", 
			"'partition'", "'indexed'", "'sum'", "'scoremax'", "'scoremin'", "'score'", 
			"'+'", "'*'", "'-'", "'%'", "'//'", "'^'", "'tri'", "'fib'", "'random'", 
			"'size'", "'sto'", "'pid'", "'tid'", "'str'", "'cardatt'", null, null, 
			null, "'not'", null, null, "'('", "')'"
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
			setState(226);
			match(T__0);
			setState(227);
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
			setState(229);
			match(T__0);
			setState(230);
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
			setState(232);
			match(T__0);
			setState(233);
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
			setState(235);
			match(T__0);
			setState(236);
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
	public static class VartContext extends ParserRuleContext {
		public NamegrContext namegr() {
			return getRuleContext(NamegrContext.class,0);
		}
		public VartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_vart; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterVart(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitVart(this);
		}
	}

	public final VartContext vart() throws RecognitionException {
		VartContext _localctx = new VartContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_vart);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(238);
			match(T__0);
			setState(239);
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
		enterRule(_localctx, 22, RULE_game);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(241);
			match(OPEN);
			setState(242);
			match(T__1);
			setState(246);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(243);
					declare();
					}
					} 
				}
				setState(248);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(249);
			setup();
			setState(252); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(252);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
					case 1:
						{
						setState(250);
						multiaction();
						}
						break;
					case 2:
						{
						setState(251);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(254); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(256);
			scoring();
			setState(257);
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
			setState(259);
			match(OPEN);
			setState(260);
			match(T__2);
			setState(261);
			typed();
			setState(262);
			var();
			setState(263);
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
		enterRule(_localctx, 26, RULE_setup);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(265);
			match(OPEN);
			setState(266);
			match(T__3);
			setState(267);
			playercreate();
			setState(269);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(268);
				teamcreate();
				}
				break;
			}
			setState(278); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(271);
					match(OPEN);
					setState(274);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__18:
						{
						setState(272);
						deckcreate();
						}
						break;
					case T__39:
						{
						setState(273);
						repeat();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(276);
					match(CLOSE);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(280); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(282);
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
		enterRule(_localctx, 28, RULE_scoring);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(284);
			match(OPEN);
			setState(285);
			match(T__4);
			setState(286);
			_la = _input.LA(1);
			if ( !(_la==T__5 || _la==T__6) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(287);
			int_();
			setState(288);
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
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public EndconditionContext endcondition() {
			return getRuleContext(EndconditionContext.class,0);
		}
		public BooleanContext boolean_() {
			return getRuleContext(BooleanContext.class,0);
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
		enterRule(_localctx, 30, RULE_stage);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(290);
			match(OPEN);
			setState(291);
			match(T__7);
			setState(292);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(294);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				setState(293);
				boolean_();
				}
				break;
			}
			setState(299);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(296);
				endcondition();
				}
				break;
			case T__10:
				{
				setState(297);
				match(T__10);
				}
				break;
			case T__11:
				{
				setState(298);
				match(T__11);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(303); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					setState(303);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
					case 1:
						{
						setState(301);
						multiaction();
						}
						break;
					case 2:
						{
						setState(302);
						stage();
						}
						break;
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(305); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(307);
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
		enterRule(_localctx, 32, RULE_endcondition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(309);
			match(OPEN);
			setState(310);
			match(T__12);
			setState(311);
			boolean_();
			setState(312);
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
		enterRule(_localctx, 34, RULE_multiaction);
		try {
			int _alt;
			setState(338);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(314);
				match(OPEN);
				setState(315);
				match(T__13);
				setState(316);
				match(OPEN);
				setState(318); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(317);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(320); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(322);
				match(CLOSE);
				setState(323);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(325);
				match(OPEN);
				setState(326);
				match(T__14);
				setState(327);
				match(OPEN);
				setState(329); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(328);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(331); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(333);
				match(CLOSE);
				setState(334);
				match(CLOSE);
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(336);
				agg();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(337);
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
		enterRule(_localctx, 36, RULE_multiaction2);
		try {
			int _alt;
			setState(353);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(340);
				match(OPEN);
				setState(341);
				match(T__14);
				setState(342);
				match(OPEN);
				setState(344); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(343);
						condact();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(346); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				setState(348);
				match(CLOSE);
				setState(349);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(351);
				agg();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(352);
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
		enterRule(_localctx, 38, RULE_condact);
		try {
			setState(367);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(355);
				match(OPEN);
				setState(356);
				boolean_();
				setState(357);
				multiaction2();
				setState(358);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(360);
				multiaction2();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(361);
				match(OPEN);
				setState(362);
				boolean_();
				setState(363);
				action();
				setState(364);
				match(CLOSE);
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(366);
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
		enterRule(_localctx, 40, RULE_agg);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(369);
			match(OPEN);
			setState(370);
			_la = _input.LA(1);
			if ( !(_la==T__15 || _la==T__16) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(371);
			collection();
			setState(372);
			var();
			setState(373);
			condact();
			setState(374);
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
		enterRule(_localctx, 42, RULE_let);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(376);
			match(OPEN);
			setState(377);
			match(T__17);
			setState(378);
			typed();
			setState(379);
			var();
			setState(383);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(380);
				multiaction();
				}
				break;
			case 2:
				{
				setState(381);
				action();
				}
				break;
			case 3:
				{
				setState(382);
				condact();
				}
				break;
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
		public SwapactionContext swapaction() {
			return getRuleContext(SwapactionContext.class,0);
		}
		public UpdatepointsContext updatepoints() {
			return getRuleContext(UpdatepointsContext.class,0);
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
		enterRule(_localctx, 44, RULE_action);
		try {
			setState(409);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(387);
				match(OPEN);
				setState(404);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
				case 1:
					{
					setState(388);
					initpoints();
					}
					break;
				case 2:
					{
					setState(389);
					teamcreate();
					}
					break;
				case 3:
					{
					setState(390);
					deckcreate();
					}
					break;
				case 4:
					{
					setState(391);
					cycleaction();
					}
					break;
				case 5:
					{
					setState(392);
					setaction();
					}
					break;
				case 6:
					{
					setState(393);
					moveaction();
					}
					break;
				case 7:
					{
					setState(394);
					copyaction();
					}
					break;
				case 8:
					{
					setState(395);
					swapaction();
					}
					break;
				case 9:
					{
					setState(396);
					updatepoints();
					}
					break;
				case 10:
					{
					setState(397);
					incaction();
					}
					break;
				case 11:
					{
					setState(398);
					setstraction();
					}
					break;
				case 12:
					{
					setState(399);
					decaction();
					}
					break;
				case 13:
					{
					setState(400);
					removeaction();
					}
					break;
				case 14:
					{
					setState(401);
					turnaction();
					}
					break;
				case 15:
					{
					setState(402);
					shuffleaction();
					}
					break;
				case 16:
					{
					setState(403);
					repeat();
					}
					break;
				}
				setState(406);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(408);
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
		enterRule(_localctx, 46, RULE_playercreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(411);
			match(OPEN);
			setState(412);
			match(T__18);
			setState(413);
			match(T__19);
			setState(414);
			int_();
			setState(415);
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
		enterRule(_localctx, 48, RULE_teamcreate);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(417);
			match(OPEN);
			setState(418);
			match(T__18);
			setState(419);
			match(T__20);
			setState(421); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(420);
					teams();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(423); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(425);
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
		enterRule(_localctx, 50, RULE_teams);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(427);
			match(OPEN);
			setState(432);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(428);
					match(INTNUM);
					setState(429);
					match(T__21);
					}
					} 
				}
				setState(434);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			}
			setState(435);
			match(INTNUM);
			setState(439);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(436);
					teams();
					}
					} 
				}
				setState(441);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
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
		enterRule(_localctx, 52, RULE_deckcreate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(444);
			match(T__18);
			setState(445);
			match(T__22);
			setState(447);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
			case 1:
				{
				setState(446);
				str();
				}
				break;
			}
			setState(449);
			cstorage();
			setState(450);
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
		enterRule(_localctx, 54, RULE_deck);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(452);
			match(OPEN);
			setState(453);
			match(T__22);
			setState(455); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(454);
					attribute();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(457); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,23,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(459);
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
		enterRule(_localctx, 56, RULE_attribute);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(461);
			match(OPEN);
			setState(467);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(462);
					namegr();
					setState(463);
					match(T__21);
					}
					} 
				}
				setState(469);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			}
			setState(470);
			namegr();
			setState(474);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(471);
					attribute();
					}
					} 
				}
				setState(476);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,25,_ctx);
			}
			setState(477);
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
		enterRule(_localctx, 58, RULE_initpoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(479);
			match(T__23);
			setState(480);
			pointstorage();
			setState(481);
			match(OPEN);
			setState(483); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(482);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(485); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,26,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(487);
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
	public static class UpdatepointsContext extends ParserRuleContext {
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
		public UpdatepointsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_updatepoints; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterUpdatepoints(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitUpdatepoints(this);
		}
	}

	public final UpdatepointsContext updatepoints() throws RecognitionException {
		UpdatepointsContext _localctx = new UpdatepointsContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_updatepoints);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(489);
			match(T__24);
			setState(490);
			pointstorage();
			setState(491);
			match(OPEN);
			setState(493); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(492);
					awards();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(495); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(497);
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
		enterRule(_localctx, 62, RULE_awards);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(499);
			match(OPEN);
			setState(501); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(500);
					subaward();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(503); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(505);
			int_();
			setState(506);
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
		enterRule(_localctx, 64, RULE_subaward);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(508);
			match(OPEN);
			setState(509);
			str();
			setState(510);
			match(T__25);
			setState(511);
			str();
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

	@SuppressWarnings("CheckReturnValue")
	public static class CycleactionContext extends ParserRuleContext {
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public VarpContext varp() {
			return getRuleContext(VarpContext.class,0);
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
		enterRule(_localctx, 66, RULE_cycleaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(514);
			match(T__26);
			setState(515);
			_la = _input.LA(1);
			if ( !(_la==T__27 || _la==T__28) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(518);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OPEN:
				{
				setState(516);
				whop();
				}
				break;
			case T__0:
				{
				setState(517);
				varp();
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
		enterRule(_localctx, 68, RULE_setaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(520);
			match(T__23);
			setState(521);
			rawstorage();
			setState(522);
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
		enterRule(_localctx, 70, RULE_setstraction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(524);
			match(T__23);
			setState(525);
			strstorage();
			setState(526);
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
		enterRule(_localctx, 72, RULE_incaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(528);
			match(T__29);
			setState(529);
			rawstorage();
			setState(531);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__0 || _la==INTNUM || _la==OPEN) {
				{
				setState(530);
				int_();
				}
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
		enterRule(_localctx, 74, RULE_decaction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(533);
			match(T__30);
			setState(534);
			rawstorage();
			setState(536);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__0 || _la==INTNUM || _la==OPEN) {
				{
				setState(535);
				int_();
				}
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
		enterRule(_localctx, 76, RULE_moveaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(538);
			match(T__31);
			setState(539);
			card();
			setState(540);
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
	public static class SwapactionContext extends ParserRuleContext {
		public List<CardContext> card() {
			return getRuleContexts(CardContext.class);
		}
		public CardContext card(int i) {
			return getRuleContext(CardContext.class,i);
		}
		public List<BasecstorageContext> basecstorage() {
			return getRuleContexts(BasecstorageContext.class);
		}
		public BasecstorageContext basecstorage(int i) {
			return getRuleContext(BasecstorageContext.class,i);
		}
		public SwapactionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_swapaction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterSwapaction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitSwapaction(this);
		}
	}

	public final SwapactionContext swapaction() throws RecognitionException {
		SwapactionContext _localctx = new SwapactionContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_swapaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(542);
			match(T__32);
			setState(549);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				{
				{
				setState(543);
				card();
				setState(544);
				card();
				}
				}
				break;
			case 2:
				{
				{
				setState(546);
				basecstorage();
				setState(547);
				basecstorage();
				}
				}
				break;
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
		enterRule(_localctx, 80, RULE_copyaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(551);
			match(T__33);
			setState(552);
			card();
			setState(553);
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
		enterRule(_localctx, 82, RULE_removeaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(555);
			match(T__34);
			setState(556);
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
		enterRule(_localctx, 84, RULE_shuffleaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(558);
			match(T__35);
			setState(564);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case OPEN:
				{
				setState(559);
				cstorage();
				}
				break;
			case T__36:
				{
				setState(560);
				match(T__36);
				setState(561);
				cstorage();
				setState(562);
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
		enterRule(_localctx, 86, RULE_turnaction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(566);
			match(T__37);
			setState(567);
			match(T__38);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
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
		enterRule(_localctx, 88, RULE_repeat);
		try {
			setState(582);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(569);
				match(T__39);
				setState(570);
				int_();
				setState(571);
				action();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(573);
				match(T__39);
				setState(574);
				match(T__16);
				setState(575);
				match(OPEN);
				setState(578);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case T__31:
					{
					setState(576);
					moveaction();
					}
					break;
				case T__34:
					{
					setState(577);
					removeaction();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(580);
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
		enterRule(_localctx, 90, RULE_pointstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(584);
			match(OPEN);
			setState(588);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(585);
				varo();
				}
				break;
			case T__1:
				{
				setState(586);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(587);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(590);
			match(T__40);
			setState(591);
			str();
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
		enterRule(_localctx, 92, RULE_card);
		try {
			setState(606);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,38,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(594);
				varcard();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(595);
				maxof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(596);
				minof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(597);
				match(OPEN);
				setState(601);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
				case 1:
					{
					setState(598);
					match(T__41);
					}
					break;
				case 2:
					{
					setState(599);
					match(T__42);
					}
					break;
				case 3:
					{
					setState(600);
					int_();
					}
					break;
				}
				setState(603);
				cstorage();
				setState(604);
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
		enterRule(_localctx, 94, RULE_maxof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(608);
			match(OPEN);
			setState(609);
			match(T__6);
			setState(610);
			cstorage();
			setState(611);
			match(T__43);
			setState(612);
			pointstorage();
			setState(613);
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
		enterRule(_localctx, 96, RULE_minof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(615);
			match(OPEN);
			setState(616);
			match(T__5);
			setState(617);
			cstorage();
			setState(618);
			match(T__43);
			setState(619);
			pointstorage();
			setState(620);
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
		public WhotContext whot() {
			return getRuleContext(WhotContext.class,0);
		}
		public VaroContext varo() {
			return getRuleContext(VaroContext.class,0);
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
		enterRule(_localctx, 98, RULE_locpre);
		try {
			setState(626);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(622);
				match(T__1);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(623);
				whot();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(624);
				varo();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(625);
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
		enterRule(_localctx, 100, RULE_locdesc);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(628);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1090715534753792L) != 0)) ) {
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
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public WhotContext whot() {
			return getRuleContext(WhotContext.class,0);
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
		enterRule(_localctx, 102, RULE_who);
		try {
			setState(632);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(630);
				whop();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(631);
				whot();
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
		enterRule(_localctx, 104, RULE_whop);
		try {
			setState(640);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(634);
				match(OPEN);
				setState(635);
				whodesc();
				setState(636);
				match(T__8);
				setState(637);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(639);
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
		enterRule(_localctx, 106, RULE_whot);
		try {
			setState(648);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,42,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(642);
				match(OPEN);
				setState(643);
				whodesc();
				setState(644);
				match(T__9);
				setState(645);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(647);
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
		enterRule(_localctx, 108, RULE_whodesc);
		try {
			setState(654);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case INTNUM:
			case OPEN:
				enterOuterAlt(_localctx, 1);
				{
				setState(650);
				int_();
				}
				break;
			case T__49:
				enterOuterAlt(_localctx, 2);
				{
				setState(651);
				match(T__49);
				}
				break;
			case T__27:
				enterOuterAlt(_localctx, 3);
				{
				setState(652);
				match(T__27);
				}
				break;
			case T__28:
				enterOuterAlt(_localctx, 4);
				{
				setState(653);
				match(T__28);
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
		enterRule(_localctx, 110, RULE_owner);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(656);
			match(OPEN);
			setState(657);
			match(T__50);
			setState(658);
			card();
			setState(659);
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
		enterRule(_localctx, 112, RULE_teamp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(661);
			match(OPEN);
			setState(662);
			match(T__9);
			setState(665);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(663);
				varp();
				}
				break;
			case OPEN:
				{
				setState(664);
				whop();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
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
		enterRule(_localctx, 114, RULE_typed);
		try {
			setState(673);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,45,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(669);
				int_();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(670);
				boolean_();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(671);
				str();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(672);
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
		enterRule(_localctx, 116, RULE_collection);
		try {
			setState(685);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,46,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(675);
				varc();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(676);
				filter();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(677);
				cstorage();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(678);
				strcollection();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(679);
				cstoragecollection();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(680);
				match(T__8);
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(681);
				match(T__9);
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(682);
				whot();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(683);
				other();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(684);
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
		enterRule(_localctx, 118, RULE_strcollection);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(687);
			match(OPEN);
			setState(693);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,47,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					{
					setState(688);
					namegr();
					setState(689);
					match(T__21);
					}
					} 
				}
				setState(695);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,47,_ctx);
			}
			setState(696);
			namegr();
			setState(697);
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
		enterRule(_localctx, 120, RULE_range);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(699);
			match(OPEN);
			setState(700);
			match(T__51);
			setState(701);
			int_();
			setState(702);
			match(T__52);
			setState(703);
			int_();
			setState(704);
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
		enterRule(_localctx, 122, RULE_other);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(706);
			match(OPEN);
			setState(707);
			match(T__53);
			setState(708);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(709);
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
		public FilterContext filter() {
			return getRuleContext(FilterContext.class,0);
		}
		public BasecstorageContext basecstorage() {
			return getRuleContext(BasecstorageContext.class,0);
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
		enterRule(_localctx, 124, RULE_cstorage);
		try {
			setState(720);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(711);
				varcs();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(712);
				unionof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(713);
				intersectof();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(714);
				disjunctionof();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(715);
				filter();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(716);
				basecstorage();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(717);
				memstorage();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(718);
				sequence();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(719);
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
	public static class BasecstorageContext extends ParserRuleContext {
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
		public List<IntContext> int_() {
			return getRuleContexts(IntContext.class);
		}
		public IntContext int_(int i) {
			return getRuleContext(IntContext.class,i);
		}
		public BasecstorageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_basecstorage; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterBasecstorage(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitBasecstorage(this);
		}
	}

	public final BasecstorageContext basecstorage() throws RecognitionException {
		BasecstorageContext _localctx = new BasecstorageContext(_ctx, getState());
		enterRule(_localctx, 126, RULE_basecstorage);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(722);
			match(OPEN);
			setState(723);
			locpre();
			setState(724);
			locdesc();
			setState(725);
			str();
			setState(730);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__0 || _la==INTNUM || _la==OPEN) {
				{
				setState(726);
				int_();
				setState(728);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__0 || _la==INTNUM || _la==OPEN) {
					{
					setState(727);
					int_();
					}
				}

				}
			}

			setState(732);
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
		enterRule(_localctx, 128, RULE_unionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(734);
			match(OPEN);
			setState(735);
			match(T__54);
			setState(742);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,52,_ctx) ) {
			case 1:
				{
				setState(736);
				aggcs();
				}
				break;
			case 2:
				{
				setState(738); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(737);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(740); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,51,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
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
		enterRule(_localctx, 130, RULE_intersectof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(746);
			match(OPEN);
			setState(747);
			match(T__55);
			setState(754);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
			case 1:
				{
				setState(748);
				aggcs();
				}
				break;
			case 2:
				{
				setState(750); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(749);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(752); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,53,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
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
		enterRule(_localctx, 132, RULE_disjunctionof);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(758);
			match(OPEN);
			setState(759);
			match(T__56);
			setState(766);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,56,_ctx) ) {
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
					_alt = getInterpreter().adaptivePredict(_input,55,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
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
		enterRule(_localctx, 134, RULE_filter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(770);
			match(OPEN);
			setState(771);
			match(T__57);
			setState(772);
			collection();
			setState(773);
			var();
			setState(774);
			boolean_();
			setState(775);
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
		enterRule(_localctx, 136, RULE_memstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(777);
			match(OPEN);
			setState(781);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__41:
				{
				setState(778);
				match(T__41);
				}
				break;
			case T__42:
				{
				setState(779);
				match(T__42);
				}
				break;
			case T__0:
			case INTNUM:
			case OPEN:
				{
				setState(780);
				int_();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(783);
			cstoragecollection();
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
		enterRule(_localctx, 138, RULE_sequence);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(786);
			match(OPEN);
			setState(787);
			_la = _input.LA(1);
			if ( !(_la==T__41 || _la==T__42) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(788);
			int_();
			setState(789);
			cstorage();
			setState(790);
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
		enterRule(_localctx, 140, RULE_runsequence);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(792);
			match(OPEN);
			setState(793);
			match(T__58);
			setState(794);
			_la = _input.LA(1);
			if ( !(_la==T__41 || _la==T__42) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(795);
			int_();
			setState(796);
			cstorage();
			setState(797);
			match(T__43);
			setState(798);
			pointstorage();
			setState(799);
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
		enterRule(_localctx, 142, RULE_cstoragecollection);
		try {
			setState(807);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,58,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(801);
				partition();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(802);
				subset();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(803);
				run();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(804);
				aggcs();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(805);
				varcsc();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(806);
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
		enterRule(_localctx, 144, RULE_run);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(809);
			match(OPEN);
			setState(810);
			match(T__59);
			setState(811);
			_la = _input.LA(1);
			if ( !(_la==T__16 || _la==T__60) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(812);
			int_();
			setState(813);
			cstorage();
			setState(814);
			match(T__43);
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

	@SuppressWarnings("CheckReturnValue")
	public static class SubsetContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public IntopContext intop() {
			return getRuleContext(IntopContext.class,0);
		}
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
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
		enterRule(_localctx, 146, RULE_subset);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(818);
			match(OPEN);
			setState(819);
			match(T__61);
			setState(820);
			cstorage();
			setState(824);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COMPOP || _la==EQOP) {
				{
				setState(821);
				intop();
				setState(822);
				int_();
				}
			}

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
		enterRule(_localctx, 148, RULE_partition);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(828);
			match(OPEN);
			setState(829);
			match(T__62);
			setState(830);
			str();
			setState(837);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,61,_ctx) ) {
			case 1:
				{
				setState(831);
				aggcs();
				}
				break;
			case 2:
				{
				setState(833); 
				_errHandler.sync(this);
				_alt = 1+1;
				do {
					switch (_alt) {
					case 1+1:
						{
						{
						setState(832);
						cstorage();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(835); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,60,_ctx);
				} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			setState(839);
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
		enterRule(_localctx, 150, RULE_aggcs);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(841);
			match(OPEN);
			setState(842);
			match(T__16);
			setState(843);
			collection();
			setState(844);
			var();
			setState(845);
			cstorage();
			setState(846);
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
		enterRule(_localctx, 152, RULE_indexed);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(848);
			match(OPEN);
			setState(849);
			match(T__63);
			setState(850);
			locpre();
			setState(851);
			locdesc();
			setState(852);
			str();
			setState(853);
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
		enterRule(_localctx, 154, RULE_boolean);
		try {
			int _alt;
			setState(890);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,64,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(855);
				match(OPEN);
				setState(885);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,63,_ctx) ) {
				case 1:
					{
					setState(856);
					match(BOOLOP);
					setState(857);
					boolean_();
					setState(859); 
					_errHandler.sync(this);
					_alt = 1+1;
					do {
						switch (_alt) {
						case 1+1:
							{
							{
							setState(858);
							boolean_();
							}
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						setState(861); 
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,62,_ctx);
					} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
					}
					break;
				case 2:
					{
					setState(863);
					intop();
					setState(864);
					int_();
					setState(865);
					int_();
					}
					break;
				case 3:
					{
					setState(867);
					match(EQOP);
					setState(868);
					str();
					setState(869);
					str();
					}
					break;
				case 4:
					{
					setState(871);
					match(EQOP);
					setState(872);
					card();
					setState(873);
					card();
					}
					break;
				case 5:
					{
					setState(875);
					match(UNOP);
					setState(876);
					boolean_();
					}
					break;
				case 6:
					{
					setState(877);
					match(EQOP);
					setState(878);
					whop();
					setState(879);
					whop();
					}
					break;
				case 7:
					{
					setState(881);
					match(EQOP);
					setState(882);
					whot();
					setState(883);
					whot();
					}
					break;
				}
				setState(887);
				match(CLOSE);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(889);
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
		enterRule(_localctx, 156, RULE_intop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(892);
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
		enterRule(_localctx, 158, RULE_aggb);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(894);
			match(OPEN);
			setState(895);
			_la = _input.LA(1);
			if ( !(_la==T__15 || _la==T__16) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(896);
			collection();
			setState(897);
			var();
			setState(898);
			boolean_();
			setState(899);
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
		public PidContext pid() {
			return getRuleContext(PidContext.class,0);
		}
		public TidContext tid() {
			return getRuleContext(TidContext.class,0);
		}
		public AggiContext aggi() {
			return getRuleContext(AggiContext.class,0);
		}
		public ScoremaxContext scoremax() {
			return getRuleContext(ScoremaxContext.class,0);
		}
		public ScoreminContext scoremin() {
			return getRuleContext(ScoreminContext.class,0);
		}
		public IntgrContext intgr() {
			return getRuleContext(IntgrContext.class,0);
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
		enterRule(_localctx, 160, RULE_int);
		try {
			setState(921);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,65,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(901);
				vari();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(902);
				sizeof();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(903);
				mult();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(904);
				subtract();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(905);
				mod();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(906);
				add();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(907);
				divide();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(908);
				exponent();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(909);
				triangular();
				}
				break;
			case 10:
				enterOuterAlt(_localctx, 10);
				{
				setState(910);
				fibonacci();
				}
				break;
			case 11:
				enterOuterAlt(_localctx, 11);
				{
				setState(911);
				random();
				}
				break;
			case 12:
				enterOuterAlt(_localctx, 12);
				{
				setState(912);
				sum();
				}
				break;
			case 13:
				enterOuterAlt(_localctx, 13);
				{
				setState(913);
				rawstorage();
				}
				break;
			case 14:
				enterOuterAlt(_localctx, 14);
				{
				setState(914);
				score();
				}
				break;
			case 15:
				enterOuterAlt(_localctx, 15);
				{
				setState(915);
				pid();
				}
				break;
			case 16:
				enterOuterAlt(_localctx, 16);
				{
				setState(916);
				tid();
				}
				break;
			case 17:
				enterOuterAlt(_localctx, 17);
				{
				setState(917);
				aggi();
				}
				break;
			case 18:
				enterOuterAlt(_localctx, 18);
				{
				setState(918);
				scoremax();
				}
				break;
			case 19:
				enterOuterAlt(_localctx, 19);
				{
				setState(919);
				scoremin();
				}
				break;
			case 20:
				enterOuterAlt(_localctx, 20);
				{
				setState(920);
				intgr();
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
	public static class IntgrContext extends ParserRuleContext {
		public List<TerminalNode> INTNUM() { return getTokens(RecycleParser.INTNUM); }
		public TerminalNode INTNUM(int i) {
			return getToken(RecycleParser.INTNUM, i);
		}
		public IntgrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intgr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterIntgr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitIntgr(this);
		}
	}

	public final IntgrContext intgr() throws RecognitionException {
		IntgrContext _localctx = new IntgrContext(_ctx, getState());
		enterRule(_localctx, 162, RULE_intgr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(924); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(923);
					match(INTNUM);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(926); 
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
		enterRule(_localctx, 164, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(928);
			match(OPEN);
			setState(929);
			match(T__64);
			setState(930);
			cstorage();
			setState(931);
			match(T__43);
			setState(932);
			pointstorage();
			setState(933);
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
	public static class ScoremaxContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ScoremaxContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scoremax; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterScoremax(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitScoremax(this);
		}
	}

	public final ScoremaxContext scoremax() throws RecognitionException {
		ScoremaxContext _localctx = new ScoremaxContext(_ctx, getState());
		enterRule(_localctx, 166, RULE_scoremax);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(935);
			match(OPEN);
			setState(936);
			match(T__65);
			setState(937);
			cstorage();
			setState(938);
			match(T__43);
			setState(939);
			pointstorage();
			setState(940);
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
	public static class ScoreminContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public CstorageContext cstorage() {
			return getRuleContext(CstorageContext.class,0);
		}
		public PointstorageContext pointstorage() {
			return getRuleContext(PointstorageContext.class,0);
		}
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public ScoreminContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scoremin; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterScoremin(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitScoremin(this);
		}
	}

	public final ScoreminContext scoremin() throws RecognitionException {
		ScoreminContext _localctx = new ScoreminContext(_ctx, getState());
		enterRule(_localctx, 168, RULE_scoremin);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(942);
			match(OPEN);
			setState(943);
			match(T__66);
			setState(944);
			cstorage();
			setState(945);
			match(T__43);
			setState(946);
			pointstorage();
			setState(947);
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
		enterRule(_localctx, 170, RULE_score);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(949);
			match(OPEN);
			setState(950);
			match(T__67);
			setState(951);
			card();
			setState(952);
			match(T__43);
			setState(953);
			pointstorage();
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
		enterRule(_localctx, 172, RULE_add);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(956);
			match(OPEN);
			setState(957);
			match(T__68);
			setState(958);
			int_();
			setState(960); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(959);
					int_();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(962); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,67,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(964);
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
		enterRule(_localctx, 174, RULE_mult);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(966);
			match(OPEN);
			setState(967);
			match(T__69);
			setState(968);
			int_();
			setState(970); 
			_errHandler.sync(this);
			_alt = 1+1;
			do {
				switch (_alt) {
				case 1+1:
					{
					{
					setState(969);
					int_();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(972); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,68,_ctx);
			} while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			setState(974);
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
		enterRule(_localctx, 176, RULE_subtract);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(976);
			match(OPEN);
			setState(977);
			match(T__70);
			setState(978);
			int_();
			setState(979);
			int_();
			setState(980);
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
		enterRule(_localctx, 178, RULE_mod);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(982);
			match(OPEN);
			setState(983);
			match(T__71);
			setState(984);
			int_();
			setState(985);
			int_();
			setState(986);
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
		enterRule(_localctx, 180, RULE_divide);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(988);
			match(OPEN);
			setState(989);
			match(T__72);
			setState(990);
			int_();
			setState(991);
			int_();
			setState(992);
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
		enterRule(_localctx, 182, RULE_exponent);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(994);
			match(OPEN);
			setState(995);
			match(T__73);
			setState(996);
			int_();
			setState(997);
			int_();
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
		enterRule(_localctx, 184, RULE_triangular);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1000);
			match(OPEN);
			setState(1001);
			match(T__74);
			setState(1002);
			int_();
			setState(1003);
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
		enterRule(_localctx, 186, RULE_fibonacci);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1005);
			match(OPEN);
			setState(1006);
			match(T__75);
			setState(1007);
			int_();
			setState(1008);
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
		enterRule(_localctx, 188, RULE_random);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1010);
			match(OPEN);
			setState(1011);
			match(T__76);
			setState(1012);
			int_();
			setState(1015);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__52) {
				{
				setState(1013);
				match(T__52);
				setState(1014);
				int_();
				}
			}

			setState(1017);
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
		enterRule(_localctx, 190, RULE_sizeof);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1019);
			match(OPEN);
			setState(1020);
			match(T__77);
			setState(1021);
			collection();
			setState(1022);
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
		enterRule(_localctx, 192, RULE_aggi);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1024);
			match(OPEN);
			setState(1025);
			match(T__16);
			setState(1026);
			collection();
			setState(1027);
			var();
			setState(1028);
			rawstorage();
			setState(1029);
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
		enterRule(_localctx, 194, RULE_rawstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1031);
			match(OPEN);
			setState(1035);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(1032);
				varo();
				}
				break;
			case T__1:
				{
				setState(1033);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(1034);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1037);
			match(T__78);
			setState(1038);
			str();
			setState(1039);
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
	public static class PidContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VarpContext varp() {
			return getRuleContext(VarpContext.class,0);
		}
		public WhopContext whop() {
			return getRuleContext(WhopContext.class,0);
		}
		public PidContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pid; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterPid(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitPid(this);
		}
	}

	public final PidContext pid() throws RecognitionException {
		PidContext _localctx = new PidContext(_ctx, getState());
		enterRule(_localctx, 196, RULE_pid);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1041);
			match(OPEN);
			setState(1042);
			match(T__79);
			setState(1045);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(1043);
				varp();
				}
				break;
			case OPEN:
				{
				setState(1044);
				whop();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1047);
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
	public static class TidContext extends ParserRuleContext {
		public TerminalNode OPEN() { return getToken(RecycleParser.OPEN, 0); }
		public TerminalNode CLOSE() { return getToken(RecycleParser.CLOSE, 0); }
		public VartContext vart() {
			return getRuleContext(VartContext.class,0);
		}
		public WhotContext whot() {
			return getRuleContext(WhotContext.class,0);
		}
		public TidContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_tid; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).enterTid(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof RecycleListener ) ((RecycleListener)listener).exitTid(this);
		}
	}

	public final TidContext tid() throws RecognitionException {
		TidContext _localctx = new TidContext(_ctx, getState());
		enterRule(_localctx, 198, RULE_tid);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1049);
			match(OPEN);
			setState(1050);
			match(T__80);
			setState(1053);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(1051);
				vart();
				}
				break;
			case OPEN:
				{
				setState(1052);
				whot();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1055);
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
		enterRule(_localctx, 200, RULE_str);
		try {
			setState(1061);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,73,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(1057);
				namegr();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(1058);
				strstorage();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(1059);
				vars();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(1060);
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
		enterRule(_localctx, 202, RULE_strstorage);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1063);
			match(OPEN);
			setState(1067);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				{
				setState(1064);
				varo();
				}
				break;
			case T__1:
				{
				setState(1065);
				match(T__1);
				}
				break;
			case OPEN:
				{
				setState(1066);
				who();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(1069);
			match(T__81);
			setState(1070);
			str();
			setState(1071);
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
		enterRule(_localctx, 204, RULE_cardatt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(1073);
			match(OPEN);
			setState(1074);
			match(T__82);
			setState(1075);
			str();
			setState(1076);
			card();
			setState(1077);
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
		enterRule(_localctx, 206, RULE_namegr);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(1080); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(1079);
					match(LETT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(1082); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,75,_ctx);
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
		"\u0004\u0001]\u043d\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
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
		"_\u0007_\u0002`\u0007`\u0002a\u0007a\u0002b\u0007b\u0002c\u0007c\u0002"+
		"d\u0007d\u0002e\u0007e\u0002f\u0007f\u0002g\u0007g\u0001\u0000\u0001\u0000"+
		"\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0004\u0001\u0004"+
		"\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001"+
		"\b\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b"+
		"\u0001\u000b\u0005\u000b\u00f5\b\u000b\n\u000b\f\u000b\u00f8\t\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0004\u000b\u00fd\b\u000b\u000b\u000b\f"+
		"\u000b\u00fe\u0001\u000b\u0001\u000b\u0001\u000b\u0001\f\u0001\f\u0001"+
		"\f\u0001\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\r\u0003\r\u010e"+
		"\b\r\u0001\r\u0001\r\u0001\r\u0003\r\u0113\b\r\u0001\r\u0001\r\u0004\r"+
		"\u0117\b\r\u000b\r\f\r\u0118\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001"+
		"\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0003\u000f\u0127\b\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0003\u000f\u012c\b\u000f\u0001\u000f\u0001\u000f\u0004\u000f\u0130"+
		"\b\u000f\u000b\u000f\f\u000f\u0131\u0001\u000f\u0001\u000f\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011"+
		"\u0001\u0011\u0001\u0011\u0004\u0011\u013f\b\u0011\u000b\u0011\f\u0011"+
		"\u0140\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0004\u0011\u014a\b\u0011\u000b\u0011\f\u0011\u014b"+
		"\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0001\u0011\u0003\u0011"+
		"\u0153\b\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0004\u0012"+
		"\u0159\b\u0012\u000b\u0012\f\u0012\u015a\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0003\u0012\u0162\b\u0012\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u0170"+
		"\b\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0015\u0001\u0015\u0003\u0015\u0180\b\u0015\u0001\u0015\u0001"+
		"\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0003"+
		"\u0016\u0195\b\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0003\u0016\u019a"+
		"\b\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017\u0001"+
		"\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0004\u0018\u01a6"+
		"\b\u0018\u000b\u0018\f\u0018\u01a7\u0001\u0018\u0001\u0018\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0005\u0019\u01af\b\u0019\n\u0019\f\u0019\u01b2"+
		"\t\u0019\u0001\u0019\u0001\u0019\u0005\u0019\u01b6\b\u0019\n\u0019\f\u0019"+
		"\u01b9\t\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001a"+
		"\u0003\u001a\u01c0\b\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001b"+
		"\u0001\u001b\u0001\u001b\u0004\u001b\u01c8\b\u001b\u000b\u001b\f\u001b"+
		"\u01c9\u0001\u001b\u0001\u001b\u0001\u001c\u0001\u001c\u0001\u001c\u0001"+
		"\u001c\u0005\u001c\u01d2\b\u001c\n\u001c\f\u001c\u01d5\t\u001c\u0001\u001c"+
		"\u0001\u001c\u0005\u001c\u01d9\b\u001c\n\u001c\f\u001c\u01dc\t\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0004"+
		"\u001d\u01e4\b\u001d\u000b\u001d\f\u001d\u01e5\u0001\u001d\u0001\u001d"+
		"\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0004\u001e\u01ee\b\u001e"+
		"\u000b\u001e\f\u001e\u01ef\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f"+
		"\u0004\u001f\u01f6\b\u001f\u000b\u001f\f\u001f\u01f7\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001 \u0001 \u0001 \u0001 \u0001 \u0001 \u0001!\u0001"+
		"!\u0001!\u0001!\u0003!\u0207\b!\u0001\"\u0001\"\u0001\"\u0001\"\u0001"+
		"#\u0001#\u0001#\u0001#\u0001$\u0001$\u0001$\u0003$\u0214\b$\u0001%\u0001"+
		"%\u0001%\u0003%\u0219\b%\u0001&\u0001&\u0001&\u0001&\u0001\'\u0001\'\u0001"+
		"\'\u0001\'\u0001\'\u0001\'\u0001\'\u0003\'\u0226\b\'\u0001(\u0001(\u0001"+
		"(\u0001(\u0001)\u0001)\u0001)\u0001*\u0001*\u0001*\u0001*\u0001*\u0001"+
		"*\u0003*\u0235\b*\u0001+\u0001+\u0001+\u0001,\u0001,\u0001,\u0001,\u0001"+
		",\u0001,\u0001,\u0001,\u0001,\u0003,\u0243\b,\u0001,\u0001,\u0003,\u0247"+
		"\b,\u0001-\u0001-\u0001-\u0001-\u0003-\u024d\b-\u0001-\u0001-\u0001-\u0001"+
		"-\u0001.\u0001.\u0001.\u0001.\u0001.\u0001.\u0001.\u0003.\u025a\b.\u0001"+
		".\u0001.\u0001.\u0003.\u025f\b.\u0001/\u0001/\u0001/\u0001/\u0001/\u0001"+
		"/\u0001/\u00010\u00010\u00010\u00010\u00010\u00010\u00010\u00011\u0001"+
		"1\u00011\u00011\u00031\u0273\b1\u00012\u00012\u00013\u00013\u00033\u0279"+
		"\b3\u00014\u00014\u00014\u00014\u00014\u00014\u00034\u0281\b4\u00015\u0001"+
		"5\u00015\u00015\u00015\u00015\u00035\u0289\b5\u00016\u00016\u00016\u0001"+
		"6\u00036\u028f\b6\u00017\u00017\u00017\u00017\u00017\u00018\u00018\u0001"+
		"8\u00018\u00038\u029a\b8\u00018\u00018\u00019\u00019\u00019\u00019\u0003"+
		"9\u02a2\b9\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001:\u0001"+
		":\u0001:\u0003:\u02ae\b:\u0001;\u0001;\u0001;\u0001;\u0005;\u02b4\b;\n"+
		";\f;\u02b7\t;\u0001;\u0001;\u0001;\u0001<\u0001<\u0001<\u0001<\u0001<"+
		"\u0001<\u0001<\u0001=\u0001=\u0001=\u0001=\u0001=\u0001>\u0001>\u0001"+
		">\u0001>\u0001>\u0001>\u0001>\u0001>\u0001>\u0003>\u02d1\b>\u0001?\u0001"+
		"?\u0001?\u0001?\u0001?\u0001?\u0003?\u02d9\b?\u0003?\u02db\b?\u0001?\u0001"+
		"?\u0001@\u0001@\u0001@\u0001@\u0004@\u02e3\b@\u000b@\f@\u02e4\u0003@\u02e7"+
		"\b@\u0001@\u0001@\u0001A\u0001A\u0001A\u0001A\u0004A\u02ef\bA\u000bA\f"+
		"A\u02f0\u0003A\u02f3\bA\u0001A\u0001A\u0001B\u0001B\u0001B\u0001B\u0004"+
		"B\u02fb\bB\u000bB\fB\u02fc\u0003B\u02ff\bB\u0001B\u0001B\u0001C\u0001"+
		"C\u0001C\u0001C\u0001C\u0001C\u0001C\u0001D\u0001D\u0001D\u0001D\u0003"+
		"D\u030e\bD\u0001D\u0001D\u0001D\u0001E\u0001E\u0001E\u0001E\u0001E\u0001"+
		"E\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001F\u0001"+
		"G\u0001G\u0001G\u0001G\u0001G\u0001G\u0003G\u0328\bG\u0001H\u0001H\u0001"+
		"H\u0001H\u0001H\u0001H\u0001H\u0001H\u0001H\u0001I\u0001I\u0001I\u0001"+
		"I\u0001I\u0001I\u0003I\u0339\bI\u0001I\u0001I\u0001J\u0001J\u0001J\u0001"+
		"J\u0001J\u0004J\u0342\bJ\u000bJ\fJ\u0343\u0003J\u0346\bJ\u0001J\u0001"+
		"J\u0001K\u0001K\u0001K\u0001K\u0001K\u0001K\u0001K\u0001L\u0001L\u0001"+
		"L\u0001L\u0001L\u0001L\u0001L\u0001M\u0001M\u0001M\u0001M\u0004M\u035c"+
		"\bM\u000bM\fM\u035d\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001"+
		"M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001M\u0001"+
		"M\u0001M\u0001M\u0001M\u0001M\u0003M\u0376\bM\u0001M\u0001M\u0001M\u0003"+
		"M\u037b\bM\u0001N\u0001N\u0001O\u0001O\u0001O\u0001O\u0001O\u0001O\u0001"+
		"O\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001"+
		"P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001P\u0001"+
		"P\u0003P\u039a\bP\u0001Q\u0004Q\u039d\bQ\u000bQ\fQ\u039e\u0001R\u0001"+
		"R\u0001R\u0001R\u0001R\u0001R\u0001R\u0001S\u0001S\u0001S\u0001S\u0001"+
		"S\u0001S\u0001S\u0001T\u0001T\u0001T\u0001T\u0001T\u0001T\u0001T\u0001"+
		"U\u0001U\u0001U\u0001U\u0001U\u0001U\u0001U\u0001V\u0001V\u0001V\u0001"+
		"V\u0004V\u03c1\bV\u000bV\fV\u03c2\u0001V\u0001V\u0001W\u0001W\u0001W\u0001"+
		"W\u0004W\u03cb\bW\u000bW\fW\u03cc\u0001W\u0001W\u0001X\u0001X\u0001X\u0001"+
		"X\u0001X\u0001X\u0001Y\u0001Y\u0001Y\u0001Y\u0001Y\u0001Y\u0001Z\u0001"+
		"Z\u0001Z\u0001Z\u0001Z\u0001Z\u0001[\u0001[\u0001[\u0001[\u0001[\u0001"+
		"[\u0001\\\u0001\\\u0001\\\u0001\\\u0001\\\u0001]\u0001]\u0001]\u0001]"+
		"\u0001]\u0001^\u0001^\u0001^\u0001^\u0001^\u0003^\u03f8\b^\u0001^\u0001"+
		"^\u0001_\u0001_\u0001_\u0001_\u0001_\u0001`\u0001`\u0001`\u0001`\u0001"+
		"`\u0001`\u0001`\u0001a\u0001a\u0001a\u0001a\u0003a\u040c\ba\u0001a\u0001"+
		"a\u0001a\u0001a\u0001b\u0001b\u0001b\u0001b\u0003b\u0416\bb\u0001b\u0001"+
		"b\u0001c\u0001c\u0001c\u0001c\u0003c\u041e\bc\u0001c\u0001c\u0001d\u0001"+
		"d\u0001d\u0001d\u0003d\u0426\bd\u0001e\u0001e\u0001e\u0001e\u0003e\u042c"+
		"\be\u0001e\u0001e\u0001e\u0001e\u0001f\u0001f\u0001f\u0001f\u0001f\u0001"+
		"f\u0001g\u0004g\u0439\bg\u000bg\fg\u043a\u0001g\u0018\u00f6\u00fe\u0118"+
		"\u0131\u0140\u014b\u015a\u01a7\u01b0\u01b7\u01c9\u01d3\u01da\u01e5\u01ef"+
		"\u01f7\u02b5\u02e4\u02f0\u02fc\u0343\u035d\u03c2\u03cc\u0000h\u0000\u0002"+
		"\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e"+
		" \"$&(*,.02468:<>@BDFHJLNPRTVXZ\\^`bdfhjlnprtvxz|~\u0080\u0082\u0084\u0086"+
		"\u0088\u008a\u008c\u008e\u0090\u0092\u0094\u0096\u0098\u009a\u009c\u009e"+
		"\u00a0\u00a2\u00a4\u00a6\u00a8\u00aa\u00ac\u00ae\u00b0\u00b2\u00b4\u00b6"+
		"\u00b8\u00ba\u00bc\u00be\u00c0\u00c2\u00c4\u00c6\u00c8\u00ca\u00cc\u00ce"+
		"\u0000\b\u0001\u0000\u0006\u0007\u0001\u0000\t\n\u0001\u0000\u0010\u0011"+
		"\u0001\u0000\u001c\u001d\u0001\u0000-1\u0001\u0000*+\u0002\u0000\u0011"+
		"\u0011==\u0001\u0000UV\u046f\u0000\u00d0\u0001\u0000\u0000\u0000\u0002"+
		"\u00d3\u0001\u0000\u0000\u0000\u0004\u00d6\u0001\u0000\u0000\u0000\u0006"+
		"\u00d9\u0001\u0000\u0000\u0000\b\u00dc\u0001\u0000\u0000\u0000\n\u00df"+
		"\u0001\u0000\u0000\u0000\f\u00e2\u0001\u0000\u0000\u0000\u000e\u00e5\u0001"+
		"\u0000\u0000\u0000\u0010\u00e8\u0001\u0000\u0000\u0000\u0012\u00eb\u0001"+
		"\u0000\u0000\u0000\u0014\u00ee\u0001\u0000\u0000\u0000\u0016\u00f1\u0001"+
		"\u0000\u0000\u0000\u0018\u0103\u0001\u0000\u0000\u0000\u001a\u0109\u0001"+
		"\u0000\u0000\u0000\u001c\u011c\u0001\u0000\u0000\u0000\u001e\u0122\u0001"+
		"\u0000\u0000\u0000 \u0135\u0001\u0000\u0000\u0000\"\u0152\u0001\u0000"+
		"\u0000\u0000$\u0161\u0001\u0000\u0000\u0000&\u016f\u0001\u0000\u0000\u0000"+
		"(\u0171\u0001\u0000\u0000\u0000*\u0178\u0001\u0000\u0000\u0000,\u0199"+
		"\u0001\u0000\u0000\u0000.\u019b\u0001\u0000\u0000\u00000\u01a1\u0001\u0000"+
		"\u0000\u00002\u01ab\u0001\u0000\u0000\u00004\u01bc\u0001\u0000\u0000\u0000"+
		"6\u01c4\u0001\u0000\u0000\u00008\u01cd\u0001\u0000\u0000\u0000:\u01df"+
		"\u0001\u0000\u0000\u0000<\u01e9\u0001\u0000\u0000\u0000>\u01f3\u0001\u0000"+
		"\u0000\u0000@\u01fc\u0001\u0000\u0000\u0000B\u0202\u0001\u0000\u0000\u0000"+
		"D\u0208\u0001\u0000\u0000\u0000F\u020c\u0001\u0000\u0000\u0000H\u0210"+
		"\u0001\u0000\u0000\u0000J\u0215\u0001\u0000\u0000\u0000L\u021a\u0001\u0000"+
		"\u0000\u0000N\u021e\u0001\u0000\u0000\u0000P\u0227\u0001\u0000\u0000\u0000"+
		"R\u022b\u0001\u0000\u0000\u0000T\u022e\u0001\u0000\u0000\u0000V\u0236"+
		"\u0001\u0000\u0000\u0000X\u0246\u0001\u0000\u0000\u0000Z\u0248\u0001\u0000"+
		"\u0000\u0000\\\u025e\u0001\u0000\u0000\u0000^\u0260\u0001\u0000\u0000"+
		"\u0000`\u0267\u0001\u0000\u0000\u0000b\u0272\u0001\u0000\u0000\u0000d"+
		"\u0274\u0001\u0000\u0000\u0000f\u0278\u0001\u0000\u0000\u0000h\u0280\u0001"+
		"\u0000\u0000\u0000j\u0288\u0001\u0000\u0000\u0000l\u028e\u0001\u0000\u0000"+
		"\u0000n\u0290\u0001\u0000\u0000\u0000p\u0295\u0001\u0000\u0000\u0000r"+
		"\u02a1\u0001\u0000\u0000\u0000t\u02ad\u0001\u0000\u0000\u0000v\u02af\u0001"+
		"\u0000\u0000\u0000x\u02bb\u0001\u0000\u0000\u0000z\u02c2\u0001\u0000\u0000"+
		"\u0000|\u02d0\u0001\u0000\u0000\u0000~\u02d2\u0001\u0000\u0000\u0000\u0080"+
		"\u02de\u0001\u0000\u0000\u0000\u0082\u02ea\u0001\u0000\u0000\u0000\u0084"+
		"\u02f6\u0001\u0000\u0000\u0000\u0086\u0302\u0001\u0000\u0000\u0000\u0088"+
		"\u0309\u0001\u0000\u0000\u0000\u008a\u0312\u0001\u0000\u0000\u0000\u008c"+
		"\u0318\u0001\u0000\u0000\u0000\u008e\u0327\u0001\u0000\u0000\u0000\u0090"+
		"\u0329\u0001\u0000\u0000\u0000\u0092\u0332\u0001\u0000\u0000\u0000\u0094"+
		"\u033c\u0001\u0000\u0000\u0000\u0096\u0349\u0001\u0000\u0000\u0000\u0098"+
		"\u0350\u0001\u0000\u0000\u0000\u009a\u037a\u0001\u0000\u0000\u0000\u009c"+
		"\u037c\u0001\u0000\u0000\u0000\u009e\u037e\u0001\u0000\u0000\u0000\u00a0"+
		"\u0399\u0001\u0000\u0000\u0000\u00a2\u039c\u0001\u0000\u0000\u0000\u00a4"+
		"\u03a0\u0001\u0000\u0000\u0000\u00a6\u03a7\u0001\u0000\u0000\u0000\u00a8"+
		"\u03ae\u0001\u0000\u0000\u0000\u00aa\u03b5\u0001\u0000\u0000\u0000\u00ac"+
		"\u03bc\u0001\u0000\u0000\u0000\u00ae\u03c6\u0001\u0000\u0000\u0000\u00b0"+
		"\u03d0\u0001\u0000\u0000\u0000\u00b2\u03d6\u0001\u0000\u0000\u0000\u00b4"+
		"\u03dc\u0001\u0000\u0000\u0000\u00b6\u03e2\u0001\u0000\u0000\u0000\u00b8"+
		"\u03e8\u0001\u0000\u0000\u0000\u00ba\u03ed\u0001\u0000\u0000\u0000\u00bc"+
		"\u03f2\u0001\u0000\u0000\u0000\u00be\u03fb\u0001\u0000\u0000\u0000\u00c0"+
		"\u0400\u0001\u0000\u0000\u0000\u00c2\u0407\u0001\u0000\u0000\u0000\u00c4"+
		"\u0411\u0001\u0000\u0000\u0000\u00c6\u0419\u0001\u0000\u0000\u0000\u00c8"+
		"\u0425\u0001\u0000\u0000\u0000\u00ca\u0427\u0001\u0000\u0000\u0000\u00cc"+
		"\u0431\u0001\u0000\u0000\u0000\u00ce\u0438\u0001\u0000\u0000\u0000\u00d0"+
		"\u00d1\u0005\u0001\u0000\u0000\u00d1\u00d2\u0003\u00ceg\u0000\u00d2\u0001"+
		"\u0001\u0000\u0000\u0000\u00d3\u00d4\u0005\u0001\u0000\u0000\u00d4\u00d5"+
		"\u0003\u00ceg\u0000\u00d5\u0003\u0001\u0000\u0000\u0000\u00d6\u00d7\u0005"+
		"\u0001\u0000\u0000\u00d7\u00d8\u0003\u00ceg\u0000\u00d8\u0005\u0001\u0000"+
		"\u0000\u0000\u00d9\u00da\u0005\u0001\u0000\u0000\u00da\u00db\u0003\u00ce"+
		"g\u0000\u00db\u0007\u0001\u0000\u0000\u0000\u00dc\u00dd\u0005\u0001\u0000"+
		"\u0000\u00dd\u00de\u0003\u00ceg\u0000\u00de\t\u0001\u0000\u0000\u0000"+
		"\u00df\u00e0\u0005\u0001\u0000\u0000\u00e0\u00e1\u0003\u00ceg\u0000\u00e1"+
		"\u000b\u0001\u0000\u0000\u0000\u00e2\u00e3\u0005\u0001\u0000\u0000\u00e3"+
		"\u00e4\u0003\u00ceg\u0000\u00e4\r\u0001\u0000\u0000\u0000\u00e5\u00e6"+
		"\u0005\u0001\u0000\u0000\u00e6\u00e7\u0003\u00ceg\u0000\u00e7\u000f\u0001"+
		"\u0000\u0000\u0000\u00e8\u00e9\u0005\u0001\u0000\u0000\u00e9\u00ea\u0003"+
		"\u00ceg\u0000\u00ea\u0011\u0001\u0000\u0000\u0000\u00eb\u00ec\u0005\u0001"+
		"\u0000\u0000\u00ec\u00ed\u0003\u00ceg\u0000\u00ed\u0013\u0001\u0000\u0000"+
		"\u0000\u00ee\u00ef\u0005\u0001\u0000\u0000\u00ef\u00f0\u0003\u00ceg\u0000"+
		"\u00f0\u0015\u0001\u0000\u0000\u0000\u00f1\u00f2\u0005Z\u0000\u0000\u00f2"+
		"\u00f6\u0005\u0002\u0000\u0000\u00f3\u00f5\u0003\u0018\f\u0000\u00f4\u00f3"+
		"\u0001\u0000\u0000\u0000\u00f5\u00f8\u0001\u0000\u0000\u0000\u00f6\u00f7"+
		"\u0001\u0000\u0000\u0000\u00f6\u00f4\u0001\u0000\u0000\u0000\u00f7\u00f9"+
		"\u0001\u0000\u0000\u0000\u00f8\u00f6\u0001\u0000\u0000\u0000\u00f9\u00fc"+
		"\u0003\u001a\r\u0000\u00fa\u00fd\u0003\"\u0011\u0000\u00fb\u00fd\u0003"+
		"\u001e\u000f\u0000\u00fc\u00fa\u0001\u0000\u0000\u0000\u00fc\u00fb\u0001"+
		"\u0000\u0000\u0000\u00fd\u00fe\u0001\u0000\u0000\u0000\u00fe\u00ff\u0001"+
		"\u0000\u0000\u0000\u00fe\u00fc\u0001\u0000\u0000\u0000\u00ff\u0100\u0001"+
		"\u0000\u0000\u0000\u0100\u0101\u0003\u001c\u000e\u0000\u0101\u0102\u0005"+
		"[\u0000\u0000\u0102\u0017\u0001\u0000\u0000\u0000\u0103\u0104\u0005Z\u0000"+
		"\u0000\u0104\u0105\u0005\u0003\u0000\u0000\u0105\u0106\u0003r9\u0000\u0106"+
		"\u0107\u0003\u0000\u0000\u0000\u0107\u0108\u0005[\u0000\u0000\u0108\u0019"+
		"\u0001\u0000\u0000\u0000\u0109\u010a\u0005Z\u0000\u0000\u010a\u010b\u0005"+
		"\u0004\u0000\u0000\u010b\u010d\u0003.\u0017\u0000\u010c\u010e\u00030\u0018"+
		"\u0000\u010d\u010c\u0001\u0000\u0000\u0000\u010d\u010e\u0001\u0000\u0000"+
		"\u0000\u010e\u0116\u0001\u0000\u0000\u0000\u010f\u0112\u0005Z\u0000\u0000"+
		"\u0110\u0113\u00034\u001a\u0000\u0111\u0113\u0003X,\u0000\u0112\u0110"+
		"\u0001\u0000\u0000\u0000\u0112\u0111\u0001\u0000\u0000\u0000\u0113\u0114"+
		"\u0001\u0000\u0000\u0000\u0114\u0115\u0005[\u0000\u0000\u0115\u0117\u0001"+
		"\u0000\u0000\u0000\u0116\u010f\u0001\u0000\u0000\u0000\u0117\u0118\u0001"+
		"\u0000\u0000\u0000\u0118\u0119\u0001\u0000\u0000\u0000\u0118\u0116\u0001"+
		"\u0000\u0000\u0000\u0119\u011a\u0001\u0000\u0000\u0000\u011a\u011b\u0005"+
		"[\u0000\u0000\u011b\u001b\u0001\u0000\u0000\u0000\u011c\u011d\u0005Z\u0000"+
		"\u0000\u011d\u011e\u0005\u0005\u0000\u0000\u011e\u011f\u0007\u0000\u0000"+
		"\u0000\u011f\u0120\u0003\u00a0P\u0000\u0120\u0121\u0005[\u0000\u0000\u0121"+
		"\u001d\u0001\u0000\u0000\u0000\u0122\u0123\u0005Z\u0000\u0000\u0123\u0124"+
		"\u0005\b\u0000\u0000\u0124\u0126\u0007\u0001\u0000\u0000\u0125\u0127\u0003"+
		"\u009aM\u0000\u0126\u0125\u0001\u0000\u0000\u0000\u0126\u0127\u0001\u0000"+
		"\u0000\u0000\u0127\u012b\u0001\u0000\u0000\u0000\u0128\u012c\u0003 \u0010"+
		"\u0000\u0129\u012c\u0005\u000b\u0000\u0000\u012a\u012c\u0005\f\u0000\u0000"+
		"\u012b\u0128\u0001\u0000\u0000\u0000\u012b\u0129\u0001\u0000\u0000\u0000"+
		"\u012b\u012a\u0001\u0000\u0000\u0000\u012c\u012f\u0001\u0000\u0000\u0000"+
		"\u012d\u0130\u0003\"\u0011\u0000\u012e\u0130\u0003\u001e\u000f\u0000\u012f"+
		"\u012d\u0001\u0000\u0000\u0000\u012f\u012e\u0001\u0000\u0000\u0000\u0130"+
		"\u0131\u0001\u0000\u0000\u0000\u0131\u0132\u0001\u0000\u0000\u0000\u0131"+
		"\u012f\u0001\u0000\u0000\u0000\u0132\u0133\u0001\u0000\u0000\u0000\u0133"+
		"\u0134\u0005[\u0000\u0000\u0134\u001f\u0001\u0000\u0000\u0000\u0135\u0136"+
		"\u0005Z\u0000\u0000\u0136\u0137\u0005\r\u0000\u0000\u0137\u0138\u0003"+
		"\u009aM\u0000\u0138\u0139\u0005[\u0000\u0000\u0139!\u0001\u0000\u0000"+
		"\u0000\u013a\u013b\u0005Z\u0000\u0000\u013b\u013c\u0005\u000e\u0000\u0000"+
		"\u013c\u013e\u0005Z\u0000\u0000\u013d\u013f\u0003&\u0013\u0000\u013e\u013d"+
		"\u0001\u0000\u0000\u0000\u013f\u0140\u0001\u0000\u0000\u0000\u0140\u0141"+
		"\u0001\u0000\u0000\u0000\u0140\u013e\u0001\u0000\u0000\u0000\u0141\u0142"+
		"\u0001\u0000\u0000\u0000\u0142\u0143\u0005[\u0000\u0000\u0143\u0144\u0005"+
		"[\u0000\u0000\u0144\u0153\u0001\u0000\u0000\u0000\u0145\u0146\u0005Z\u0000"+
		"\u0000\u0146\u0147\u0005\u000f\u0000\u0000\u0147\u0149\u0005Z\u0000\u0000"+
		"\u0148\u014a\u0003&\u0013\u0000\u0149\u0148\u0001\u0000\u0000\u0000\u014a"+
		"\u014b\u0001\u0000\u0000\u0000\u014b\u014c\u0001\u0000\u0000\u0000\u014b"+
		"\u0149\u0001\u0000\u0000\u0000\u014c\u014d\u0001\u0000\u0000\u0000\u014d"+
		"\u014e\u0005[\u0000\u0000\u014e\u014f\u0005[\u0000\u0000\u014f\u0153\u0001"+
		"\u0000\u0000\u0000\u0150\u0153\u0003(\u0014\u0000\u0151\u0153\u0003*\u0015"+
		"\u0000\u0152\u013a\u0001\u0000\u0000\u0000\u0152\u0145\u0001\u0000\u0000"+
		"\u0000\u0152\u0150\u0001\u0000\u0000\u0000\u0152\u0151\u0001\u0000\u0000"+
		"\u0000\u0153#\u0001\u0000\u0000\u0000\u0154\u0155\u0005Z\u0000\u0000\u0155"+
		"\u0156\u0005\u000f\u0000\u0000\u0156\u0158\u0005Z\u0000\u0000\u0157\u0159"+
		"\u0003&\u0013\u0000\u0158\u0157\u0001\u0000\u0000\u0000\u0159\u015a\u0001"+
		"\u0000\u0000\u0000\u015a\u015b\u0001\u0000\u0000\u0000\u015a\u0158\u0001"+
		"\u0000\u0000\u0000\u015b\u015c\u0001\u0000\u0000\u0000\u015c\u015d\u0005"+
		"[\u0000\u0000\u015d\u015e\u0005[\u0000\u0000\u015e\u0162\u0001\u0000\u0000"+
		"\u0000\u015f\u0162\u0003(\u0014\u0000\u0160\u0162\u0003*\u0015\u0000\u0161"+
		"\u0154\u0001\u0000\u0000\u0000\u0161\u015f\u0001\u0000\u0000\u0000\u0161"+
		"\u0160\u0001\u0000\u0000\u0000\u0162%\u0001\u0000\u0000\u0000\u0163\u0164"+
		"\u0005Z\u0000\u0000\u0164\u0165\u0003\u009aM\u0000\u0165\u0166\u0003$"+
		"\u0012\u0000\u0166\u0167\u0005[\u0000\u0000\u0167\u0170\u0001\u0000\u0000"+
		"\u0000\u0168\u0170\u0003$\u0012\u0000\u0169\u016a\u0005Z\u0000\u0000\u016a"+
		"\u016b\u0003\u009aM\u0000\u016b\u016c\u0003,\u0016\u0000\u016c\u016d\u0005"+
		"[\u0000\u0000\u016d\u0170\u0001\u0000\u0000\u0000\u016e\u0170\u0003,\u0016"+
		"\u0000\u016f\u0163\u0001\u0000\u0000\u0000\u016f\u0168\u0001\u0000\u0000"+
		"\u0000\u016f\u0169\u0001\u0000\u0000\u0000\u016f\u016e\u0001\u0000\u0000"+
		"\u0000\u0170\'\u0001\u0000\u0000\u0000\u0171\u0172\u0005Z\u0000\u0000"+
		"\u0172\u0173\u0007\u0002\u0000\u0000\u0173\u0174\u0003t:\u0000\u0174\u0175"+
		"\u0003\u0000\u0000\u0000\u0175\u0176\u0003&\u0013\u0000\u0176\u0177\u0005"+
		"[\u0000\u0000\u0177)\u0001\u0000\u0000\u0000\u0178\u0179\u0005Z\u0000"+
		"\u0000\u0179\u017a\u0005\u0012\u0000\u0000\u017a\u017b\u0003r9\u0000\u017b"+
		"\u017f\u0003\u0000\u0000\u0000\u017c\u0180\u0003\"\u0011\u0000\u017d\u0180"+
		"\u0003,\u0016\u0000\u017e\u0180\u0003&\u0013\u0000\u017f\u017c\u0001\u0000"+
		"\u0000\u0000\u017f\u017d\u0001\u0000\u0000\u0000\u017f\u017e\u0001\u0000"+
		"\u0000\u0000\u0180\u0181\u0001\u0000\u0000\u0000\u0181\u0182\u0005[\u0000"+
		"\u0000\u0182+\u0001\u0000\u0000\u0000\u0183\u0194\u0005Z\u0000\u0000\u0184"+
		"\u0195\u0003:\u001d\u0000\u0185\u0195\u00030\u0018\u0000\u0186\u0195\u0003"+
		"4\u001a\u0000\u0187\u0195\u0003B!\u0000\u0188\u0195\u0003D\"\u0000\u0189"+
		"\u0195\u0003L&\u0000\u018a\u0195\u0003P(\u0000\u018b\u0195\u0003N\'\u0000"+
		"\u018c\u0195\u0003<\u001e\u0000\u018d\u0195\u0003H$\u0000\u018e\u0195"+
		"\u0003F#\u0000\u018f\u0195\u0003J%\u0000\u0190\u0195\u0003R)\u0000\u0191"+
		"\u0195\u0003V+\u0000\u0192\u0195\u0003T*\u0000\u0193\u0195\u0003X,\u0000"+
		"\u0194\u0184\u0001\u0000\u0000\u0000\u0194\u0185\u0001\u0000\u0000\u0000"+
		"\u0194\u0186\u0001\u0000\u0000\u0000\u0194\u0187\u0001\u0000\u0000\u0000"+
		"\u0194\u0188\u0001\u0000\u0000\u0000\u0194\u0189\u0001\u0000\u0000\u0000"+
		"\u0194\u018a\u0001\u0000\u0000\u0000\u0194\u018b\u0001\u0000\u0000\u0000"+
		"\u0194\u018c\u0001\u0000\u0000\u0000\u0194\u018d\u0001\u0000\u0000\u0000"+
		"\u0194\u018e\u0001\u0000\u0000\u0000\u0194\u018f\u0001\u0000\u0000\u0000"+
		"\u0194\u0190\u0001\u0000\u0000\u0000\u0194\u0191\u0001\u0000\u0000\u0000"+
		"\u0194\u0192\u0001\u0000\u0000\u0000\u0194\u0193\u0001\u0000\u0000\u0000"+
		"\u0195\u0196\u0001\u0000\u0000\u0000\u0196\u0197\u0005[\u0000\u0000\u0197"+
		"\u019a\u0001\u0000\u0000\u0000\u0198\u019a\u0003(\u0014\u0000\u0199\u0183"+
		"\u0001\u0000\u0000\u0000\u0199\u0198\u0001\u0000\u0000\u0000\u019a-\u0001"+
		"\u0000\u0000\u0000\u019b\u019c\u0005Z\u0000\u0000\u019c\u019d\u0005\u0013"+
		"\u0000\u0000\u019d\u019e\u0005\u0014\u0000\u0000\u019e\u019f\u0003\u00a0"+
		"P\u0000\u019f\u01a0\u0005[\u0000\u0000\u01a0/\u0001\u0000\u0000\u0000"+
		"\u01a1\u01a2\u0005Z\u0000\u0000\u01a2\u01a3\u0005\u0013\u0000\u0000\u01a3"+
		"\u01a5\u0005\u0015\u0000\u0000\u01a4\u01a6\u00032\u0019\u0000\u01a5\u01a4"+
		"\u0001\u0000\u0000\u0000\u01a6\u01a7\u0001\u0000\u0000\u0000\u01a7\u01a8"+
		"\u0001\u0000\u0000\u0000\u01a7\u01a5\u0001\u0000\u0000\u0000\u01a8\u01a9"+
		"\u0001\u0000\u0000\u0000\u01a9\u01aa\u0005[\u0000\u0000\u01aa1\u0001\u0000"+
		"\u0000\u0000\u01ab\u01b0\u0005Z\u0000\u0000\u01ac\u01ad\u0005X\u0000\u0000"+
		"\u01ad\u01af\u0005\u0016\u0000\u0000\u01ae\u01ac\u0001\u0000\u0000\u0000"+
		"\u01af\u01b2\u0001\u0000\u0000\u0000\u01b0\u01b1\u0001\u0000\u0000\u0000"+
		"\u01b0\u01ae\u0001\u0000\u0000\u0000\u01b1\u01b3\u0001\u0000\u0000\u0000"+
		"\u01b2\u01b0\u0001\u0000\u0000\u0000\u01b3\u01b7\u0005X\u0000\u0000\u01b4"+
		"\u01b6\u00032\u0019\u0000\u01b5\u01b4\u0001\u0000\u0000\u0000\u01b6\u01b9"+
		"\u0001\u0000\u0000\u0000\u01b7\u01b8\u0001\u0000\u0000\u0000\u01b7\u01b5"+
		"\u0001\u0000\u0000\u0000\u01b8\u01ba\u0001\u0000\u0000\u0000\u01b9\u01b7"+
		"\u0001\u0000\u0000\u0000\u01ba\u01bb\u0005[\u0000\u0000\u01bb3\u0001\u0000"+
		"\u0000\u0000\u01bc\u01bd\u0005\u0013\u0000\u0000\u01bd\u01bf\u0005\u0017"+
		"\u0000\u0000\u01be\u01c0\u0003\u00c8d\u0000\u01bf\u01be\u0001\u0000\u0000"+
		"\u0000\u01bf\u01c0\u0001\u0000\u0000\u0000\u01c0\u01c1\u0001\u0000\u0000"+
		"\u0000\u01c1\u01c2\u0003|>\u0000\u01c2\u01c3\u00036\u001b\u0000\u01c3"+
		"5\u0001\u0000\u0000\u0000\u01c4\u01c5\u0005Z\u0000\u0000\u01c5\u01c7\u0005"+
		"\u0017\u0000\u0000\u01c6\u01c8\u00038\u001c\u0000\u01c7\u01c6\u0001\u0000"+
		"\u0000\u0000\u01c8\u01c9\u0001\u0000\u0000\u0000\u01c9\u01ca\u0001\u0000"+
		"\u0000\u0000\u01c9\u01c7\u0001\u0000\u0000\u0000\u01ca\u01cb\u0001\u0000"+
		"\u0000\u0000\u01cb\u01cc\u0005[\u0000\u0000\u01cc7\u0001\u0000\u0000\u0000"+
		"\u01cd\u01d3\u0005Z\u0000\u0000\u01ce\u01cf\u0003\u00ceg\u0000\u01cf\u01d0"+
		"\u0005\u0016\u0000\u0000\u01d0\u01d2\u0001\u0000\u0000\u0000\u01d1\u01ce"+
		"\u0001\u0000\u0000\u0000\u01d2\u01d5\u0001\u0000\u0000\u0000\u01d3\u01d4"+
		"\u0001\u0000\u0000\u0000\u01d3\u01d1\u0001\u0000\u0000\u0000\u01d4\u01d6"+
		"\u0001\u0000\u0000\u0000\u01d5\u01d3\u0001\u0000\u0000\u0000\u01d6\u01da"+
		"\u0003\u00ceg\u0000\u01d7\u01d9\u00038\u001c\u0000\u01d8\u01d7\u0001\u0000"+
		"\u0000\u0000\u01d9\u01dc\u0001\u0000\u0000\u0000\u01da\u01db\u0001\u0000"+
		"\u0000\u0000\u01da\u01d8\u0001\u0000\u0000\u0000\u01db\u01dd\u0001\u0000"+
		"\u0000\u0000\u01dc\u01da\u0001\u0000\u0000\u0000\u01dd\u01de\u0005[\u0000"+
		"\u0000\u01de9\u0001\u0000\u0000\u0000\u01df\u01e0\u0005\u0018\u0000\u0000"+
		"\u01e0\u01e1\u0003Z-\u0000\u01e1\u01e3\u0005Z\u0000\u0000\u01e2\u01e4"+
		"\u0003>\u001f\u0000\u01e3\u01e2\u0001\u0000\u0000\u0000\u01e4\u01e5\u0001"+
		"\u0000\u0000\u0000\u01e5\u01e6\u0001\u0000\u0000\u0000\u01e5\u01e3\u0001"+
		"\u0000\u0000\u0000\u01e6\u01e7\u0001\u0000\u0000\u0000\u01e7\u01e8\u0005"+
		"[\u0000\u0000\u01e8;\u0001\u0000\u0000\u0000\u01e9\u01ea\u0005\u0019\u0000"+
		"\u0000\u01ea\u01eb\u0003Z-\u0000\u01eb\u01ed\u0005Z\u0000\u0000\u01ec"+
		"\u01ee\u0003>\u001f\u0000\u01ed\u01ec\u0001\u0000\u0000\u0000\u01ee\u01ef"+
		"\u0001\u0000\u0000\u0000\u01ef\u01f0\u0001\u0000\u0000\u0000\u01ef\u01ed"+
		"\u0001\u0000\u0000\u0000\u01f0\u01f1\u0001\u0000\u0000\u0000\u01f1\u01f2"+
		"\u0005[\u0000\u0000\u01f2=\u0001\u0000\u0000\u0000\u01f3\u01f5\u0005Z"+
		"\u0000\u0000\u01f4\u01f6\u0003@ \u0000\u01f5\u01f4\u0001\u0000\u0000\u0000"+
		"\u01f6\u01f7\u0001\u0000\u0000\u0000\u01f7\u01f8\u0001\u0000\u0000\u0000"+
		"\u01f7\u01f5\u0001\u0000\u0000\u0000\u01f8\u01f9\u0001\u0000\u0000\u0000"+
		"\u01f9\u01fa\u0003\u00a0P\u0000\u01fa\u01fb\u0005[\u0000\u0000\u01fb?"+
		"\u0001\u0000\u0000\u0000\u01fc\u01fd\u0005Z\u0000\u0000\u01fd\u01fe\u0003"+
		"\u00c8d\u0000\u01fe\u01ff\u0005\u001a\u0000\u0000\u01ff\u0200\u0003\u00c8"+
		"d\u0000\u0200\u0201\u0005[\u0000\u0000\u0201A\u0001\u0000\u0000\u0000"+
		"\u0202\u0203\u0005\u001b\u0000\u0000\u0203\u0206\u0007\u0003\u0000\u0000"+
		"\u0204\u0207\u0003h4\u0000\u0205\u0207\u0003\u0006\u0003\u0000\u0206\u0204"+
		"\u0001\u0000\u0000\u0000\u0206\u0205\u0001\u0000\u0000\u0000\u0207C\u0001"+
		"\u0000\u0000\u0000\u0208\u0209\u0005\u0018\u0000\u0000\u0209\u020a\u0003"+
		"\u00c2a\u0000\u020a\u020b\u0003\u00a0P\u0000\u020bE\u0001\u0000\u0000"+
		"\u0000\u020c\u020d\u0005\u0018\u0000\u0000\u020d\u020e\u0003\u00cae\u0000"+
		"\u020e\u020f\u0003\u00c8d\u0000\u020fG\u0001\u0000\u0000\u0000\u0210\u0211"+
		"\u0005\u001e\u0000\u0000\u0211\u0213\u0003\u00c2a\u0000\u0212\u0214\u0003"+
		"\u00a0P\u0000\u0213\u0212\u0001\u0000\u0000\u0000\u0213\u0214\u0001\u0000"+
		"\u0000\u0000\u0214I\u0001\u0000\u0000\u0000\u0215\u0216\u0005\u001f\u0000"+
		"\u0000\u0216\u0218\u0003\u00c2a\u0000\u0217\u0219\u0003\u00a0P\u0000\u0218"+
		"\u0217\u0001\u0000\u0000\u0000\u0218\u0219\u0001\u0000\u0000\u0000\u0219"+
		"K\u0001\u0000\u0000\u0000\u021a\u021b\u0005 \u0000\u0000\u021b\u021c\u0003"+
		"\\.\u0000\u021c\u021d\u0003\\.\u0000\u021dM\u0001\u0000\u0000\u0000\u021e"+
		"\u0225\u0005!\u0000\u0000\u021f\u0220\u0003\\.\u0000\u0220\u0221\u0003"+
		"\\.\u0000\u0221\u0226\u0001\u0000\u0000\u0000\u0222\u0223\u0003~?\u0000"+
		"\u0223\u0224\u0003~?\u0000\u0224\u0226\u0001\u0000\u0000\u0000\u0225\u021f"+
		"\u0001\u0000\u0000\u0000\u0225\u0222\u0001\u0000\u0000\u0000\u0226O\u0001"+
		"\u0000\u0000\u0000\u0227\u0228\u0005\"\u0000\u0000\u0228\u0229\u0003\\"+
		".\u0000\u0229\u022a\u0003\\.\u0000\u022aQ\u0001\u0000\u0000\u0000\u022b"+
		"\u022c\u0005#\u0000\u0000\u022c\u022d\u0003\\.\u0000\u022dS\u0001\u0000"+
		"\u0000\u0000\u022e\u0234\u0005$\u0000\u0000\u022f\u0235\u0003|>\u0000"+
		"\u0230\u0231\u0005%\u0000\u0000\u0231\u0232\u0003|>\u0000\u0232\u0233"+
		"\u0003|>\u0000\u0233\u0235\u0001\u0000\u0000\u0000\u0234\u022f\u0001\u0000"+
		"\u0000\u0000\u0234\u0230\u0001\u0000\u0000\u0000\u0235U\u0001\u0000\u0000"+
		"\u0000\u0236\u0237\u0005&\u0000\u0000\u0237\u0238\u0005\'\u0000\u0000"+
		"\u0238W\u0001\u0000\u0000\u0000\u0239\u023a\u0005(\u0000\u0000\u023a\u023b"+
		"\u0003\u00a0P\u0000\u023b\u023c\u0003,\u0016\u0000\u023c\u0247\u0001\u0000"+
		"\u0000\u0000\u023d\u023e\u0005(\u0000\u0000\u023e\u023f\u0005\u0011\u0000"+
		"\u0000\u023f\u0242\u0005Z\u0000\u0000\u0240\u0243\u0003L&\u0000\u0241"+
		"\u0243\u0003R)\u0000\u0242\u0240\u0001\u0000\u0000\u0000\u0242\u0241\u0001"+
		"\u0000\u0000\u0000\u0243\u0244\u0001\u0000\u0000\u0000\u0244\u0245\u0005"+
		"[\u0000\u0000\u0245\u0247\u0001\u0000\u0000\u0000\u0246\u0239\u0001\u0000"+
		"\u0000\u0000\u0246\u023d\u0001\u0000\u0000\u0000\u0247Y\u0001\u0000\u0000"+
		"\u0000\u0248\u024c\u0005Z\u0000\u0000\u0249\u024d\u0003\u0004\u0002\u0000"+
		"\u024a\u024d\u0005\u0002\u0000\u0000\u024b\u024d\u0003f3\u0000\u024c\u0249"+
		"\u0001\u0000\u0000\u0000\u024c\u024a\u0001\u0000\u0000\u0000\u024c\u024b"+
		"\u0001\u0000\u0000\u0000\u024d\u024e\u0001\u0000\u0000\u0000\u024e\u024f"+
		"\u0005)\u0000\u0000\u024f\u0250\u0003\u00c8d\u0000\u0250\u0251\u0005["+
		"\u0000\u0000\u0251[\u0001\u0000\u0000\u0000\u0252\u025f\u0003\u0012\t"+
		"\u0000\u0253\u025f\u0003^/\u0000\u0254\u025f\u0003`0\u0000\u0255\u0259"+
		"\u0005Z\u0000\u0000\u0256\u025a\u0005*\u0000\u0000\u0257\u025a\u0005+"+
		"\u0000\u0000\u0258\u025a\u0003\u00a0P\u0000\u0259\u0256\u0001\u0000\u0000"+
		"\u0000\u0259\u0257\u0001\u0000\u0000\u0000\u0259\u0258\u0001\u0000\u0000"+
		"\u0000\u0259\u025a\u0001\u0000\u0000\u0000\u025a\u025b\u0001\u0000\u0000"+
		"\u0000\u025b\u025c\u0003|>\u0000\u025c\u025d\u0005[\u0000\u0000\u025d"+
		"\u025f\u0001\u0000\u0000\u0000\u025e\u0252\u0001\u0000\u0000\u0000\u025e"+
		"\u0253\u0001\u0000\u0000\u0000\u025e\u0254\u0001\u0000\u0000\u0000\u025e"+
		"\u0255\u0001\u0000\u0000\u0000\u025f]\u0001\u0000\u0000\u0000\u0260\u0261"+
		"\u0005Z\u0000\u0000\u0261\u0262\u0005\u0007\u0000\u0000\u0262\u0263\u0003"+
		"|>\u0000\u0263\u0264\u0005,\u0000\u0000\u0264\u0265\u0003Z-\u0000\u0265"+
		"\u0266\u0005[\u0000\u0000\u0266_\u0001\u0000\u0000\u0000\u0267\u0268\u0005"+
		"Z\u0000\u0000\u0268\u0269\u0005\u0006\u0000\u0000\u0269\u026a\u0003|>"+
		"\u0000\u026a\u026b\u0005,\u0000\u0000\u026b\u026c\u0003Z-\u0000\u026c"+
		"\u026d\u0005[\u0000\u0000\u026da\u0001\u0000\u0000\u0000\u026e\u0273\u0005"+
		"\u0002\u0000\u0000\u026f\u0273\u0003j5\u0000\u0270\u0273\u0003\u0004\u0002"+
		"\u0000\u0271\u0273\u0003h4\u0000\u0272\u026e\u0001\u0000\u0000\u0000\u0272"+
		"\u026f\u0001\u0000\u0000\u0000\u0272\u0270\u0001\u0000\u0000\u0000\u0272"+
		"\u0271\u0001\u0000\u0000\u0000\u0273c\u0001\u0000\u0000\u0000\u0274\u0275"+
		"\u0007\u0004\u0000\u0000\u0275e\u0001\u0000\u0000\u0000\u0276\u0279\u0003"+
		"h4\u0000\u0277\u0279\u0003j5\u0000\u0278\u0276\u0001\u0000\u0000\u0000"+
		"\u0278\u0277\u0001\u0000\u0000\u0000\u0279g\u0001\u0000\u0000\u0000\u027a"+
		"\u027b\u0005Z\u0000\u0000\u027b\u027c\u0003l6\u0000\u027c\u027d\u0005"+
		"\t\u0000\u0000\u027d\u027e\u0005[\u0000\u0000\u027e\u0281\u0001\u0000"+
		"\u0000\u0000\u027f\u0281\u0003n7\u0000\u0280\u027a\u0001\u0000\u0000\u0000"+
		"\u0280\u027f\u0001\u0000\u0000\u0000\u0281i\u0001\u0000\u0000\u0000\u0282"+
		"\u0283\u0005Z\u0000\u0000\u0283\u0284\u0003l6\u0000\u0284\u0285\u0005"+
		"\n\u0000\u0000\u0285\u0286\u0005[\u0000\u0000\u0286\u0289\u0001\u0000"+
		"\u0000\u0000\u0287\u0289\u0003p8\u0000\u0288\u0282\u0001\u0000\u0000\u0000"+
		"\u0288\u0287\u0001\u0000\u0000\u0000\u0289k\u0001\u0000\u0000\u0000\u028a"+
		"\u028f\u0003\u00a0P\u0000\u028b\u028f\u00052\u0000\u0000\u028c\u028f\u0005"+
		"\u001c\u0000\u0000\u028d\u028f\u0005\u001d\u0000\u0000\u028e\u028a\u0001"+
		"\u0000\u0000\u0000\u028e\u028b\u0001\u0000\u0000\u0000\u028e\u028c\u0001"+
		"\u0000\u0000\u0000\u028e\u028d\u0001\u0000\u0000\u0000\u028fm\u0001\u0000"+
		"\u0000\u0000\u0290\u0291\u0005Z\u0000\u0000\u0291\u0292\u00053\u0000\u0000"+
		"\u0292\u0293\u0003\\.\u0000\u0293\u0294\u0005[\u0000\u0000\u0294o\u0001"+
		"\u0000\u0000\u0000\u0295\u0296\u0005Z\u0000\u0000\u0296\u0299\u0005\n"+
		"\u0000\u0000\u0297\u029a\u0003\u0006\u0003\u0000\u0298\u029a\u0003h4\u0000"+
		"\u0299\u0297\u0001\u0000\u0000\u0000\u0299\u0298\u0001\u0000\u0000\u0000"+
		"\u029a\u029b\u0001\u0000\u0000\u0000\u029b\u029c\u0005[\u0000\u0000\u029c"+
		"q\u0001\u0000\u0000\u0000\u029d\u02a2\u0003\u00a0P\u0000\u029e\u02a2\u0003"+
		"\u009aM\u0000\u029f\u02a2\u0003\u00c8d\u0000\u02a0\u02a2\u0003t:\u0000"+
		"\u02a1\u029d\u0001\u0000\u0000\u0000\u02a1\u029e\u0001\u0000\u0000\u0000"+
		"\u02a1\u029f\u0001\u0000\u0000\u0000\u02a1\u02a0\u0001\u0000\u0000\u0000"+
		"\u02a2s\u0001\u0000\u0000\u0000\u02a3\u02ae\u0003\f\u0006\u0000\u02a4"+
		"\u02ae\u0003\u0086C\u0000\u02a5\u02ae\u0003|>\u0000\u02a6\u02ae\u0003"+
		"v;\u0000\u02a7\u02ae\u0003\u008eG\u0000\u02a8\u02ae\u0005\t\u0000\u0000"+
		"\u02a9\u02ae\u0005\n\u0000\u0000\u02aa\u02ae\u0003j5\u0000\u02ab\u02ae"+
		"\u0003z=\u0000\u02ac\u02ae\u0003x<\u0000\u02ad\u02a3\u0001\u0000\u0000"+
		"\u0000\u02ad\u02a4\u0001\u0000\u0000\u0000\u02ad\u02a5\u0001\u0000\u0000"+
		"\u0000\u02ad\u02a6\u0001\u0000\u0000\u0000\u02ad\u02a7\u0001\u0000\u0000"+
		"\u0000\u02ad\u02a8\u0001\u0000\u0000\u0000\u02ad\u02a9\u0001\u0000\u0000"+
		"\u0000\u02ad\u02aa\u0001\u0000\u0000\u0000\u02ad\u02ab\u0001\u0000\u0000"+
		"\u0000\u02ad\u02ac\u0001\u0000\u0000\u0000\u02aeu\u0001\u0000\u0000\u0000"+
		"\u02af\u02b5\u0005Z\u0000\u0000\u02b0\u02b1\u0003\u00ceg\u0000\u02b1\u02b2"+
		"\u0005\u0016\u0000\u0000\u02b2\u02b4\u0001\u0000\u0000\u0000\u02b3\u02b0"+
		"\u0001\u0000\u0000\u0000\u02b4\u02b7\u0001\u0000\u0000\u0000\u02b5\u02b6"+
		"\u0001\u0000\u0000\u0000\u02b5\u02b3\u0001\u0000\u0000\u0000\u02b6\u02b8"+
		"\u0001\u0000\u0000\u0000\u02b7\u02b5\u0001\u0000\u0000\u0000\u02b8\u02b9"+
		"\u0003\u00ceg\u0000\u02b9\u02ba\u0005[\u0000\u0000\u02baw\u0001\u0000"+
		"\u0000\u0000\u02bb\u02bc\u0005Z\u0000\u0000\u02bc\u02bd\u00054\u0000\u0000"+
		"\u02bd\u02be\u0003\u00a0P\u0000\u02be\u02bf\u00055\u0000\u0000\u02bf\u02c0"+
		"\u0003\u00a0P\u0000\u02c0\u02c1\u0005[\u0000\u0000\u02c1y\u0001\u0000"+
		"\u0000\u0000\u02c2\u02c3\u0005Z\u0000\u0000\u02c3\u02c4\u00056\u0000\u0000"+
		"\u02c4\u02c5\u0007\u0001\u0000\u0000\u02c5\u02c6\u0005[\u0000\u0000\u02c6"+
		"{\u0001\u0000\u0000\u0000\u02c7\u02d1\u0003\u000e\u0007\u0000\u02c8\u02d1"+
		"\u0003\u0080@\u0000\u02c9\u02d1\u0003\u0082A\u0000\u02ca\u02d1\u0003\u0084"+
		"B\u0000\u02cb\u02d1\u0003\u0086C\u0000\u02cc\u02d1\u0003~?\u0000\u02cd"+
		"\u02d1\u0003\u0088D\u0000\u02ce\u02d1\u0003\u008aE\u0000\u02cf\u02d1\u0003"+
		"\u008cF\u0000\u02d0\u02c7\u0001\u0000\u0000\u0000\u02d0\u02c8\u0001\u0000"+
		"\u0000\u0000\u02d0\u02c9\u0001\u0000\u0000\u0000\u02d0\u02ca\u0001\u0000"+
		"\u0000\u0000\u02d0\u02cb\u0001\u0000\u0000\u0000\u02d0\u02cc\u0001\u0000"+
		"\u0000\u0000\u02d0\u02cd\u0001\u0000\u0000\u0000\u02d0\u02ce\u0001\u0000"+
		"\u0000\u0000\u02d0\u02cf\u0001\u0000\u0000\u0000\u02d1}\u0001\u0000\u0000"+
		"\u0000\u02d2\u02d3\u0005Z\u0000\u0000\u02d3\u02d4\u0003b1\u0000\u02d4"+
		"\u02d5\u0003d2\u0000\u02d5\u02da\u0003\u00c8d\u0000\u02d6\u02d8\u0003"+
		"\u00a0P\u0000\u02d7\u02d9\u0003\u00a0P\u0000\u02d8\u02d7\u0001\u0000\u0000"+
		"\u0000\u02d8\u02d9\u0001\u0000\u0000\u0000\u02d9\u02db\u0001\u0000\u0000"+
		"\u0000\u02da\u02d6\u0001\u0000\u0000\u0000\u02da\u02db\u0001\u0000\u0000"+
		"\u0000\u02db\u02dc\u0001\u0000\u0000\u0000\u02dc\u02dd\u0005[\u0000\u0000"+
		"\u02dd\u007f\u0001\u0000\u0000\u0000\u02de\u02df\u0005Z\u0000\u0000\u02df"+
		"\u02e6\u00057\u0000\u0000\u02e0\u02e7\u0003\u0096K\u0000\u02e1\u02e3\u0003"+
		"|>\u0000\u02e2\u02e1\u0001\u0000\u0000\u0000\u02e3\u02e4\u0001\u0000\u0000"+
		"\u0000\u02e4\u02e5\u0001\u0000\u0000\u0000\u02e4\u02e2\u0001\u0000\u0000"+
		"\u0000\u02e5\u02e7\u0001\u0000\u0000\u0000\u02e6\u02e0\u0001\u0000\u0000"+
		"\u0000\u02e6\u02e2\u0001\u0000\u0000\u0000\u02e7\u02e8\u0001\u0000\u0000"+
		"\u0000\u02e8\u02e9\u0005[\u0000\u0000\u02e9\u0081\u0001\u0000\u0000\u0000"+
		"\u02ea\u02eb\u0005Z\u0000\u0000\u02eb\u02f2\u00058\u0000\u0000\u02ec\u02f3"+
		"\u0003\u0096K\u0000\u02ed\u02ef\u0003|>\u0000\u02ee\u02ed\u0001\u0000"+
		"\u0000\u0000\u02ef\u02f0\u0001\u0000\u0000\u0000\u02f0\u02f1\u0001\u0000"+
		"\u0000\u0000\u02f0\u02ee\u0001\u0000\u0000\u0000\u02f1\u02f3\u0001\u0000"+
		"\u0000\u0000\u02f2\u02ec\u0001\u0000\u0000\u0000\u02f2\u02ee\u0001\u0000"+
		"\u0000\u0000\u02f3\u02f4\u0001\u0000\u0000\u0000\u02f4\u02f5\u0005[\u0000"+
		"\u0000\u02f5\u0083\u0001\u0000\u0000\u0000\u02f6\u02f7\u0005Z\u0000\u0000"+
		"\u02f7\u02fe\u00059\u0000\u0000\u02f8\u02ff\u0003\u0096K\u0000\u02f9\u02fb"+
		"\u0003|>\u0000\u02fa\u02f9\u0001\u0000\u0000\u0000\u02fb\u02fc\u0001\u0000"+
		"\u0000\u0000\u02fc\u02fd\u0001\u0000\u0000\u0000\u02fc\u02fa\u0001\u0000"+
		"\u0000\u0000\u02fd\u02ff\u0001\u0000\u0000\u0000\u02fe\u02f8\u0001\u0000"+
		"\u0000\u0000\u02fe\u02fa\u0001\u0000\u0000\u0000\u02ff\u0300\u0001\u0000"+
		"\u0000\u0000\u0300\u0301\u0005[\u0000\u0000\u0301\u0085\u0001\u0000\u0000"+
		"\u0000\u0302\u0303\u0005Z\u0000\u0000\u0303\u0304\u0005:\u0000\u0000\u0304"+
		"\u0305\u0003t:\u0000\u0305\u0306\u0003\u0000\u0000\u0000\u0306\u0307\u0003"+
		"\u009aM\u0000\u0307\u0308\u0005[\u0000\u0000\u0308\u0087\u0001\u0000\u0000"+
		"\u0000\u0309\u030d\u0005Z\u0000\u0000\u030a\u030e\u0005*\u0000\u0000\u030b"+
		"\u030e\u0005+\u0000\u0000\u030c\u030e\u0003\u00a0P\u0000\u030d\u030a\u0001"+
		"\u0000\u0000\u0000\u030d\u030b\u0001\u0000\u0000\u0000\u030d\u030c\u0001"+
		"\u0000\u0000\u0000\u030e\u030f\u0001\u0000\u0000\u0000\u030f\u0310\u0003"+
		"\u008eG\u0000\u0310\u0311\u0005[\u0000\u0000\u0311\u0089\u0001\u0000\u0000"+
		"\u0000\u0312\u0313\u0005Z\u0000\u0000\u0313\u0314\u0007\u0005\u0000\u0000"+
		"\u0314\u0315\u0003\u00a0P\u0000\u0315\u0316\u0003|>\u0000\u0316\u0317"+
		"\u0005[\u0000\u0000\u0317\u008b\u0001\u0000\u0000\u0000\u0318\u0319\u0005"+
		"Z\u0000\u0000\u0319\u031a\u0005;\u0000\u0000\u031a\u031b\u0007\u0005\u0000"+
		"\u0000\u031b\u031c\u0003\u00a0P\u0000\u031c\u031d\u0003|>\u0000\u031d"+
		"\u031e\u0005,\u0000\u0000\u031e\u031f\u0003Z-\u0000\u031f\u0320\u0005"+
		"[\u0000\u0000\u0320\u008d\u0001\u0000\u0000\u0000\u0321\u0328\u0003\u0094"+
		"J\u0000\u0322\u0328\u0003\u0092I\u0000\u0323\u0328\u0003\u0090H\u0000"+
		"\u0324\u0328\u0003\u0096K\u0000\u0325\u0328\u0003\u0010\b\u0000\u0326"+
		"\u0328\u0003\u0098L\u0000\u0327\u0321\u0001\u0000\u0000\u0000\u0327\u0322"+
		"\u0001\u0000\u0000\u0000\u0327\u0323\u0001\u0000\u0000\u0000\u0327\u0324"+
		"\u0001\u0000\u0000\u0000\u0327\u0325\u0001\u0000\u0000\u0000\u0327\u0326"+
		"\u0001\u0000\u0000\u0000\u0328\u008f\u0001\u0000\u0000\u0000\u0329\u032a"+
		"\u0005Z\u0000\u0000\u032a\u032b\u0005<\u0000\u0000\u032b\u032c\u0007\u0006"+
		"\u0000\u0000\u032c\u032d\u0003\u00a0P\u0000\u032d\u032e\u0003|>\u0000"+
		"\u032e\u032f\u0005,\u0000\u0000\u032f\u0330\u0003Z-\u0000\u0330\u0331"+
		"\u0005[\u0000\u0000\u0331\u0091\u0001\u0000\u0000\u0000\u0332\u0333\u0005"+
		"Z\u0000\u0000\u0333\u0334\u0005>\u0000\u0000\u0334\u0338\u0003|>\u0000"+
		"\u0335\u0336\u0003\u009cN\u0000\u0336\u0337\u0003\u00a0P\u0000\u0337\u0339"+
		"\u0001\u0000\u0000\u0000\u0338\u0335\u0001\u0000\u0000\u0000\u0338\u0339"+
		"\u0001\u0000\u0000\u0000\u0339\u033a\u0001\u0000\u0000\u0000\u033a\u033b"+
		"\u0005[\u0000\u0000\u033b\u0093\u0001\u0000\u0000\u0000\u033c\u033d\u0005"+
		"Z\u0000\u0000\u033d\u033e\u0005?\u0000\u0000\u033e\u0345\u0003\u00c8d"+
		"\u0000\u033f\u0346\u0003\u0096K\u0000\u0340\u0342\u0003|>\u0000\u0341"+
		"\u0340\u0001\u0000\u0000\u0000\u0342\u0343\u0001\u0000\u0000\u0000\u0343"+
		"\u0344\u0001\u0000\u0000\u0000\u0343\u0341\u0001\u0000\u0000\u0000\u0344"+
		"\u0346\u0001\u0000\u0000\u0000\u0345\u033f\u0001\u0000\u0000\u0000\u0345"+
		"\u0341\u0001\u0000\u0000\u0000\u0346\u0347\u0001\u0000\u0000\u0000\u0347"+
		"\u0348\u0005[\u0000\u0000\u0348\u0095\u0001\u0000\u0000\u0000\u0349\u034a"+
		"\u0005Z\u0000\u0000\u034a\u034b\u0005\u0011\u0000\u0000\u034b\u034c\u0003"+
		"t:\u0000\u034c\u034d\u0003\u0000\u0000\u0000\u034d\u034e\u0003|>\u0000"+
		"\u034e\u034f\u0005[\u0000\u0000\u034f\u0097\u0001\u0000\u0000\u0000\u0350"+
		"\u0351\u0005Z\u0000\u0000\u0351\u0352\u0005@\u0000\u0000\u0352\u0353\u0003"+
		"b1\u0000\u0353\u0354\u0003d2\u0000\u0354\u0355\u0003\u00c8d\u0000\u0355"+
		"\u0356\u0005[\u0000\u0000\u0356\u0099\u0001\u0000\u0000\u0000\u0357\u0375"+
		"\u0005Z\u0000\u0000\u0358\u0359\u0005T\u0000\u0000\u0359\u035b\u0003\u009a"+
		"M\u0000\u035a\u035c\u0003\u009aM\u0000\u035b\u035a\u0001\u0000\u0000\u0000"+
		"\u035c\u035d\u0001\u0000\u0000\u0000\u035d\u035e\u0001\u0000\u0000\u0000"+
		"\u035d\u035b\u0001\u0000\u0000\u0000\u035e\u0376\u0001\u0000\u0000\u0000"+
		"\u035f\u0360\u0003\u009cN\u0000\u0360\u0361\u0003\u00a0P\u0000\u0361\u0362"+
		"\u0003\u00a0P\u0000\u0362\u0376\u0001\u0000\u0000\u0000\u0363\u0364\u0005"+
		"V\u0000\u0000\u0364\u0365\u0003\u00c8d\u0000\u0365\u0366\u0003\u00c8d"+
		"\u0000\u0366\u0376\u0001\u0000\u0000\u0000\u0367\u0368\u0005V\u0000\u0000"+
		"\u0368\u0369\u0003\\.\u0000\u0369\u036a\u0003\\.\u0000\u036a\u0376\u0001"+
		"\u0000\u0000\u0000\u036b\u036c\u0005W\u0000\u0000\u036c\u0376\u0003\u009a"+
		"M\u0000\u036d\u036e\u0005V\u0000\u0000\u036e\u036f\u0003h4\u0000\u036f"+
		"\u0370\u0003h4\u0000\u0370\u0376\u0001\u0000\u0000\u0000\u0371\u0372\u0005"+
		"V\u0000\u0000\u0372\u0373\u0003j5\u0000\u0373\u0374\u0003j5\u0000\u0374"+
		"\u0376\u0001\u0000\u0000\u0000\u0375\u0358\u0001\u0000\u0000\u0000\u0375"+
		"\u035f\u0001\u0000\u0000\u0000\u0375\u0363\u0001\u0000\u0000\u0000\u0375"+
		"\u0367\u0001\u0000\u0000\u0000\u0375\u036b\u0001\u0000\u0000\u0000\u0375"+
		"\u036d\u0001\u0000\u0000\u0000\u0375\u0371\u0001\u0000\u0000\u0000\u0376"+
		"\u0377\u0001\u0000\u0000\u0000\u0377\u0378\u0005[\u0000\u0000\u0378\u037b"+
		"\u0001\u0000\u0000\u0000\u0379\u037b\u0003\u009eO\u0000\u037a\u0357\u0001"+
		"\u0000\u0000\u0000\u037a\u0379\u0001\u0000\u0000\u0000\u037b\u009b\u0001"+
		"\u0000\u0000\u0000\u037c\u037d\u0007\u0007\u0000\u0000\u037d\u009d\u0001"+
		"\u0000\u0000\u0000\u037e\u037f\u0005Z\u0000\u0000\u037f\u0380\u0007\u0002"+
		"\u0000\u0000\u0380\u0381\u0003t:\u0000\u0381\u0382\u0003\u0000\u0000\u0000"+
		"\u0382\u0383\u0003\u009aM\u0000\u0383\u0384\u0005[\u0000\u0000\u0384\u009f"+
		"\u0001\u0000\u0000\u0000\u0385\u039a\u0003\b\u0004\u0000\u0386\u039a\u0003"+
		"\u00be_\u0000\u0387\u039a\u0003\u00aeW\u0000\u0388\u039a\u0003\u00b0X"+
		"\u0000\u0389\u039a\u0003\u00b2Y\u0000\u038a\u039a\u0003\u00acV\u0000\u038b"+
		"\u039a\u0003\u00b4Z\u0000\u038c\u039a\u0003\u00b6[\u0000\u038d\u039a\u0003"+
		"\u00b8\\\u0000\u038e\u039a\u0003\u00ba]\u0000\u038f\u039a\u0003\u00bc"+
		"^\u0000\u0390\u039a\u0003\u00a4R\u0000\u0391\u039a\u0003\u00c2a\u0000"+
		"\u0392\u039a\u0003\u00aaU\u0000\u0393\u039a\u0003\u00c4b\u0000\u0394\u039a"+
		"\u0003\u00c6c\u0000\u0395\u039a\u0003\u00c0`\u0000\u0396\u039a\u0003\u00a6"+
		"S\u0000\u0397\u039a\u0003\u00a8T\u0000\u0398\u039a\u0003\u00a2Q\u0000"+
		"\u0399\u0385\u0001\u0000\u0000\u0000\u0399\u0386\u0001\u0000\u0000\u0000"+
		"\u0399\u0387\u0001\u0000\u0000\u0000\u0399\u0388\u0001\u0000\u0000\u0000"+
		"\u0399\u0389\u0001\u0000\u0000\u0000\u0399\u038a\u0001\u0000\u0000\u0000"+
		"\u0399\u038b\u0001\u0000\u0000\u0000\u0399\u038c\u0001\u0000\u0000\u0000"+
		"\u0399\u038d\u0001\u0000\u0000\u0000\u0399\u038e\u0001\u0000\u0000\u0000"+
		"\u0399\u038f\u0001\u0000\u0000\u0000\u0399\u0390\u0001\u0000\u0000\u0000"+
		"\u0399\u0391\u0001\u0000\u0000\u0000\u0399\u0392\u0001\u0000\u0000\u0000"+
		"\u0399\u0393\u0001\u0000\u0000\u0000\u0399\u0394\u0001\u0000\u0000\u0000"+
		"\u0399\u0395\u0001\u0000\u0000\u0000\u0399\u0396\u0001\u0000\u0000\u0000"+
		"\u0399\u0397\u0001\u0000\u0000\u0000\u0399\u0398\u0001\u0000\u0000\u0000"+
		"\u039a\u00a1\u0001\u0000\u0000\u0000\u039b\u039d\u0005X\u0000\u0000\u039c"+
		"\u039b\u0001\u0000\u0000\u0000\u039d\u039e\u0001\u0000\u0000\u0000\u039e"+
		"\u039c\u0001\u0000\u0000\u0000\u039e\u039f\u0001\u0000\u0000\u0000\u039f"+
		"\u00a3\u0001\u0000\u0000\u0000\u03a0\u03a1\u0005Z\u0000\u0000\u03a1\u03a2"+
		"\u0005A\u0000\u0000\u03a2\u03a3\u0003|>\u0000\u03a3\u03a4\u0005,\u0000"+
		"\u0000\u03a4\u03a5\u0003Z-\u0000\u03a5\u03a6\u0005[\u0000\u0000\u03a6"+
		"\u00a5\u0001\u0000\u0000\u0000\u03a7\u03a8\u0005Z\u0000\u0000\u03a8\u03a9"+
		"\u0005B\u0000\u0000\u03a9\u03aa\u0003|>\u0000\u03aa\u03ab\u0005,\u0000"+
		"\u0000\u03ab\u03ac\u0003Z-\u0000\u03ac\u03ad\u0005[\u0000\u0000\u03ad"+
		"\u00a7\u0001\u0000\u0000\u0000\u03ae\u03af\u0005Z\u0000\u0000\u03af\u03b0"+
		"\u0005C\u0000\u0000\u03b0\u03b1\u0003|>\u0000\u03b1\u03b2\u0005,\u0000"+
		"\u0000\u03b2\u03b3\u0003Z-\u0000\u03b3\u03b4\u0005[\u0000\u0000\u03b4"+
		"\u00a9\u0001\u0000\u0000\u0000\u03b5\u03b6\u0005Z\u0000\u0000\u03b6\u03b7"+
		"\u0005D\u0000\u0000\u03b7\u03b8\u0003\\.\u0000\u03b8\u03b9\u0005,\u0000"+
		"\u0000\u03b9\u03ba\u0003Z-\u0000\u03ba\u03bb\u0005[\u0000\u0000\u03bb"+
		"\u00ab\u0001\u0000\u0000\u0000\u03bc\u03bd\u0005Z\u0000\u0000\u03bd\u03be"+
		"\u0005E\u0000\u0000\u03be\u03c0\u0003\u00a0P\u0000\u03bf\u03c1\u0003\u00a0"+
		"P\u0000\u03c0\u03bf\u0001\u0000\u0000\u0000\u03c1\u03c2\u0001\u0000\u0000"+
		"\u0000\u03c2\u03c3\u0001\u0000\u0000\u0000\u03c2\u03c0\u0001\u0000\u0000"+
		"\u0000\u03c3\u03c4\u0001\u0000\u0000\u0000\u03c4\u03c5\u0005[\u0000\u0000"+
		"\u03c5\u00ad\u0001\u0000\u0000\u0000\u03c6\u03c7\u0005Z\u0000\u0000\u03c7"+
		"\u03c8\u0005F\u0000\u0000\u03c8\u03ca\u0003\u00a0P\u0000\u03c9\u03cb\u0003"+
		"\u00a0P\u0000\u03ca\u03c9\u0001\u0000\u0000\u0000\u03cb\u03cc\u0001\u0000"+
		"\u0000\u0000\u03cc\u03cd\u0001\u0000\u0000\u0000\u03cc\u03ca\u0001\u0000"+
		"\u0000\u0000\u03cd\u03ce\u0001\u0000\u0000\u0000\u03ce\u03cf\u0005[\u0000"+
		"\u0000\u03cf\u00af\u0001\u0000\u0000\u0000\u03d0\u03d1\u0005Z\u0000\u0000"+
		"\u03d1\u03d2\u0005G\u0000\u0000\u03d2\u03d3\u0003\u00a0P\u0000\u03d3\u03d4"+
		"\u0003\u00a0P\u0000\u03d4\u03d5\u0005[\u0000\u0000\u03d5\u00b1\u0001\u0000"+
		"\u0000\u0000\u03d6\u03d7\u0005Z\u0000\u0000\u03d7\u03d8\u0005H\u0000\u0000"+
		"\u03d8\u03d9\u0003\u00a0P\u0000\u03d9\u03da\u0003\u00a0P\u0000\u03da\u03db"+
		"\u0005[\u0000\u0000\u03db\u00b3\u0001\u0000\u0000\u0000\u03dc\u03dd\u0005"+
		"Z\u0000\u0000\u03dd\u03de\u0005I\u0000\u0000\u03de\u03df\u0003\u00a0P"+
		"\u0000\u03df\u03e0\u0003\u00a0P\u0000\u03e0\u03e1\u0005[\u0000\u0000\u03e1"+
		"\u00b5\u0001\u0000\u0000\u0000\u03e2\u03e3\u0005Z\u0000\u0000\u03e3\u03e4"+
		"\u0005J\u0000\u0000\u03e4\u03e5\u0003\u00a0P\u0000\u03e5\u03e6\u0003\u00a0"+
		"P\u0000\u03e6\u03e7\u0005[\u0000\u0000\u03e7\u00b7\u0001\u0000\u0000\u0000"+
		"\u03e8\u03e9\u0005Z\u0000\u0000\u03e9\u03ea\u0005K\u0000\u0000\u03ea\u03eb"+
		"\u0003\u00a0P\u0000\u03eb\u03ec\u0005[\u0000\u0000\u03ec\u00b9\u0001\u0000"+
		"\u0000\u0000\u03ed\u03ee\u0005Z\u0000\u0000\u03ee\u03ef\u0005L\u0000\u0000"+
		"\u03ef\u03f0\u0003\u00a0P\u0000\u03f0\u03f1\u0005[\u0000\u0000\u03f1\u00bb"+
		"\u0001\u0000\u0000\u0000\u03f2\u03f3\u0005Z\u0000\u0000\u03f3\u03f4\u0005"+
		"M\u0000\u0000\u03f4\u03f7\u0003\u00a0P\u0000\u03f5\u03f6\u00055\u0000"+
		"\u0000\u03f6\u03f8\u0003\u00a0P\u0000\u03f7\u03f5\u0001\u0000\u0000\u0000"+
		"\u03f7\u03f8\u0001\u0000\u0000\u0000\u03f8\u03f9\u0001\u0000\u0000\u0000"+
		"\u03f9\u03fa\u0005[\u0000\u0000\u03fa\u00bd\u0001\u0000\u0000\u0000\u03fb"+
		"\u03fc\u0005Z\u0000\u0000\u03fc\u03fd\u0005N\u0000\u0000\u03fd\u03fe\u0003"+
		"t:\u0000\u03fe\u03ff\u0005[\u0000\u0000\u03ff\u00bf\u0001\u0000\u0000"+
		"\u0000\u0400\u0401\u0005Z\u0000\u0000\u0401\u0402\u0005\u0011\u0000\u0000"+
		"\u0402\u0403\u0003t:\u0000\u0403\u0404\u0003\u0000\u0000\u0000\u0404\u0405"+
		"\u0003\u00c2a\u0000\u0405\u0406\u0005[\u0000\u0000\u0406\u00c1\u0001\u0000"+
		"\u0000\u0000\u0407\u040b\u0005Z\u0000\u0000\u0408\u040c\u0003\u0004\u0002"+
		"\u0000\u0409\u040c\u0005\u0002\u0000\u0000\u040a\u040c\u0003f3\u0000\u040b"+
		"\u0408\u0001\u0000\u0000\u0000\u040b\u0409\u0001\u0000\u0000\u0000\u040b"+
		"\u040a\u0001\u0000\u0000\u0000\u040c\u040d\u0001\u0000\u0000\u0000\u040d"+
		"\u040e\u0005O\u0000\u0000\u040e\u040f\u0003\u00c8d\u0000\u040f\u0410\u0005"+
		"[\u0000\u0000\u0410\u00c3\u0001\u0000\u0000\u0000\u0411\u0412\u0005Z\u0000"+
		"\u0000\u0412\u0415\u0005P\u0000\u0000\u0413\u0416\u0003\u0006\u0003\u0000"+
		"\u0414\u0416\u0003h4\u0000\u0415\u0413\u0001\u0000\u0000\u0000\u0415\u0414"+
		"\u0001\u0000\u0000\u0000\u0416\u0417\u0001\u0000\u0000\u0000\u0417\u0418"+
		"\u0005[\u0000\u0000\u0418\u00c5\u0001\u0000\u0000\u0000\u0419\u041a\u0005"+
		"Z\u0000\u0000\u041a\u041d\u0005Q\u0000\u0000\u041b\u041e\u0003\u0014\n"+
		"\u0000\u041c\u041e\u0003j5\u0000\u041d\u041b\u0001\u0000\u0000\u0000\u041d"+
		"\u041c\u0001\u0000\u0000\u0000\u041e\u041f\u0001\u0000\u0000\u0000\u041f"+
		"\u0420\u0005[\u0000\u0000\u0420\u00c7\u0001\u0000\u0000\u0000\u0421\u0426"+
		"\u0003\u00ceg\u0000\u0422\u0426\u0003\u00cae\u0000\u0423\u0426\u0003\u0002"+
		"\u0001\u0000\u0424\u0426\u0003\u00ccf\u0000\u0425\u0421\u0001\u0000\u0000"+
		"\u0000\u0425\u0422\u0001\u0000\u0000\u0000\u0425\u0423\u0001\u0000\u0000"+
		"\u0000\u0425\u0424\u0001\u0000\u0000\u0000\u0426\u00c9\u0001\u0000\u0000"+
		"\u0000\u0427\u042b\u0005Z\u0000\u0000\u0428\u042c\u0003\u0004\u0002\u0000"+
		"\u0429\u042c\u0005\u0002\u0000\u0000\u042a\u042c\u0003f3\u0000\u042b\u0428"+
		"\u0001\u0000\u0000\u0000\u042b\u0429\u0001\u0000\u0000\u0000\u042b\u042a"+
		"\u0001\u0000\u0000\u0000\u042c\u042d\u0001\u0000\u0000\u0000\u042d\u042e"+
		"\u0005R\u0000\u0000\u042e\u042f\u0003\u00c8d\u0000\u042f\u0430\u0005["+
		"\u0000\u0000\u0430\u00cb\u0001\u0000\u0000\u0000\u0431\u0432\u0005Z\u0000"+
		"\u0000\u0432\u0433\u0005S\u0000\u0000\u0433\u0434\u0003\u00c8d\u0000\u0434"+
		"\u0435\u0003\\.\u0000\u0435\u0436\u0005[\u0000\u0000\u0436\u00cd\u0001"+
		"\u0000\u0000\u0000\u0437\u0439\u0005Y\u0000\u0000\u0438\u0437\u0001\u0000"+
		"\u0000\u0000\u0439\u043a\u0001\u0000\u0000\u0000\u043a\u0438\u0001\u0000"+
		"\u0000\u0000\u043a\u043b\u0001\u0000\u0000\u0000\u043b\u00cf\u0001\u0000"+
		"\u0000\u0000L\u00f6\u00fc\u00fe\u010d\u0112\u0118\u0126\u012b\u012f\u0131"+
		"\u0140\u014b\u0152\u015a\u0161\u016f\u017f\u0194\u0199\u01a7\u01b0\u01b7"+
		"\u01bf\u01c9\u01d3\u01da\u01e5\u01ef\u01f7\u0206\u0213\u0218\u0225\u0234"+
		"\u0242\u0246\u024c\u0259\u025e\u0272\u0278\u0280\u0288\u028e\u0299\u02a1"+
		"\u02ad\u02b5\u02d0\u02d8\u02da\u02e4\u02e6\u02f0\u02f2\u02fc\u02fe\u030d"+
		"\u0327\u0338\u0343\u0345\u035d\u0375\u037a\u0399\u039e\u03c2\u03cc\u03f7"+
		"\u040b\u0415\u041d\u0425\u042b\u043a";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}