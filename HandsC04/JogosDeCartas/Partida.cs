using System;
using System.Collections.Generic;

namespace JogosDeCartas
{
    public class Partida
    {
        public Guid Id { get; init; }
        public DateTime DataInicio { get; init; }
        public DateTime? DataFim { get; set; }
        public List<IJogador> Jogadores { get; init; }
        public IJogador? Vencedor { get; set; }
        public List<Rodada> Rodadas { get; init; }
        public string Status { get; set; } = "Ativa";

        public Partida(List<IJogador> jogadores)
        {
            Id = Guid.NewGuid();
            DataInicio = DateTime.Now;
            Jogadores = jogadores;
            Rodadas = new List<Rodada>();
        }

        public void FinalizarPartida(IJogador vencedor)
        {
            Vencedor = vencedor;
            DataFim = DateTime.Now;
            Status = "Finalizada";
        }

        public int NumeroRodadas => Rodadas.Count;
    }
}

