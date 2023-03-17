/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public abstract class Constant
    {
        public static byte CONSTANT_Unknown = 0;
        public static byte CONSTANT_Utf8 = 1;
        public static byte CONSTANT_Integer = 3;
        public static byte CONSTANT_Float = 4;
        public static byte CONSTANT_Long = 5;
        public static byte CONSTANT_Double = 6;
        public static byte CONSTANT_Class = 7;
        public static byte CONSTANT_String = 8;
        public static byte CONSTANT_FieldRef = 9;
        public static byte CONSTANT_MethodRef = 10;
        public static byte CONSTANT_InterfaceMethodRef = 11;
        public static byte CONSTANT_NameAndType = 12;
        public static byte CONSTANT_MethodHandle = 15;
        public static byte CONSTANT_MethodType = 16;
        public static byte CONSTANT_InvokeDynamic = 18;
        public static byte CONSTANT_MemberRef = 19; // Unofficial constant

        protected byte tag;

        public Constant(byte tag)
        {
            this.tag = tag;
        }

        public byte getTag()
        {
            return tag;
        }
    }
}
