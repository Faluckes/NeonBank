using System;

namespace NeonBank
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                CurrentAccount conta1 = new CurrentAccount(32131, 312321);
                CurrentAccount conta2 = new CurrentAccount(321, 345789);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch(FinancialOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }



            Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(2);
        }

        private static void TestaDivisao(int divisor)
        {
            try
            {
                Dividir(10, divisor);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Fui capturado pelo (NullReferenceException ex)");
                Console.WriteLine(ex.Message);
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                Console.WriteLine($"Fazendo o cáuculo {numero} / {divisor}");
                int resultado = numero / divisor;
                Console.WriteLine($"O resultado é {resultado}");
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no cáuculo {ex.Message}");
                throw;
            }

        }
    }
}