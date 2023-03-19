using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Util
{
    public interface Base<T> : List<T>
    {
        bool isList()
        {
            return false;
        }

        T getFirst()
        {
            return (T)this;
        }

        T getLast()
        {
            return (T)this;
        }

        DefaultList<T> getList()
        {
            throw new UnsupportedOperationException();
        }

        int size()
        {
            return 1;
        }

        List<T> iterator()
        {
            return new List<T>()
            {
                private bool hasNext = true;
                public bool hasNext()
                {
                    return hasNext;
                }
                public T next()
                {
                    if (hasNext)
                    {
                        hasNext = false;
                        return (T)Base.this;
                    }
                    throw new Exception();
                }
                public void remove()
                {
                    throw new Exception();
                }
            };
        }
    }
}
