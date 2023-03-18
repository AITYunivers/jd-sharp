using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Declaration
{
    public interface Declaration
    {
        // Access flags for Class, Field, Method, Nested class, Module, Module Requires, Module Exports, Module Opens
        static int FLAG_PUBLIC       = 0x0001;  // C  F  M  N  .  .  .  .
        static int FLAG_PRIVATE      = 0x0002;  // .  F  M  N  .  .  .  .
        static int FLAG_PROTECTED    = 0x0004;  // .  F  M  N  .  .  .  .
        static int FLAG_STATIC       = 0x0008;  // C  F  M  N  .  .  .  .
        static int FLAG_FINAL        = 0x0010;  // C  F  M  N  .  .  .  .
        static int FLAG_SYNCHRONIZED = 0x0020;  // .  .  M  .  .  .  .  .
        static int FLAG_SUPER        = 0x0020;  // C  .  .  .  .  .  .  .
        static int FLAG_OPEN         = 0x0020;  // .  .  .  .  Mo .  .  .
        static int FLAG_TRANSITIVE   = 0x0020;  // .  .  .  .  .  MR .  .
        static int FLAG_VOLATILE     = 0x0040;  // .  F  .  .  .  .  .  .
        static int FLAG_BRIDGE       = 0x0040;  // .  .  M  .  .  .  .  .
        static int FLAG_STATIC_PHASE = 0x0040;  // .  .  .  .  .  MR .  .
        static int FLAG_TRANSIENT    = 0x0080;  // .  F  .  .  .  .  .  .
        static int FLAG_VARARGS      = 0x0080;  // .  .  M  .  .  .  .  .
        static int FLAG_NATIVE       = 0x0100;  // .  .  M  .  .  .  .  .
        static int FLAG_INTERFACE    = 0x0200;  // C  .  .  N  .  .  .  .
        static int FLAG_ANONYMOUS    = 0x0200;  // .  .  M  .  .  .  .  . // Custom flag
        static int FLAG_ABSTRACT     = 0x0400;  // C  .  M  N  .  .  .  .
        static int FLAG_STRICT       = 0x0800;  // .  .  M  .  .  .  .  .
        static int FLAG_SYNTHETIC    = 0x1000;  // C  F  M  N  Mo MR ME MO
        static int FLAG_ANNOTATION   = 0x2000;  // C  .  .  N  .  .  .  .
        static int FLAG_ENUM         = 0x4000;  // C  F  .  N  .  .  .  .
        static int FLAG_MODULE       = 0x8000;  // C  .  .  .  .  .  .  .
        static int FLAG_MANDATED     = 0x8000;  // .  .  .  .  Mo MR ME MO

        // Extension
        static int FLAG_DEFAULT      = 0x10000; // .  .  M  .  .  .  .  .

        void accept(DeclarationVisitor visitor);
    }
}
