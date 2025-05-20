
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_LPAREN        =  3, // '('
        SYMBOL_RPAREN        =  4, // ')'
        SYMBOL_SEMISEMI      =  5, // ';;'
        SYMBOL_QUESTION      =  6, // '?'
        SYMBOL_LBRACE        =  7, // '{'
        SYMBOL_RBRACE        =  8, // '}'
        SYMBOL_MINUSGT       =  9, // '->'
        SYMBOL_3AD           = 10, // '3ad'
        SYMBOL_3LIKOM        = 11, // '3likom'
        SYMBOL_3ML           = 12, // '3ml'
        SYMBOL_3RF           = 13, // '3rf'
        SYMBOL_7AGA          = 14, // '7aga'
        SYMBOL_8LT           = 15, // '8lt'
        SYMBOL_AKBR          = 16, // akbr
        SYMBOL_AS8R          = 17, // 'as8r'
        SYMBOL_BA3D          = 18, // 'ba3d'
        SYMBOL_BGD           = 19, // bgd
        SYMBOL_DA            = 20, // da
        SYMBOL_DIGIT         = 21, // digit
        SYMBOL_E2SM          = 22, // 'e2sm'
        SYMBOL_E3ML          = 23, // 'e3ml'
        SYMBOL_EDRB          = 24, // edrb
        SYMBOL_ELSALAMA      = 25, // Elsalama
        SYMBOL_GARRB         = 26, // garrb
        SYMBOL_ID            = 27, // id
        SYMBOL_KALAM         = 28, // kalam
        SYMBOL_KDA           = 29, // kda
        SYMBOL_LL            = 30, // ll
        SYMBOL_M3            = 31, // 'm3'
        SYMBOL_MESH_ZAY      = 32, // 'mesh_zay'
        SYMBOL_MN            = 33, // mn
        SYMBOL_N2S           = 34, // 'n2s'
        SYMBOL_NADAH         = 35, // nadah
        SYMBOL_NO3           = 36, // 'no3'
        SYMBOL_RAKAM         = 37, // rakam
        SYMBOL_SA7           = 38, // 'sa7'
        SYMBOL_SALAM         = 39, // salam
        SYMBOL_TOL_MA        = 40, // 'tol_ma'
        SYMBOL_W             = 41, // w
        SYMBOL_WZD           = 42, // wzd
        SYMBOL_ZAY_BA3D      = 43, // 'zay_ba3d'
        SYMBOL_ZWD           = 44, // zwd
        SYMBOL_3AD2          = 45, // <3ad>
        SYMBOL_ARGS          = 46, // <args>
        SYMBOL_ASSIGN        = 47, // <assign>
        SYMBOL_DECLARE       = 48, // <declare>
        SYMBOL_EXPR          = 49, // <expr>
        SYMBOL_EXPR_TAIL     = 50, // <expr_tail>
        SYMBOL_FA3L          = 51, // <fa3l>
        SYMBOL_FACTOR        = 52, // <factor>
        SYMBOL_GARRB2        = 53, // <garrb>
        SYMBOL_GOMLA         = 54, // <gomla>
        SYMBOL_ID2           = 55, // <id>
        SYMBOL_LAW_EH        = 56, // <law_eh>
        SYMBOL_NADAH2        = 57, // <nadah>
        SYMBOL_NUM           = 58, // <num>
        SYMBOL_OP            = 59, // <op>
        SYMBOL_PARAM         = 60, // <param>
        SYMBOL_PARAMS        = 61, // <params>
        SYMBOL_PROGRAM       = 62, // <program>
        SYMBOL_SHART         = 63, // <shart>
        SYMBOL_STMTMINUSLIST = 64, // <stmt-list>
        SYMBOL_TERM          = 65, // <term>
        SYMBOL_TERM_TAIL     = 66, // <term_tail>
        SYMBOL_TOOL          = 67, // <tool>
        SYMBOL_TYPE          = 68  // <type>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_SALAM_3LIKOM_M3_ELSALAMA                                      =  0, // <program> ::= salam '3likom' <stmt-list> 'm3' Elsalama
        RULE_STMTLIST                                                              =  1, // <stmt-list> ::= <gomla>
        RULE_STMTLIST_SEMISEMI                                                     =  2, // <stmt-list> ::= <gomla> ';;' <stmt-list>
        RULE_GOMLA                                                                 =  3, // <gomla> ::= <declare>
        RULE_GOMLA2                                                                =  4, // <gomla> ::= <assign>
        RULE_GOMLA3                                                                =  5, // <gomla> ::= <law_eh>
        RULE_GOMLA4                                                                =  6, // <gomla> ::= <3ad>
        RULE_GOMLA5                                                                =  7, // <gomla> ::= <tool>
        RULE_GOMLA6                                                                =  8, // <gomla> ::= <garrb>
        RULE_GOMLA7                                                                =  9, // <gomla> ::= <fa3l>
        RULE_GOMLA8                                                                = 10, // <gomla> ::= <nadah>
        RULE_ID_ID                                                                 = 11, // <id> ::= id
        RULE_NUM_DIGIT                                                             = 12, // <num> ::= digit
        RULE_DECLARE_3RF_MN_NO3                                                    = 13, // <declare> ::= '3rf' <id> mn 'no3' <type>
        RULE_TYPE_RAKAM                                                            = 14, // <type> ::= rakam
        RULE_TYPE_KALAM                                                            = 15, // <type> ::= kalam
        RULE_TYPE_SA7                                                              = 16, // <type> ::= 'sa7'
        RULE_TYPE_8LT                                                              = 17, // <type> ::= '8lt'
        RULE_TYPE_7AGA                                                             = 18, // <type> ::= '7aga'
        RULE_ASSIGN_3ML_DA                                                         = 19, // <assign> ::= '3ml' <id> da <expr>
        RULE_EXPR                                                                  = 20, // <expr> ::= <term> <expr_tail>
        RULE_EXPR_TAIL_ZWD                                                         = 21, // <expr_tail> ::= <term> zwd <expr_tail>
        RULE_EXPR_TAIL_N2S                                                         = 22, // <expr_tail> ::= <term> 'n2s' <expr_tail>
        RULE_TERM                                                                  = 23, // <term> ::= <factor> <term_tail>
        RULE_TERM_TAIL_EDRB                                                        = 24, // <term_tail> ::= <factor> edrb <term_tail>
        RULE_TERM_TAIL_E2SM                                                        = 25, // <term_tail> ::= <factor> 'e2sm' <term_tail>
        RULE_FACTOR                                                                = 26, // <factor> ::= <id>
        RULE_FACTOR2                                                               = 27, // <factor> ::= <num>
        RULE_LAW_EH_QUESTION_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE                   = 28, // <law_eh> ::= '?' '(' <shart> ')' '->' '{' <stmt-list> '}'
        RULE_LAW_EH_QUESTION_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE_BGD_LBRACE_RBRACE = 29, // <law_eh> ::= '?' '(' <shart> ')' '->' '{' <stmt-list> '}' bgd '{' <stmt-list> '}'
        RULE_SHART                                                                 = 30, // <shart> ::= <expr> <op> <expr>
        RULE_OP_AKBR                                                               = 31, // <op> ::= akbr
        RULE_OP_AS8R                                                               = 32, // <op> ::= 'as8r'
        RULE_OP_MESH_ZAY                                                           = 33, // <op> ::= 'mesh_zay'
        RULE_OP_ZAY_BA3D                                                           = 34, // <op> ::= 'zay_ba3d'
        RULE_3AD_3AD_MN_LL_MINUSGT_LBRACE_RBRACE                                   = 35, // <3ad> ::= '3ad' <id> mn <expr> ll <expr> '->' '{' <stmt-list> '}'
        RULE_TOOL_TOL_MA_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE                       = 36, // <tool> ::= 'tol_ma' '(' <shart> ')' '->' '{' <stmt-list> '}'
        RULE_GARRB_GARRB_MINUSGT_LBRACE_RBRACE_W_BA3D_KDA_LPAREN_RPAREN            = 37, // <garrb> ::= garrb '->' '{' <stmt-list> '}' w 'ba3d' kda '(' <shart> ')'
        RULE_FA3L_E3ML_WZD_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE                     = 38, // <fa3l> ::= 'e3ml' wzd <id> '(' <params> ')' '->' '{' <stmt-list> '}'
        RULE_PARAMS                                                                = 39, // <params> ::= <param>
        RULE_PARAMS_SEMISEMI                                                       = 40, // <params> ::= <param> ';;' <params>
        RULE_PARAM_MN_NO3                                                          = 41, // <param> ::= <id> mn 'no3' <type>
        RULE_NADAH_NADAH_LPAREN_RPAREN                                             = 42, // <nadah> ::= nadah <id> '(' <args> ')'
        RULE_ARGS                                                                  = 43, // <args> ::= <expr>
        RULE_ARGS_SEMISEMI                                                         = 44  // <args> ::= <expr> ';;' <args>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox list;
        ListBox listBox1;
        public MyParser(string filename , ListBox listBox , ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            list = listBox;
            listBox1 = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMISEMI :
                //';;'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3AD :
                //'3ad'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3LIKOM :
                //'3likom'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3ML :
                //'3ml'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3RF :
                //'3rf'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_7AGA :
                //'7aga'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_8LT :
                //'8lt'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AKBR :
                //akbr
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS8R :
                //'as8r'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BA3D :
                //'ba3d'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BGD :
                //bgd
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DA :
                //da
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E2SM :
                //'e2sm'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E3ML :
                //'e3ml'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EDRB :
                //edrb
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSALAMA :
                //Elsalama
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GARRB :
                //garrb
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KALAM :
                //kalam
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KDA :
                //kda
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LL :
                //ll
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_M3 :
                //'m3'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MESH_ZAY :
                //'mesh_zay'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MN :
                //mn
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_N2S :
                //'n2s'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NADAH :
                //nadah
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NO3 :
                //'no3'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RAKAM :
                //rakam
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SA7 :
                //'sa7'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SALAM :
                //salam
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TOL_MA :
                //'tol_ma'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_W :
                //w
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WZD :
                //wzd
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ZAY_BA3D :
                //'zay_ba3d'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ZWD :
                //zwd
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3AD2 :
                //<3ad>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGS :
                //<args>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARE :
                //<declare>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR_TAIL :
                //<expr_tail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FA3L :
                //<fa3l>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GARRB2 :
                //<garrb>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOMLA :
                //<gomla>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LAW_EH :
                //<law_eh>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NADAH2 :
                //<nadah>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //<num>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //<param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //<params>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHART :
                //<shart>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMTMINUSLIST :
                //<stmt-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM_TAIL :
                //<term_tail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TOOL :
                //<tool>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_SALAM_3LIKOM_M3_ELSALAMA :
                //<program> ::= salam '3likom' <stmt-list> 'm3' Elsalama
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST :
                //<stmt-list> ::= <gomla>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST_SEMISEMI :
                //<stmt-list> ::= <gomla> ';;' <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA :
                //<gomla> ::= <declare>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA2 :
                //<gomla> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA3 :
                //<gomla> ::= <law_eh>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA4 :
                //<gomla> ::= <3ad>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA5 :
                //<gomla> ::= <tool>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA6 :
                //<gomla> ::= <garrb>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA7 :
                //<gomla> ::= <fa3l>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GOMLA8 :
                //<gomla> ::= <nadah>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_DIGIT :
                //<num> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARE_3RF_MN_NO3 :
                //<declare> ::= '3rf' <id> mn 'no3' <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_RAKAM :
                //<type> ::= rakam
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_KALAM :
                //<type> ::= kalam
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_SA7 :
                //<type> ::= 'sa7'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_8LT :
                //<type> ::= '8lt'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_7AGA :
                //<type> ::= '7aga'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_3ML_DA :
                //<assign> ::= '3ml' <id> da <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term> <expr_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_TAIL_ZWD :
                //<expr_tail> ::= <term> zwd <expr_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_TAIL_N2S :
                //<expr_tail> ::= <term> 'n2s' <expr_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor> <term_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TAIL_EDRB :
                //<term_tail> ::= <factor> edrb <term_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TAIL_E2SM :
                //<term_tail> ::= <factor> 'e2sm' <term_tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<factor> ::= <num>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LAW_EH_QUESTION_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE :
                //<law_eh> ::= '?' '(' <shart> ')' '->' '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LAW_EH_QUESTION_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE_BGD_LBRACE_RBRACE :
                //<law_eh> ::= '?' '(' <shart> ')' '->' '{' <stmt-list> '}' bgd '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHART :
                //<shart> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_AKBR :
                //<op> ::= akbr
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_AS8R :
                //<op> ::= 'as8r'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_MESH_ZAY :
                //<op> ::= 'mesh_zay'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_ZAY_BA3D :
                //<op> ::= 'zay_ba3d'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_3AD_3AD_MN_LL_MINUSGT_LBRACE_RBRACE :
                //<3ad> ::= '3ad' <id> mn <expr> ll <expr> '->' '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TOOL_TOL_MA_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE :
                //<tool> ::= 'tol_ma' '(' <shart> ')' '->' '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GARRB_GARRB_MINUSGT_LBRACE_RBRACE_W_BA3D_KDA_LPAREN_RPAREN :
                //<garrb> ::= garrb '->' '{' <stmt-list> '}' w 'ba3d' kda '(' <shart> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FA3L_E3ML_WZD_LPAREN_RPAREN_MINUSGT_LBRACE_RBRACE :
                //<fa3l> ::= 'e3ml' wzd <id> '(' <params> ')' '->' '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS :
                //<params> ::= <param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_SEMISEMI :
                //<params> ::= <param> ';;' <params>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAM_MN_NO3 :
                //<param> ::= <id> mn 'no3' <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NADAH_NADAH_LPAREN_RPAREN :
                //<nadah> ::= nadah <id> '(' <args> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS :
                //<args> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS_SEMISEMI :
                //<args> ::= <expr> ';;' <args>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString() + " In Line: " + args.UnexpectedToken.Location.LineNr;
            list.Items.Add(message);
            string message2 = "Expected Token: "+ args.ExpectedTokens.ToString();
            list.Items.Add(message2);
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser p , TokenReadEventArgs t)
        {
            string info = t.Token.Text + "\t \t " + (SymbolConstants) t.Token.Symbol.Id;
            listBox1.Items.Add(info);
        }

    }
}
