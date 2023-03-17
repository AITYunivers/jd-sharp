/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.ClassFile.Constant;

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ElementValuePrimitiveType : ElementValue
    {
        protected int type;
        protected ConstantValue constValue;

        public ElementValuePrimitiveType(int type, ConstantValue constValue)
        {
            this.type = type;
            this.constValue = constValue;
        }

        public int getType()
        {
            return type;
        }

        
        public T getConstValue<T>() where T: ConstantValue
        {
            return (T)constValue;
        }

        
        public void accept(ElementValueVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
