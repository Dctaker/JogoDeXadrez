using System;
using tabuleiro;
using Xadrez;
namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        //Validando posição origem
                        partida.ValidarPosicaoOrigem(origem);

                        //MOSTRANDO CAMINHOS POSSIVEIS DAS PEÇAS
                        bool[,] PosicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        //Validando Destino 
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroException a)
                    {
                        Console.WriteLine(a.Message);
                        Console.ReadKey();
                    }
                }

            
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
