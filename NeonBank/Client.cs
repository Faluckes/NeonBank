using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonBank
{
    public class Client
    {
        private string _cpf;


        public string Nome { get; set; }
        public string CPF
        {
            get
            {
                return _cpf;
            }

            set
            {
                _cpf = value;
            }
        }
        public string Profissao { get; set; }
        public string Salario { get; set; }
    }
}
