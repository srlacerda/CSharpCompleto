using Comparison.Entities;
using System;
using System.Collections.Generic;

namespace Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("TV",900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            //Comparison é um delegate que recebe dois objetos do tipo T e retorna um inteiro
            //Respeita o "O" do SOLID - Open Close Principle
            
            //opcao1 - Referencia simples de metodo com parametro
            list.Sort(CompareProducts); //opcao 1

            //opcao2 - Referencia de metodo atribuido a uma variavel do tipo delegate
            Comparison<Product> comp = CompareProducts;
            list.Sort(comp);

            //opcao3 - Expressao lambda atribuida a uma variavel do tipo delegate
            Comparison<Product> compLambda = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
            list.Sort(compLambda);

            //opcao4 - Expressao lambda inline
            list.Sort((p1,p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }
        }

        static int CompareProducts(Product p1, Product p2)
        {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
