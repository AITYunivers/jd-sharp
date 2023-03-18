/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using System.Collections;
using System.Collections.ObjectModel;

namespace JD_Sharp.Util
{
    public class DefaultList<E> : ArrayList
    {
        public EmptyList<object> EMPTY_LIST = new();

        public DefaultList() { }

        public DefaultList(int capacity) :
        base(capacity) {}

        public DefaultList(Collection<E> collection) :
        base(collection) {}

        public DefaultList(E element, E[] elements)
        {
            Add(element);

            foreach (E e in elements)
                Add(e);
        }

        public DefaultList(E[] elements)
        {
            if ((elements != null) && (elements.Length > 0))
                foreach (E e in elements)
                    Add(e);
        }

        public E getFirst()
        {
            return (E)this[0];
        }

        public E getLast()
        {
            return (E)this[Count - 1];
        }

        public E removeFirst()
        {
            E e = (E)this[0];
            Remove(e);
            return e;
        }

        public E removeLast()
        {
            E e = (E)this[Count - 1];
            Remove(e);
            return e;
        }

        public bool isList()
        {
            return true;
        }

        public DefaultList<E> getList()
        {
            return this;
        }

        public static <T> DefaultList<T> emptyList()
        {
            return EMPTY_LIST;
        }

        public class EmptyList<E> : DefaultList<E> 
        {
            public EmptyList() : base(0) { }

            public E set(int index, E e)
            {
                throw new NotSupportedException();
            }
            public void add(int index, E e)
            {
                throw new NotSupportedException();
            }
            public E remove(int index)
            {
                throw new NotSupportedException();
            }
            public DefaultList<E> iterator() { return this; }

            public bool hasNext() { return false; }
            public E next() { throw new InvalidOperationException(); }
            public void remove() { throw new NotSupportedException(); }
        }
    }
}
