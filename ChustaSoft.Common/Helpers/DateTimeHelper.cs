using ChustaSoft.Common.Enums;
using System;

namespace ChustaSoft.Common.Helpers
{
    public static class DateTimeHelper
    {

        private const int MinWeekDays = 1;
        private const int TotalWeekDays = 7;


        public static DateTime GetFirstWeekDate(this DateTime date, WeekCalendarType weekCalendarType = WeekCalendarType.MondayFirst)
        {
            int dayToSubstract = GetDaysToSubstract(date, weekCalendarType);

            return date.AddDays(dayToSubstract);
        }


        private static int GetDaysToSubstract(DateTime date, WeekCalendarType weekCalendarType)
        {
            if (weekCalendarType == WeekCalendarType.MondayFirst && date.DayOfWeek == DayOfWeek.Sunday)
                return (TotalWeekDays - 1) * (-1);
            else
                return MinWeekDays - (int)date.DayOfWeek + (int)weekCalendarType;
        }
    }
}
