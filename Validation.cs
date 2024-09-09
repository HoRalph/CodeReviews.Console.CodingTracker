using System;
using System.Globalization;
using Spectre.Console;
class Validation
{
    
    //Verify dates format
    public static int VerifyDates(string startDate, string endDate, int iD = 0)
    {
     if(!ValidDateTimeFormat(startDate))
     {
        return 1;
     }
     else if(!ValidDateTimeFormat(endDate))
     {
        return 2;
     }

    else if(!ValidDuration(startDate, endDate))
    {
        return 3;
    }
     else if (!ValidSession(startDate, endDate, iD))
     {
        return 4;
     }
     else
        return 0;
     
    }
    public static bool ValidDateTimeFormat(string DateString)
    {
        CultureInfo enUS = new CultureInfo("en-US");
        DateTime dateValue = DateTime.Today;
        bool validDate = false;
            validDate = DateTime.TryParseExact(DateString, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out dateValue);
        return validDate;
    }

    //verify end date later than start date
    public static bool ValidDuration(string startDate, string endDate) 
    {
        CultureInfo enUS = new CultureInfo("en-US");
        DateTime.TryParseExact(startDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputStartDateValue);
        DateTime.TryParseExact(endDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputEndDateValue);
        return inputEndDateValue > inputStartDateValue;
    }
    //verify no overlap dates
    public static bool ValidSession(string startDate, string endDate, int iD)
    {
        /*
            if startDate <= existing enDate date or endDate > = existing startDates then it is an invalid session
            select all of the start dates, coner to DateTime. compare with the input endDate for loop.
            select all of the end dates, coner to DateTime. compare with the input startDate for loop.
            
        */       
        CultureInfo enUS = new CultureInfo("en-US");
        List<string> startDates = DatabaseController.GetStartDates(iD);
        List<string> endDates = DatabaseController.GetEndDates(iD);
        if (startDates.Count == 0 || endDates.Count == 0)
        {
            return true;
        }
        for (int i = 0; i<startDates.Count;i++)
        {
                DateTime.TryParseExact(startDates[i], "M/d/yyyy HH:mm:ss tt",enUS, DateTimeStyles.None, out DateTime startDateValue);
                DateTime.TryParseExact(endDates[i], "M/d/yyyy HH:mm:ss tt",enUS, DateTimeStyles.None, out DateTime endDateValue);
                DateTime.TryParseExact(startDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputStartDateValue);
                DateTime.TryParseExact(endDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputEndDateValue);
                if ((inputStartDateValue <= endDateValue) && (inputStartDateValue >= startDateValue))
                {
                    return false;
                }
                else if (inputEndDateValue <= endDateValue && inputEndDateValue >= startDateValue)
                {
                    return false;
                }
        }
        return true;
    }
}
