/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantUtf8 : ConstantValue
    {
        protected string value;

        public ConstantUtf8(string value) : base(CONSTANT_Utf8)
        {
            this.value = value;
        }

        public string getValue()
        {
            return value;
        }
    }
}
