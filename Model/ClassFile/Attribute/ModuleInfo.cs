/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ModuleInfo
    {
        protected string name;
        protected int flags;
        protected string version;

        public ModuleInfo(string name, int flags, string version)
        {
            this.name = name;
            this.flags = flags;
            this.version = version;
        }

        public string getName()
        {
            return name;
        }

        public int getFlags()
        {
            return flags;
        }

        public string getVersion()
        {
            return version;
        }

        public override string ToString()
        {
            var str = $"ModuleInfo{{name={name}, " +
                      $"flags={flags}, ";

            if (version != null)
                str += $", version={version}";

            return str + "}";
        }
    }
}
