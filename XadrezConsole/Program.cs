using System;
using Tabuleiro;
namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           Posicao p = new Posicao(3, 4);

            Console.WriteLine("Posição " + p);
            Console.ReadKey();
        }
    }
}
