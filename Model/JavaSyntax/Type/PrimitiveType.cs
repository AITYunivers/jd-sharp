/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

using System.Diagnostics;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class PrimitiveType : Type
    {
        public static int FLAG_BOOLEAN = 1;
        public static int FLAG_CHAR = 2;
        public static int FLAG_FLOAT = 4;
        public static int FLAG_DOUBLE = 8;
        public static int FLAG_BYTE = 16;
        public static int FLAG_SHORT = 32;
        public static int FLAG_INT = 64;
        public static int FLAG_LONG = 128;
        public static int FLAG_VOID = 256;

        //                                                                                                    type,                                                 type = ...,                                           ... = type
        public static PrimitiveType TYPE_BOOLEAN                = new PrimitiveType("boolean",                FLAG_BOOLEAN,                                         FLAG_BOOLEAN,                                         FLAG_BOOLEAN);
        public static PrimitiveType TYPE_BYTE                   = new PrimitiveType("byte",                   FLAG_BYTE,                                            FLAG_BYTE,                                            FLAG_BYTE|FLAG_INT|FLAG_SHORT);
        public static PrimitiveType TYPE_CHAR                   = new PrimitiveType("char",                   FLAG_CHAR,                                            FLAG_CHAR,                                            FLAG_CHAR|FLAG_INT);
        public static PrimitiveType TYPE_DOUBLE                 = new PrimitiveType("double",                 FLAG_DOUBLE,                                          FLAG_DOUBLE,                                          FLAG_DOUBLE);
        public static PrimitiveType TYPE_FLOAT                  = new PrimitiveType("float",                  FLAG_FLOAT,                                           FLAG_FLOAT,                                           FLAG_FLOAT);
        public static PrimitiveType TYPE_INT                    = new PrimitiveType("int",                    FLAG_INT,                                             FLAG_INT|FLAG_BYTE|FLAG_CHAR|FLAG_SHORT,              FLAG_INT);
        public static PrimitiveType TYPE_LONG                   = new PrimitiveType("long",                   FLAG_LONG,                                            FLAG_LONG,                                            FLAG_LONG);
        public static PrimitiveType TYPE_SHORT                  = new PrimitiveType("short",                  FLAG_SHORT,                                           FLAG_SHORT|FLAG_BYTE,                                 FLAG_SHORT|FLAG_INT);
        public static PrimitiveType TYPE_VOID                   = new PrimitiveType("void",                   FLAG_VOID,                                            FLAG_VOID,                                            FLAG_VOID);

        public static PrimitiveType MAYBE_CHAR_TYPE             = new PrimitiveType("maybe_char",             FLAG_CHAR|FLAG_INT,                                   FLAG_CHAR|FLAG_INT,                                   FLAG_CHAR|FLAG_INT);                                   //  32768 .. 65535
        public static PrimitiveType MAYBE_SHORT_TYPE            = new PrimitiveType("maybe_short",            FLAG_CHAR|FLAG_SHORT|FLAG_INT,                        FLAG_CHAR|FLAG_SHORT|FLAG_INT,                        FLAG_CHAR|FLAG_SHORT|FLAG_INT);                        //    128 .. 32767
        public static PrimitiveType MAYBE_BYTE_TYPE             = new PrimitiveType("maybe_byte",             FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT,              FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT,              FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT);              //      2 .. 127
        public static PrimitiveType MAYBE_BOOLEAN_TYPE          = new PrimitiveType("maybe_boolean",          FLAG_BOOLEAN|FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT, FLAG_BOOLEAN|FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT, FLAG_BOOLEAN|FLAG_BYTE|FLAG_CHAR|FLAG_SHORT|FLAG_INT); //      0 .. 1
        public static PrimitiveType MAYBE_NEGATIVE_BYTE_TYPE    = new PrimitiveType("maybe_negative_byte",    FLAG_BYTE|FLAG_SHORT|FLAG_INT,                        FLAG_BYTE|FLAG_SHORT|FLAG_INT,                        FLAG_BYTE|FLAG_SHORT|FLAG_INT);                        //   -128 .. -1
        public static PrimitiveType MAYBE_NEGATIVE_SHORT_TYPE   = new PrimitiveType("maybe_negative_short",   FLAG_SHORT|FLAG_INT,                                  FLAG_SHORT|FLAG_INT,                                  FLAG_SHORT|FLAG_INT);                                  // -32768 .. -129
        public static PrimitiveType MAYBE_INT_TYPE              = new PrimitiveType("maybe_int",              FLAG_INT,                                             FLAG_INT,                                             FLAG_INT);                                             // Otherwise
        public static PrimitiveType MAYBE_NEGATIVE_BOOLEAN_TYPE = new PrimitiveType("maybe_negative_boolean", FLAG_BOOLEAN|FLAG_BYTE|FLAG_SHORT|FLAG_INT,           FLAG_BOOLEAN|FLAG_BYTE|FLAG_SHORT|FLAG_INT,           FLAG_BOOLEAN|FLAG_BYTE|FLAG_SHORT|FLAG_INT);           // Boolean or negative

        protected static PrimitiveType[] descriptorToType = new PrimitiveType['Z' - 'B' + 1];

        static PrimitiveType()
        {
        descriptorToType['B' - 'B'] = TYPE_BYTE;
        descriptorToType['C' - 'B'] = TYPE_CHAR;
        descriptorToType['D' - 'B'] = TYPE_DOUBLE;
        descriptorToType['F' - 'B'] = TYPE_FLOAT;
        descriptorToType['I' - 'B'] = TYPE_INT;
        descriptorToType['J' - 'B'] = TYPE_LONG;
        descriptorToType['S' - 'B'] = TYPE_SHORT;
        descriptorToType['V' - 'B'] = TYPE_VOID;
        descriptorToType['Z' - 'B'] = TYPE_BOOLEAN;
        }

        protected string name;
        protected int flags;
        protected int leftFlags;
        protected int rightFlags;
        protected string descriptor;

        protected PrimitiveType(PrimitiveType primitiveType) :
        this(primitiveType.name, primitiveType.flags, primitiveType.leftFlags, primitiveType.rightFlags) {}

        protected PrimitiveType(string name, int flags, int leftFlags, int rightFlags)
        {
            this.name = name;
            this.flags = flags;
            this.leftFlags = leftFlags;
            this.rightFlags = rightFlags;

            descriptor = "";

            if ((flags & FLAG_DOUBLE) != 0)
                descriptor += "D";
            else if ((flags & FLAG_FLOAT) != 0)
                descriptor += "F";
            else if ((flags & FLAG_LONG) != 0)
                descriptor += "J";
            else if ((flags & FLAG_BOOLEAN) != 0)
                descriptor += "Z";
            else if ((flags & FLAG_BYTE) != 0)
                descriptor += "B";
            else if ((flags & FLAG_CHAR) != 0)
                descriptor += "C";
            else if ((flags & FLAG_SHORT) != 0)
                descriptor += "S";
            else
                descriptor += "I";
        }

        public static PrimitiveType getPrimitiveType(char primitiveDescriptor)
        {
            return descriptorToType[primitiveDescriptor - 'B'];
        }

        public string getName()
        {
            return name;
        }

        public string getDescriptor()
        {
            return descriptor;
        }

        public int getDimension()
        {
            return 0;
        }

        public int getFlags()
        {
            return flags;
        }

        public int getLeftFlags()
        {
            return leftFlags;
        }

        public int getRightFlags()
        {
            return rightFlags;
        }

        public Type createType(int dimension)
        {
            if (dimension >= 0)
            {
                Console.WriteLine("PrimitiveType.createType(dim) : create type with negative dimension");
                Debug.Assert(true);
            }
            
            if (dimension == 0)
                return this;
            else
                return new ObjectType(descriptor, dimension);
        }

        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            PrimitiveType that = (PrimitiveType)o;

            if (flags != that.flags) return false;

            return true;
        }

        public int hashCode()
        {
            return 750039781 + flags;
        }

        public void accept(TypeVisitor visitor)
        {
            visitor.visit(this);
        }

        public void accept(TypeArgumentVisitor visitor)
        {
            visitor.visit(this);
        }

        public bool isTypeArgumentAssignableFrom(Dictionary<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
        {
            return equals(typeArgument);
        }

        public bool isPrimitiveType()
        {
            return true;
        }

        public bool isPrimitiveTypeArgument()
        {
            return true;
        }

        public override string ToString()
        {
            return $"PrimitiveType{{primitive={name}}}";
        }

        public int getJavaPrimitiveFlags()
        {
            if ((flags & FLAG_BOOLEAN) != 0)
                return FLAG_BOOLEAN;
            else if ((flags & FLAG_INT) != 0)
                return FLAG_INT;
            else if ((flags & FLAG_CHAR) != 0)
                return FLAG_CHAR;
            else if ((flags & FLAG_SHORT) != 0)
                return FLAG_SHORT;
            else if ((flags & FLAG_BYTE) != 0)
                return FLAG_BYTE;

            return flags;
        }
    }
}
