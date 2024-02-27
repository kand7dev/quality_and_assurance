using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HRLib
{
    public static void Echo()
    {
        Console.WriteLine("You're calling this class!");
    }
    public static bool ValidName(string Name)
    {
        string[] employeeNameAndSurname = Name.Split(' ');
        foreach (string name in employeeNameAndSurname)
        {
            foreach (char character in name)
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static bool ValidPassword(string Password)
    {
        if (Password.Length < 12) return false; // προυπόθεση α.
        if (!char.IsUpper(Password, 0) || !char.IsDigit(Password, Password.Length - 1)) return false; // προυπόθεση δ.
        return (Password.Any(c => IsLetter(c)) && Password.Any(c => IsDigit(c)) && Password.Any(c => IsSymbol(c))); // προυποθέσεις β,γ.
    }
    public static void EncryptPassword(string Password, ref string EncryptedPW)
    {
        int key = 5;
        EncryptedPW = Encipher(Password, key);
    }
    public static void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
    {
        if (Phone.Length > 10 || Phone.Any(c => char.IsLetter(c)))
        {
            TypePhone = -1;
            InfoPhone = null;
            return;
        }
        Dictionary<string, string> cellphoneDict = new Dictionary<string, string>
        {
            { "690", "NOVA" },
            { "693", "NOVA" },
            { "699", "NOVA" },
            { "694", "VODAFONE" },
            { "695", "VODAFONE" },
            { "697", "COSMOTE" },
            { "698", "COSMOTE" }
        };
        Dictionary<string, string> landlineDict = new Dictionary<string, string>
        {
            { "21", "Μητροπολιτική Περιοχή Αθήνας - Πειραιά" },
            { "22", "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
            { "23", "Κεντική Μακεδονία" },
            { "24", "Θεσσαλία, Δυτική Μακεδονία"},
            { "25", "Θράκη, Ανατολική Μακεδονία" },
            { "26", "Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά" },
            { "27", "Ανατολική Πελοπόννησος, Κύθηρα" },
            { "28", "Κρήτη" }
        };
        string firstThreeDigits = Phone.Substring(0, 3); // or string firstThreeDigits = Phone[0..3]; which works only on C# 8.0
        string firstTwoDigits = Phone.Substring(0, 2);
        if (cellphoneDict.ContainsKey(firstThreeDigits))
        {
            TypePhone = 1;
            InfoPhone = cellphoneDict[firstThreeDigits];
        }
        else if (landlineDict.ContainsKey(firstTwoDigits))
        {
            TypePhone = 0;
            InfoPhone = landlineDict[firstTwoDigits];
        }
        else
        {
            TypePhone = -1;
            InfoPhone = null;
        }
    }

    // Helper functions for ValidPassword.
    private static bool IsLetter(char character)
    {
        return (character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z');
    }
    private static bool IsDigit(char character)
    {
        return (character >= '0' && character <= '9');
    }
    private static bool IsSymbol(char character)
    {
        return (character > 32 && character < 127 && !IsDigit(character) && !IsLetter(character));
    }
    // Helper functions for EncryptPassword.
    private static char Cipher(char ch, int key)
    {
        if (!char.IsLetter(ch)) return ch; // if char is digit.

        char offset = char.IsUpper(ch) ? 'A' : 'a'; // offest changes if char is upper or lower.

        return (char)((((ch + key) - offset) % 26) + offset);

    }
    private static string Encipher(string input, int key)
    {
        string output = string.Empty;

        foreach (char ch in input)
        {
            output += Cipher(ch, key);
        }

        return output;
    }
    private static string Decipher(string input, int key)
    {
        return Encipher(input, 26 - key);
    }
}