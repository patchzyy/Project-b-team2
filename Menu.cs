class Menu
{
    public static int ShowMenu(List<string> OptionList)
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

            for (int i = 0; i < OptionList.Count; i++)
            {
                Console.WriteLine($"{(option == i ? color : "    ")}{OptionList[i]}\u001b[0m");
            }

            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option + 1) % OptionList.Count;
                    break;
                case ConsoleKey.UpArrow:
                    option = (option - 1 + OptionList.Count) % OptionList.Count;
                    break;
                case ConsoleKey.Enter:
                    selected = true;
                    break;
            }
        }

        return option;
    }

}
