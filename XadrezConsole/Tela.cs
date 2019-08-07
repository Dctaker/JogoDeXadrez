using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using Xadrez;

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
                //Forma de imprimir o numero equivalente da Linha
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
                        //Chamando 6.3.2 e dando (objeto.peca(com os parametros da Matriz) como parametro do METODO);
                        ImprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            //Imprimindo letra pra identificar a coluna
            Console.WriteLine("  a b c d e f g h");
        }

        //6.3.3 Metodo vai ler 
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        //Metodo 6.3.2 Que vai dar cores as peças
        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                //se for branca so vai imprimir branca=cinza
                Console.Write(peca);
            }
            else
            {
                //aux recebe cor padrao do console
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow; //cor padrão passa a ser amarelo
                Console.Write(peca); //imprimir peca com cor padra(amarelo)
                Console.ForegroundColor = aux; //cor padrão volta a ser cinza
            }
        }
    }
}
