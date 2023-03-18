/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;

namespace JD_Sharp.Model.JavaFragment
{
    public class StartStatementsBlockFragment : StartFlexibleBlockFragment, JavaFragment
    {
        protected Group group;

        public StartStatementsBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label)
        {
            group = new Group(this);
        }

        public StartStatementsBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label, Group group) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label)
        {
            this.group = group;
            group.add(this);
        }

        public Group getGroup()
        {
            return group;
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }

        public class Group
        {
            protected List<FlexibleFragment> fragments = new();
            protected int minimalLineCount = 2147483647;

            public Group(FlexibleFragment fragment)
            {
                fragments.Add(fragment);
            }

            public void add(FlexibleFragment fragment)
            {
                fragments.Add(fragment);
            }

            public int getMinimalLineCount()
            {
                if (minimalLineCount == 2147483647)
                    foreach (FlexibleFragment fragment in fragments)
                        if (minimalLineCount > fragment.getLineCount())
                            minimalLineCount = fragment.getLineCount();

                return minimalLineCount;
            }
        }
    }
}
