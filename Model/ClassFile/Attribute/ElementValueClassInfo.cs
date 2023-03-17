/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ElementValueClassInfo : ElementValue
    {
        protected string classInfo;

        public ElementValueClassInfo(string classInfo)
        {
            this.classInfo = classInfo;
        }

        public string getClassInfo()
        {
            return classInfo;
        }

        public void accept(ElementValueVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
