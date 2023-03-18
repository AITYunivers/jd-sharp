using JD_Sharp.API.Loader;
using JD_Sharp.API.Printer;
using JD_Sharp.Model.JavaFragment;
using JD_Sharp.Model.JavaSyntax.Type;
using JD_Sharp.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JD_Sharp.Service.Fragmenter.JavaSyntaxToJavaFragment.Visitor
{
    public class TypeVisitor : AbstractJavaSyntaxVisitor
    {
        public static KeywordToken BOOLEAN = new KeywordToken("bool");
        public static KeywordToken BYTE = new KeywordToken("byte");
        public static KeywordToken CHAR = new KeywordToken("char");
        public static KeywordToken DOUBLE = new KeywordToken("double");
        public static KeywordToken EXPORTS = new KeywordToken("exports");
        public static KeywordToken EXTENDS = new KeywordToken("extends");
        public static KeywordToken FLOAT = new KeywordToken("float");
        public static KeywordToken INT = new KeywordToken("int");
        public static KeywordToken LONG = new KeywordToken("long");
        public static KeywordToken MODULE = new KeywordToken("module");
        public static KeywordToken OPEN = new KeywordToken("open");
        public static KeywordToken OPENS = new KeywordToken("opens");
        public static KeywordToken PROVIDES = new KeywordToken("provides");
        public static KeywordToken REQUIRES = new KeywordToken("requires");
        public static KeywordToken SHORT = new KeywordToken("short");
        public static KeywordToken SUPER = new KeywordToken("super");
        public static KeywordToken TO = new KeywordToken("to");
        public static KeywordToken TRANSITIVE = new KeywordToken("transitive");
        public static KeywordToken USES = new KeywordToken("uses");
        public static KeywordToken VOID = new KeywordToken("void");
        public static KeywordToken WITH = new KeywordToken("with");

        public static int UNKNOWN_LINE_NUMBER = Printer.UNKNOWN_LINE_NUMBER;

        protected Loader loader;
        protected string internalPackageName;
        protected bool genericTypesSupported;
        protected ImportsFragment importsFragment;
        protected Tokens tokens;
        protected int maxLineNumber = 0;
        protected string currentInternalTypeName;
        protected HashMap<string, TextToken> textTokenCache = new HashMap<>();

        public TypeVisitor(Loader loader, string mainInternalTypeName, int majorVersion, ImportsFragment importsFragment)
        {
            this.loader = loader;
            this.genericTypesSupported = (majorVersion >= 49); // (majorVersion >= Java 5)
            this.importsFragment = importsFragment;

            int index = mainInternalTypeName.lastIndexOf('/');
            this.internalPackageName = (index == -1) ? "" : mainInternalTypeName.substring(0, index + 1);
        }

        
    public void visit(TypeArguments arguments)
        {
            buildTokensForList(arguments, TextToken.COMMA_SPACE);
        }
        
    public void visit(DiamondTypeArgument argument) { }

        
    public void visit(WildcardExtendsTypeArgument argument)
        {
            tokens.add(TextToken.QUESTIONMARK_SPACE);
            tokens.add(EXTENDS);
            tokens.add(TextToken.SPACE);

            BaseType type = argument.getType();

            type.accept(this);
        }

        
    public void visit(PrimitiveType type)
        {
            switch (type.getJavaPrimitiveFlags())
            {
                case FLAG_BOOLEAN: tokens.add(BOOLEAN); break;
                case FLAG_CHAR: tokens.add(CHAR); break;
                case FLAG_FLOAT: tokens.add(FLOAT); break;
                case FLAG_DOUBLE: tokens.add(DOUBLE); break;
                case FLAG_BYTE: tokens.add(BYTE); break;
                case FLAG_SHORT: tokens.add(SHORT); break;
                case FLAG_INT: tokens.add(INT); break;
                case FLAG_LONG: tokens.add(LONG); break;
                case FLAG_VOID: tokens.add(VOID); break;
            }

            // Build token for dimension
            visitDimension(type.getDimension());
        }

        
    public void visit(ObjectType type)
        {
            // Build token for type reference
            tokens.add(newTypeReferenceToken(type, currentInternalTypeName));

            if (genericTypesSupported)
            {
                // Build token for type arguments
                BaseTypeArgument typeArguments = type.getTypeArguments();

                if (typeArguments != null)
                {
                    visitTypeArgumentList(typeArguments);
                }
            }

            // Build token for dimension
            visitDimension(type.getDimension());
        }

        
    public void visit(InnerObjectType type)
        {
            if ((currentInternalTypeName == null) || (!currentInternalTypeName.equals(type.getInternalName()) && !currentInternalTypeName.equals(type.getOuterType().getInternalName())))
            {
                BaseType outerType = type.getOuterType();

                outerType.accept(this);
                tokens.add(TextToken.DOT);
            }

            // Build token for type reference
            tokens.add(new ReferenceToken(ReferenceToken.TYPE, type.getInternalName(), type.getName(), null, currentInternalTypeName));

            if (genericTypesSupported)
            {
                // Build token for type arguments
                BaseTypeArgument typeArguments = type.getTypeArguments();

                if (typeArguments != null)
                {
                    visitTypeArgumentList(typeArguments);
                }
            }

            // Build token for dimension
            visitDimension(type.getDimension());
        }

        protected void visitTypeArgumentList(BaseTypeArgument arguments)
        {
            if (arguments != null)
            {
                tokens.add(TextToken.LEFTANGLEBRACKET);
                arguments.accept(this);
                tokens.add(TextToken.RIGHTANGLEBRACKET);
            }
        }

        protected void visitDimension(int dimension)
        {
            switch (dimension)
            {
                case 0: break;
                case 1: tokens.add(TextToken.DIMENSION_1); break;
                case 2: tokens.add(TextToken.DIMENSION_2); break;
                default: tokens.add(newTextToken(new string(new char[dimension]).replaceAll("\0", "[]"))); break;
            }
        }

        
    public void visit(WildcardSuperTypeArgument argument)
        {
            tokens.add(TextToken.QUESTIONMARK_SPACE);
            tokens.add(SUPER);
            tokens.add(TextToken.SPACE);

            BaseType type = argument.getType();

            type.accept(this);
        }

        
        @SuppressWarnings("unchecked")
    public void visit(Types types)
        {
            buildTokensForList(types, TextToken.COMMA_SPACE);
        }

        
    public void visit(TypeParameter parameter)
        {
            tokens.add(newTextToken(parameter.getIdentifier()));
        }

        
    public void visit(TypeParameterWithTypeBounds parameter)
        {
            tokens.add(newTextToken(parameter.getIdentifier()));
            tokens.add(TextToken.SPACE);
            tokens.add(EXTENDS);
            tokens.add(TextToken.SPACE);

            BaseType types = parameter.getTypeBounds();

            if (types.isList())
            {
                buildTokensForList(types.getList(), TextToken.SPACE_AND_SPACE);
            }
            else
            {
                BaseType type = types.getFirst();

                type.accept(this);
            }
        }

        
        @SuppressWarnings("unchecked")
    public void visit(TypeParameters parameters)
        {
            int size = parameters.size();

            if (size > 0)
            {
                parameters.get(0).accept(this);

                for (int i = 1; i < size; i++)
                {
                    tokens.add(TextToken.COMMA_SPACE);
                    parameters.get(i).accept(this);
                }
            }
        }

        
    public void visit(GenericType type)
        {
            tokens.add(newTextToken(type.getName()));
            visitDimension(type.getDimension());
        }

        
    public void visit(WildcardTypeArgument type)
        {
            tokens.add(TextToken.QUESTIONMARK);
        }

        protected <T extends TypeArgumentVisitable> void buildTokensForList(List<T> list, TextToken separator)
        {
            int size = list.size();

            if (size > 0)
            {
                list.get(0).accept(this);

                for (int i = 1; i < size; i++)
                {
                    tokens.add(separator);
                    list.get(i).accept(this);
                }
            }
        }

        protected ReferenceToken newTypeReferenceToken(ObjectType ot, string ownerInternalName)
        {
            string internalName = ot.getInternalName();
            string qualifiedName = ot.getQualifiedName();
            string name = ot.getName();

            if (packageContainsType(internalPackageName, internalName))
            {
                // In the current package
                return new ReferenceToken(ReferenceToken.TYPE, internalName, name, null, ownerInternalName);
            }
            else
            {
                if (packageContainsType("java/lang/", internalName))
                {
                    // A 'java.lang' class
                    string internalLocalTypeName = internalPackageName + name;

                    if (loader.canLoad(internalLocalTypeName))
                    {
                        return new ReferenceToken(ReferenceToken.TYPE, internalName, qualifiedName, null, ownerInternalName);
                    }
                    else
                    {
                        return new ReferenceToken(ReferenceToken.TYPE, internalName, name, null, ownerInternalName);
                    }
                }
                else
                {
                    return new TypeReferenceToken(importsFragment, internalName, qualifiedName, name, ownerInternalName);
                }
            }
        }

        protected static bool packageContainsType(string internalPackageName, string internalClassName)
        {
            if (internalClassName.startsWith(internalPackageName))
            {
                return internalClassName.indexOf('/', internalPackageName.length()) == -1;
            }
            else
            {
                return false;
            }
        }

        private static class TypeReferenceToken extends ReferenceToken
        {
        protected ImportsFragment importsFragment;
        protected string qualifiedName;

        public TypeReferenceToken(ImportsFragment importsFragment, string internalTypeName, string qualifiedName, string name, string ownerInternalName)
        {
            super(TYPE, internalTypeName, name, null, ownerInternalName);
            this.importsFragment = importsFragment;
            this.qualifiedName = qualifiedName;
        }

        
        public string getName()
        {
            if (importsFragment.contains(internalTypeName))
            {
                return name;
            }
            else
            {
                return qualifiedName;
            }
        }
    }

    protected TextToken newTextToken(string text)
    {
        TextToken textToken = textTokenCache.get(text);

        if (textToken == null)
        {
            textTokenCache.put(text, textToken = new TextToken(text));
        }

        return textToken;
    }

    public class Tokens extends DefaultList<Token> {
        protected int currentLineNumber = UNKNOWN_LINE_NUMBER;

    public int getCurrentLineNumber()
    {
        return currentLineNumber;
    }

    
        public bool add(Token token)
    {
        assert!(token instanceof LineNumberToken);
        return super.add(token);
    }

    public void addLineNumberToken(Expression expression)
    {
        addLineNumberToken(expression.getLineNumber());
    }

    public void addLineNumberToken(int lineNumber)
    {
        if (lineNumber != UNKNOWN_LINE_NUMBER)
        {
            if (lineNumber >= maxLineNumber)
            {
                super.add(new LineNumberToken(lineNumber));
                maxLineNumber = currentLineNumber = lineNumber;
            }
        }
    }
}
    }
}
