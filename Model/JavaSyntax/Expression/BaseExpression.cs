using JD_Sharp.Model.JavaSyntax.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Expression
{
    public interface BaseExpression : Base<Expression>
    {
        void accept(ExpressionVisitor visitor);

        bool isArrayExpression() { return false; }
        bool isBinaryOperatorExpression() { return false; }
        bool isBooleanExpression() { return false; }
        bool isCastExpression() { return false; }
        bool isConstructorInvocationExpression() { return false; }
        bool isDoubleConstantExpression() { return false; }
        bool isFieldReferenceExpression() { return false; }
        bool isFloatConstantExpression() { return false; }
        bool isIntegerConstantExpression() { return false; }
        bool isLengthExpression() { return false; }
        bool isLocalVariableReferenceExpression() { return false; }
        bool isLongConstantExpression() { return false; }
        bool isMethodInvocationExpression() { return false; }
        bool isNewArray() { return false; }
        bool isNewExpression() { return false; }
        bool isNewInitializedArray() { return false; }
        bool isNullExpression() { return false; }
        bool isObjectTypeReferenceExpression() { return false; }
        bool isPostOperatorExpression() { return false; }
        bool isPreOperatorExpression() { return false; }
        bool isStringConstantExpression() { return false; }
        bool isSuperConstructorInvocationExpression() { return false; }
        bool isSuperExpression() { return false; }
        bool isTernaryOperatorExpression() { return false; }
        bool isThisExpression() { return false; }

        BaseExpression getDimensionExpressionList() { return NO_EXPRESSION; }
        BaseExpression getParameters() { return NO_EXPRESSION; }

        Expression getCondition() { return NO_EXPRESSION; }
        Expression getExpression() { return NO_EXPRESSION; }
        Expression getTrueExpression() { return NO_EXPRESSION; }
        Expression getFalseExpression() { return NO_EXPRESSION; }
        Expression getIndex() { return NO_EXPRESSION; }
        Expression getLeftExpression() { return NO_EXPRESSION; }
        Expression getRightExpression() { return NO_EXPRESSION; }

        string getDescriptor() { return ""; }
        double getDoubleValue() { return 0D; }
        float getFloatValue() { return 0F; }
        int getIntegerValue() { return 0; }
        string getInternalTypeName() { return ""; }
        long getLongValue() { return 0L; }
        string getName() { return ""; }
        ObjectType getObjectType() { return ObjectType.TYPE_UNDEFINED_OBJECT; }
        string getOperator() { return ""; }
        string getStringValue() { return ""; }
    }
}
