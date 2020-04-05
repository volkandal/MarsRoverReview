using System;
using System.Linq;

namespace HB.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var upperRightCoordinates = Console.ReadLine().Trim().ToUpper().Split(' ').Select(int.Parse).ToList();

            #region Reading first rover start location and instructions 
            var roverOneStartLocation = Console.ReadLine().Trim().ToUpper().Split(' ');
            Location roverOneLocation = new Location();

            if (roverOneStartLocation.Length == 3)
            {
                roverOneLocation.X = int.Parse(roverOneStartLocation[0]);
                roverOneLocation.Y = Convert.ToInt32(roverOneStartLocation[1]);
                roverOneLocation.MoveDirection = (MoveDirection)Enum.Parse(typeof(MoveDirection), roverOneStartLocation[2]);
            }

            var roverOneInstructions = Console.ReadLine().ToUpper();
            #endregion

            #region Reading second rover start location and instructions 
            var roverTwoStartLocation = Console.ReadLine().Trim().ToUpper().Split(' ');
            Location roverTwoLocation = new Location();

            if (roverTwoStartLocation.Length == 3)
            {

                roverTwoLocation.X = int.Parse(roverTwoStartLocation[0]);
                roverTwoLocation.Y = Convert.ToInt32(roverTwoStartLocation[1]);
                roverTwoLocation.MoveDirection = (MoveDirection)Enum.Parse(typeof(MoveDirection), roverTwoStartLocation[2]);

            }

            var roverTwoInstructions = Console.ReadLine().ToUpper();
            #endregion

            try
            {
                roverOneLocation.Move(upperRightCoordinates, roverOneInstructions);
                roverTwoLocation.Move(upperRightCoordinates, roverTwoInstructions);

                Console.WriteLine("\nOutput:");
                Console.WriteLine($"{roverOneLocation.X} {roverOneLocation.Y} {roverOneLocation.MoveDirection.ToString()}");
                Console.WriteLine($"{roverTwoLocation.X} {roverTwoLocation.Y} {roverTwoLocation.MoveDirection.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
