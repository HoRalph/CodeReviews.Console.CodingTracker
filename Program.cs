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
            DatabaseController.CreateTable();
            switch(Input.Menu())
            {
                case 0:
                //exit program
                return;
                
                case 1:
                    Console.Clear();
                    DatabaseController.ViewTable();
                    Console.ReadLine();
                    break;
                
                case 2:
                    Console.Clear();
                    Input.InsertInput();
                    mySession.StartDate = mySession.ConvertDate(Input.startDateTime);
                    mySession.EndDate = mySession.ConvertDate(Input.endDateTime);
                    mySession.Duration = mySession.EndDate - mySession.StartDate;
                    DatabaseController.InsertRecord(mySession.StartDate.ToString(), mySession.EndDate.ToString(), mySession.Duration.ToString());
                    break;
                
                case 3:
                    Console.Clear();
                    DatabaseController.ViewTable();
                    Console.WriteLine();
                    Input.InputId();
                    DatabaseController.DeleteRecord(Input.updateId);
                    break;
                
                case 4:
                    Console.Clear();
                    DatabaseController.ViewTable();
                    Console.WriteLine();
                    Input.InputId();
                    Input.InsertInput();
                    mySession.StartDate = mySession.ConvertDate(Input.startDateTime);
                    mySession.EndDate = mySession.ConvertDate(Input.endDateTime);
                    mySession.Duration = mySession.EndDate - mySession.StartDate;
                    DatabaseController.UpdateRecord(Input.updateId,mySession.StartDate.ToString(), mySession.EndDate.ToString(), mySession.Duration.ToString());
                    break;
                
                case 5:
                    Console.Clear();
                    Visualisation.DrawTable();
                    Console.WriteLine();
                    Console.ReadLine();
                    //DatabaseController.DeleteTable();
                    break;
                
                default:
                    return;
            }
        }
    }

}