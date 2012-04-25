using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VsiTe.BattleShipModul
{
    public class Fleet
    {
        public int NumOfShips {

            get { return m_ships.Count; }
        }
        public Ship[] GetShips() {

            return m_ships.ToArray(); //iz flote dobijemo sve brodove
        }
        public void AddShip(Ship ship) {

            m_ships.Add(ship);
        }
        private List<Ship> m_ships = new List<Ship>();
        public static readonly int[] ShipLenghts = { 5, 4, 4, 3, 3, 3, 2, 2, 2 };
    }
}
