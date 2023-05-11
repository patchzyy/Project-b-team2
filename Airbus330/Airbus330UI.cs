public class DrawAirbus330UI
{
    public static string? SelectAirbus330(Airbus330 plane, int amountToSelect)
    {
        int seatIndex = 0;
        int seatsChosen = 0;
        while (true)
        {
            Console.Clear();
            DrawAirbus330(plane, plane.Seats[seatIndex]);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                if (!plane.Seats[seatIndex].IsReserved)
                {
                    break;
                }
            }
            if (key.Key == ConsoleKey.Escape)
            {
                return null;
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (seatIndex != 344)
                {
                    seatIndex++;
                }
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (seatIndex != 0)
                {
                    seatIndex--;
                }
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
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
        }
        Console.WriteLine(seatIndex);
        return "placeholder";
    }
    
    public static void DrawAirbus330(Airbus330 plane, Seat currentSeat)
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
                    if (seat.ExtraBeenRuimte)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (seat.IsClubClass)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    if (seat.IsReserved)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    if (seat == currentSeat)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    if (seat.IsReserved)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
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