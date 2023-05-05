using Microsoft.Data.Sqlite;
using System.Globalization;


// Columns van de Flights table inde database op volgorde

// id: Het unieke id van de vlucht [int]
// duration: De duur van de vlucht in minuten [int]
// date: De datum van de vlucht [string]
// time: Tijd wanneer het vliegtuig aankomt/vertrekt	[string]
// origin: Plek vanaf waar het vliegtuig vertrekt		[string]
// destination: Plek waar het vliegtuig naartoe gaat	[string]
// aircraft: Het type vliegtuig (Boeing 737, Airbus 330 of Boeing 787)	[string]
// gate: De plek waar de passangiers moet in/uitstappen	[string]

// Code voor de connectie naar de database
// SqliteConnection connection = new("Data Source=ailine_data.db");
// connection.Open();

public static class Flights
{
    public static void SetDailyFlightSchedule()
    {
        SqliteConnection connection = new("Data Source=airline_data.db");
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

    public static void CheckFlights()
    {
        Thread.Sleep(1000);
        Information.DisplayLogo();
        Flights.DisplayArrivingFlights();
        Console.WriteLine("");
        Flights.DisplayDepartingFlights();
        Console.WriteLine("\n\nDruk op enter om terug te gaan.");
        Console.ReadLine();
    }

    public static void DisplayDepartingFlights()
    {
        List<Flight> departingFlights = GetDepartingFlights();
        Console.WriteLine("Vertrek\n");
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4}", "Tijd", "Bestemming", "Toestel", "Status", "Gate");
        Console.WriteLine("-------------------------------------------------------------");
        foreach (Flight flight in departingFlights)
        {
            string state;
            string dateString = flight.Time;
            DateTime currentTime = DateTime.Now;
            DateTime time = DateTime.ParseExact(dateString, "HH:mm", CultureInfo.InvariantCulture);
            TimeSpan timeDifference = time - currentTime;
            if (currentTime > time)
            {
                state = "Vertrokken";
            }
            else if (timeDifference.TotalMinutes >= 1 && timeDifference.TotalMinutes <= 30)
            {
                state = "Boarding";
            }
            else
            {
                state = "Inactief";
            }
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4}", flight.Time, flight.Destination, flight.Aircraft, state, flight.Gate);
        }
    }

    public static void DisplayArrivingFlights()
    {
        List<Flight> arrivingFlights = GetArrivingFlights();
        Console.WriteLine("Aankomst\n");
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4}", "Tijd", "Afkomst", "Toestel", "Status", "Gate");
        Console.WriteLine("-------------------------------------------------------------");
        foreach (Flight flight in arrivingFlights)
        {
            string state;
            string dateString = flight.Time;
            DateTime currentTime = DateTime.Now;
            DateTime time = DateTime.ParseExact(dateString, "HH:mm", CultureInfo.InvariantCulture);
            TimeSpan timeDifference = time - currentTime;
            if (currentTime > time)
            {
                state = "Geland";
            }
            else if (timeDifference.TotalMinutes >= 1 && timeDifference.TotalMinutes <= 120)
            {
                state = "Onderweg";
            }
            else
            {
                state = "Inactief";
            }

            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4}", flight.Time, flight.Origin, flight.Aircraft, state, flight.Gate);
            Console.ResetColor();
        }
    }

    public static List<Flight> GetDepartingFlights()
    {
        List<Flight> departingFlights = new();
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();

        SqliteCommand command = new SqliteCommand("SELECT * FROM Flights WHERE origin = 'Rotterdam'", connection);
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            departingFlights.Add(new Flight(reader.GetInt16(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
        }

        return departingFlights.OrderBy(f => f.Time).ToList();
    }

    public static List<Flight> GetArrivingFlights()
    {
        List<Flight> arrivingFlights = new();
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();

        SqliteCommand command = new SqliteCommand("SELECT * FROM Flights WHERE destination = 'Rotterdam'", connection);
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            arrivingFlights.Add(new Flight(reader.GetInt16(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
        }

        return arrivingFlights.OrderBy(f => f.Time).ToList();
    }

}