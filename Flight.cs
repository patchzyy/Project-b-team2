using Microsoft.Data.Sqlite;
public class Flight
{
    public readonly string? Time, Origin, Destination, Aircraft, State, Gate;
    public Flight(string time, string origin, string destination, string aircraft, string state, string gate)
    {
        Time = time;
        Origin = origin;
        Destination = destination;
        Aircraft = aircraft;
        State = state;
        Gate = gate;
    }

    public void AddToDatabase()
    {
        string query = $"INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('{Time}', '{Origin}', '{Destination}', '{Aircraft}', '{State}', '{Gate}')";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }
}
