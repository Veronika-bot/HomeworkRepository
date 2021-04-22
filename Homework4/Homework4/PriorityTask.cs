using System;

namespace Homework4
{
    internal class PriorityTask : RegularTask
    {
        private readonly Priority priority;

        public PriorityTask(string name, DateTime date, TimeSpan time, Priority priority) : base(name, date, time)
        {
            this.priority = priority;
        }

        public Priority GetPriority()
        {
            return priority;
        }

        public override string ConvertToString(int index)
        {
            var output = base.ConvertToString(index);

            if (priority != Priority.Empty)
            {
                output += $"{priority}";
            }

            return output;
        }

        public override string GetAlarm()
        {
            return base.GetAlarm() + $" Priority: {priority}";
        }
    }
}
