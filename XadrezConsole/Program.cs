using System;
using tabuleiro;
using Xadrez;
using tabuleiro;
namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
            
        }
    }
}
