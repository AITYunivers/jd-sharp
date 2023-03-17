/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ElementValueEnumConstValue : ElementValue
    {
        protected string descriptor;
        protected string constName;

        public ElementValueEnumConstValue(string descriptor, string constName)
        {
            this.descriptor = descriptor;
            this.constName = constName;
        }

        public string getDescriptor()
        {
            return descriptor;
        }

        public string getConstName()
        {
            return constName;
        }

        public void accept(ElementValueVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
