using System.Threading.Tasks.Dataflow;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei( Tabuleiro tab, Cor cor, PartidaDeXadrez partida ) : base( tab, cor )
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }

        private bool podeMover( Posicao pos )
        {
            Peca p = tab.peca( pos );
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque( Posicao pos )
        {
            Peca p = tab.peca( pos );
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[ tab.Linhas, tab.Colunas ];

            Posicao pos = new Posicao( 0, 0 );

            // acima
            pos.definirValores( posicao.Linha - 1, posicao.Coluna );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // NE (nordeste)
            pos.definirValores( posicao.Linha - 1, posicao.Coluna + 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // direita
            pos.definirValores( posicao.Linha, posicao.Coluna + 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // SE (sudeste)
            pos.definirValores( posicao.Linha + 1, posicao.Coluna + 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // abaixo
            pos.definirValores( posicao.Linha + 1, posicao.Coluna );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // SO (sudoeste)
            pos.definirValores( posicao.Linha + 1, posicao.Coluna - 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // esquerda
            pos.definirValores( posicao.Linha, posicao.Coluna - 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // NO (noroeste)
            pos.definirValores( posicao.Linha - 1, posicao.Coluna - 1 );
            if ( tab.posicaoValida( pos ) && podeMover( pos ) )
            {
                mat[ pos.Linha, pos.Coluna ] = true;
            }

            // #JogadaEspecial Roque
            if ( qteMovimentos == 0 && !partida.xeque )
            {
                // #JogadaEspecial Roque Pequeno
                Posicao posT1 = new Posicao( posicao.Linha, posicao.Coluna + 3 );

                if ( testeTorreParaRoque( posT1 ) )
                {
                    Posicao p1 = new Posicao( posicao.Linha, posicao.Coluna + 1 );
                    Posicao p2 = new Posicao( posicao.Linha, posicao.Coluna + 2 );

                    if ( tab.peca( p1 ) == null && tab.peca( p2 ) == null )
                    {
                        mat[ posicao.Linha, posicao.Coluna + 2 ] = true;
                    }
                }

                // #JogadaEspecial Roque Grande
                Posicao posT2 = new Posicao( posicao.Linha, posicao.Coluna - 4 );

                if ( testeTorreParaRoque( posT2 ) )
                {
                    Posicao p1 = new Posicao( posicao.Linha, posicao.Coluna - 1 );
                    Posicao p2 = new Posicao( posicao.Linha, posicao.Coluna - 2 );
                    Posicao p3 = new Posicao( posicao.Linha, posicao.Coluna - 3 );

                    if ( tab.peca( p1 ) == null && tab.peca( p2 ) == null && tab.peca( p3 ) == null )
                    {
                        mat[ posicao.Linha, posicao.Coluna - 2 ] = true;
                    }
                }
            }

            return mat;
        }
    }
}
