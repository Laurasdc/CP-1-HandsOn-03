using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
    public abstract class Baralho
    {
        protected List<ICarta> cartas;
        protected Random random;

        public Baralho()
        {
            cartas = new List<ICarta>();
            random = new Random();
            InicializarBaralho();
        }

        protected abstract void InicializarBaralho();

        public void Embaralhar()
        {
            cartas = cartas.OrderBy(x => random.Next()).ToList();
        }

        public ICarta PuxarCarta()
        {
            if (cartas.Count == 0)
                throw new InvalidOperationException("O baralho está vazio.");

            var carta = cartas[0];
            cartas.RemoveAt(0);
            return carta;
        }

        public int NumeroDeCartas => cartas.Count;

        public void AdicionarCarta(ICarta carta)
        {
            cartas.Add(carta);
        }
    }
}

