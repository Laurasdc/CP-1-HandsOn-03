using System.Collections.Generic;

namespace JogosDeCartas
{
public interface IJogador
    {
        string Nome { get; }
        List<ICarta> Mao { get; }
        int Vitorias { get; }
        int Derrotas { get; }
        int TotalRodadasJogadas { get; }
        void ReceberCarta(ICarta carta);
        ICarta DescartarCarta(int indice);
        bool TemCartas();
        void RegistrarVitoria();
        void RegistrarDerrota();
    }
}

