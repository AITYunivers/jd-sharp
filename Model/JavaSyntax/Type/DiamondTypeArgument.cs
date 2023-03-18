/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class DiamondTypeArgument : TypeArgument
    {
        public static DiamondTypeArgument DIAMOND = new DiamondTypeArgument();

        protected DiamondTypeArgument() { }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }

        public bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            return true;
        }
    }
}
