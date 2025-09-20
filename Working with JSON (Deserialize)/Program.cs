using System;
using System.IO;
using System.Text.Json;

namespace Working_with_JSON__Deserialize_
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader streamReader = new StreamReader("../../../products.json"))
            {
                jsonString = streamReader.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            string mostExpensiveProductName = products[0].ProductName;
            float maxPrice = products[0].ProductPrice;

            foreach (Product e in products)
            {
                if (e.ProductPrice > maxPrice)
                {
                    maxPrice = e.ProductPrice;
                    mostExpensiveProductName = e.ProductName;
                }
            }

            Console.WriteLine(mostExpensiveProductName);
            Console.ReadKey();
        }
    }
}
