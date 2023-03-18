using JD_Sharp.Model.ClassFile.Attribute;
using JD_Sharp.Model.JavaSyntax.Declaration;
using JD_Sharp.Model.JavaSyntax.Reference;
using JD_Sharp.Model.JavaSyntax.Type;
using JD_Sharp.Service.Fragmenter.JavaSyntaxToJavaFragment.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax
{
    public abstract class AbstractJavaSyntaxVisitor : AbstractTypeArgumentVisitor,
    DeclarationVisitor, ExpressionVisitor, ReferenceVisitor, StatementVisitor,
    TypeVisitor, TypeParameterVisitor
    {
        public void visit(CompilationUnit compilationUnit)
        {
            compilationUnit.getTypeDeclarations().accept(this);
        }

        
    public void visit(AnnotationDeclaration declaration)
        {
            safeAccept(declaration.getAnnotationDeclarators());
            safeAccept(declaration.getBodyDeclaration());
            safeAccept(declaration.getAnnotationReferences());
        }

        
    public void visit(ArrayVariableInitializer declaration)
        {
            acceptListDeclaration(declaration);
        }

        
    public void visit(BodyDeclaration declaration)
        {
            safeAccept(declaration.getMemberDeclarations());
        }

        
    public void visit(ClassDeclaration declaration)
        {
            BaseType superType = declaration.getSuperType();

            if (superType != null)
            {
                superType.accept(this);
            }

            safeAccept(declaration.getTypeParameters());
            safeAccept(declaration.getInterfaces());
            safeAccept(declaration.getAnnotationReferences());
            safeAccept(declaration.getBodyDeclaration());
        }

         public void visit(CommentStatement statement) { }

         public void visit(CommentExpression expression) { }

        
    public void visit(ConstructorInvocationExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getParameters());
        }

        
    public void visit(ConstructorDeclaration declaration)
        {
            safeAccept(declaration.getAnnotationReferences());
            safeAccept(declaration.getFormalParameters());
            safeAccept(declaration.getExceptionTypes());
            safeAccept(declaration.getStatements());
        }

        
    public void visit(EnumDeclaration declaration)
        {
            visit((TypeDeclaration)declaration);
            safeAccept(declaration.getInterfaces());
            safeAcceptListDeclaration(declaration.getConstants());
            safeAccept(declaration.getBodyDeclaration());
        }

        
    public void visit(EnumDeclaration.Constant declaration)
        {
            safeAccept(declaration.getAnnotationReferences());
            safeAccept(declaration.getArguments());
            safeAccept(declaration.getBodyDeclaration());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(Expressions list)
        {
            acceptListExpression(list);
        }

        
    public void visit(ExpressionVariableInitializer declaration)
        {
            declaration.getExpression().accept(this);
        }

        
    public void visit(FieldDeclaration declaration)
        {
            BaseType type = declaration.getType();

            type.accept(this);
            safeAccept(declaration.getAnnotationReferences());
            declaration.getFieldDeclarators().accept(this);
        }

        
    public void visit(FieldDeclarator declarator)
        {
            safeAccept(declarator.getVariableInitializer());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(FieldDeclarators list)
        {
            acceptListDeclaration((List <? extends Declaration >)list);
        }

        
    public void visit(FormalParameter declaration)
        {
            BaseType type = declaration.getType();

            type.accept(this);
            safeAccept(declaration.getAnnotationReferences());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(FormalParameters list)
        {
            acceptListDeclaration(list);
        }

        
    public void visit(InstanceInitializerDeclaration declaration)
        {
            safeAccept(declaration.getStatements());
        }

        
    public void visit(InterfaceDeclaration declaration)
        {
            safeAccept(declaration.getInterfaces());
            safeAccept(declaration.getAnnotationReferences());
            safeAccept(declaration.getBodyDeclaration());
        }

        
    public void visit(LocalVariableDeclaration declaration)
        {
            BaseType type = declaration.getType();

            type.accept(this);
            declaration.getLocalVariableDeclarators().accept(this);
        }

        
    public void visit(LocalVariableDeclarator declarator)
        {
            safeAccept(declarator.getVariableInitializer());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(LocalVariableDeclarators declarators)
        {
            acceptListDeclaration(declarators);
        }

        
    public void visit(MethodDeclaration declaration)
        {
            BaseType returnedType = declaration.getReturnedType();

            returnedType.accept(this);
            safeAccept(declaration.getAnnotationReferences());
            safeAccept(declaration.getFormalParameters());
            safeAccept(declaration.getExceptionTypes());
            safeAccept(declaration.getStatements());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(MemberDeclarations declarations)
        {
            acceptListDeclaration(declarations);
        }

        
    public void visit(ModuleDeclaration declarations) { }

        
        @SuppressWarnings("unchecked")
    public void visit(TypeDeclarations list)
        {
            acceptListDeclaration(list);
        }

        
    public void visit(ArrayExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            expression.getExpression().accept(this);
            expression.getIndex().accept(this);
        }

        
    public void visit(BinaryOperatorExpression expression)
        {
            expression.getLeftExpression().accept(this);
            expression.getRightExpression().accept(this);
        }
        
    public void visit(BooleanExpression expression) { }

        
    public void visit(CastExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            expression.getExpression().accept(this);
        }

        
    public void visit(ConstructorReferenceExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(DoubleConstantExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(EnumConstantReferenceExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(FieldReferenceExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getExpression());
        }

        
    public void visit(FloatConstantExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(IntegerConstantExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(InstanceOfExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            expression.getExpression().accept(this);
        }

        
    public void visit(LambdaFormalParametersExpression expression)
        {
            safeAccept(expression.getFormalParameters());
            expression.getStatements().accept(this);
        }

        
    public void visit(LambdaIdentifiersExpression expression)
        {
            safeAccept(expression.getStatements());
        }

         public void visit(LengthExpression expression)
        {
            expression.getExpression().accept(this);
        }

        
    public void visit(LocalVariableReferenceExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(LongConstantExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(MethodInvocationExpression expression)
        {
            expression.getExpression().accept(this);
            safeAccept(expression.getNonWildcardTypeArguments());
            safeAccept(expression.getParameters());
        }

        
    public void visit(MethodReferenceExpression expression)
        {
            expression.getExpression().accept(this);
        }

        
    public void visit(NewArray expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getDimensionExpressionList());
        }

        
    public void visit(NewExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getParameters());
            // safeAccept(expression.getBodyDeclaration());
        }

        
    public void visit(NewInitializedArray expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getArrayInitializer());
        }

        
    public void visit(NoExpression expression) { }

        
    public void visit(NullExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(TypeReferenceDotClassExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(ObjectTypeReferenceExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(ParenthesesExpression expression)
        {
            expression.getExpression().accept(this);
        }

        
    public void visit(PostOperatorExpression expression)
        {
            expression.getExpression().accept(this);
        }

        
    public void visit(PreOperatorExpression expression)
        {
            expression.getExpression().accept(this);
        }
        
    public void visit(StringConstantExpression expression) { }

        
    public void visit(SuperConstructorInvocationExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
            safeAccept(expression.getParameters());
        }

        
    public void visit(SuperExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(TernaryOperatorExpression expression)
        {
            expression.getCondition().accept(this);
            expression.getTrueExpression().accept(this);
            expression.getFalseExpression().accept(this);
        }

        
    public void visit(ThisExpression expression)
        {
            BaseType type = expression.getType();

            type.accept(this);
        }

        
    public void visit(AnnotationReference reference)
        {
            safeAccept(reference.getElementValue());
            safeAccept(reference.getElementValuePairs());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(AnnotationReferences list)
        {
            acceptListReference(list);
        }

        
    public void visit(ExpressionElementValue reference)
        {
            reference.getExpression().accept(this);
        }

        
    public void visit(ElementValueArrayInitializerElementValue reference)
        {
            safeAccept(reference.getElementValueArrayInitializer());
        }

        
    public void visit(AnnotationElementValue reference)
        {
            safeAccept(reference.getElementValue());
            safeAccept(reference.getElementValuePairs());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(ElementValues list)
        {
            acceptListReference(list);
        }

        
    public void visit(ElementValuePair reference)
        {
            reference.getElementValue().accept(this);
        }

        
        @SuppressWarnings("unchecked")
    public void visit(ElementValuePairs list)
        {
            acceptListReference(list);
        }

        
    public void visit(ObjectReference reference)
        {
            visit((ObjectType)reference);
        }

         public void visit(InnerObjectReference reference)
        {
            visit((InnerObjectType)reference);
        }

        
    public void visit(AssertStatement statement)
        {
            statement.getCondition().accept(this);
            safeAccept(statement.getMessage());
        }

        
    public void visit(BreakStatement statement) { }

         public void visit(ByteCodeStatement statement) { }

        
    public void visit(ContinueStatement statement) { }

        
    public void visit(DoWhileStatement statement)
        {
            safeAccept(statement.getCondition());
            safeAccept(statement.getStatements());
        }

        
    public void visit(ExpressionStatement statement)
        {
            statement.getExpression().accept(this);
        }

        
    public void visit(ForEachStatement statement)
        {
            BaseType type = statement.getType();

            type.accept(this);
            statement.getExpression().accept(this);
            safeAccept(statement.getStatements());
        }

        
    public void visit(ForStatement statement)
        {
            safeAccept(statement.getDeclaration());
            safeAccept(statement.getInit());
            safeAccept(statement.getCondition());
            safeAccept(statement.getUpdate());
            safeAccept(statement.getStatements());
        }

        
    public void visit(IfStatement statement)
        {
            statement.getCondition().accept(this);
            safeAccept(statement.getStatements());
        }

        
    public void visit(IfElseStatement statement)
        {
            statement.getCondition().accept(this);
            safeAccept(statement.getStatements());
            statement.getElseStatements().accept(this);
        }

        
    public void visit(LabelStatement statement)
        {
            safeAccept(statement.getStatement());
        }

        
    public void visit(LambdaExpressionStatement statement)
        {
            statement.getExpression().accept(this);
        }

        
    public void visit(LocalVariableDeclarationStatement statement)
        {
            visit((LocalVariableDeclaration)statement);
        }

        
    public void visit(NoStatement statement) { }

         public void visit(ReturnExpressionStatement statement)
        {
            statement.getExpression().accept(this);
        }

        
    public void visit(ReturnStatement statement) { }

        
        @SuppressWarnings("unchecked")
    public void visit(Statements list)
        {
            acceptListStatement(list);
        }

        
    public void visit(SwitchStatement statement)
        {
            statement.getCondition().accept(this);
            acceptListStatement(statement.getBlocks());
        }

        
    public void visit(SwitchStatement.DefaultLabel statement) { }

        
    public void visit(SwitchStatement.ExpressionLabel statement)
        {
            statement.getExpression().accept(this);
        }

        
    public void visit(SwitchStatement.LabelBlock statement)
        {
            statement.getLabel().accept(this);
            statement.getStatements().accept(this);
        }

        
    public void visit(SwitchStatement.MultiLabelsBlock statement)
        {
            safeAcceptListStatement(statement.getLabels());
            statement.getStatements().accept(this);
        }

        
    public void visit(SynchronizedStatement statement)
        {
            statement.getMonitor().accept(this);
            safeAccept(statement.getStatements());
        }

        
    public void visit(ThrowStatement statement)
        {
            statement.getExpression().accept(this);
        }

        
    public void visit(TryStatement statement)
        {
            safeAcceptListStatement(statement.getResources());
            statement.getTryStatements().accept(this);
            safeAcceptListStatement(statement.getCatchClauses());
            safeAccept(statement.getFinallyStatements());
        }

        
    public void visit(TryStatement.CatchClause statement)
        {
            BaseType type = statement.getType();

            type.accept(this);
            safeAccept(statement.getStatements());
        }

        
    public void visit(TryStatement.Resource statement)
        {
            BaseType type = statement.getType();

            type.accept(this);
            statement.getExpression().accept(this);
        }

        
    public void visit(StaticInitializerDeclaration declaration)
        {
            safeAccept(declaration.getStatements());
        }

        
    public void visit(TypeDeclarationStatement statement)
        {
            statement.getTypeDeclaration().accept(this);
        }

        
    public void visit(WhileStatement statement)
        {
            statement.getCondition().accept(this);
            safeAccept(statement.getStatements());
        }

        
    public void visit(TypeParameter parameter) { }

        
    public void visit(TypeParameterWithTypeBounds parameter)
        {
            parameter.getTypeBounds().accept(this);
        }

        
    public void visit(TypeParameters parameters)
        {
            Iterator<TypeParameter> iterator = parameters.iterator();

            while (iterator.hasNext())
                iterator.next().accept(this);
        }

        public void visit(TypeDeclaration declaration)
        {
            safeAccept(declaration.getAnnotationReferences());
        }

        
        @SuppressWarnings("unchecked")
    public void visit(Types types)
        {
            Iterator<Type> iterator = types.iterator();

            while (iterator.hasNext())
            {
                BaseType type = iterator.next();

                type.accept(this);
            }
        }

        public void acceptListDeclaration(List<? extends Declaration> list)
        {
            for (Declaration declaration : list)
                declaration.accept(this);
        }

        public void acceptListExpression(List<? extends Expression> list)
        {
            for (Expression expression : list)
                expression.accept(this);
        }

        public void acceptListReference(List<? extends Reference> list)
        {
            for (Reference reference : list)
                reference.accept(this);
        }

        public void acceptListStatement(List<? extends Statement> list)
        {
            for (Statement statement : list)
                statement.accept(this);
        }

        public void safeAccept(Declaration declaration)
        {
            if (declaration != null)
                declaration.accept(this);
        }

        public void safeAccept(BaseExpression expression)
        {
            if (expression != null)
                expression.accept(this);
        }

        public void safeAccept(Reference reference)
        {
            if (reference != null)
                reference.accept(this);
        }

        public void safeAccept(BaseStatement list)
        {
            if (list != null)
                list.accept(this);
        }

        public void safeAccept(BaseType list)
        {
            if (list != null)
                list.accept(this);
        }

        public void safeAccept(BaseTypeParameter list)
        {
            if (list != null)
                list.accept(this);
        }

        public void safeAcceptListDeclaration(List<? extends Declaration> list)
        {
            if (list != null)
            {
                for (Declaration declaration : list)
                    declaration.accept(this);
            }
        }

        public void safeAcceptListStatement(List<? extends Statement> list)
        {
            if (list != null)
            {
                for (Statement statement : list)
                    statement.accept(this);
            }
        }
    }
}
