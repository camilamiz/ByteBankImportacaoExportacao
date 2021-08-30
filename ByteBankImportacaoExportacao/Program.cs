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
            //LeituraBinaria();

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach (var linha in linhas)
            {
                //vamos usar isso somente para casos de arquivo pequenos, pois o arquivo é lido de uma vez
                Console.WriteLine(linha);
            }

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
            Console.WriteLine("Arquivo escrevendoComAClasseFile criado!");

            Console.ReadLine();

            //Console.WriteLine("Digite o seu nome: ");
            //var nome = Console.ReadLine();
            //Console.WriteLine(nome);

            //Console.ReadLine();
        }
    }
}
