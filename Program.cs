using System;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static Airplane[] ReadAirplaneArray(int n)
        {
            Airplane []airplane = new Airplane[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i+1+"\nВведіть місто відправлення ");
                airplane[i].StartCity = Console.ReadLine();
                Console.WriteLine("\nВведіть місто прибуття ");
                airplane[i].FinishCity = Console.ReadLine();
                Console.WriteLine("\nВведіть дату відправлення \nРік ");
                airplane[i].StartDate.Year = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nМісяць ");
                airplane[i].StartDate.Month = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nДень ");
                airplane[i].StartDate.Day = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nГодина ");
                airplane[i].StartDate.Hours = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nХвилина ");
                airplane[i].StartDate.Minutes = Int32.Parse(Console.ReadLine());

            }
            return airplane;
        }
        static void PrintAirplane(Airplane airplane)
        {
            Console.WriteLine("Місто відправлення - " + airplane.StartCity);
            Console.WriteLine("Місто прибуття - " + airplane.FinishCity);
            Console.WriteLine("Дата відправлення - " + airplane.StartDate.Year + "/" 
                + airplane.StartDate.Month + "/" + airplane.StartDate.Day + " " 
                + airplane.StartDate.Hours + ":" + airplane.StartDate.Minutes);
            Console.WriteLine("Дата прибуття - " + airplane.FinishDate.Year + "/"
                + airplane.FinishDate.Month + "/" + airplane.FinishDate.Day + " "
                + airplane.FinishDate.Hours + ":" + airplane.FinishDate.Minutes);
        }
        static void PrintAirplanes(Airplane []airplanes)
        {
            for (int i = 0; i < airplanes.Length; i++)
            {
                Console.WriteLine("\n");
                PrintAirplane(airplanes[i]);
            }
        }
        static void GetAirplaneInfo(Airplane []airplanes, out int maxTime, out int minTime)
        {
            int totalTime = maxTime = minTime = airplanes[0].GetTotalTime();
            for (int i = 1; i < airplanes.Length; i++)
            {
                totalTime = airplanes[i].GetTotalTime();
                if (totalTime > maxTime)
                    maxTime = totalTime;

                if (totalTime < minTime)
                    minTime = totalTime;
            }
        }
    }

    struct Airplane
    {
        public string StartCity;
        public string FinishCity;
        public Date StartDate;
        public Date FinishDate;
        public Airplane(string startCity, string finishCity, Date startDate, Date finishDate)
        {
            StartCity = startCity;
            FinishCity = finishCity;
            StartDate = startDate;
            FinishDate = finishDate;
        }
        public int GetTotalTime()
        {
            int hour, minute;
            hour = FinishDate.Hours - StartDate.Hours;
            minute = FinishDate.Minutes - StartDate.Minutes;
            return hour * 60 + minute;
        }
        public bool IsArrivingToday()
        {
            if (StartDate.Year == FinishDate.Year && StartDate.Month == FinishDate.Month && StartDate.Day == FinishDate.Day)
                return true;
            else return false;
        }
    }
    struct Date
    {
        public int Year;
        public int Month;
        public int Day;
        public int Hours;
        public int Minutes;
        public Date(int year, int month, int day, int hours, int minutes)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
        }
    }
}
