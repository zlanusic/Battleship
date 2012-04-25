using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VsiTe.BattleShipModul
{
   public class Square
    {
        public Square(int row, int column) {
            //starting point
            m_row = row;
            m_column = column;
            m_isFree = true;
        }
        public void Occupy() {

            m_isFree = false;
        }
        public bool IsFree {

            get { return m_isFree; }
        }
        public int Row {

            get { return m_row; }
        }
        public int Column {

            get { return m_column; }
        }

        private int m_row;
        private int m_column;
        private bool m_isFree;

    }
}
