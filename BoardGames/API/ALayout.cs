using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoardGames.API
{
    public abstract class ALayout : Dictionary<Coordinate, APiece>
    {
        public abstract void Initialize();

        public void Cleanup()
        {
            Clear();
        }

        public abstract void Move(Move move);
        
        public abstract ALayout Clone();
    }
}
