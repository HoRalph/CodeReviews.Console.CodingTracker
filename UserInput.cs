using System;
using System.Collections;
class Input
{
    public static string?startDateTime="";
    public static string?endDateTime="";
    public static int updateId=0;
    public static int Menu()
    {
        string?result = "";
        bool validInput = false;
        int countInputs = 5; //number of valid inputs
        int input=0; 

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("-----------------MAIN MENU-----------------");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine(@"
            Type 0 to Close Application.
            Type 1 to View All Records.
            Type 2 to Insert Record.
            Type 3 to Delete Record.
            Type 4 to Update Record.
            Type 5 to Delete Table.
            ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Please enter an option.");
            
        while(!validInput)
        {
            result = Console.ReadLine();
            validInput = int.TryParse(result, out input) && !(input > countInputs);
            if (validInput == false)
            {
                Console.WriteLine("Invalid Input! Please retry.");
            }
        }
        return input;
    }

    public static void InsertInput()
    {
        bool validDate = false;

        while(!validDate)
        {
            int verifyResults = 99;
            while(verifyResults>0)
            {
            Console.WriteLine("Please enter the start data/time in MM/DD/yyyy HH:MM");
            startDateTime = Console.ReadLine();
            validDate = Validation.ValidDateTimeFormat(startDateTime);
            Console.WriteLine("Please enter the End data/time in MM/DD/yyyy HH:MM");
            endDateTime = Console.ReadLine();
            verifyResults =  Validation.VerifyDates(startDateTime, endDateTime);
            
            switch (verifyResults)
            {
                case 1:
                    Console.WriteLine("Invalid date time format! Please re-enter in MM/DD/yyyy HH:MM.");
                    break;
                case 2:
                    Console.WriteLine("Invalid date time format! Please re-enter in MM/DD/yyyy HH:MM.");
                    break;
                case 3:
                    Console.WriteLine("Start date time does not precede end date time. Please re-enter.");
                    break;
                case 4:
                    Console.WriteLine("Invalid session! overlapping sessions. Please re-enter.");
                    break;                
                default:
                    break;
            }
            }
        }
    }
    public static void InsertInput(int iD)
    {
        bool validDate = false;

        while(!validDate)
        {
            int verifyResults = 99;
            while(verifyResults>0)
            {
            Console.WriteLine("Please enter the start data/time in MM/DD/yyyy HH:MM");
            startDateTime = Console.ReadLine();
            validDate = Validation.ValidDateTimeFormat(startDateTime);
            Console.WriteLine("Please enter the End data/time in MM/DD/yyyy HH:MM");
            endDateTime = Console.ReadLine();
            verifyResults =  Validation.VerifyDates(startDateTime, endDateTime, iD);
            
            switch (verifyResults)
            {
                case 1:
                    Console.WriteLine("Invalid date time format! Please re-enter in MM/DD/yyyy HH:MM.");
                    break;
                case 2:
                    Console.WriteLine("Invalid date time format! Please re-enter in MM/DD/yyyy HH:MM.");
                    break;
                case 3:
                    Console.WriteLine("Start date time does not precede end date time. Please re-enter.");
                    break;
                case 4:
                    Console.WriteLine("Invalid session! overlapping sessions. Please re-enter.");
                    break;                
                default:
                    break;
            }
            }
        }
    }
    public static void InputId()
    {        
        bool validInput = false;
        string?result="";
        while(!validInput)
        {
            Console.WriteLine("Please enter the ID of the session you would like to update.");
            result = Console.ReadLine();
            if (result != null || result!= "")
            {
                validInput = true;
            }
            validInput = int.TryParse(result, out updateId);
        }
    }
}