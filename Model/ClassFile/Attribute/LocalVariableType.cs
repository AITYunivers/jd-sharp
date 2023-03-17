/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class LocalVariableType
    {
        protected int startPc;
        protected int length;
        protected string name;
        protected string signature;
        protected int index;

        public LocalVariableType(int startPc, int length, string name, string signature, int index)
        {
            this.startPc = startPc;
            this.length = length;
            this.name = name;
            this.signature = signature;
            this.index = index;
        }

        public int getStartPc()
        {
            return startPc;
        }

        public int getLength()
        {
            return length;
        }

        public string getName()
        {
            return name;
        }

        public string getSignature()
        {
            return signature;
        }

        public int getIndex()
        {
            return index;
        }

        public override string ToString()
        {
            return $"LocalVariable{{index={index}, " +
                   $"name={name}, " +
                   $"signature={signature}, " +
                   $"index={index}, " +
                   $"startPc={startPc}, " +
                   $"length={length}}}";
        }
    }
}
