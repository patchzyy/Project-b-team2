class Menu
{
    List<string> Option_Text;

    public Menu(List<string> option_text)
    {
        Option_Text = option_text;
    }

    public int ShowMenu()
    {
        bool selected = false;
        ConsoleKeyInfo key;
        int option = 0;

        Console.WriteLine("Use up and down arrows to scroll through the menu");
        string kleur = "-->  \u001b[32m";
        (int left, int top) = Console.GetCursorPosition();

        while (!selected)
 {
            Console.Clear();
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < Option_Text.Count; i++)
            {
                Console.WriteLine($"{(option == i ? kleur : "    ")}{Option_Text[i]}\u001b[0m");
            }

            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option + 1) % Option_Text.Count;
                    break;
                case ConsoleKey.UpArrow:
                    option = (option - 1 + Option_Text.Count) % Option_Text.Count;
                    break;
                case ConsoleKey.Enter:
                    selected = true;
                    break;
            }
        }

        return option;
    }
    public int mainmenu(Boolean loggedin){
        if (loggedin){
        List<string> mainMenuItems = new List<string> { "item 1", "Item 2", "Item 3" , "issam"};
        Menu mainMenu = new Menu(mainMenuItems);
        int selectedOption = mainMenu.ShowMenu();
        return selectedOption;
        }
        else{
        List<string> mainMenuItems = new List<string> { "Login", "Register", "Item 3" , "issam"};
        Menu mainMenu = new Menu(mainMenuItems);
        int selectedOption = mainMenu.ShowMenu();
        return selectedOption;
        }
    }
}


// class Menu{
//     Boolean selected = false;
//     ConsoleKeyInfo key;
//     int option = 1;
    

//     public Menu(){

//         Console.ForegroundColor = ConsoleColor.Cyan;
//         Console.WriteLine("Welkom bij het main menu");
//         Console.ResetColor();
//         Console.WriteLine("gebruik pijltje omhoog en omlaag om door het menu te scrollen");
//         string kleur = "-->  \u001b[32m";
//         (int left, int top) = Console.GetCursorPosition();
//         while(selected == false){
//         Console.Clear();
//         Console.SetCursorPosition(left, top);
//         Console.WriteLine($"{(option == 0 ? kleur : "    ")}   Login\u001b[0m");
//         Console.WriteLine($"{(option == 1 ? kleur : "    ")}   optie 2\u001b[0m");
//         Console.WriteLine($"{(option == 2 ? kleur : "    ")}   optie 3\u001b[0m");
//         Console.WriteLine($"{(option == 3 ? kleur : "    ")}   optie 4\u001b[0m");
//         key = Console.ReadKey(true);

//         switch(key.Key)
//         {
//             case ConsoleKey.DownArrow:
//                 option = (option + 1)%4;
//                 break;
//             case ConsoleKey.UpArrow:
//                 option = (option - 1 +4)%4;
//                 break;
//             case ConsoleKey.Enter:
//                 selected = true;
//                 break;
//         }
//         }
//     }
// }