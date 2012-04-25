using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VsiTe.BattleShipModul
{
   public class Ship
    {
        public Ship(Square[] squares) {

            m_squares = squares; //polja
        }
        public Square[] Squares {

            get { return m_squares;}
        }
        private Square[] m_squares;
    }
}
