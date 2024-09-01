using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using Dapper;


class DatabaseController
{
    public static void CreateTable()
    {   
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            var sql = @"CREATE TABLE IF NOT EXISTS CodingSessions (
            ID INTEGER PRIMARY KEY AUTOINCREMENT,
            STARTDATETIME STRING,
            ENDDATETIME STRING,
            DURATION STRING);";

            connection.Execute(sql);
        }   
    }
    
    public static void ViewTable()
    {
        
    }
    
    public static void InsertRecord(string Start, string End, String Duration)
    {

    }

    public static void UpdateRecord(int iD)
    {

    }
    
    public static void DeleteRecord(int iD)
    {
        
    }
    
    public static void DeleteTable()
    {
        
    }

    //create table if not exist
    //insert record
    //update record
    //delete record
    //delete table
}