﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Utilities
{
    public static class DateTimeValidator
    {
        public static bool IsDateTimeValid(string dateTime)
        {
            return DateTime.TryParse(dateTime, out DateTime dateTimeRes);
        }
    }
}
