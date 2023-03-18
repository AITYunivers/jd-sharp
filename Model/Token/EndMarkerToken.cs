/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.API.Printer;

namespace JD_Sharp.Model.Token
{
    public class EndMarkerToken : Token
    {
        public static EndMarkerToken COMMENT = new EndMarkerToken(Printer.COMMENT);
        public static EndMarkerToken JAVADOC = new EndMarkerToken(Printer.JAVADOC);
        public static EndMarkerToken ERROR = new EndMarkerToken(Printer.ERROR);
        public static EndMarkerToken IMPORT_STATEMENTS = new EndMarkerToken(Printer.IMPORT_STATEMENTS);

        protected int type;

        protected EndMarkerToken(int type)
        {
            this.type = type;
        }

        public int getType()
        {
            return type;
        }

        public override string ToString()
        {
            return $"EndMarkerToken{{'{type}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
