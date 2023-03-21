using Microsoft.Data.Sqlite;

class Register
{
    private SqliteConnection connection;

    public Register()
    {
        connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();
    }
}

