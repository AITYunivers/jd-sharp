/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;

namespace JD_Sharp.Model.JavaFragment
{
    public class StartMovableJavaBlockFragment : StartMovableBlockFragment, JavaFragment
    {
        public static StartMovableJavaBlockFragment START_MOVABLE_TYPE_BLOCK = new StartMovableJavaBlockFragment(1);
        public static StartMovableJavaBlockFragment START_MOVABLE_FIELD_BLOCK = new StartMovableJavaBlockFragment(2);
        public static StartMovableJavaBlockFragment START_MOVABLE_METHOD_BLOCK = new StartMovableJavaBlockFragment(3);

        protected StartMovableJavaBlockFragment(int type) :
        base(type) {}

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
