/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class StartBlockToken : Token
    {
        public static StartBlockToken START_BLOCK = new StartBlockToken("{");
        public static StartBlockToken START_ARRAY_BLOCK = new StartBlockToken("[");
        public static StartBlockToken START_ARRAY_INITIALIZER_BLOCK = new StartBlockToken("{");
        public static StartBlockToken START_PARAMETERS_BLOCK = new StartBlockToken("(");
        public static StartBlockToken START_RESOURCES_BLOCK = new StartBlockToken("(");
        public static StartBlockToken START_DECLARATION_OR_STATEMENT_BLOCK = new StartBlockToken("");

        protected string text;

        protected StartBlockToken(string text)
        {
            this.text = text;
        }

        public string getText()
        {
            return text;
        }

        public override string ToString()
        {
            return $"StartBlockToken{{'{text}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
