/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ElementValuePair
    {
        protected string elementName;
        protected ElementValue elementValue;

        public ElementValuePair(string elementName, ElementValue elementValue)
        {
            this.elementName = elementName;
            this.elementValue = elementValue;
        }

        public string getElementName()
        {
            return elementName;
        }

        
        public T getElementValue<T>() where T: ElementValue
        {
            return (T)elementValue;
        }
    }
}
