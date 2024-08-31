using System;
using System.Runtime.InteropServices.Marshalling;
class Input
{
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
}