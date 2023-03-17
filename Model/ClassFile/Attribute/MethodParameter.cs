/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class MethodParameter
    {
        protected string name;
        protected int access;

        public MethodParameter(string name, int access)
        {
            this.name = name;
            this.access = access;
        }

        public string getName()
        {
            return name;
        }

        public int getAccess()
        {
            return access;
        }

        public override string ToString()
        {
            return $"Parameter{{name = {name}, " +
                   $"access={access}}}";
        }
    }
}
