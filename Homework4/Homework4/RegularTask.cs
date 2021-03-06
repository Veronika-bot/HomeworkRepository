using System;

namespace Homework4
{
    internal class RegularTask : WeeklyTask
    {
        private readonly DateTime date;
        private readonly TimeSpan time;

        public RegularTask(string name) : base(name)
        {
        }

        public RegularTask(string name, DateTime date) : base(name)
        {
            this.date = date;
        }

        public RegularTask(string name, DateTime date, TimeSpan time) : base(name)
        {
            this.date = date;
            this.time = time;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public override string ConvertToString(int index)
        {
            var output = base.ConvertToString(index);

            if (date != default)
            {
                output += $"{date.ToShortDateString()} ";
            }

            if (time != default)
            {
                output += $"{time} ";
            }

            return output;
        }

        public override string GetAlarm()
        {
            return $"{(date - DateTime.Today).Days} days left";
        }
    }
}
