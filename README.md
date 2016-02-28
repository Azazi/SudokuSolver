# SudokuSolver
A WPF application to solve Sudoku puzzles.

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Empty.png)

Sudoku Solver is an application that allows its users to solve Sudoku puzzles. The user can either type in the known values or load the board from a file. The board file format uses the digits 1 to 9 with a period or a 0 to mean the cell is blank. Any other characters in the file should be ignored. Example board file contents are:

4 . . | . . . | 8 . 5
. 3 . | . . . | . . .
. . . | 7 . . | . . .
------+-------+------
. 2 . | . . . | . 6 .
. . . | . 8 . | 4 . .
. . . | . 1 . | . . .
------+-------+------
. . . | 6 . 3 | . 7 .
5 . . | 2 . . | . . .
1 . 4 | . . . | . . .

or

400000805
030000000
000700000
020000060
000080400
000010000
000603070
500200000
104000000

or

4.....8.5.3..........7......2.....6.....8.4......1.......6.3.7.5..2.....1.4......

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Load.png)
Loading an input file.

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Loaded.png)
Input file loaded into the board.

Clicking the "Solve Game" button will start the solving process. The process of finding a solution does not block the UI, and the user can cancel the process, clear the board, or manually type in new values into the board to speed up the solving process. 

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Solved.png)
Solution found!

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Manual.png)
Manual Input

![alt tag](https://github.com/Azazi/SudokuSolver/blob/master/Tutorial/Unsolvable.png)
Unsolvable input
