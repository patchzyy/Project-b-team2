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
        Console.WriteLine("Let's get to know each other!");
        Console.WriteLine("Please specify your details.");

        string fullname = FullNameSequence();
        string email = EmailSequence();
        string password = PasswordSequence();

        User currentuser = new User(fullname, email, password);
        currentuser.AddToDatabase();
        
        Console.WriteLine($"Welcome to Rotterdam Airlines! {fullname}\n");
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
        string fullname = string.Empty;
        while(!fullname.Contains(" ") && (fullname.Length < 6))
        {
            Console.Write("\nPlease enter your full name: ");
            fullname = Console.ReadLine()!;

            if(!fullname.Contains(" ")) Console.WriteLine("Your name does not contain a space indicating it is not your full name.");
            if(fullname.Length < 6) Console.WriteLine("Your name is too short to be seen as a valid full name.");
        }
        return fullname;
    }

    private static string EmailSequence()
    {
        string email = string.Empty;
        while(!email.Contains("@") && !email.Contains("."))
        {
            Console.Write("\nPlease enter your email adress: ");
            email = Console.ReadLine()!;

            if(!email.Contains("@")) Console.WriteLine("Your email does not seem to contain a @ making it invalid.");
            if(!email.Contains(".")) Console.WriteLine("Your email does not contain a . indicating it is an invalid email adress.");
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
Please enter a password of 8 or more characters that contains:
    -A digit (0-9)
    -A special character
    ");
            Console.Write("Enter a password: ");
            password = Console.ReadLine()!;

            if(password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
            {
                Console.WriteLine("Password meets criteria!");
                Console.Write("Confirm password: ");
                confirmpassword = Console.ReadLine();
                
                if(password != confirmpassword)
                {
                    Console.WriteLine("Passwords do not match, please try again.");
                }
                else
                {
                    Console.WriteLine("Passwords accepted!");
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