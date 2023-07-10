namespace FlightOptimizer.UnitTests
{
    internal class SeatsBuilderTest
    {
        [Test]
        public void TestBuild() 
        {
            var adult1 = new Passenger(1, PassengerType.Adult, 20, "A", false);
            var adult2 = new Passenger(2, PassengerType.Adult, 20, "A", false);
            var adult3 = new Passenger(3, PassengerType.Adult, 20, "-", false);
            var child1 = new Passenger(4, PassengerType.Child, 11, "A", false);
            var passengersList = new List<Passenger>() { adult1, adult2, adult3, child1};

            var expectedFamily = new Family("A");
            expectedFamily.AddMember(adult1);
            expectedFamily.AddMember(adult2);
            expectedFamily.AddMember(child1);
            var expectedEligibleSeats = new List<ISeats>() { expectedFamily, adult3 };

            var builder = new SeatsBuilder();
            var eligibleSeats = builder.Build(passengersList);

            Assert.That(eligibleSeats.Count, Is.EqualTo(2));
            Assert.That(eligibleSeats[0].OccupiedBy(), Is.EqualTo(expectedEligibleSeats[0].OccupiedBy()));
            Assert.That(eligibleSeats[1].OccupiedBy(), Is.EqualTo(expectedEligibleSeats[1].OccupiedBy()));
        }
        [Test]
        public void TestBuild_FamilyWithThreeAdults_ShouldThrow() 
        {
            var adult1 = new Passenger(1, PassengerType.Adult, 20, "A", false);
            var adult2 = new Passenger(2, PassengerType.Adult, 20, "A", false);
            var adult3 = new Passenger(3, PassengerType.Adult, 20, "A", false);
            var passengers = new List<Passenger>() { adult1, adult2, adult3};
            var builder = new SeatsBuilder();
            Assert.Throws<Exception>(() => builder.Build(passengers));
        }
        [Test]
        public void TestBuild_FamilyWithFourChilds_ShouldThrow()
        {
            var adult1 = new Passenger(1, PassengerType.Adult, 20, "A", false);
            var adult2 = new Passenger(2, PassengerType.Adult, 20, "A", false);
            var child1 = new Passenger(3, PassengerType.Child, 11, "A", false);
            var child2 = new Passenger(4, PassengerType.Child, 11, "A", false);
            var child3 = new Passenger(5, PassengerType.Child, 11, "A", false);
            var child4 = new Passenger(6, PassengerType.Child, 11, "A", false);
            var passengers = new List<Passenger>() { adult1, adult2, child1, child2, child3, child4 };
            var builder = new SeatsBuilder();
            Assert.Throws<Exception>(() => builder.Build(passengers));
        }
        [Test]
        public void TestBuild_FamilyWithNoAdults_ShouldBeFiltered() 
        {
            var adult1 = new Passenger(1, PassengerType.Adult, 20, "B", false);
            var adult2 = new Passenger(2, PassengerType.Adult, 20, "B", false);
            var child1 = new Passenger(3, PassengerType.Child, 11, "A", false);
            var child2 = new Passenger(4, PassengerType.Child, 11, "A", false);
            var child3 = new Passenger(5, PassengerType.Child, 11, "A", false);
            var passengers = new List<Passenger>() { adult1, adult2, child1, child2, child3 };
            var builder = new SeatsBuilder();
            var eligibleSeats = builder.Build(passengers);
            Assert.That(eligibleSeats.Count, Is.EqualTo(1));
            Assert.That(eligibleSeats[0].OccupiedBy, Is.EqualTo("Family[B]"));
        }
        [Test]
        public void TestBuild_SingleChild_ShouldBeFiltered()
        {
            var adult1 = new Passenger(1, PassengerType.Adult, 20, "B", false);
            var adult2 = new Passenger(2, PassengerType.Adult, 20, "B", false);
            var child1 = new Passenger(3, PassengerType.Child, 11, "-", false);
            var passengers = new List<Passenger>() { adult1, adult2, child1};
            var builder = new SeatsBuilder();
            var eligibleSeats = builder.Build(passengers);
            Assert.That(eligibleSeats.Count, Is.EqualTo(1));
            Assert.That(eligibleSeats[0].OccupiedBy, Is.EqualTo("Family[B]"));
        }
    }
}
