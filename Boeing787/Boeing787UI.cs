public class DrawBoeing787UI
{
    public static void DrawBoeing787(Boeing787 plane)
    {
        Console.WriteLine("     _/                                                \\_");
        Console.WriteLine("    /                                                    \\");
        Console.WriteLine("   /                                                      \\");
        Console.WriteLine("  /                                                        \\");
        Console.WriteLine(" /                                                          \\");
        Console.WriteLine("/                                                            \\");
        Console.WriteLine("|                                                            |");
        Console.WriteLine("|                                                            |");
        int rowNr = 1;
        bool rowHasSeats = true;
        while (rowHasSeats)
        {
            if (rowNr == 4)
            {
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 7)
            {
                rowNr = 16;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 26)
            {
                rowNr = 27;
                Console.WriteLine("|                                                            |");
            }
            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            int rowSeatCount = 0;
            if (rowNr > 36)
            {
                Console.Write("                    ");
            }
            foreach (var seat in plane.Seats)
            {
                if (seat.SeatId.StartsWith(rowNr.ToString() + "-"))
                {
                    if (seat.SeatId.Length == 3)
                        Console.Write(" ");
                    if (rowNr > 16 && rowNr < 37)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("J"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr == 16)
                    {
                        if (seat.SeatId.EndsWith("J"))
                        {
                            Console.Write("                      ");
                        }
                    }

                    if (rowNr < 7)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("     ");
                        }
                        if (seat.SeatId.EndsWith("K"))
                        {
                            Console.Write("     ");
                        }
                    }
                    if (seat.IsReserved)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(seat.SeatId + "  ");
                    if (rowNr < 7)
                    {
                        Console.Write("  ");
                    }
                    rowHasSeats = true;
                    rowSeatCount++;
                }
            }
            if (rowNr > 36)
            {
                Console.Write("                    ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|" + $"  {rowNr}");

            rowNr++;
            if (rowNr == 39)
            {
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                Console.WriteLine("\\                                                            /");
                Console.WriteLine(" \\                                                          /");
                Console.WriteLine("  \\_                                                      _/");
                Console.WriteLine("    \\                                                    /");
                Console.WriteLine("     \\_                                                _/");
                return;
            }
        }
    }
}