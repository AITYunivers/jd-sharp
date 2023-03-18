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

namespace JD_Sharp.Model.JavaFragment
{
    public class LineNumberTokensFragment : FixedFragment, JavaFragment
    {
        protected List<Token.Token> tokens;

        public LineNumberTokensFragment(Token.Token[] tokens) :
        this(tokens.ToList()) {}

        public LineNumberTokensFragment(List<Token.Token> tokens) :
        base(searchFirstLineNumber(tokens), searchLastLineNumber(tokens))
        {
            if (firstLineNumber != Printer.UNKNOWN_LINE_NUMBER)
            {
                Console.WriteLine("Uses 'TokensFragment' instead");
                Debug.Assert(true);
            }
            this.tokens = tokens;
        }

        public List<Token.Token> getTokens()
        {
            return tokens;
        }

        protected static int searchFirstLineNumber(List<Token.Token> tokens)
        {
            SearchLineNumberVisitor visitor = new SearchLineNumberVisitor();

            foreach (Token.Token token in tokens)
            {
                token.accept(visitor);

                if (visitor.lineNumber != Printer.UNKNOWN_LINE_NUMBER)
                    return visitor.lineNumber - visitor.newLineCounter;
            }

            return Printer.UNKNOWN_LINE_NUMBER;
        }

        protected static int searchLastLineNumber(List<Token.Token> tokens)
        {
            SearchLineNumberVisitor visitor = new SearchLineNumberVisitor();
            int index = tokens.Count();

            while (index-- > 0)
            {
                tokens[index].accept(visitor);

                if (visitor.lineNumber != Printer.UNKNOWN_LINE_NUMBER)
                    return visitor.lineNumber + visitor.newLineCounter;
            }

            return Printer.UNKNOWN_LINE_NUMBER;
        }

        protected class SearchLineNumberVisitor : AbstractNopTokenVisitor
        {
            public int lineNumber;
            public int newLineCounter;

            public void reset()
            {
                lineNumber = Printer.UNKNOWN_LINE_NUMBER;
                newLineCounter = 0;
            }

            public void visit(LineNumberToken token)
            {
                lineNumber = token.getLineNumber();
            }

            public void visit(NewLineToken token)
            {
                newLineCounter++;
            }
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
