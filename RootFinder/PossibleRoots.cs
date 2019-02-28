using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootFinder
{
    class PossibleRoots
    {
        private Function _function;
        private List<double> _possibleRoots;

        public double AdequateRoot
        {
            get
            {
                Argument argument = new Argument("x", double.NaN);
                double leastDiff = double.MaxValue;
                double adequate = double.NaN;
                foreach(double possibleRoot in _possibleRoots)
                {
                    if (Double.IsNaN(possibleRoot)) continue;
                    argument.setArgumentValue(possibleRoot);
                    double diff = Math.Abs(_function.calculate(argument));
                    if (diff < leastDiff)
                    {
                        leastDiff = diff;
                        adequate = possibleRoot;
                    }
                }
                return adequate;
            }
        }

        public PossibleRoots(Function function)
        {
            this._function = function;
            this._possibleRoots = new List<double>();
        }

        public void AddPossibleRoot(double possibleRoot)
        {
            this._possibleRoots.Add(possibleRoot);
        }
    }
}
