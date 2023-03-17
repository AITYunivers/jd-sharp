/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantString : Constant
    {
        protected int stringIndex;

        public ConstantString(int stringIndex) : base(CONSTANT_String)
        {
            this.stringIndex = stringIndex;
        }

        public int getStringIndex()
        {
            return stringIndex;
        }
    }
}
