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
 private List<double> zCoefficients, rshValues, canonicalZCoefficients, canonicalRhsValues;
 private List<List<double>> constraintCoefficients, canonicalConstraintCoefficients;
 private List<int> slack, excess, variables;
 private List<string> constraintVariables, variableType;

 public string MaxOrMin { get => maxOrMin; set => maxOrMin = value; }
 public string Sign { get => sign; set => sign = value; }
 public List<double> ZCoefficients { get => zCoefficients; set => zCoefficients = value; }
 public List<double> RshValues { get => rshValues; set => rshValues = value; }
 public List<double> CanonicalZCoefficients { get => canonicalZCoefficients; set => canonicalZCoefficients = value; }
 public List<double> CanonicalRhsValues { get => canonicalRhsValues; set => canonicalRhsValues = value; }
 public List<List<double>> ConstraintCoefficients { get => constraintCoefficients; set => constraintCoefficients = value; }
 public List<List<double>> CanonicalConstraintCoefficients { get => canonicalConstraintCoefficients; set => canonicalConstraintCoefficients = value; }
 public List<int> Slack { get => slack; set => slack = value; }
 public List<int> Excess { get => excess; set => excess = value; }
 public List<int> Variables { get => variables; set => variables = value; }
 public List<string> ConstraintVariables { get => constraintVariables; set => constraintVariables = value; }
 public List<string> VariableType { get => variableType; set => variableType = value; }

 public CanonicalForm(string maxOrMin, string sign, List<double> zCoefficients, List<double> rshValues, List<double> canonicalZCoefficients, List<double> canonicalRhsValues, List<List<double>> constraintCoefficients, List<List<double>> canonicalConstraintCoefficients, List<int> slack, List<int> excess, List<int> variables, List<string> constraintVariables, List<string> variableType)
 {
     this.MaxOrMin = maxOrMin;
     this.Sign = sign;
     this.ZCoefficients = zCoefficients;
     this.RshValues = rshValues;
     this.CanonicalZCoefficients = canonicalZCoefficients;
     this.CanonicalRhsValues = canonicalRhsValues;
     this.ConstraintCoefficients = constraintCoefficients;
     this.CanonicalConstraintCoefficients = canonicalConstraintCoefficients;
     this.Slack = slack;
     this.Excess = excess;
     this.Variables = variables;
     this.ConstraintVariables = constraintVariables;
     this.VariableType = variableType;
 }

 
 public void ConvertZToCanonicalForm()
 {
     if (MaxOrMin == "max")
     {
         foreach (var coefficient in ZCoefficients)
         {
             CanonicalZCoefficients.Add(coefficient * -1);
         }
     }
     else
     {
         CanonicalZCoefficients.AddRange(ZCoefficients);
     }
 }

 public void ConvertConstraintsToCanonicalForm()
 {
     for (int i = 0; i < ConstraintCoefficients.Count; i++)
     {
         List<double> convals = new List<double>();
         string consign = Sign;

         for (int j = 0; j < Sign.Length; j++)
         {
             foreach (var val in ConstraintCoefficients[i])
             {
                 if (Sign == ">=")
                 {
                     convals.Add(val * -1);
                 }
                 else if (Sign == "<=")
                 {
                     convals.Add(val);
                 }
                 else
                 {
                     convals.Add(val * -1);
                 }
             }

             if (Sign == ">=")
             {
                 Excess.Add(1);
                 CanonicalRhsValues.Add(RshValues[i] * -1);
             }
             else if (Sign == "<=")
             {
                 Slack.Add(1);
                 CanonicalRhsValues.Add(RshValues[i]);
             }
             else
             {
                 convals.Add(1);
                 Excess.Add(1);
                 convals.Add(1);
                 Slack.Add(1);
                 CanonicalRhsValues.Add(RshValues[i] * -1);
                 CanonicalRhsValues.Add(RshValues[i]);

             }
         }

         CanonicalConstraintCoefficients.Add(convals);
     }
 }


 public override string ToString()
 {
     string canonicalForm = $"Canonical Form:\n{MaxOrMin} z = ";
     for (int i = 0; i < CanonicalZCoefficients.Count; i++)
     {
         canonicalForm += $"{CanonicalZCoefficients[i]}x{Variables[i]} ";
     }
     canonicalForm += $"\ns.t.\n";

     for (int i = 0; i < CanonicalConstraintCoefficients.Count; i++)
     {
         for (int j = 0; j < CanonicalConstraintCoefficients[i].Count; j++)
         {
             canonicalForm += $"{CanonicalConstraintCoefficients[i][j]}x{Variables[j]} ";
         }
         canonicalForm += $"<={CanonicalRhsValues[i]}\n";
     }

     return canonicalForm;
 }
 
}
}
