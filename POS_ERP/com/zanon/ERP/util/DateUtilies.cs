using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.util
{
    public class DateUtilies
    {


        private HttpContext cur;
        private const int startGreg = 1900;
        private const int endGreg = 2100;
        private string[] allFormats ={"yyyy/MM/dd","yyyy/MM/dd HH:mm","yyyy/M/d","yyyy/M/d HH:mm",
                                         "yyyy/M/dd","yyyy/M/dd HH:mm","yyyy/MM/d","yyyy/MM/d HH:mm",        
            "dd/MM/yyyy","dd/MM/yyyy HH:mm","d/M/yyyy","d/M/yyyy HH:mm",
            "dd/M/yyyy","dd/M/yyyy HH:mm","d/MM/yyyy","d/MM/yyyy HH:mm","yyyy-MM-dd","yyyy-MM-dd HH:mm",
            "yyyy-M-d","yyyy-M-d HH:mm","dd-MM-yyyy","dd-MM-yyyy HH:mm","d-M-yyyy","d-M-yyyy HH:mm",
            "dd-M-yyyy","dd-M-yyyy HH:mm","d-MM-yyyy","d-MM-yyyy HH:mm","yyyy MM dd","yyyy MM dd HH:mm",
            "yyyy M d","yyyy M d HH:mm","dd MM yyyy","dd MM yyyy HH:mm","d M yyyy","d M yyyy HH:mm",
            "dd M yyyy HH:mm","dd M yyyy","d MM yyyy","d MM yyyy HH:mm"};
        private CultureInfo arCul;
        private CultureInfo enCul;
        private HijriCalendar h;
        private UmAlQuraCalendar uCal;
        private GregorianCalendar g;
        private int GetWorkingDays;
        public DateUtilies()
        {
            cur = HttpContext.Current;

            arCul = new CultureInfo("ar-SA");
            enCul = new CultureInfo("en-US");

            //h = new HijriCalendar();
            uCal = new UmAlQuraCalendar();
            //h.HijriAdjustment = -1;
            g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
            //arCul.DateTimeFormat.Calendar = h;
            arCul.DateTimeFormat.Calendar = uCal;
        }

        /// <summary>

        /// Check if string is hijri date and then return true 

        /// </summary>

        /// <PARAM name="hijri"></PARAM>

        /// <returns></returns>

        //public bool IsHijri(string hijri)
        //{
        //    if (hijri.Length<=0)
        //    {

        //        cur.Trace.Warn("IsHijri Error: Date String is Empty");
        //        return false;
        //    }
        //    try
        //    {    
        //        DateTime tempDate=DateTime.ParseExact(hijri,allFormats,
        //             arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
        //        if (tempDate.Year>=startGreg && tempDate.Year<=endGreg)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        cur.Trace.Warn("IsHijri Error :"+hijri.ToString()+"\n"+
        //                          ex.Message);
        //        return false;
        //    }

        //}
        /// <summary>

        /// Check if string is Gregorian date and then return true 

        /// </summary>

        /// <PARAM name="greg"></PARAM>

        /// <returns></returns>

        public bool IsGreg(string greg)
        {
            if (greg.Length <= 0)
            {

                cur.Trace.Warn("IsGreg :Date String is Empty");
                return false;
            }
            try
            {
                DateTime tempDate = DateTime.ParseExact(greg, allFormats,
                    enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                if (tempDate.Year >= startGreg && tempDate.Year <= endGreg)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                cur.Trace.Warn("IsGreg Error :" + greg.ToString() + "\n" + ex.Message);
                return false;
            }
        }


        public string GetHijriMonth(DateTime date)
        {
            string strHijriMonth = "";

            try
            {
                int intMonth = uCal.GetMonth(date);
                Dictionary<int, string> HijriMonths = new Dictionary<int, string>();
                HijriMonths.Add(1, "محرم");
                HijriMonths.Add(2, "صفر");
                HijriMonths.Add(3, "ربيع اول");
                HijriMonths.Add(4, "ربيع الاخر");
                HijriMonths.Add(5, "جمادى الاولى");
                HijriMonths.Add(6, "جمادى الاخرة");
                HijriMonths.Add(7, "رجب");
                HijriMonths.Add(8, "شعبان ");
                HijriMonths.Add(9, "رمضان");
                HijriMonths.Add(10, "شوال");
                HijriMonths.Add(11, "ذو القعدة");
                HijriMonths.Add(12, "ذو الحجة");

                strHijriMonth = HijriMonths[intMonth];

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }

            return strHijriMonth;
        }

        public string GetHijriMonthNumber(DateTime date)
        {
            string strHijriMonth = "";

            try
            {
                int intMonth = uCal.GetMonth(date);



                strHijriMonth = intMonth.ToString("00");

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }

            return strHijriMonth;
        }
        public string GetHijriMonth1(string intMonth)
        {
            string strHijriMonth = "";

            try
            {

                Dictionary<string, string> HijriMonths = new Dictionary<string, string>();
                HijriMonths.Add("01", "محرم");
                HijriMonths.Add("02", "صفر");
                HijriMonths.Add("03", "ربيع اول");
                HijriMonths.Add("04", "ربيع الاخر");
                HijriMonths.Add("05", "جمادى الاولى");
                HijriMonths.Add("06", "جمادى الاخرة");
                HijriMonths.Add("07", "رجب");
                HijriMonths.Add("08", "شعبان ");
                HijriMonths.Add("09", "رمضان");
                HijriMonths.Add("10", "شوال");
                HijriMonths.Add("11", "ذو القعدة");
                HijriMonths.Add("12", "ذو الحجة");

                strHijriMonth = HijriMonths[intMonth];

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }

            return strHijriMonth;
        }
        /// <summary>

        /// Return Formatted Hijri date string 

        /// </summary>

        /// <PARAM name="date"></PARAM>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>

        public string FormatHijri(string date, string format)
        {
            if (date.Length <= 0)
            {

                cur.Trace.Warn("Format :Date String is Empty");
                return "";
            }
            try
            {
                DateTime tempDate = DateTime.ParseExact(date,
                   allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return tempDate.ToString(format, arCul.DateTimeFormat);

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }
        }

        public int getValueForDateHejri(string hejriDate, bool year, bool month, bool day, bool hour, bool minute)
        {
            int val = -1;
            try
            {

                string datePart = hejriDate.Substring(0, hejriDate.IndexOf(" "));
                string timePart = hejriDate.Substring(hejriDate.IndexOf(" "));
                string[] dateParts = hejriDate.Substring(0, hejriDate.IndexOf(' ')).Split(new char[] { '/' });
                string[] timeParts = hejriDate.Substring(hejriDate.IndexOf(' ')).Split(new char[] { ':' });
                if (year)
                {
                    val = int.Parse(dateParts[0]);
                }
                else if (month)
                {
                    val = int.Parse(dateParts[1]);
                }
                else if (day)
                {
                    val = int.Parse(dateParts[2]);
                }
                else if (hour)
                {
                    val = int.Parse(timeParts[0]);
                }
                else if (minute)
                {
                    val = int.Parse(timeParts[1]);
                }
            }
            catch (Exception ex)
            {

            }
            return val;
        }



        /// <summary>

        /// Returned Formatted Gregorian date string

        /// </summary>

        /// <PARAM name="date"></PARAM>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>

        public string FormatGreg(string date, string format)
        {
            if (date.Length <= 0)
            {

                cur.Trace.Warn("Format :Date String is Empty");
                return "";
            }
            try
            {
                DateTime tempDate = DateTime.ParseExact(date, allFormats,
                    enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return tempDate.ToString(format, enCul.DateTimeFormat);

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }

        }
        /// <summary>

        /// Return Today Gregorian date and return it in yyyy/MM/dd format

        /// </summary>

        /// <returns></returns>
        /// 
        public string FormatGreg(DateTime date, string format)
        {
            try
            {
                DateTime tempDate = DateTime.ParseExact(date.ToString("dd/MM/yyyy"), allFormats,
                    enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return tempDate.ToString(format, enCul.DateTimeFormat);

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Date :\n" + ex.Message);
                return "";
            }

        }

        public string GDateNow()
        {
            try
            {
                return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GDateNow :\n" + ex.Message);
                return "";
            }
        }
        public string HDateNow()
        {
            try
            {
                string CurrentHijriDate = GregToHijri(DateTime.Now);

                return CurrentHijriDate;
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GDateNow :\n" + ex.Message);
                return "";
            }
        }

        public string GDateNowForSearch()
        {
            try
            {
                return DateTime.Now.AddDays(1).ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GDateNow :\n" + ex.Message);
                return "";
            }
        }
        /// <summary>

        /// Return formatted today Gregorian date based on your format

        /// </summary>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>

        public string GDateNow(string format)
        {
            try
            {
                return DateTime.Now.ToString(format, enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GDateNow :\n" + ex.Message);
                return "";
            }
        }

        /// <summary>

        /// Return Today Hijri date and return it in yyyy/MM/dd format

        /// </summary>

        /// <returns></returns>

        //public string HDateNow()
        //{
        //    try
        //    {
        //        return DateTime.Now.ToString("yyyy/MM/dd",arCul.DateTimeFormat);
        //    }
        //    catch (Exception ex)
        //    {
        //        cur.Trace.Warn("HDateNow :\n"+ex.Message);
        //        return "";
        //    }
        //}
        /// <summary>

        /// Return formatted today hijri date based on your format

        /// </summary>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>


        //public string HDateNow(string format)
        //{
        //    try
        //    {
        //        return DateTime.Now.ToString(format,arCul.DateTimeFormat);
        //    }
        //    catch (Exception ex)
        //    {
        //        cur.Trace.Warn("HDateNow :\n"+ex.Message);
        //        return "";
        //    }

        //}

        /// <summary>

        /// Convert Hijri Date to it's equivalent Gregorian Date

        /// </summary>

        /// <PARAM name="hijri"></PARAM>

        /// <returns></returns>
        public DateTime[] GetGregPeriodForHijriMonth(int HijriYear, byte HijriMonth)
        {
            DateTime[] arrDates = new DateTime[2];

            try
            {
                string strFirstHijriDate = HijriYear.ToString() + "/" + HijriMonth.ToString("00") + "/01";

                string strNextHijriDate = (HijriMonth < 12 ? HijriYear : HijriYear + 1).ToString() + "/" + (HijriMonth < 12 ? HijriMonth + 1 : 1).ToString("00") + "/01";

                DateTime dtFirstHijriDate = DateTime.ParseExact(strFirstHijriDate, allFormats,
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                DateTime dtNextHijriDate = DateTime.ParseExact(strNextHijriDate, allFormats,
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                DateTime dtMonthEndHijri = dtNextHijriDate.AddDays(-1);
                List<DateTime> days = new List<DateTime>();

                //string strFirsGreg = dtFirstHijriDate.ToString("dd/MM/yyyy", enCul.DateTimeFormat);
                //string strLastGreg = dtMonthEndHijri.ToString("dd/MM/yyyy", enCul.DateTimeFormat);

                //DateTime dtFirstGregDate = DateTime.ParseExact(strFirstHijriDate, "dd/MM/yyyy",
                //   enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                //DateTime dtLstGregDate = DateTime.ParseExact(strLastGreg, "dd/MM/yyyy",
                //   enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                arrDates[0] = dtFirstHijriDate;
                arrDates[1] = dtMonthEndHijri;

                for (DateTime i = dtFirstHijriDate; i <= dtMonthEndHijri; i = i.AddDays(1))
                {
                    if (i.DayOfWeek != DayOfWeek.Friday && i.DayOfWeek != DayOfWeek.Saturday)
                    {
                        days.Add(i);
                        GetWorkingDays++;
                    }
                }
                //TimeSpan workingDays = days[days.Count-1] - days[0];
                //// Difference in days.
                //double differenceInDays = workingDays.TotalDays;

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("HijriToGreg :" + HijriMonth.ToString() + ":" + HijriYear.ToString() + "\n" + ex.Message);
                return null;
            }

            return arrDates;
        }

        public int getWorkingDays()
        {
            int workingDays = GetWorkingDays;

            return workingDays;
        }

        public List<DateTime> GetGregDaysForHijriMonth(int HijriYear, byte HijriMonth)
        {
            List<DateTime> arrDates = new List<DateTime>();

            try
            {
                string strFirstHijriDate = HijriYear.ToString() + "/" + HijriMonth.ToString("00") + "/01";

                string strNextHijriDate = (HijriMonth < 12 ? HijriYear : HijriYear + 1).ToString() + "/" + (HijriMonth < 12 ? HijriMonth + 1 : 1).ToString("00") + "/01";

                DateTime dtFirstHijriDate = DateTime.ParseExact(strFirstHijriDate, allFormats,
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                DateTime dtNextHijriDate = DateTime.ParseExact(strNextHijriDate, allFormats,
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                DateTime dtMonthEndHijri = dtNextHijriDate.AddDays(-1);


                //string strFirsGreg = dtFirstHijriDate.ToString("dd/MM/yyyy", enCul.DateTimeFormat);
                //string strLastGreg = dtMonthEndHijri.ToString("dd/MM/yyyy", enCul.DateTimeFormat);

                //DateTime dtFirstGregDate = DateTime.ParseExact(strFirstHijriDate, "dd/MM/yyyy",
                //   enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                //DateTime dtLstGregDate = DateTime.ParseExact(strLastGreg, "dd/MM/yyyy",
                //   enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                for (DateTime i = dtFirstHijriDate; i <= dtMonthEndHijri; i = i.AddDays(1))
                {
                    if (i.DayOfWeek != DayOfWeek.Friday && i.DayOfWeek != DayOfWeek.Saturday)
                    {
                        arrDates.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("HijriToGreg :" + HijriMonth.ToString() + ":" + HijriYear.ToString() + "\n" + ex.Message);
                return null;
            }

            return arrDates;
        }

        private DateTime Convert_From_Hijri_To_Gregorian(string dt)
        {
            CultureInfo arCI = new CultureInfo("ar-SA");
            string hijri = dt;

            DateTime tempDate = DateTime.ParseExact(hijri, "dd/MM/yyyy", arCI.DateTimeFormat, DateTimeStyles.AllowInnerWhite);
            return tempDate;
        }



        public string HijriToGreg(string hijri)
        {

            if (hijri.Length <= 0)
            {

                cur.Trace.Warn("HijriToGreg :Date String is Empty");
                return "";
            }
            try
            {
                DateTime tempDate = DateTime.ParseExact(hijri, allFormats,
                   arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return tempDate.ToString("dd/MM/yyyy", enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
                return "";
            }
        }
        /// <summary>

        /// Convert Hijri Date to it's equivalent Gregorian Date

        /// and return it in specified format

        /// </summary>

        /// <PARAM name="hijri"></PARAM>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>

        //public string HijriToGreg(string hijri,string format)
        //{

        //    if (hijri.Length<=0)
        //    {

        //        cur.Trace.Warn("HijriToGreg :Date String is Empty");
        //        return "";
        //    }
        //    try
        //    {
        //        DateTime tempDate=DateTime.ParseExact(hijri,
        //           allFormats,arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
        //        return tempDate.ToString(format,enCul.DateTimeFormat);

        //    }
        //    catch (Exception ex)
        //    {
        //        cur.Trace.Warn("HijriToGreg :"+hijri.ToString()+"\n"+ex.Message);
        //        return "";
        //    }
        //}
        /// <summary>

        /// Convert Gregoian Date to it's equivalent Hijir Date

        /// </summary>

        /// <PARAM name="greg"></PARAM>

        /// <returns></returns>

        public string GregToHijri(DateTime greg)
        {

            if (greg == null)
            {

                cur.Trace.Warn("GregToHijri :Date String is Empty");
                return "";
            }
            try
            {
                //string gregDate = greg.Year + "/" + greg.Month + "/" + greg.Day;
                //DateTime tempDate = DateTime.ParseExact(gregDate, allFormats,enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                string hejriDate = greg.ToString("yyyy/MM/dd", arCul.DateTimeFormat);//"yyyy/MM/dd"
                //hejriDate += " " + greg.Hour + ":" + greg.Minute;
                return hejriDate;

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
                return "";
            }
        }
        public string GregToHijri(DateTime greg, string format)
        {

            if (greg == null)
            {

                cur.Trace.Warn("GregToHijri :Date String is Empty");
                return "";
            }
            try
            {
                //string gregDate = greg.Year + "/" + greg.Month + "/" + greg.Day;
                //DateTime tempDate = DateTime.ParseExact(gregDate, allFormats,enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                string hejriDate = greg.ToString(format, arCul.DateTimeFormat);//"yyyy/MM/dd"
                //hejriDate += " " + greg.Hour + ":" + greg.Minute;
                return hejriDate;

            }
            catch (Exception ex)
            {
                cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
                return "";
            }
        }

        public DateTime HijriToGregDate(string hijri)
        {

            if (hijri.Length <= 0)
            {

                cur.Trace.Warn("HijriToGreg :Date String is Empty");
                return DateTime.Now;
            }
            try
            {
                hijri = hijri.Replace("-", "/");
                DateTime tempDate;
                bool IsValid = DateTime.TryParseExact(hijri, allFormats,
                    arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out tempDate);

                if (!IsValid)
                {
                    string day = hijri.Substring(hijri.LastIndexOf("/") + 1);
                    int intCorrectionDay = Convert.ToInt32(day) - 1;
                    string strCorrectionDay = intCorrectionDay.ToString().Length > 1 ? intCorrectionDay.ToString() : "0" + intCorrectionDay.ToString();

                    hijri = hijri.Substring(0, hijri.LastIndexOf("/") + 1) + strCorrectionDay;

                    tempDate = DateTime.ParseExact(hijri, allFormats,
                    arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                }

                return tempDate;//.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
                return DateTime.Now;
            }
        }
        /// <summary>

        /// Convert Hijri Date to it's equivalent Gregorian Date and

        /// return it in specified format

        /// </summary>

        /// <PARAM name="greg"></PARAM>

        /// <PARAM name="format"></PARAM>

        /// <returns></returns>

        //public string GregToHijri(string greg,string format)
        //{

        //    if (greg.Length<=0)
        //    {

        //        cur.Trace.Warn("GregToHijri :Date String is Empty");
        //        return "";
        //    }
        //    try
        //    {

        //        DateTime tempDate=DateTime.ParseExact(greg,allFormats,
        //            enCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
        //        return tempDate.ToString(format,arCul.DateTimeFormat);

        //    }
        //    catch (Exception ex)
        //    {
        //        cur.Trace.Warn("GregToHijri :"+greg.ToString()+"\n"+ex.Message);
        //        return "";
        //    }
        //}

        /// <summary>

        /// Return Gregrian Date Time as digit stamp

        /// </summary>

        /// <returns></returns>

        public string GTimeStamp()
        {
            return GDateNow("yyyyMMddHHmmss");
        }
        /// <summary>

        /// Return Hijri Date Time as digit stamp

        /// </summary>

        /// <returns></returns>

        //public string HTimeStamp()
        //{
        //    return HDateNow("yyyyMMddHHmmss");
        //}


        /// <summary>

        /// Compare two instaces of string date 

        /// and return indication of thier values 

        /// </summary>

        /// <PARAM name="d1"></PARAM>

        /// <PARAM name="d2"></PARAM>

        /// <returns>positive d1 is greater than d2,

        /// negative d1 is smaller than d2, 0 both are equal</returns>

        public int Compare(string d1, string d2)
        {
            try
            {
                DateTime date1 = DateTime.ParseExact(d1, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                DateTime date2 = DateTime.ParseExact(d2, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                return DateTime.Compare(date1, date2);
            }
            catch (Exception ex)
            {
                cur.Trace.Warn("Compare :" + "\n" + ex.Message);
                return -1;
            }

        }
        public int getDifferenceOfDaysBetweenTowHejri(string stratHejri, string endHejri)
        {
            int days = 0;
            try
            {
                DateTime start = Convert.ToDateTime(FormatGreg(stratHejri, "yyyy-MM-dd"), new CultureInfo("en-US"));
                DateTime end = Convert.ToDateTime(FormatGreg(endHejri, "yyyy-MM-dd"), new CultureInfo("en-US"));
                while (end.CompareTo(start) > 0)
                {
                    days++;
                    start = start.AddDays(1);
                }
            }
            catch (Exception ex)
            {
            }
            return days;
        }
        public bool isEndDateAfterStartHejriDate(string stratHejri, string endHejri)
        {
            bool status = false;
            try
            {
                DateTime start = Convert.ToDateTime(FormatGreg(stratHejri, "yyyy-MM-dd"), new CultureInfo("en-US"));
                DateTime end = Convert.ToDateTime(FormatGreg(endHejri, "yyyy-MM-dd"), new CultureInfo("en-US"));
                if (end.CompareTo(start) > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
            }
            return status;
        }

        public bool isDatebetweenTwoDates(string currentDate, string startDate, string endDate)
        {
            bool status = false;
            try
            {
                DateTime start = Convert.ToDateTime(FormatGreg(startDate, "yyyy-MM-dd"), new CultureInfo("en-US"));
                DateTime end = Convert.ToDateTime(FormatGreg(endDate, "yyyy-MM-dd"), new CultureInfo("en-US"));
                DateTime current = Convert.ToDateTime(FormatGreg(currentDate, "yyyy-MM-dd"), new CultureInfo("en-US"));
                if (current.CompareTo(start) >= 0 && current.CompareTo(end) <= 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public int getCurrentHijri(bool Year, bool month, bool day)
        {
            int val = 1;
            try
            {
                string CurrentHijriDate = GregToHijri(DateTime.Now);

                if (Year)
                {
                    val = getValueForDateHejri(CurrentHijriDate, true, false, false, false, false);
                }
                else if (month)
                {
                    val = getValueForDateHejri(CurrentHijriDate, false, true, false, false, false);
                }
                else if (day)
                {
                    val = getValueForDateHejri(CurrentHijriDate, false, false, true, false, false);
                }
            }
            catch (Exception ex)
            {
            }
            return val;
        }

    }
}