namespace FlightOptimizer
{
    internal class SolverResult
    {
        public List<List<int>> Items { get; }
        public double OptimalValue { get; }
        public SolverResult(List<List<int>> items, double optimalValue)
        {
            Items = items;
            OptimalValue = optimalValue;
        }
    }
}
