using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class WeeklyTaskService
    {
        private readonly List<WeeklyTask> tasks;

        public WeeklyTaskService()
        {
            tasks = new();
        }

        public void AddNewTask()
        { 
            Console.WriteLine("Add task in format: {},{},{},{}");
            var inputData = Console.ReadLine();
            var task = ParseNewTask(inputData);
            AddNewTask(task);
        }

        public void UpdateTask()
        {
            Console.WriteLine("Input number to update:");
            var inputNumber = Console.ReadLine();
            var taskNumber = int.Parse(inputNumber);
            
            Console.WriteLine("Input new task data:");
            var inputTaskData = Console.ReadLine();
            var task = ParseNewTask(inputTaskData);
            tasks[taskNumber - 1] = task;
        }

        public void FilterTaskByPriority()
        {
            Console.WriteLine("Input priority:");
            var priority = Console.ReadLine();

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];

                if (((PriorityTask) tasks[i]).GetPriority().ToString() == priority)
                {
                    PrintTask(i, task);
                }
            }
        }

        public void FilterTaskByDate()
        {
            Console.WriteLine("Input data:");
            var inputDate = Console.ReadLine();
            var date = DateTime.Parse(inputDate);

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];

                if (((RegularTask)tasks[i]).GetDate() >= date)
                {
                    PrintTask(i, task);
                }
            }
        }

        public void PrintAllTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                PrintTask(i, task);
            }
        }

        private static void PrintTask(int i, WeeklyTask task)
        {
            Console.WriteLine(task.ConvertToString(i));
        }

        private WeeklyTask ParseNewTask(string inputData)
        {
            var parts = inputData?.Split(',');

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                Console.WriteLine("Invalid task format, try again.");
                return null;
            }

            return CreateNewTask(parts);
        }

        private WeeklyTask CreateNewTask(string[] parts)
        {
            return parts.Length switch
            {
                1 => CreateTaskWithName(parts),
                2 => CreateTaskWithDate(parts),
                3 => CreateTaskWithDateTime(parts),
                4 => CreateTaskWithDateTimeAndPriority(parts),
                _ => null,
            };
        }

        private WeeklyTask CreateTaskWithName(string[] parts)
        {
             return new RegularTask(parts[0]);
        }

        private WeeklyTask CreateTaskWithDate(string[] parts)
        {
            var date = DateTime.Parse(parts[1]);
            return new RegularTask(parts[0], date);
        }

        private WeeklyTask CreateTaskWithDateTime(string[] parts)
        {
            var (date, time) = ParseDateTime(parts);
            return new RegularTask(parts[0], date, time);
        }

        private WeeklyTask CreateTaskWithDateTimeAndPriority(string[] parts)
        {
            var (date, time) = ParseDateTime(parts);

            var priority = Enum.Parse<Priority>(parts[3]);
            return new PriorityTask(parts[0], date, time, priority);
        }

        private static (DateTime date, TimeSpan time) ParseDateTime(string[] parts)
        {
            var date = DateTime.Parse(parts[1]);
            var time = TimeSpan.Parse(parts[2]);
            return (date, time);
        }

        private void AddNewTask(WeeklyTask task)
        {
            tasks.Add(task);
        }
    }
}
