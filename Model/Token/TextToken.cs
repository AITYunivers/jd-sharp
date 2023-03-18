/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class TextToken : Token
    {
        public static TextToken AT = new TextToken("@");
        public static TextToken COMMA = new TextToken(",");
        public static TextToken COLON = new TextToken(":");
        public static TextToken COLON_COLON = new TextToken("::");
        public static TextToken COMMA_SPACE = new TextToken(", ");
        public static TextToken DIAMOND = new TextToken("<>");
        public static TextToken DOT = new TextToken(".");
        public static TextToken DIMENSION_1 = new TextToken("[]");
        public static TextToken DIMENSION_2 = new TextToken("[][]");
        public static TextToken INFINITE_FOR = new TextToken(" (;;)");
        public static TextToken LEFTRIGHTCURLYBRACKETS = new TextToken("{}");
        public static TextToken LEFTROUNDBRACKET = new TextToken("(");
        public static TextToken RIGHTROUNDBRACKET = new TextToken(")");
        public static TextToken LEFTRIGHTROUNDBRACKETS = new TextToken("()");
        public static TextToken LEFTANGLEBRACKET = new TextToken("<");
        public static TextToken RIGHTANGLEBRACKET = new TextToken(">");
        public static TextToken QUESTIONMARK = new TextToken("?");
        public static TextToken QUESTIONMARK_SPACE = new TextToken("? ");
        public static TextToken SPACE = new TextToken(" ");
        public static TextToken SPACE_AND_SPACE = new TextToken(" & ");
        public static TextToken SPACE_ARROW_SPACE = new TextToken(" -> ");
        public static TextToken SPACE_COLON_SPACE = new TextToken(" : ");
        public static TextToken SPACE_EQUAL_SPACE = new TextToken(" = ");
        public static TextToken SPACE_QUESTION_SPACE = new TextToken(" ? ");
        public static TextToken SPACE_LEFTROUNDBRACKET = new TextToken(" (");
        public static TextToken SEMICOLON = new TextToken(";");
        public static TextToken SEMICOLON_SPACE = new TextToken("; ");
        public static TextToken VARARGS = new TextToken("... ");
        public static TextToken VERTICALLINE = new TextToken("|");
        public static TextToken EXCLAMATION = new TextToken("!");

        protected string text;

        public TextToken(string text)
        {
            this.text = text;
        }

        public string getText()
        {
            return text;
        }

        public override string ToString()
        {
            return $"TextToken{{'{text}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
