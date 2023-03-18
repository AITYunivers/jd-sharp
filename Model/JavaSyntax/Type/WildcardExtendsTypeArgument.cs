﻿/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class WildcardExtendsTypeArgument : TypeArgument
    {
        protected Type type;

        public WildcardExtendsTypeArgument(Type type)
        {
            this.type = type;
        }

        public Type getType()
        {
            return type;
        }

        public bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            if (typeArgument.isWildcardExtendsTypeArgument())
                return type.isTypeArgumentAssignableFrom(typeBounds, typeArgument.getType());
            else if (typeArgument is Type)
                return type.isTypeArgumentAssignableFrom(typeBounds, typeArgument);

            return false;
        }

        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            WildcardExtendsTypeArgument that = (WildcardExtendsTypeArgument)o;

            return type != null ? type.Equals(that.type) : that.type == null;
        }

        public int hashCode()
        {
            return 957014778 + (type != null ? type.GetHashCode() : 0);
        }

        public bool isWildcardExtendsTypeArgument() { return true; }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return $"WildcardExtendsTypeArgument{{? extends {type}}}";
        }
    }
}
