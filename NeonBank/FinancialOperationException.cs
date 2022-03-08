using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonBank
{
    public class FinancialOperationException : Exception
    {
        public FinancialOperationException()
        {

        }
        public FinancialOperationException(string mensagem)
            : base(mensagem)
        {

        }

        public FinancialOperationException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }


    }
}
