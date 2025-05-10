using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTarget.Services
{
    public class SomaService
    {
        public int CalcularSoma()
        {
            int indice = 13, soma = 0, k = 0;

            while (k < indice)
            {
                k++;
                soma += k;
            }

            return soma;
        }
    }
}
