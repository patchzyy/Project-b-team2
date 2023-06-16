using Microsoft.Data.Sqlite;
class Program
{

    public static void Main()
    {
        Console.ResetColor();
        Information.DisplayLogo();
        Thread.Sleep(2000);
        Menu menu = new Menu(new[] { "Login", "Registreren", "Meer Informatie" });
        menu.Run();
        //DrawBoeing737UI.SelectBoeing737(new Boeing737());
        //DrawBoeing787UI.SelectBoeing787(new Boeing787());
        // DrawAirbus330UI.SelectAirbus330(new Airbus330(), 2);



    }
}