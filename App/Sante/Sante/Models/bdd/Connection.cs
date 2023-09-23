using Npgsql;
namespace Sante.Models.bdd;

public class Connection
{
    public static NpgsqlConnection GetConnection()
    {
        int Port = 5432;
        string Host = "localhost";
        string User = "postgres";
        string Database = "sante";
        string Password = "fabien";
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