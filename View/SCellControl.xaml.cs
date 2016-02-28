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
    /// Interaction logic for SCellControl.xaml
    /// </summary>
    public partial class SCellControl : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="background">Background color to assign to the cell control.</param>
        public SCellControl(Brush background)
        {
            InitializeComponent();
            cellTextBox.Background = background;
        }

        #region Accessors & mutators

        /// <summary>
        /// Sets the value of the cell control to the provided value.
        /// </summary>
        /// <param name="value">Value to set the cell control to.</param>
        public void setValue(int value)
        {
            if (value == 0) cellTextBox.Text = "";
            else cellTextBox.Text = value.ToString();
        }

        /// <summary>
        /// Returns the value of the cell control.
        /// </summary>
        /// <returns>Value of the cell control.</returns>
        public int getValue()
        {
            if (cellTextBox.Text == "") return 0;
            else return int.Parse(cellTextBox.Text);
        }

        #endregion

        #region error checking

        /// <summary>
        /// Ensures that only digits 1 through 9 are accepted as values for the cell control.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void cellTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cellTextBox.Text.Length == 0) return;
            else if (cellTextBox.Text.Length > 1) cellTextBox.Text = "";
            else if (!char.IsDigit(cellTextBox.Text[0])) cellTextBox.Text = "";
        }

        #endregion
    }
}
