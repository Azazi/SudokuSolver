using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku.View
{
    /// <summary>
    /// Interaction logic for SBoardControl.xaml
    /// </summary>
    public partial class SBoardControl : UserControl
    {
        /// <summary>
        /// A board of cell controls to hold the game board.
        /// </summary>
        public SCellControl[,] boardControl;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SBoardControl()
        {
            InitializeComponent();
            this.emptyBoardControl();
        }

        #region Helper methods

        /// <summary>
        /// Creates an empty board of cell controls to hold the game board.
        /// </summary>
        public void emptyBoardControl()
        {
            this.boardControl = new SCellControl[SBoard.ROW_SIZE, SBoard.COL_SIZE];

            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    // Initialize the cell at row and column with contrasting colors
                    this.boardControl[row, col] = new SCellControl(((col + row) % 2 == 0) ? Brushes.Wheat : Brushes.White);

                    // Set the row and column on the UI
                    Grid.SetRow(this.boardControl[row, col], row / SBoard.BOX_SIZE + row);
                    Grid.SetColumn(this.boardControl[row, col], col / SBoard.BOX_SIZE + col);
                    boardGrid.Children.Add(this.boardControl[row, col]);
                }
            }
        }

        #endregion

        #region Mutators & accessors

        /// <summary>
        /// Updates the board cell controls using the model board object.
        /// </summary>
        /// <param name="board">Board model object containing the board data.</param>
        public void updateBoard(SBoard board)
        {
            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    boardControl[row, col].setValue(board.getCell(row, col).Value);
                }
            }
        }

        /// <summary>
        /// Returns the up-to-date version of the game board.
        /// </summary>
        /// <returns>The up-to-date version of the game board.</returns>
        public SBoard getUpdatedBoard()
        {
            SBoard updatedBoard = new SBoard();

            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    updatedBoard.setCell(boardControl[row, col].getValue(), row, col);
                }
            }

            return updatedBoard;
        }

        #endregion
    }
}
