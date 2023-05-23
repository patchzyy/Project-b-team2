using Microsoft.Data.Sqlite;
class Program
{

    public static void Main()
    {
        // DrawAirbus330UI.SelectAirbus330(new Airbus330(), 2);
    
        Information.DisplayLogo();
        Thread.Sleep(2000);
        Menu menu = new Menu(new[]{"Login","Register","More Information", "Fast"});
        menu.Run();



        

    }

    /*
    BELANGRIJK:
    Om code te besparen is het hetbeste als we hier de connectie aanmaken naar de database!
    via:
        connection = new SqliteConnection("Data Source=airline_data.db");
        connection.Open();

    Zo kunnen we de connection meegeven als parameter bij het gebruik van class methods!
    dank alsvast

    -Siebe
    
    */
    // 
}