using Npgsql;

public class Connection
{
    public static NpgsqlConnection GetConnection()
    {
        const int port = 5432;
        const string host = "localhost";
        const string user = "postgres";
        const string database = "sante";
        const string password = "fabien";
        var connString =
            $"Server={host};Username={user};Database={database};Port={port};Password={password};SSLMode=Prefer";
        var connection = new NpgsqlConnection(connString);
        return connection;
    }
}