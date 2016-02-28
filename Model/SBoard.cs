using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    /// <summary>
    /// Game board object.
    /// </summary>
    public class SBoard
    {
        // Global constants
        public const int ROW_SIZE = 9;
        public const int COL_SIZE = 9;
        public const int BOX_SIZE = 3;

        /// <summary>
        /// Array of cell objects which form the game board.
        /// </summary>
        private SCell[,] board;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SBoard()
        {
            // Initialize the game board object.
            this.board = new SCell[ROW_SIZE, COL_SIZE];
            for (int row = 0; row < ROW_SIZE; row++)
            {
                for (int col = 0; col < COL_SIZE; col++)
                {
                    this.board[row, col] = new SCell();
                }
            }
        }

        /// <summary>
        /// Constructor taking a board as an argument.
        /// </summary>
        /// <param name="board">Game board used to build this board object.</param>
        public SBoard(SCell[,] board)
        {
            this.board = board;
        }

        #region Accessors & mutators

        /// <summary>
        /// Sets the cell at the specified row and column to the given value.
        /// </summary>
        /// <param name="value">Value to set the cell to.</param>
        /// <param name="row">The row on which the cell is.</param>
        /// <param name="col">The column on which the cell is.</param>
        public void setCell(int value, int row, int col)
        {
            this.board[row, col].Value = value;
        }

        /// <summary>
        /// Returns the cell object the specified row and column.
        /// </summary>
        /// <param name="row">The row on which the cell is.</param>
        /// <param name="col">The column on which the cell is.</param>
        /// <returns></returns>
        public SCell getCell(int row, int col)
        {
            return this.board[row, col];
        }

        #endregion
    }
}
