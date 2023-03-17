/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class AttributeParameterAnnotations : Attribute
    {
        protected Annotations[] parameterAnnotations;

        public AttributeParameterAnnotations(Annotations[] parameterAnnotations)
        {
            this.parameterAnnotations = parameterAnnotations;
        }

        public Annotations[] getParameterAnnotations()
        {
            return parameterAnnotations;
        }
    }
}
