class Menu{
    Boolean selected = false;
    ConsoleKeyInfo key;
    public Menu(){

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welkom bij het main menu");
        Console.ResetColor();
        Console.WriteLine("gebruik pijltje omhoog en omlaag om door het menu te scrollen");

        while(selected == false){

        
        Console.WriteLine("    \nLogin");
        Console.WriteLine("--> \u001b[32moptie 2\u001b[0m");
        Console.WriteLine("   optie 3");
        Console.WriteLine("   optie 4");
        var key = Console.ReadKey(true);
        }
    }
}