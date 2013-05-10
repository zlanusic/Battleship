using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class RandomFiring : IFiringTactics
    {
        public RandomFiring(EnemyGrid grid, int targetShipLength)
        {
            m_grid = grid;
            m_targetShipLength = targetShipLength;
        }

        #region IFiringTactics Members

        public Square NextTarget()
        {
            List<Square> freeSquares = new List<Square>();
            for (int r = 0; r < Grid.NumberOfRows; ++r)
            {
                for (int c = 0; c < Grid.NumberOfColumns; ++c)
                {
                    if (m_grid.IsFree(r, c))
                        freeSquares.Add(m_grid.GetSquare(r, c));
                }
            }
            Random rand = new Random();
            int index = rand.Next(freeSquares.Count);
            return freeSquares[index];
        }

        public void AddNewHit(Square square)
        {
            throw new NotImplementedException();
        }

        #endregion

        private EnemyGrid m_grid;

        private int m_targetShipLength;

    }
}
