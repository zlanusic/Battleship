using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class Fleet
    {
        public int NumberOfShips
        {
            get { return m_ships.Count; }
        }

        public Ship[] GetShips()
        {
            return m_ships.ToArray();
        }

        public void AddShip(Ship ship)
        {
            m_ships.Add(ship);
        }

        public HitResults Fire(int row, int column)
        {
            foreach (Ship ship in m_ships)
            {
                HitResults result = ship.Fire(row, column);
                if (result != HitResults.Missed)
                {
                    if (result == HitResults.Sunk)
                        m_lastSunkenShip = ship;
                    return result;
                }
            }
            return HitResults.Missed;
        }

        public Ship LastSunkenShip
        {
            get { return m_lastSunkenShip; }
        }

        private List<Ship> m_ships = new List<Ship>();

        private Ship m_lastSunkenShip = null;

        public static readonly int[] ShipLengths = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
    }
}
