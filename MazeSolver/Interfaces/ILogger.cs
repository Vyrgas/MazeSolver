using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// Interface for logging messages to the provided log.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="message">A message to write.</param>
        void Log(string message);
    }
}
