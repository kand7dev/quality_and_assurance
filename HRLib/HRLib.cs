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
}