using System;
using System.Collections.Generic;

namespace Homework4
{
    public delegate void WriteOutput(string text);
    public delegate string ReadInput();
    public delegate void UpdateTaskNotifier(string message, int taskNumber);

    internal class WeeklyTaskService
    {
        private WriteOutput writeOutput;
        private ReadInput readInput;
        private UpdateTaskNotifier updateTaskNotifier;
        private readonly List<WeeklyTask> tasks;

        public WeeklyTaskService()
        {
            tasks = new();
        }

        public void SetOutputWriter(WriteOutput outputWriter)
        {
            writeOutput = outputWriter;   
        }

        public void SetInputReader(ReadInput inputWriter)
        {
            readInput = inputWriter;
        }

        public void SetUpdateTaskNotifier(UpdateTaskNotifier taskNotifierUpdate)
        {
            updateTaskNotifier = taskNotifierUpdate;
        }

        public void AddNewTask()
        {
            writeOutput("Add task in format: {},{},{},{}");
            var inputData = readInput();
            Add(inputData);
        }

        public void UpdateTask()
        {
            writeOutput("Input number to update:");
            var inputNumber = readInput();
            var taskNumber = int.Parse(inputNumber);

            writeOutput("Input new task data:");
            var inputTaskData = readInput().Trim();
            Update(taskNumber, inputTaskData);
        }

        public void FilterTaskByPriority()
        {
            writeOutput("Input priority:");
            var parsedPriority = Enum.Parse<Priority>(readInput());

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
            writeOutput("Input data:");
            var inputDate = readInput();
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
                writeOutput(tasks[i].GetAlarm());
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
                writeOutput("Invalid task format, try again.");
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
                writeOutput($"Task #{taskNumber} hasn't been updated");
            }
        }

        private void UpdateTask(int taskNumber, WeeklyTask task)
        {
            tasks[taskNumber - 1] = task;
            updateTaskNotifier(" has been updated", taskNumber);
        }

        private void PrintTask(int i)
        {
            writeOutput(tasks[i].ConvertToString(i));
        }

        private WeeklyTask ParseNewTask(string inputData)
        {
            var parts = inputData?.Split(',');

            if (parts == null || parts.Length < 1 || parts.Length > 4)
            {
                writeOutput("Invalid task format, try again.");
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
