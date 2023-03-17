/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantClass : Constant
    {
        protected int nameIndex;

        public ConstantClass(int nameIndex) : base(CONSTANT_Class)
        {
            this.nameIndex = nameIndex;
        }

        public int getNameIndex()
        {
            return nameIndex;
        }
    }
}
