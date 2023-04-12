using Microsoft.Data.Sqlite;

// Admin is geinherrit van User class.
class User{
    public int id {get; set; }
    public string First_Name {get; set; }

    public string Last_Name {get; set; }
    public string Email {get; set; }
    public string Password {get; set; }
    public bool has_Admin {get; set; }


    // Even een constructor om te testen.. Deze test helaas niet of de data wel goed is
    // daarom is het de bedoeling dat de static method "Register" gebruikt wordt.
    public User(string first_name, string last_name, string email, string password, bool has_admin = false)
    {
        First_Name = first_name;
        Last_Name = last_name;
        Email = email;
        Password = password;
        has_Admin = has_admin;
    }


    public static User Register()
    {
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine("Laten we elkaar leren kennen!");
        Console.WriteLine("Vul je details in.");

        string first_name = FirstNameSequence();
        string last_name = LastNameSequence();
        string email = EmailSequence();
        string password = PasswordSequence();

        User currentuser = new User(first_name, last_name, email, password);
        currentuser.AddToDatabase();
        
        Console.WriteLine($"Welkom in Rotterdam Airlines, {first_name} {last_name}!\n");
        Thread.Sleep(5000);

        return currentuser;
    }


    //Voegt toe nieuwe User toe aan de database..
    // datbase wrapper die de verbinding instand houdt.
    // last rowid, bij user inserrt en dan ID ophalen.
    private void AddToDatabase(){
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();

        string sql = "INSERT INTO users (first_name, last_name, email, password, has_admin) VALUES (@first_name, @last_name, @email, @password, @has_admin)";
        using  (SqliteCommand command = new SqliteCommand(sql, connection)) {
            command.Parameters.AddWithValue("@first_name", this.First_Name);
            command.Parameters.AddWithValue("@last_name", this.Last_Name);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@password", this.Password);
            command.Parameters.AddWithValue("@has_admin", this.has_Admin ? 1 : 0);
            command.ExecuteNonQuery();
        }
        
        connection.Close();
    }


    // Hieronder staat alles dat te maken heeft met register... 
    private static string FirstNameSequence()
    {
    string firstname;
    while(true)
        {
            Console.WriteLine("\nVul je voornaam in: ");
            firstname = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(firstname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.WriteLine("Je voornaam mag niet niks zijn.");
                continue;
            }
            if (firstname.Any(char.IsDigit) || ContainsSpecialChar(firstname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.WriteLine("Je voornaam mag alleen letters bevatten.");
                continue;
            }

            return firstname;
        } 
    }


    //last name
    private static string LastNameSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
    while (true)
    {
        Console.WriteLine("Vul je achternaam in: ");
        string lastname = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(lastname))
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine("Je achternaam mag niet leeg zijn.");
            continue;
        }

        else if (lastname.Any(char.IsDigit) || ContainsSpecialChar(lastname))
        {
            Console.Clear();
            Information.DisplayLogo();
            Console.WriteLine("Je achternaam mag alleen letters bevatten.");
            continue;
        }

        return lastname;
    }
    
    }


    private static string EmailSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        string email = string.Empty;
        while(!email.Contains("@") && !email.Contains("."))
        {
            Console.Write("\nVul je emailadres in: ");
            email = Console.ReadLine()!;

            if(!email.Contains("@")) {
                Console.Clear();
                Information.DisplayLogo();
                Console.WriteLine("Je emailadres moet ten minste een '@' bevatten.");
            }

            if(!email.Contains("."))
            { 
                Console.Clear();
                Information.DisplayLogo();
                Console.WriteLine("Je emailadres moet ten minste een '.' bevatten.");
            }
        }
        return email;
    }

    private static string PasswordSequence()
    {
        string password = string.Empty;
        string? confirmpassword = string.Empty;

        while(true)
        {
            Console.WriteLine(@"
Vul een wachtwoord in van 8 of meer tekens met:
    - Ten minste 1 numerieke waarde (0-9)
    - Ten minste 1 speciale teken
    ");
            Console.Write("Vul een wachtwoord in: ");
            password = Console.ReadLine()!;

            if(password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
            {
                Console.WriteLine("Wachtwoord voldoet aan de eisen!");
                Console.Write("Bevestig je wachtwoord: ");
                confirmpassword = Console.ReadLine();
                
                if(password != confirmpassword)
                {
                    Console.WriteLine("De wachtwoorden verschillen van elkaar, probeer het opnieuw.");
                }
                else
                {
                    Console.WriteLine("Wachtwoorden correct.");
                    break;
                }
            }

        }

        return password;
    }


    private static bool ContainsSpecialChar(string password) {
        foreach (char c in password) {
            if (!Char.IsLetterOrDigit(c)) {
                return true;
            }
        }
        return false;
    }

        private static bool ContainsDigit(string password) {
        foreach (char c in password) {
            if (Char.IsDigit(c)) {
                return true;
            }
        }
        return false;
    }

}