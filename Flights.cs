using Microsoft.Data.Sqlite;

// Columns van de Flights table inde database op volgorde

// time: Tijd wanneer het vliegtuig aankomt/vertrekt	[int]
// origin: Plek vanaf waar het vliegtuig vertrekt		[string]
// destination: Plek waar het vliegtuig naartoe gaat	[string]
// aircraft: Het type vliegtuig (Boeing 737, Airbus 330 of Boeing 787)	[string]
// state: De status van het vliegtuig (boarding, geland, inactief of vertrokken)	[string]
// gate: De plek waar de passangiers moet in/uitstappen	[string]

// Code voor de connectie naar de database
// SqliteConnection connection = new("Data Source=ailine_data.db");
// connection.Open();

public static class Flights
{
    public static void SetDailyFlightSchedule()
    {
        SqliteConnection connection = new("Data Source=ailine_data.db");
        connection.Open();

        List<string> sqlQueries = new List<string>()
        {
            "INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('07:00', 'Rotterdam', 'Londen', 'Airbus 330', 'Inactief', 'G6')",
            "INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('20:00', 'Rotterdam', 'Milaan', 'Boeing 737', 'Inactief', 'C3')",
            "INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('08:00', 'Berlijn', 'Rotterdam', 'Airbus 330', 'Inactief', 'E5')",
            "INSERT INTO Flights (time, origin, destination, aircraft, state, gate) VALUES ('08:00', 'Budapest', 'Rotterdam', 'Boeing 787', 'Inactief', 'E5')",
        };

        foreach (string sqlQuery in sqlQueries)
        {
            SqliteCommand command = new SqliteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
        }
        connection.Close();
    }

    public static void DisplayDepartingFlights()
    {
        List<Flight> departingFlights = GetDepartingFlights();
        Console.WriteLine("Vertrekken\n");
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4}", "Tijd", "Bestemming", "Toestel", "Status", "Gate");
        Console.WriteLine("-------------------------------------------------------------");
        foreach (Flight flight in departingFlights)
        {
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4}", flight.Time, flight.Destination, flight.Aircraft, flight.State, flight.Gate);
        }
    }

    public static void DisplayArrivingFlights()
    {
        List<Flight> arrivingFlights = GetArrivingFlights();
        Console.WriteLine("Aankomsten\n");
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4}", "Tijd", "Afkomst", "Toestel", "Status", "Gate");
        Console.WriteLine("-------------------------------------------------------------");
        foreach (Flight flight in arrivingFlights)
        {
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4}", flight.Time, flight.Origin, flight.Aircraft, flight.State, flight.Gate);
        }
    }

    private static List<Flight> GetDepartingFlights()
    {
        List<Flight> departingFlights = new();
        SqliteConnection connection = new("Data Source=ailine_data.db");
        connection.Open();

        SqliteCommand command = new SqliteCommand("SELECT * FROM Flights WHERE origin = 'Rotterdam'", connection);
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            departingFlights.Add(new Flight(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
        }

        return departingFlights;
    }

    private static List<Flight> GetArrivingFlights()
    {
        List<Flight> arrivingFlights = new();
        SqliteConnection connection = new("Data Source=ailine_data.db");
        connection.Open();

        SqliteCommand command = new SqliteCommand("SELECT * FROM Flights WHERE destination = 'Rotterdam'", connection);
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            arrivingFlights.Add(new Flight(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
        }

        return arrivingFlights;
    } 

}