using JD_Sharp.Model.ClassFile.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_Sharp.Model.JavaSyntax.Reference
{
    public class AnnotationReference : BaseAnnotationReference
    {
        protected ObjectType type;
        protected ElementValue elementValue;
        protected BaseElementValuePair elementValuePairs;

        public AnnotationReference(ObjectType type)
        {
            this.type = type;
        }

        public AnnotationReference(ObjectType type, ElementValue elementValue)
        {
            this.type = type;
            this.elementValue = elementValue;
        }

        public AnnotationReference(ObjectType type, BaseElementValuePair elementValuePairs)
        {
            this.type = type;
            this.elementValuePairs = elementValuePairs;
        }

        protected AnnotationReference(ObjectType type, ElementValue elementValue, BaseElementValuePair elementValuePairs)
        {
            this.type = type;
            this.elementValue = elementValue;
            this.elementValuePairs = elementValuePairs;
        }

        public ObjectType getType()
        {
            return type;
        }

        public ElementValue getElementValue()
        {
            return elementValue;
        }

        public BaseElementValuePair getElementValuePairs()
        {
            return elementValuePairs;
        }

        public bool equals(object o)
        {
            if (this == o) return true;
            if (!(o is AnnotationReference)) return false;

            AnnotationReference that = (AnnotationReference)o;

            if (elementValue != null ? !elementValue.Equals(that.elementValue) : that.elementValue != null) return false;
            if (elementValuePairs != null ? !elementValuePairs.Equals(that.elementValuePairs) : that.elementValuePairs != null)
                return false;
            if (!type.equals(that.type)) return false;

            return true;
        }

        public int hashCode()
        {
            int result = 970748295 + type.hashCode();
            result = 31 * result + (elementValue != null ? elementValue.hashCode() : 0);
            result = 31 * result + (elementValuePairs != null ? elementValuePairs.hashCode() : 0);
            return result;
        }

        public void accept(ReferenceVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
