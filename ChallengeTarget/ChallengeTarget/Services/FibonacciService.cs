using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTarget.Services
{
    public class FibonacciService
    {
        public bool PertenceFibonacci(int numero)
        {
            int a = 0, b = 1;
            while (b < numero)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == numero || numero == 0;
        }
    }
}
