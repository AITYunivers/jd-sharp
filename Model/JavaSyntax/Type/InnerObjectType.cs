/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using System.Diagnostics;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class InnerObjectType : ObjectType
    {
        protected ObjectType outerType;

        public InnerObjectType(string internalName, string qualifiedName, string name, ObjectType outerType) :
        base(internalName, qualifiedName, name)
        {
            this.outerType = outerType;
            Debug.Assert(name == null || !Character.isDigit(name.charAt(0)) || (qualifiedName == null));
        }

        public InnerObjectType(string internalName, string qualifiedName, string name, int dimension, ObjectType outerType) :
        base(internalName, qualifiedName, name, dimension)
        {
            this.outerType = outerType;
            Debug.Assert(name == null || !Character.isDigit(name.charAt(0)) || (qualifiedName == null));
        }

        public InnerObjectType(string internalName, string qualifiedName, string name, BaseTypeArgument typeArguments, ObjectType outerType) :
        base(internalName, qualifiedName, name, typeArguments)
        {
            this.outerType = outerType;
            Debug.Assert(name == null || !Character.isDigit(name.charAt(0)) || (qualifiedName == null));
        }

        public InnerObjectType(string internalName, string qualifiedName, string name, BaseTypeArgument typeArguments, int dimension, ObjectType outerType) :
        base(internalName, qualifiedName, name, typeArguments, dimension)
        {
            this.outerType = outerType;
            Debug.Assert(name == null || !Character.isDigit(name.charAt(0)) || (qualifiedName == null));
        }

        public InnerObjectType(InnerObjectType iot) :
        base(iot)
        {
            outerType = iot.outerType;
        }

        public ObjectType getOuterType()
        {
            return outerType;
        }

        public Type createType(int dimension)
        {
            Debug.Assert(dimension >= 0);
            return new InnerObjectType(internalName, qualifiedName, name, typeArguments, dimension, outerType);
        }

        public ObjectType createType(BaseTypeArgument typeArguments)
        {
            return new InnerObjectType(internalName, qualifiedName, name, typeArguments, dimension, outerType);
        }
        
        public bool equals(object o)
        {
            if (this == o) return true;
            if (!(o is InnerObjectType)) return false;
            if (!base.Equals(o)) return false;

            InnerObjectType that = (InnerObjectType)o;

            if (!outerType.Equals(that.outerType)) return false;

            return true;
        }

        public int hashCode()
        {
            int result = 111476860 + base.hashCode();
            result = 31 * result + outerType.hashCode();
            return result;
        }

        public bool isInnerObjectType()
        {
            return true;
        }

        public bool isInnerObjectTypeArgument()
        {
            return true;
        }

        public void accept(TypeVisitor visitor)
        {
            visitor.visit(this);
        }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            if (typeArguments == null)
                return $"InnerObjectType{{{outerType}.{descriptor}}}";
            else
                return $"InnerObjectType{{{outerType}.{descriptor}<{typeArguments}>}}";
        }
    }
}
