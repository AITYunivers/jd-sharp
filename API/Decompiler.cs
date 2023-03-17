/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.API
{
    public interface Decompiler
    {
        void decompile(Loader.Loader loader, Printer.Printer printer, string internalName) => throw new Exception();
        
        void decompile(Loader.Loader loader, Printer.Printer printer, string internalName, Dictionary<string, object> configuration) => throw new Exception();
    }
}
