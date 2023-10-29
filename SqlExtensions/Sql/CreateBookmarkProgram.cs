using System.Windows.Input;
using Microsoft.Data.Sqlite;

namespace SqlExtensions;

public static class CreateBookmarkProgram
{
    public static ICommand RunCommand { get; } = new Command(Run);

    public static void Run(object sql)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder();
        connectionStringBuilder.DataSource = BookmarkProgram.DataSource;
        using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        connection.Open();
        using var transaction = connection.BeginTransaction();
        var insertCommand = connection.CreateCommand();
        insertCommand.CommandText = (string)sql;
        insertCommand.ExecuteNonQuery();
        transaction.Commit();
    }
}