using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.Checkers
{
    public class CheckersGame : Game
    {
        public CheckersGame()
        {

        }

        public override void Start()
        {
            Referee?.Start(PieceColor.Black);
        }
    }
}
