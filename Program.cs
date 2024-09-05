using System;
using System.Configuration;
using System.Collections.Specialized;
namespace Program;

class Program
{
    
    public static void Main(String[] args)
    {
        //CodingSession mySession = new CodingSession();
        Console.WriteLine(ConfigurationManager.AppSettings.Get("key1"));
        
        while(true)
        {
            CodingSession mySession = new CodingSession();
            /*DatabaseController.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS CodingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartDateTime STRING,
            EndDateTime STRING,
            Duration STRING);");*/
            DatabaseController.CreateTable();
            switch(Input.Menu())
            {
                case 0:
                //exit program
                return;
                
                case 1:

                    break;
                
                case 2:
                    Input.InsertInput();
                    mySession.StartDate = mySession.ConvertDate(Input.startDateTime);
                    mySession.EndDate = mySession.ConvertDate(Input.endDateTime);
                    mySession.Duration = mySession.EndDate - mySession.StartDate;
                    Console.WriteLine(mySession.StartDate);
                    Console.WriteLine(mySession.EndDate);
                    Console.WriteLine(mySession.Duration);
                    break;
                
                case 3:
                    break;
                
                case 4:
                    break;
                
                case 5:
                    break;
                
                default:
                    return;
            
            }
        }
    }

}