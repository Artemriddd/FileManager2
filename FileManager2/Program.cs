﻿using System;
using System.IO;

namespace FileManager2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            CommandHelp.Help();
            InputCommand userConsoleInterface = new();
            userConsoleInterface.InCommand();
        }
    }
}
