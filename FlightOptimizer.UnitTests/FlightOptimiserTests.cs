using System.Text;

namespace FlightOptimizer.UnitTests
{
    internal class FlightOptimiserTests
    {
        [Test]
        public void SolveOptimalFlightTest()
        {
            var expectedOptimalRevenue = 2800;

            var child1 = new Passenger(1, PassengerType.Child, 10, "A", false);
            var child2 = new Passenger(2, PassengerType.Child, 10, "A", false);
            var adult1 = new Passenger(6, PassengerType.Adult, 15, "A", false);
            var adult2 = new Passenger(7, PassengerType.Adult, 15, "-", false);
            var adult3 = new Passenger(8, PassengerType.Adult, 15, "-", false);
            var adult4 = new Passenger(12, PassengerType.Adult, 15, "-", false);
            var adult5 = new Passenger(13, PassengerType.Adult, 15, "-", false);
            var adult6 = new Passenger(14, PassengerType.Adult, 15, "-", false);
            var adult7 = new Passenger(15, PassengerType.Adult, 15, "-", false);
            var adult8 = new Passenger(16, PassengerType.Adult, 15, "-", false);
            var adult9 = new Passenger(17, PassengerType.Adult, 15, "-", false);
            var adult10 = new Passenger(18, PassengerType.Adult, 15, "-", false);
            var adult11 = new Passenger(19, PassengerType.Adult, 15, "-", false);

            var passengers = new List<Passenger>() { child1, child2, adult1, adult2, adult3, adult4, adult5, adult6, adult7, adult8, adult9, adult10, adult11 };
            var rows = new List<int>() { 6, 6 , 6, 6};
            var eligibleSeats = new SeatsBuilder().Build(passengers);
            var optimalFlight = new FlightOptimizer().SolveOptimalFlight(eligibleSeats, rows);

            Assert.That(optimalFlight.Revenue, Is.EqualTo(expectedOptimalRevenue));
        }
    }
}
