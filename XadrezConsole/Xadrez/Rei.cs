using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        //7.2 Construtor que vai repassar a instrução para classe Peca
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        //7.3 Metodo que vai imprimir o REI
        public override string ToString()
        {
            return "R";
        }

        //7.3.2 Rei pode mover para esta posição (pos)
        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            //posso mover se a posição for null(livre)
            //ou se a peca que estiver la for da cor diferente do rei
            return p == null || p.cor != cor;
        }


        private bool TesteTorreRoque(Posicao pos)
        {
            //Metodo vai testar se a peça que esta nessa POS é uma torre
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
            // E atende os requisitos do Roque
        }

        //7.3.3 Todas as 8 possiveis movimentações do REI
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // posição ACIMA da posicao do REI
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição Noroeste da posicao do REI
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição DIREITA da posicao do REI
            pos.DefinirPosicao(posicao.linha, posicao.coluna +1 );
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição SUDESTE da posicao do REI
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna +1);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição ABAIXO da posicao do REI
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição SO da posicao do REI
            pos.DefinirPosicao(posicao.linha + 1, posicao.coluna-1);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição Esquerda da posicao do REI
            pos.DefinirPosicao(posicao.linha, posicao.coluna-1);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // posição Noroeste da posicao do REI
            pos.DefinirPosicao(posicao.linha - 1, posicao.coluna -1);
            //Verificaado se a Posicão é valida  E se Pode Mover
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true; //PODE MOVER
            }

            // Jogada especial - ROQUE
            //se nao tiver mexido, e não estiver em xeque
            if(qteMovimentos ==0 && !partida.xeque )
            {
                //Roque pequeno // posicao da torre
                Posicao post1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (TesteTorreRoque(post1))
                {
                    //Posicao do rei + 1
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna +2] = true;
                    }
                }

                //Roque pequeno // posicao da torre
                Posicao post2 = new Posicao(posicao.linha, posicao.coluna -4);
                if (TesteTorreRoque(post2))
                {
                    //Posicao do rei + 1
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna -2] = true;
                    }
                }
                
            }



            return mat;

        }
    }
}
