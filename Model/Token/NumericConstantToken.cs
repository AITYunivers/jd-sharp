/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class NumericConstantToken : Token
    {
        protected string text;

        public NumericConstantToken(string text)
        {
            this.text = text;
        }

        public string getText()
        {
            return text;
        }

        public override string ToString()
        {
            return $"NumericConstantToken{{'{text}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
