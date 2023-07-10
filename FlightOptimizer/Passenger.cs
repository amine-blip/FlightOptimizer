namespace FlightOptimizer
{
    class Passenger : ISeats
    {
        public Passenger(int id, PassengerType passengerType, uint age, string familyName, bool requiresTwoSeats)
        {
            ValidateFields(age, passengerType, familyName, requiresTwoSeats);
            Id = id;
            PassengerType = passengerType;
            Age = age;
            FamilyName = familyName;
            RequiresTwoSeats = requiresTwoSeats;
            HasFamily = DoesHaveFamily(familyName);
        }
        public int Id { get; }
        public PassengerType PassengerType { get; }
        public uint Age { get; }
        public string FamilyName { get; }
        public bool RequiresTwoSeats { get; }
        public bool HasFamily { get; }

        public int Count()
        {
            return RequiresTwoSeats ? 2 : 1;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id} {nameof(PassengerType)}: {PassengerType} {nameof(Age)}: {Age} {nameof(FamilyName)}: {FamilyName} {nameof(RequiresTwoSeats)}: {RequiresTwoSeats}";
        }

        public double Price()
        {
            var seatPrice = PassengerType == PassengerType.Adult ? Constants.AdultSeatPrice : Constants.ChildrenSeatPrice;
            return seatPrice * Count();
        }

        private bool DoesHaveFamily(string familyName)
        {
            if (familyName.Equals(Constants.NoFamily))
                return false;
            return true;
        }
        private void ValidateFields(uint age, PassengerType passengerType, string familyName, bool requieresTwoSeats)
        {
            if (string.IsNullOrWhiteSpace(familyName))
                throw new Exception("Family Name can not be Null or Empty");
            switch (passengerType)
            {
                case PassengerType.Child:
                    {
                        if (age > Constants.MaximumAgeOfChildren)
                            throw new Exception("A Child Passenger can not be older than 12 years");
                        if (requieresTwoSeats)
                            throw new Exception("A Child Passenger can not require two seats");
                        break;
                    }
                case PassengerType.Adult:
                    {
                        if (age <= Constants.MaximumAgeOfChildren)
                            throw new Exception("An Adult Passenger cant be younger than 12 years");
                        break;
                    }
            }
        }

        public string OccupiedBy()
        {
            return $"Passenger[{Id}]";
        }
    }
    enum PassengerType
    {
        Child,
        Adult
    }
}