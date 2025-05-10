using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StringInversorService
{
    public string Inverter(string input)
    {
        char[] resultado = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultado[i] = input[input.Length - 1 - i];
        }
        return new string(resultado);
    }
}
