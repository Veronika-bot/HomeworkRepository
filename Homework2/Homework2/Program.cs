using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = string.Empty;
            while (day != "Exit the program")
            {
                Console.WriteLine("Enter the day of week: ");
                day = Console.ReadLine().ToLower();
                int color = 0;
                int days = -1;
                int numberofday = -1;

                switch (day)
                {
                    case "mon":
                    case "monday":
                        day = "Monday";
                        color = 1;
                        numberofday = (int)DayOfWeek.Monday;
                        days = 5;
                        break;
                    case "tue":
                    case "tuesday":
                        day = "Tuesday";
                        color = 2;
                        numberofday = (int)DayOfWeek.Tuesday;
                        days = 4;
                        break;
                    case "wed":
                    case "wednesday":
                        day = "Wednesday";
                        color = 3;
                        numberofday = (int)DayOfWeek.Wednesday;
                        days = 3;
                        break;
                    case "thu":
                    case "thursday":
                        day = "Thursday";
                        color = 4;
                        numberofday = (int)DayOfWeek.Thursday;
                        days = 2;
                        break;
                    case "fri":
                    case "friday":
                        day = "Friday";
                        color = 5;
                        numberofday = (int)DayOfWeek.Friday;
                        days = 1;
                        break;
                    case "sat":
                    case "suturday":
                        day = "Saturday";
                        color = 6;
                        numberofday = (int)DayOfWeek.Saturday;
                        days = 0;
                        break;
                    case "sun":
                    case "sunday":
                        day = "Sunday";
                        color = 8;
                        numberofday = (int)DayOfWeek.Sunday;
                        days = 0;
                        break;
                    case "exit":
                        day = "Exit the program";
                        color = 15;
                        break;
                    default:
                        day = "There is no such day";
                        color = 15;
                        break;
                }

                string today = DateTime.Today.DayOfWeek.ToString();
                int numberdaytoday = (int)DateTime.Today.DayOfWeek;
                DateTime nextday = DateTime.Today.AddDays((numberofday -numberdaytoday + 7) % 7);
                if (nextday == DateTime.Today)
                {
                    nextday = nextday.AddDays(7);
                }

                Console.ForegroundColor = (ConsoleColor)color;
                if (numberofday != -1)
                {
                    Console.WriteLine($"{day} - {numberofday}, {days} days before the weekend, {nextday} - next {day} date");
                    if (today == day)
                    {
                        Console.WriteLine($"{today} is today");
                    }
                }
                else
                {
                    Console.WriteLine($"{day}");
                }
                Console.ResetColor();

            }

        }
    }
}
