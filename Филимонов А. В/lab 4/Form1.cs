using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessingLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Image files|*.jpeg;*.jpg;*.bmp;*.png;*.tiff|All files|*.*";
            if (fd.ShowDialog() != DialogResult.OK) return;
            pbSource.Load(fd.FileName);
            propertyGrid1.SelectedObject = pbSource.Image;
        }

        private void SaveImage(PictureBox sender)
        {
            var fd = new SaveFileDialog();
            fd.Filter = "Image files|*.jpeg;*.jpg;*.bmp;*.png;*.tiff|All files|*.*";
            if (fd.ShowDialog() != DialogResult.OK) return;
            sender.Image.Save(fd.FileName);
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabSource)
                SaveImage(pbSource);
            else
                SaveImage(pbDest);
        }

        private void convertToGreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ticks = Environment.TickCount;
            var bmp = ImageActions.Color2Grey_Unsafe(new Bitmap(pbSource.Image));
            ticks = Environment.TickCount - ticks;
            pbDest.Image = bmp;
            MessageBox.Show($"Elapsed time = {ticks} ms");
        }

        private void showFFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bmp = ImageActions.FFT2(new Bitmap(pbSource.Image));
            pbDest.Image = bmp;
        }

        private void gaussLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double sigma = 10;
            var bmp = ImageActions.FrequencyFilter(new Bitmap(pbSource.Image), sigma, true);
            pbDest.Image = bmp;
        }

        private void gaussHighpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double sigma = 10;
            var bmp = ImageActions.FrequencyFilter(new Bitmap(pbSource.Image), sigma, false);
            pbDest.Image = bmp;
        }

        private void spatialLowpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bmp = ImageActions.SpatialLowpassFilter(new Bitmap(pbSource.Image));
            pbDest.Image = bmp;
        }

        private void spatialHighpassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bmp = ImageActions.SpatialHighpassFilter(new Bitmap(pbSource.Image));
            pbDest.Image = bmp;
        }

        private void findFragmentSpatialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Image files|*.jpeg;*.jpg;*.bmp;*.png;*.tiff|All files|*.*";
            if (fd.ShowDialog() != DialogResult.OK) return;
            Bitmap filter = new Bitmap(fd.FileName);
            var (result, pos) = ImageActions.FindPositionSpatial(new Bitmap(pbSource.Image), filter);
            pbDest.Image = result;
            MessageBox.Show($"Fragment found at X={pos.X}, Y={pos.Y}");
        }

        private void findFragmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Image files|*.jpeg;*.jpg;*.bmp;*.png;*.tiff|All files|*.*";
            if (fd.ShowDialog() != DialogResult.OK) return;
            Bitmap filter = new Bitmap(fd.FileName);
            var (result, pos) = ImageActions.FindPosition(new Bitmap(pbSource.Image), filter);
            pbDest.Image = result;
            MessageBox.Show($"Fragment found at X={pos.X}, Y={pos.Y}");
        }
    }
}