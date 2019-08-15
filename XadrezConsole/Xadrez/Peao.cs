using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Peao:Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);


            if(cor == Cor.Branca)
            {
                
                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna);
                if(tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha - 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha - 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Jogada especial eN Passant
                if(posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelInPassant)
                    {
                        mat[esquerda.linha -1, esquerda.coluna] = true;
                    }
                }

                //Jogada especial eN Passant - direita
                if (posicao.linha == 3)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelInPassant)
                    {
                        mat[direita.linha -1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha + 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirPosicao(posicao.linha + 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Jogada especial eN Passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelInPassant)
                    {
                        mat[esquerda.linha +1, esquerda.coluna] = true;
                    }
                }

                //Jogada especial eN Passant - direita
                if (posicao.linha == 4)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelInPassant)
                    {
                        mat[direita.linha +1, direita.coluna] = true;
                    }
                }

            }

            return mat;
        }

    }
}
