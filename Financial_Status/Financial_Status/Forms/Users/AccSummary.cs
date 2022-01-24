using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using FinancialDataBase;
using Globals;

namespace Financial_Status.Forms.Users
{
    public partial class AccSummary : Form
    {
        ScrollBar vScrollBar1;
        ScrollBar hScrollBar1;

        public AccSummary()
        {
            InitializeComponent();
        }

        private void Display_Account_Pallete()
        {
            int x, y;
            int indx_SA, indx_LA;

            DisplaySavings[] displaySAs = new DisplaySavings[DataBasedata.accountinfo.Count];
            DisplayLoans[] displayLAs = new DisplayLoans[DataBasedata.accountinfo.Count];
            GroupBox groupBox1 = new GroupBox();
            GroupBox groupBox2 = new GroupBox();

            indx_SA = 0;
            indx_LA = 0;
            x = 10;
            y = 20;


            for (int i = 0; i < DataBasedata.accountinfo.Count; i++)
            {
                switch (DataBasedata.accountinfo[i].Type)
                {
                    case "Savings":
                        displaySAs[indx_SA] = new DisplaySavings();

                        if (indx_SA == 0)
                        {
                            panel1.Controls.Add(groupBox1);
                            groupBox1.Text = "Saving Accounts";
                            groupBox1.AutoSize = true;
                            groupBox1.Visible = true;
                            groupBox1.Font = new Font("Arial", 10, FontStyle.Bold);
                            groupBox1.ForeColor = Color.Green;

                            groupBox1.Location = new Point(10, 10);

                            x = 10;
                            y = 20;
                        }
                        else
                        {
                            x = x + displaySAs[indx_SA].Size.Width + 10;
                        }
                        
                        if ((x + displaySAs[indx_SA].Size.Width) > (Size.Width-20))
                        {
                            y = y + displaySAs[indx_SA].Size.Height + 10;
                            x = 10;
                        }

                        displaySAs[indx_SA].DisplaySavingsAccount(x, y, i);

                        groupBox1.Controls.Add(displaySAs[indx_SA]);
                        indx_SA++;

                        break;

                    case "Loan":
                        displayLAs[indx_LA] = new DisplayLoans();

                        if (indx_LA == 0)
                        {
                            panel1.Controls.Add(groupBox2);
                            groupBox2.Text = "Loan Accounts Total = Rs " + DataBasedata.GetTotalDebt().ToString("N") + " Dr";
                            groupBox2.AutoSize = true;
                            groupBox2.Visible = true;
                            groupBox2.Font = new Font("Arial", 10, FontStyle.Bold);
                            groupBox2.ForeColor = Color.Green;

                            groupBox2.Location = new Point(10, groupBox1.Size.Height + 20);

                            y = 20;
                            x = 10;
                        }
                        else
                        {
                            x = x + displayLAs[indx_LA].Size.Width + 10;
                        }

                        if ((x + displayLAs[indx_LA].Size.Width) > Size.Width)
                        {
                            y = y + displayLAs[indx_LA].Size.Height + 10;
                            x = 10;
                        }

                        displayLAs[indx_LA].DisplayLoansAccount(x, y, i);
                        groupBox2.Controls.Add(displayLAs[indx_LA]);
                        indx_LA++;

                        break;

                    default:
                        break;
                }
            }

            GlobalVar.MaxTables = DataBasedata.accountinfo.Count;

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = Size.Height;

            hScrollBar1.Maximum = Size.Width;
        }

        private void AccSummary_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            panel1.AutoScroll = false;
            vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Maximum = Size.Height;
            vScrollBar1.Minimum = 0;

            hScrollBar1 = new HScrollBar();
            hScrollBar1.Dock = DockStyle.Bottom;
            hScrollBar1.Maximum = Size.Width;
            hScrollBar1.Minimum = 0; ;

            panel1.AutoScroll = true;

            panel1.Dock = DockStyle.Fill;

            //Read Accounts
            DataBasedata.ReadAccountInfo();

            Display_Account_Pallete();
        }
    }
}
