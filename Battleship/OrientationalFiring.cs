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
            m_squaresHit = new List<Square>(squaresHit);
            m_targetShipLength = targetShipLength;
        }

        public void AddNewHit(Square square)
        {
            m_squaresHit.Add(square);
        }

        #region IFiringTactics Members

        public Square NextTarget()
        {
            m_squaresHit.Sort(((sq1, sq2) => sq1.Row == sq2.Row ? sq1.Column - sq2.Column : sq1.Row - sq2.Row));
            //Array.Sort<Square>(m_squaresHit, ((sq1, sq2) => sq1.Column == sq2.Column ? sq1.Column - sq2.Column : sq1.Row - sq2.Row));
            List<Square> squares = new List<Square>();
            Square first = m_squaresHit[0];
            Square last = m_squaresHit[m_squaresHit.Count - 1];
            if (first.Row == last.Row)
            {
                int row = first.Row;
                int left = first.Column - 1;
                if (left >= 0 && m_grid.IsFree(row, left))
                {
                    squares.Add(m_grid.GetSquare(row, left));
                }
                int right = last.Column + 1;
                if (right < Grid.NumberOfColumns && m_grid.IsFree(row, right))
                {
                    squares.Add(m_grid.GetSquare(row, right));
                }
            }
            else
            {
                int column = first.Column;
                int top = first.Row - 1;
                if (top >= 0 && m_grid.IsFree(top, column))
                {
                    squares.Add(m_grid.GetSquare(top, column));
                }
                int bottom = last.Row + 1;
                if (bottom < Grid.NumberOfRows && m_grid.IsFree(bottom, column))
                {
                    squares.Add(m_grid.GetSquare(bottom, column));
                }
            }
            Random r = new Random();
            int index = r.Next(squares.Count);
            return squares[index];
        }

        #endregion

        private EnemyGrid m_grid;
        private List<Square> m_squaresHit;
        private int m_targetShipLength;
    }
}
