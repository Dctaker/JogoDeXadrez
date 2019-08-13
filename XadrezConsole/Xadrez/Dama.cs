using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);


            //Acima 
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
            //Enquanto posição valida dentro do tabuleiro AND Ppode mover
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //Pode mover pra lá
                //Vai se mover ate
                //1. Se a posicao da peça for !null (ou seja tem ALGUEM) = PARAAAAA
                //2. Se a posição tiver alguem de cor diferente da peça =PARAAAAAA
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                //caso if seja falso, continua o WHILE
                pos.linha = pos.linha - 1;

            }


            //Abaixo 
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
            //Enquanto posição valida dentro do tabuleiro AND Ppode mover
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //Pode mover pra lá
                //Vai se mover ate
                //1. Se a posicao da peça for !null (ou seja tem ALGUEM) = PARAAAAA
                //2. Se a posição tiver alguem de cor diferente da peça =PARAAAAAA
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                //caso if seja falso, continua o WHILE
                pos.linha = pos.linha + 1;

            }


            //Direita
            pos.DefinirPosicao(posicao.linha, posicao.coluna + 1);
            //Enquanto posição valida dentro do tabuleiro AND Ppode mover
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //Pode mover pra lá
                //Vai se mover ate
                //1. Se a posicao da peça for !null (ou seja tem ALGUEM) = PARAAAAA
                //2. Se a posição tiver alguem de cor diferente da peça =PARAAAAAA
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                //caso if seja falso, continua o WHILE
                pos.coluna = pos.coluna + 1;

            }


            //Esquerda
            pos.DefinirPosicao(posicao.linha, posicao.coluna - 1);
            //Enquanto posição valida dentro do tabuleiro AND Ppode mover
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //Pode mover pra lá
                //Vai se mover ate
                //1. Se a posicao da peça for !null (ou seja tem ALGUEM) = PARAAAAA
                //2. Se a posição tiver alguem de cor diferente da peça =PARAAAAAA
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                //caso if seja falso, continua o WHILE
                pos.coluna = pos.coluna - 1;

            }

            //NO
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna - 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.linha - 1, pos.coluna - 1);
            }

            //NE 
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.linha - 1, pos.coluna + 1);
            }

            //SE
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.linha + 1, pos.coluna + 1);
            }

            //SO
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirPosicao(pos.linha + 1, pos.coluna - 1);
            }

            return mat;

        }
    }
}








