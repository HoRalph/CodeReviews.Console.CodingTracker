using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;

class CodingSession
{
    //startTime, endTime, Duration
    public static string StartDateString {get;set;}
    public static string EndDateString {get;set;}
    public DateTime StartDate = ConvertDate(StartDateString);
    public DateTime EndDate = ConvertDate(EndDateString);
    private TimeSpan Duration()
    {
        return EndDate - StartDate;       
    }
    private static DateTime ConvertDate(string DateString)
    {
        DateTime dateValue = DateTime.Today;
        CultureInfo enUS = new CultureInfo("en-US");
        if(Validation.ValidDateTimeFormat(DateString))
        {
            DateTime.TryParseExact(DateString,"MM/dd/yyyy HH:MM",enUS, DateTimeStyles.None, out dateValue);
        }
        return dateValue;
    }
}