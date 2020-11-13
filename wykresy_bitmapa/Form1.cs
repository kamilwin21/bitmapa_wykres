using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wykresy_bitmapa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // label1.Content = openFileDialog.FileName;
                // img1.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                Bitmap bm = new Bitmap(Image.FromFile(openFileDialog.FileName));
                Bitmap jasnosc = new Bitmap(Image.FromFile(openFileDialog.FileName));
                int x, y;
                int v1 = 0, v2, v3;
                double s;
               
                int[] tabR = new int[256];
                int[] tabG = new int[256];
                int[] tabB = new int[256];

                pictureBox1.Image = bm;


                
                for (x = 0; x < bm.Width; x++)
                {
                    for (y = 0; y < bm.Height; y++)
                    {
                        Color pixelColor = bm.GetPixel(x, y);


                        int r = pixelColor.R;
                        int g = pixelColor.G;
                        int b = pixelColor.B;
                        tabR[r]++;
                        tabG[g]++;
                        tabB[b]++;

      
                    }
                }
                int maxR = tabR.Max()/100;
                int maxG = tabG.Max() /100;
                int maxB = tabB.Max() /100;
                for (int i=0;i<tabR.Length;i++)
                {
                    tabR[i] /= maxR;
                    tabG[i] /= maxG;
                    tabB[i] /= maxB;

                }

                chart1.Series[0].Points.Clear();
                chart2.Series["Green"].Points.Clear();
                chart3.Series["Blue"].Points.Clear();
                chart4.Series["R"].Points.Clear();
                chart4.Series["G"].Points.Clear();
                chart4.Series["B"].Points.Clear();
                for (int i = 0; i < 255; i++)
                {
                    chart1.Series[0].Points.AddXY(i, tabR[i]);
                    chart2.Series["Green"].Points.AddXY(i, tabG[i]);
                    chart3.Series["Blue"].Points.AddXY(i, tabB[i]);
                    chart4.Series["R"].Points.AddXY(i, tabR[i]);
                    chart4.Series["G"].Points.AddXY(i, tabG[i]);
                    chart4.Series["B"].Points.AddXY(i, tabB[i]);
                }
                chart1.Invalidate();



            }
        }
    }
}