using System;
using System.IO;

namespace Aoc
{
    public class Day1 
    {
        public static void Main(string[] args) 
        {
            string[] prefix = getSuffix(args);
            
            string[] textInput = getStringInput(prefix);

            int sum = 0;

            foreach (string line in textInput) {
                sum += calculateLine(line);
            }
            
            Console.WriteLine($"Result : {sum}");
        }

        public static int calculateLine(string line) {
            int startIndex = 0;
            int endIndex = line.Length -1;
            int firstDigit = 0, lastDigit = 0;
            bool digitsFound = false, firstDigitFound = false, lastDigitFound = false;

            while(!digitsFound && (startIndex <= endIndex)) {

                if (!firstDigitFound) {
                    
                    int firstDigitDouble = (int) Char.GetNumericValue(line[startIndex]);

                    if (firstDigitDouble != -1) {
                        firstDigit = firstDigitDouble;
                        firstDigitFound = true;
                    } else {
                        startIndex ++;
                    }
                }

                if (!lastDigitFound) {
                    int lastDigitDouble = (int) Char.GetNumericValue(line[endIndex]);

                    if (lastDigitDouble != -1) {
                        lastDigit = lastDigitDouble;
                        lastDigitFound = true;
                    } else {
                        endIndex --;
                    }
                }

                digitsFound = firstDigitFound && lastDigitFound;
            }

            return digitsFound ? firstDigit * 10 + lastDigit : 0;
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
}
