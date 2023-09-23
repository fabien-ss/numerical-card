using Npgsql;
namespace Sante.Models.bdd;

public class Connection
{
    public static NpgsqlConnection GetConnection()
    {
        const int Port = 5432;
        const string Host = "localhost";
        const string User = "postgres";
        const string Database = "sante";
        const string Password = "fabien";
        string connString =
            String.Format(
                "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                Host,
                User,
                Database,
                Port,
                Password);
        NpgsqlConnection connection = new NpgsqlConnection(connString);
        //   connection.Open();
        return connection;
    }
}