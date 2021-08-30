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
    }
}
