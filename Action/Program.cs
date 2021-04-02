using Action.Entitites;
using System;
using System.Collections.Generic;

namespace Action
{
    class Program
    {
        //Action -> recebe zero ou até 16 parametros e é void (nao retorna nada)
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            #region Sintaxe 1 - Metodo passado como argumento para o foreach
            //list.ForEach(UpdatePrice);
            #endregion

            #region Sintaxe 2 - Action passada como argumento para o foreach
            //Action<Product> act = UpdatePrice;
            //list.ForEach(act);
            #endregion

            #region Sintaxe 3 - Action recebendo uma Expressao Lambda e posteriormente 
            //passada como argumento para o foreach
            //-->obs: Expressao Lambda Void precisa abrir e fechar chaves "{}"
            //Action<Product> actLambda = p => { p.Price += p.Price * 0.1; };
            //list.ForEach(actLambda);
            #endregion

            #region Sintaxe 4 - Expressao Lambda inline
            list.ForEach(p => { p.Price += p.Price * 0.1; });
            #endregion

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }
        }

        static void UpdatePrice(Product p)
        {
            //Atualiza o preço de um produto aumentando 10%
            p.Price += p.Price * 0.1;
        }
    }
}
