/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using JD_Sharp.Model.JavaSyntax.Declaration;

namespace JD_Sharp.Model.JavaSyntax
{
    public class CompilationUnit
    {
        protected BaseTypeDeclaration typeDeclarations;

        public CompilationUnit(BaseTypeDeclaration typeDeclarations)
        {
            this.typeDeclarations = typeDeclarations;
        }

        public BaseTypeDeclaration getTypeDeclarations()
        {
            return typeDeclarations;
        }
    }
}
