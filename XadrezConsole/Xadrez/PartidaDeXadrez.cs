using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        //9.1 Propiedades da Classe
        //a partida tem um Tabuleiro
        public Tabuleiro tab { get; private set; }
        //a partida tem um  Turno
        public  int turno { get; private set; }
        //a partida tem Cor jogador Atual
        public Cor jogadorAtual { get; private set; }
        //atriuto vai inforamr se partida foi terminada
        public bool terminada { get; private set; }
        //Vai guardar todas as pecas da partida
        private HashSet<Peca> pecas;
        //Vai guardar as pecas ccapturadas
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }
        //Vai armazenar as pecas que estiverem vulneraveis a jogada especial
        public Peca VulneravelInPassant { get; private set; }

        //9.2 Construtores
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8); //inicia com tabuleiro 8x8
            turno = 1; //partida comeca com turno 1
            jogadorAtual = Cor.Branca; //quem inicia é as peças brancas
            terminada = false;
            xeque = false;
            VulneravelInPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();

        }

        //9.3 Metodos, retornando a peca capturada
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem); // Retirando do tabuleiro a peça da pos origem dela
            p.IncrementarQteMovimentos(); //Essa peça mexeu
            Peca PecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino); 
            if(PecaCapturada != null)
            {
                capturadas.Add(PecaCapturada);
            }

            //Jogada especial ROQUE
            if(p is Rei && destino.coluna == origem.coluna +2)
            {
                //Origem da torre
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);             
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);    //O destino vai ser o lugar onde o Rei esta          
                Peca T = tab.RetirarPeca(origemT);  //retiro a peca
                T.IncrementarQteMovimentos(); //Incremento jogada 
                tab.ColocarPeca(T, destinoT); // Coloco a torre no luga
            }

            //Jogada especial ROQUE - Grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                //Origem da torre
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);    //O destino vai ser o lugar onde o Rei esta          
                Peca T = tab.RetirarPeca(origem);  //retiro a peca
                T.IncrementarQteMovimentos(); //Incremento jogada
                tab.ColocarPeca(T, destinoT); // Coloco a torre no luga
            }

            //Jogada En Passant
            if(p is Peao)
            {
                if(origem.coluna != destino.coluna && PecaCapturada == null)
                {
                    Posicao PosP;
                    if(p.cor == Cor.Branca)
                    {
                        PosP = new Posicao(destino.linha + 1, destino.coluna); 
                    }
                    else
                    {
                        PosP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    PecaCapturada = tab.RetirarPeca(PosP);
                    capturadas.Add(PecaCapturada);
                        
                }
            }


            return PecaCapturada;
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca PecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);// retirando uma peca da posição destino
            p.DecrementarQteMovimentos(); // decrementando quantidade de movimentos
            if (PecaCapturada != null) // teve uma peça capturada
            {
                tab.ColocarPeca(PecaCapturada, destino);
                capturadas.Remove(PecaCapturada);
            }
            tab.ColocarPeca(p, origem);

            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                //Origem da torre
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);    //O destino vai ser o lugar onde o Rei esta          
                Peca T = tab.RetirarPeca(destinoT);  //retiro a peca
                T.DecrementarQteMovimentos(); //Incremento jogada 
                tab.ColocarPeca(T, origemT); // Coloco a torre no luga
            }


            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                //Origem da torre
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);    //O destino vai ser o lugar onde o Rei esta          
                Peca T = tab.RetirarPeca(destinoT);  //retiro a peca
                T.DecrementarQteMovimentos(); //Incremento jogada 
                tab.ColocarPeca(T, origemT); // Coloco a torre no luga
            }

            //Jpgada E Passant
            if(p is Peao)
            {
                if(origem.coluna != destino.coluna && PecaCapturada == VulneravelInPassant)
                {
                    Peca peao = tab.RetirarPeca(destino);
                    Posicao PosP;
                    if(p.cor == Cor.Branca)
                    {
                        PosP = new Posicao(3, destino.coluna);
                    }
                    else
                    {
                        PosP = new Posicao(4, destino.coluna);
                    }
                }
            }

        }

        //9.3.3 ExecutaMovimento + PassandoTurno + MudaJogador
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca PecaCapturada = executaMovimento(origem, destino);
            if (EstaEmXeque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, PecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em Xeque");
            }
            if (EstaEmXeque(Adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (TestarExqueMate(Adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else // se não tiver em xeque mate:
            {
                turno++;
                MudarJogador();
            }
            
            Peca p = tab.peca(destino); //Pegando a peça movida
            //JOGADA ESPECIAL INPASSANT
            //se peça movida for um peao e tiver andado duas casas:
            if(p is Peao &&(destino.linha ==origem.linha -2 || destino.linha == origem.linha + 2))
            {
                VulneravelInPassant = p;
            }
            else
            {
                VulneravelInPassant = null;
            }
        
        }

        //9.3.5 Realizar as verificações se e possivel mover peça de Origem
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("Essa peça não é sua!");
                
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                //o sinal ! é importante pois estou verificando um tipo BOOL
                throw new TabuleiroException("A peça esta Bloqueda!");
            }
        }

        //9.3.6 Realizar verificações se e possivel mover peca para Destino
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de Destino invalida!");
            }
        }




        //9.3.4 Metodo responsavel pela troca de jogares
        private void MudarJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }

            else
            {
                jogadorAtual = Cor.Branca;
            }
        }


        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        // Assim eu tenho todas as pecas da cor em jogo
        //Exceto aws capturadas
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        //9.3.7 Metodo responsavel por verificar quem é a peça adversaria
        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
            
        }

        //9.3.8 Metodo responsavel por acahr o REi dentro do conjunto de peçasEmJogo da msm COR
        private Peca rei (Cor cor)
        {
            foreach( Peca x in PecasEmJogo(cor))
            {
                //se o x for da classe REI
                if( x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

       //9.3.8 Metodo responsavel de verificar se as pecas adversarias podem mover para posicao do rei

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if(R == null)
            {
                throw new TabuleiroException("Não existe um rei");
            }
            foreach(Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if(mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        //9.3.9 Metodo responsavel pela logica de XEQUE MATE
        public bool TestarExqueMate(Cor cor)
        {
            //É impossivel xequeMate se a peca da cor não estiver em Xeque
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach( Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis(); //para cada movimento possivel, vou tentar tirar do xeque
                for(int i=0; i< tab.linhas; i++)
                {
                    for(int j=0; j < tab.colunas; j++)
                    {
                        if(mat[i, j])//se estiver amrcado como VERDADEIRA
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            //É uma possivel posição para a peça verdadeira
                            Peca PecaCapturada = executaMovimento(origem, new Posicao(i, j)); //realiza movimento de la para i,j
                            bool testeXeque = EstaEmXeque(cor); //testando se ainda esta em xeque
                            DesfazMovimento(origem, destino, PecaCapturada); // Desfaz o movimento
                            if(!testeXeque) //significa que o movimento de cima tirou do xeque
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

            
        }


        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        //9.3.2
        private void colocarPecas()

        {
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('b', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('c', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('d', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('e', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('f', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('g', 2, new Peao(tab, Cor.Branca,this));
            ColocarNovaPeca('h', 2, new Peao(tab, Cor.Branca,this));



            ColocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(tab, Cor.Preta,this));
            ColocarNovaPeca('g', 7, new Peao(tab, Cor.Preta,this));
            ColocarNovaPeca('h', 7, new Peao(tab, Cor.Preta,this));

        }
    }
}
