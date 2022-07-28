using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace Randomness_Education00
{


    public partial class Form1 : Form
    {
        public BitmapData [] dice= new BitmapData [7];
        public Bitmap[] bmp_dice = new Bitmap[7];

        public Form1()
        {
            InitializeComponent();

            bmp_dice[0] = Properties.Resources._0;
            //dice[0] = bmp_dice[0].LockBits(new Rectangle(0, 0, bmp_dice[0].Width, bmp_dice[0].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[1] = Properties.Resources._1;
            //dice[1] = bmp_dice[1].LockBits(new Rectangle(0, 0, bmp_dice[1].Width, bmp_dice[1].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[2] = Properties.Resources._2;
            //dice[2] = bmp_dice[2].LockBits(new Rectangle(0, 0, bmp_dice[2].Width, bmp_dice[2].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[3] = Properties.Resources._3;
            //dice[3] = bmp_dice[3].LockBits(new Rectangle(0, 0, bmp_dice[3].Width, bmp_dice[3].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[4] = Properties.Resources._4;
            //dice[4] = bmp_dice[4].LockBits(new Rectangle(0, 0, bmp_dice[4].Width, bmp_dice[4].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[5] = Properties.Resources._5;
            //dice[5] = bmp_dice[5].LockBits(new Rectangle(0, 0, bmp_dice[5].Width, bmp_dice[5].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            bmp_dice[6] = Properties.Resources._6;
            //dice[6] = bmp_dice[6].LockBits(new Rectangle(0, 0, bmp_dice[6].Width, bmp_dice[6].Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            chart1.Series[0].IsVisibleInLegend = false;

        }

        public int[] hist = new int[100];
        private void button1_Click(object sender, EventArgs e)
        {

            //サイコロをふる
            int[,] number = new int[10, 10];
            int[] count = new int[7];

            Random rnd = new System.Random();
            for (int dice_y = 0; dice_y < 10; dice_y++)
            {
                for (int dice_x = 0; dice_x < 10; dice_x++)
                {
                    int intResult = rnd.Next(1, 7);
                    number[dice_x, dice_y] = intResult;
                    count[intResult]++;
                }
            }

            hist[count[1]]++;


            for(int i =0;i<100;i++)
            {
                chart1.Series[0].Points.AddXY(i, hist[i]);
            }

            Graphics g = pictureBox1.CreateGraphics();
            for(int i=0; i<10;i++)
            {
                for(int j=0; j<10;j++)
                {
                    g.DrawImage(bmp_dice[number[j, i]], 30 * (j+1), 30 * (i+1), 20,20);
                }
            }

            for(int i=1; i<7; i++)
            {
                textBox2.AppendText(i.ToString() + ": " + count[i].ToString() + "個 \n");
            }
            textBox2.AppendText(" ------------- \n");

            //pictureBox1.Refresh();

            /*bmp_dice[1].UnlockBits(dice[1]);
            pictureBox1.Image = bmp_dice[1];
            pictureBox1.Refresh();
            //サイコロをふる
            int [,] number= new int[10,10];
            Random rnd = new System.Random();
            for (int dice_y = 0; dice_y < 10; dice_y++)
            {
                for (int dice_x = 0; dice_x < 10; dice_x++)
                {
                    int intResult = rnd.Next(1,7);
                    number[dice_x, dice_y] = intResult;
                }
            }
            Bitmap bmp_dice_window = new Bitmap(360, 360);
            BitmapData dice_window = bmp_dice_window.LockBits(new Rectangle(0, 0, bmp_dice_window.Width, bmp_dice_window.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            for(int dice_y=0; dice_y < 10; dice_y++)
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int dice_x = 0; dice_x < 10; dice_x++)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                            Int32 value = Marshal.ReadInt32(dice[number[dice_x, dice_y]].Scan0, j * 4 + 30 * 4 * i);
                            byte r = (byte)(value & 0xff);
                            byte g = (byte)((value >> 8) & 0xff);
                            byte b = (byte)((value >> 16) & 0xff);
                            value = r | g | b;
                            Marshal.WriteInt32(dice_window.Scan0, ((30 + dice_x * 30) + j) * 4 + 360 * 4 * ((30 + dice_y * 30) + i), value);
                        }
                    }
                }
            }

            bmp_dice_window.UnlockBits(dice_window);
            pictureBox1.Image = bmp_dice_window;
            pictureBox1.Refresh();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {


            Random rnd = new System.Random();
            for (int ii = 0; ii < 1000; ii++)
            {
                //サイコロをふる
                int[,] number = new int[10, 10];
                int[] count = new int[7];
                for (int dice_y = 0; dice_y < 10; dice_y++)
                {
                    for (int dice_x = 0; dice_x < 10; dice_x++)
                    {
                        int intResult = rnd.Next(1, 7);
                        number[dice_x, dice_y] = intResult;
                        count[intResult]++;
                    }
                }

                hist[count[1]]++;


                for (int i = 0; i < 50; i++)
                {
                    chart1.Series[0].Points.AddXY(i, hist[i]);
                }

                if (ii % 10 == 0)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            g.DrawImage(bmp_dice[number[j, i]], 30 * (j + 1), 30 * (i + 1), 20, 20);
                        }
                    }
                }

                /*
                for (int i = 1; i < 7; i++)
                {
                    textBox2.AppendText(i.ToString() + ": " + count[i].ToString() + "個 \n");
                }
                textBox2.AppendText(" ------------- \n");*/
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new System.Random();
            for (int ii = 0; ii < 1000; ii++)
            {
                //サイコロをふる
                int[,] number = new int[10, 10];
                int[] count = new int[7];
                for (int dice_y = 0; dice_y < 10; dice_y++)
                {
                    for (int dice_x = 0; dice_x < 10; dice_x++)
                    {
                        int intResult = rnd.Next(1, 7);
                        if (intResult == 1) { intResult = rnd.Next(1, 7); } //1の出る確率が36分の1
                        number[dice_x, dice_y] = intResult;
                        count[intResult]++;
                    }
                }

                hist[count[1]]++;


                for (int i = 0; i < 25; i++)
                {
                    chart1.Series[0].Points.AddXY(i, hist[i]);
                }

                if (ii % 10 == 0)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            g.DrawImage(bmp_dice[number[j, i]], 30 * (j + 1), 30 * (i + 1), 20, 20);
                        }
                    }
                }
            }
        }

        public int dice_counter = 100;
        public int trial_counter = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (dice_counter < 2)
            {
                textBox3.AppendText("もう振れないよ！ \n");
                return;
            }

            trial_counter++;

            //サイコロをふる
            int[,] number = new int[10, 10];
            int[] count = new int[7];

            Random rnd = new System.Random();

            int temp = 0;
            for (int dice_y = 0; dice_y < 10; dice_y++)
            {
                for (int dice_x = 0; dice_x < 10; dice_x++)
                {
                    if (temp < dice_counter)
                    {
                        int intResult = rnd.Next(1, 7);
                        number[dice_x, dice_y] = intResult;
                        count[intResult]++;
                    }
                    temp++;
                }
            }
            temp = 0;



            Graphics g = pictureBox1.CreateGraphics();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (temp < dice_counter)
                    {
                        g.DrawImage(bmp_dice[number[j, i]], 30 * (j + 1), 30 * (i + 1), 20, 20);
                    }
                    else
                    {
                        g.DrawImage(bmp_dice[0], 30 * (j + 1), 30 * (i + 1), 20, 20);
                    }
                    temp++;
                }
            }


            textBox3.AppendText(trial_counter.ToString()+": "+ dice_counter.ToString() + "個中, 1は" + count[1].ToString() + "個 \n");
            textBox3.AppendText(" ------------- \n");

            chart2.Series[0].Points.AddXY(trial_counter, dice_counter);

            dice_counter -= count[1];
            button4.Text = "さいころを" + ""+
                dice_counter.ToString() + "個振る";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dice_counter = 100;
            trial_counter = 0;
            chart2.Series[0].Points.Clear();
        }
    }
}
