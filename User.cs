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
        
        Console.Clear();
        Information.DisplayLogo();
        Console.WriteLine($"\n\nWelkom in Rotterdam Airlines, {first_name} {last_name}!\n");
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
    // TODO:    -checken op hoofdletter
    //          -password zo doen dat ipv chars bolletjes komen ter bescherming?
    private static string FirstNameSequence()
    {
        string firstname;
        while(true)
            {
                Console.Write("\nVul je voornaam in: ");
                firstname = CheckFirstName();
                // firstname = Console.ReadLine()!;


                if (string.IsNullOrWhiteSpace(firstname))
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je voornaam mag niet niks zijn.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (firstname.Any(char.IsDigit) || ContainsSpecialChar(firstname))
                {
                    Console.Clear();
                    Information.DisplayLogo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je voornaam mag alleen letters bevatten.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return firstname;
            }
    }

    private static bool IsValidFirstName(string firstname)
    {
        if (string.IsNullOrWhiteSpace(firstname))
        {
            
            return false;
        }
        if (firstname.Any(char.IsDigit) || ContainsSpecialChar(firstname))
        {
            return false;
        }
        return true;
    }

    private static string CheckFirstName()
    {
        string? firstname = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (firstname.Length > 0) {
                    firstname = firstname.Remove(firstname.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(20, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                firstname += c;
            }

            if (IsValidFirstName(firstname)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(firstname);
        }
        Console.WriteLine();
        Console.ResetColor();
        return firstname;
    }


    //last name
    private static string LastNameSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        while (true)
        {
            Console.Write("Vul je achternaam in: ");
            string lastname = CheckLastName();

            if (string.IsNullOrWhiteSpace(lastname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je achternaam mag niet leeg zijn.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            else if (lastname.Any(char.IsDigit) || ContainsSpecialChar(lastname))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je achternaam mag alleen letters bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            return lastname;
        }
    
    }

    private static bool IsValidLastName(string lastname)
    {
        if (string.IsNullOrWhiteSpace(lastname))
        {
            return false;
        }
        if (lastname.Any(char.IsDigit) || ContainsSpecialChar(lastname))
        {
            return false;
        }
        return true;
    }

    private static string CheckLastName()
    {
        string? lastname = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (lastname.Length > 0) {
                    lastname = lastname.Remove(lastname.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(22, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                lastname += c;
            }

            if (IsValidFirstName(lastname)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(lastname);
        }
        Console.WriteLine();
        Console.ResetColor();
        return lastname;
    }

    private static string EmailSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        string email = "";
        while(true)
        {
            Console.Write("\nVul je emailadres in: ");
            email = CheckEmail();

            if(!email.Contains("@"))
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je emailadres moet ten minste een '@' bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }

            if(!email.Contains("."))
            { 
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je emailadres moet ten minste een '.' bevatten.");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            if (email.Length < 8)
            {
                Console.Clear();
                Information.DisplayLogo();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Je email mag niet korter dan 8 tekens zijn.\n");
                Console.ForegroundColor = ConsoleColor.White;
                continue;
            }
            break;
        }
        return email;
    }

    private static bool IsValidEmail(string email)
    {
        if (email.Contains("@") && email.Contains(".") && email.Length > 8)
        {
            return true;
        }
        return false;
    }

    private static string CheckEmail()
    {
        string? email = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (email.Length > 0) {
                    email = email.Remove(email.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(22, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                email += c;
            }

            if (IsValidEmail(email)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(email);
        }
        Console.WriteLine();
        Console.ResetColor();
        return email;
    }

    private static string PasswordSequence()
    {
        Console.Clear();
        Information.DisplayLogo();
        
        string password = "";
        string? confirmpassword = "";

        while(true)
        {
            Console.WriteLine(@"
Vul een wachtwoord in van 8 of meer tekens met:
    - Ten minste 1 numerieke waarde (0-9)
    - Ten minste 1 speciale teken
    ");
            Console.Write("Vul een wachtwoord in: ");
            password = CheckPassword();

            if(password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
            {
                Console.WriteLine("Wachtwoord voldoet aan de eisen!\n");
                while (true)
                {
                    Console.Write("Bevestig je wachtwoord: ");
                    confirmpassword = Console.ReadLine();
                    
                    // gebruiker optie geven nieuwe ww of opnieuw duplicate proberen
                    if(password != confirmpassword)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("De wachtwoorden verschillen van elkaar, probeer het opnieuw.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("Je wachtwoord is correct. Een moment alstublieft.");
                        Thread.Sleep(750);
                        break;
                    }
                }
            }
            // hier missen we nog specifiek laten zien waar user verkeerde input geeft

        }

        return password;
    }

    private static bool IsValidPassword(string password)
    {
        if (password.Length > 8 && ContainsSpecialChar(password) && ContainsDigit(password))
        {
            return true;
        }
        return false;
    }

    private static string CheckPassword()
    {
        string? password = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0) {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(23, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                password += c;
            }

            if (IsValidPassword(password)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(password);
        }
        Console.WriteLine();
        Console.ResetColor();
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