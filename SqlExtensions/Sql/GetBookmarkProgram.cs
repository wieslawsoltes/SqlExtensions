using System.Windows.Input;
using Microsoft.Data.Sqlite;

namespace SqlExtensions;

public static class GetBookmarkProgram
{
    public static ICommand RunCommand { get; } = new Command(Run);

    public static void Run(object sql)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = BookmarkProgram.DataSource;
        using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        var selectCommand = connection.CreateCommand();
        selectCommand.CommandText = (string)sql;

        using var reader = selectCommand.ExecuteReader();
        while (reader.Read())
        {
            BookmarkProgram.DebugPrintBookmark(reader);
        }
    }
}
