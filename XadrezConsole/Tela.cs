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
                for(int j=0; j<tab.colunas; j++)
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
                        Console.Write(tab.peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
