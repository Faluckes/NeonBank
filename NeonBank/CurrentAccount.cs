using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonBank
{
    public class CurrentAccount
    {
        public static double OperationTaxa { get; private set; }




        public Client Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciaNaoPermitidas { get; private set; }


        public static int TotalAccountsCreated { get; private set; }

        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }
        public CurrentAccount(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0)
            {
                throw new ArgumentException("O argumento Agencia deve ser maior que 0.", nameof(numeroAgencia));
            }
            if (numeroConta <= 0)
            {
                throw new ArgumentException("O argumento Numero deve ser maior que 0.", nameof(numeroConta));
            }
            Agencia = numeroAgencia;
            Numero = numeroConta;
            TotalAccountsCreated++;
            OperationTaxa = 30 / TotalAccountsCreated;

        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new InsufficientFundsException(Saldo, valor);
            }
            _saldo -= valor;

        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, CurrentAccount contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a Transferencia.", nameof(valor));
            }
            try
            {
            Sacar(valor);
            }
            catch (InsufficientFundsException ex)
            {
                ContadorTransferenciaNaoPermitidas++;
                throw new FinancialOperationException("SEM PERMIÇÃO PARA VER ESSA INFORMAÇÃO.", ex); // Estou escondendo a informação do usuario.
            }
            contaDestino.Depositar(valor);
        }
    }
}
