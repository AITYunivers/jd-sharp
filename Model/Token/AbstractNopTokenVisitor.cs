/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Token
{
    public abstract class AbstractNopTokenVisitor : TokenVisitor
    {
        public void visit(BooleanConstantToken token) { }
        public void visit(CharacterConstantToken token) { }
        public void visit(DeclarationToken token) { }
        public void visit(EndBlockToken token) { }
        public void visit(EndMarkerToken token) { }
        public void visit(KeywordToken token) { }
        public void visit(LineNumberToken token) { }
        public void visit(NewLineToken token) { }
        public void visit(NumericConstantToken token) { }
        public void visit(ReferenceToken token) { }
        public void visit(StartBlockToken token) { }
        public void visit(StartMarkerToken token) { }
        public void visit(StringConstantToken token) { }
        public void visit(TextToken token) { }
    }
}
