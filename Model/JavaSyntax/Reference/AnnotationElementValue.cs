using JD_Sharp.Model.ClassFile.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Reference
{
    internal class AnnotationElementValue : AnnotationReference, ElementValue
    {
        public AnnotationElementValue(AnnotationReference annotationReference) :
        base(annotationReference.getType(),
             annotationReference.getElementValue(),
             annotationReference.getElementValuePairs()) {}

        public void accept(ReferenceVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return $"AnnotationElementValue{{type={type}, elementValue={elementValue}, elementValuePairs={elementValuePairs} }}";
        }
    }
}
