using System;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Working_with_JSON__Serialize_
{
    class Program
    {
        static void Main(string[] args)
        {
            const int productArraySize = 5;
            Product[] products = new Product[productArraySize];

            for (int i = 0; i < productArraySize; i++)
            {
                Console.Write("Введите код товара (целое число): ");
                int productCode = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите название товара: ");
                string productName = Console.ReadLine();

                Console.Write("Введите цену товара: ");
                float productPrice = Convert.ToSingle(Console.ReadLine());

                products[i] = new Product() { ProductCode = productCode, ProductName = productName, ProductPrice = productPrice };
            }

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, jsonSerializerOptions);

            using (StreamWriter sw = new StreamWriter("../../../products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}
