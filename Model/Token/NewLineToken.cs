/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class NewLineToken : Token
    {
        public static NewLineToken NEWLINE_1 = new NewLineToken(1);
        public static NewLineToken NEWLINE_2 = new NewLineToken(2);

        protected int count;

        public NewLineToken(int count)
        {
            this.count = count;
        }

        public int getCount()
        {
            return count;
        }

        public override string ToString()
        {
            return $"NewLineToken{{{count}}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
