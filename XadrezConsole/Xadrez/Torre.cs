using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        
        //8.2 Construtor que vai repassar a instrução para classe Peca
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        //8.3 Metodo que vai imprimir a Torre
        public override string ToString()
        {
            return "T";
        
        }

        //8.3.2 pODEmOVER
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            //posso mover se a posição for null(livre)
            //ou se a peca que estiver la for da cor diferente do rei
            return p == null || p.cor != cor;
        }


        //8.3.3 Todas as 8 possiveis movimentações do REI
        public override bool[,] MovimentosPossiveis()
        {
            //Iniciando uma Matriz
            bool[,] mat = new bool[tab.linhas, tab.colunas];


            //Iniciando uma posição 0,0
            Posicao pos = new Posicao(0, 0);


            //Acima 
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
            //Enquanto posição valida dentro do tabuleiro AND Ppode mover
            while(tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //Pode mover pra lá
                //Vai se mover ate
                //1. Se a posicao da peça for !null (ou seja tem ALGUEM) = PARAAAAA
                //2. Se a posição tiver alguem de cor diferente da peça =PARAAAAAA
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
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
            pos.DefinirPosicao(posicao.linha, posicao.coluna +1);
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
            pos.DefinirPosicao(posicao.linha, posicao.coluna -1);
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
            return mat;

        }




    }
}
