using System;

namespace Homework2
{
    class Program
    {
        static void Main()
        {
            string day = string.Empty;
            while (day != "Exit the program")
            {
                Console.WriteLine("Enter the day of week: ");
                day = Console.ReadLine().ToLower();

                switch (day)
                {
                    case "mon" or "monday":
                        TasksWithDays(DayOfWeek.Monday);
                        break;
                    case "tue" or "tuesday":
                        day = "Tuesday";
                        TasksWithDays(DayOfWeek.Tuesday);
                        break;
                    case "wed" or "wednesday":
                        day = "Wednesday";
                        TasksWithDays(DayOfWeek.Wednesday);
                        break;
                    case "thu" or "thursday":
                        day = "Thursday";
                        TasksWithDays(DayOfWeek.Thursday);
                        break;
                    case "fri" or "friday":
                        day = "Friday";
                        TasksWithDays(DayOfWeek.Friday);
                        break;
                    case "sat" or "saturday":
                        day = "Saturday";
                        TasksWithDays(DayOfWeek.Saturday);
                        break;
                    case "sun" or "sunday":
                        day = "Sunday";
                        TasksWithDays(DayOfWeek.Sunday);
                        break;
                    case "exit":
                        day = "Exit the program";
                        Console.WriteLine($"{day}");
                        break;
                    default:
                        day = "There is no such day";
                        Console.WriteLine($"{day}");
                        break;
                }

            }

        }

        public static void TasksWithDays(DayOfWeek day)
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            DateTime nextday = DateTime.Today.AddDays((day - today + 7) % 7);

            if (nextday == DateTime.Today)
            {
                nextday = nextday.AddDays(7);
            }

            Console.ForegroundColor = (ConsoleColor)day + 1;
            Console.WriteLine($"{day} - {(int)day}");
            Console.WriteLine($"{nextday} - next {day} date");

            if (today == day)
            {
                Console.WriteLine($"{today} is today");
            }

            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                Console.WriteLine("0 days before the weekend");
            }
            else
            {
                
                Console.WriteLine($"{DayOfWeek.Saturday - day} days before the weekend");
            }

            Console.ResetColor();
        }
    }
}
