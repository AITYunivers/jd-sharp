using JD_Sharp.API.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Expression
{
    public interface Expression : BaseExpression
    {
        int UNKNOWN_LINE_NUMBER = Printer.UNKNOWN_LINE_NUMBER;

        int getLineNumber();

        Type getType();

        int getPriority();
    }
}
