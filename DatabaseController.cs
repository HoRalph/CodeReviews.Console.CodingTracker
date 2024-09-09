using System;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Globalization;
using System.ComponentModel;
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
    public static IEnumerable<session> ExecuteQuery(string sql, DynamicParameters parameters)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            return connection.Query<session>(sql, parameters);
        }   
    }
    public static IEnumerable<session> ExecuteQuery(string sql)
    {
        string?connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        using (var connection = new SqliteConnection(connectionString))
        {
            return connection.Query<session>(sql);
        }   
    }
    public static void CreateTable()
    {   
            var sql = @"CREATE TABLE IF NOT EXISTS CodingSessions (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartDateTime STRING,
            EndDateTime STRING,
            Duration STRING);";
            ExecuteNonQuery(sql);         
    }
    public static List<String[]> ViewTable()
    {
        var sql = "SELECT * FROM CodingSessions";
        List<string[]> rows = new List<string[]>();
        foreach (var session in ExecuteQuery(sql))
        {
            rows.Add([session.Id, session.StartDateTime, session.EndDateTime, session.Duration]);
        }
        return rows;
    }
    public static List<string> GetStartDates(int iD=0)
    {
        var sql = "SELECT StartDateTime FROM CodingSessions WHERE Id <> @iD";
        var parameters = new DynamicParameters();
        parameters.Add("@iD", iD);
        List<string> datesList = new List<string>();
        foreach (var session in ExecuteQuery(sql, parameters))
        {
            datesList.Add(session.StartDateTime);
        }
        return datesList;
    }
        public static List<string> GetEndDates(int iD  =0)
    {
        var sql = "SELECT EndDateTime FROM CodingSessions";
        var parameters = new DynamicParameters();
        parameters.Add("@iD",iD);
        List<string> datesList = new List<string>();
        foreach (var session in ExecuteQuery(sql, parameters))
        {
            datesList.Add(session.EndDateTime);
        }
        return datesList;
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
        var sql = @"UPDATE CodingSessions 
        SET StartDateTime = @StartDateTime, EndDateTime = @EndDateTime, Duration = @Duration 
        WHERE Id = @iD;";
        object[] parameters =  {new{StartDateTime, EndDateTime, Duration, iD}};
        ExecuteNonQuery(sql, parameters);
    }
    
    public static void DeleteRecord(int iD)
    {
        var sql = @"DELETE FROM CodingSessions 
        WHERE Id = @iD;";
        object[] parameters =  {new{iD}};
        ExecuteNonQuery(sql, parameters);
    }
    
    public static void DeleteTable()
    {
        var sql = @"DELETE FROM CodingSessions;";
        ExecuteNonQuery(sql);  
    }
}