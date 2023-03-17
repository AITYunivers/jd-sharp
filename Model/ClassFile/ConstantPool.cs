/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.ClassFile.Constant;

namespace JD_Sharp.Model.ClassFile
{
    public class ConstantPool
    {
        protected Constant[] constants;

        public ConstantPool(Constant[] constants)
        {
            this.constants = constants;
        }

        public T getConstant<T>(int index) where T : Constant
        {
            return (T)constants[index];
        }

        public string getConstantTypeName(int index)
        {
            ConstantClass cc = (ConstantClass)constants[index];
            ConstantUtf8 cutf8 = (ConstantUtf8)constants[cc.getNameIndex()];
            return cutf8.getValue();
        }

        public string getConstantString(int index)
        {
            ConstantString cString = (ConstantString)constants[index];
            ConstantUtf8 cutf8 = (ConstantUtf8)constants[cString.getStringIndex()];
            return cutf8.getValue();
        }

        public string getConstantUtf8(int index)
        {
            ConstantUtf8 cutf8 = (ConstantUtf8)constants[index];
            return cutf8.getValue();
        }

        public ConstantValue getConstantValue(int index)
        {
            Constant constant = constants[index];

            if (constant != null && constant.getTag() == Constant.CONSTANT_String)
            {
                constant = constants[((ConstantString)constant).getStringIndex()];
            }

            return (ConstantValue)constant;
        }

        public override string ToString()
        {
            return "ConstantPool";
        }
    }
}
