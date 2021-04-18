using System;

namespace Homework4
{
    class Program
    {
        private static WeeklyTaskService service = new WeeklyTaskService();
        static void Main(string[] args)
        {
            RunInLoop();
            Console.ReadKey();
        }

        private static void RunInLoop()
        {
            string input = null;

            while (input != "exit")
            {
                PrintMenu();

                input = Console.ReadLine();

                if (int.TryParse(input, out var parsedInput))
                {
                    HandleCommand(parsedInput);
                }
                else
                {
                    Console.WriteLine("Invalid command, try again.");
                }
            }
        }

        private static void HandleCommand(int parsedInput)
        {
            switch (parsedInput)
            {
                case 1:
                    service.AddNewTask();
                    break;
                case 2:
                    service.PrintAllTasks();
                    break;
                case 3:
                    service.UpdateTask();
                    break;
                case 4:
                    service.FilterTaskByDate();
                    break;
                case 5:
                    service.FilterTaskByPriority();
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(
            @"Choose a command:
1. Add new task
2. Print all tasks
3. Update task
4. Filter task by date
5. Filter task by priority");
        }
    }
}