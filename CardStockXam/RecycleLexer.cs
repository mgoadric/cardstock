//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Recycle.g4 by ANTLR 4.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5")]
[System.CLSCompliant(false)]
public partial class RecycleLexer : Lexer {
	public const int
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
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"T__25", "T__26", "T__27", "T__28", "T__29", "T__30", "T__31", "T__32", 
		"T__33", "T__34", "T__35", "T__36", "T__37", "T__38", "T__39", "T__40", 
		"T__41", "T__42", "T__43", "T__44", "T__45", "T__46", "T__47", "T__48", 
		"T__49", "T__50", "T__51", "T__52", "T__53", "T__54", "T__55", "T__56", 
		"T__57", "T__58", "T__59", "T__60", "T__61", "T__62", "T__63", "T__64", 
		"T__65", "T__66", "T__67", "T__68", "T__69", "BOOLOP", "COMPOP", "EQOP", 
		"UNOP", "INTNUM", "LETT", "OPEN", "CLOSE", "WS", "ANY"
	};


	public RecycleLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'''", "'game'", "'setup'", "'stage'", "'player'", "'team'", "'scoring'", 
		"'min'", "'max'", "'end'", "'choice'", "'do'", "'any'", "'all'", "'let'", 
		"'declare'", "'create'", "'players'", "'teams'", "'deck'", "','", "'set'", 
		"'cycle'", "'next'", "'current'", "'previous'", "'inc'", "'dec'", "'move'", 
		"'remember'", "'forget'", "'shuffle'", "'turn'", "'pass'", "'repeat'", 
		"'top'", "'bottom'", "'actual'", "'sto'", "'points'", "'str'", "'tuples'", 
		"'using'", "'partition'", "'vloc'", "'iloc'", "'hloc'", "'mem'", "'owner'", 
		"'other'", "'range'", "'..'", "'filter'", "'cardatt'", "'+'", "'*'", "'-'", 
		"'%'", "'//'", "'^'", "'tri'", "'fib'", "'random'", "'size'", "'sort'", 
		"'union'", "'intersect'", "'disjunction'", "'sum'", "'score'", null, null, 
		null, "'not'", null, null, "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, "BOOLOP", 
		"COMPOP", "EQOP", "UNOP", "INTNUM", "LETT", "OPEN", "CLOSE", "WS", "ANY"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Recycle.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2R\x24A\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t)\x4*\t"+
		"*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31\x4\x32"+
		"\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x4\x37\t\x37"+
		"\x4\x38\t\x38\x4\x39\t\x39\x4:\t:\x4;\t;\x4<\t<\x4=\t=\x4>\t>\x4?\t?\x4"+
		"@\t@\x4\x41\t\x41\x4\x42\t\x42\x4\x43\t\x43\x4\x44\t\x44\x4\x45\t\x45"+
		"\x4\x46\t\x46\x4G\tG\x4H\tH\x4I\tI\x4J\tJ\x4K\tK\x4L\tL\x4M\tM\x4N\tN"+
		"\x4O\tO\x4P\tP\x4Q\tQ\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\b"+
		"\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n\x3\n"+
		"\x3\n\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r"+
		"\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3"+
		"\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x13\x3\x13\x3\x13\x3"+
		"\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3\x17\x3\x17\x3"+
		"\x17\x3\x17\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x19\x3\x19\x3"+
		"\x19\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3"+
		"\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3"+
		"\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3"+
		"\x1E\x3\x1E\x3\x1E\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3"+
		"\x1F\x3\x1F\x3 \x3 \x3 \x3 \x3 \x3 \x3 \x3!\x3!\x3!\x3!\x3!\x3!\x3!\x3"+
		"!\x3\"\x3\"\x3\"\x3\"\x3\"\x3#\x3#\x3#\x3#\x3#\x3$\x3$\x3$\x3$\x3$\x3"+
		"$\x3$\x3%\x3%\x3%\x3%\x3&\x3&\x3&\x3&\x3&\x3&\x3&\x3\'\x3\'\x3\'\x3\'"+
		"\x3\'\x3\'\x3\'\x3(\x3(\x3(\x3(\x3)\x3)\x3)\x3)\x3)\x3)\x3)\x3*\x3*\x3"+
		"*\x3*\x3+\x3+\x3+\x3+\x3+\x3+\x3+\x3,\x3,\x3,\x3,\x3,\x3,\x3-\x3-\x3-"+
		"\x3-\x3-\x3-\x3-\x3-\x3-\x3-\x3.\x3.\x3.\x3.\x3.\x3/\x3/\x3/\x3/\x3/\x3"+
		"\x30\x3\x30\x3\x30\x3\x30\x3\x30\x3\x31\x3\x31\x3\x31\x3\x31\x3\x32\x3"+
		"\x32\x3\x32\x3\x32\x3\x32\x3\x32\x3\x33\x3\x33\x3\x33\x3\x33\x3\x33\x3"+
		"\x33\x3\x34\x3\x34\x3\x34\x3\x34\x3\x34\x3\x34\x3\x35\x3\x35\x3\x35\x3"+
		"\x36\x3\x36\x3\x36\x3\x36\x3\x36\x3\x36\x3\x36\x3\x37\x3\x37\x3\x37\x3"+
		"\x37\x3\x37\x3\x37\x3\x37\x3\x37\x3\x38\x3\x38\x3\x39\x3\x39\x3:\x3:\x3"+
		";\x3;\x3<\x3<\x3<\x3=\x3=\x3>\x3>\x3>\x3>\x3?\x3?\x3?\x3?\x3@\x3@\x3@"+
		"\x3@\x3@\x3@\x3@\x3\x41\x3\x41\x3\x41\x3\x41\x3\x41\x3\x42\x3\x42\x3\x42"+
		"\x3\x42\x3\x42\x3\x43\x3\x43\x3\x43\x3\x43\x3\x43\x3\x43\x3\x44\x3\x44"+
		"\x3\x44\x3\x44\x3\x44\x3\x44\x3\x44\x3\x44\x3\x44\x3\x44\x3\x45\x3\x45"+
		"\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45\x3\x45"+
		"\x3\x46\x3\x46\x3\x46\x3\x46\x3G\x3G\x3G\x3G\x3G\x3G\x3H\x3H\x3H\x3H\x3"+
		"H\x5H\x227\nH\x3I\x3I\x3I\x3I\x3I\x5I\x22E\nI\x3J\x3J\x3J\x3J\x5J\x234"+
		"\nJ\x3K\x3K\x3K\x3K\x3L\x3L\x3M\x3M\x3N\x3N\x3O\x3O\x3P\x6P\x243\nP\r"+
		"P\xEP\x244\x3P\x3P\x3Q\x3Q\x2\x2R\x3\x3\x5\x4\a\x5\t\x6\v\a\r\b\xF\t\x11"+
		"\n\x13\v\x15\f\x17\r\x19\xE\x1B\xF\x1D\x10\x1F\x11!\x12#\x13%\x14\'\x15"+
		")\x16+\x17-\x18/\x19\x31\x1A\x33\x1B\x35\x1C\x37\x1D\x39\x1E;\x1F= ?!"+
		"\x41\"\x43#\x45$G%I&K\'M(O)Q*S+U,W-Y.[/]\x30_\x31\x61\x32\x63\x33\x65"+
		"\x34g\x35i\x36k\x37m\x38o\x39q:s;u<w=y>{?}@\x7F\x41\x81\x42\x83\x43\x85"+
		"\x44\x87\x45\x89\x46\x8BG\x8DH\x8FI\x91J\x93K\x95L\x97M\x99N\x9BO\x9D"+
		"P\x9FQ\xA1R\x3\x2\x6\x4\x2>>@@\x3\x2\x32;\x3\x2\x43\\\x5\x2\v\f\xF\xF"+
		"\"\"\x24E\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3"+
		"\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3"+
		"\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2"+
		"\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2"+
		"\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2"+
		")\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3"+
		"\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2"+
		"\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41"+
		"\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x2"+
		"I\x3\x2\x2\x2\x2K\x3\x2\x2\x2\x2M\x3\x2\x2\x2\x2O\x3\x2\x2\x2\x2Q\x3\x2"+
		"\x2\x2\x2S\x3\x2\x2\x2\x2U\x3\x2\x2\x2\x2W\x3\x2\x2\x2\x2Y\x3\x2\x2\x2"+
		"\x2[\x3\x2\x2\x2\x2]\x3\x2\x2\x2\x2_\x3\x2\x2\x2\x2\x61\x3\x2\x2\x2\x2"+
		"\x63\x3\x2\x2\x2\x2\x65\x3\x2\x2\x2\x2g\x3\x2\x2\x2\x2i\x3\x2\x2\x2\x2"+
		"k\x3\x2\x2\x2\x2m\x3\x2\x2\x2\x2o\x3\x2\x2\x2\x2q\x3\x2\x2\x2\x2s\x3\x2"+
		"\x2\x2\x2u\x3\x2\x2\x2\x2w\x3\x2\x2\x2\x2y\x3\x2\x2\x2\x2{\x3\x2\x2\x2"+
		"\x2}\x3\x2\x2\x2\x2\x7F\x3\x2\x2\x2\x2\x81\x3\x2\x2\x2\x2\x83\x3\x2\x2"+
		"\x2\x2\x85\x3\x2\x2\x2\x2\x87\x3\x2\x2\x2\x2\x89\x3\x2\x2\x2\x2\x8B\x3"+
		"\x2\x2\x2\x2\x8D\x3\x2\x2\x2\x2\x8F\x3\x2\x2\x2\x2\x91\x3\x2\x2\x2\x2"+
		"\x93\x3\x2\x2\x2\x2\x95\x3\x2\x2\x2\x2\x97\x3\x2\x2\x2\x2\x99\x3\x2\x2"+
		"\x2\x2\x9B\x3\x2\x2\x2\x2\x9D\x3\x2\x2\x2\x2\x9F\x3\x2\x2\x2\x2\xA1\x3"+
		"\x2\x2\x2\x3\xA3\x3\x2\x2\x2\x5\xA5\x3\x2\x2\x2\a\xAA\x3\x2\x2\x2\t\xB0"+
		"\x3\x2\x2\x2\v\xB6\x3\x2\x2\x2\r\xBD\x3\x2\x2\x2\xF\xC2\x3\x2\x2\x2\x11"+
		"\xCA\x3\x2\x2\x2\x13\xCE\x3\x2\x2\x2\x15\xD2\x3\x2\x2\x2\x17\xD6\x3\x2"+
		"\x2\x2\x19\xDD\x3\x2\x2\x2\x1B\xE0\x3\x2\x2\x2\x1D\xE4\x3\x2\x2\x2\x1F"+
		"\xE8\x3\x2\x2\x2!\xEC\x3\x2\x2\x2#\xF4\x3\x2\x2\x2%\xFB\x3\x2\x2\x2\'"+
		"\x103\x3\x2\x2\x2)\x109\x3\x2\x2\x2+\x10E\x3\x2\x2\x2-\x110\x3\x2\x2\x2"+
		"/\x114\x3\x2\x2\x2\x31\x11A\x3\x2\x2\x2\x33\x11F\x3\x2\x2\x2\x35\x127"+
		"\x3\x2\x2\x2\x37\x130\x3\x2\x2\x2\x39\x134\x3\x2\x2\x2;\x138\x3\x2\x2"+
		"\x2=\x13D\x3\x2\x2\x2?\x146\x3\x2\x2\x2\x41\x14D\x3\x2\x2\x2\x43\x155"+
		"\x3\x2\x2\x2\x45\x15A\x3\x2\x2\x2G\x15F\x3\x2\x2\x2I\x166\x3\x2\x2\x2"+
		"K\x16A\x3\x2\x2\x2M\x171\x3\x2\x2\x2O\x178\x3\x2\x2\x2Q\x17C\x3\x2\x2"+
		"\x2S\x183\x3\x2\x2\x2U\x187\x3\x2\x2\x2W\x18E\x3\x2\x2\x2Y\x194\x3\x2"+
		"\x2\x2[\x19E\x3\x2\x2\x2]\x1A3\x3\x2\x2\x2_\x1A8\x3\x2\x2\x2\x61\x1AD"+
		"\x3\x2\x2\x2\x63\x1B1\x3\x2\x2\x2\x65\x1B7\x3\x2\x2\x2g\x1BD\x3\x2\x2"+
		"\x2i\x1C3\x3\x2\x2\x2k\x1C6\x3\x2\x2\x2m\x1CD\x3\x2\x2\x2o\x1D5\x3\x2"+
		"\x2\x2q\x1D7\x3\x2\x2\x2s\x1D9\x3\x2\x2\x2u\x1DB\x3\x2\x2\x2w\x1DD\x3"+
		"\x2\x2\x2y\x1E0\x3\x2\x2\x2{\x1E2\x3\x2\x2\x2}\x1E6\x3\x2\x2\x2\x7F\x1EA"+
		"\x3\x2\x2\x2\x81\x1F1\x3\x2\x2\x2\x83\x1F6\x3\x2\x2\x2\x85\x1FB\x3\x2"+
		"\x2\x2\x87\x201\x3\x2\x2\x2\x89\x20B\x3\x2\x2\x2\x8B\x217\x3\x2\x2\x2"+
		"\x8D\x21B\x3\x2\x2\x2\x8F\x226\x3\x2\x2\x2\x91\x22D\x3\x2\x2\x2\x93\x233"+
		"\x3\x2\x2\x2\x95\x235\x3\x2\x2\x2\x97\x239\x3\x2\x2\x2\x99\x23B\x3\x2"+
		"\x2\x2\x9B\x23D\x3\x2\x2\x2\x9D\x23F\x3\x2\x2\x2\x9F\x242\x3\x2\x2\x2"+
		"\xA1\x248\x3\x2\x2\x2\xA3\xA4\a)\x2\x2\xA4\x4\x3\x2\x2\x2\xA5\xA6\ai\x2"+
		"\x2\xA6\xA7\a\x63\x2\x2\xA7\xA8\ao\x2\x2\xA8\xA9\ag\x2\x2\xA9\x6\x3\x2"+
		"\x2\x2\xAA\xAB\au\x2\x2\xAB\xAC\ag\x2\x2\xAC\xAD\av\x2\x2\xAD\xAE\aw\x2"+
		"\x2\xAE\xAF\ar\x2\x2\xAF\b\x3\x2\x2\x2\xB0\xB1\au\x2\x2\xB1\xB2\av\x2"+
		"\x2\xB2\xB3\a\x63\x2\x2\xB3\xB4\ai\x2\x2\xB4\xB5\ag\x2\x2\xB5\n\x3\x2"+
		"\x2\x2\xB6\xB7\ar\x2\x2\xB7\xB8\an\x2\x2\xB8\xB9\a\x63\x2\x2\xB9\xBA\a"+
		"{\x2\x2\xBA\xBB\ag\x2\x2\xBB\xBC\at\x2\x2\xBC\f\x3\x2\x2\x2\xBD\xBE\a"+
		"v\x2\x2\xBE\xBF\ag\x2\x2\xBF\xC0\a\x63\x2\x2\xC0\xC1\ao\x2\x2\xC1\xE\x3"+
		"\x2\x2\x2\xC2\xC3\au\x2\x2\xC3\xC4\a\x65\x2\x2\xC4\xC5\aq\x2\x2\xC5\xC6"+
		"\at\x2\x2\xC6\xC7\ak\x2\x2\xC7\xC8\ap\x2\x2\xC8\xC9\ai\x2\x2\xC9\x10\x3"+
		"\x2\x2\x2\xCA\xCB\ao\x2\x2\xCB\xCC\ak\x2\x2\xCC\xCD\ap\x2\x2\xCD\x12\x3"+
		"\x2\x2\x2\xCE\xCF\ao\x2\x2\xCF\xD0\a\x63\x2\x2\xD0\xD1\az\x2\x2\xD1\x14"+
		"\x3\x2\x2\x2\xD2\xD3\ag\x2\x2\xD3\xD4\ap\x2\x2\xD4\xD5\a\x66\x2\x2\xD5"+
		"\x16\x3\x2\x2\x2\xD6\xD7\a\x65\x2\x2\xD7\xD8\aj\x2\x2\xD8\xD9\aq\x2\x2"+
		"\xD9\xDA\ak\x2\x2\xDA\xDB\a\x65\x2\x2\xDB\xDC\ag\x2\x2\xDC\x18\x3\x2\x2"+
		"\x2\xDD\xDE\a\x66\x2\x2\xDE\xDF\aq\x2\x2\xDF\x1A\x3\x2\x2\x2\xE0\xE1\a"+
		"\x63\x2\x2\xE1\xE2\ap\x2\x2\xE2\xE3\a{\x2\x2\xE3\x1C\x3\x2\x2\x2\xE4\xE5"+
		"\a\x63\x2\x2\xE5\xE6\an\x2\x2\xE6\xE7\an\x2\x2\xE7\x1E\x3\x2\x2\x2\xE8"+
		"\xE9\an\x2\x2\xE9\xEA\ag\x2\x2\xEA\xEB\av\x2\x2\xEB \x3\x2\x2\x2\xEC\xED"+
		"\a\x66\x2\x2\xED\xEE\ag\x2\x2\xEE\xEF\a\x65\x2\x2\xEF\xF0\an\x2\x2\xF0"+
		"\xF1\a\x63\x2\x2\xF1\xF2\at\x2\x2\xF2\xF3\ag\x2\x2\xF3\"\x3\x2\x2\x2\xF4"+
		"\xF5\a\x65\x2\x2\xF5\xF6\at\x2\x2\xF6\xF7\ag\x2\x2\xF7\xF8\a\x63\x2\x2"+
		"\xF8\xF9\av\x2\x2\xF9\xFA\ag\x2\x2\xFA$\x3\x2\x2\x2\xFB\xFC\ar\x2\x2\xFC"+
		"\xFD\an\x2\x2\xFD\xFE\a\x63\x2\x2\xFE\xFF\a{\x2\x2\xFF\x100\ag\x2\x2\x100"+
		"\x101\at\x2\x2\x101\x102\au\x2\x2\x102&\x3\x2\x2\x2\x103\x104\av\x2\x2"+
		"\x104\x105\ag\x2\x2\x105\x106\a\x63\x2\x2\x106\x107\ao\x2\x2\x107\x108"+
		"\au\x2\x2\x108(\x3\x2\x2\x2\x109\x10A\a\x66\x2\x2\x10A\x10B\ag\x2\x2\x10B"+
		"\x10C\a\x65\x2\x2\x10C\x10D\am\x2\x2\x10D*\x3\x2\x2\x2\x10E\x10F\a.\x2"+
		"\x2\x10F,\x3\x2\x2\x2\x110\x111\au\x2\x2\x111\x112\ag\x2\x2\x112\x113"+
		"\av\x2\x2\x113.\x3\x2\x2\x2\x114\x115\a\x65\x2\x2\x115\x116\a{\x2\x2\x116"+
		"\x117\a\x65\x2\x2\x117\x118\an\x2\x2\x118\x119\ag\x2\x2\x119\x30\x3\x2"+
		"\x2\x2\x11A\x11B\ap\x2\x2\x11B\x11C\ag\x2\x2\x11C\x11D\az\x2\x2\x11D\x11E"+
		"\av\x2\x2\x11E\x32\x3\x2\x2\x2\x11F\x120\a\x65\x2\x2\x120\x121\aw\x2\x2"+
		"\x121\x122\at\x2\x2\x122\x123\at\x2\x2\x123\x124\ag\x2\x2\x124\x125\a"+
		"p\x2\x2\x125\x126\av\x2\x2\x126\x34\x3\x2\x2\x2\x127\x128\ar\x2\x2\x128"+
		"\x129\at\x2\x2\x129\x12A\ag\x2\x2\x12A\x12B\ax\x2\x2\x12B\x12C\ak\x2\x2"+
		"\x12C\x12D\aq\x2\x2\x12D\x12E\aw\x2\x2\x12E\x12F\au\x2\x2\x12F\x36\x3"+
		"\x2\x2\x2\x130\x131\ak\x2\x2\x131\x132\ap\x2\x2\x132\x133\a\x65\x2\x2"+
		"\x133\x38\x3\x2\x2\x2\x134\x135\a\x66\x2\x2\x135\x136\ag\x2\x2\x136\x137"+
		"\a\x65\x2\x2\x137:\x3\x2\x2\x2\x138\x139\ao\x2\x2\x139\x13A\aq\x2\x2\x13A"+
		"\x13B\ax\x2\x2\x13B\x13C\ag\x2\x2\x13C<\x3\x2\x2\x2\x13D\x13E\at\x2\x2"+
		"\x13E\x13F\ag\x2\x2\x13F\x140\ao\x2\x2\x140\x141\ag\x2\x2\x141\x142\a"+
		"o\x2\x2\x142\x143\a\x64\x2\x2\x143\x144\ag\x2\x2\x144\x145\at\x2\x2\x145"+
		">\x3\x2\x2\x2\x146\x147\ah\x2\x2\x147\x148\aq\x2\x2\x148\x149\at\x2\x2"+
		"\x149\x14A\ai\x2\x2\x14A\x14B\ag\x2\x2\x14B\x14C\av\x2\x2\x14C@\x3\x2"+
		"\x2\x2\x14D\x14E\au\x2\x2\x14E\x14F\aj\x2\x2\x14F\x150\aw\x2\x2\x150\x151"+
		"\ah\x2\x2\x151\x152\ah\x2\x2\x152\x153\an\x2\x2\x153\x154\ag\x2\x2\x154"+
		"\x42\x3\x2\x2\x2\x155\x156\av\x2\x2\x156\x157\aw\x2\x2\x157\x158\at\x2"+
		"\x2\x158\x159\ap\x2\x2\x159\x44\x3\x2\x2\x2\x15A\x15B\ar\x2\x2\x15B\x15C"+
		"\a\x63\x2\x2\x15C\x15D\au\x2\x2\x15D\x15E\au\x2\x2\x15E\x46\x3\x2\x2\x2"+
		"\x15F\x160\at\x2\x2\x160\x161\ag\x2\x2\x161\x162\ar\x2\x2\x162\x163\a"+
		"g\x2\x2\x163\x164\a\x63\x2\x2\x164\x165\av\x2\x2\x165H\x3\x2\x2\x2\x166"+
		"\x167\av\x2\x2\x167\x168\aq\x2\x2\x168\x169\ar\x2\x2\x169J\x3\x2\x2\x2"+
		"\x16A\x16B\a\x64\x2\x2\x16B\x16C\aq\x2\x2\x16C\x16D\av\x2\x2\x16D\x16E"+
		"\av\x2\x2\x16E\x16F\aq\x2\x2\x16F\x170\ao\x2\x2\x170L\x3\x2\x2\x2\x171"+
		"\x172\a\x63\x2\x2\x172\x173\a\x65\x2\x2\x173\x174\av\x2\x2\x174\x175\a"+
		"w\x2\x2\x175\x176\a\x63\x2\x2\x176\x177\an\x2\x2\x177N\x3\x2\x2\x2\x178"+
		"\x179\au\x2\x2\x179\x17A\av\x2\x2\x17A\x17B\aq\x2\x2\x17BP\x3\x2\x2\x2"+
		"\x17C\x17D\ar\x2\x2\x17D\x17E\aq\x2\x2\x17E\x17F\ak\x2\x2\x17F\x180\a"+
		"p\x2\x2\x180\x181\av\x2\x2\x181\x182\au\x2\x2\x182R\x3\x2\x2\x2\x183\x184"+
		"\au\x2\x2\x184\x185\av\x2\x2\x185\x186\at\x2\x2\x186T\x3\x2\x2\x2\x187"+
		"\x188\av\x2\x2\x188\x189\aw\x2\x2\x189\x18A\ar\x2\x2\x18A\x18B\an\x2\x2"+
		"\x18B\x18C\ag\x2\x2\x18C\x18D\au\x2\x2\x18DV\x3\x2\x2\x2\x18E\x18F\aw"+
		"\x2\x2\x18F\x190\au\x2\x2\x190\x191\ak\x2\x2\x191\x192\ap\x2\x2\x192\x193"+
		"\ai\x2\x2\x193X\x3\x2\x2\x2\x194\x195\ar\x2\x2\x195\x196\a\x63\x2\x2\x196"+
		"\x197\at\x2\x2\x197\x198\av\x2\x2\x198\x199\ak\x2\x2\x199\x19A\av\x2\x2"+
		"\x19A\x19B\ak\x2\x2\x19B\x19C\aq\x2\x2\x19C\x19D\ap\x2\x2\x19DZ\x3\x2"+
		"\x2\x2\x19E\x19F\ax\x2\x2\x19F\x1A0\an\x2\x2\x1A0\x1A1\aq\x2\x2\x1A1\x1A2"+
		"\a\x65\x2\x2\x1A2\\\x3\x2\x2\x2\x1A3\x1A4\ak\x2\x2\x1A4\x1A5\an\x2\x2"+
		"\x1A5\x1A6\aq\x2\x2\x1A6\x1A7\a\x65\x2\x2\x1A7^\x3\x2\x2\x2\x1A8\x1A9"+
		"\aj\x2\x2\x1A9\x1AA\an\x2\x2\x1AA\x1AB\aq\x2\x2\x1AB\x1AC\a\x65\x2\x2"+
		"\x1AC`\x3\x2\x2\x2\x1AD\x1AE\ao\x2\x2\x1AE\x1AF\ag\x2\x2\x1AF\x1B0\ao"+
		"\x2\x2\x1B0\x62\x3\x2\x2\x2\x1B1\x1B2\aq\x2\x2\x1B2\x1B3\ay\x2\x2\x1B3"+
		"\x1B4\ap\x2\x2\x1B4\x1B5\ag\x2\x2\x1B5\x1B6\at\x2\x2\x1B6\x64\x3\x2\x2"+
		"\x2\x1B7\x1B8\aq\x2\x2\x1B8\x1B9\av\x2\x2\x1B9\x1BA\aj\x2\x2\x1BA\x1BB"+
		"\ag\x2\x2\x1BB\x1BC\at\x2\x2\x1BC\x66\x3\x2\x2\x2\x1BD\x1BE\at\x2\x2\x1BE"+
		"\x1BF\a\x63\x2\x2\x1BF\x1C0\ap\x2\x2\x1C0\x1C1\ai\x2\x2\x1C1\x1C2\ag\x2"+
		"\x2\x1C2h\x3\x2\x2\x2\x1C3\x1C4\a\x30\x2\x2\x1C4\x1C5\a\x30\x2\x2\x1C5"+
		"j\x3\x2\x2\x2\x1C6\x1C7\ah\x2\x2\x1C7\x1C8\ak\x2\x2\x1C8\x1C9\an\x2\x2"+
		"\x1C9\x1CA\av\x2\x2\x1CA\x1CB\ag\x2\x2\x1CB\x1CC\at\x2\x2\x1CCl\x3\x2"+
		"\x2\x2\x1CD\x1CE\a\x65\x2\x2\x1CE\x1CF\a\x63\x2\x2\x1CF\x1D0\at\x2\x2"+
		"\x1D0\x1D1\a\x66\x2\x2\x1D1\x1D2\a\x63\x2\x2\x1D2\x1D3\av\x2\x2\x1D3\x1D4"+
		"\av\x2\x2\x1D4n\x3\x2\x2\x2\x1D5\x1D6\a-\x2\x2\x1D6p\x3\x2\x2\x2\x1D7"+
		"\x1D8\a,\x2\x2\x1D8r\x3\x2\x2\x2\x1D9\x1DA\a/\x2\x2\x1DAt\x3\x2\x2\x2"+
		"\x1DB\x1DC\a\'\x2\x2\x1DCv\x3\x2\x2\x2\x1DD\x1DE\a\x31\x2\x2\x1DE\x1DF"+
		"\a\x31\x2\x2\x1DFx\x3\x2\x2\x2\x1E0\x1E1\a`\x2\x2\x1E1z\x3\x2\x2\x2\x1E2"+
		"\x1E3\av\x2\x2\x1E3\x1E4\at\x2\x2\x1E4\x1E5\ak\x2\x2\x1E5|\x3\x2\x2\x2"+
		"\x1E6\x1E7\ah\x2\x2\x1E7\x1E8\ak\x2\x2\x1E8\x1E9\a\x64\x2\x2\x1E9~\x3"+
		"\x2\x2\x2\x1EA\x1EB\at\x2\x2\x1EB\x1EC\a\x63\x2\x2\x1EC\x1ED\ap\x2\x2"+
		"\x1ED\x1EE\a\x66\x2\x2\x1EE\x1EF\aq\x2\x2\x1EF\x1F0\ao\x2\x2\x1F0\x80"+
		"\x3\x2\x2\x2\x1F1\x1F2\au\x2\x2\x1F2\x1F3\ak\x2\x2\x1F3\x1F4\a|\x2\x2"+
		"\x1F4\x1F5\ag\x2\x2\x1F5\x82\x3\x2\x2\x2\x1F6\x1F7\au\x2\x2\x1F7\x1F8"+
		"\aq\x2\x2\x1F8\x1F9\at\x2\x2\x1F9\x1FA\av\x2\x2\x1FA\x84\x3\x2\x2\x2\x1FB"+
		"\x1FC\aw\x2\x2\x1FC\x1FD\ap\x2\x2\x1FD\x1FE\ak\x2\x2\x1FE\x1FF\aq\x2\x2"+
		"\x1FF\x200\ap\x2\x2\x200\x86\x3\x2\x2\x2\x201\x202\ak\x2\x2\x202\x203"+
		"\ap\x2\x2\x203\x204\av\x2\x2\x204\x205\ag\x2\x2\x205\x206\at\x2\x2\x206"+
		"\x207\au\x2\x2\x207\x208\ag\x2\x2\x208\x209\a\x65\x2\x2\x209\x20A\av\x2"+
		"\x2\x20A\x88\x3\x2\x2\x2\x20B\x20C\a\x66\x2\x2\x20C\x20D\ak\x2\x2\x20D"+
		"\x20E\au\x2\x2\x20E\x20F\al\x2\x2\x20F\x210\aw\x2\x2\x210\x211\ap\x2\x2"+
		"\x211\x212\a\x65\x2\x2\x212\x213\av\x2\x2\x213\x214\ak\x2\x2\x214\x215"+
		"\aq\x2\x2\x215\x216\ap\x2\x2\x216\x8A\x3\x2\x2\x2\x217\x218\au\x2\x2\x218"+
		"\x219\aw\x2\x2\x219\x21A\ao\x2\x2\x21A\x8C\x3\x2\x2\x2\x21B\x21C\au\x2"+
		"\x2\x21C\x21D\a\x65\x2\x2\x21D\x21E\aq\x2\x2\x21E\x21F\at\x2\x2\x21F\x220"+
		"\ag\x2\x2\x220\x8E\x3\x2\x2\x2\x221\x222\a\x63\x2\x2\x222\x223\ap\x2\x2"+
		"\x223\x227\a\x66\x2\x2\x224\x225\aq\x2\x2\x225\x227\at\x2\x2\x226\x221"+
		"\x3\x2\x2\x2\x226\x224\x3\x2\x2\x2\x227\x90\x3\x2\x2\x2\x228\x22E\t\x2"+
		"\x2\x2\x229\x22A\a@\x2\x2\x22A\x22E\a?\x2\x2\x22B\x22C\a>\x2\x2\x22C\x22E"+
		"\a?\x2\x2\x22D\x228\x3\x2\x2\x2\x22D\x229\x3\x2\x2\x2\x22D\x22B\x3\x2"+
		"\x2\x2\x22E\x92\x3\x2\x2\x2\x22F\x230\a#\x2\x2\x230\x234\a?\x2\x2\x231"+
		"\x232\a?\x2\x2\x232\x234\a?\x2\x2\x233\x22F\x3\x2\x2\x2\x233\x231\x3\x2"+
		"\x2\x2\x234\x94\x3\x2\x2\x2\x235\x236\ap\x2\x2\x236\x237\aq\x2\x2\x237"+
		"\x238\av\x2\x2\x238\x96\x3\x2\x2\x2\x239\x23A\t\x3\x2\x2\x23A\x98\x3\x2"+
		"\x2\x2\x23B\x23C\t\x4\x2\x2\x23C\x9A\x3\x2\x2\x2\x23D\x23E\a*\x2\x2\x23E"+
		"\x9C\x3\x2\x2\x2\x23F\x240\a+\x2\x2\x240\x9E\x3\x2\x2\x2\x241\x243\t\x5"+
		"\x2\x2\x242\x241\x3\x2\x2\x2\x243\x244\x3\x2\x2\x2\x244\x242\x3\x2\x2"+
		"\x2\x244\x245\x3\x2\x2\x2\x245\x246\x3\x2\x2\x2\x246\x247\bP\x2\x2\x247"+
		"\xA0\x3\x2\x2\x2\x248\x249\v\x2\x2\x2\x249\xA2\x3\x2\x2\x2\a\x2\x226\x22D"+
		"\x233\x244\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
