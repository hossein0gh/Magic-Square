using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using magic_square;

namespace magic_square
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (textBox_input.Text == string.Empty)
            {
                output.Rows.Clear();
                sum_txtbox.Text = string.Empty;
                return;
            }
            int n  = int.Parse(textBox_input.Text);
            int[,] nums;
            output.ColumnCount = n;
            output.RowCount = n;
            if (n % 4 == 2)
            {
                if(n==2)
                {
                    MessageBox.Show("input is not valid!", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_input.Text=string.Empty;
                    sum_txtbox.Text = string.Empty;
                    output.Rows.Clear();
                    return;
                }
                nums = magic_square.EvenSquare2(n);
            }
            else if (n % 4 == 0)
                nums = magic_square.EvenSquare1(n);
            else
                nums = magic_square.OddSquare(n);

            #region square style
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    output.Rows[i].Cells[j].Value = nums[i, j];
                    if (i % 2 == 0)
                    {
                        output.Rows[i].Cells[j].Style.BackColor = Color.Navy;
                        output.Rows[i].Cells[j].Style.ForeColor = Color.White;
                    }
                    if (i % 2 != 0)
                    {
                        output.Rows[i].Cells[j].Style.BackColor = Color.LightSeaGreen;
                        output.Rows[i].Cells[j].Style.ForeColor = Color.Black;

                    }
                }
            }
            #endregion

            // sum of each row,column or diaginal
            int sum ;
            sum = n * (n * n + 1) / 2;
            sum_txtbox.Text = sum.ToString();
        }

        private void textBox_input_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
                
        }

        private void textBox_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_show.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
