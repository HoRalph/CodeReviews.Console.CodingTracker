using System;
using System.Globalization;
class Validation
{
    
    //Verify dates format
    public static int VerifyDates(string startDate, string endDate)
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
     else if (!ValidSession(startDate, endDate))
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
        bool validInputStartDate = DateTime.TryParseExact(startDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputStartDateValue);
        bool validInputEndDate = DateTime.TryParseExact(endDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputEndDateValue);
        return inputEndDateValue > inputStartDateValue;
    }
        
    //verify no overlap dates
    public static bool ValidSession(string startDate, string endDate)
    {
        /*
            if startDate <= existing enDate date or endDate > = existing startDates then it is an invalid session
            select all of the start dates, coner to DateTime. compare with the input endDate for loop.
            select all of the end dates, coner to DateTime. compare with the input startDate for loop.
            
        */       
        CultureInfo enUS = new CultureInfo("en-US");
        DateTime dateValue = DateTime.Today;
        List<string> startDates = DatabaseController.GetStartDates();
        List<string> endDates = DatabaseController.GetEndDates();
        foreach (string _startDate in startDates )
        {
            foreach(string _endDate in endDates)
            {
                bool validStartDate = DateTime.TryParseExact(_startDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime startDateValue);
                bool validEndDate = DateTime.TryParseExact(_endDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime endDateValue);
                bool validInputStartDate = DateTime.TryParseExact(startDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputStartDateValue);
                bool validInputEndDate = DateTime.TryParseExact(endDate, "MM/dd/yyyy HH:mm",enUS, DateTimeStyles.None, out DateTime inputEndDateValue);
                if (inputStartDateValue <= endDateValue || inputEndDateValue >= startDateValue)
                {
                    return false;
                }
                else
                    return true;
            }
        }
        return false;
    }
}
