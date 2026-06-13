using System;
using System.Collections.Generic;

class PatientRecord
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal BillAmount { get; set; }
    public string Status { get; set; }
}

class Program
{
    static void Main(string[] args)
    { 
        decimal totalrevenue=0;

    
        List<PatientRecord> patients = new List<PatientRecord>
        {
            new PatientRecord { Name = "John Doe", Department = "General", BillAmount = 500, Status = "Admitted" },
            new PatientRecord { Name = "Jane Smith", Department = "Dental", BillAmount = 1200, Status = "Admitted" },
            new PatientRecord { Name = "Bob Brown", Department = "General", BillAmount = 400, Status = "Admitted" },
            new PatientRecord { Name = "Alice W.", Department = "Ortho", BillAmount = 2500, Status = "Admitted" },
            new PatientRecord { Name = "Sam K.", Department = "Dental", BillAmount = 800, Status = "Admitted" }
        };

        int gcount=0, dcount=0, ocount=0;
        foreach (PatientRecord patient in patients)
        {

            totalrevenue += patient.BillAmount;
            if (patient.Department.Equals("General"))
            {
                gcount++;
            }
            if (patient.Department.Equals("Dental"))
            {
                dcount++;
            }
            if (patient.Department.Equals("Ortho"))
            {
                ocount++;
            }
        }

        Console.WriteLine("--------------------------------------------------\r\n       DAILY HOSPITAL ACTIVITY REPORT\r\n--------------------------------------------------\n");
        Console.WriteLine($"Date: {DateTime.Now}\n");
        int i = 0;
        Console.WriteLine("Patient List:");
        foreach(PatientRecord patient in patients)
        {
            Console.WriteLine($"{i + 1}. {patient.Name}  - {patient.Department}   - ${patient.BillAmount}\n");
        }
        Console.WriteLine("--------------------------------------------------\r\nSUMMARY STATISTICS\r\n--------------------------------------------------");
        Console.WriteLine($"Total Patients Visited:  {patients.Count}\nTotal Revenue:           ${totalrevenue}\n");
        Console.WriteLine("Traffic by Department:\n");
        
        Console.WriteLine($"-General: {gcount}\n");
        Console.WriteLine($"- Dental: {dcount}\n");
        Console.WriteLine($"- Ortho: {ocount}\n");
        Console.WriteLine("End of Report.\r\n--------------------------------------------------");
    }
}
