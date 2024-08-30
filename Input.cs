using System;
class Input
{
    public static int Menu()
    {
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

            return 9;
    }


    
}