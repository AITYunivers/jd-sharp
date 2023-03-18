/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.API.Printer;

namespace JD_Sharp.Model.Token
{
    public class DeclarationToken : Token
    {
        // Declaration & reference types
        public static int TYPE        = Printer.TYPE;
        public static int FIELD       = Printer.FIELD;
        public static int METHOD      = Printer.METHOD;
        public static int CONSTRUCTOR = Printer.CONSTRUCTOR;
        public static int PACKAGE     = Printer.PACKAGE;
        public static int MODULE      = Printer.MODULE;

        protected int type;
        protected string internalTypeName;
        protected string name;
        protected string descriptor;

        public DeclarationToken(int type, string internalTypeName, string name, string descriptor)
        {
            this.type = type;
            this.internalTypeName = internalTypeName;
            this.name = name;
            this.descriptor = descriptor;
        }

        public int getType()
        {
            return type;
        }

        public string getInternalTypeName()
        {
            return internalTypeName;
        }

        public string getName()
        {
            return name;
        }

        public string getDescriptor()
        {
            return descriptor;
        }

        public override string ToString()
        {
            return $"DeclarationToken{{declaration='{name}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
