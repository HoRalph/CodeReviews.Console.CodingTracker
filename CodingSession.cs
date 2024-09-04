using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;

public class CodingSession
{
    //startTime, endTime, Duration
    public  string StartDateString {get;set;}
    public  string EndDateString {get;set;}
    public DateTime StartDate;
    public DateTime EndDate;
    public TimeSpan Duration;    
    public void SetStartDate(string dateString)
    {
    this.StartDate = ConvertDate(this.StartDateString);
    //public DateTime EndDate = ConvertDate(EndDateString);
    }
    public void SetEndDate(string dateString)
    {
    this.EndDate = ConvertDate(this.EndDateString);
    //public DateTime EndDate = ConvertDate(EndDateString);
    }
    public void SetDuration()
    {
        this.Duration =  this.EndDate - this.StartDate;
    }
    public DateTime ConvertDate(string DateString)
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