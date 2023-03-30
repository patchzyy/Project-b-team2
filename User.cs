using Microsoft.Data.Sqlite;

// Admin is geinherrit van User class.
class User{
    public int id {get; set; }
    public string Name {get; set; }
    public string Email {get; set; }
    public string Password {get; set; }
    public bool has_Admin {get; set; }


    // Even een constructor om te testen.. Deze test helaas niet of de data wel goed is
    // daarom is het de bedoeling dat de static method "Register" gebruikt wordt.
    public User(string name, string email, string password, bool has_admin = false)
    {
        Name = name;
        Email = email;
        Password = password;
        has_Admin = has_admin;
    }


    public static bool Register()
    {
        Console.Clear();
        Console.WriteLine("Laten we elkaar leren kennen!");
        Console.WriteLine("Vul je details in.");

        string fullname = FullNameSequence();
        string email = EmailSequence();
        string password = PasswordSequence();

        User currentuser = new User(fullname, email, password);
        currentuser.AddToDatabase();
        
        Console.WriteLine($"Welkom in Rotterdam Airlines, {fullname}!\n");
        Thread.Sleep(5000);

        return true;
    }


    //Voegt toe nieuwe User toe aan de database..
    // datbase wrapper die de verbinding instand houdt.
    // last rowid, bij user inserrt en dan ID ophalen.
    private void AddToDatabase(){
        SqliteConnection connection = new("Data Source=airline_data.db");
        connection.Open();

        string sql = "INSERT INTO users (name, email, password, has_admin) VALUES (@name, @email, @password, @has_admin)";
        using  (SqliteCommand command = new SqliteCommand(sql, connection)) {
            command.Parameters.AddWithValue("@name", this.Name);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@password", this.Password);
            command.Parameters.AddWithValue("@has_admin", this.has_Admin ? 1 : 0);
            command.ExecuteNonQuery();
        }
        
        connection.Close();
    }


    // Hieronder staat alles dat te maken heeft met register... 
    private static string FullNameSequence()
    {
    string firstname, lastname;

    //first name
    while(true)
    {
        Console.Write("\nVul je voornaam in: ");
        firstname = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(firstname))
        {
            Console.WriteLine("Je voornaam mag niet niks zijn.");
            continue;
        }
        // dit ga ik op terugkomen, want de isSymbol wilt niet helemaal goed mee werken.
        if (firstname.Any(char.IsDigit) || firstname.Any(char.IsSymbol) || firstname.Contains(" "))
        {
            Console.WriteLine("Je voornaam mag alleen letters bevatten.");
            continue;
        }

        break;
    } 

    //last name
    while (true)
    {
        Console.WriteLine("Vul je achternaam in: ");
        lastname = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(lastname))
        {
            Console.WriteLine("Je achternaam mag niet leeg zijn.");
            continue;
        }

        else if (lastname.Any(char.IsDigit))
        {
            Console.WriteLine("Je achternaam mag alleen letters bevatten.");
            continue;
        }

        break;
    }
    return $"{firstname} {lastname}";
    }

    private static string EmailSequence()
    {
        string email = string.Empty;
        while(!email.Contains("@") && !email.Contains("."))
        {
            Console.Write("\nVul je emailadres in: ");
            email = Console.ReadLine()!;

            if(!email.Contains("@")) Console.WriteLine("Je emailadres moet ten minste een '@' bevatten.");
            if(!email.Contains(".")) Console.WriteLine("Je emailadres moet ten minste een '.' bevatten.");
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