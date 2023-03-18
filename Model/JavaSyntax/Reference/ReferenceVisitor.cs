using JD_Sharp.Model.ClassFile.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Reference
{
    public interface ReferenceVisitor
    {
        void visit(AnnotationElementValue reference);
        void visit(AnnotationReference reference);
        void visit(AnnotationReferences references);
        void visit(ElementValueArrayInitializerElementValue reference);
        void visit(ElementValues references);
        void visit(ElementValuePair reference);
        void visit(ElementValuePairs references);
        void visit(ExpressionElementValue reference);
        void visit(InnerObjectReference reference);
        void visit(ObjectReference reference);
    }
}
