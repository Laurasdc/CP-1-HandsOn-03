using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JogosDeCartas
{
    public class HistoricoService
    {
        private readonly string _caminhoArquivo;
        private List<Partida> _historico;

        public HistoricoService(string diretorioBase = "historico")
        {
            _caminhoArquivo = Path.Combine(diretorioBase, "historico_partidas.json");
            _historico = CarregarHistorico();
        }

        public void SalvarPartida(Partida partida)
        {
            _historico.Add(partida);
            SalvarHistorico();
        }

        public List<Partida> ObterHistorico() => _historico;

        public List<Partida> ObterPartidasJogador(string nomeJogador)
        {
            return _historico.FindAll(p => p.Jogadores.Exists(j => j.Nome == nomeJogador));
        }

        private List<Partida> CarregarHistorico()
        {
            if (!File.Exists(_caminhoArquivo))
                return new List<Partida>();

            var json = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<Partida>>(json) ?? new List<Partida>();
        }

        private void SalvarHistorico()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_caminhoArquivo)!);
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_historico, opcoes);
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}

