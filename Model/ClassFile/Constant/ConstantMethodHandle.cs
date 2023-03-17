/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantMethodHandle : Constant
    {
        protected int referenceKind;
        protected int referenceIndex;

        public ConstantMethodHandle(int referenceKind, int referenceIndex) : base(CONSTANT_MethodHandle)
        {
            this.referenceKind = referenceKind;
            this.referenceIndex = referenceIndex;
        }

        public int getReferenceKind()
        {
            return referenceKind;
        }

        public int getReferenceIndex()
        {
            return referenceIndex;
        }
    }
}
