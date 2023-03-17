/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class InnerClass
    {
        protected string innerTypeName;
        protected string outerTypeName;
        protected string innerName;
        protected int innerAccessFlags;

        public InnerClass(string innerTypeName, string outerTypeName, string innerName, int innerAccessFlags)
        {
            this.innerTypeName = innerTypeName;
            this.outerTypeName = outerTypeName;
            this.innerName = innerName;
            this.innerAccessFlags = innerAccessFlags;
        }

        public string getInnerTypeName()
        {
            return innerTypeName;
        }

        public string getOuterTypeName()
        {
            return outerTypeName;
        }

        public string getInnerName()
        {
            return innerName;
        }

        public int getInnerAccessFlags()
        {
            return innerAccessFlags;
        }
    }
}
