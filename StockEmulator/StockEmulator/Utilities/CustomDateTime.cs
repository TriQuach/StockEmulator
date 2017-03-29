using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Utilities
{
    public class CustomDateTime
    {
        public DateTime Date { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public CustomDateTime(DateTime dt)
        {
            Date = dt;
            Year = dt.Year;
            Month = dt.Month;
            Day = dt.Day;
            Hours = dt.Hour;
            Minutes = dt.Minute;
            Seconds = dt.Second;
        }

        public string ToHourString()
        {
            if (Hours < 12)
            {
                return String.Format(
                "{0:00} AM",
                this.Hours);
            }

            return String.Format(
                "{0} PM",
                Date.ToString("hh"));
        }
    }
}
