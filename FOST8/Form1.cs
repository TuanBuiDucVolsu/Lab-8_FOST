using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOST8
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1, bitmap2, bitmap3;
        Grapher grapher;

        public Form1()
        {
            InitializeComponent();
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmap2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            bitmap3 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics graphics = Graphics.FromImage(bitmap1);
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            Graphics graphics3 = Graphics.FromImage(bitmap3);
            grapher = new Grapher { Graphics1 = graphics, Scale1 = 1.0, imX10 = (int)(pictureBox1.Width * 0.5), imY10 = (int)(pictureBox1.Height * 0.5),
            Graphics2 = graphics2, Graphics3 = graphics3};
            grapher.Clear(); 
            pictureBox1.Image = bitmap1;
            pictureBox2.Image = bitmap2;
            pictureBox3.Image = bitmap3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap3.RotateFlip(RotateFlipType.Rotate180FlipX);
                grapher.Clear();
                grapher.Build(double.Parse(qTextBox.Text),
                    double.Parse(mTextBox.Text),
                    new Vector3 { X = double.Parse(v0xTextBox.Text), Y = 0, Z = double.Parse(v0zTextBox.Text) },
                    new Vector3 { X = 0, Y = 0, Z = double.Parse(BTextBox.Text) },
                    double.Parse(dtTextBox.Text),
                    double.Parse(TmaxTextBox.Text));
                bitmap1.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap2.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap3.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox1.Image = bitmap1;
                pictureBox2.Image = bitmap2;
                pictureBox3.Image = bitmap3;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("OverflowException!");
            }
            catch 
            {
                MessageBox.Show("Something went wrong!");
            }
        }
         

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            grapher.Scale1 = trackBar1.Value;
        }
         
    }
}
