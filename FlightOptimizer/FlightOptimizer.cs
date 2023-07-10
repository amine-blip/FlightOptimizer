namespace FlightOptimizer
{
    class FlightOptimizer
    {
        public OptimalFlight SolveOptimalFlight(List<ISeats> eligibleSeatsList, List<int> rowsCapacities)
        {
            var solver = new MultipleKnapsackSolver();
            var weights = new List<double>();
            var values = new List<double>();
            foreach (var eligibleSeats in eligibleSeatsList)
            {
                weights.Add(eligibleSeats.Count());
                values.Add(eligibleSeats.Price());
            }
            var solverResult = solver.Solve(weights.ToArray(), values.ToArray(), rowsCapacities.Select(Convert.ToDouble).ToArray());
            var optimalRevenue = solverResult.OptimalValue;
            var optimalSeats = new List<List<ISeats>>();
            foreach (var indexes in solverResult.Items)
            {
                var rowList = new List<ISeats>();
                foreach (var index in indexes)
                {
                    rowList.Add(eligibleSeatsList[index]);
                }
                optimalSeats.Add(rowList);
            }

            return new OptimalFlight(optimalSeats, optimalRevenue);
        }


    }
}