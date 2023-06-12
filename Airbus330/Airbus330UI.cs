public class DrawAirbus330UI
{
    private static bool _reversedSeatFirst = true;
    public static List<Seat>? SelectAirbus330(Airbus330 plane, int amountToSelect, Flight flight)
    {
        int seatIndex = 0;
        List<string> SeatsChosen = new();
        List<Seat> returnSeats = new();
        while (true)
        {
            Console.Clear();
            DrawAirbus330(plane, plane.Seats[seatIndex], flight);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return returnSeats;
            }
            if (key.Key == ConsoleKey.Enter)
            {
                _reversedSeatFirst = true;
                Console.Clear();
                DrawAirbus330(plane, plane.Seats[seatIndex], flight);
                if (plane.Seats[seatIndex].IsReserved)
                {
                    SeatsChosen.Remove(plane.Seats[seatIndex].SeatId);
                    returnSeats.Remove(plane.Seats[seatIndex]);
                    plane.Seats[seatIndex].IsReserved = false;
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawAirbus330(plane, plane.Seats[seatIndex], flight);
                    continue;
                }

                if (SeatsChosen.Count == amountToSelect)
                {
                    // Console.WriteLine($"Je hebt al {amountToSelect} stoelen gekozen.");
                    // Console.Write("Druk op enter om door te gaan.\n");
                    // while (true)
                    // {
                    //     key = Console.ReadKey();
                    //     if (key.Key == ConsoleKey.Enter)
                    //     {
                    //         break;
                    //     }
                    // }
                    // continue;
                    _reversedSeatFirst = true;
                    Console.Clear();
                    DrawAirbus330(plane, plane.Seats[seatIndex], flight);
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
                    DrawAirbus330(plane, plane.Seats[seatIndex], flight);
                }
                // else
                // {
                //     SeatsChosen.Remove(plane.Seats[seatIndex].SeatId);
                //     returnSeats.Remove(plane.Seats[seatIndex]);
                //     plane.Seats[seatIndex].IsReserved = false;
                // }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                _reversedSeatFirst = false;
                if (seatIndex != 344)
                {
                    seatIndex++;
                }
                continue;
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                _reversedSeatFirst = false;
                if (seatIndex != 0)
                {
                    seatIndex--;
                }
                continue;
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                _reversedSeatFirst = false;
                Console.Clear();
                DrawAirbus330(plane, plane.Seats[seatIndex], flight);
                if (seatIndex < 6)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex == 8 || seatIndex == 9)
                {
                    seatIndex += 13;
                    continue;
                }
                if (seatIndex == 11)
                {
                    seatIndex += 5;
                    continue;
                }
                if (seatIndex > 5 && seatIndex < 12)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex > 11 && seatIndex < 15)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex == 36 || seatIndex == 37 || seatIndex == 38)
                {
                    seatIndex += 18;
                    continue;
                }
                if (seatIndex == 39 || seatIndex == 40 || seatIndex == 41)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex == 42 || seatIndex == 43 || seatIndex == 44)
                {
                    seatIndex += 18;
                    continue;
                }
                if (seatIndex == 51 || seatIndex == 52 || seatIndex == 53)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex > 14 && seatIndex < 44)
                {
                    seatIndex += 9;
                    continue;
                }
                if (seatIndex > 44 && seatIndex < 54)
                {
                    seatIndex += 3;
                    continue;
                }
                if (seatIndex > 53 && seatIndex < 216)
                {
                    seatIndex += 9;
                    continue;
                }
                if (seatIndex == 216 || seatIndex == 217 || seatIndex == 218)
                {
                    seatIndex += 12;
                    continue;
                }
                if (seatIndex == 219 || seatIndex == 220 || seatIndex == 221)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex == 222 || seatIndex == 223 || seatIndex == 224)
                {
                    seatIndex += 12;
                    continue;
                }
                if (seatIndex == 225 || seatIndex == 226 || seatIndex == 227)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex > 227 && seatIndex < 291)
                {
                    seatIndex += 9;
                    continue;
                }
                if (seatIndex == 291)
                {
                    seatIndex += 9;
                    continue;
                }
                if (seatIndex == 292 || seatIndex == 293)
                {
                    seatIndex += 8;
                    continue;
                }
                if (seatIndex > 293 && seatIndex < 297)
                {
                    seatIndex += 8;
                    continue;
                }
                if (seatIndex == 297)
                {
                    seatIndex += 8;
                    continue;
                }
                if (seatIndex == 298)
                {
                    seatIndex += 8;
                    continue;
                }
                if (seatIndex == 299)
                {
                    seatIndex += 7;
                    continue;
                }
                if (seatIndex > 299 && seatIndex < 335)
                {
                    seatIndex += 7;
                    continue;
                }
                if (seatIndex == 335)
                {
                    seatIndex += 7;
                    continue;
                }
                if (seatIndex == 336)
                {
                    seatIndex += 6;
                    continue;
                }
                if (seatIndex == 337 || seatIndex == 338 || seatIndex == 339)
                {
                    seatIndex += 5;
                    continue;
                }
                if (seatIndex == 340)
                {
                    seatIndex += 4;
                    continue;
                }
                if (seatIndex == 341)
                {
                    seatIndex += 3;
                    continue;
                }

            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                _reversedSeatFirst = false;
                Console.Clear();
                DrawAirbus330(plane, plane.Seats[seatIndex], flight);
                if (seatIndex < 6)
                {
                    continue;
                }
                if (seatIndex > 5 && seatIndex < 12)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex > 11 && seatIndex < 14)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex == 14)
                {
                    seatIndex -= 7;
                    continue;
                }
                if (seatIndex > 14 && seatIndex < 17)
                {
                    seatIndex -= 5;
                    continue;
                }
                if (seatIndex == 17)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex == 18 || seatIndex == 19 || seatIndex == 20)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex == 24 || seatIndex == 25 || seatIndex == 26)
                {
                    seatIndex -= 9;
                    continue;
                }
                if (seatIndex == 21 || seatIndex == 22)
                {
                    seatIndex -= 13;
                    continue;
                }
                if (seatIndex == 23)
                {
                    seatIndex -= 14;
                    continue;
                }
                if (seatIndex > 17 && seatIndex < 45)
                {
                    seatIndex -= 9;
                    continue;
                }
                if (seatIndex == 45 || seatIndex == 46 || seatIndex == 47)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex > 47 && seatIndex < 54)
                {
                    seatIndex -= 3;
                    continue;
                }

                // middle row 
                if (seatIndex == 54 || seatIndex == 55 || seatIndex == 56)
                {
                    seatIndex -= 18;
                    continue;
                }
                if (seatIndex == 60 || seatIndex == 61 || seatIndex == 62)
                {
                    seatIndex -= 18;
                    continue;
                }
                if (seatIndex == 57 || seatIndex == 58 || seatIndex == 59)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex > 53 && seatIndex < 225)
                {
                    seatIndex -= 9;
                    continue;
                }
                if (seatIndex == 225 || seatIndex == 226 || seatIndex == 227)
                {
                    seatIndex -= 6;
                    continue;
                }

                // last row 

                if (seatIndex == 228 || seatIndex == 229 || seatIndex == 230)
                {
                    seatIndex -= 12;
                    continue;
                }
                if (seatIndex == 231 || seatIndex == 232 || seatIndex == 233)
                {
                    seatIndex -= 6;
                    continue;
                }
                if (seatIndex == 234 || seatIndex == 235 || seatIndex == 236)
                {
                    seatIndex -= 12;
                    continue;
                }
                if (seatIndex > 227 && seatIndex < 300)
                {
                    seatIndex -= 9;
                    continue;
                }
                if (seatIndex == 300 || seatIndex == 301)
                {
                    seatIndex -= 9;
                    continue;
                }
                if (seatIndex > 301 && seatIndex < 305)
                {
                    seatIndex -= 8;
                    continue;
                }
                if (seatIndex == 305 || seatIndex == 306)
                {
                    seatIndex -= 8;
                    continue;
                }
                if (seatIndex > 306 && seatIndex < 342)
                {
                    seatIndex -= 7;
                    continue;
                }
                if (seatIndex > 341 && seatIndex < 345)
                {
                    seatIndex -= 5;
                    continue;
                }
            }
            if (SeatsChosen.Count == amountToSelect)
            {
                Console.Clear();
                DrawAirbus330(plane, plane.Seats[seatIndex], flight);
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

    public static void DrawAirbus330(Airbus330 plane, Seat currentSeat, Flight flight)
    {
        Console.WriteLine("         _/                                         \\_");
        Console.WriteLine("        /                                             \\");
        Console.Write("      _/                                               \\_");
        Console.Write("             LEGENDA \n");
        Console.Write("     /                                                   \\             ");
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Extra Beenruimte\n");
        Console.Write("   _/                                                     \\_           ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Gereserveerde stoel\n");
        Console.Write("  /                                                         \\          ");
        Console.BackgroundColor = ConsoleColor.DarkMagenta;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Club Class stoel\n");
        Console.Write(" /                                                           \\         ");
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ");
        Console.ResetColor();
        Console.Write(" = Huidige stoel\n");
        Console.Write("|                                                            |");
        Console.Write("         Gebruik de pijltjestoetsen om door het vliegtuig te navigeren.\n");
        Console.Write("|                                                            |");
        Console.Write("         Druk op ENTER om een stoel te (de)selecteren.\n");
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
                    if (seat.IsClubClass)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    if (seat.ExtraBeenRuimte)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (!DrawAirbus330UI._reversedSeatFirst)
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
                    if (DrawAirbus330UI._reversedSeatFirst)
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
            if (rowNr == 20)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   Huidige stoel: " + currentSeat.SeatId);
            }
            if (rowNr == 21)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   Prijs: " + currentSeat.GetTotalPrice(flight));
            }
            if (rowNr == 22)
            {
                Console.WriteLine("|" + $"  {rowNr}" + "                   " + (currentSeat.IsClubClass ? "ClubClass" : currentSeat.ExtraBeenRuimte ? "Extra Beenruimte" : ""));
            }
            if (rowNr == 23)
            {
                Console.WriteLine("|" + $"  {rowNr}");
            }
            if (rowNr != 20 && rowNr != 21 && rowNr != 22 && rowNr != 23)
            {
                Console.WriteLine("|" + $"  {rowNr}");
            }
            rowNr++;
            if (rowNr == 51)
            {
                Console.WriteLine("|                                                            |");
                Console.WriteLine("|                                                            |");
                return;
            }
        }
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