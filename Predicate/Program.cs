using System;
using Predicate.Entities;
using System.Collections.Generic;

namespace Predicate
{
    class Program
    {
        //Predicate é uma função que recebe um objeto e devolve um booleano
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            //RemoveAll espera receber um Predicate

            #region Sintaxe 1 - Metodo passado como argumento
            //list.RemoveAll(ProductTest);
            #endregion

            #region Sintaxe 2 - Predicate passado como argumento
            //Predicate<Product> predicate = ProductTest;
            //list.RemoveAll(predicate);
            #endregion

            #region Sintaxe 3 - Predicate recebendo uma Expressao Lambda e posteriormente passando como parametro
            //Predicate<Product> predicate = p => p.Price >= 100;
            //list.RemoveAll(predicate);
            #endregion

            #region Sintaxe 4 - Expressao Lambda inline
            list.RemoveAll(p => p.Price >= 100);
            #endregion

            foreach (Product p in list)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public static bool ProductTest(Product p)
        {
            return p.Price >= 100;
        }
    }
}
