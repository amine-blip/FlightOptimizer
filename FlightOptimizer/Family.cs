using System.Collections.Immutable;

namespace FlightOptimizer
{
    class Family : ISeats
    {
        private readonly List<Passenger> members = new List<Passenger>();
        private int numberOfAdults = 0;
        private int numberOfChildren = 0;
        private bool hasAdults = false;
        public Family(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public bool HasAdults => hasAdults;
        public ImmutableList<Passenger> Members => members.ToImmutableList();
        public void AddMember(Passenger member)
        {
            switch (member.PassengerType)
            {
                case PassengerType.Child:
                    {
                        numberOfChildren++;
                        if (numberOfChildren > Constants.MaximumNumberOfChildrenPerFamily)
                            throw new Exception($"A Family can not have more than {Constants.MaximumNumberOfChildrenPerFamily} children");
                        break;
                    }
                case PassengerType.Adult:
                    {
                        numberOfAdults++;
                        hasAdults = true;
                        if (numberOfAdults > Constants.MaximumNumberOfAdultsPerFamily)
                            throw new Exception($"A Family can not have more than {Constants.MaximumNumberOfAdultsPerFamily} adults");
                        break;
                    }
            }
            members.Add(member);
        }

        public int Count()
        {
            return members.Sum(member => member.Count());
        }

        public double Price()
        {
            return members.Sum(member => member.Price());
        }
        public override string ToString()
        {
            return string.Concat(members.Select(member => member.ToString() + "\n"));
        }

        public string OccupiedBy()
        {
            return $"Family[{Name}]";
        }
    }
}