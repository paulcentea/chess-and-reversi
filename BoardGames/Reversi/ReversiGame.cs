using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Reversi
{
    public class ReversiGame : Game
    {
        public ReversiGame()
        {

        }

        public override void Start()
        {
            Referee?.Start(PieceColor.Black);
        }
    }
}
