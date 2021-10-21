using ChustaSoft.Common.Enums;
using System;

namespace ChustaSoft.Common.Helpers
{
    public static class DateTimeHelper
    {

        private const int MinWeekDays = 1;
        private const int TotalWeekDays = 7;


        /// <summary>
        /// Retrives the first day of the week based on the week of a given date
        /// </summary>
        /// <param name="date">Given date to extract the first day of the week</param>
        /// <param name="weekCalendarType">Calendar type, by default Starting on Monday</param>
        /// <returns>First day of the week given by the specified date</returns>
        public static DateTime GetFirstWeekDate(this DateTime date, WeekCalendarType weekCalendarType = WeekCalendarType.MondayFirst)
        {
            int dayToSubstract = GetDaysToSubstract(date, weekCalendarType);

            return date.AddDays(dayToSubstract);
        }

        /// <summary>
        /// Retrives the last day of the week based on the week of a given date
        /// </summary>
        /// <param name="date">Given date to extract the last day of the week</param>
        /// <param name="weekCalendarType">Calendar type, by default Starting on Monday</param>
        /// <returns>Last day of the week given by the specified date</returns>
        public static DateTime GetLastWeekDate(this DateTime date, WeekCalendarType weekCalendarType = WeekCalendarType.MondayFirst)
        {
            int dayToSubstract = GetDaysToAdd(date, weekCalendarType);

            return date.AddDays(dayToSubstract);
        }


        private static int GetDaysToSubstract(DateTime date, WeekCalendarType weekCalendarType)
        {
            if (weekCalendarType == WeekCalendarType.MondayFirst && date.DayOfWeek == DayOfWeek.Sunday)
                return (TotalWeekDays - 1) * (-1);
            else
                return MinWeekDays - (int)date.DayOfWeek + (int)weekCalendarType;
        }

        private static int GetDaysToAdd(DateTime date, WeekCalendarType weekCalendarType)
        {
            if (weekCalendarType == WeekCalendarType.MondayFirst && date.DayOfWeek == DayOfWeek.Sunday)
                return 0;
            else
                return TotalWeekDays - (int)date.DayOfWeek + (int)weekCalendarType;
        }

    }
}
