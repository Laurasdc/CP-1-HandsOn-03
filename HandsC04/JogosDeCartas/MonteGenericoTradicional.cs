using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
    /// <summary>
    /// Exemplo de monte com 52 cartas tradicionais.
    /// Extensível para UNO, Truco, etc.
    /// </summary>
    public class MonteGenericoTradicional : MonteDeCartas
    {
        protected override void InicializarMonte()
        {
            string[] naipes = { "Copas", "Ouros", "Espadas", "Paus" };
            string[] nomes = { "Ás", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valete", "Dama", "Rei" };
            int[] valores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            for (int i = 0; i < naipes.Length; i++)
            {
                for (int j = 0; j < nomes.Length; j++)
                {
                    cartas.Add(new CartaTradicional(nomes[j], naipes[i], valores[j]));
                }
            }
        }
    }
}

