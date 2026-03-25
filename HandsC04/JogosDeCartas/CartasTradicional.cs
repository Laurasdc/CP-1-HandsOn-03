using System.Collections.Generic;

namespace JogosDeCartas
{
    public class CartaTradicional : ICarta
    {
        public string Nome { get; }
        public string Naipe { get; }
        public int Valor { get; }
        public bool EstaViradaParaCima { get; private set; }

        public CartaTradicional(string nome, string naipe, int valor)
        {
            Nome = nome;
            Naipe = naipe;
            Valor = valor;
            EstaViradaParaCima = false;
        }

        public void Virar()
        {
            EstaViradaParaCima = !EstaViradaParaCima;
        }
    }

    public class BaralhoTradicional : Baralho
    {
        protected override void InicializarBaralho()
        {
            string[] naipes = { "Copas", "Ouros", "Espadas", "Paus" };
            string[] valores = { "Ás", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valete", "Dama", "Rei" };
            int[] valoresNumericos = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            for (int i = 0; i < naipes.Length; i++)
            {
                for (int j = 0; j < valores.Length; j++)
                {
                    cartas.Add(new CartaTradicional(valores[j], naipes[i], valoresNumericos[j]));
                }
            }
        }
    }
}

