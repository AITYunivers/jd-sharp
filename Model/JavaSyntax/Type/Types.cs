/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class Types : DefaultList<Type>, BaseType
    {
        public Types() { }

        public Types(int capacity) :
        base(capacity) {}

        public Types(Collection<Type> collection) :
        base(collection) {}

        public Types(Type type, Type[] types) :
        base(type, types)
        {
            if (types != null && types.Length > 0)
            {
                Console.WriteLine("Uses 'Type' implementation instead");
                Debug.Assert(true);
            }
        }

        public bool isTypes() { return true; }

        public void accept(TypeVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
