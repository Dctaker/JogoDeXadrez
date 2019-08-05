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

        //5.3.2 Metodo que vai dar a Posição uma Peça
        //Inserindo peças no tabuleiro
        public void ColocarPeca(Peca p, Posicao pos)
        {
            //A matriz pecas vai receber uma PEÇA  na posicao p.linha, p.coluna
            pecas[pos.linha, pos.coluna] = p;
            //A pposição dela agora vai ser pos
            p.posicao = pos;
        }
    }

}
