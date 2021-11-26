using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class MoveEventArgs : EventArgs
    {
        public Move Move { get; private set; }

        public MoveEventArgs(Move move)
        {
            Move = move;
        }
    }
}
