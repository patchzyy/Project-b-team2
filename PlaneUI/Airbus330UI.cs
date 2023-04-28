public class DrawAirbus330UI
{
    public static void DrawAirbus330(Airbus330 plane)
    {
        Console.WriteLine("|                                                            |");
        Console.WriteLine("|                                                            |");
        int rowNr = 1;
        bool rowHasSeats = true;
        while (rowHasSeats)
        {
            if (rowNr == 3)
            {
                rowNr = 4;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 11)
            {
                rowNr = 14;
                Console.WriteLine("|                                                            |");
            }
            if (rowNr == 34)
            {
                rowNr = 36;
                Console.WriteLine("|                                                            |");
            }

            rowHasSeats = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|  ");
            if (rowNr > 43 && rowNr < 50)
            {
                Console.Write("    ");
            }
            if (rowNr > 0 && rowNr < 3)
            {
                Console.Write("     ");
            }
            if (rowNr > 7 && rowNr < 11)
            {
                Console.Write("                    ");
            }
            if (rowNr == 33)
            {
                Console.Write("                    ");
            }
            if (rowNr == 50)
            {
                Console.Write("                    ");
            }

            int rowSeatCount = 0;

            foreach (var seat in plane.Seats)
            {
                if (seat.SeatId.StartsWith(rowNr.ToString() + "-"))
                {
                    if (seat.SeatId.Length == 3)
                        Console.Write(" ");
                    if (rowNr < 3)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("      ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("      ");
                        }
                    }
                    if (rowNr == 4)
                    {
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("                      ");
                        }
                    }
                    if (rowNr > 4 && rowNr < 8)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 13 && rowNr < 33)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 35 && rowNr < 44)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("  ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("  ");
                        }
                    }
                    if (rowNr > 43 && rowNr < 50)
                    {
                        if (seat.SeatId.EndsWith("D"))
                        {
                            Console.Write("    ");
                        }
                        if (seat.SeatId.EndsWith("H"))
                        {
                            Console.Write("    ");
                        }
                    }
                    if (seat.IsReserved)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(seat.SeatId + "  ");
                    rowHasSeats = true;
                    rowSeatCount++;
                }
            }
            if (rowNr > 7 && rowNr < 11)
            {
                Console.Write("                    ");
            }
            if (rowNr == 33)
            {
                Console.Write("                    ");
            }
            if (rowNr == 50)
            {
                Console.Write("                    ");
            }
            if (rowNr > 43 && rowNr < 50)
            {
                Console.Write("    ");
            }
            if (rowNr > 0 && rowNr < 3)
            {
                Console.Write("     ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|" + $"  {rowNr}");

            rowNr++;
            if (rowNr == 51)
            {
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                return;
            }
        }
    }
}