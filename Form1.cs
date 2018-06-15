using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 演習0608
{
    public partial class Form1 : Form
    {
        const int LABEL_COUNT = 5;

        private static Random rand = new Random();
        //int vx = 15, vy = 15, vx1 = 23, vy1 = 23, vx2=8,vy2=8;
        int[] vx = new int[LABEL_COUNT];
        int[] vy = new int[LABEL_COUNT];
        Label[] labels = new Label[LABEL_COUNT];
        Label[] enemys = new Label[LABEL_COUNT];
        int zz = 0;
        int time = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*   labels[0] = new Label();
               labels[0].AutoSize = true;
               labels[0].Text = "◆";
               Controls.Add(labels[0]);*/

            for (int n = 0; n < LABEL_COUNT; n++)
            {
                labels[n] = new Label();
                labels[n].AutoSize = true;
                labels[n].Text = label2.Text;
                labels[n].Image = label2.Image;
                labels[n].Font = label2.Font;
                labels[n].ForeColor = label2.ForeColor;
                Controls.Add(labels[n]);
                labels[n].Left = rand.Next(0, ClientSize.Width - labels[n].Width);
                labels[n].Top = rand.Next(0, ClientSize.Height - labels[n].Height);
                vx[n] = rand.Next(10, 30);
                vy[n] = rand.Next(10, 30);

            }

            for (int m = 0; m < 3; m++)
            {
                enemys[m] = new Label();
                enemys[m].AutoSize = true;
                enemys[m].Text = label1.Text;
                // enemys[n].Image = label2.Image;
                enemys[m].Font = label1.Font;
                enemys[m].ForeColor = label1.ForeColor;
                Controls.Add(enemys[m]);
                enemys[m].Left = rand.Next(0, ClientSize.Width - enemys[m].Width);
                enemys[m].Top = rand.Next(0, ClientSize.Height - enemys[m].Height);
                vx[m] = rand.Next(10, 30);
                vy[m] = rand.Next(10, 30);

            }





            label1.Left = rand.Next(0, ClientSize.Width - label1.Width);
            label1.Top = rand.Next(0, ClientSize.Height - label1.Height);
            vx[0] = rand.Next(10, 30);
            vy[0] = rand.Next(10, 30);

            label2.Left = rand.Next(0, ClientSize.Width - label2.Width);
            label2.Top = rand.Next(0, ClientSize.Height - label2.Height);
            vx[1] = rand.Next(10, 30);
            vy[1] = rand.Next(10, 30);


            label3.Left = rand.Next(0, ClientSize.Width - label3.Width);
            label3.Top = rand.Next(0, ClientSize.Height - label3.Height);
            vx[2] = rand.Next(10, 30);
            vy[2] = rand.Next(10, 30);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            Point cpos;

            cpos = MousePosition;
            cpos = PointToClient(cpos);

            label4.Left = cpos.X - label4.Width / 2;
            label4.Top = cpos.Y - label4.Height / 2;

            for (int n = 0; n < LABEL_COUNT; n++)
            {
                labels[n].Left += vx[n];
                labels[n].Top += vy[n];

                if (labels[n].Left < 0)
                {
                    vx[n] = Math.Abs(vx[n]);
                }

                if (labels[n].Top > ClientSize.Height - labels[n].Height)
                {
                    vy[n] = -Math.Abs(vy[n]);
                }

                if (labels[n].Top < 0)
                {
                    vy[n] = Math.Abs(vy[n]);
                }

                if (labels[n].Left > ClientSize.Width - labels[n].Width)
                {
                    vx[n] = -Math.Abs(vx[n]);
                }


                if (
    (cpos.Y >= labels[n].Top && cpos.Y <= labels[n].Bottom) &&
    (cpos.X <= labels[n].Right && cpos.X >= labels[n].Left)

    )
                {                 

                        labels[n].Visible=false;
                   
                        zz++;
                        textBox1.Text = zz.ToString();
                    
                    if ( zz == LABEL_COUNT)
                    {
                        timer1.Stop();
                        button1.Visible = true;
                    }
                }

                
            }
            time++;
            label5.Text = "Time " + time;
        }
        private void timer2_Tick(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            // timer1.Enabled = true;
            time = 0;
            for (int n = 0; n < LABEL_COUNT; n++)
            {
                labels[n] = new Label();
                labels[n].AutoSize = true;
                labels[n].Text = label2.Text;
                labels[n].Image = label2.Image;
                labels[n].Font = label2.Font;
                labels[n].ForeColor = label2.ForeColor;
                Controls.Add(labels[n]);
                labels[n].Left = rand.Next(0, ClientSize.Width - labels[n].Width);
                labels[n].Top = rand.Next(0, ClientSize.Height - labels[n].Height);
                vx[n] = rand.Next(10, 30);
                vy[n] = rand.Next(10, 30);

            }
            zz = 0;
            timer1.Start();
            button1.Visible = false;
        }
    }
}
