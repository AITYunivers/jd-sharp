/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using System.Diagnostics;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class GenericType : Type
    {
        protected string name;
        protected int dimension;

        public GenericType(string name)
        {
            this.name = name;
            dimension = 0;
        }

        public GenericType(string name, int dimension)
        {
            this.name = name;
            this.dimension = dimension;
        }

        public string getName()
        {
            return name;
        }

        public string getDescriptor()
        {
            return name;
        }

        public int getDimension()
        {
            return dimension;
        }

        public Type createType(int dimension)
        {
            Debug.Assert(dimension >= 0);
            if (this.dimension == dimension)
                return this;
            else
                return new GenericType(name, dimension);
        }

        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            GenericType that = (GenericType)o;

            if (dimension != that.dimension) return false;
            if (!name.Equals(that.name)) return false;

            return true;
        }

        public int hashCode()
        {
            int result = 991890290 + name.GetHashCode();
            result = 31 * result + dimension;
            return result;
        }

        public void accept(TypeVisitor visitor)
        {
            visitor.visit(this);
        }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }

        public bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            return equals(typeArgument);
        }

        public bool isGenericType()
        {
            return true;
        }

        public bool isGenericTypeArgument() { return true; }

        public override string ToString()
        {
            string str = name;

            if (dimension > 0)
                str += $", dimension={dimension}";

            return str + "}";
        }
    }
}
