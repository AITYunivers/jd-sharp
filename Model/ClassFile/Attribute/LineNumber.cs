/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class LineNumber
    {
        protected int startPc;
        protected int lineNumber;

        public LineNumber(int startPc, int lineNumber)
        {
            this.startPc = startPc;
            this.lineNumber = lineNumber;
        }

        public int getStartPc()
        {
            return startPc;
        }

        public int getLineNumber()
        {
            return lineNumber;
        }

        public override string ToString()
        {
            return $"LineNumber{{startPc={startPc}, lineNumber={lineNumber}}}";
        }
    }
}
