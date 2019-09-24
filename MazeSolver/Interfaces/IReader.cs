using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// Interface for reading messages from the provided source.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads all the messages from the provided data source into List of string lists.
        /// </summary>
        /// <param name="source">Data source string.</param>
        /// <returns>Collection of read messages.</returns>
        List<List<int>> Read(string source);
    }
}
