/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.API.Printer;

namespace JD_Sharp.Model.Token
{
    public class StartMarkerToken : Token
    {
        public static StartMarkerToken COMMENT = new StartMarkerToken(Printer.COMMENT);
        public static StartMarkerToken JAVADOC = new StartMarkerToken(Printer.JAVADOC);
        public static StartMarkerToken ERROR = new StartMarkerToken(Printer.ERROR);
        public static StartMarkerToken IMPORT_STATEMENTS = new StartMarkerToken(Printer.IMPORT_STATEMENTS);

        protected int type;

        protected StartMarkerToken(int type)
        {
            this.type = type;
        }

        public int getType()
        {
            return type;
        }

        public override string ToString()
        {
            return $"StartMarkerToken{{'{type}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
