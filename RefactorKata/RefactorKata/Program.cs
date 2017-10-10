using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is intentionally bad : (  Let's Refactor!
            var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            System.Data.SqlClient.SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            /*
             * cmd.CommandText = "Select * from Invoices";
             */
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            //TODO: Replace with Dapper
            while (reader.Read())
            {
                var prod = new Product();
                prod.name = reader["Name"].ToString();
                products.Add(prod);
            }
            conn.Dispose();
            Console.WriteLine("Products Loaded!");
            for (int i =0; i< products.Count; i++)
            {
                Console.WriteLine(products[i].name);
            }
        }
    }
    public class Product
    {
        public string name;
        public string Name { get { return name; } set { name = value; } }
    }
}
