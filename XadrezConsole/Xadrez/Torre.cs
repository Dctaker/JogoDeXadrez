using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        
        //8.2 Construtor que vai repassar a instrução para classe Peca
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        //8.3 Metodo que vai imprimir a Torre
        public override string ToString()
        {
            return "R";
        
        }
    }
}
