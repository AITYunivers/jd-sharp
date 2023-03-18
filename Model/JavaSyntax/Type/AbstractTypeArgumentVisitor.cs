/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public abstract class AbstractTypeArgumentVisitor : TypeArgumentVisitor
    {
        public void visit(TypeArguments arguments)
        {
            foreach (TypeArgument typeArgument in arguments)
                typeArgument.accept(this);
        }

        public void visit(DiamondTypeArgument argument) { }

        public void visit(WildcardExtendsTypeArgument argument)
        {
            argument.getType().accept(this);
        }

        public void visit(PrimitiveType type) { }

        public void visit(ObjectType type)
        {
            safeAccept(type.getTypeArguments());
        }

        public void visit(InnerObjectType type)
        {
            type.getOuterType().accept(this);
            safeAccept(type.getTypeArguments());
        }

        public void visit(WildcardSuperTypeArgument argument)
        {
            argument.getType().accept(this);
        }

        public void visit(GenericType type) { }

        public void visit(WildcardTypeArgument argument) { }

        protected void safeAccept(TypeArgumentVisitable visitable)
        {
            if (visitable != null)
                visitable.accept(this);
        }
    }
}
