using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public interface DeclarationVisitor
    {
        void visit(AnnotationDeclaration declaration);
        void visit(ArrayVariableInitializer declaration);
        void visit(BodyDeclaration declaration);
        void visit(ClassDeclaration declaration);
        void visit(ConstructorDeclaration declaration);
        void visit(EnumDeclaration declaration);
        void visit(EnumDeclaration.Constant declaration);
        void visit(ExpressionVariableInitializer declaration);
        void visit(FieldDeclaration declaration);
        void visit(FieldDeclarator declaration);
        void visit(FieldDeclarators declarations);
        void visit(FormalParameter declaration);
        void visit(FormalParameters declarations);
        void visit(InstanceInitializerDeclaration declaration);
        void visit(InterfaceDeclaration declaration);
        void visit(LocalVariableDeclaration declaration);
        void visit(LocalVariableDeclarator declarator);
        void visit(LocalVariableDeclarators declarators);
        void visit(MethodDeclaration declaration);
        void visit(MemberDeclarations declarations);
        void visit(ModuleDeclaration declarations);
        void visit(StaticInitializerDeclaration declaration);
        void visit(TypeDeclarations declarations);
    }
}
