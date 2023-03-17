/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class Annotation
    {
        protected string descriptor;
        protected ElementValuePair[] elementValuePairs;

        public Annotation(string descriptor, ElementValuePair[] elementValuePairs)
        {
            this.descriptor = descriptor;
            this.elementValuePairs = elementValuePairs;
        }

        public string getDescriptor()
        {
            return descriptor;
        }

        public ElementValuePair[] getElementValuePairs()
        {
            return elementValuePairs;
        }
    }
}
