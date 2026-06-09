using System;

public class Patient
{
    public string PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void InputDetails(Patient patient)
    {
        
        patient.PatientID = "PAT-2025-001";

        Console.Write("Enter Patient Name:");
        var temp_name = Console.ReadLine();
        if (string.IsNullOrEmpty(temp_name))
        {
            Console.WriteLine("Name can't be empty");
        }
        patient.Name = temp_name;

        Console.Write("Enter Age:");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Error: Please enter a valid numeric age.");
        }
        else
        {
            patient.Age = age;
            if (patient.Age < 0 || patient.Age > 120)
            {
                throw new Exception("Invalid Age");
            }
        }

        Console.Write("Enter Gender (Male/Female/Other):");
        var gen = Console.ReadLine();
        if((string.Equals(gen, "Male", StringComparison.OrdinalIgnoreCase)) ||
            (string.Equals(gen, "Female", StringComparison.OrdinalIgnoreCase))||
           (string.Equals(gen, "Other", StringComparison.OrdinalIgnoreCase)))
            {
            patient.Gender = gen;
            }

        Console.Write("Enter Mobile Number:");
        var temp = Console.ReadLine();
        try
        {
            if (temp.Length != 10)
            {
                throw new Exception("Invalid Mobile Number");
            }
            patient.PhoneNumber = temp;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.Write("Enter City:");
        patient.City = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("[Registration Complete]");

        Console.WriteLine();

        return;
    }


   
    static void Main(string[] args)
    {
        Patient patient = new Patient();
        Console.WriteLine("--------------------------------------------------\n       HOSPITAL PATIENT REGISTRATION SYSTEM\n--------------------------------------------------");
        InputDetails(patient);
        Console.WriteLine("--------------------------------------------------\n            PATIENT REGISTRATION SLIP\n--------------------------------------------------");
        Console.WriteLine($"Date: [{DateTime.Now}]");
        Console.WriteLine();

        Console.WriteLine($"Patient ID: {patient.PatientID}");
        Console.WriteLine($"Name:       {patient.Name}");
        Console.WriteLine($"Age:        {patient.Age}");
        Console.WriteLine($"Contact:    {patient.PhoneNumber}");
        Console.WriteLine($"Location:   {patient.City}");

        Console.WriteLine();


        Console.WriteLine("Instructions:\nPlease proceed to the waiting area.");

        Console.WriteLine("--------------------------------------------------");


    }
}
