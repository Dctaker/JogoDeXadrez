using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }

        //A cor pode ser acessada por outras classes
        //pode ser definida/alterada por subclasses ou ela msm
        public Cor cor { get; protected set; } 

        //Vai copntar as jogadas de cada peça
        public int qteMovimentos { get; protected set; }

        //A peça tbm esta em um TABULEIRO
        public Tabuleiro tab { get; protected set; }

        //4.2 Construtor
        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            //Não passada como argumento pois inicia com 0
            this.qteMovimentos = 0;
        }

        //4.3 Vai incrementar a quantidade de movimentos
        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }
    }
}
