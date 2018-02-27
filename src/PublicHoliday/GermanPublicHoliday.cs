using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHoliday
{
    /// <summary>
    /// German Federal (German Unity Day) and State Public Holidays (excluding Sundays)
    /// </summary>
    public class GermanPublicHoliday : ExtendedPublicHoliday
    {
        #region  Inner Types

        /// <summary>
        ///
        /// </summary>
        public enum States
        {
            /// <summary>
            /// All states
            /// </summary>
            ALL = 0,

            /// <summary>
            /// Baden-Württemberg
            /// </summary>
            BW,

            /// <summary>
            /// Bayern, Bavaria
            /// </summary>
            BY,

            /// <summary>
            /// Berlin
            /// </summary>
            BE,

            /// <summary>
            /// Brandenburg
            /// </summary>
            BB,

            /// <summary>
            /// Bremen
            /// </summary>
            HB,

            /// <summary>
            /// Hamburg
            /// </summary>
            HH,

            /// <summary>
            /// Hessen, Hesse
            /// </summary>
            HE,

            /// <summary>
            /// Mecklenburg-Vorpommern
            /// </summary>
            MV,

            /// <summary>
            /// Niedersachsen, Lower Saxony
            /// </summary>
            NI,

            /// <summary>
            /// Nordrhein-Westfalen, North Rhine-Westphalia
            /// </summary>
            NW,

            /// <summary>
            /// Rheinland-Pfalz, Rhineland-Palatinate
            /// </summary>
            RP,

            /// <summary>
            /// Saarland
            /// </summary>
            SL,

            /// <summary>
            /// Sachsen, Saxony
            /// </summary>
            SN,

            /// <summary>
            /// Sachsen-Anhalt
            /// </summary>
            ST,

            /// <summary>
            /// Schleswig-Holstein
            /// </summary>
            SH,

            /// <summary>
            /// Thüringen
            /// </summary>
            TH,
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the state (ISO 3166-2:DE), + default All for all states.
        /// </summary>
        public States State { get; set; }

        /// <summary>
        /// Whether this state observes epiphany.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes epiphany; otherwise, <c>false</c>.
        /// </value>
        public bool HasEpiphany => Array.IndexOf(new[] { States.BW, States.BY, States.ST }, State) > -1;

        /// <summary>
        /// Whether this state observes Fronleichnam.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Fronleichnam; otherwise, <c>false</c>.
        /// </value>
        public bool HasCorpusChristi => Array.IndexOf(new[] { States.BW, States.BY, States.HE, States.NW, States.RP, States.SL }, State) > -1;

        /// <summary>
        /// Whether this state observes Mariä Himmelfahrt.
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Mariä Himmelfahrt; otherwise, <c>false</c>.
        /// </value>
        public bool HasAssumption => States.SL == State;

        /// <summary>
        /// Whether this state observes Buß- und Bettag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Buß- und Bettag; otherwise, <c>false</c>.
        /// </value>
        public bool HasRepentance => States.SN == State;

        /// <summary>
        /// Whether this state observes Reformationstag
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Reformationstag; otherwise, <c>false</c>.
        /// </value>
        public bool HasReformation => Array.IndexOf(new[] { States.BB, States.MV, States.SN, States.ST, States.TH }, State) > -1;

        /// <summary>
        /// Whether this state observes Allerheiligen
        /// </summary>
        /// <value>
        /// <c>true</c> if this state observes Allerheiligen; otherwise, <c>false</c>.
        /// </value>
        public bool HasAllSaints => Array.IndexOf(new[] { States.BW, States.BY, States.NW, States.RP, States.SL }, State) > -1;

        #endregion

        #region Holiday Methods

        /// <summary>
        /// Neujahrstag New Year's Day January 1
        /// </summary>
        /// <param name="year"></param>
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// Heilige Drei Könige Epiphany January 6
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }

        /// <summary>
        /// Karfreitag - Good Friday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime GoodFriday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(-2);
            return hol;
        }

        /// <summary>
        /// Ostermontag - Easter Monday
        /// </summary>
        /// <param name="year"></param>
        public static DateTime EasterMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(1);
            return hol;
        }

        /// <summary>
        /// Tag der Arbeit - Labour Day
        /// </summary>
        /// <param name="year">The year.</param>

        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }

        /// <summary>
        /// Christi Himmelfahrt - Ascension
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Ascension(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays(4 + (7 * 5));
            return hol;
        }

        /// <summary>
        /// Pfingstsonntag - Pentecost
        /// </summary>
        /// <param name="year"></param>

        public static DateTime PentecostSunday(int year) => PentecostMonday(year).AddDays(-1);

        /// <summary>
        /// Pfingstmontag - Pentecost
        /// </summary>
        /// <param name="year"></param>

        public static DateTime PentecostMonday(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            hol = hol.AddDays((7 * 7) + 1);
            return hol;
        }


        /// <summary>
        /// Fronleichnam - CorpusChristi
        /// </summary>
        /// <param name="year"></param>

        public static DateTime CorpusChristi(int year)
        {
            var hol = HolidayCalculator.GetEaster(year);
            //first Thursday after Trinity Sunday (Pentecost + 1 week)
            hol = hol.AddDays((7 * 8) + 4);
            return hol;
        }

        /// <summary>
        /// Mariä Himmelfahrt - Assumption of Mary
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }

        /// <summary>
        /// Tag der Deutschen Einheit - German Unity
        /// </summary>
        /// <param name="year"></param>
        public static DateTime GermanUnity(int year)
        {
            return new DateTime(year, 10, 3);
        }

        /// <summary>
        /// Reformationstag - Reformation
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Reformation(int year)
        {
            return new DateTime(year, 10, 31);
        }


        /// <summary>
        /// Allerheiligen - All Saints
        /// </summary>
        /// <param name="year"></param>

        public static DateTime AllSaints(int year)
        {
            return new DateTime(year, 11, 1);
        }

        /// <summary>
        /// Buß- und Bettag - Repentance and Prayer
        /// </summary>
        /// <param name="year"></param>
        public static DateTime Repentance(int year)
        {
            var firstAdvent = HolidayCalculator.FindPrevious(Christmas(year), DayOfWeek.Sunday).AddDays(-28);
            var wednesday = HolidayCalculator.FindPrevious(firstAdvent, DayOfWeek.Wednesday);
            return wednesday;
        }

        /// <summary>
        /// Heiligabend - Christmas eve
        /// </summary>
        /// <param name="year"></param>

        public static DateTime ChristmasEve(int year)
        {
            return new DateTime(year, 12, 24, 14, 0, 0);
        }

        /// <summary>
        /// Weihnachtstag - Christmas
        /// </summary>
        /// <param name="year"></param>

        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }

        /// <summary>
        /// Zweiter Weihnachtsfeiertag- St Stephens
        /// </summary>
        /// <param name="year"></param>

        public static DateTime StStephen(int year)
        {
            return new DateTime(year, 12, 26);
        }

        /// <summary>
        /// Silvester - New Year's Eve
        /// </summary>
        /// <param name="year"></param>

        public static DateTime NewYearsEve(int year)
        {
            return new DateTime(year, 12, 31, 14, 0, 0);
        }

        #endregion

        #region Public Methods

        #region PublicHolidayBase Override Methods

        /// <summary>
        /// List of federal and state holidays (for defined <see cref="State"/>)
        /// </summary>
        /// <param name="year">The year.</param>

        public override IList<DateTime> PublicHolidays(int year)
        {
            var days = new List<DateTime>();
            var holidays = PublicHolidayNames(year);
            foreach (var day in holidays)
            {
                days.Add(day.Key);
            }
            return days;

        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Dictionary of bank holidays
        /// </returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var holidays = AllHolidaysName(year);
            for (int i = 0; i < holidays.Count; i++)

                foreach (var item in holidays)
                {
                    switch (item.Value)
                    {
                        case "Heilige Drei Könige": { if (HasEpiphany) holidays.Remove(item.Key); break; }
                        case "Fronleichnam": { if (HasCorpusChristi) holidays.Remove(item.Key); break; }
                        case "Mariä Himmelfahrt": { if (HasAssumption) holidays.Remove(item.Key); break; }
                        case "Reformationstag": { if (HasReformation || year == 2017) holidays.Remove(item.Key); break; }
                        case "Allerheiligen": { if (HasAllSaints) holidays.Remove(item.Key); break; }
                        case "Buß- und Bettag": { if (HasRepentance) holidays.Remove(item.Key); break; }
                        case "Ostersonntag":
                        case "Pfingstsonntag":
                        case "Heiligabend":
                        case "Silvester":
                            {
                                holidays.Remove(item.Key); break;
                            }
                        default:
                            break;
                    }
                }
            return holidays;
        }

        /// <summary>
        /// Determines whether date is a public holiday.
        /// </summary>
        /// <param name="dt">The date.</param>
        /// <returns>
        ///   <c>true</c> if is public holiday; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            foreach (var day in PublicHolidayNames(dt.Year))
            {
                if (day.Key == dt)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region ExtendedPublicHoliday Override Methods

        public override IDictionary<DateTime, string> AllHolidaysName(int year)
        {
            var holidays = new Dictionary<DateTime, string> { { NewYear(year), "Neujahrstag" } };
            holidays.Add(Epiphany(year), "Heilige Drei Könige");
            holidays.Add(GoodFriday(year), "Karfreitag");
            holidays.Add(HolidayCalculator.GetEaster(year), "Ostersonntag");
            holidays.Add(EasterMonday(year), "Ostermontag");
            holidays.Add(MayDay(year), "Tag der Arbeit");
            holidays.Add(Ascension(year), "Christi Himmelfahrt");
            holidays.Add(PentecostSunday(year), "Pfingstsonntag");
            holidays.Add(PentecostMonday(year), "Pfingstmontag");
            holidays.Add(CorpusChristi(year), "Fronleichnam"); // Happy cadaver
            holidays.Add(Assumption(year), "Mariä Himmelfahrt");
            holidays.Add(GermanUnity(year), "Tag der Deutschen Einheit");
            holidays.Add(Reformation(year), "Reformationstag");
            holidays.Add(AllSaints(year), "Allerheiligen");
            holidays.Add(Repentance(year), "Buß- und Bettag");
            holidays.Add(ChristmasEve(year), "Heiligabend");
            holidays.Add(Christmas(year), "Weihnachtstag");
            holidays.Add(StStephen(year), "Zweiter Weihnachtsfeiertag");
            holidays.Add(NewYearsEve(year), "Silvester");

            return holidays;
        }

        public override IList<DateTime> AllHolidays(int year)
        {
            var days = new List<DateTime>();
            var holidays = AllHolidaysName(year);
            foreach (var day in holidays)
            {
                days.Add(day.Key);
            }
            return days;
        }

        public override bool IsHoliday(DateTime dt)
        {
            foreach (var day in AllHolidaysName(dt.Year))
            {
                if (day.Key == dt)
                {
                    return true;
                }
            }
            return false;
        }

        public override IList<DateTime> GetAllHolidaysInDateRange(DateTime startDate, DateTime endDate)
        {
            var days = new List<DateTime>();
            var holidays = GetAllHolidaysNameInDateRange(startDate, endDate);
            foreach (var day in holidays)
            {
                days.Add(day.Key);
            }
            return days;

        }

        public override IDictionary<DateTime, string> GetAllHolidaysNameInDateRange(DateTime startDate, DateTime endDate)
        {
            var holidays = new Dictionary<DateTime, string>();
            for (var year = startDate.Year; year <= endDate.Year; year++)
            {

                var days = AllHolidaysName(year)
                        .Where(d => d.Key >= startDate && d.Key <= endDate);
                foreach (var item in days)
                {
                    holidays.Add(item.Key, item.Value);
                }
            }
            return holidays;
        }

        #endregion
        #endregion

    }
}