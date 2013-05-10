using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public interface IFiringTactics
    {
        Square NextTarget();

        void AddNewHit(Square square);
    }
}
