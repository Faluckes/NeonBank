using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonBank
{
    public class FileReader : IDisposable
    {
        public string File { get; }

        public FileReader(string file)
        {
            File = file;

           // throw new FileNotFoundException();

            Console.WriteLine($"Abrindo arquivo: {file}");



        }

        public string ReadNextLine()
        {
            Console.WriteLine("Lendo linha. . .");
            throw new IOException();
            return "Linha do arquivo";
        }

        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
