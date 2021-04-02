using LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LINQ
{
    class Program
    {
        //LINQ - Language Integrate Query


        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            #region Demo
            // Specify the data source.
            //int[] numbers = new int[] { 2, 3, 4, 5 };

            //// Define the query expression.
            //IEnumerable<int> result = numbers
            //.Where(x => x % 2 == 0) //somente numeros pares
            //.Select(x => 10 * x);

            //// Execute the query.
            //foreach (int x in result)
            //{
            //    Console.WriteLine(x);
            //}
            #endregion

            #region Parte1

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product(){Id = 1,Name = "Computer", Price = 1100.0, Category = c2},
                new Product(){Id = 2,Name = "Hammer", Price = 90.0, Category = c1},
                new Product(){Id = 3,Name = "TV", Price = 1700.0, Category = c3},
                new Product(){Id = 4,Name = "Notebook", Price = 1300.0, Category = c2},
                new Product(){Id = 5,Name = "Saw", Price = 80.0, Category = c1},
                new Product(){Id = 6,Name = "Tablet", Price = 700.0, Category = c2},
                new Product(){Id = 7,Name = "Camera", Price = 700.0, Category = c3},
                new Product(){Id = 8,Name = "Printer", Price = 350.0, Category = c3},
                new Product(){Id = 9,Name = "MacBook", Price = 1800.0, Category = c2},
                new Product(){Id = 10,Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product(){Id = 11,Name = "Level", Price = 70.0, Category = c1},
            };

            //Where TODO PRODUTO P =>(TAL QUE) => Category.Tier == 1 AND Product.Preco < 900
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900",r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select( p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            //Ordena por preço e depois por nome
            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name).Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            //PULA 2 e PEGA 4
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);
            Console.WriteLine();

            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r8);
            Console.WriteLine();

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test2: " + r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max price: " + r10);
            Console.WriteLine();

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price: " + r11);
            Console.WriteLine();

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);
            Console.WriteLine();

            //media
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r13);
            Console.WriteLine();

            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Category 5 Average prices: " + r14);
            Console.WriteLine();

            //Aggregate -> em outras linguagens esta operação recebe o nome de Reduce/MappReduce
            //Aggregate -> Voce monta uma operação agregada personalizada - no exemplo abaixo é uma soma
            //valor default = 0 (caso nao encontre)
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x+y);
            Console.WriteLine("Category 1 Aggregate Sum " + r15 );
            Console.WriteLine();

            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }       


            #endregion
        }
    }
}
