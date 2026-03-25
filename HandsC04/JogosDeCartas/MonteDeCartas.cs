using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
    /// <summary>
    /// Classe abstrata genérica para qualquer monte/pilha/talha de cartas.
    /// Pode representar baralho, pilha de descarte, reserva, etc.
    /// </summary>
    public abstract class MonteDeCartas
    {
        protected List<ICarta> cartas;
        protected Random random;

        public MonteDeCartas()
        {
            cartas = new List<ICarta>();
            random = new Random();
            InicializarMonte();
        }

        protected abstract void InicializarMonte();

        public virtual void Embaralhar()
        {
            cartas = cartas.OrderBy(x => random.Next()).ToList();
        }

        public virtual ICarta PuxarCarta()
        {
            if (cartas.Count == 0)
                throw new InvalidOperationException("O monte está vazio.");

            var carta = cartas[0];
            cartas.RemoveAt(0);
            return carta;
        }

        public int NumeroDeCartas => cartas.Count;

        public virtual void AdicionarCarta(ICarta carta)
        {
            cartas.Add(carta);
        }
    }
}

