/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class TypeParameter : BaseTypeParameter
    {
        protected string identifier;

        public TypeParameter(string identifier)
        {
            this.identifier = identifier;
        }

        public string getIdentifier()
        {
            return identifier;
        }

        public void accept(TypeParameterVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return $"TypeParameter{{identifier={identifier}}}";
        }
    }
}
