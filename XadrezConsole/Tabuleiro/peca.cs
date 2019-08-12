using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
   abstract class Peca
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

        //4.3.4 Posso mover(peca(pos)) para destino
        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        //4.3.3 Verificar se a peça não esta bloqueda de MOvimentos
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for( int i=0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    if( mat[i , j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //4.3 Vai incrementar a quantidade de movimentos
        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        //4.4 Vai incrementar a quantidade de movimentos
        public void DecrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        //4.3.2 Movimentos possiveis que as peças podem fazer
        public abstract bool[,] MovimentosPossiveis();
        
    }
}
