using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo( Tabuleiro tab, Cor cor ) : base( tab, cor ) { }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover( Posicao pos )
        {
            Peca p = tab.peca( pos );
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[ tab.Linhas, tab.Colunas ];

            Posicao pos = new Posicao( 0, 0 );

            // para cima 1 e esquerda 2
            pos.definirValores( posicao.Linha - 1, posicao.Coluna - 2 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para cima 2 e esquerda 1
            pos.definirValores( posicao.Linha - 2, posicao.Coluna - 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para cima 2 e direita 1
            pos.definirValores( posicao.Linha - 2, posicao.Coluna + 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para cima 1 e direita 2
            pos.definirValores( posicao.Linha - 1, posicao.Coluna + 2 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para baixo 1 e direita 2
            pos.definirValores( posicao.Linha + 1, posicao.Coluna + 2 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para baixo 2 e direita 1
            pos.definirValores( posicao.Linha + 2, posicao.Coluna + 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para baixo 2 e esquerda 1
            pos.definirValores( posicao.Linha + 2, posicao.Coluna - 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // para baixo 1 e esquerda 2
            pos.definirValores( posicao.Linha + 1, posicao.Coluna - 2 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            return mat;

        }
    }
}
