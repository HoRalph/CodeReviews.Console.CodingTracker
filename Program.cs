// See https://aka.ms/new-console-template for more information
using System;
using System.Configuration;
using System.Collections.Specialized;
namespace Program;

class Program
{
 
    public static void Main(String[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(ConfigurationManager.AppSettings.Get("key1"));
        Input.Menu();

    }

}