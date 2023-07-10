/* Solve a multiple knapsack problem using a MIP solver.
https://developers.google.com/optimization/pack/multiple_knapsack?hl=fr#c_1
*/
using Google.OrTools.LinearSolver;

namespace FlightOptimizer
{
    class MultipleKnapsackSolver
    {
        public SolverResult Solve(double[] weights, double[] values, double[] binCapacities)
        {
            int NumItems = weights.Length;
            int[] allItems = Enumerable.Range(0, NumItems).ToArray();

            int NumBins = binCapacities.Length;
            int[] allBins = Enumerable.Range(0, NumBins).ToArray();

            // Create the linear solver with the SCIP backend.
            Solver solver = Solver.CreateSolver("SCIP");

            // Variables.
            Variable[,] x = new Variable[NumItems, NumBins];
            foreach (int i in allItems)
            {
                foreach (int b in allBins)
                {
                    x[i, b] = solver.MakeBoolVar($"x_{i}_{b}");
                }
            }

            // Constraints.
            // Each item is assigned to at most one bin.
            foreach (int i in allItems)
            {
                Constraint constraint = solver.MakeConstraint(0, 1, "");
                foreach (int b in allBins)
                {
                    constraint.SetCoefficient(x[i, b], 1);
                }
            }

            // The amount packed in each bin cannot exceed its capacity.
            foreach (int b in allBins)
            {
                Constraint constraint = solver.MakeConstraint(0, binCapacities[b], "");
                foreach (int i in allItems)
                {
                    constraint.SetCoefficient(x[i, b], weights[i]);
                }
            }

            // Objective.
            Objective objective = solver.Objective();
            foreach (int i in allItems)
            {
                foreach (int b in allBins)
                {
                    objective.SetCoefficient(x[i, b], values[i]);
                }
            }
            objective.SetMaximization();
            Solver.ResultStatus resultStatus = solver.Solve();
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
                throw new Exception("The problem does not have an optimal solution!");
            var result = ProcessResult(allItems, allBins, solver, x);
            return result;
        }

        private static SolverResult ProcessResult(int[] allItems, int[] allBins, Solver solver, Variable[,] x)
        {
            var items = new List<List<int>>();
            var optimalValue = solver.Objective().Value();
            foreach (int b in allBins)
            {
                var binItems = new List<int>();
                foreach (int i in allItems)
                {
                    if (x[i, b].SolutionValue() == 1)
                    {
                        binItems.Add(i);
                    }
                }
                items.Add(binItems);
            }
            return new SolverResult(items, optimalValue);
        }
    }
}