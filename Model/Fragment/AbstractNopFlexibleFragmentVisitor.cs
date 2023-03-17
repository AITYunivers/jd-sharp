/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Fragment
{
    public abstract class AbstractNopFlexibleFragmentVisitor : FragmentVisitor
    {
        public void visit(EndFlexibleBlockFragment fragment) { }
        public void visit(EndMovableBlockFragment fragment) { }
        public void visit(StartFlexibleBlockFragment fragment) { }
        public void visit(StartMovableBlockFragment fragment) { }
        public void visit(FixedFragment fragment) { }

        public void visit(FlexibleFragment fragment)
        {
            throw new NotImplementedException();
        }

        public void visit(SpacerBetweenMovableBlocksFragment fragment)
        {
            throw new NotImplementedException();
        }
    }
}
