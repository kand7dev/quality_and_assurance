using QualityAndAssurance.HRLib;
using System;
using System.Runtime.InteropServices;

public class EntryPoint
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //HRLib.Employee employee1 = new HRLib.Employee("Viktor", "2121860594", "6906169199", new DateTime(1999, 10, 6), new DateTime(2023, 1, 1));
        //HRLib.Employee employee2 = new HRLib.Employee("Volodymyr", "2121056439", "6934567609", new DateTime(1986, 10, 6), new DateTime(2001, 5, 20));
        //HRLib.Employee employee3 = new HRLib.Employee("Viktor Romanyuk Volodymyr", "2121056439", "6934567609", new DateTime(1986, 10, 6), new DateTime(2001, 5, 20));
        //Console.WriteLine(employee3.Name);
        //Console.WriteLine(HRLib.ValidName(employee3.Name));
        //Console.OutputEncoding = System.Text.Encoding.UTF8;

        //int typePhone = 0;
        //string phoneInfo = string.Empty;
        //HRLib.CheckPhone(employee1.MobilePhone, ref typePhone, ref phoneInfo);
        //Console.WriteLine($"TypePhone: {typePhone}\n" +
        //                  $"PhoneInfo: {phoneInfo}");

        //Console.WriteLine($"{employee1.Name}\n" +
        //                  $"{employee1.Birthday.Year}/{employee1.Birthday.Month}/{employee1.Birthday.Day}");
        //int age = 0;
        //int YearsOfExperience = 0;
        //HRLib.InfoEmployee(employee1, ref age, ref YearsOfExperience);
        //Console.WriteLine($"Age: {age}\nYearsOfExperience: {YearsOfExperience}");
        //HRLib.Employee[] employeeArray = new HRLib.Employee[] { employee1, employee2};
        //int count = HRLib.LiveInAthens(employeeArray);
        //Console.WriteLine(count);
        //int result = HRLib.LiveInAthens(employeeArray);
        //Console.WriteLine(result);
        //HRLib.Employee emp1 = new HRLib.Employee("Viktor Romanyuk", "2121029470", "6906169183", new DateTime(1995, 7, 2), new DateTime(2023, 12, 1));
        //int YearsOfExperience = 0;
        //int Age = 0;
        //HRLib.InfoEmployee(emp1, ref Age, ref YearsOfExperience);
        //Console.WriteLine($"Age: {Age}\nYearsOfExperience: {YearsOfExperience}");
        HRLib.Employee emp1 = new HRLib.Employee("Viktor Romanyuk","2121029460", "6906169188", new DateTime(1998, 12 ,1), new DateTime(2017, 9 ,15));
        int age = 0;
        int yearsOfExperience = 0;
        HRLib.InfoEmployee(emp1, ref age, ref yearsOfExperience);
        Console.WriteLine($"Age: {age} and Experience: {yearsOfExperience}");
    }
}