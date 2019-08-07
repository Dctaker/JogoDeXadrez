using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        //9.1 Propiedades da Classe
        //a partida tem um Tabuleiro
        public Tabuleiro tab { get; private set; }
        //a partida tem um  Turno
        private int turno;
        //a partida tem Cor jogador Atual
        private Cor jogadorAtual;
        //atriuto vai inforamr se partida foi terminada
        public bool terminada { get; private set; }

        //9.2 Construtores
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8); //inicia com tabuleiro 8x8
            turno = 1; //partida comeca com turno 1
            jogadorAtual = Cor.Branca; //quem inicia é as peças brancas
            colocarPecas();
            terminada = false;
        }

        //9.3 Metodos
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem); // Retirando do tabuleiro a peça da pos origem dela
            p.IncrementarQteMovimentos(); //Essa peça mexeu
            Peca PecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);          
        }

        private void colocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e',7).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('f', 6).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('g', 7).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('f',1).toPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());


        }
    }
}
