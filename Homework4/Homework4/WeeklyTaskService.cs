using System;
using System.Collections.Generic;

namespace Homework4
{
    internal class WeeklyTaskService
    {
        delegate void GetMessage(int taskNumber);
        delegate void WriteOutput(string text);
        delegate string ReadInput();
        private readonly WriteOutput outputDel = Program.WriteOutput;
        private readonly ReadInput inputDel = Program.ReadInputString;
        private readonly List<WeeklyTask> tasks;

        public WeeklyTaskService()
        {
            tasks = new();
        }

        public void AddNewTask()
        {
            outputDel("Add task in format: {},{},{},{}");
            var inputData = inputDel();
            Add(inputData);
        }

        public void UpdateTask()
        {
            outputDel("Input number to update:");
            var inputNumber = inputDel();
            var taskNumber = int.Parse(inputNumber);

            outputDel("Input new task data:");
            var inputTaskData = inputDel().Trim();
            Update(taskNumber, inputTaskData);
        }

        public void FilterTaskByPriority()
        {
            outputDel("Input priority:");
            var parsedPriority = Enum.Parse<Priority>(inputDel());

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i] is PriorityTask priorityTask && priorityTask.GetPriority() == parsedPriority)
                {
                    PrintTask(i);
                }
            }
        }

        public void FilterTaskByDate()
        {
            outputDel("Input data:");
            var inputDate = inputDel();
            var date = DateTime.Parse(inputDate);

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i] is RegularTask regularTask && regularTask.GetDate() >= date)
                {
                    PrintTask(i);
                }
            }
        }

        public void PrintAllTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                PrintTask(i);
                outputDel(tasks[i].GetAlarm());
            }
        }

        private void Add(string inputData)
        {
            if (!string.IsNullOrEmpty(inputData))
            {
                var task = ParseNewTask(inputData);
                AddNewTask(task);
            }
            else
            {
                outputDel("Invalid task format, try again.");
            }
        }

        private void Update(int taskNumber, string inputTaskData)
        {
            if (!string.IsNullOrEmpty(inputTaskData))
            {
                var task = ParseNewTask(inputTaskData);
                UpdateTask(taskNumber, task);
            }
            else
            {
                outputDel($"Task #{taskNumber} hasn't been updated");
            }
        }

        private void UpdateTask(int taskNumber, WeeklyTask task)
        {
            tasks[taskNumber - 1] = task;
            GetMessage del = PrintUpdateMessage;
            del(taskNumber);
        }

        private void PrintUpdateMessage(int taskNumber)
        {
            outputDel($"Task #{taskNumber} has been updated");
        }

        private void PrintTask(int i)
        {
            outputDel(tasks[i].ConvertToString(i));
        }

        private WeeklyTask ParseNewTask(string inputData)
        {
            var parts = inputData?.Split(',');

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                outputDel("Invalid task format, try again.");
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
