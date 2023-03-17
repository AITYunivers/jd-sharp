/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile
{
    public interface Constants
    {
        // Access flags for Class, Field, Method, Nested class, Module, Module Requires, Module Exports, Module Opens
        static int ACC_PUBLIC       = 0x0001; // C  F  M  N  .  .  .  .
        static int ACC_PRIVATE      = 0x0002; // .  F  M  N  .  .  .  .
        static int ACC_PROTECTED    = 0x0004; // .  F  M  N  .  .  .  .
        static int ACC_STATIC       = 0x0008; // C  F  M  N  .  .  .  .
        static int ACC_FINAL        = 0x0010; // C  F  M  N  .  .  .  .
        static int ACC_SYNCHRONIZED = 0x0020; // .  .  M  .  .  .  .  .
        static int ACC_SUPER        = 0x0020; // C  .  .  .  .  .  .  .
        static int ACC_OPEN         = 0x0020; // .  .  .  .  Mo .  .  .
        static int ACC_TRANSITIVE   = 0x0020; // .  .  .  .  .  MR .  .
        static int ACC_VOLATILE     = 0x0040; // .  F  .  .  .  .  .  .
        static int ACC_BRIDGE       = 0x0040; // .  .  M  .  .  .  .  .
        static int ACC_STATIC_PHASE = 0x0040; // .  .  .  .  .  MR .  .
        static int ACC_TRANSIENT    = 0x0080; // .  F  .  .  .  .  .  .
        static int ACC_VARARGS      = 0x0080; // .  .  M  .  .  .  .  .
        static int ACC_NATIVE       = 0x0100; // .  .  M  .  .  .  .  .
        static int ACC_INTERFACE    = 0x0200; // C  .  .  N  .  .  .  .
        static int ACC_ABSTRACT     = 0x0400; // C  .  M  N  .  .  .  .
        static int ACC_STRICT       = 0x0800; // .  .  M  .  .  .  .  .
        static int ACC_SYNTHETIC    = 0x1000; // C  F  M  N  Mo MR ME MO
        static int ACC_ANNOTATION   = 0x2000; // C  .  .  N  .  .  .  .
        static int ACC_ENUM         = 0x4000; // C  F  .  N  .  .  .  .
        static int ACC_MODULE       = 0x8000; // C  .  .  .  .  .  .  .
        static int ACC_MANDATED     = 0x8000; // .  .  .  .  Mo MR ME MO
    }
}
