using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        //7.2 Construtor que vai repassar a instrução para classe Peca
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        //7.3 Metodo que vai imprimir o REI
        public override string ToString()
        {
            return "R";
        }
    }
}
