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
        public  int turno { get; private set; }
        //a partida tem Cor jogador Atual
        public Cor jogadorAtual { get; private set; }
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

        //9.3.3 ExecutaMovimento + PassandoTurno + MudaJogador
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            MudarJogador();
        }

        //9.3.5 Realizar as verificações se e possivel mover peça de Origem
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("Essa peça não é sua!");
                
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                //o sinal ! é importante pois estou verificando um tipo BOOL
                throw new TabuleiroException("A peça esta Bloqueda!");
            }
        }

        //9.3.6 Realizar verificações se e possivel mover peca para Destino
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de Destino invalida!");
            }
        }

        //9.3.4 Metodo responsavel pela troca de jogares
        private void MudarJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }

            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        //9.3.2
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
