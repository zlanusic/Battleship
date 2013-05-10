using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class Square
    {
        public Square(int row, int column)
        {
            m_row = row;
            m_column = column;
            m_isFree = true;
        }

        public void Occupy()
        {
            m_isFree = false;
        }

        public int Row
        {
            get { return m_row; }
        }

        public int Column
        {
            get { return m_column; }
        }

        public bool IsFree
        {
            get { return m_isFree; }
        }

        private int m_row;
        private int m_column;
        private bool m_isFree;
    }
}
