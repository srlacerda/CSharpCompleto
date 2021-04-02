using System;
using System.Linq;

namespace ProgramacaoFuncional
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = new int[3] { 1, 2, 3 };

            #region Programacao Imperativa
            int sum = 0;
            foreach (int x in list)
            {
                sum += x;
            }
            Console.WriteLine($"sum normal {sum}");
            #endregion

            #region Programcao Funcional - voce define uma expressao lambda
            //list.Sort(MetodoSort) no projeto "Comparison" passamos uma funcao como parametro.
            //na Programacao funcional podemos passar a funcao como parametro e também retornar uma funcao no resultado.

            int sumFuncional = list.Aggregate(0, (x, y) => x + y);
            Console.WriteLine($"sum funcional {sumFuncional}");
            #endregion
        }
    }
}
