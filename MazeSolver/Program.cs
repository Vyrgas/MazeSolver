using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> data = new FileReader().Read("RPAMaze.txt");
            ILogger logger = new ConsoleLogger();

            foreach (var list in data)
            {
                string msg = string.Empty;

                foreach (var item in list)
                {
                    msg += $"{item.ToString()} ";
                }

                logger.Log(msg);
            }

            logger.Log(Environment.NewLine);

            Solver mazeSolver = new MazeSolver(new List<ILogger>{
                logger,
                new FileLogger()
            },
            data
            );

            bool result = mazeSolver.Solve();
            logger.Log($"Maze is solveble: {result.ToString()}");
            logger.Log("Press any key to exit the program...");
            Console.ReadKey();
        }
    }
}
