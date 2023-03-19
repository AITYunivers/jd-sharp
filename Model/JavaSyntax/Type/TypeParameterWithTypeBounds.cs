/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class TypeParameterWithTypeBounds : TypeParameter
    {
        protected BaseType typeBounds;

        public TypeParameterWithTypeBounds(string identifier, BaseType typeBounds) :
        base(identifier)
        {
            this.typeBounds = typeBounds;
        }

        public BaseType getTypeBounds()
        {
            return typeBounds;
        }

        public void accept(TypeParameterVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return $"TypeParameter{{identifier={identifier}, typeBounds={typeBounds}}}";
        }
    }
}
