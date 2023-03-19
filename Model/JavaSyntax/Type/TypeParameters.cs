/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Util;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class TypeParameters : DefaultList<TypeParameter>, BaseTypeParameter
    {
        public TypeParameters() { }

        public TypeParameters(int capacity) :
        base(capacity) {}

        public TypeParameters(Collection<TypeParameter> collection) :
        base(collection)
        {
            if (collection != null && collection.Count > 1)
            {
                Console.WriteLine("Uses 'TypeParameter' instead");
                Debug.Assert(true);
            }
        }

        public TypeParameters(TypeParameter type, TypeParameter[] types) :
        base(types.Count() + 1)
        {
            if (types != null && types.Length > 1)
            {
                Console.WriteLine("Uses 'TypeParameter' instead");
                Debug.Assert(true);
            }

            Add(type);

            foreach (TypeParameter t in types)
                Add(t);
        }

        public void accept(TypeParameterVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            string str = this[0].ToString();

            for (int i = 1; i < Count; i++)
                str += $" & {this[i]}";

            return str;
        }
    }
}
