using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    public abstract class ExtendedPublicHoliday : PublicHolidayBase
    {
        public abstract IDictionary<DateTime, string> AllHolidaysName(int year);
        public abstract IList<DateTime> AllHolidays(int year);
        public abstract bool IsHoliday(DateTime dt);
        public abstract IList<DateTime> GetAllHolidaysInDateRange(DateTime startDate, DateTime endDate);
        public abstract IDictionary<DateTime, string> GetAllHolidaysNameInDateRange(DateTime startDate, DateTime endDate);
    }
}
