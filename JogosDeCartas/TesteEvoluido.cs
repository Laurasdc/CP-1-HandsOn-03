using System;
using System.Collections.Generic;
using System.Linq;

namespace JogosDeCartas
{
    public class TesteSimples : JogoDeCartasAbstrato
    {
        public TesteSimples(int numeroJogadores) : base(numeroJogadores)
        {
        }

        protected override Baralho CriarBaralho() => new BaralhoTradicional();

        protected override IJogador CriarJogador(string nome) => new Jogador(nome);

        protected override bool VerificarCondicaoVitória()
        {
            // Simples: sem cartas na mão
            return JogadorAtual.TemCartas() == false;
        }

        protected override void RealizarJogada(IJogador jogador)
        {
            // Simula: descarta uma carta se possível
            if (jogador.TemCartas() && Baralho.NumeroDeCartas > 0)
            {
                jogador.DescartarCarta(0);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var jogo = new TesteSimples(3);
            jogo.IniciarJogo();
            Console.WriteLine("=== JOGO INICIADO ===");
            Console.WriteLine($"Partida ID: {jogo.PartidaAtual?.Id}");

            int turnos = 0;
            while (!jogo.JogoTerminado && turnos < 30)
            {
                jogo.JogarTurno();
                turnos++;
                Console.WriteLine($"Turno {turnos}: {jogo.JogadorAtual.Nome} - Cartas restantes no baralho: {jogo.Baralho.NumeroDeCartas}");
                if (VerificarCondicaoVitória())
                {
                    break;
                }
            }

            jogo.TerminarJogo();
            jogo.SalvarHistorico();
            Console.WriteLine("=== JOGO FINALIZADO ===");
            Console.WriteLine($"Vencedor: {jogo.PartidaAtual?.Vencedor?.Nome}");
            Console.WriteLine($"Rodadas: {jogo.PartidaAtual?.NumeroRodadas}");

            var hs = new HistoricoService();
            Console.WriteLine($"Total partidas no histórico: {hs.ObterHistorico().Count}");
        }

        private static bool VerificarCondicaoVitória()
        {
            return false; // Simplified
        }
    }
}

