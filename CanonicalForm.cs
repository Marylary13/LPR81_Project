using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381
{
    internal class CanonicalForm
    {
        //object for the input files just a placeholder for now
        Input input = new Input();

        // for now creating the variables like this
        // when input class is created it will be something like this eg. : maxOrMin = input.MaxOrMin
        private string maxOrMin, sign;  
        private List<double> zCoefficients, constraintCoefficients, rshValues, canonicalZCoefficients, canonicalConstraintCoefficients, canonicalRhsValues;
        private List<int> slack, excess;
        private List<string> zVariables, constraintVariables;

        public CanonicalForm(string maxOrMin, string sign, List<double> zCoefficients, List<double> constraintCoefficients, List<double> rshValues, List<double> canonicalZCoefficients, List<double> canonicalConstraintCoefficients, List<double> canonicalRhsValues, List<int> slack, List<int> excess, List<string> zVariables, List<string> constraintVariables)
        {
            this.maxOrMin = maxOrMin;
            this.sign = sign;


            zCoefficients = new List<double>();
            constraintCoefficients = new List<double>();
            rshValues = new List<double>();
            canonicalZCoefficients = new List<double>();
            canonicalConstraintCoefficients = new List<double>();
            canonicalRhsValues = new List<double>();
            slack = new List<int>();
            excess = new List<int>();
            zVariables = new List<string>();
            constraintVariables = new List<string>();

        }


        public void ConvertZToCanonicalForm()
        {
            if (maxOrMin == "max")
            {
                foreach (var coefficient in zCoefficients)
                {
                    canonicalZCoefficients.Add(coefficient * -1);
                }
            }
            else
            {
                canonicalZCoefficients.AddRange(zCoefficients);
            }
        }


        public void ConvertConstraintsToCanonicalForm()
        {
            //making j = 1 to avoid including the z rhs 

            int i = 0;
            int j = 1;
            while (i < constraintCoefficients.Count)
            {
                string consign = sign; 

                foreach (var val in constraintCoefficients.ElementAt(i)) //error here trying to fix
                {
                    if (sign == ">=")
                    {
                        canonicalConstraintCoefficients.Add(val * -1);
                    }
                    else if (sign == "<=")
                    {
                        canonicalConstraintCoefficients.Add(val);
                    }
                    else
                    {
                        canonicalConstraintCoefficients.Add(val * -1);
                        canonicalConstraintCoefficients.Add(val);
                    }
                }

                if (sign == ">=")
                {
                    canonicalConstraintCoefficients.Add(1);
                    constraintVariables.Add("e");
                    canonicalRhsValues.Add(rshValues[j] * -1);
                }
                else if (sign == "<=")
                {
                    canonicalConstraintCoefficients.Add(1);
                    constraintVariables.Add("s");
                    canonicalRhsValues.Add(rshValues[j]);
                }
                else
                {
                    canonicalConstraintCoefficients.Add(1);
                    constraintVariables.Add("e");
                    canonicalConstraintCoefficients.Add(1);
                    constraintVariables.Add("s");
                    canonicalRhsValues.Add(rshValues[j] * -1);
                    canonicalRhsValues.Add(rshValues[j]);
                }

                i++;
            }
        }

    }  
}
