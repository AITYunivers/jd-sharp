/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;

namespace JD_Sharp.Model.JavaFragment
{
    public class EndBlockFragment : EndFlexibleBlockFragment, JavaFragment
    {
        protected StartBlockFragment start;

        public EndBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label, StartBlockFragment start) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label)
        {
            this.start = start;
            start.setEndArrayInitializerBlockFragment(this);
        }

        public void setLineCount(int lineCount)
        {
            this.lineCount = lineCount;
        }

        public StartBlockFragment getStartArrayInitializerBlockFragment()
        {
            return start;
        }

        public bool incLineCount(bool force)
        {
            if (lineCount < maximalLineCount)
            {
                lineCount++;
                return true;
            }
            return false;
        }

        public bool decLineCount(bool force)
        {
            if (lineCount > minimalLineCount)
            {
                lineCount--;
                return true;
            }
            return false;
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
