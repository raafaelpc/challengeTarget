using System;
using System.IO;
using System.Text.Json;
using ChallengeTarget.model;

namespace ChallengeTarget.Services
{
    public class FaturamentoService
    {
        private readonly List<Faturamento> _dados;

        // JSON embutido como fallback
        private const string FallbackJson = @"[
            { ""dia"": 1, ""valor"": 22174.1664 },
            { ""dia"": 2, ""valor"": 24537.6698 },
            { ""dia"": 3, ""valor"": 26139.6134 },
            { ""dia"": 4, ""valor"": 0.0 },
            { ""dia"": 5, ""valor"": 0.0 },
            { ""dia"": 6, ""valor"": 26742.6612 },
            { ""dia"": 7, ""valor"": 0.0 },
            { ""dia"": 8, ""valor"": 42889.2258 },
            { ""dia"": 9, ""valor"": 46251.174 },
            { ""dia"": 10, ""valor"": 11191.4722 },
            { ""dia"": 11, ""valor"": 0.0 },
            { ""dia"": 12, ""valor"": 0.0 },
            { ""dia"": 13, ""valor"": 3847.4823 },
            { ""dia"": 14, ""valor"": 373.7838 },
            { ""dia"": 15, ""valor"": 2659.7563 },
            { ""dia"": 16, ""valor"": 48924.2448 },
            { ""dia"": 17, ""valor"": 18419.2614 },
            { ""dia"": 18, ""valor"": 0.0 },
            { ""dia"": 19, ""valor"": 0.0 },
            { ""dia"": 20, ""valor"": 35240.1826 },
            { ""dia"": 21, ""valor"": 43829.1667 },
            { ""dia"": 22, ""valor"": 18235.6852 },
            { ""dia"": 23, ""valor"": 4355.0662 },
            { ""dia"": 24, ""valor"": 13327.1025 },
            { ""dia"": 25, ""valor"": 0.0 },
            { ""dia"": 26, ""valor"": 0.0 },
            { ""dia"": 27, ""valor"": 25681.8318 },
            { ""dia"": 28, ""valor"": 1718.1221 },
            { ""dia"": 29, ""valor"": 13220.495 },
            { ""dia"": 30, ""valor"": 8414.61 }
        ]";

        public FaturamentoService(string jsonPath)
        {
            try
            {
                // Tenta ler o arquivo JSON
                if (File.Exists(jsonPath))
                {
                    var json = File.ReadAllText(jsonPath);
                    _dados = JsonSerializer.Deserialize<List<Faturamento>>(json) ?? new();
                    return;
                }
                else
                {
                    Console.WriteLine($"Arquivo {jsonPath} não encontrado. Usando dados de fallback.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}. Usando dados de fallback.");
            }

            // Usa o JSON embutido como fallback
            _dados = JsonSerializer.Deserialize<List<Faturamento>>(FallbackJson) ?? new();
        }

        public double MenorFaturamento() =>
            _dados.Where(d => d.valor > 0).Min(d => d.valor);

        public double MaiorFaturamento() =>
            _dados.Max(d => d.valor);

        public int DiasAcimaMedia()
        {
            var diasUteis = _dados.Where(d => d.valor > 0).ToList();
            double media = diasUteis.Average(d => d.valor);
            return diasUteis.Count(d => d.valor > media);
        }
    }
}