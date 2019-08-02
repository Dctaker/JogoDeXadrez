using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
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
    }

}
