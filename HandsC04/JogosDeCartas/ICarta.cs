using System;

namespace JogosDeCartas
{
    public interface ICarta
    {
        string Nome { get; }
        string Naipe { get; }
        int Valor { get; }
        bool EstaViradaParaCima { get; }
        void Virar();
    }
}

