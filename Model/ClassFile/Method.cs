/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile
{
    public class Method
    {
        protected int accessFlags;
        protected string name;
        protected string descriptor;
        protected Dictionary<string, Attribute.Attribute> attributes;
        protected ConstantPool constants;

        public Method(int accessFlags, string name, string descriptor, Dictionary<string, Attribute.Attribute> attributes, ConstantPool constants)
        {
            this.accessFlags = accessFlags;
            this.name = name;
            this.descriptor = descriptor;
            this.attributes = attributes;
            this.constants = constants;
        }

        public int getAccessFlags()
        {
            return accessFlags;
        }

        public string getName()
        {
            return name;
        }

        public string getDescriptor()
        {
            return descriptor;
        }

        public T getAttribute<T>(string name) where T: Attribute.Attribute
        {
            return (attributes == null) ? default : (T)attributes[name];
        }

        public ConstantPool getConstants()
        {
            return constants;
        }

        public override string ToString()
        {
            return $"Method{{{name} {descriptor}}}";
        }
    }
}
