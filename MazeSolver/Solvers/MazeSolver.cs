using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MazeSolver : Solver
    {
        #region Private fields

        /// <summary>
        /// starting point of the maze.
        /// </summary>
        private Point startPt;

        /// <summary>
        /// The maze array itself.
        /// </summary>
        private int[,] maze;

        /// <summary>
        /// Visited positions of the maze.
        /// </summary>
        private bool[,] wasHere;

        /// <summary>
        /// The solution to the maze.
        /// </summary>
        private bool[,] correctPath;

        /// <summary>
        /// End points of the maze.
        /// </summary>
        private readonly List<Point> endPoints = new List<Point>();

        #endregion

        #region Properties

        /// <summary>
        /// Starting position of the maze.
        /// </summary>
        public Point StartPt
        {
            get { return startPt; }

            set
            {
                startPt = value;

                maze[value.X, value.Y] = 2;
                wasHere = new bool[Width, Height];
                correctPath = new bool[Width, Height];
            }
        }

        #endregion

        // The maze


        public MazeSolver(List<ILogger> loggers, List<List<int>> data) : base(loggers)
        {
            InitializeData(data);
        }

        /// <summary>
        /// Initializes MazeSolver properties from a given  list of integer lists.
        /// Where first element of the list represents starting X and Y positions
        /// of the maze.
        /// </summary>
        /// <param name="data"></param>
        private void InitializeData(List<List<int>> data)
        {
            if (data?.Count > 0)
            {
                List<int> size = data[0];
                Width = size[0];
                Height = size[1];
                maze = new int[Width, Height];
                wasHere = new bool[Width, Height];
                correctPath = new bool[Width, Height];
                FindEndPoints(data);
            }

            for (int row = 1; row < Height + 1; row++)
            {
                // Sets boolean Arrays to default values
                for (int col = 0; col < Width; col++)
                {
                    int cellValue = data[row][col];

                    if (cellValue == 2)
                    {
                        StartPt = new Point(row - 1, col);
                    }

                    maze[row - 1, col] = cellValue;
                    wasHere[row - 1, col] = false;
                    correctPath[row - 1, col] = false;
                }
            }
        }

        #region Public methods
        public override bool Solve()
        {
            // Will leave you with a boolean array (correctPath) 
            // with the path indicated by true values.
            // If returns false, there is no solution to the maze.
            Loggers.ForEach(log => log.Log($"Starting maze solver at location: {StartPt.ToString()}"));

            return RecursiveSolve(StartPt.X, StartPt.Y);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Finds end points of the maze by checking edges: Top, Right, Bottom and Left.
        /// </summary>
        /// <param name="data"></param>
        private void FindEndPoints(List<List<int>> data)
        {
            //Check for end points on top wall of the maze
            List<int> side = data[1];

            for (int i = 0; i < Width; i++)
            {
                int value = side[i];

                if (value == 0)
                {
                    endPoints.Add(new Point(0, i));
                }
            }

            //Check for end points on the bottom wall of the maze
            side = data[Height];

            for (int i = 0; i < Width; i++)
            {
                int value = side[i];

                if (value == 0)
                {
                    endPoints.Add(new Point(Height - 1, i));
                }
            }

            //Check for end points on the left wall of the maze
            for (int i = 1; i < Height + 1; i++)
            {
                int value = data[i][0];

                if (value == 0)
                {
                    endPoints.Add(new Point(i - 1, 0));
                }
            }

            //Check for end points on the right wall of the maze
            for (int i = 1; i < Height + 1; i++)
            {
                int value = data[i][Width - 1];

                if (value == 0)
                {
                    endPoints.Add(new Point(i, Width - 1));
                }
            }
        }

        /// <summary>
        /// Recursively solves the given maze by starting at the specified location
        /// provided by integer X and Y arguments.
        /// </summary>
        /// <param name="x">X coordinate of the starting position.</param>
        /// <param name="y">Y coordinate of the starting position.</param>
        /// <returns>Success of the operation.</returns>
        private bool RecursiveSolve(int x, int y)
        {
            // If you reached the end
            foreach (var pt in endPoints)
            {
                if (x == pt.X && y == pt.Y)
                {
                    correctPath[x, y] = true;
                    Loggers.ForEach(log => log.Log($"Step to: x = {x.ToString()}, y = {y.ToString()}"));

                    return true;
                }
            }

            if (maze[x, y] == 1 || wasHere[x, y])
            {
                return false;
            }

            // If you are on a wall or already were here
            wasHere[x, y] = true;

            // Checks if not on left edge
            if (x != 0)
            {
                if (RecursiveSolve(x - 1, y))
                { // Recalls method one to the left
                    correctPath[x, y] = true; // Sets that path value to true;
                    Loggers.ForEach(log => log.Log($"Step to: x = {x.ToString()}, y = {y.ToString()}"));

                    return true;
                }
            }

            // Checks if not on right edge
            if (x != Width - 1)
            {
                if (RecursiveSolve(x + 1, y))
                { // Recalls method one to the right
                    correctPath[x, y] = true;
                    Loggers.ForEach(log => log.Log($"Step to: x = {x.ToString()}, y = {y.ToString()}"));

                    return true;
                }
            }

            // Checks if not on top edge
            if (y != 0)
            {
                if (RecursiveSolve(x, y - 1))
                { // Recalls method one up
                    correctPath[x, y] = true;
                    Loggers.ForEach(log => log.Log($"Step to: x = {x.ToString()}, y = {y.ToString()}"));

                    return true;
                }
            }

            // Checks if not on bottom edge
            if (y != Height - 1)
            {
                if (RecursiveSolve(x, y + 1))
                { // Recalls method one down
                    correctPath[x, y] = true;
                    Loggers.ForEach(log => log.Log($"Step to: x = {x.ToString()}, y = {y.ToString()}"));

                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
