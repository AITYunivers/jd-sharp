/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class EndBlockToken : Token
    {
        public static EndBlockToken END_BLOCK = new EndBlockToken("}");
        public static EndBlockToken END_ARRAY_BLOCK = new EndBlockToken("]");
        public static EndBlockToken END_ARRAY_INITIALIZER_BLOCK = new EndBlockToken("}");
        public static EndBlockToken END_PARAMETERS_BLOCK = new EndBlockToken(")");
        public static EndBlockToken END_RESOURCES_BLOCK = new EndBlockToken(")");
        public static EndBlockToken END_DECLARATION_OR_STATEMENT_BLOCK = new EndBlockToken("");

        protected string text;

        public EndBlockToken(string text)
        {
            this.text = text;
        }

        public string getText()
        {
            return text;
        }

        public override string ToString()
        {
            return $"EndBlockToken{{'{text}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
