using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public class BodyDeclaration : Declaration
    {
        protected string internalTypeName;
        protected BaseMemberDeclaration memberDeclarations;

        public BodyDeclaration(string internalTypeName, BaseMemberDeclaration memberDeclarations)
        {
            this.internalTypeName = internalTypeName;
            this.memberDeclarations = memberDeclarations;
        }

        public string getInternalTypeName()
        {
            return internalTypeName;
        }

        public BaseMemberDeclaration getMemberDeclarations()
        {
            return memberDeclarations;
        }

        public void accept(DeclarationVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
