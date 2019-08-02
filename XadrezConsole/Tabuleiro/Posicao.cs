using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Posicao
    {

        //2.1 - Propiedades da Classe
        public int linha { get; set; }
        public int coluna { get; set; }

        //2.2 - Construtor da Classe
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }


        //2.3 - Metodo Para Imprimir 
        public override string ToString()
        {
            return linha
                + ", "
                + coluna;
        }

    }
}
