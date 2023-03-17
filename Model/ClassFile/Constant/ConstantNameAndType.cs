/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantNameAndType : Constant
    {
        protected int nameIndex;
        protected int descriptorIndex;

        public ConstantNameAndType(int nameIndex, int descriptorIndex) : base(CONSTANT_NameAndType)
        {
            this.nameIndex = nameIndex;
            this.descriptorIndex = descriptorIndex;
        }

        public int getNameIndex()
        {
            return nameIndex;
        }

        public int getDescriptorIndex()
        {
            return descriptorIndex;
        }
    }
}
