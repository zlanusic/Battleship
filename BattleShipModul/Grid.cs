using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace VsiTe.BattleShipModul
{
    public class Grid
    {
        public enum Orientation {
        
            Vertical,
            Horizontal,
        }
        //konstruktor klase
        public Grid() {

            m_field = new Square[NumberOfRows, NumberOfColumns];
            for (int r = 0; r < 10; ++r) //rows
                for (int c = 0; c < 10; ++c) //columns
                    m_field[r, c] = new Square(r, c); //inicijalizacija
        }
        private Square[,] m_field; //dvodimenzijalno polje
        //metoda 
        public Square[]GetFreeStartingSquares(int lenght, Orientation orientation ) {
        
            switch(orientation) {
            
                case Orientation.Horizontal:
                    return GetFreeHorizontalSquares(lenght);
                    
                case Orientation.Vertical:
                    return GetFreeVerticalSquares(lenght);
                    
                default:
                    Debug.Assert(false);
                    break;
            }
            return null;
        }

        public Ship MakeShip(Square startSquare, int lenght, Orientation orientation) {
            Square[] squares = GetSquares(startSquare, lenght, orientation);
            OccupySquares(squares);
            return new Ship(squares);
        }
        private Square[] GetSquares(Square startSquare, int lenght, Orientation orientation) {

            List<Square> squares = new List<Square>();
            int deltaR = 0;
            int deltaC = 0;
            switch (orientation) { 
            
                case Orientation.Horizontal:
                    deltaC = 1;
                    break;
                case Orientation.Vertical:
                    deltaR = 1;
                    break;
            }
            int row = startSquare.Row;
            int column = startSquare.Column;
            for (int i = 0; i < lenght; ++i) {

                squares.Add(m_field[row, column]);
                row += deltaR;
                column += deltaC; 
            }
                return squares.ToArray();
        }
        private void OccupySquares(Square[] squraes) {

            int left = squraes[0].Column - 1;
            if (left < 0)
                left = 0;
            int right = squraes[squraes.Length - 1].Column + 1;
            if (right >= Grid.NumberOfColumns)
                right = Grid.NumberOfColumns - 1;
            int bottom = squraes[squraes.Length - 1].Row + 1;
            if (bottom >= Grid.NumberOfRows)
                bottom = Grid.NumberOfRows - 1;


            int top = squraes[0].Row - 1;
            if (top < 0)
                top = 0;
            for (int r = top; r <= bottom; ++r) {

                for (int c = left; c <= right; ++c)
                    m_field[r, c].Occupy();
            }

        }
        private Square[]GetFreeHorizontalSquares(int lenght) {
        
          List<Square> squares = new List<Square>();
            for(int r = 0; r < NumberOfRows; ++r ) {
            
                int counter = 0;
                for (int c = 0; c < NumberOfColumns; ++c)
                {

                    if (m_field[r, c].IsFree)
                        counter++;
                    else
                        counter = 0;
                    if (counter >= lenght)
                        squares.Add(m_field[r, c + 1 - lenght]);
                }
                

            }
                return squares.ToArray();
            

        }
        private Square[] GetFreeVerticalSquares(int lenght)
        {

            List<Square> squares = new List<Square>();
            for (int c = 0; c < NumberOfRows; ++c)
            {

                int counter = 0;
                for (int r = 0; r < NumberOfColumns; ++r)
                {

                    if (m_field[r, c].IsFree)
                        counter++;
                    else
                        counter = 0;
                    if (counter >= lenght)
                        squares.Add(m_field[r + 1 - lenght, c]);
                }

            }

            return squares.ToArray();

        }

        //konstante redaka i kolona za privremeno
        public const int NumberOfRows = 10;
        public const int NumberOfColumns = 10;
    }
}
