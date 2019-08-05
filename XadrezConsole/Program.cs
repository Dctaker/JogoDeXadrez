using System;
using tabuleiro;
using Xadrez;
namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chamando o tabuleiro
            Tabuleiro tab = new Tabuleiro(8, 8);

            //Chamando as peças dentro do tabuleiro
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.ColocarPeca(new Rei(tab, Cor.Vermelho), new Posicao(2, 4));


            Tela.ImprimirTabuleiro(tab);
        }
    }
}
