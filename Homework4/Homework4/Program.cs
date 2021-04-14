using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework4
{
    class WeeklyTask
    {
        private string taskName;
        private DateTime date;
        private TimeSpan time;
        private int priority;

        private static List<WeeklyTask> allTasks { get; } = new();

        public WeeklyTask(string taskName, DateTime date) : this(taskName, date, 1)
        {

        }

        public WeeklyTask(string taskName, DateTime date, int priority) : this(taskName, date, new TimeSpan(12, 0, 0), priority)
        {

        }

        public WeeklyTask(string taskName, DateTime date, TimeSpan time) : this(taskName, date, time, 1)
        {

        }

        public WeeklyTask(string taskName, DateTime date, TimeSpan time, int priority)
        {
            this.taskName = taskName;
            this.date = date;
            this.time = time;
            this.priority = priority;
            allTasks.Add(this);
        }

        public static void PrintAllTasks()
        {
            for (int i = 0; i < allTasks.Count; i++)
            {
                Console.WriteLine($"{allTasks[i].taskName}, {allTasks[i].date.ToShortDateString()}, {allTasks[i].time}, {allTasks[i].priority}");
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            EnterTask();
            WeeklyTask.PrintAllTasks();
        }

        public static void EnterTask()
        {
            while (true)
            {
                Console.WriteLine("Input information about your task: ");
                string information = Console.ReadLine().Trim();

                if (information == "exit")
                {
                    break;
                }

                information = Regex.Replace(information, @"\s+", "");
                string[] words = information.Split(',');

                if (words.Length == 4)
                {
                    WeeklyTask task = new WeeklyTask(words[0], Convert.ToDateTime(words[1]), TimeSpan.Parse(words[2]), int.Parse(words[3]));
                }
                else if (words.Length == 2)
                {
                    WeeklyTask task = new WeeklyTask(words[0], Convert.ToDateTime(words[1]));
                }
                else if (words.Length == 3 && words[2].All(char.IsDigit))
                {
                    WeeklyTask task = new WeeklyTask(words[0], Convert.ToDateTime(words[1]), int.Parse(words[2]));
                }
                else
                {
                    WeeklyTask task = new WeeklyTask(words[0], Convert.ToDateTime(words[1]), TimeSpan.Parse(words[2]));
                }
            }
        }

    }
}
