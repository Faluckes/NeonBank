using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonBank
{
    public class InsufficientFundsException : FinancialOperationException
    {

        public double Saldo { get; }
        public double ValorSaque { get; }
        public InsufficientFundsException()
        {

        }

        public InsufficientFundsException(double saldo, double valorSaque)
            : this($"Tentativa de saque do valor de R${valorSaque} em uma conta com saldo de R${saldo}")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public InsufficientFundsException(string mensagem)
            : base(mensagem)
        {
        }

        public InsufficientFundsException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }
    }
}
