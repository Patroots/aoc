using System;
using System.IO;

namespace Aoc;

public class AocUtils {

    static string basePath = Environment.CurrentDirectory;
    public static string[] getSuffix(string[] args) {
        string[] puzzleArgs = new string[args.Length - 1];
        Array.ConstrainedCopy(args, 1, puzzleArgs, 0, puzzleArgs.Length);

        string puzzleName = args[0];
        basePath += $"/{puzzleName}";

        string? testSuffix = Array.Find(puzzleArgs, arg => arg.ToLower() == "test");
        string? puzzleNumber = Array.Find(puzzleArgs, arg => arg == "1" || arg == "2");

        return [testSuffix != null ? $"_{testSuffix}" : "", puzzleNumber != null ? $"_{puzzleNumber}" : "_1"];
    }

    public static string[] getStringInput(string[] prefix) {
        string filePath = basePath + $"/input{prefix[0]}{prefix[1]}.txt";

        string[] readText = File.ReadAllLines(filePath);
        return readText;
    }
}