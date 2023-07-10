namespace FlightOptimizer
{
    class InputsReader
    {
        public List<Passenger> ReadPassengersFile(string path)
        {
            var passengersLines = File.ReadAllLines(path);
            var passengers = new List<Passenger>();
            var ids = new HashSet<int>();
            for (int i = 1; i < passengersLines.Length; i++)
            {
                var passengerParts = passengersLines[i].Split(";");
                var id = Convert.ToInt32(passengerParts[0]);
                //Check id unicity
                if (ids.Contains(id))
                    throw new Exception("multiple passengers with same id found in the passengers input file");
                ids.Add(id);
                var type = (PassengerType)Enum.Parse(typeof(PassengerType), passengerParts[1]);
                var age = Convert.ToUInt32(passengerParts[2]);
                var family = passengerParts[3];
                var requiresTwoSeats = Convert.ToBoolean(passengerParts[4]);
                var passenger = new Passenger(id, type, age, family, requiresTwoSeats);
                passengers.Add(passenger);
            }
            return passengers;
        }
        public List<int> ReadRowsCapacitiesFile(string path)
        {
            var rowsCapacitiesLines = File.ReadAllLines(path);
            var rowsCapacities = new List<int>();
            var totalCapacity = 0;
            foreach (var line in rowsCapacitiesLines)
            {
                var rowCapacity = Convert.ToInt32(line);
                totalCapacity += rowCapacity;
                rowsCapacities.Add(rowCapacity);
            }
            if (totalCapacity != Constants.AirplaneCapacity)
                throw new Exception($"Total capacity '{totalCapacity}' does not match with the airplance capacity '{Constants.AirplaneCapacity}'");
            return rowsCapacities;
        }
    }
}