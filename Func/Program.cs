using Func.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Func
{
    class Program
    {
        //Func -> recebe zero ou até 16 parametros e retorna um resultado
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            #region Sintaxe 1 - Metodo passada como argumento para o Select
            //List<string> result = list.Select(NameUpper).ToList();
            #endregion

            #region Sintaxe 2 - Func passada como argumento para o Select
            //Func<Product, string> func = NameUpper;
            //List<string> result = list.Select(func).ToList();
            #endregion

            #region Sintaxe 3 - Func recebendo uma Expressao Lambda e posteriormente 
            //passada como argumento para o Select
            //Func<Product, string> func = p => p.Name.ToUpper();
            //List<string> result = list.Select(func).ToList();
            #endregion

            #region Sintaxe 4 - Expresao Lambda inline
            List<string> result = list.Select(p => p.Name.ToUpper()).ToList();
            #endregion

            foreach (string p in result)
            {
                Console.WriteLine(p);
            }
        }

        static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }

    }
}
