using System.Collections.Generic;
class Program
{

    public static void DisplayDetails(List<string> details)
    {
        Console.WriteLine("--------------------------------------------------\n            APPOINTMENT TICKET\n--------------------------------------------------");
        Console.WriteLine($"Patient: {details[0]}");
        Console.WriteLine($"Department: {details[1]}");
        Console.WriteLine($"Doctor: {details[2]}");
        Console.WriteLine($"Time: {details[3]}");
        Console.WriteLine("Status: Confirmed");
        Console.WriteLine("Please arrive 15 mins before your slot.\n--------------------------------------------------");
    }
    static void Main(string[] args)
    {
        string[] Departments = { "General Medicine", "Dental", "Orthopedic" };
        string[] GeneralDr = { "Dr. A. Kumar", "Dr. B. Singh" };
        string[] DentalDr = { "Dr. C. Roy", "Dr. D. Gupta" };
        string[] OrthopedicsDr = { "Dr. C. Roy", "Dr. D. Gupta" };
        List<string> details=new List<string>();
        int TimeSlot;
        int deptop;
        int dr;

        //menu
        while (true)
        {
            Console.WriteLine("--------------------------------------------------\n       APPOINTMENT BOOKING SYSTEM\n--------------------------------------------------");
            Console.Write("Enter Patient Name:");
            string name=Console.ReadLine();
            details.Add(name);
            Console.WriteLine();
            //switch case for dept
            Console.Write("Select Department:\n1. General Medicine\n2. Dental\n3. Orthopedics\nEnter Choice:");
            deptop = int.Parse(Console.ReadLine());
            switch (deptop)
            {
                case 1:
                    details.Add(Departments[0]);
                    Console.Write("Select Doctor:");
                    for(int i = 0; i < GeneralDr.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{GeneralDr[i]}");
                    }
                    Console.Write("Enter Choice:");
                    dr = int.Parse(Console.ReadLine());
                    switch(dr)
                    {
                        
                        case 1:
                            details.Add(GeneralDr[0]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;

                        case 2:
                            details.Add(GeneralDr[1]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;
                        default:
                            Console.WriteLine("Invalid Option Selected");
                            break;
                    }
                    break;
                 case 2:
                    details.Add(Departments[1]);
                    Console.Write("Select Doctor:");
                    for (int i = 0; i < DentalDr.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{DentalDr[i]}");
                    }
                    Console.Write("Enter Choice:");
                    dr = int.Parse(Console.ReadLine());
                    switch (dr)
                    {

                        case 1:
                            details.Add(DentalDr[0]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;

                        case 2:
                            details.Add(DentalDr[1]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;
                        default:
                            Console.WriteLine("Invalid Option Selected");
                            break;
                    }
                    break;

                case 3:
                    details.Add(Departments[2]);
                    Console.Write("Select Doctor:");
                    for (int i = 0; i < OrthopedicsDr.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{OrthopedicsDr[i]}");
                    }
                    Console.Write("Enter Choice:");
                    dr = int.Parse(Console.ReadLine());
                    switch (dr)
                    {

                        case 1:
                            details.Add(OrthopedicsDr[0]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;

                        case 2:
                            details.Add(OrthopedicsDr[1]);
                            Console.WriteLine("Select Time slot:\n1. 10:00 AM\n2. 11:00 AM\n3. 12:00 PM");
                            TimeSlot = int.Parse(Console.ReadLine());
                            if (TimeSlot == 1) details.Add("10:00 AM");
                            else if (TimeSlot == 2) details.Add("11:00 AM");
                            else if (TimeSlot == 3) details.Add("12:00 AM");
                            else Console.WriteLine("Invalid Option");
                            break;
                        default:
                            Console.WriteLine("Invalid Option Selected");
                            break;
                    }
                    break;
            }

            Console.WriteLine("[Booking Confirmed]");
            //Display the details
            DisplayDetails(details);


        }


    }
}