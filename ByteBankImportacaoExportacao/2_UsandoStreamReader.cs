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
        static void UsandoStreamReader()
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

                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    var msg = $"{contaCorrente.Titular.Nome}:  Conta número {contaCorrente.Numero}, agencia {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";

                    Console.WriteLine(msg);
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');
            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var nomeTitular = campos[3];

            var agenciaInt = int.Parse(agencia);
            var numeroInt = int.Parse(numero);
            var saldoDouble = double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agenciaInt, numeroInt);
            resultado.Depositar(saldoDouble);
            resultado.Titular = titular;

            return resultado;
        }
    }
}