﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal abstract class WeeklyTask
    {
        private readonly string name;

        public WeeklyTask(string name)
        {
            this.name = name;
        }

        public virtual string ConvertToString(int index)
        {
            return $"Task #{index + 1}: {name} ";
        }

        public abstract string GetAlarm();
    }
}
