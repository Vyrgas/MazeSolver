using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// Abstract class for solving mazes
    /// </summary>
    public abstract class Solver
    {
        #region Public properties

        //Logger for logging messages.
        public List<ILogger> Loggers { get; set; }

        /// <summary>
        /// Width of the maze.
        /// </summary>
        public int Width { get; protected set; } = 0;

        /// <summary>
        /// Height of the maze.
        /// </summary>
        public int Height { get; protected set; } = 0;

        #endregion

        public Solver(List<ILogger> loggers)
        {
            Loggers = loggers;
        }

        public abstract bool Solve();
    }
}
