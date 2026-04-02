using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using System.Windows.Forms;

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

            for (int j = 0; j < cols; j++)
            {
                grid.Columns.Add($"C{j}", $"C{j}");
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
