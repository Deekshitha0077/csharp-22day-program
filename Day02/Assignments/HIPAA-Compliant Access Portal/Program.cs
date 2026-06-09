using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString =
    "Server=localhost;" +
    "Database=CareBridgeDB;" +
    "Trusted_Connection=True;" +
    "TrustServerCertificate=True;";
        using SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        string query = "";

        while (true)
        {

            Console.WriteLine("==========HIPAA-Compliant Access Portal===========");
            Console.WriteLine("1.Clinical Team\n2.Billing Team\n3.Analytics Team\n4.Exit");
            Console.WriteLine("Enter your role:");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("Clinical Team Data");
                    query = @"Select * from vw_Clinical";
                    break;
                case 2:
                    Console.WriteLine("Billing Team Data");
                    query = @"Select * from vw_Billing";
                    break;
                case 3:
                    Console.WriteLine("Analytics Team Data");
                    query = @"Select * from vw_Analytics";
                    break;
                case 4:
                    Console.WriteLine("Exiting....");
                    return;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    return;

            }


            using SqlCommand cmd =
                new SqlCommand(query, conn);

            

            using SqlDataReader reader =
                cmd.ExecuteReader();

            Console.WriteLine("-------------------");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"| {reader.GetName(i)}: {reader[i]} ");
                }
                Console.WriteLine("|");
            }



        }

    }
}
