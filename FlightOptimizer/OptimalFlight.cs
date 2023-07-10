using System.Text;

namespace FlightOptimizer
{
    class OptimalFlight
    {
        public List<List<ISeats>> Seats { get; }
        public double Revenue { get; }
        public OptimalFlight(List<List<ISeats>> seats, double revenue)
        {
            Seats = seats;
            Revenue = revenue;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"Optimal Revenue is : {Revenue} \nPassengers Distribution :");
            int rowIndex = 0;
            foreach (var row in Seats)
            {
                strBuilder.AppendLine($"Row {rowIndex}: ");
                foreach (var seat in row)
                    strBuilder.Append(seat.OccupiedBy() + " ");
                strBuilder.AppendLine();
                rowIndex++;
            }
            return strBuilder.ToString();
        }
    }
}