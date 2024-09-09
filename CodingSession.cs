using System;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using System.Globalization;
//namespace Program;
public class CodingSession
{
    //startTime, endTime, Duration
    public  string startDateString;
    public  string endDateString;
    private DateTime startDate;
    private DateTime endDate;
    private TimeSpan duration;
    public string StartDateString
    {
        get { return startDateString; }
        set { startDateString = value;}
    }
    public string EndDateString
    {
        get { return endDateString; }
        set { endDateString = value;}
    }
    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value;}
    }
    public DateTime EndDate
    {
        get {return endDate;}
        set {endDate = value;}
    }
    public TimeSpan Duration
    {
        get {return duration;}
        set {duration = value;}
    }
    public DateTime ConvertDate(string DateString)
    {
        DateTime dateValue = DateTime.Today;
        CultureInfo enUS = new CultureInfo("en-US");
        if(Validation.ValidDateTimeFormat(DateString))
        {
            DateTime.TryParseExact(DateString,"MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out dateValue);
        }
        return dateValue;
    }
}