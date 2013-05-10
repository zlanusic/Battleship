using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class AfterFirstHitFiring : IFiringTactics
    {
        public AfterFirstHitFiring(EnemyGrid grid, Square firstSquareHit, int targetShipLength)
        {
            m_grid = grid;
            m_firstSquare = firstSquareHit;
            m_targetShipLength = targetShipLength;
        }

        #region IFiringTactics Members

        public Square NextTarget()
        {
            List<Square> freeSquares = new List<Square>();
            int row = m_firstSquare.Row;
            int column = m_firstSquare.Column;
            if (column > 0 && m_grid.IsFree(row, column - 1))
                freeSquares.Add(m_grid.GetSquare(row, column - 1));
            if (row > 0 && m_grid.IsFree(row - 1, column))
                freeSquares.Add(m_grid.GetSquare(row - 1, column));
            if (column + 1 < Grid.NumberOfColumns && m_grid.IsFree(row, column + 1))
                freeSquares.Add(m_grid.GetSquare(row, column + 1));
            if (row + 1 < Grid.NumberOfRows && m_grid.IsFree(row + 1, column))
                freeSquares.Add(m_grid.GetSquare(row + 1, column));

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
        private Square m_firstSquare;
        private int m_targetShipLength;
    }
}
