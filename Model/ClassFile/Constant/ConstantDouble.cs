﻿/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.ClassFile.Constant
{
    public class ConstantDouble : ConstantValue
    {
        protected double value;

        public ConstantDouble(double value) : base(CONSTANT_Double)
        {
            this.value = value;
        }

        public double getValue()
        {
            return value;
        }
    }
}
