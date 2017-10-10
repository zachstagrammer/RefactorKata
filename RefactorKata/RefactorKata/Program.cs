using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var products = GetProducts();

            foreach (var product in products)
            {
                Console.WriteLine("This product is call: " + product.Name);
            }

        }

        private static IEnumerable<Product> GetProducts()
        {
            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";
                
                var reader = cmd.ExecuteReader();
                var products = new List<Product>();

                //TODO: Replace with Dapper
                while (reader.Read())
                {
                    var prod = new Product {Name = reader["Name"].ToString()};
                    products.Add(prod);
                }
                Console.WriteLine("Products Loaded!");
                return products;
            }
        }
    }
}
