using Delegates.Services;
using System;

namespace Delegates
{
    //Delegates pré-definidos

    //- Predicate -> recebe um objeto e devolve um booleano
    //- Action -> recebe zero ou até 16 parametros e é void (nao retorna nada)
    //- Func - > recebe zero ou até 16 parametros e retorna um resultado

    //Delegate é um tipo referencia com type safety

    delegate double BinaryNumericOperation(double n1, double n2);

    delegate void BinaryNumericOperationVoid(double n1, double n2);
    class Program

    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            #region Delegates

            #region Sintaxe Normal
            //double resultNormal = CalculationService.Sum(a, b);
            //Console.WriteLine($"resultado normal: {resultNormal}");
            #endregion

            //- Como o delegate é type safety o compilador avisa que 
            //a assinatura da funcao Square nao casa com a assinatura do delegate
            //BinaryNumericOperation op = CalculationService.Square; //vai dar erro do compilador

            #region Sintaxe 1 - Passando metodo como argumento para o delegate
            //BinaryNumericOperation op = CalculationService.Sum;
            //double result = op(a, b);
            //Console.WriteLine($"resultado delegate: {result}");
            #endregion

            #region Sintaxe 2 - Instanciando o delegate passando o metodo como argumento - porém muito verboso
            //BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);
            //double result = op(a, b);
            //Console.WriteLine($"resultado delegate: {result}");
            #endregion

            #region Sintaxe 3 - Uutilizando o Invoke (da na mesma que a sintaxe 2)
            //BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);
            //double result = op.Invoke(a, b);
            //Console.WriteLine($"resultado delegate: {result}");
            #endregion






            #endregion

            #region Multicast Delegate
            //- A chamda Invoke (ou reduzida) executa todos os metodos na ordem 
            //em que foram adicionados

            //- Seu uso faz sentido para metodos void

            //BinaryNumericOperationVoid op = CalculationService.ShowSum;
            //op += CalculationService.ShowMax;

            //op.Invoke(a, b);

            #endregion

        }
    }
}
