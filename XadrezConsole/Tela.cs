using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Tela
    {

        //6.3.5 
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando: " + partida.jogadorAtual);
            Console.WriteLine();
        }

        //6.3.6
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas Capturadas: ");
            Console.Write("Brancas");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            
            Console.Write("Pretas");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach( Peca x in conjunto)
            {
                Console.Write(x);
            }
            Console.Write("]");
        } 
    
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
                    //Chamando 6.3.2 e dando (objeto.peca(com os parametros da Matriz) como parametro do METODO);
                    ImprimirPeca(tab.peca(i, j));
                    Console.Write("");
                }
                Console.WriteLine();
            }
            //Imprimindo letra pra identificar a coluna
            Console.WriteLine("  a b c d e f g h");
        }

        //6.3.4 Responsavel por marcar o trajeto que as peças possam fazer
        //Recebendo uma matriz que vai guardar os MovimentoasPosiveeis como parametro
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] PosicoesPossiveis )
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            //Forma de Imrpimir os valores na tela - No formato de tabuleiro
            // Primeiro percorrer s linhas
            for (int i = 0; i < tab.linhas; i++)
            {
                //Forma de imprimir o numero equivalente da Linha
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (PosicoesPossiveis[i, j]){
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    //Chamando 6.3.2 e dando (objeto.peca(com os parametros da Matriz) como parametro do METODO);
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            //Imprimindo letra pra identificar a coluna
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
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
            if (peca == null)
            {
                Console.Write("- ");
            }

            else
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
                Console.Write(" ");
            }
        }       
    }
}
