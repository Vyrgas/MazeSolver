using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// Class for reading maze data from a given text file.
    /// </summary>
    public class FileReader : IReader
    {
        /// <summary>
        /// Reads all the messages from the provided file path into List of string lists
        /// where each element of a list contains a single line characters of a file.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<List<int>> Read(string source)
        {
            List<List<int>> data = new List<List<int>>();

            try
            {
                foreach (var line in File.ReadLines(@source))
                {
                    data.Add(new List<int>(line?.Split(' ')?.Select(s => int.Parse(s))));
                }
            }
            catch (UnauthorizedAccessException uEx)
            {
                Console.WriteLine($"You do not have sufficient rights to access file '{source}'. Exception: {uEx.ToString()}");
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine($"File path '{source}' is too long. Exception: {pathEx.Message}");
            }
            catch (FormatException forEx)
            {
                Console.WriteLine($"Failed to convert string value to integer from file '{source}'. Exception: {forEx.Message}");
            }

            return data;
        }
    }
}
