using System;
using System.IO;
using Aoc;

if (args.Length == 0) {
    throw new ArgumentException("Need at least puzzle name as first argument");
}

string puzzleName = args[0];

switch (puzzleName.ToLower())
{
case "day1":
    Console.WriteLine("Launching day1 puzzle...");
    Day1.Exec(args);
    break;

case "day2":
    Console.WriteLine("Launching day2 puzzle...");
    Day2.Exec(args);
    break;

default:
    Console.WriteLine($"No puzzle named {puzzleName}");
    break;
}

