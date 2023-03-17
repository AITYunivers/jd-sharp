/*
 * Copyright (c) 2008, 2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Attribute
{
    public class CodeException
    {
        protected int index;
        protected int startPc;
        protected int endPc;
        protected int handlerPc;
        protected int catchType;

        public CodeException(int index, int startPc, int endPc, int handlerPc, int catchType)
        {
            this.index = index;
            this.startPc = startPc;
            this.endPc = endPc;
            this.handlerPc = handlerPc;
            this.catchType = catchType;
        }

        public int getStartPc()
        {
            return startPc;
        }

        public int getEndPc()
        {
            return endPc;
        }

        public int getHandlerPc()
        {
            return handlerPc;
        }

        public int getCatchType()
        {
            return catchType;
        }

        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            CodeException that = (CodeException)o;

            if (startPc != that.startPc) return false;
            return endPc == that.endPc;
        }

        public int hashCode()
        {
            return 969815374 + 31 * startPc + endPc;
        }

        public override string ToString()
        {
            return $"CodeException{{index={index}, startPc={startPc}, endPc={endPc}, handlerPc={handlerPc}, catchType={catchType}}}";
        }
    }
}
