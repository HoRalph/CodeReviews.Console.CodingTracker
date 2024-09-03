using System;
using System.Globalization;
class Validation
{
    
    //Verify dates format
    public static bool ValidDateTimeFormat(string DateString)
    {
        CultureInfo enUS = new CultureInfo("en-US");
        DateTime dateValue = DateTime.Today;
        bool validDate = false;
            validDate = DateTime.TryParseExact(DateString, "MM/dd/yyyy HH:MM",enUS, DateTimeStyles.None, out dateValue);
        return validDate;
    }

    //verify end date later than start date
    public static bool ValidDuration(DateTime startDate, DateTime endDate) 
    {
        return endDate > startDate;
    }
        
    //verify no overlap dates
    public static bool ValidSession(DateTime startDate, DateTime endDate)
    {
        /*
            if startDate <= existing enDate date or endDate > = existing startDates then it is an invalid session
            select all of the start dates, coner to DateTime. compare with the input endDate for loop.
            select all of the end dates, coner to DateTime. compare with the input startDate for loop.
            
        */


        return true;
    }
}
