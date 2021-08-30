using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456,78945,4785.50,Gustavo Santos";
                var encoding = Encoding.UTF8;
                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            //faz a mesma coisa que o CriarArquivo sem fazer tratativa de bytes

            var caminhoNovoArquivo = "contasExportadasStreamWriter.csv";
            //o FileMode.Create sobrescreve se já existe um arquivo com o mesmo nome
            //o FileMode.CreateNew verifica se o arquivo já existe e se já existe, lança uma exceção
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            //using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("456,65456,4556.0,Pedro");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    //não é nesse momento que a linha é escrita no arquivo. se abrirmos o arquivo no meio do loop, não vamos ver a linha acima
                    //para fazer o código acima, usamos a ram, que é muito rápida, no entanto, para escrever no arquivo no hd, demora muito mais tempo
                    //o buffer armazena as informações para que o sistema seja chamado menos vezes
                    //no entanto, tem ocasiões em que não quero usar o buffer, quero ser notificado de imediato, caso algum problema ocorra
                    //para isso usamos o Flush - ele despeja o buffer para o stream!
                    escritor.WriteLine($"linha {i}");
                    escritor.Flush(); 

                    Console.WriteLine($"linha {i} foi escrita no arquivo. Tecle enter para adicionar mais uma.");
                    Console.ReadLine();
                }

            }
        }
    }
}
