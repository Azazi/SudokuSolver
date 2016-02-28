using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    /// <summary>
    /// Game cell object.
    /// </summary>
    public class SCell
    {
        /// <summary>
        /// A boolean flag indicating whether or not the current cell is empty.
        /// </summary>
        public bool isEmpty;
        
        /// <summary>
        /// The value stored at the current cell.
        /// </summary>
        private int value;
        public int Value
        {
            set
            {
                this.value = value;
                this.isEmpty = (0 == value) ? true : false;
            }

            get { return this.value; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SCell()
        {
            this.Value = 0;
        }

        /// <summary>
        /// Constructor taking a value as an argument.
        /// </summary>
        /// <param name="value">Value to assign to the current cell.</param>
        public SCell(int value)
        {
            this.Value = value;
        }
    }
}
