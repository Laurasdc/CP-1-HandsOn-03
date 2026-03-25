using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
public class Jogador : IJogador
    {
        public string Nome { get; }
        public List<ICarta> Mao { get; private set; }
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int TotalRodadasJogadas { get; private set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Mao = new List<ICarta>();
        }

        public void ReceberCarta(ICarta carta)
        {
            Mao.Add(carta);
        }

        public ICarta DescartarCarta(int indice)
        {
            if (indice < 0 || indice >= Mao.Count)
                throw new ArgumentOutOfRangeException(nameof(indice));

            var carta = Mao[indice];
            Mao.RemoveAt(indice);
            return carta;
        }

        public bool TemCartas() => Mao.Any();

        public void RegistrarVitoria()
        {
            Vitorias++;
        }

        public void RegistrarDerrota()
        {
            Derrotas++;
            TotalRodadasJogadas++;
        }
    }
}

