using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace XadrezConsole
{
    class Tela
    {
        //6.3 Metodo estatico recebendo um tab
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            //Forma de Imrpimir os valores na tela - No formato de tabuleiro
            // Primeiro percorrer s linhas
            for (int i=0; i<tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                
                for (int j=0; j<tab.colunas; j++)
                {
                    
                    //Testando se ha alguma peça
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    //Se tiver peça no ESPAÇO
                    else
                    {
                        //Recebendo o Metodo 5.3 com os parametros(i j)
                        ImprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
