using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    /// <summary>
    /// Solver class.
    /// </summary>
    public class SSolver
    {
        /// <summary>
        /// Board object storing the state of the game board.
        /// </summary>
        public SBoard board;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="board">A board object storing the state of the game.</param>
        public SSolver(SBoard board)
        {
            this.board = board;
        }

        /// <summary>
        /// Attempts to solve the current game board.
        /// </summary>
        /// <returns>Returns true if the solving process is successful. Returns false otherwise.</returns>
        public Boolean solveBoard()
        {
            if (this.isBoardValid()) return this.solve();
            return false;
        }

        #region Helper methods

        /// <summary>
        /// Checks if a suggested value makes a valid board if inserted into the provided row and column.
        /// </summary>
        /// <param name="suggestedValue">Suggested value for the cell.</param>
        /// <param name="row">Row on which the cell is.</param>
        /// <param name="col">Column on which the cell is.</param>
        /// <returns>Returns true if the value makes a valid board. Returns false otherwise.</returns>
        private Boolean isValid(int suggestedValue, int row, int col)
        {
            int r = (row / SBoard.BOX_SIZE) * SBoard.BOX_SIZE;
            int c = (col / SBoard.BOX_SIZE) * SBoard.BOX_SIZE;

            for (int i = 0; i < SBoard.ROW_SIZE; i++)
            {
                if((i != col && board.getCell(row, i).Value == suggestedValue) ||
                   (i != row && board.getCell(i, col).Value == suggestedValue) ||
                   ((r + (i % SBoard.BOX_SIZE)) != row && (c + (i / SBoard.BOX_SIZE)) != col && board.getCell(r + (i % SBoard.BOX_SIZE), c + (i / SBoard.BOX_SIZE)).Value == suggestedValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to solve the current game board using a recursive brute-force algorithm.
        /// </summary>
        /// <returns>Returns true if there is a valid solution to the board. Returns false otherwise.</returns>
        private Boolean solve()
        {
            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    if (this.board.getCell(row, col).isEmpty)
                    {
                        for (int suggestedValue = 1; suggestedValue <= 9; suggestedValue++)
                        {
                            this.board.setCell(suggestedValue, row, col);
                            if (this.isValid(suggestedValue, row, col) && this.solve()) return true;
                            else { this.board.setCell(0, row, col); }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the current board state is valid.
        /// </summary>
        /// <returns>Returns true if the board state is valid. Returns false otherwise.</returns>
        private Boolean isBoardValid()
        {
            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    if (!this.board.getCell(row, col).isEmpty)
                    {
                        if (!this.isValid(this.board.getCell(row, col).Value, row, col)) return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
