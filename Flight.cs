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
    public void RemoveFromDatabase(){
        string query = $"DELETE FROM Flights WHERE time = '{Time}' AND origin = '{Origin}' AND destination = '{Destination}' AND aircraft = '{Aircraft}' AND state = '{State}' AND gate = '{Gate}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public override string ToString()
    {
        return @$"Time: {Time} - "
            + @$"Origin: {Origin} - "
            + @$"Destination: {Destination} - "
            + @$"Aircraft: {Aircraft} - "
            + @$"State: {State} - "
            + @$"Gate: {Gate}" ;
    }
}
