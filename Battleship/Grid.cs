using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Vsite.Battleship
{
    public class Grid
    {
        public enum Orientation
        {
            Vertical,
            Horizontal
        }

        public Grid()
        {
            m_field = new Square[NumberOfRows, NumberOfColumns];
            for (int r = 0; r < NumberOfRows; ++r)
                for (int c = 0; c < NumberOfColumns; ++c)
                    m_field[r, c] = new Square(r, c);
        }

        public Square[] GetFreeStartingSquares(int length, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    return GetAvailableStartingSquares((r, c) => m_field[r, c], length, NumberOfRows, NumberOfColumns);
                case Orientation.Vertical:
                    return GetAvailableStartingSquares((r, c) => m_field[c, r], length, NumberOfColumns, NumberOfRows);
                default:
                    Debug.Assert(false);
                    break;
            }
            return null;
        }

        public Ship MakeShip(Square startingSquare, int length, Orientation orientation)
        {
            Square[] squares = GetSquares(startingSquare, length, orientation);
            OccupySquares(squares);
            return new Ship(squares);
        }

        private Square[] GetSquares(Square startingSquare, int length, Orientation orientation)
        {
            List<Square> squares = new List<Square>();
            int deltaR = 0;
            int deltaC = 0;
            switch (orientation)
            {
                case Orientation.Horizontal:
                    deltaC = 1;
                    break;
                case Orientation.Vertical:
                    deltaR = 1;
                    break;
            }
            int row = startingSquare.Row;
            int column = startingSquare.Column;
            for (int i = 0; i < length; ++i)
            {
                squares.Add(m_field[row, column]);
                row += deltaR;
                column += deltaC;
            }
            return squares.ToArray();
        }

        private void OccupySquares(Square[] squares)
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

        private Square[] GetAvailableStartingSquares(Func<int, int, Square> selector, int length, int maxI, int maxJ)
        {
            List<Square> squares = new List<Square>();
            for (int i = 0; i < maxI; ++i)
            {
                int counter = 0;
                for (int j = 0; j < maxJ; ++j)
                {
                    if (selector(i, j).IsFree)
                        counter++;
                    else
                        counter = 0;
                    if (counter >= length)
                        squares.Add(selector(i, j + 1 - length));
                }
            }
            return squares.ToArray();
        }

        private Square[,] m_field;

        public const int NumberOfRows = 10;
        public const int NumberOfColumns = 10;

    }
}
