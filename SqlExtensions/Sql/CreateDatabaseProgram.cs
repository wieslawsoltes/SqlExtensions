using System.Windows.Input;
using Microsoft.Data.Sqlite;

namespace SqlExtensions;

public static class CreateDatabaseProgram
{
    public static ICommand RunCommand { get; } = new Command(Run);

    public static void Run(object? sql)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = BookmarkProgram.DataSource;
        using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        var createTableCommand = connection.CreateCommand();
        createTableCommand.CommandText = (string)sql;
        createTableCommand.ExecuteNonQuery();
    }
}
