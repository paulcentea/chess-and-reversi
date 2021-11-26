using BoardGames.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    public class ChessGame : Game
    {
        public ChessGame()
        {

        }

        public override void Start()
        {
            Referee?.Start(PieceColor.White);
        }
    }
}
