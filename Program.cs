using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

namespace CS_Lesson_10
{

    internal class Program
    {
        static string path = "C:\\Users\\С - 3\\Documents\\Ушаков\\Ушаков2\\CS_Lesson_10\\file.json";
        static string path_xml = "C:\\Users\\С - 3\\Documents\\Ушаков\\Ушаков2\\CS_Lesson_10\\file_xml.xml";
        
        static void Main(string[] args)
        {
            //Task_1();
            Task_2();


        }

        public static void Task_2()
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            List<Product> products = new List<Product>
            {
                new Product(1, "Bread", 50f),
                new Product(2, "Konfet", 100f),
                new Product(3, "Cola", 80f),
                new Product(4, "Pepsi", 85f),
                new Product(5, "Eggs", 101f),
                new Product(6, "Makarons", 25f),
                new Product(7, "Gercules", 60f),
                new Product(8, "Chocolate", 50f),
                new Product(9, "Tort", 250f),
            };

            XmlSerializer xml = new XmlSerializer(typeof(List<Product>));

            using (FileStream fstream = new FileStream(path_xml, FileMode.Truncate))
            {
                xml.Serialize(fstream, products);
            }


            XmlDocument doc = new XmlDocument();

            doc.Load(path_xml);

            foreach (XmlNode node in doc.DocumentElement)
            {
                string Id = (string)node.Attributes[0].Value;
                string Name = node.Attributes["Name"].Value;
                string price = node.Attributes["Price"].Value;
                Console.Write("Id - " + Id + "\nName - " + Name + "\nPrice - " + price);
            }


        }

        public static void Task_1()
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            List<Product> products = new List<Product>
            {
                new Product(1, "Bread", 50f),
                new Product(2, "Konfet", 100f),
                new Product(3, "Cola", 80f),
                new Product(4, "Pepsi", 85f),
                new Product(5, "Eggs", 101f),
                new Product(6, "Makarons", 25f),
                new Product(7, "Gercules", 60f),
                new Product(8, "Chocolate", 50f),
                new Product(9, "Tort", 250f),
            };

            string json = JsonSerializer.Serialize(products);

            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    AllowTrailingCommas = true,
            //    IgnoreReadOnlyProperties = true
            //};

            using (StreamWriter writer = new StreamWriter(path, false, unicode))
            {
                writer.Write(json);
            }

            using (StreamReader reader = new StreamReader(path))
            {
                Console.WriteLine(reader.ReadLine());
            }

            


        }

        public static void Lesson()
        {
            var employees = new List<Person>
            {
                new Person("Tom", 37, "Microsoft"),
                new Person("Bob", 41, "Google")
            };
            Person p1 = new Person("Tom", 37, "Microsoft");
            Person p2 = new Person("Bob", 41, "Google");

            string json = JsonSerializer.Serialize(employees);
            //Console.WriteLine(json);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(json);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                IgnoreReadOnlyProperties = true
            };

            //Console.WriteLine(JsonSerializer.Serialize(p1, options));

            ///////////////////////////////////////////////////////////////////////////////////////

            XmlSerializer xml = new XmlSerializer(typeof(Person));


            using (StreamWriter writer = new StreamWriter(path_xml))
            {
                xml.Serialize(writer, p1);
            }
        }
    }
}
