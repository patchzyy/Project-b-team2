public static class Input
{
    public delegate bool ValidationDelegate(string input);
    public static string? GetInput(ValidationDelegate validate, int cursorPosition)
    {
        string? output = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return null;
            }

            if (c == '\r') { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (output.Length > 0) {
                    output = output.Remove(output.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(cursorPosition, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                output += c;
            }

            if (validate(output)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(output);
        }
        Console.WriteLine();
        Console.ResetColor();
        return output;
    }

    public static string? GetPasswordInput(ValidationDelegate validate, int cursorPosition)
    {
        string? output = "";
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char c = keyInfo.KeyChar;

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return null;
            }

            if (c == '\r')
            { // user has pressed the enter key
                Console.WriteLine(); // move to the next line
                break;
            }
            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (output.Length > 0)
                {
                    output = output.Remove(output.Length - 1);
                    Console.Write("\b \b"); // erase the character from the console
                }
            }
            Console.SetCursorPosition(12, Console.CursorTop);
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                output += c;
            }

            if (validate(output)) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            foreach (char letter in output)
            {
                Console.Write("*");
            }
        }
        return output;
    }
}