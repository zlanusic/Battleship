using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class Ship
    {
        public Ship(Square[] squares)
        {
            m_squares = squares;
        }

        public Square[] Squares
        {
            get { return m_squares; }
        }

        public HitResults Fire(int row, int column)
        {
            foreach (Square square in m_squares)
            {
                if (square.Column == column && square.Row == row)
                {
                    m_hitFields.Add(square);
                    if (m_hitFields.Count == m_squares.Length)
                        return HitResults.Sunk;
                    return HitResults.Hit;
                }
            }
            return HitResults.Missed;
        }

        private Square[] m_squares;

        private HashSet<Square> m_hitFields = new HashSet<Square>();
    }
}
