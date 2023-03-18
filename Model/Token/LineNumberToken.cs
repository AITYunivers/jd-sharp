/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.API.Printer;

namespace JD_Sharp.Model.Token
{
    public class LineNumberToken : Token
    {
        public static LineNumberToken UNKNOWN_LINE_NUMBER = new LineNumberToken(Printer.UNKNOWN_LINE_NUMBER);

        protected int lineNumber;

        public LineNumberToken(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        public int getLineNumber()
        {
            return lineNumber;
        }

        public override string ToString()
        {
            return $"LineNumberToken{{{lineNumber}}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
