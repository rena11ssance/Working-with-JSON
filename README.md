# Работа с JSON

Задача. Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

— Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).

— Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.

— Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

> Products.cs
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_with_JSON_Serialize_
{
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
```

> Program.cs
```
using System;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Working_with_JSON_Serialize_
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
```
Задача. Необходимо разработать программу для получения информации о товаре из json-файла. Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.

Решение.

> Products.cs
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_with_JSON__Deserialize_
{
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
    }
}
```

> Program.cs
```
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
```
___
