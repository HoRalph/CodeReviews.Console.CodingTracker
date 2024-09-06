using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.VisualBasic;
public class session
{
    public string Id {get; set;}
    public string StartDateTime {get; set;}
    public string EndDateTime {get; set;}
    public string Duration {get; set;}
}
class DatabaseController
{
    public static void ExecuteNonQuery(string sql, object[] parameters)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Execute(sql, parameters);
        }   
    }
        public static void ExecuteNonQuery(string sql)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Execute(sql);
        }   
    }
    /*public static object ExecuteQuery(string sql, object[] parameters)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            return connection.Query<session>(sql, parameters);
        }   
    }
    public static Collection ExecuteQuery(string sql)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            return connection.Query<session>(sql);
        }   
    }*/
    public static void CreateTable()
    {   
            var sql = @"CREATE TABLE IF NOT EXISTS CodingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartDateTime STRING,
            EndDateTime STRING,
            Duration STRING);";
            ExecuteNonQuery(sql);         
    }
    public static void ViewTable()
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        var sql = @"SELECT * FROM CodingSessions";
        using (var connection = new SqliteConnection(connectionString))
        {
        var sessions = connection.Query<session>(sql);
        
        foreach (var session in sessions)
        {
            Console.WriteLine($"{session.Id}      {session.StartDateTime}     {session.EndDateTime}     {session.Duration}");
        }
        }
    }

    public static void InsertRecord(string StartDateTime, string EndDateTime, string Duration)
    {
        var sql = @"INSERT INTO CodingSessions 
        (StartDateTime, EndDateTime, Duration) 
        VALUES (@StartDateTime, @EndDateTime, @Duration);";
        object[] parameters =  {new{StartDateTime, EndDateTime, Duration}};
        ExecuteNonQuery(sql, parameters);
    }

    public static void UpdateRecord(int iD, string StartDateTime, string EndDateTime, string Duration)
    {
        var sql = @"UPDATE CodingSesions 
        SET StartDateTime = @StartDateTime, EndDateTime = @EndDateTime, Duration = @Duration 
        WHERE Id = @iD;";
        object[] parameters =  {new{StartDateTime, EndDateTime, Duration, iD}};
        ExecuteNonQuery(sql, parameters);
    }
    
    public static void DeleteRecord(int iD)
    {
        var sql = @"DELETE FROM CodingSesions 
        WHERE Id = iD;";
        object[] parameters =  {new{iD}};
        ExecuteNonQuery(sql, parameters);
    }
    
    public static void DeleteTable()
    {
        var sql = @"DELETE FROM CodingSesions;";
        ExecuteNonQuery(sql);  
    }
}