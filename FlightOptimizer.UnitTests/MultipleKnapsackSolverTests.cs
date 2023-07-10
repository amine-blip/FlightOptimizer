namespace FlightOptimizer.UnitTests
{
    public class MultipleKnapsackSolverTests
    {

        [Test]
        public void Test1()
        {
            var expectedOptimalValue = 395;

            double[] Weights = { 48, 30, 42, 36, 36, 48, 42, 42, 36, 24, 30, 30, 42, 36, 36 };
            double[] Values = { 10, 30, 25, 50, 35, 30, 15, 40, 30, 35, 45, 10, 20, 30, 25 };
            double[] BinCapacities = { 100, 100, 100, 100, 100 };
            var solver = new MultipleKnapsackSolver();
            var result = solver.Solve(Weights, Values, BinCapacities);

            Assert.That(result.OptimalValue, Is.EqualTo(expectedOptimalValue));
        }
        [Test]
        public void Test2()
        {
            var expectedOptimalValue = 3000;

            double[] Weights = { 2, 3, 5, 5, 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            double[] Values = { 500, 650, 950, 950, 950, 950, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 };
            int NumItems = Weights.Length;
            double[] BinCapacities = { 6, 6 };
            var solver = new MultipleKnapsackSolver();
            var result = solver.Solve(Weights, Values, BinCapacities);

            Assert.That(result.OptimalValue, Is.EqualTo(expectedOptimalValue));
        }
    }
}