class Menu
{
    public static int ShowMenu(List<string> optionList)
    {
        bool selected = false;
        ConsoleKeyInfo key;
        int option = 0;

        string color = "->  \u001b[32m";
        (int left, int top) = Console.GetCursorPosition();

        while (!selected)
 {
            Console.Clear();
            Console.WriteLine("Use up and down arrows to scroll through the menu");
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{(option == i ? color : "    ")}{optionList[i]}\u001b[0m");
            }

            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option + 1) % optionList.Count;
                    break;
                case ConsoleKey.UpArrow:
                    option = (option - 1 + optionList.Count) % optionList.Count;
                    break;
                case ConsoleKey.Enter:
                    selected = true;
                    break;
            }
        }

        return option;
    }
    // dit returned de string ipv de index. dus dit zou "login" returnen ipv 0
    public static string ShowMenu_ReturnString(List<string> optionlist){
        int option = ShowMenu(optionlist);
        return optionlist[option];
    }

}
