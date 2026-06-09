using System;

class PatientDetails
{
    public string Name { get; set; }
    public double Temperature { get; set; }
    public int Oxygen { get; set; }
    public int Pulse { get; set; }
}

class Program
{
    static string EvaluateCondition(PatientDetails details)
    {
        if (details.Temperature > 39.0 || details.Oxygen < 90 ||( details.Pulse < 50 || details.Pulse > 120))
        {
            return "Critical/Emergency";
        }
        else if (details.Temperature > 37.5 || details.Oxygen < 95 || details.Pulse > 100)
        {
            return "Observation Needed";
        }
        else
        {
            return "Normal";
        }
    }

    static void DisplayDetails(PatientDetails details)
    {
        Console.WriteLine("--------------------------------------------------\n       MEDICAL ASSESSMENT REPORT\n--------------------------------------------------");
        Console.WriteLine($"Patient: {details.Name}\n\nVitals Recorded:\nTemp:   {details.Temperature} C\nOxygen: {details.Oxygen} %\nPulse:  {details.Pulse} BPM");
    
    }

    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------\nVITAL SIGNS MONITOR\n--------------------------------------------------");

        PatientDetails patient = new PatientDetails();

        Console.Write("Enter Patient Name:");
        patient.Name = Console.ReadLine();

        // Temperature
        Console.Write("Enter Temperature (C):");
        if (!double.TryParse(Console.ReadLine(), out double temperature) || temperature < 0)
        {
            Console.WriteLine("Invalid temperature input.");
            return;
        }
        patient.Temperature = temperature;

        // Oxygen
        Console.Write("Enter Oxygen Level (%):");
        if (!int.TryParse(Console.ReadLine(), out int oxygen) || oxygen < 0 || oxygen > 100)
        {
            Console.WriteLine("Invalid oxygen input.");
            return;
        }
        patient.Oxygen = oxygen;

        // Pulse
        Console.Write("Enter Pulse Rate (BPM):");
        if (!int.TryParse(Console.ReadLine(), out int pulse) || pulse < 0)
        {
            Console.WriteLine("Invalid pulse input.");
            return;
        }
        patient.Pulse = pulse;

        string condition = EvaluateCondition(patient);
        Console.WriteLine();

        Console.WriteLine("[Analyzing Data...]");
        Console.WriteLine();
        DisplayDetails(patient);
        Console.WriteLine();
        Console.Write("Status Assessment:");
        if (condition.Equals("Critical/Emergency"))
        {
            Console.WriteLine("EMERGENCY DOCTOR VISIT NEEDED\n(Reason: High Pulse or Elevated Temp)\n\nAction: Nurse to monitor every hour.");
        }
        else if(condition.Equals("Observation Needed"))
        {
            Console.WriteLine("OBSERVATION NEEDED\n(Reason: Abnormal Pulse or Abnormal Temp)\n\nAction: Nurse to monitor every hour.");
        }
        else
        {
            Console.WriteLine("NORMAL\n(Reason: normal Pulse AND normal Temp)\n\nAction: Regular Checkup .");
        }

        Console.WriteLine("--------------------------------------------------\n");
    }
}
