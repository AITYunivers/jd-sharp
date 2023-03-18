/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.API.Printer;
using JD_Sharp.Model.Fragment;
using JD_Sharp.Model.Token;
using System.Diagnostics;
using JD_Sharp.Service.Fragmenter.JavaSyntaxToJavaFragment.Visitor;

namespace JD_Sharp.Model.JavaFragment
{
    public class TokensFragment : FlexibleFragment, JavaFragment
    {
        public static TokensFragment COMMA = new TokensFragment(new Token.Token[1] { TextToken.COMMA });
        public static TokensFragment SEMICOLON = new TokensFragment(new Token.Token[1] { TextToken.SEMICOLON});
        public static TokensFragment START_DECLARATION_OR_STATEMENT_BLOCK = new TokensFragment(new Token.Token[1] { StartBlockToken.START_DECLARATION_OR_STATEMENT_BLOCK});
        public static TokensFragment END_DECLARATION_OR_STATEMENT_BLOCK = new TokensFragment(new Token.Token[1] { EndBlockToken.END_DECLARATION_OR_STATEMENT_BLOCK});
        public static TokensFragment END_DECLARATION_OR_STATEMENT_BLOCK_SEMICOLON = new TokensFragment(new Token.Token[2] { EndBlockToken.END_DECLARATION_OR_STATEMENT_BLOCK, TextToken.SEMICOLON]);
        public static TokensFragment RETURN_SEMICOLON = new TokensFragment(new Token.Token[2] { StatementVisitor.RETURN, TextToken.SEMICOLON });

        protected List<Token.Token> tokens;

        public TokensFragment(Token.Token[] tokens) :
        this(tokens.ToList()) {}

        public TokensFragment(List<Token.Token> tokens) :
        this(getLineCount(tokens), tokens) {}

        protected TokensFragment(int lineCount, List<Token.Token> tokens) :
        base(lineCount, lineCount, lineCount, 0, "Tokens")
        {
            this.tokens = tokens;
        }

        public List<Token.Token> getTokens()
        {
            return tokens;
        }

        protected static int getLineCount(List<Token.Token> tokens)
        {
            LineCountVisitor visitor = new LineCountVisitor();

            foreach (Token.Token token in tokens)
            {
                token.accept(visitor);
            }

            return visitor.lineCount;
        }

        protected class LineCountVisitor : AbstractNopTokenVisitor
        {
            public int lineCount = 0;

            public void visit(LineNumberToken token)
            {
                lineCount++;
                if (token.getLineNumber() == Printer.UNKNOWN_LINE_NUMBER)
                {
                    Console.WriteLine("LineNumberToken cannot have a known line number. Uses 'LineNumberTokensFragment' instead");
                    Debug.Assert(true);
                }
            }
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
