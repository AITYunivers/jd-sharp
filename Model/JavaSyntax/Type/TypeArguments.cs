/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Util;
using System.Collections.ObjectModel;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class TypeArguments : DefaultList<TypeArgument>, BaseTypeArgument
    {
        public TypeArguments() { }

        public TypeArguments(int capacity) :
        base(capacity) {}

        public TypeArguments(Collection<TypeArgument> list) :
        base(list) {}
        
        public bool isList()
        {
            return true;
        }

        public bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            if (typeArgument.GetType() != typeof(TypeArguments))
                return false;

            TypeArguments ata = (TypeArguments)typeArgument;

            if (Count != ata.Count)
                return false;

            List<TypeArgument> iterator1 = new();// iterator();
            List<TypeArgument> iterator2 = new();// ata.iterator();

            DefaultList<object> i1 = EMPTY_LIST.iterator();
            DefaultList<object> i2 = ata.EMPTY_LIST.iterator();

            foreach (var obj in i1)
                if (obj is TypeArgument)
                    iterator1.Add((TypeArgument)obj);

            foreach (var obj in i2)
                if (obj is TypeArgument)
                    iterator2.Add((TypeArgument)obj);

            for (int i = 0; i < iterator1.Count; i++)
                if (!iterator1[i].isTypeArgumentAssignableFrom(typeBounds, iterator2[i]))
                    return false;

            return true;
        }
    
        public bool isTypeArgumentList()
        {
            return true;
        }
        
        public TypeArgument getTypeArgumentFirst()
        {
            return getFirst();
        }

        
        public DefaultList<TypeArgument> getTypeArgumentList()
        {
            return this;
        }

        public int typeArgumentSize()
        {
            return Count;
        }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
