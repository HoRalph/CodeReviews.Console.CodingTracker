using System;
using System.Configuration;
using System.Collections.Specialized;
namespace Program;

class Program
{
 
    public static void Main(String[] args)
    {
        Console.WriteLine(ConfigurationManager.AppSettings.Get("key1"));
        
        while(true)
        {

            DatabaseController.ExecuteNonQuery(@"CREATE TABLE IF NOT EXISTS CodingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartDateTime STRING,
            EndDateTime STRING,
            Duration STRING);");
            //DatabaseController.CreateTable();
            switch(Input.Menu())
            {
                case 0:
                //exit program
                return;
                
                case 1:
                    
                    break;
                
                case 2:
                    DatabaseController.InsertRecord("08/25/2024", "09/01/2024", "5");
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