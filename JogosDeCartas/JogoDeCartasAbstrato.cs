using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
    public abstract class JogoDeCartasAbstrato : IGameDeCartas
    {
        public List<IJogador> Jogadores { get; protected set; }
        public Baralho? Baralho { get; protected set; }
        public IJogador JogadorAtual { get; protected set; }
        public bool JogoTerminado { get; protected set; }
        public Partida? PartidaAtual { get; protected set; }
        public List<Partida> HistoricoPartidas { get; protected set; } = new List<Partida>();
        protected int indiceJogadorAtual;
        protected Random random;
        protected HistoricoService historicoService = new HistoricoService();

        protected JogoDeCartasAbstrato(int numeroJogadores)
        {
            random = new Random();
            Jogadores = new List<IJogador>();
            for (int i = 0; i < numeroJogadores; i++)
            {
                Jogadores.Add(CriarJogador($"Jogador {i + 1}"));
            }
            indiceJogadorAtual = 0;
            JogadorAtual = Jogadores[indiceJogadorAtual];
        }

        protected abstract Baralho CriarBaralho();
        protected abstract IJogador CriarJogador(string nome);
        protected abstract bool VerificarCondicaoVitória();
        protected abstract void RealizarJogada(IJogador jogador);

        public virtual void IniciarJogo()
        {
            PartidaAtual = new Partida(new List<IJogador>(Jogadores));
            Baralho = CriarBaralho();
            Baralho.Embaralhar();
            DistribuirCartasIniciais();
        }

        protected virtual void DistribuirCartasIniciais()
        {
            int cartasPorJogador = NumeroCartasIniciaisPorJogador;
            for (int i = 0; i < cartasPorJogador; i++)
            {
                foreach (var jogador in Jogadores)
                {
                    if (Baralho.NumeroDeCartas > 0)
                    {
                        jogador.ReceberCarta(Baralho.PuxarCarta());
                    }
                }
            }
        }

        protected virtual int NumeroCartasIniciaisPorJogador => 5;

        public virtual void JogarTurno()
        {
            if (JogoTerminado) return;

            RealizarJogada(JogadorAtual);
            ProximoJogador();
        }

        private void ProximoJogador()
        {
            indiceJogadorAtual = (indiceJogadorAtual + 1) % Jogadores.Count;
            JogadorAtual = Jogadores[indiceJogadorAtual];
        }

        public virtual void TerminarJogo()
        {
            JogoTerminado = true;
            if (PartidaAtual != null)
            {
                // Determina vencedor simples
                var vencedor = Jogadores.FirstOrDefault(j => !j.TemCartas()) ?? JogadorAtual;
                PartidaAtual.FinalizarPartida(vencedor);
                HistoricoPartidas.Add(PartidaAtual);
                historicoService.SalvarPartida(PartidaAtual);
            }
        }

        public virtual void SalvarHistorico()
        {
            foreach (var partida in HistoricoPartidas)
            {
                historicoService.SalvarPartida(partida);
            }
        }
    }
}

