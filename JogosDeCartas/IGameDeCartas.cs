using System.Collections.Generic;

namespace JogosDeCartas
{
public interface IGameDeCartas
    {
        List<IJogador> Jogadores { get; }
        Baralho Baralho { get; }
        IJogador JogadorAtual { get; }
        bool JogoTerminado { get; }
        Partida? PartidaAtual { get; }
        List<Partida> HistoricoPartidas { get; }
        void IniciarJogo();
        void JogarTurno();
        void TerminarJogo();
        void SalvarHistorico();
    }
}

