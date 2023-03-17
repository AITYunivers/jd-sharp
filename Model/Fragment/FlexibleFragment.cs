/*
 * Copyright (c) 2008-2019 Emmanuel Dupuy.
 * This project is distributed under the GPLv3 license.
 * This is a Copyleft license that gives the user the right to use,
 * copy and modify the code freely for non-commercial purposes.
 */

namespace JD_Sharp.Model.Fragment
{
    public abstract class FlexibleFragment : Fragment
    {
        protected int minimalLineCount;
        protected int maximalLineCount;
        protected int initialLineCount;
        protected int lineCount;
        protected int weight;
        protected string label;

        public FlexibleFragment(int minimalLineCount, int lineCount, int maximalLineCount, int weight, string label)
        {
            this.minimalLineCount = minimalLineCount;
            this.maximalLineCount = maximalLineCount;
            this.initialLineCount = this.lineCount = lineCount;
            this.weight = weight;
            this.label = label;
        }

        public void resetLineCount()
        {
            lineCount = initialLineCount;
        }

        public int getMinimalLineCount()
        {
            return minimalLineCount;
        }

        public int getMaximalLineCount()
        {
            return maximalLineCount;
        }

        public int getInitialLineCount()
        {
            return initialLineCount;
        }

        public int getLineCount()
        {
            return lineCount;
        }

        public int getWeight()
        {
            return weight;
        }

        public string getLabel()
        {
            return label;
        }

        public bool incLineCount(bool force)
        {
            if (lineCount < maximalLineCount)
            {
                lineCount++;
                return true;
            }
            else
                return false;
        }

        public bool decLineCount(bool force)
        {
            if (lineCount > minimalLineCount)
            {
                lineCount--;
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return $"{{minimal-line-count={getMinimalLineCount()}" +
                   $", maximal-line-count={getMaximalLineCount()}" +
                   $", initial-line-count={getInitialLineCount()}" +
                   $", line-count={getLineCount()}" +
                   $", weight={getWeight()}" +
                   (getLabel() != null ? ", label='" + label + "'}" : "}");
        }

        public void accept(FragmentVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
