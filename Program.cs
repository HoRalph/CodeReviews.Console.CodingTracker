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
            switch(Input.Menu())
            {
                case 0:
                //exit program
                return;
                
                case 1:
                    break;
                
                case 2:
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