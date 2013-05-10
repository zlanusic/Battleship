using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class OrientationalFiring : IFiringTactics
    {
        public OrientationalFiring(EnemyGrid grid, Square[] squaresHit, int targetShipLength)
        {
            m_grid = grid;
            m_squaresHit = squaresHit;
            m_targetShipLength = targetShipLength;
        }

        #region IFiringTactics Members

        public Square NextTarget()
        {
            SortSquares();
            Square firstSquare = m_squaresHit[0];
            Square lastSquare = m_squaresHit[m_squaresHit.Length - 1];
            List<Square> available = new List<Square>();
            int left = firstSquare.Column;
            int top = firstSquare.Row;
            int right = lastSquare.Column;
            int bottom = lastSquare.Row;
            // vertical orientation
            if (left == right)
            {
                if (top > 0 && m_grid.IsFree(top - 1, left))
                    available.Add(m_grid.GetSquare(top - 1, left));
                if (bottom + 1 <= Grid.NumberOfRows)
                    available.Add(m_grid.GetSquare(bottom + 1, left));
            }
            else
            {
                if (left > 0 && m_grid.IsFree(top, left - 1))
                    available.Add(m_grid.GetSquare(top, left - 1));
                if (right + 1 <= Grid.NumberOfColumns)
                    available.Add(m_grid.GetSquare(bottom, left + 1));
            }
            Random r = new Random();
            int index = r.Next(2);
            return available[index];
        }

        #endregion

        private void SortSquares()
        {
            Array.Sort<Square>(m_squaresHit, SquareComparison);
        }

        private static int SquareComparison(Square sq1, Square sq2)
        {
            if (sq1.Column == sq2.Column)
                return sq1.Row - sq2.Row;
            return sq1.Column - sq2.Column;
        }

        private EnemyGrid m_grid;
        private Square[] m_squaresHit;
        private int m_targetShipLength;
    }
}
