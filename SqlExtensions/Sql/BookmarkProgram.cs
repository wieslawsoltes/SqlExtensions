using System;
using Microsoft.Data.Sqlite;

namespace SqlExtensions;

public static class BookmarkProgram
{
    public static string DataSource = "./BookmarksDB.sqlite";

    public static void DebugPrintBookmark(SqliteDataReader reader)
    {
        Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, URL: {reader.GetString(2)}");
    }
}
