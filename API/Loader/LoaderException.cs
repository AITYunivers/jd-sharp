/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.API.Loader
{
    public class LoaderException : Exception
    {
        private static long serialVersionUID = 9506606333927794L;
        public LoaderException() { }

        public LoaderException(string msg) : base(msg){}

        public LoaderException(string msg, Exception cause) : base(msg, cause) { }
    }
}
