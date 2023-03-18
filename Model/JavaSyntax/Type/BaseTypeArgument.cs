/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Util;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public interface BaseTypeArgument : TypeArgumentVisitable
    {
        bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            return false;
        }

        bool isTypeArgumentList()
        {
            return false;
        }

        TypeArgument getTypeArgumentFirst()
        {
            return (TypeArgument)this;
        }

        DefaultList<TypeArgument> getTypeArgumentList()
        {
            return (DefaultList<TypeArgument>)this;
        }

        int typeArgumentSize()
        {
            return 1;
        }

        bool isGenericTypeArgument() { return false; }
        bool isInnerObjectTypeArgument() { return false; }
        bool isObjectTypeArgument() { return false; }
        bool isPrimitiveTypeArgument() { return false; }
        bool isWildcardExtendsTypeArgument() { return false; }
        bool isWildcardSuperTypeArgument() { return false; }
        bool isWildcardTypeArgument() { return false; }

        Type getType() { return ObjectType.TYPE_UNDEFINED_OBJECT; }
    }
}
