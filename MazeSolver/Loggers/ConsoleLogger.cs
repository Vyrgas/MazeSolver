using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// Logger for writing messages to standard console window.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs the message to the console window.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
