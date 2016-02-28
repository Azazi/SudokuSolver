using Microsoft.Win32;
using Sudoku.Model;
using Sudoku.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The game board model.
        /// </summary>
        private SBoard gameBoard;

        /// <summary>
        /// The game solver object.
        /// </summary>
        private SSolver solver;

        /// <summary>
        /// The solving process result flag.
        /// </summary>
        private bool success;

        /// <summary>
        /// The background worker used to avoid blocking the UI.
        /// </summary>
        private BackgroundWorker bw = new BackgroundWorker();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Setup the background worker
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

        }

        #region Background worker

        /// <summary>
        /// Event handler for the work completed event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Completed event arguments.</param>
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check if this is a previous worker
            if (this.solveGameButton.Content.Equals("Solve Game")) return;

            // Update the button text
            this.solveGameButton.Content = "Solve Game";

            // Update the gameboard and the control if the board is solvable
            if (success)
            {
                this.gameBoard = solver.board;
                this.boardControl.updateBoard(this.gameBoard);

                // Update the status label
                this.statusLabel.Content = "Solved!";
            }
            else
            {
                // Update the status label
                this.statusLabel.Content = "Unsolvable!";
            }
        }

        /// <summary>
        /// Event handler for the work event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Solve the board
            this.success = solver.solveBoard();
        }

        /// <summary>
        /// Disposes of and reinstantiates the current background worker.
        /// </summary>
        private void disposeBackgroundWorker()
        {
            // Dispose of the background worker
            bw.CancelAsync();
            bw.Dispose();
            bw = null;
            GC.Collect();

            // Reinstantiate the background worker
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        #endregion

        #region helper methods

        /// <summary>
        /// Updates the game board from a file.
        /// </summary>
        /// <param name="fileName">Name and path of the file to load the game from.</param>
        private void updateGameBoardFromFile(string fileName)
        {
            this.gameBoard = SParser.parseFile(fileName);
            this.boardControl.updateBoard(this.gameBoard);
        }

        #endregion

        #region button click handlers

        /// <summary>
        /// Handles showing the filer browser dialoge & selecting an 
        /// input file.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Routed event arguments.</param>
        private void loadGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the status label
            this.statusLabel.Content = "";

            // Create an open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the dialog options
            openFileDialog.Multiselect = false;
            openFileDialog.FilterIndex = 1;

            // Show the open file dialog
            bool? fileSelected = openFileDialog.ShowDialog();

            // Wait for user's input
            if (fileSelected == true)
            {
                // Read the file contents to the gameBoard
                this.updateGameBoardFromFile(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles solving the gameboard.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Routed event arguments.</param>
        private void solveGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Change button text
            if (solveGameButton.Content.Equals("Cancel")) this.solveGameButton.Content = "Solve Game";
            else this.solveGameButton.Content = "Cancel";

            // Get the updated gameboard from the board control 
            this.gameBoard = this.boardControl.getUpdatedBoard();

            // Solve the gameboard
            this.solver = new SSolver(this.gameBoard);

            // Update the status label
            this.statusLabel.Content = "Solving...";

            // Check if the background worker is already running. Run
            // the solver on the background worker otherwise
            if (bw.IsBusy)
            {
                // Dispose of the current background worker and stop
                // the thread
                this.disposeBackgroundWorker();
                this.statusLabel.Content = "Canceled!";
            }
            else bw.RunWorkerAsync();
        }

        /// <summary>
        /// Handles clearing the gameboard.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Routed event arguments.</param>
        private void clearBoardButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the background worker
            if (bw.IsBusy)
            {
                this.disposeBackgroundWorker();
                this.solveGameButton.Content = "Solve Game";
            }

            // Resets the game board control
            this.boardControl.emptyBoardControl();

            // Reset the status label
            this.statusLabel.Content = "";
        }

        #endregion
    }
}
