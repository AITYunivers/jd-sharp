/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaFragment
{
    public class EndBlockInParameterFragment : EndBlockFragment, JavaFragment
    {
        public EndBlockInParameterFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label, StartBlockFragment start) :
        base(minimalLineCount, lineCount, maximalLineCount, weight, label, start) {}

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
