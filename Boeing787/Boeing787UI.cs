public class DrawBoeing787UI
{
    public static void DrawBoeing787(Boeing787 plane, Seat currentSeat)
    {
        string[] NederlandsBool = new string[2] { "Nee", "Ja" };
        Console.WriteLine("        /                                            \\");
        Console.WriteLine("       /                                              \\");
        Console.Write("     _/                                                \\_");
        Console.Write("                        Economy Plus stoelen staan");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write(" Donkerblauw ");
        Console.ResetColor();
        Console.Write("aangegeven. \n");
        Console.Write("    /                                                    \\");
        Console.Write("                       Business Class stoelen staan");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(" geel ");
        Console.ResetColor();
        Console.Write("aangegeven. \n");
        Console.Write("   /                                                      \\");
        Console.Write("                      Standaard stoelen zijn Wit. \n");
        Console.WriteLine("  /                                                        \\");
        Console.Write(" /                                                          \\");
        Console.Write("                    Stoelen die gereserveerd zijn staan ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("rood");
        Console.ResetColor();
        Console.Write(" aangegeven. \n");
        Console.Write("/                                                            \\");
        Console.Write("                   De stoel die U aan het bekijken bent staat ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("Blauw");
        Console.ResetColor();
        Console.Write(" aangegeven. \n");
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
                        Console.BackgroundColor = ConsoleColor.Red;

                    if (seat.IsBusinessClass)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                    if (seat.IsEconomyPlus)
                        Console.ForegroundColor = ConsoleColor.DarkBlue;

                    if (seat == currentSeat)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.Write(seat.SeatId);
                    Console.ResetColor();
                    Console.Write("  ");
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
            if (rowNr == 22)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   Huidige stoel: " + currentSeat.SeatId);
            }
            if (rowNr == 23)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   Prijs: " + currentSeat.SeatPrice());
            }
            if (rowNr == 24)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   EconomyPlus: " + NederlandsBool[Convert.ToInt32(currentSeat.IsEconomyPlus)]);
            }
            if (rowNr == 25)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   BusinessClass: " + NederlandsBool[Convert.ToInt32(currentSeat.IsBusinessClass)]);
            }
            if (rowNr != 22 && rowNr != 23 && rowNr != 24 && rowNr != 25)
            {
                Console.WriteLine("|" + $"  {rowNr}");
            }

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

    public static string? SelectBoeing787(Boeing787 plane)
    {
        var hasSelection = false;
        var seatIndex = 0;
        while (!hasSelection)
        {
            Console.Clear();
            DrawBoeing787(plane, plane.Seats[seatIndex]);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                if (!plane.Seats[seatIndex].IsReserved)
                    hasSelection = true;
            }
            if (key.Key == ConsoleKey.Escape)
                return null;
            if ((key.Key == ConsoleKey.LeftArrow) && (seatIndex > 0))
                seatIndex--;
            if ((key.Key == ConsoleKey.RightArrow) && (seatIndex < (plane.Seats.Count - 1)))
                seatIndex++;
            if ((key.Key == ConsoleKey.UpArrow) && (seatIndex > 5))
            {
                //row 38
                if (seatIndex == plane.Seats.Count - 1 || seatIndex == plane.Seats.Count - 2 || seatIndex == plane.Seats.Count - 3)
                {
                    seatIndex -= 3;
                }
                //row 37
                else if (seatIndex == plane.Seats.Count - 4 || seatIndex == plane.Seats.Count - 5 || seatIndex == plane.Seats.Count - 6)
                {
                    seatIndex -= 6;
                }
                //row 36 - 18
                else if (seatIndex < plane.Seats.Count - 6 && seatIndex >= 50)
                {
                    seatIndex -= 9;
                }
                //row 17
                else if (seatIndex == 45 || seatIndex == 46)
                {
                    seatIndex = 38;
                }
                else if (seatIndex == 47)
                {
                    seatIndex = 39;
                }
                else if (seatIndex == 42 || seatIndex == 43 || seatIndex == 44)
                {
                    seatIndex -= 6;
                }
                else if (seatIndex == 48 || seatIndex == 49 || seatIndex == 50)
                {
                    seatIndex -= 9;
                }
                //row 1 - 16
                else if (seatIndex < 42 && seatIndex > 5)
                {
                    seatIndex -= 6;
                }
            }
            if ((key.Key == ConsoleKey.DownArrow) && (seatIndex < (plane.Seats.Count - 3)))
            {
                //row 1-5
                if (seatIndex >= 0 && seatIndex <= 29)
                {
                    seatIndex += 6;
                }
                //row 6
                else if (seatIndex == 30)
                {
                    seatIndex = 36;
                }
                else if (seatIndex == 31)
                {
                    seatIndex = 37;
                }
                else if (seatIndex == 32)
                {
                    seatIndex = 38;
                }
                else if (seatIndex == 33)
                {
                    seatIndex = 39;
                }
                else if (seatIndex == 34)
                {
                    seatIndex = 40;
                }
                else if (seatIndex == 35)
                {
                    seatIndex = 41;
                }
                //row 16
                else if (seatIndex > 35 && seatIndex < 39)
                {
                    seatIndex += 6;
                }
                else if (seatIndex > 38 && seatIndex < 42)
                {
                    seatIndex += 9;
                }
                //row 17 - 35
                else if (seatIndex > 41 && seatIndex < plane.Seats.Count - 15)
                {
                    seatIndex += 9;
                }
                //row 36
                else if (seatIndex == plane.Seats.Count - 13 || seatIndex == plane.Seats.Count - 14 || seatIndex == plane.Seats.Count - 15)
                {
                    seatIndex = plane.Seats.Count - 6;
                }
                else if (seatIndex == plane.Seats.Count - 12 || seatIndex == plane.Seats.Count - 11 || seatIndex == plane.Seats.Count - 10)
                {
                    seatIndex += 6;
                }
                else if (seatIndex == plane.Seats.Count - 9 || seatIndex == plane.Seats.Count - 8 || seatIndex == plane.Seats.Count - 7)
                {
                    seatIndex = plane.Seats.Count - 4;
                }
                //row 37
                else if (seatIndex == plane.Seats.Count - 6 || seatIndex == plane.Seats.Count - 5 || seatIndex == plane.Seats.Count - 4)
                {
                    seatIndex += 3;
                }
            }
        }
        if (hasSelection)
        {
            Console.WriteLine("Selected seat: " + plane.Seats[seatIndex].SeatId);
            return plane.Seats[seatIndex].SeatId;
        }
        else
            return null;
    }
}