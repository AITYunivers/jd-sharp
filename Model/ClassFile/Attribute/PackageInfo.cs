/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class PackageInfo
    {
        protected string internalName;
        protected int flags;
        protected string[] moduleInfoNames;

        public PackageInfo(string internalName, int flags, string[] moduleInfoNames)
        {
            this.internalName = internalName;
            this.flags = flags;
            this.moduleInfoNames = moduleInfoNames;
        }

        public string getInternalName()
        {
            return internalName;
        }

        public int getFlags()
        {
            return flags;
        }

        public string[] getModuleInfoNames()
        {
            return moduleInfoNames;
        }

        public override string ToString()
        {
            var str = $"PackageInfo{{internalName={internalName}, " +
                      $"flags={flags}, ";

            if (moduleInfoNames != null)
                str += $", moduleInfoNames={moduleInfoNames}";

            return str + "}";
        }
    }
}
