using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowProgramming_Assignments
{
    public class TrainSearchCondition
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int InfantCount { get; set; }
        public string TripType { get; set; } // "편도" 또는 "왕복"

        public int TotalPassengers => AdultCount + ChildCount + InfantCount;
    }
}
