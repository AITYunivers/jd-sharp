/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;

namespace JD_Sharp.Model.JavaFragment
{
    public class EndStatementsBlockFragment : EndFlexibleBlockFragment, JavaFragment
    {
        protected StartStatementsBlockFragment.Group group;

        public EndStatementsBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label, StartStatementsBlockFragment.Group group) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label)
        {
            this.group = group;
            group.add(this);
        }

        public StartStatementsBlockFragment.Group getGroup()
        {
            return group;
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
