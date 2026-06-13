class Bill
{
    decimal Consultation_Fee = 500m;
    decimal Blood_Test = 200m;
    decimal X_Ray = 1000m;
    decimal Admission_Fee = 2000m;
    public decimal Bill_Calculator()
    {
        int op;
        decimal tot=0.0m;
        Console.WriteLine("Add Services:\n1. Consultation (500)\n2. Blood Test (200)\n3. X-Ray (1000)\n4.Admission_Fee\n5.Done\n");

        while (true) { 
        Console.Write("choice:");
        op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    tot +=Consultation_Fee;
                    Console.WriteLine("[Added Consultation]");
                    break;
                case 2:
                    tot += Blood_Test;
                    Console.WriteLine("[Added Blood Test]");
                    break;
                case 3:
                    tot += X_Ray;
                    Console.WriteLine("[Added X Ray]");
                    break;
                case 4:
                    tot += Admission_Fee;
                    Console.WriteLine("[Added Admission]");
                    break;
                case 5:
                   
                    Console.WriteLine("[Calculating Bill...]\n");
                    //stop execution
                    return tot;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        


        Console.WriteLine("-------------------------------------------------\n       HOSPITAL BILLING CALCULATOR\n--------------------------------------------------");
        Console.Write("Patient Name:");
        string name = Console.ReadLine();
        Console.Write("Patient Age:");
        int age = int.Parse(Console.ReadLine());

        Console.WriteLine();
        var Bill = new Bill();
        decimal tot=Bill.Bill_Calculator();
        decimal final_tot=0.0m, disc_amt=0.0m,tax=0.0m;
        //discount
        if (age > 60)
        {
            disc_amt = (20 * tot / 100);
            tax = 5 * (tot-disc_amt) / 100;
            final_tot = tot-disc_amt + tax;

        }
        else if (age < 10)
        {
            if (tot == 500)//consultation only
            {
                disc_amt = (50 * tot / 100);
                

            }
            tax = 5 * (tot - disc_amt) / 100;
            final_tot = tot - disc_amt + tax;

        }
        else
        {
            tax = 5 * (tot - disc_amt) / 100;
            final_tot = tot + tax;
        }

        string discount = disc_amt == 0 ? "0" : (age > 60 ? "20" : "50");
        string type = age > 60 ? "Senior Citizen"
                     : age < 10 ? "Child"
                     : "Regular";
        //display bill
        Console.WriteLine($"--------------------------------------------------\n            FINAL BILL INVOICE\r\n--------------------------------------------------\nPatient:{name} ({type})\n\nBase Amount:      {tot}\nDiscount ({discount}%):   -{disc_amt}\nTax (5%):         +{tax}\n\n--------------------------------------------------\nTOTAL PAYABLE:    {final_tot}\r\n--------------------------------------------------");
    }
}