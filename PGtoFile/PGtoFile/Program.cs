using System;
using Npgsql;         // Npgsql .NET Data Provider for PostgreSQL

class Sample
{
    static void Main(string[] args)
    {
        string dump = "";

        Console.WriteLine("Vítejte u programu pro stažení tabulek z PostgreSQL do souboru");

        // Připojení k PostgreSQL
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" +
                                "Password=thank130;Database=postgres;");
        conn.Open();

        NpgsqlCommand cmd = new NpgsqlCommand("select * from hosts ORDER BY id", conn);

        // Vykonání dotazu
        NpgsqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read()) { 
            dump += "INSERT INTO hosts(id, title) VALUES(" + dr[0] + ", " + dr[1] + ")\n";
        }

        Console.WriteLine(dump);

        // Close connection
        conn.Close();

        string[] lines = { "First line", "Second line", "Third line" };
        System.IO.File.WriteAllText(@"D:\lines.txt", dump);

        Console.WriteLine("Stiskněte Enter pro ukončení");
        Console.ReadLine();
    }
}