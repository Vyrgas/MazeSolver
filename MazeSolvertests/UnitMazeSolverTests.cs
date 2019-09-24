using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

using MazeSolver;

namespace MazeSolverTests
{
    public class UnitMazeSolverTests
    {
        private readonly List<List<int>> data1 = new List<List<int>>()
            {
                new List<int>(){4, 4},
                new List<int>(){1, 1, 1, 1},
                new List<int>(){0, 0, 2, 1},
                new List<int>(){1, 1, 0, 0},
                new List<int>(){1, 1, 1, 1}
            };

        private readonly List<List<int>> data2 = new List<List<int>>()
            {
                new List<int>() {10, 10 },
                new List<int>() {1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new List<int>() {0, 0, 0, 1, 1, 0, 1, 1, 1, 1 },
                new List<int>() {1, 1, 0, 0, 1, 0, 1, 1, 1, 1 },
                new List<int>() {1, 1, 1, 0, 0, 0, 0, 0, 2, 1 },
                new List<int>() {1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                new List<int>() {1, 1, 1, 0, 1, 1, 0, 0, 0, 1 },
                new List<int>() {1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                new List<int>() {1, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                new List<int>() {1, 1, 1, 1, 1, 1, 1, 0, 1, 1 },
                new List<int>() {1, 1, 1, 1, 1, 1, 1, 0, 1, 1 }
            };

        [Fact]
        public void ChangeMazeStartPosition()
        {
            MazeSolver.MazeSolver mazeRun = new MazeSolver.MazeSolver(new List<ILogger> { new FakeLogger() }, data1)
            {
                StartPt = new Point(1, 1)
            };

            Assert.Equal(new Point(1, 1), mazeRun.StartPt);

            mazeRun.StartPt = new Point(1, 2);

            Assert.Equal(new Point(1, 2), mazeRun.StartPt);

            mazeRun.StartPt = new Point(2, 1);

            Assert.Equal(new Point(2, 1), mazeRun.StartPt);

            mazeRun.StartPt = new Point(2, 2);

            Assert.Equal(new Point(2, 2), mazeRun.StartPt);
        }

        [Fact]
        public void SolveMazeWithProvidedData()
        {
            MazeSolver.MazeSolver mazeSolver = new MazeSolver.MazeSolver(new List<ILogger> { new FakeLogger() }, data2);
            bool result = mazeSolver.Solve();

            Assert.True(result);
        }

        [Fact]
        public void SolveMazeWithNewPoint()
        {
            MazeSolver.MazeSolver mazeSolver = new MazeSolver.MazeSolver(new List<ILogger> { new FakeLogger() }, data2);
            mazeSolver.StartPt = new Point(6, 1);
            bool result = mazeSolver.Solve();

            Assert.True(result);
        }
    }
}
