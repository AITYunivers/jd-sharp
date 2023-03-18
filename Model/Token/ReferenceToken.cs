/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public class ReferenceToken : DeclarationToken
    {
        protected string ownerInternalName;

        public ReferenceToken(int type, string internalTypeName, string name, string descriptor, string ownerInternalName) :
        base(type, internalTypeName, name, descriptor)
        {
            this.ownerInternalName = ownerInternalName;
        }

        public string getOwnerInternalName()
        {
            return ownerInternalName;
        }

        public override string ToString()
        {
            return $"ReferenceToken{{'{name}'}}";
        }

        public void accept(TokenVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
