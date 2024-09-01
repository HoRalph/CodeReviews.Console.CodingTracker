using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using System.Dynamic;

class CodingSession
{
    //startTime, endTime, Duration
    public DateTime StartTime {get;set;}
    public DateTime EndTime {get;set;}
    private TimeSpan Duration()
    {
        return EndTime - StartTime;       
    }
}