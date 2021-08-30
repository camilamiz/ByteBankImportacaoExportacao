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
        static void LidandoComFileStreamDiretamente()
        {
            //var textComQuebraDelInha = "minha primeira linha \nminha segunda linha";
            //Console.WriteLine(textComQuebraDelInha);
            //Console.ReadLine();

            //no mesmo diretório do executável - é um endereço relativo
            var enderecoDoArquivo = "contas.txt";

            //IDisposable - não estou chamando o fluxoDoArquivo.Close() diretamente
            //deste modo, tem também a lógica do try e do finally de uma maneira mais enxuta
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; //1 kb de memória para ler o arquivo
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    //método Read - retorna um int, que é o número total de bytes lidos do buffer
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }

            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = Encoding.Default; //UTF8Encoding, ou  Encoding.UTF8, o default é o padrão do sistema operacional

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

        static void TestaExercicioAcharOErro()
        {
            var fs = new FileStream("teste.txt", FileMode.Open);

            var buffer = new byte[1024];
            var encoding = Encoding.ASCII;

            var bytesLidos = fs.Read(buffer, 0, 1024);
            var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);

            Console.Write(conteudoArquivo);
            Console.ReadLine();

            //saída
            //Arquivo para ser lido com c?? digo C#.
            //além disso, o buffer não está sendo reutilizado, desse movo, a chamada do método Read é feita
            //somente uma vez
        }
    }
}