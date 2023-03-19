using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Expression
{
    public abstract class AbstractLineNumberTypeExpression : AbstractLineNumberExpression
    {
        protected Type type;

        protected AbstractLineNumberTypeExpression(Type type)
        {
            this.type = type;
        }

        protected AbstractLineNumberTypeExpression(int lineNumber, Type type)
        {
            super(lineNumber);
            this.type = type;
        }

        @Override
    public Type getType()
        {
            return type;
        }

        public void setType(Type type)
        {
            this.type = type;
        }
    }
}
