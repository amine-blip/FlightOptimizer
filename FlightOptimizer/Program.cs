namespace FlightOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var passengersFilePath = args[0];
            var rowsCapacitiesFilePath = args[1];

            //Read Inputs
            var inputsReader = new InputsReader();
            var passengers = inputsReader.ReadPassengersFile(passengersFilePath);
            var rowsCapacities = inputsReader.ReadRowsCapacitiesFile(rowsCapacitiesFilePath);

            //Build single passengers and families list (eligible seats)
            var seatsBuilder = new SeatsBuilder();
            var eligibleSeats = seatsBuilder.Build(passengers);

            //Solve optimal flight
            var flightOptimizer = new FlightOptimizer();
            var optimalFlight = flightOptimizer.SolveOptimalFlight(eligibleSeats, rowsCapacities);

            //Display optimal revenue and passengers repartition
            Console.WriteLine(optimalFlight.ToString());
        }
    }
}