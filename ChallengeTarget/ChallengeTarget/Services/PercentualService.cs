using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTarget.Services
{
    public class PercentualService
    {
        private readonly Dictionary<string, double> _faturamentos = new()
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        public Dictionary<string, double> CalcularPercentuais()
        {
            double total = _faturamentos.Values.Sum();
            return _faturamentos.ToDictionary(kvp => kvp.Key, kvp => Math.Round(kvp.Value / total * 100, 2));
        }
    }
}
