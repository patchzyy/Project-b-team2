using Microsoft.Data.Sqlite;

public class ExtraUser
{
    public readonly string FirstName;
    public readonly string LastName;
    public readonly int Age;
    public readonly User MasterUser;

    public readonly Seat Seat;

    public readonly Flight Flight;


    public ExtraUser(string firstName, string lastName, int age, User masteruser, Seat seat, Flight flight)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        MasterUser = masteruser;
        Seat = seat;
        Flight = flight;

    }


    public static void RemoveDatabase()
    {
        string query = "DROP TABLE ExtraUsers";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();
    }

    public void AddToDatabase()
    {
        // first find the booking id
        string query = $"SELECT bookingID FROM Bookings WHERE userEmail = '{MasterUser.Email}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        SqliteDataReader reader = DatabaseConnection.ExecuteReader();
        int bookingID = 0;
        while (reader.Read())
        {
            bookingID = reader.GetInt32(0);
        }
        connection.Close();
        // now add the extra user to the database
        query = $"INSERT INTO ExtraUsers (firstName, lastName, age, masterUserEmail, seat, bookingID) VALUES ('{FirstName}', '{LastName}', '{Age}', '{MasterUser.Email}' , '{Seat.SeatId}', '{bookingID}')";
        connection.Open();
        DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }

    public static ExtraUser AskForInformation(User user, Seat seat, Flight flight)
    {
        string firstName = User.FirstNameSequence(true, 0, 4);
        if (firstName is null)
        {
            return null;
        }
        string lastName = User.LastNameSequence(true, 1, 4);
        if (lastName is null)
        {
            return null;
        }
        DateOnly date_of_birth = User.DateOfBirthSequence(true, 2, 4);
        int age = DateOnly.FromDateTime(DateTime.Now).Year - date_of_birth.Year;
        string passportnumber = User.PassportSequence(true, 3, 4);
        ExtraUser Extrauser = new ExtraUser(firstName, lastName, age, user, seat, flight);
        Extrauser.AddToDatabase();
        return Extrauser;
    }

    public void RemoveFromDatabase()
    {
        string query = $"DELETE FROM ExtraUsers WHERE firstName = '{FirstName}' AND lastName = '{LastName}' AND age = '{Age}' AND masterUserEmail = '{MasterUser.Email}' AND seat = '{Seat.SeatId}'";
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();
        SqliteCommand DatabaseConnection = new(query, connection);
        DatabaseConnection.ExecuteNonQuery();
        connection.Close();

    }
}


