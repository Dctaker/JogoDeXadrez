using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class PosicaoXadrez //8.0
    {
        //8.1 Propiedades da Classe
        public char coluna { get; set; }
        public int linha { get; set; }

        //8.2 Construtor da classe - So recebendo
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        //8.3 Metodo que vai converter o Tabuleiro original do xadrez
        //Para Formato de Matriz
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }

        //8.3.1 Metodo que vai imprimir a posição real dos objetos
        public override string ToString()
        {
            return "" + coluna + linha;
        }

    }
}
