using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class EnemyGrid
    {
        public EnemyGrid()
        {
            m_field = new Square[Grid.NumberOfRows, Grid.NumberOfColumns];
            for (int r = 0; r < Grid.NumberOfRows; ++r)
                for (int c = 0; c < Grid.NumberOfColumns; ++c)
                    m_field[r, c] = new Square(r, c);
        }

        public bool IsFree(int row, int column)
        {
            return m_field[row, column].IsFree;
        }

        public Square GetSquare(int row, int column)
        {
            return m_field[row, column];
        }

        public void OccupySquare(Square square)
        {
            m_field[square.Row, square.Column].Occupy();
        }

        public void OccupySquares(Square[] squares)
        {
            int left = squares[0].Column - 1;
            if (left < 0)
                left = 0;
            int top = squares[0].Row - 1;
            if (top < 0)
                top = 0;

            int right = squares[squares.Length - 1].Column + 1;
            if (right >= Grid.NumberOfColumns)
                right = Grid.NumberOfColumns - 1;
            int bottom = squares[squares.Length - 1].Row + 1;
            if (bottom >= Grid.NumberOfRows)
                bottom = Grid.NumberOfRows - 1;

            for (int r = top; r <= bottom; ++r)
                for (int c = left; c <= right; ++c)
                    m_field[r, c].Occupy();
        }

        private Square[,] m_field;
    }
}
