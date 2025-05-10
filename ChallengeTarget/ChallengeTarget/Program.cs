using ChallengeTarget.Services;
using System;

namespace ChallengeTarget
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1) Soma de 1 até 13:");
            var somaService = new SomaService();
            Console.WriteLine($"Resultado: {somaService.CalcularSoma()}\n");

            Console.WriteLine("2) Fibonacci:");
            var fib = new FibonacciService();
            Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
            string inputNumero = Console.ReadLine();
            if (int.TryParse(inputNumero, out int numero))
            {
                Console.WriteLine($"Número {numero} pertence à sequência? {fib.PertenceFibonacci(numero)}\n");
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.\n");
            }

            Console.WriteLine("3) Faturamento (JSON):");
            var fat = new FaturamentoService("Data/faturamento.json");
            Console.WriteLine($"Menor Faturamento: {fat.MenorFaturamento():C}");
            Console.WriteLine($"Maior Faturamento: {fat.MaiorFaturamento():C}");
            Console.WriteLine($"Dias acima da média: {fat.DiasAcimaMedia()}\n");

            Console.WriteLine("4) Percentual por Estado:");
            var percent = new PercentualService();
            foreach (var kvp in percent.CalcularPercentuais())
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}%");
            }

            Console.WriteLine("\n5) Inversor de String:");
            var inversor = new StringInversorService();
            Console.Write("Digite uma string para inverter: ");
            string entrada = Console.ReadLine();
            if (!string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine($"Original: {entrada}");
                Console.WriteLine($"Invertida: {inversor.Inverter(entrada)}");
            }
            else
            {
                Console.WriteLine("Entrada inválida. A string não pode ser vazia.");
            }

            // Prompt para encerrar o programa
            while (true)
            {
                Console.WriteLine("\nDigite 1 para encerrar o programa:");
                string exitInput = Console.ReadLine();
                if (exitInput == "1")
                {
                    break;
                }
                Console.WriteLine("Entrada inválida. Por favor, digite 1 para encerrar.");
            }
        }
    }
}