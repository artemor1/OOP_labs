using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab_3
{
    
    public static class GridHelper
    {
        public static void PutMatrixInGrid(DataGridView grid, Matrix<double> matrix)
        {
            grid.SuspendLayout();

            grid.Columns.Clear();
            grid.Rows.Clear();

            int rows = matrix.RowCount;
            int cols = matrix.ColumnCount;

            try
            {
                for (int j = 0; j < cols; j++)
                {
                    grid.Columns.Add($"C{j}", $"C{j}");
                }
            }
            catch
            {
                Debug.WriteLine($"[Data Grid] Couldn't put matrix into grid ");
            }
            for (int i = 0; i < rows; i++)
            {
                object[] row = new object[cols];

                for (int j = 0; j < cols; j++)
                {
                    row[j] = matrix[i, j];
                }

                grid.Rows.Add(row);
            }

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;

            grid.ResumeLayout();
        }
    }
}
