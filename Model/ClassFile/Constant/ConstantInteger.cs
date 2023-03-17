/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantInteger : ConstantValue
    {
        protected int value;

        public ConstantInteger(int value) : base(CONSTANT_Integer)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }
    }
}
