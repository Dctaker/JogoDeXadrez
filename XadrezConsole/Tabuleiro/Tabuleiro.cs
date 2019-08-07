using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        //5.1 Propiedades 
        public int linhas { get; set; }
        public int colunas { get; set; }
        //Matriz de pecas - So o tabuleiro mexe nelas
        private Peca[,] pecas;


        //5.2 Construtor
        //Quando criar tabuleiro informar o tanto de coluasxlinhas
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            //Matriz de peças
            pecas = new Peca[linhas, colunas];

        }

        

        //5.3 Metodo que vai passar a posição da peça dentro do tabuleiro para
        // o 6.3 Na classe Tela
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //5.3.1 Melhoria //SobreCarga
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }


        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        //5.3.2 Metodo que vai dar a Posição uma Peça
        //Inserindo peças no tabuleiro
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                //Para add peça preciso verificar se ja existe uma peça naquela posição
                //Se existir eu chamo exeção com mensagem de erro diferente
                throw new TabuleiroException("Ja existe uma peça nesta posição");
            }
            //A matriz pecas vai receber uma PEÇA  na posicao p.linha, p.coluna
            pecas[pos.linha, pos.coluna] = p;
            //A pposição dela agora vai ser pos
            p.posicao = pos;
        }

        //5.3.5 Retirar peça do tabuleiro
        //Ele vai retornar uma PECA(posso precisar desta peça ainda) //Retirar a peca de uma dada posicao
        public Peca RetirarPeca(Posicao pos)
        {
            //se peca(na posicao) for igual a nulo
            if (peca(pos) == null)
            {
                return null;
            }
            else
            {
                //caso tenha peça, ela vai passar pra variavel AUX
                Peca aux = peca(pos);
                //ela se torna null ou seja, não esta mais dentro do tabuleiro
                aux.posicao = null;
               // marca a posição dela como Nulo, marca a posição no tabuleiro informando que não existe mais peça LA
                pecas[pos.linha, pos.coluna] = null;
                return aux;
            }
        }


        //5.3.3 Metodo que vai vewrificar se a posição é Valida no tabuleiro
        public bool PosicaoValida(Posicao pos)
        {
            if( pos.linha <0 || pos.linha >= linhas || pos.coluna <0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }


        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida");
            }
        }
    }

}
