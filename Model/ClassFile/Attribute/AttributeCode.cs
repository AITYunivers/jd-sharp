/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class AttributeCode : Attribute
    {
        protected int maxStack;
        protected int maxLocals;
        protected byte[] code;
        protected CodeException[] exceptionTable;
        protected Dictionary<string, Attribute> attributes;

        public AttributeCode(int maxStack, int maxLocals, byte[] code, CodeException[] exceptionTable, Dictionary<string, Attribute> attributes)
        {
            this.maxStack = maxStack;
            this.maxLocals = maxLocals;
            this.code = code;
            this.exceptionTable = exceptionTable;
            this.attributes = attributes;
        }

        public int getMaxStack()
        {
            return maxStack;
        }

        public int getMaxLocals()
        {
            return maxLocals;
        }

        public byte[] getCode()
        {
            return code;
        }

        public CodeException[] getExceptionTable()
        {
            return exceptionTable;
        }

        public T getAttribute<T>(string name) where T: Attribute
        {
            return (attributes == null) ? default : (T)attributes[name];
        }
    }
}
