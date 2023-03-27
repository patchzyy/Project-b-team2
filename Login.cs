class Login : User
{
    public Login(string name, string email, string password, bool has_admin) : base(name, email, password, has_admin)
    {

    }

    public User LoggingIn(string email, string password)
    {
        // if CheckDatabase is true
        // create the designated User object
        // return User object
    }

    private bool CheckDatabase(string email, string password)
    {
        // return account found in database
    }
}