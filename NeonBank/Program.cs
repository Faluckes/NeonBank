using System;

namespace NeonBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoadAccounts();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no metodo main");
            }



            Console.ReadLine();
        }
        private static void LoadAccounts()
        {
            using (FileReader leitor = new FileReader("Teste.txt"))
            {
                leitor.ReadNextLine();
            }




            //----------------------------------------------
            //FileReader leitor = null;
            //try
            //{
            //    new FileReader("contas.txt");
            //    leitor.ReadNextLine();
            //    leitor.ReadNextLine();
            //    leitor.ReadNextLine();
            //}

            //catch (IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o Finally");
            //    if (leitor != null)
            //    {
            //        leitor.Close();
            //    }
            //}

        }

        private static void TestaInnerException()
        {
            try
            {
                CurrentAccount conta1 = new CurrentAccount(40, 30);
                CurrentAccount conta2 = new CurrentAccount(4230, 4230);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (FinancialOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
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