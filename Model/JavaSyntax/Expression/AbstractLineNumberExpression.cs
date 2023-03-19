using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Expression
{
    public abstract class AbstractLineNumberExpression : Expression
    {
        protected int lineNumber;

        protected AbstractLineNumberExpression()
        {
            this.lineNumber = UNKNOWN_LINE_NUMBER;
        }

        protected AbstractLineNumberExpression(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }

        @Override
    public int getLineNumber()
        {
            return lineNumber;
        }

        @Override
    public int getPriority()
        {
            return 0;
        }
    }
}
