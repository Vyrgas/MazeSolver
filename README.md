# MazeSolver

This is a maze solving application which uses recursion for solving the maze. There is given an example data file [RPAMaze.txt]("MazeSolver/MazeSolver/RPAMaze.txt"). Where the first line contains maze height (10) and width (10). Next ten lines are maze representation as two-dimensional array. Wall tiles are marked with 1, path tiles are marked with 0 and start position is 
marked with 2.

The application:
 When application starts, it prints a maze from text file into console.
 Application can work with any start position which could be set in an example text file placing
  number 2 in a desired position or from the code using MaseSolver.StartPt.
 Moves to exit are made in four directions: top, right, bottom, left.
 While application works, it prints moves directions into console (in reversed order - from end to start point).
 Maze solving application stops, when one from two exits was found.
 Application creates "Log.txt" file in the same directory as "MazeSolver.exe" application, which contains the trail
  (in reversed order - from end to start point).
 Application can work with any size of maze as it is set by the first line of the example file.
 A few tests with xUnit framework were written for showing the MazeSolver can work with different maze size,
  the StartPoint of a maze can be set at any time using MazeSolver.StartPt property and after setting StartPoint
  and calling MazeSolver.Solve() method solves the maze from the new given point.
