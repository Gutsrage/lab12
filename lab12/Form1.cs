using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        Bitmap bmp;
        Image image;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = openFileDialog1;
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(dialog.FileName);
                pictureBox1.Image = image;
                bmp = new Bitmap(image);
            }
            else
                MessageBox.Show("Картинка не выбрана");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int porog = trackBar1.Value;
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    if (radioButton1.Checked)
                    {

                        if (color.R > porog)
                            bmp.SetPixel(i, j, Color.White);
                        else
                            bmp.SetPixel(i, j, Color.Black);
                    }
                    else if (radioButton2.Checked)
                    {

                        if (color.G > porog)
                            bmp.SetPixel(i, j, Color.White);
                        else
                            bmp.SetPixel(i, j, Color.Black);
                    }
                    else if (radioButton3.Checked)
                    {

                        if (color.B > porog)
                            bmp.SetPixel(i, j, Color.White);
                        else
                            bmp.SetPixel(i, j, Color.Black);
                    }
                }
            pictureBox1.Image=bmp;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
