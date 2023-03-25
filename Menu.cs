class Menu
{
    private List<string> optionList;
    
    public Menu(List<string> options)
    {
        this.optionList = options;
    }
    
    public int ShowMenu()
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
// returned de string inplaats van de index
    public string ShowMenu_ReturnString()
    {
        int option = ShowMenu();
        return optionList[option];
    }
// voegt een optie toe aan de lijst 
    public void AddOption(string option)
    {
        optionList.Add(option);
    }
// verwijderd een optie uit de lijst
    public void RemoveOption(int index)
    {
        optionList.RemoveAt(index);
    }
// returned de lengte van de lijst
    public int GetOptionCount()
    {
        return optionList.Count;
    }
}

// TODO:
 // print het menu maar ook nog met een header, dus text boven het menu
/// handig voor bijvoorbeeld het tonen van de logo
//     public int ShowMenuWithHeader(string header)
//     {
//         Console.WriteLine(header);
//         Console.WriteLine();

//         return ShowMenu();
//     }
// }
