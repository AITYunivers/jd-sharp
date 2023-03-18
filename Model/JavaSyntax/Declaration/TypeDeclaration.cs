using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public abstract class TypeDeclaration : BaseTypeDeclaration, MemberDeclaration
    {
        protected BaseAnnotationReference annotationReferences;
        protected int flags;
        protected string internalTypeName;
        protected string name;
        protected BodyDeclaration bodyDeclaration;

        protected TypeDeclaration(BaseAnnotationReference annotationReferences, int flags, string internalTypeName, string name, BodyDeclaration bodyDeclaration)
        {
            this.annotationReferences = annotationReferences;
            this.flags = flags;
            this.internalTypeName = internalTypeName;
            this.name = name;
            this.bodyDeclaration = bodyDeclaration;
        }

        public BaseAnnotationReference getAnnotationReferences()
        {
            return annotationReferences;
        }

        public int getFlags()
        {
            return flags;
        }

        public string getInternalTypeName()
        {
            return internalTypeName;
        }

        public string getName()
        {
            return name;
        }

        public BodyDeclaration getBodyDeclaration()
        {
            return bodyDeclaration;
        }
    }
}
