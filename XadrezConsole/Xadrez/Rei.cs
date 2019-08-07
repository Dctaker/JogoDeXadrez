using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        //7.2 Construtor que vai repassar a instrução para classe Peca
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
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

            return mat;

        }
    }
}
