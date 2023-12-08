using System;
using System.IO;
using System.Collections;

namespace Aoc;

public class Day2
{
    static HashSet<Game> gameSet = new HashSet<Game>();
    public static void Exec(string[] args) 
    {
        string[] prefix = AocUtils.getSuffix(args);
        
        string[] textInput = AocUtils.getStringInput(prefix);

        int sum = 0;

        // foreach (string line in textInput) {
        //     if (prefix[1] == "1") {
        //         //
        //     } else {
        //         //
        //     }
        // }

        parseGame(textInput[0]);
        
        Console.WriteLine($"Result : {sum}");
    }

    public static void parseGame(string line) {
        int idIndex = line.IndexOf(":") - 1;
        if (idIndex < 0) throw new Exception("Invalid game line");

        int gameId = (int) Char.GetNumericValue(line[idIndex]);
        if (gameId < 0) throw new Exception("Invalid game id");

        string[] draws = line.Split(":")[1].Split(";");
        Game game = new Game(gameId, draws.Length);
        game.display();
    }

    public static string[] getSuffix(string[] args) {
        string? testSuffix = Array.Find(args, arg => arg.ToLower() == "test");
        string? puzzleNumber = Array.Find(args, arg => arg == "1" || arg == "2");

        return [testSuffix != null ? $"_{testSuffix}" : "", puzzleNumber != null ? $"_{puzzleNumber}" : "_1"];
    }

    public static string[] getStringInput(string[] prefix) {
        string filePath = $"./input{prefix[0]}{prefix[1]}.txt";

        string[] readText = File.ReadAllLines(filePath);

        return readText;
    }
}

