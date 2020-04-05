using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover
{
    public enum MoveDirection
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }

    public interface ILocation
    {
        void Move(List<int> upperRightCoordinates, string instructions);
    }

    public class Location : ILocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MoveDirection MoveDirection { get; set; }

        public Location()
        {
            X = Y = 0;

            MoveDirection = MoveDirection.N;

        }

        private void TurnLeft()
        {
            switch (this.MoveDirection)
            {
                case MoveDirection.N:
                    this.MoveDirection = MoveDirection.W;
                    break;
                case MoveDirection.S:
                    this.MoveDirection = MoveDirection.E;
                    break;
                case MoveDirection.E:
                    this.MoveDirection = MoveDirection.N;
                    break;
                case MoveDirection.W:
                    this.MoveDirection = MoveDirection.S;
                    break;
                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.MoveDirection)
            {
                case MoveDirection.N:
                    this.MoveDirection = MoveDirection.E;
                    break;
                case MoveDirection.S:
                    this.MoveDirection = MoveDirection.W;
                    break;
                case MoveDirection.E:
                    this.MoveDirection = MoveDirection.S;
                    break;
                case MoveDirection.W:
                    this.MoveDirection = MoveDirection.N;
                    break;
                default:
                    break;
            }
        }

        private void GoStraight()
        {
            switch (this.MoveDirection)
            {
                case MoveDirection.N:
                    this.Y++;
                    break;
                case MoveDirection.S:
                    this.Y--;
                    break;
                case MoveDirection.E:
                    this.X++;
                    break;
                case MoveDirection.W:
                    this.X--;
                    break;
                default:
                    break;
            }
        }


        public void Move(List<int> upperRightCoordinates, string instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'M':
                        this.GoStraight();
                        break;
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;

                    default:
                        Console.WriteLine($"Encountered Invalid Move Character: '{instruction}'! Expected inputs are L, M, R");
                        throw new Exception($"Encountered Invalid Move Character: '{instruction}'! Expected inputs are L, M, R");
                }

                if (this.X < 0 || this.X > upperRightCoordinates[0] || this.Y < 0 || this.Y > upperRightCoordinates[1])
                {
                    throw new Exception($"Beyond the specified limit motion detected! Created plateau coordinates (0 , 0) and ({upperRightCoordinates[0]} , {upperRightCoordinates[1]})");
                }
            }
        }
    }
}
