﻿class Program
{
    public static void Main()
    {
        Register test = new();
        Console.WriteLine(@"
 ____       _   _               _                 
|  _ \ ___ | |_| |_ ___ _ __ __| | __ _ _ __ ___  
| |_) / _ \| __| __/ _ \ '__/ _` |/ _` | '_ ` _ \ 
|  _ < (_) | |_| ||  __/ | | (_| | (_| | | | | | |
|_| \_\___/ \__|\__\___|_|  \__,_|\__,_|_| |_| |_|
                                                  
    _    _      _ _                 
   / \  (_)_ __| (_)_ __   ___  ___ 
  / _ \ | | '__| | | '_ \ / _ \/ __|
 / ___ \| | |  | | | | | |  __/\__ \
/_/   \_\_|_|  |_|_|_| |_|\___||___/
        
        ");
        Thread.Sleep(2000);
        Console.Write(@"
Rotterdam Airlines is gevestigd in Rotterdam South Airport in
        ");
        Thread.Sleep(1000);
        Console.WriteLine(@"
Driemanssteeweg 107,
3011 WN,
Rotterdam
        ");
    Menu menu = new Menu();
    }


}