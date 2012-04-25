using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VsiTe.BattleShipModul
{
    public class ShipBuilder
    {
        public ShipBuilder() { 
        
            m_grid = new Grid();
        }
        public Fleet MakeFleet() {
            Fleet fleet = new Fleet();
            Random rnd = new Random();

            foreach (int lenght in Fleet.ShipLenghts) { 


                int or = rnd.Next(2);
                Grid.Orientation orient = (Grid.Orientation)or;
                Square[] squares = m_grid.GetFreeStartingSquares(lenght, orient); //sva moguca poc. polja
                if (squares.Length == 0)
                {

                    if (orient == Grid.Orientation.Vertical)
                        orient = Grid.Orientation.Horizontal;
                }
                else
                    orient = Grid.Orientation.Vertical;
                squares = m_grid.GetFreeStartingSquares(lenght, orient);
                int next = rnd.Next(squares.Length);
                Square nextField = squares[next];
                Ship ship = m_grid.MakeShip(nextField, lenght, orient);
                fleet.AddShip(ship);
                
            }
            

            return fleet;
        }

        private Ship MakeShip(int lenght, Grid.Orientation orientation) {

            return null;
        }

        private Grid m_grid;

    }
}
