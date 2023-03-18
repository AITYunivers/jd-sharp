/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class CharacterConstantToken : Token
    {
        protected string c;
        protected string ownerInternalName;

        public CharacterConstantToken(string c, string ownerInternalName)
        {
            this.c = c;
            this.ownerInternalName = ownerInternalName;
        }

        public string getCharacter()
        {
            return c;
        }

        public string getOwnerInternalName()
        {
            return ownerInternalName;
        }

        public override string ToString()
        {
            return $"CharacterConstantToken{{'{c}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
