using System.Reflection.Metadata.Ecma335;
using tabuleiro;

namespace tabuleiro
{
    internal abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.cor = cor;
            this.posicao = null;
            this.tab = tab;
            this.qteMovimentos = 0;

        }

        public abstract bool[,] movimentosPossiveis();

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
    }
}
