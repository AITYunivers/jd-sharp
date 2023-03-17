/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Fragment
{
    public abstract class EndFlexibleBlockFragment : StartFlexibleBlockFragment
    {
        protected EndFlexibleBlockFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label) {}

        public void accept(FragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
