/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;

namespace JD_Sharp.Model.JavaFragment
{
    public class StartSingleStatementBlockFragment : StartFlexibleBlockFragment, JavaFragment
    {
        protected EndSingleStatementBlockFragment end;

        public StartSingleStatementBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label) {}

        public void setLineCount(int lineCount)
        {
            this.lineCount = lineCount;
        }

        public EndSingleStatementBlockFragment getEndSingleStatementBlockFragment()
        {
            return end;
        }

        public void setEndSingleStatementBlockFragment(EndSingleStatementBlockFragment end)
        {
            this.end = end;
        }

        public bool incLineCount(bool force)
        {
            if (lineCount < maximalLineCount)
            {
                lineCount++;

                if (!force)
                    if (end.getLineCount() == 0)
                        end.setLineCount(1);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool decLineCount(bool force)
        {
            if (lineCount > minimalLineCount)
            {
                lineCount--;

                if (!force)
                    if (lineCount == 1)
                        end.setLineCount(1);

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
