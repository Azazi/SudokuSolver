using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parser
{
    /// <summary>
    /// Helper parser class.
    /// </summary>
    public static class SParser
    {
        // Global constants
        private static int ZERO = 48;
        private static int NINE = 57;
        private static int DOT = 46;

        /// <summary>
        /// Parses the file contents into an object of type SBoard.
        /// </summary>
        /// <param name="fileName">Name and path of the file to be parsed.</param>
        /// <returns>A board object containing the puzzle data.</returns>
        public static SBoard parseFile(string fileName)
        {
            string input = File.ReadAllText(fileName);
            SBoard board = new SBoard();
            
            int currentCharIndex = 0;

            for (int row = 0; row < SBoard.ROW_SIZE; row++)
            {
                for (int col = 0; col < SBoard.COL_SIZE; col++)
                {
                    int value = -1;
                    while (value == -1)
                    {
                        if (input[currentCharIndex] >= ZERO && input[currentCharIndex] <= NINE)
                        {
                            int.TryParse(input[currentCharIndex].ToString(), out value);
                        }
                        else if (input[currentCharIndex] == DOT)
                        {
                            value = 0;
                        }
                        currentCharIndex++;
                    }
                    board.setCell(value, row, col);
                }
            }

            return board;
        }
    }
}
