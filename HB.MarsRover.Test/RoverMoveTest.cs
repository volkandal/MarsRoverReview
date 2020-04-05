using NUnit.Framework;
using System.Collections.Generic;

namespace HB.MarsRover.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TS_12N_LMLMLMLMM()
        {
            Location location = new Location()
            {
                X = 1,
                Y = 2,
                MoveDirection = MoveDirection.N
            };

            var upperRightCoordinates = new List<int> { 5, 5 };
            var instructions = "LMLMLMLMM";

            location.Move(upperRightCoordinates, instructions);

            var output = $"{location.X} {location.Y} {location.MoveDirection.ToString()}";
            var expected = "1 3 N";

            Assert.AreEqual(output, expected);
        }

        [Test]
        public void TS_33E_MMRMMRMRRM()
        {
            Location location = new Location()
            {
                X = 3,
                Y = 3,
                MoveDirection = MoveDirection.E
            };

            var upperRightCoordinates = new List<int> { 5, 5 };
            var instructions = "MMRMMRMRRM";

            location.Move(upperRightCoordinates, instructions);

            var output = $"{location.X} {location.Y} {location.MoveDirection.ToString()}";
            var expected = "5 1 E";

            Assert.AreEqual(output, expected);
        }
    }
}