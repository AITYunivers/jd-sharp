/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class KeywordToken : Token
    {
        protected string keyword;

        public KeywordToken(string keyword)
        {
            this.keyword = keyword;
        }

        public string getKeyword()
        {
            return keyword;
        }

        public override string ToString()
        {
            return $"KeywordToken{{'{keyword}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
