/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class LocalVariable
    {
        protected int startPc;
        protected int length;
        protected string name;
        protected string descriptor;
        protected int index;

        public LocalVariable(int startPc, int length, string name, string descriptor, int index)
        {
            this.startPc = startPc;
            this.length = length;
            this.name = name;
            this.descriptor = descriptor;
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

        public string getDescriptor()
        {
            return descriptor;
        }

        public int getIndex()
        {
            return index;
        }

        public override string ToString()
        {
            return $"LocalVariable{{index={index}, " +
                   $"name={name}, " +
                   $"descriptor={descriptor}, " +
                   $"startPc={startPc}, " +
                   $"length={length}}}";
        }
    }
}
