class Menu{
    Boolean selected = false;
    ConsoleKeyInfo key;
    int option = 1;
    

    public Menu(){

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welkom bij het main menu");
        Console.ResetColor();
        Console.WriteLine("gebruik pijltje omhoog en omlaag om door het menu te scrollen");
        string kleur = "--> \u001b[32m";
        (int left, int top) = Console.GetCursorPosition();
        while(selected == false){
        Console.Clear();
        Console.SetCursorPosition(left, top);
        Console.WriteLine(option);
        Console.WriteLine($"{(option == 0 ? kleur : "    ")}   Login\u001b[0m");
        Console.WriteLine($"{(option == 1 ? kleur : "    ")}   optie 2\u001b[0m");
        Console.WriteLine($"{(option == 2 ? kleur : "    ")}   optie 3\u001b[0m");
        Console.WriteLine($"{(option == 3 ? kleur : "    ")}   optie 4\u001b[0m");
        key = Console.ReadKey(true);

        switch(key.Key)
        {
            case ConsoleKey.DownArrow:
                option = (option + 1)%4;
                break;
            case ConsoleKey.UpArrow:
                option = (option - 1 +4)%4;
                break;
            case ConsoleKey.Enter:
                selected = true;
                break;
        }
        }
    }
}