/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.API.Printer
{
    public interface Printer
    {
        void start(int maxLineNumber, int majorVersion, int minorVersion);
        void end();

        void printText(string text);
        void printNumericConstant(string constant);
        void printstringConstant(string constant, string ownerInternalName);
        void printKeyword(string keyword);

        // Declaration & reference types
        static int TYPE = 1;
        static int FIELD = 2;
        static int METHOD = 3;
        static int CONSTRUCTOR = 4;
        static int PACKAGE = 5;
        static int MODULE = 6;

        void printDeclaration(int type, string internalTypeName, string name, string descriptor);
        void printReference(int type, string internalTypeName, string name, string descriptor, string ownerInternalName);

        void indent();
        void unindent();

        static int UNKNOWN_LINE_NUMBER = 0;

        void startLine(int lineNumber);
        void endLine();
        void extraLine(int count);

        // Marker types
        static int COMMENT = 1;
        static int JAVADOC = 2;
        static int ERROR = 3;
        static int IMPORT_STATEMENTS = 4;

        void startMarker(int type);
        void endMarker(int type);
    }
}
