using Microsoft.Data.SqlClient;

// Connection string to SQL Server

string connectionString =
    "Server=localhost;" +
    "Database=CareBridgeDB;" +
    "Trusted_Connection=True;" +
    "TrustServerCertificate=True;";


string procedure="";


//create branding

while (true)
{
    
    Console.WriteLine("===========CareBridge Clinical Operations Console============");
    Console.WriteLine("-----Select an option from the below list-------");
    Console.WriteLine("1.Readmissions within 30 days\n" +
        "2.High-Risk Patients\n" +
        "3.Provider Workload\n" +
        "4.Revenue Analysis\n" +
        "5.Exit\n");

    Console.WriteLine("Enter an option:");
    int op = int.Parse(Console.ReadLine());

    //Switch statements

    switch (op)
    {
        case 1:
            procedure = "usp_ReadmissionAnalytics";
            Console.WriteLine("30-Day Readmission Report");
            break;
        case 2:
            procedure = "sp_HighRiskPatients";
            Console.WriteLine("High-Risk Patients Report");
            break;
        case 3:
            procedure = "sp_ProviderWorkload";
            Console.WriteLine("Provider Workload Report");
            break;
        case 4:
            procedure = "sp_MonthlyBillingReport";
            Console.WriteLine("Revenue Analysis Report");
            break;
        case 5:
            Console.WriteLine("Exiting.....");
            return;
        default:
            Console.WriteLine("Invalid Option choosen");
            break;

    }


    using SqlConnection conn = new SqlConnection(connectionString);

    using SqlCommand cmd = new SqlCommand(procedure, conn);

    // Tell C# this is a stored procedure

    cmd.CommandType = System.Data.CommandType.StoredProcedure;


    conn.Open();

    using SqlDataReader reader = cmd.ExecuteReader();


    
    Console.WriteLine(
        "--------------------------"
    );

    // Read each returned row
    while (reader.Read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            Console.Write($"|{reader.GetName(i)}: +  {reader[i]} | ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
   
}
