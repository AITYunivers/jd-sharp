/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile
{
    public class ClassFile
    {
        protected int majorVersion;
        protected int minorVersion;
        protected int accessFlags;
        protected string internalTypeName;
        protected string superTypeName;
        protected string[] interfaceTypeNames;
        protected Field[] fields;
        protected Method[] methods;
        protected Dictionary<string, Attribute.Attribute> attributes;

        protected ClassFile outerClassFile;
        protected List<ClassFile> innerClassFiles;

        public ClassFile(int majorVersion, int minorVersion, int accessFlags, string internalTypeName, string superTypeName, string[] interfaceTypeNames, Field[] fields, Method[] methods, Dictionary<string, Attribute.Attribute> attributes)
        {
            this.majorVersion = majorVersion;
            this.minorVersion = minorVersion;
            this.accessFlags = accessFlags;
            this.internalTypeName = internalTypeName;
            this.superTypeName = superTypeName;
            this.interfaceTypeNames = interfaceTypeNames;
            this.fields = fields;
            this.methods = methods;
            this.attributes = attributes;
        }

        public int getMinorVersion() { return minorVersion; }
        public int getMajorVersion() { return majorVersion; }

        public int getAccessFlags()
        {
            return accessFlags;
        }
        public void setAccessFlags(int accessFlags)
        {
            this.accessFlags = accessFlags;
        }

        public bool isEnum() { return (accessFlags & Constants.ACC_ENUM) != 0; }
        public bool isAnnotation() { return (accessFlags & Constants.ACC_ANNOTATION) != 0; }
        public bool isInterface() { return (accessFlags & Constants.ACC_INTERFACE) != 0; }
        public bool isModule() { return (accessFlags & Constants.ACC_MODULE) != 0; }
        public bool isStatic() { return (accessFlags & Constants.ACC_STATIC) != 0; }

        public string getInternalTypeName()
        {
            return internalTypeName;
        }

        public string getSuperTypeName()
        {
            return superTypeName;
        }

        public string[] getInterfaceTypeNames()
        {
            return interfaceTypeNames;
        }

        public Field[] getFields()
        {
            return fields;
        }

        public Method[] getMethods()
        {
            return methods;
        }

        public T getAttribute<T>(string name) where T: Attribute.Attribute
        {
            return (attributes == null) ? default : (T)attributes[name];
        }

        public ClassFile getOuterClassFile()
        {
            return outerClassFile;
        }

        public void setOuterClassFile(ClassFile outerClassFile)
        {
            this.outerClassFile = outerClassFile;
        }

        public List<ClassFile> getInnerClassFiles()
        {
            return innerClassFiles;
        }

        public void setInnerClassFiles(List<ClassFile> innerClassFiles)
        {
            this.innerClassFiles = innerClassFiles;
        }

        public override string ToString()
        {
            return $"ClassFile{{{internalTypeName}}}";
        }
    }
}
