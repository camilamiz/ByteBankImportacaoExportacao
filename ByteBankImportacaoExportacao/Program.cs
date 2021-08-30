using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //IO - Input and Output

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //CriarArquivo();
            //CriarArquivoComWriter();
            //TestaEscrita();

            //using (var fs = new FileStream("testaTipos.txt", FileMode.Create))
            //using (var escritor = new StreamWriter(fs))
            //{
            //    escritor.WriteLine(true); //saem como texto puro
            //    escritor.WriteLine(false); //saem como texto puro
            //    escritor.WriteLine(543543453); //saem como texto puro
            //}

            //EscritaBinaria();
            LeituraBinaria();

            Console.ReadLine();
        }
    }
}
