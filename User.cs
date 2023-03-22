using Microsoft.Data.Sqlite;

/*
BELANGRIJK:
De User class heeft wel een ID, maar het probleem hiermee is dat omdat deze
aangemaakt wordt door de database die er niet 123 is. :(
Hierop moet nog iets gevonden worden.

Ook is dit een tijdelijke oplossing, er wordt nu niet gecheckt op leeftijd etc..
(zie trello)

*/


// Admin is geinherrit van User class.
class User{
    public int id {get; set; }
    public string Name {get; set; }
    public string Email {get; set; }
    public string Password {get; set; }
    public bool has_Admin {get; set; }


    // Even een constructor om te testen.. Deze test helaas niet of de data wel goed is
    // daarom is het de bedoeling dat de static method "Register" gebruikt wordt.
    public User(string name, string email, string password, bool has_admin = false){
        Name = name;
        Email = email;
        Password = password;
        has_Admin = has_admin;
    }


    public static void Register(string name, string email, string password, bool has_admin = false){

        if (!IsValidData(name, email, password))
        {
            throw new Exception("Invalid credentials have been provided. Please check the requirements");
        }
        else{
            new User(name, email, password);
        }
    }

    
    //Voegt toe nieuwe User toe aan de database..
    // datbase wrapper die de verbinding instand houdt.
    // last rowid, bij user inserrt en dan ID ophalen.
    private void AddToDatabase(SqliteConnection connection){
        string sql = "INSERT INTO users (name, email, password, has_admin) VALUES (@name, @email, @password, @has_admin)";

        using  (SqliteCommand command = new SqliteCommand(sql, connection)) {
            command.Parameters.AddWithValue("@name", this.Name);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@password", this.Password);
            command.Parameters.AddWithValue("@has_admin", this.has_Admin ? 1 : 0);

            command.ExecuteNonQuery();
        }

    }


    //Kijkt of de ingevoerde data wel voldoet aan wat simpele eisen.
    private static bool IsValidData(string name, string email, string password) {

        if (Char.IsUpper(name, 0) && email.Contains("@") && password.Length >= 8)
        {
            return true;
        }
        else return false;
    }


}