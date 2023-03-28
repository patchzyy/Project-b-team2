static class Menu
{
    private static List<string> optionList;

    public static void Run()
    {
        optionList = new List<string>{"Login Menu", "Dummy Option 1", "Dummy Option 2"};

        while (true)
        {
            Console.Clear();
            Console.WriteLine();

            int option = GetOption();

            switch (option)
            {
                case 0:
                    LoginMenu();
                    break;
                case 1:
                    DummyMethod1();
                    Console.ReadLine();
                    break;
                case 2:
                    DummyMethod2();
                    break;
            }
        }
    }

    private static void LoginMenu()
    {
        optionList = new List<string>{"Login", "Back to Main Menu"};

        while (true)
        {
            Console.Clear();
            Console.WriteLine();

            int option = GetOption();

            switch (option)
            {
                case 0:
                    Console.WriteLine("You selected Login");
                    Console.ReadLine();
                    break;
                case 1:
                    Menu.Run();
                    return;
            }
        }
    }

    private static int GetOption()
    {
        bool selected = false;
        ConsoleKeyInfo key;
        int option = 0;

        string color = "->  ";
        (int left, int top) = Console.GetCursorPosition();

        while (!selected)
        {
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{(option == i ? color : "    ")}{optionList[i]}");
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

    public static void DummyMethod1()
    {
        Console.Clear();
        Console.WriteLine("This is Dummy Method 1");
        optionList = new List<string>{"Main menu", "dummy 2"};
        int option = GetOption();
        if (option == 0)
        {
            Menu.Run();
        }
        else
        {
            DummyMethod2();
        }

        Console.ReadLine();
    }

    public static void DummyMethod2()
    {
        Console.Clear();
        Console.WriteLine("This is Dummy Method 2");
        optionList = new List<string>{"Main menu", "dummy 1"};
        int option = GetOption();
        if (option == 0)
        {
            Menu.Run();
        }
        else
        {
            DummyMethod1();
        }
    }
}
