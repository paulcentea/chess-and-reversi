using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public class ContextChangedEventArgs : EventArgs
    {
        public Context Context { get; set; }

        public ContextChangedEventArgs(Context context)
        {
            Context = context;
        }
    }
}
