using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public class AnnotationDeclaration : TypeDeclaration
    {
        protected BaseFieldDeclarator annotationDeclarators;

        public AnnotationDeclaration(BodyDeclaration annotationReferences, int flags, string internalName, string name, BaseFieldDeclarator annotationDeclarators, BodyDeclaration bodyDeclaration) :
        base(annotationReferences, flags, internalName, name, bodyDeclaration)
        {
            this.annotationDeclarators = annotationDeclarators;
        }

        public BaseFieldDeclarator getAnnotationDeclarators()
        {
            return annotationDeclarators;
        }

        public void accept(DeclarationVisitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return $"AnnotationDeclaration{{{internalTypeName}}}";
        }
    }
}
