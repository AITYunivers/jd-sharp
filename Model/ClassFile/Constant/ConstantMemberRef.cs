/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantMemberRef : Constant
    {
        protected int classIndex;
        protected int nameAndTypeIndex;

        public ConstantMemberRef(int classIndex, int nameAndTypeIndex) : base(CONSTANT_MemberRef)
        {
            this.classIndex = classIndex;
            this.nameAndTypeIndex = nameAndTypeIndex;
        }

        public int getClassIndex()
        {
            return classIndex;
        }

        public int getNameAndTypeIndex()
        {
            return nameAndTypeIndex;
        }
    }
}
