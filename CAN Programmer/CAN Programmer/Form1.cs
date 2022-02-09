using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAN_Programmer
{
    public partial class Form1 : Form
    {
        int NoOfCCs = new int();
        Hlt_pack[] hLtpack = new Hlt_pack[18];
        CoachUnit c = new CoachUnit();
        System.Windows.Forms.PaintEventArgs k;


        private void data_download(object state)
        {
            int k;

            try
            {

                DataPort.BaudRate = 9600;
                DataPort.PortName = "COM1";
                DataPort.Open();

                DataPort.Write("Ready");

                while (true)
                {
                    k = DataPort.ReadByte();
                    if (1 == k)
                    {
                        for (int i = 0; i < NoOfCCs; i++)
                        {
                            hLtpack[i].Hlt_update(1);
                        }

                        Updatestatus("Ok");
                    }
                    else if (0 == k)
                    {
                        for (int i = 0; i < NoOfCCs; i++)
                        {
                            hLtpack[i].Hlt_update(0);
                        }

                        Updatestatus("fail");


                    }
                    else
                    {
                        break;
                    }
                }

                DataPort.Close();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Updatestatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus), new object[] { value });
                return;
            }
      
            this.Refresh();
        }




        public Form1()
        {
            InitializeComponent();
        }

        // This example creates a PictureBox control on the form and draws to it.
        // This example assumes that the Form_Load event handler method is
        // connected to the Load event of the form.

        private PictureBox pictureBox1 = new PictureBox();
        private void Form1_Load(object sender, System.EventArgs e)
        {
            NoOfCCs = 12;
            for (int i = 0; i < NoOfCCs; i++)
                hLtpack[i] = new Hlt_pack();

            Size size = new Size(NoOfCCs * 180 + 150, 280 + 150);
            panel1.Size = size;
            pictureBox2.Size = size;

            // Dock the PictureBox to the form and set its background to white.
            //pictureBox1.Dock = DockStyle.Fill;
            //pictureBox1.BackColor = Color.Black;
            //pictureBox1.AutoScrollOffset = new Point(0,0);
            // Connect the Paint event of the PictureBox to the event handler method.
            //pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

            // Add the PictureBox control to the Form.
            //this.Controls.Add(pictureBox1);

        }
        private void Form1_closing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if(this.Size.Height > (280 + 150))
            {
                Size size = new Size(NoOfCCs * 180 + 150, this.Size.Height);

                panel1.Size = size;
                pictureBox2.Size = size;
            }
            else
            {
                Size size = new Size(NoOfCCs * 180 + 150, (280 + 150));

                panel1.Size = size;
                pictureBox2.Size = size;

            }

            
            

        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            // Create a local version of the graphics object for the PictureBox.
            k = e;
           for(int i=0;i<NoOfCCs;i++)
            {
                c.Update_dev(sender, e, i,hLtpack[i]);

            }

            panel1.AutoScroll = true;
            //c.Update_dev(sender, e, 1);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(data_download));
           
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NoOfCCs; i++)
            {
                hLtpack[i].Hlt_update(1);
            }
            this.Refresh();

        }
    }


    public class CoachUnit
    {
        Pen p;
        int x, y, width, height;
        Graphics g;

        public CoachUnit()
        {
        }

        public void DrawUnit(int x, int y, int width, int height, int state, string s)
        {
            Color Pass = Color.FromArgb(128, 0, 255, 0);
            Color fail = Color.FromArgb(128, 255, 0, 0);

            Pen whitePen = new Pen(Color.FromArgb(128, 255, 255, 255), 5);
            SolidBrush Redbrush = new SolidBrush(fail);
            SolidBrush Yellowbrush = new SolidBrush(Color.FromArgb(255, 255, 255, 0));
            Font drawFont = new Font("Arial", 10);

            if(state == 1)
                Redbrush.Color = Pass;
            else
                Redbrush.Color = fail;



            g.DrawRectangle(whitePen, x, y, width, height);
            g.FillRectangle(Redbrush, x, y, width, height);

            g.DrawString(s, drawFont, Yellowbrush, new PointF(x + 10, y + 15));

        }
        public void Update_dev(object sender, System.Windows.Forms.PaintEventArgs e, int coachID, Hlt_pack h)
        {
            Pen YellowPen = new Pen(Color.FromArgb(255, 255, 255, 0), 2);
            Pen GrayPen = new Pen(Color.FromArgb(255, 128, 128, 128), 2);
            SolidBrush Yellowbrush = new SolidBrush(Color.FromArgb(255, 255, 255, 0));
            Font drawFont = new Font("Arial", 10);


            g = e.Graphics;

            x = coachID * 180 + 100;
            y = 100;
            width = 50;
            height =  50;

            g.DrawRectangle(GrayPen, x-10, y-20, 170, 380);
            g.DrawString((coachID + 1).ToString(), drawFont, Yellowbrush, new PointF(x + 75, y + 340));



            DrawUnit(x + 50, y, width, height, h.CC, "CC");
            DrawUnit(x, y + 70, width, height, h.SSD1, "SSD");
            DrawUnit(x, y + 140, width, height, h.DSD1, "DSD");
            DrawUnit(x, y + 210, width, height, h.HCD1, "HCD");
            DrawUnit(x, y + 280, width, height, h.ANM1, "ANM");

            DrawUnit(x + 100, y + 70, width, height, h.SSD2, "SSD");
            DrawUnit(x + 100, y + 140, width, height, h.DSD2, "DSD");
            DrawUnit(x + 100, y + 210, width, height, h.HCD2, "HCD");
            DrawUnit(x + 100, y + 280, width, height, h.ANM2, "ANM");

            g.DrawLine(YellowPen, x + 65, y + 50, x + 65, y + 305);
            g.DrawLine(YellowPen, x + 85, y + 50, x + 85, y + 305);

            g.DrawLine(YellowPen, x + 65, y + 95, x + 50, y + 95);
            g.DrawLine(YellowPen, x + 85, y + 95, x + 100, y + 95);

            g.DrawLine(YellowPen, x + 65, y + 165, x + 50, y + 165);
            g.DrawLine(YellowPen, x + 85, y + 165, x + 100, y + 165);

            g.DrawLine(YellowPen, x + 65, y + 235, x + 50, y + 235);
            g.DrawLine(YellowPen, x + 85, y + 235, x + 100, y + 235);

            g.DrawLine(YellowPen, x + 65, y + 305, x + 50, y + 305);
            g.DrawLine(YellowPen, x + 85, y + 305, x + 100, y + 305);

            g.DrawLine(YellowPen, x + 65, y + 50, x + 65, y + 305);
            g.DrawLine(YellowPen, x + 65, y + 50, x + 65, y + 305);


        }

    }

    public class Hlt_pack
    {
        public int CC;
        public int SSD1;
        public int SSD2;
        public int DSD1;
        public int DSD2;
        public int HCD1;
        public int HCD2;
        public int ANM1;
        public int ANM2;

        public Hlt_pack()
        {
            CC = 0;
            SSD1 = 0;
            SSD2 = 0;
            DSD1 = 0;
            DSD2 = 0;
            HCD1 = 0;
            HCD2 = 0;
            ANM1 = 0;
            ANM2 = 0;

        }

        public void Hlt_update(int i)
        {
            if (i == 0)
            {
                CC = 1;
                SSD1 = 1;
                SSD2 = 0;
                DSD1 = 0;
                DSD2 = 1;
                HCD1 = 1;
                HCD2 = 0;
                ANM1 = 0;
                ANM2 = 1;

            }

            else
            {
                CC = 0;
                SSD1 = 0;
                SSD2 = 1;
                DSD1 = 1;
                DSD2 = 0;
                HCD1 = 0;
                HCD2 = 1;
                ANM1 = 1;
                ANM2 = 0;

            }
        }


    }
}


