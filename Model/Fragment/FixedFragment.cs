/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Fragment
{
    public abstract class FixedFragment : Fragment
    {
        protected int firstLineNumber;
        protected int lastLineNumber;

        public FixedFragment(int firstLineNumber, int lastLineNumber)
        {
            this.firstLineNumber = firstLineNumber;
            this.lastLineNumber = lastLineNumber;
        }

        public int getFirstLineNumber()
        {
            return firstLineNumber;
        }

        public int getLastLineNumber()
        {
            return lastLineNumber;
        }

        public override string ToString()
        {
            return $"{{first-line-number={firstLineNumber}, last-line-number={lastLineNumber}}}";
        }

        public void accept(FragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
