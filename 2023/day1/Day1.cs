using System;
using System.IO;
using System.Collections;

namespace Aoc;

public class Day1 
{
    static Dictionary<string, int> digits = new Dictionary<string, int>{{"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}};

    public static void Exec(string[] args) 
    {
        string[] prefix = AocUtils.getSuffix(args);
        
        string[] textInput = AocUtils.getStringInput(prefix);

        int sum = 0;

        foreach (string line in textInput) {
            if (prefix[1] == "1") {
                sum += calculateLineOnlyDigits(line);
            } else {
                sum += calculateLineDigitsAndChar(line);
            }
        }
        
        Console.WriteLine($"Result : {sum}");
    }

    public static int calculateLineDigitsAndChar(string line) {
        int startIndex = 0;
        int endIndex = line.Length -1;
        int firstDigit = 0, lastDigit = 0;
        bool digitsFound = false, firstDigitFound = false, lastDigitFound = false;

        while(!digitsFound && (startIndex <= endIndex)) {
            if(!firstDigitFound) {
                int firstDigitTry = findDigit(startIndex, true, line);
                if (firstDigitTry != -1) {
                    firstDigit = firstDigitTry;
                    firstDigitFound = true;
                } else {
                    startIndex ++;
                } 
            }

            if(!lastDigitFound) {
                int lastDigitTry = findDigit(endIndex, false, line);
                if (lastDigitTry != -1) {
                    lastDigit = lastDigitTry;
                    lastDigitFound = true;
                } else {
                    endIndex --;
                } 
            }

            digitsFound = firstDigitFound && lastDigitFound;
        }

        return digitsFound ? firstDigit * 10 + lastDigit : 0;
    }

    public static int findDigit(int index, bool isStartIndex, string line) {
        // Find numeric digit
        int digitInt = (int) Char.GetNumericValue(line[index]);
        if (digitInt != -1) return digitInt;

        // Find string digit
        string testString = isStartIndex ? line.Substring(0, index+1) : line.Substring(index);
        int writtenDigit = findWrittenDigitInString(digits, testString);
        
        return writtenDigit;
    }

    public static int findWrittenDigitInString(Dictionary<string, int> dic, string seq) {
        foreach(KeyValuePair<string, int> entry in dic) {
            if (seq.Contains(entry.Key)) {
                return entry.Value;
            }
        }
        return -1;
    }

    public static int calculateLineOnlyDigits(string line) {
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
}

