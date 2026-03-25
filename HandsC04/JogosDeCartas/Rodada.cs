using System;
using System.Collections.Generic;

namespace JogosDeCartas
{
    public class Rodada
    {
        public Guid Id { get; init; }
        public DateTime Timestamp { get; init; }
        public Dictionary<string, List<ICarta>> Jogadas { get; init; } = new();
        public IJogador? Vencedor { get; set; }
        public List<IJogador> OrdemTurno { get; init; } = new();

        public Rodada()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public void RegistrarJogada(IJogador jogador, List<ICarta> cartasJogadas)
        {
            Jogadas[jogador.Nome] = cartasJogadas;
        }

        public void DefinirVencedorRodada(IJogador vencedor)
        {
            Vencedor = vencedor;
        }
    }
}

