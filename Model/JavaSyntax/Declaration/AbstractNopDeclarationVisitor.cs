using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public abstract class AbstractNopDeclarationVisitor : DeclarationVisitor
    {
        public void visit(AnnotationDeclaration declaration) { }
        public void visit(ArrayVariableInitializer declaration) { }
        public void visit(BodyDeclaration declaration) { }
        public void visit(ClassDeclaration declaration) { }
        public void visit(ConstructorDeclaration declaration) { }
        public void visit(EnumDeclaration declaration) { }
        public void visit(EnumDeclaration.Constant declaration) { }
        public void visit(ExpressionVariableInitializer declaration) { }
        public void visit(FieldDeclaration declaration) { }
        public void visit(FieldDeclarator declaration) { }
        public void visit(FieldDeclarators declarations) { }
        public void visit(FormalParameter declaration) { }
        public void visit(FormalParameters declarations) { }
        public void visit(InstanceInitializerDeclaration declaration) { }
        public void visit(InterfaceDeclaration declaration) { }
        public void visit(LocalVariableDeclaration declaration) { }
        public void visit(LocalVariableDeclarator declarator) { }
        public void visit(LocalVariableDeclarators declarators) { }
        public void visit(MemberDeclarations declarations) { }
        public void visit(MethodDeclaration declaration) { }
        public void visit(ModuleDeclaration declarations) { }
        public void visit(StaticInitializerDeclaration declaration) { }
        public void visit(TypeDeclarations declaration) { }
    }
}
