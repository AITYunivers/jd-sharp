/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class ElementValueAnnotationValue : ElementValue
    {
        protected Annotation annotationValue;

        public ElementValueAnnotationValue(Annotation annotationValue)
        {
            this.annotationValue = annotationValue;
        }

        public Annotation getAnnotationValue()
        {
            return annotationValue;
        }

        public void accept(ElementValueVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
