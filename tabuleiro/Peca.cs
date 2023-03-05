using System.Reflection.Metadata.Ecma335;
using tabuleiro;

namespace tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.Cor = cor;
            this.Posicao = null;
            this.Tab = tab;
            this.QteMovimentos = 0;

        }
    }
}
