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
            //o partial indica que temos uma classe com métodos espalhados por arquivos diferentes
            //neste caso, temos o 1_LidandoComStreamDiretamente e os métodos desse arquivo podem ser chamados aqui diretamente
            //LidandoComFileStreamDiretamente();

            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            //o StreamReader faz exatamente o que fizemos no 1_LidandoComStreamDiretamente
            //mas ainda precisamos usar o IDisposable para fechar o leitor
            //quando temos dois blocos using aninhados, podemos remover as chaves do using externo e o nível de indentação
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                //var linha = leitor.ReadToEnd(); // o readToEnd lê o arquivo inteiro de uma vez, o que é um pouco arriscado de usar
                //usamos o readline enquanto não chegamos no fim do stream
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
            }
            

            Console.ReadLine();
        }
    }
}
