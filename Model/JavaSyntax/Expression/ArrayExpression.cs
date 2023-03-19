using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Expression
{
    public class ArrayExpression : AbstractLineNumberTypeExpression
    {
        protected Expression expression;
        protected Expression index;

        public ArrayExpression(Expression expression, Expression index)
        {
            super(createItemType(expression));
            this.expression = expression;
            this.index = index;
        }

        public ArrayExpression(int lineNumber, Expression expression, Expression index)
        {
            super(lineNumber, createItemType(expression));
            this.expression = expression;
            this.index = index;
        }

        @Override
    public Expression getExpression()
        {
            return expression;
        }

        public void setExpression(Expression expression)
        {
            this.expression = expression;
        }

        public Expression getIndex()
        {
            return index;
        }

        public void setIndex(Expression index)
        {
            this.index = index;
        }

        @Override
    public int getPriority()
        {
            return 1;
        }

        protected static Type createItemType(Expression expression)
        {
            Type type = expression.getType();
            int dimension = type.getDimension();

            return type.createType((dimension > 0) ? dimension - 1 : 0);
        }

        @Override
    public boolean isArrayExpression() { return true; }

        @Override
    public void accept(ExpressionVisitor visitor)
        {
            visitor.visit(this);
        }

        @Override
    public String toString()
        {
            return "ArrayExpression{" + expression + "[" + index + "]}";
        }
    }
}
