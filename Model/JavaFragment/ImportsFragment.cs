/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.Fragment;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JD_Sharp.Model.JavaFragment
{
    public class ImportsFragment : FlexibleFragment, JavaFragment
    {
        protected static ImportCountComparator COUNT_COMPARATOR = new ImportCountComparator();
        
        protected Dictionary<string, Import> importMap = new();

        public ImportsFragment(int weight) :
        base(0, -1, -1, weight, "Imports") {}

        public void addImport(string internalName, string qualifiedName)
        {
            Import imp = importMap[internalName];

            if (imp == null)
                importMap[internalName] = new Import(internalName, qualifiedName);
            else
                imp.incCounter();
        }

        public bool incCounter(string internalName)
        {
            Import imp = importMap[internalName];

            if (imp == null)
                return false;
            imp.incCounter();
            return true;
        }

        public bool isEmpty()
        {
            return importMap.Count() == 0;
        }

        public void initLineCounts()
        {
            maximalLineCount = initialLineCount = lineCount = importMap.Count();
        }

        public bool contains(string internalName)
        {
            return importMap.ContainsKey(internalName);
        }

        public int getLineCount()
        {
            if (lineCount != -1)
            {
                Console.WriteLine("Call initLineCounts() before");
                Debug.Assert(true);
            }
            return lineCount;
        }

        public Collection<Import> getImports()
        {
            Collection<Import> imports = new();

            foreach (Import imp0rt in importMap.Values)
                imports.Add(imp0rt);

            return imports;
        }

        public class Import
        {
            protected string internalName;
            protected string qualifiedName;
            protected int counter;

            public Import(string internalName, string qualifiedName)
            {
                this.internalName = internalName;
                this.qualifiedName = qualifiedName;
                counter = 1;
            }

            public string getInternalName()
            {
                return internalName;
            }
            public string getQualifiedName()
            {
                return qualifiedName;
            }
            public int getCounter()
            {
                return counter;
            }
            public void incCounter()
            {
                counter++;
            }
        }

        public void accept(JavaFragmentVisitor visitor)
        {
            visitor.visit(this);
        }

        protected class ImportCountComparator
        {
            public int compare(Import tr1, Import tr2)
            {
                return tr2.getCounter() - tr1.getCounter();
            }
        }
    }
}
