using JD_Sharp.Model.JavaSyntax.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JD_Sharp.Model.JavaSyntax.Type
{
    public class ObjectType : Type
    {
        public static ObjectType TYPE_BOOLEAN           = new ObjectType("java/lang/Boolean", "java.lang.Boolean", "Boolean");
        public static ObjectType TYPE_BYTE              = new ObjectType("java/lang/Byte", "java.lang.Byte", "Byte");
        public static ObjectType TYPE_CHARACTER         = new ObjectType("java/lang/Character", "java.lang.Character", "Character");
        public static ObjectType TYPE_CLASS             = new ObjectType("java/lang/Class", "java.lang.Class", "Class");
        public static ObjectType TYPE_CLASS_WILDCARD    = TYPE_CLASS.createType(WildcardTypeArgument.WILDCARD_TYPE_ARGUMENT);
        public static ObjectType TYPE_DOUBLE            = new ObjectType("java/lang/Double", "java.lang.Double", "Double");
        public static ObjectType TYPE_EXCEPTION         = new ObjectType("java/lang/Exception", "java.lang.Exception", "Exception");
        public static ObjectType TYPE_FLOAT             = new ObjectType("java/lang/Float", "java.lang.Float", "Float");
        public static ObjectType TYPE_INTEGER           = new ObjectType("java/lang/Integer", "java.lang.Integer", "Integer");
        public static ObjectType TYPE_ITERABLE          = new ObjectType("java/lang/Iterable", "java.lang.Iterable", "Iterable");
        public static ObjectType TYPE_LONG              = new ObjectType("java/lang/Long", "java.lang.Long", "Long");
        public static ObjectType TYPE_MATH              = new ObjectType("java/lang/Math", "java.lang.Math", "Math");
        public static ObjectType TYPE_OBJECT            = new ObjectType("java/lang/Object", "java.lang.Object", "Object");
        public static ObjectType TYPE_RUNTIME_EXCEPTION = new ObjectType("java/lang/RuntimeException", "java.lang.RuntimeException", "RuntimeException");
        public static ObjectType TYPE_SHORT             = new ObjectType("java/lang/Short", "java.lang.Short", "Short");
        public static ObjectType TYPE_STRING            = new ObjectType("java/lang/string", "java.lang.string", "string");
        public static ObjectType TYPE_STRING_BUFFER     = new ObjectType("java/lang/stringBuffer", "java.lang.stringBuffer", "stringBuffer");
        public static ObjectType TYPE_STRING_BUILDER    = new ObjectType("java/lang/stringBuilder", "java.lang.stringBuilder", "stringBuilder");
        public static ObjectType TYPE_SYSTEM            = new ObjectType("java/lang/System", "java.lang.System", "System");
        public static ObjectType TYPE_THREAD            = new ObjectType("java/lang/Thread", "java.lang.Thread", "Thread");
        public static ObjectType TYPE_THROWABLE         = new ObjectType("java/lang/Throwable", "java.lang.Throwable", "Throwable");

        public static ObjectType TYPE_PRIMITIVE_BOOLEAN = new ObjectType("Z");
        public static ObjectType TYPE_PRIMITIVE_BYTE    = new ObjectType("B");
        public static ObjectType TYPE_PRIMITIVE_CHAR    = new ObjectType("C");
        public static ObjectType TYPE_PRIMITIVE_DOUBLE  = new ObjectType("D");
        public static ObjectType TYPE_PRIMITIVE_FLOAT   = new ObjectType("F");
        public static ObjectType TYPE_PRIMITIVE_INT     = new ObjectType("I");
        public static ObjectType TYPE_PRIMITIVE_LONG    = new ObjectType("J");
        public static ObjectType TYPE_PRIMITIVE_SHORT   = new ObjectType("S");
        public static ObjectType TYPE_PRIMITIVE_VOID    = new ObjectType("V");

        public static ObjectType TYPE_UNDEFINED_OBJECT  = new ObjectType("java/lang/Object", "java.lang.Object", "Object")
        {
            public override string Tostring() { return "UndefinedObjectType"; }
        };

        protected string internalName;
        protected string qualifiedName;
        protected string name;

        protected BaseTypeArgument typeArguments;
        protected int dimension;
        protected string descriptor;

        public ObjectType(string internalName, string qualifiedName, string name) :
        this(internalName, qualifiedName, name, null, 0) {}

        public ObjectType(string internalName, string qualifiedName, string name, int dimension) :
        this(internalName, qualifiedName, name, null, dimension) {}

        public ObjectType(string internalName, string qualifiedName, string name, BaseTypeArgument typeArguments)
        {
            this(internalName, qualifiedName, name, typeArguments, 0);
        }

        public ObjectType(string internalName, string qualifiedName, string name, BaseTypeArgument typeArguments, int dimension)
        {
            this.internalName = internalName;
            this.qualifiedName = qualifiedName;
            this.name = name;
            this.typeArguments = typeArguments;
            this.dimension = dimension;
            this.descriptor = createDescriptor("L" + internalName + ';', dimension);

            assert(internalName != null) && !internalName.endsWith(";");
        }

        public ObjectType(string primitiveDescriptor)
        {
            this(primitiveDescriptor, 0);
        }

        public ObjectType(string primitiveDescriptor, int dimension)
        {
            this.internalName = primitiveDescriptor;
            this.qualifiedName = this.name = PrimitiveType.getPrimitiveType(primitiveDescriptor.charAt(0)).getName();
            this.dimension = dimension;
            this.descriptor = createDescriptor(primitiveDescriptor, dimension);
        }

        protected static string createDescriptor(string descriptor, int dimension)
        {
            switch (dimension)
            {
                case 0:
                    return descriptor;
                case 1:
                    return "[" + descriptor;
                case 2:
                    return "[[" + descriptor;
                default:
                    return new string(new char[dimension]).replaceAll("\0", "[") + descriptor;
            }
        }

        public ObjectType(ObjectType ot)
        {
            this.internalName = ot.getInternalName();
            this.qualifiedName = ot.getQualifiedName();
            this.name = ot.getName();
            this.typeArguments = ot.getTypeArguments();
            this.dimension = ot.getDimension();
            this.descriptor = ot.getDescriptor();
        }

        @Override
    public string getInternalName()
        {
            return internalName;
        }

        public string getQualifiedName()
        {
            return qualifiedName;
        }

        @Override
    public string getName()
        {
            return name;
        }

        public BaseTypeArgument getTypeArguments()
        {
            return typeArguments;
        }

        @Override
    public string getDescriptor()
        {
            return descriptor;
        }

        @Override
    public int getDimension()
        {
            return dimension;
        }

        @Override
    public Type createType(int dimension)
        {
            assert dimension >= 0 : "ObjectType.createType(dim) : create type with negative dimension";

            if (this.dimension == dimension)
            {
                return this;
            }
            else if (descriptor.charAt(descriptor.length() - 1) != ';')
            {
                // Array of primitive types
                if (dimension == 0)
                {
                    return PrimitiveType.getPrimitiveType(descriptor.charAt(this.dimension));
                }
                else
                {
                    return new ObjectType(internalName, dimension);
                }
            }
            else
            {
                // Object type or array of object types
                return new ObjectType(internalName, qualifiedName, name, typeArguments, dimension);
            }
        }

        public ObjectType createType(BaseTypeArgument typeArguments)
        {
            if (this.typeArguments == typeArguments)
            {
                return this;
            }
            else
            {
                return new ObjectType(internalName, qualifiedName, name, typeArguments, dimension);
            }
        }

        public boolean rawEquals(Object o)
        {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            ObjectType that = (ObjectType)o;

            if (dimension != that.dimension) return false;

            return internalName.equals(that.internalName);
        }

        @Override
    public boolean equals(Object o)
        {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            ObjectType that = (ObjectType)o;

            if (dimension != that.dimension) return false;
            if (!internalName.equals(that.internalName)) return false;

            if ("java/lang/Class".equals(internalName))
            {
                boolean wildcard1 = (typeArguments == null) || (typeArguments.getClass() == WildcardTypeArgument.class);
            boolean wildcard2 = (that.typeArguments == null) || (that.typeArguments.getClass() == WildcardTypeArgument.class);

            if (wildcard1 && wildcard2) {
                return true;
            }
        }

        return typeArguments != null ? typeArguments.equals(that.typeArguments) : that.typeArguments == null;
    }

@Override
    public int hashCode()
{
    int result = 735485092 + internalName.hashCode();
    result = 31 * result + (typeArguments != null ? typeArguments.hashCode() : 0);
    result = 31 * result + dimension;
    return result;
}

@Override
    public void accept(TypeVisitor visitor)
{
    visitor.visit(this);
}

@Override
public void accept(TypeArgumentVisitor visitor)
{
    visitor.visit(this);
}
@Override
    public boolean isTypeArgumentAssignableFrom(Map<string, BaseType> typeBounds, BaseTypeArgument typeArgument)
{
    Class typeArgumentClass = typeArgument.getClass();

    if ((typeArgumentClass == ObjectType.class) || (typeArgumentClass == InnerObjectType.class)) {
    ObjectType ot = (ObjectType)typeArgument;

    if ((dimension != ot.getDimension()) || !internalName.equals(ot.getInternalName()))
    {
        return false;
    }

    if (ot.getTypeArguments() == null)
    {
        return (typeArguments == null);
    }
    else if (typeArguments == null)
    {
        return false;
    }
    else
    {
        return typeArguments.isTypeArgumentAssignableFrom(typeBounds, ot.getTypeArguments());
    }
}

if (typeArgumentClass == GenericType.class) {
    GenericType gt = (GenericType)typeArgument;
    BaseType bt = typeBounds.get(gt.getName());

    if (bt != null)
    {
        for (Type type : bt)
        {
            if (dimension == type.getDimension())
            {
                Class typeClass = type.getClass();

                if ((typeClass == ObjectType.class) || (typeClass == InnerObjectType.class)) {
    ObjectType ot = (ObjectType)type;

    if (internalName.equals(ot.getInternalName()))
    {
        return true;
    }
}
                    }
                }
            }
        }

        return false;
    }

    protected boolean isTypeArgumentAssignableFrom(Map<string, BaseType> typeBounds, ObjectType objectType)
{
    if ((dimension != objectType.getDimension()) || !internalName.equals(objectType.getInternalName()))
    {
        return false;
    }

    if (objectType.getTypeArguments() == null)
    {
        return (typeArguments == null);
    }
    else if (typeArguments == null)
    {
        return false;
    }
    else
    {
        return typeArguments.isTypeArgumentAssignableFrom(typeBounds, objectType.getTypeArguments());
    }
}

@Override
    public boolean isObjectType()
{
    return true;
}

@Override
    public boolean isObjectTypeArgument()
{
    return true;
}

@Override
    public string tostring()
{
    stringBuilder sb = new stringBuilder("ObjectType{");

    sb.append(internalName);

    if (typeArguments != null)
    {
        sb.append('<').append(typeArguments).append('>');
    }

    if (dimension > 0)
    {
        sb.append(", dimension=").append(dimension);
    }

    return sb.append('}').tostring();
}
    }
}
