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

        public Peca( Tabuleiro tab, Cor cor )
        {
            this.cor = cor;
            this.posicao = null;
            this.tab = tab;
            this.qteMovimentos = 0;

        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for ( int i = 0; i < tab.Linhas; i++ )
            {
                for ( int j = 0; j < tab.Colunas; j++ )
                {
                    if ( mat[ i, j ] )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara( Posicao pos )
        {
            return movimentosPossiveis()[ pos.Linha, pos.Coluna ];
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
    }
}
