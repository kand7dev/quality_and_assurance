using System;
using System.Runtime.InteropServices;

public class EntryPoint
{
    static void Main(string[] args)
    {
        HRLib.Employee employee1 = new HRLib.Employee("Viktor", "2121029460033", "6906169199", new DateTime(1999, 10, 6), new DateTime(2023, 1, 1));
        HRLib.Employee employee2 = new HRLib.Employee("Volodymyr", "212102946032131", "6934567609", new DateTime(1986, 10, 6), new DateTime(2001, 5, 20));
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int typePhone = 0;
        string phoneInfo = string.Empty;
        HRLib.CheckPhone(employee1.MobilePhone, ref typePhone, ref phoneInfo);
        Console.WriteLine($"TypePhone: {typePhone}\n" +
                          $"PhoneInfo: {phoneInfo}");

        Console.WriteLine($"{employee1.Name}\n" +
                          $"{employee1.Birthday.Year}/{employee1.Birthday.Month}/{employee1.Birthday.Day}");
        int age = 0;
        int YearsOfExperience = 0;
        HRLib.InfoEmployee(employee1, ref age, ref YearsOfExperience);
        Console.WriteLine($"Age: {age}\nYearsOfExperience: {YearsOfExperience}");
        HRLib.Employee[] employeeArray = new HRLib.Employee[] { employee1, employee2};
        int count = HRLib.LiveInAthens(employeeArray);
        Console.WriteLine(count);
    }
}