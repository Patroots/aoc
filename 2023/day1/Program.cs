using System;
using System.IO;

namespace Aoc
{
    public class Day1 
    {
        public static void Main(string[] args) 
        {
            string arg = args[0];
            bool isTest;

            bool isArgOk = Boolean.TryParse(arg, out isTest);

            if (!isArgOk) {
                throw new ArgumentException("Argument must be true for test or false for live");
            }
            
            string[] textInput = getStringInput(isTest);

            int sum = 0;

            foreach (string line in textInput) {
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

                if (digitsFound) {
                    sum += firstDigit * 10 + lastDigit;
                }
            }
            
            Console.WriteLine($"Result : {sum}");
        }

        public static string[] getStringInput(bool isTest) {
            string filePath = isTest ? "./testInput.txt" : "./input.txt";
            

            string[] readText = File.ReadAllLines(filePath);
            return readText;
        }
    }
}
