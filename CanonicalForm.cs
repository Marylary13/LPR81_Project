using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381
{
    internal class CanonicalForm
    {
         private string maxOrMin, sign;
 private List<double> zCoefficients, constraintCoefficients, rshValues, canonicalZCoefficients, canonicalConstraintCoefficients, canonicalRhsValues;
 private List<int> slack, excess;
 private List<string> zVariables, constraintVariables;

 public CanonicalForm(string maxOrMin, string sign, List<double> zCoefficients, List<double> constraintCoefficients, List<double> rshValues, List<double> canonicalZCoefficients, List<double> canonicalConstraintCoefficients, List<double> canonicalRhsValues, List<int> slack, List<int> excess, List<string> zVariables, List<string> constraintVariables)
 {
     this.maxOrMin = maxOrMin;
     this.sign = sign;
     this.zCoefficients = zCoefficients;
     this.constraintCoefficients = constraintCoefficients;
     this.rshValues = rshValues;
     this.canonicalZCoefficients = canonicalZCoefficients;
     this.canonicalConstraintCoefficients = canonicalConstraintCoefficients;
     this.canonicalRhsValues = canonicalRhsValues;
     this.slack = slack;
     this.excess = excess;
     this.zVariables = zVariables;
     this.constraintVariables = constraintVariables;

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


 public void ConvertToCanonicalForm()
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
    }
}
