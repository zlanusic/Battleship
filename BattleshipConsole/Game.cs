using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vsite.Battleship;

namespace BattleshipConsole
{
    class Game
    {
        enum Players
        {
            Me,
            Computer
        }

        public Game()
        {

        }

        public void Play()
        {
            ShipBuilder sb = new ShipBuilder();
            Fleet fleet = sb.MakeFleet();

            Gunnary gunnary = new Gunnary();

            List<int> opponentShipsLeft = new List<int>(Fleet.ShipLengths);

            Players currentPlayer = (Players)(new Random().Next(Enum.GetValues(typeof(Players)).Length));
            bool noWinner = true;
            do
            {
                currentPlayer = SwitchPlayers(currentPlayer);

                switch (currentPlayer)
                {
                    case Players.Me:
                        int[] rc = ReadNextTarget();
                        HitResults hitResult = fleet.Fire(rc[0], rc[1]);
                        Console.WriteLine(hitResult.ToString().ToUpper());
                        // check if all ships are sunken
                        if (hitResult == HitResults.Sunk)
                        {
                            opponentShipsLeft.Remove(fleet.LastSunkenShip.Squares.Length);
                            if (opponentShipsLeft.Count == 0)
                                noWinner = false;
                        }
                        break;
                    case Players.Computer:
                        Console.Write("My next target is: ");
                        Square nextTarget = gunnary.NextTarget();
                        Console.WriteLine(string.Format("{0} {1}", (char)(nextTarget.Column + 'A'), nextTarget.Row + 1));
                        hitResult = ReadHitResult();
                        gunnary.ProcessHitResult(hitResult);
                        if (gunnary.AnyShipLeft() == false)
                            noWinner = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (noWinner == true);
            Console.WriteLine("And the winner is: {0}", currentPlayer);
            Console.ReadKey();

        }

        private Players SwitchPlayers(Players currentPlayer)
        {
            switch (currentPlayer)
            {
                case Players.Me:
                    return Players.Computer;
                case Players.Computer:
                    return Players.Me;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int[] ReadNextTarget()
        {
            Console.Write("Enter next target: ");
            string entry = Console.ReadLine().Trim().ToUpper();
            int column = (int)(entry[0] - 'A');
            int row = Convert.ToInt32(entry.Remove(0, 1).Trim()) - 1;
            return new int[] { row, column };
        }

        private HitResults ReadHitResult()
        {
            Console.Write("Enter hit result (M)issed, (H)it or (S)unk: ");
            string result = Console.ReadLine().Trim().ToUpper();
            switch (result[0])
            {
                case 'M':
                    return HitResults.Missed;
                case 'H':
                    return HitResults.Hit;
                case 'S':
                    return HitResults.Sunk;
            }
            throw new ArgumentOutOfRangeException();
        }

    }
}
