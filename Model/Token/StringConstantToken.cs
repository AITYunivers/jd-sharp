/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class StringConstantToken : Token
    {
        protected string text;
        protected string ownerInternalName;

        public StringConstantToken(string text, string ownerInternalName)
        {
            this.text = text;
            this.ownerInternalName = ownerInternalName;
        }

        public string getText()
        {
            return text;
        }

        public string getOwnerInternalName()
        {
            return ownerInternalName;
        }

        public override string ToString()
        {
            return $"StringConstantToken{{'{text}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
