using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimetableRightNow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] timeTableArray = new string[][]
            {
                new string[] { "Accounting", "Break", "English", "La", "Lunch","TeWaaAko", "Computer Science" },
                new string[] { "English", "BREAK", "Mathematics", "Physics", "Lunhc","iTime", "Accounting" },
                new string[] { "Physics", "Break", "Computer Science", "Lunch", "Mathematics" },
                new string[] { "iTime", "Lunhc", "Accounting", "English" },
                new string[] { "Mathematics", "Break", "La-iTime", "Lunch", "Computer Science", "Physics" }
            };

            dynamic day = new DateTime().DayOfWeek;
            day = Convert.ToString(day);

            TimeTable timetable = new TimeTable();
            timetable.time = string.Format("{0:h:mm:ss tt}", DateTime.Now).Split(':');

            int hour = Convert.ToInt32(timetable.time[0]);
            int minute = Convert.ToInt32(timetable.time[1]);
            string amOrPm = timetable.time[2].Split(' ')[1];

            if (day == "Saturday" || day == "Sunday")
                Console.WriteLine("No classes!");

            if (hour <= 10 && minute <= 9 && day == "Thurday")
                Console.WriteLine("No Classes!");


            if (hour <= 9 && amOrPm == "am")
                Console.WriteLine("No Classes!");

            if (hour >= 3 && amOrPm == "pm")
                Console.WriteLine("No Classes!");

            switch (day)
            {
                case "Monday":
                    timetable.Monday();
                    break;
                case "Tuesday":
                    timetable.Tuesday();
                    break;
                case "Wednesday":
                    timetable.Wednesday();
                    break;
                case "Thursday":
                    timetable.Thursday();
                    break;
                case "Friday":
                    timetable.Friday();
                    break;
            }
        }
    }

    internal interface ITimeTable
    {
        public string[] time { get; set; }
        public void Monday();
        public void Tuesday();
        public void Wednesday();
        public void Thursday();
        public void Friday();
    }

    class TimeTable : ITimeTable
    {
        public string[] time { get; set; }

        public void Monday()
        {
            Console.WriteLine("Monday");
        }

        public void Tuesday()
        {
            Console.WriteLine("Tuesday");
        }

        public void Wednesday()
        {
            Console.WriteLine("Wednesday");
        }

        public void Thursday()
        {
            Console.WriteLine("Thurday");
        }

        public void Friday()
        {
            Console.WriteLine("Friday");
        }
    }
}