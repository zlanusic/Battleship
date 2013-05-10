using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vsite.Battleship
{
    public class Gunnary
    {
        enum Tactics
        {
            Random,
            AfterFirst,
            Orientational
        }

        public Gunnary()
        {
            m_enemyGrid = new EnemyGrid();
            m_tactics = new RandomFiring(m_enemyGrid, Fleet.ShipLengths[0]);
            m_tacticsState = Tactics.Random;
            m_squaresHit = new List<Square>();
            m_shipsLeft = new List<int>(Fleet.ShipLengths);
        }

        public Square NextTarget()
        {
            m_lastTarget = m_tactics.NextTarget();
            m_enemyGrid.OccupySquare(m_lastTarget);
            return m_lastTarget;
        }

        public void ProcessHitResult(HitResults hitResult)
        {
            if (hitResult == HitResults.Hit)
            {
                m_squaresHit.Add(m_lastTarget);
                if (m_tacticsState == Tactics.Random)
                {
                    m_tactics = new AfterFirstHitFiring(m_enemyGrid, m_squaresHit[0], m_shipsLeft[0]);
                    m_tacticsState = Tactics.AfterFirst;
                }
                else if (m_tacticsState == Tactics.AfterFirst)
                {
                    m_tactics = new OrientationalFiring(m_enemyGrid, m_squaresHit.ToArray(), m_shipsLeft[0]);
                    m_tacticsState = Tactics.Orientational;
                }
                else
                {
                    m_tactics.AddNewHit(m_lastTarget);
                }
            }
            else if (hitResult == HitResults.Sunk)
            {
                m_squaresHit.Add(m_lastTarget);
                m_squaresHit.Sort(((sq1, sq2) => sq1.Row == sq2.Row ? sq1.Column - sq2.Column : sq1.Row - sq2.Row));
                m_enemyGrid.OccupySquares(m_squaresHit.ToArray());
                int shipLength = m_squaresHit.Count;
                m_shipsLeft.Remove(shipLength);
                if (AnyShipLeft())
                {
                    m_squaresHit.Clear();
                    m_tactics = new RandomFiring(m_enemyGrid, m_shipsLeft[0]);
                    m_tacticsState = Tactics.Random;
                }
            }
        }

        public bool AnyShipLeft()
        {
            return m_shipsLeft.Count > 0;
        }


        private EnemyGrid m_enemyGrid;

        private IFiringTactics m_tactics;

        private List<Square> m_squaresHit;

        private Square m_lastTarget;

        private Tactics m_tacticsState;

        private List<int> m_shipsLeft;
    }
}
