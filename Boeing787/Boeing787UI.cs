public class DrawBoeing787UI
{
    private static bool _reversedSeatFirst = true;
    public static void DrawBoeing787(Boeing787 plane, Seat currentSeat, Flight flight)
    {
        string[] NederlandsBool = new string[2] { "Nee", "Ja" };
        Console.WriteLine("        /                                            \\");
        Console.WriteLine("       /                                              \\");
        Console.Write("     _/                                                \\_");
        Console.Write("                       LEGENDA\n");
        Console.Write("    /                                                    \\                      ");
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = EconomyPlus \n");
        Console.Write("   /                                                      \\                     ");
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = BusinessClass \n");
        Console.Write("  /                                                        \\                    ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Gereserveerde stoel\n");
        Console.Write(" /                                                          \\                   ");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Huidige stoel\n");
        Console.WriteLine("/                                                            \\");
        Console.Write("|                                                            |");
        Console.Write("                  Gebruik de pijltjestoetsen om door het vliegtuig te navigeren.\n");
        Console.Write("|                                                            |");
        Console.Write("                  Druk op ENTER om een stoel te (de)selecteren\n");
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
                    {
                        Console.Write(" ");
                    }
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
                    if (seat.IsBusinessClass)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    if (seat.IsEconomyPlus)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                    if (!DrawBoeing787UI._reversedSeatFirst)
                    {
                        if (seat.IsReserved)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        if (seat == currentSeat)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                    }
                    if (DrawBoeing787UI._reversedSeatFirst)
                    {
                        if (seat == currentSeat)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        if (seat.IsReserved)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                    }
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
                Console.WriteLine("|" + $"  {rowNr}" + "                   Prijs: " + currentSeat.GetTotalPrice(flight));
            }
            if (rowNr == 24)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   " + (currentSeat.IsBusinessClass ? "BusinessClass" : currentSeat.IsEconomyPlus ? "EconomyPlus" : "Economy"));
            }
            if (rowNr == 25)
            {
                Console.WriteLine("|" + $"  {rowNr}");
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

    public static List<Seat>? SelectBoeing787(Boeing787 plane, int amountToSelect, Flight flight)
    {
        int seatIndex = 0;
        List<string> SeatsChosen = new();
        List<Seat> returnSeats = new();
        while (true)
        {
            Console.Clear();
            DrawBoeing787(plane, plane.Seats[seatIndex], flight);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return returnSeats;
            }
            if (key.Key == ConsoleKey.Enter)
            {
                _reversedSeatFirst = true;
                Console.Clear();
                DrawBoeing787(plane, plane.Seats[seatIndex], flight);
                if (plane.Seats[seatIndex].IsReserved)
                {
                    SeatsChosen.Remove(plane.Seats[seatIndex].SeatId);
                    returnSeats.Remove(plane.Seats[seatIndex]);
                    plane.Seats[seatIndex].IsReserved = false;
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawBoeing787(plane, plane.Seats[seatIndex], flight);
                    continue;
                }

                if (SeatsChosen.Count == amountToSelect)
                {
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawBoeing787(plane, plane.Seats[seatIndex], flight);
                    Console.WriteLine($"Je hebt al {amountToSelect} stoelen gekozen.");
                    Console.WriteLine("\nWil je doorgaan met het boeken?");
                    if (ChooseTheSeats())
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (!plane.Seats[seatIndex].IsReserved)
                {
                    SeatsChosen.Add(plane.Seats[seatIndex].SeatId);
                    returnSeats.Add(plane.Seats[seatIndex]);
                    plane.Seats[seatIndex].IsReserved = true;
                    Console.Clear();
                    DrawBoeing787(plane, plane.Seats[seatIndex], flight);
                }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            if ((key.Key == ConsoleKey.LeftArrow) && (seatIndex > 0))
            {
                _reversedSeatFirst = false;
                seatIndex--;
                continue;
            }
            if ((key.Key == ConsoleKey.RightArrow) && (seatIndex < (plane.Seats.Count - 1)))
            {
                _reversedSeatFirst = false;
                seatIndex++;
                continue;
            }
            if ((key.Key == ConsoleKey.UpArrow) && (seatIndex > 5))
            {
                _reversedSeatFirst = false;
                Console.Clear();
                DrawBoeing787(plane, plane.Seats[seatIndex], flight);
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
                _reversedSeatFirst = false;
                Console.Clear();
                DrawBoeing787(plane, plane.Seats[seatIndex], flight);
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

            if (SeatsChosen.Count == amountToSelect)
            {
                Console.Clear();
                DrawBoeing787(plane, plane.Seats[seatIndex], flight);
                Console.Write("\nJe gekozen stoelen zijn: ");
                foreach (string seat in SeatsChosen)
                {
                    bool isLastSeat = seat.Equals(SeatsChosen.Last());
                    Console.Write($"{seat}");

                    if (!isLastSeat)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(".");
                Console.WriteLine("\nWil je doorgaan met het boeken?");
                if (ChooseTheSeats())
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            else if (SeatsChosen.Count > amountToSelect)
            {
                MovingOn(amountToSelect);
                continue;
            }
        }
        foreach (Seat seat in returnSeats)
        {
            Seat addSeat = new Seat(seat.SeatId, seat.ExtraBeenRuimte, seat.IsClubClass, seat.IsDoubleSeat, seat.IsFrontSeat, seat.IsBusinessClass, seat.IsEconomyPlus, seat.IsEconomy);
            returnSeats.Append(addSeat);
        }
        return returnSeats;

    }

    private static void MovingOn(int amountToSelect)
    {
        Console.WriteLine($"Selecteer a.u.b. alleen {amountToSelect} stoelen.");
        Console.WriteLine("Druk op enter om door te gaan met stoelen selecteren.");
        var keyForMenu = Console.ReadKey(true);
        while (true)
        {
            if (keyForMenu.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    private static bool ChooseTheSeats()
    {
        List<string> choices = new() { "Ja", "Nee" };
        int selectedOption = 0;
        while (true)
        {
            // Console.WriteLine();
            var cursor = Console.GetCursorPosition();
            Console.SetCursorPosition(0, cursor.Top);
            if (selectedOption == 0)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("Ja");
                Console.ResetColor();
                Console.Write("   ");
                Console.Write("Nee");
            }
            else if (selectedOption == 1)
            {
                Console.Write("Ja");
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write("Nee");
                Console.ResetColor();
            }
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (selectedOption > 0)
                    {
                        selectedOption--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (selectedOption < choices.Count - 1)
                    {
                        selectedOption++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (selectedOption == 0)
                    {
                        Console.WriteLine("\n\n");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }

        }
    }
}