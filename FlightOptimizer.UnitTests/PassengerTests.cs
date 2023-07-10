namespace FlightOptimizer.UnitTests
{
    internal class PassengerTests
    {
        [Test]
        public void ShouldThrow() 
        {
            Assert.Throws<Exception>(() => new Passenger(1, PassengerType.Child, 15, "A", false));
            Assert.Throws<Exception>(() => new Passenger(1, PassengerType.Adult, 10, "A", false));
            Assert.Throws<Exception>(() => new Passenger(1, PassengerType.Child, 15, "A", true));        }
    }
}