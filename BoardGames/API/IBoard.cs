using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.API
{
    public interface IBoard
    {
        Action<object, MoveEventArgs> MoveProposed { get; set; }

        void Initialize();
        void OnContextChanged(object sender, ContextChangedEventArgs e);
        void SupressMouseInteractions();
        void ResumeMouseInteractions();
        void Cleanup();
    }
}
