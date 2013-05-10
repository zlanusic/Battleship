using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class ShipBuilder
    {
        public Fleet MakeFleet()
        {
            Fleet fleet = null;
            while (fleet == null)
            {
                fleet = TryToMakeFleet();
            }
            return fleet;
        }

        private Fleet TryToMakeFleet()
        {
            m_grid = new Grid();
            Fleet fleet = new Fleet();
            foreach (int length in Fleet.ShipLengths)
            {
                Ship ship = MakeShip(length);
                if (ship == null)
                    return null;
                fleet.AddShip(ship);
            }
            return fleet;
        }

        private Ship MakeShip(int length)
        {
            Random rnd = new Random();
            int or = rnd.Next(2);
            Grid.Orientation orientation = (Grid.Orientation)or;
            Square[] squares = m_grid.GetFreeStartingSquares(length, orientation);
            if (squares.Length == 0)
            {
                if (orientation == Grid.Orientation.Vertical)
                    orientation = Grid.Orientation.Horizontal;
                else
                    orientation = Grid.Orientation.Vertical;
                squares = m_grid.GetFreeStartingSquares(length, orientation);
                if (squares.Length == 0)
                    return null;
            }
            int next = rnd.Next(squares.Length);
            Square nextField = squares[next];
            Ship ship = m_grid.MakeShip(nextField, length, orientation);
            return ship;
        }

        Grid m_grid;
    }
}
