namespace FlightOptimizer
{
    class SeatsBuilder
    {
        public List<ISeats> Build(List<Passenger> passengers)
        {
            var familiesDictionary = new Dictionary<string, Family>();
            var singlePassengers = new List<ISeats>();
            foreach (var passenger in passengers)
            {
                if (passenger.HasFamily)
                    AddPassengerToFamiliesDictionary(passenger, familiesDictionary);
                else
                {
                    //Single childs should not be added
                    if(passenger.PassengerType == PassengerType.Adult) 
                        singlePassengers.Add(passenger);
                }
            }
            RemoveFamiliesWithNoAdults(familiesDictionary);
            return familiesDictionary.Select(kvp => kvp.Value).Concat(singlePassengers).ToList();
        }
        private void AddPassengerToFamiliesDictionary(Passenger passenger, Dictionary<string, Family> familiesDictionary)
        {
            if (familiesDictionary.ContainsKey(passenger.FamilyName))
            {
                var family = familiesDictionary[passenger.FamilyName];
                family.AddMember(passenger);
            }
            else
            {
                var family = new Family(passenger.FamilyName);
                family.AddMember(passenger);
                familiesDictionary.Add(passenger.FamilyName, family);
            }
        }
        private void RemoveFamiliesWithNoAdults(Dictionary<string, Family> familiesDictionary)
        {
            foreach (var family in familiesDictionary)
            {
                if (!family.Value.HasAdults) familiesDictionary.Remove(family.Key);
            }
        }
    }
}