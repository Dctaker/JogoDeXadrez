using System;
using System.Collections.Generic;
using System.Text;
using XadrezConsole;
using Xadrez;


namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string mg ) : base(mg)
        {

        }
    }
}
