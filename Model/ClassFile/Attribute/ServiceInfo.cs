/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ServiceInfo
    {
        protected string interfaceTypeName;
        protected string[] implementationTypeNames;

        public ServiceInfo(string interfaceTypeName, string[] implementationTypeNames)
        {
            this.interfaceTypeName = interfaceTypeName;
            this.implementationTypeNames = implementationTypeNames;
        }

        public string getInterfaceTypeName()
        {
            return interfaceTypeName;
        }

        public string[] getImplementationTypeNames()
        {
            return implementationTypeNames;
        }

        public override string ToString()
        {
            var str = $"ServiceInfo{{interfaceTypeName={interfaceTypeName}";

            if (implementationTypeNames != null)
                str += $", implementationTypeNames={implementationTypeNames}";

            return str + "}";
        }
    }
}
