/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Fragment
{
    public class StartMovableBlockFragment : FlexibleFragment
    {
        protected int type;

        public StartMovableBlockFragment(int type) : base(0, 0, 0, 0, "Start movable block")
        {
            this.type = type;
        }

        public int getType()
        {
            return type;
        }

        public string ToString()
        {
            return "{start-movable-block}";
        }

        public void accept(FragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
