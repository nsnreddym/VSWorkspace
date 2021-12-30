using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileTransactions;
using Globalclass;

namespace Spectrum_test
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        

        private void Settings_Load(object sender, EventArgs e)
        {
            Filehandlings settings = new Filehandlings();
            string path = @".\Settings.ini";            
            if (!File.Exists(path))
            {
                settings.Settings_default();
            }
            settings.Settings_Read();    

            cbRBW.Text = Globals.RBW_unit;
            cbVBW.Text = Globals.VBW_unit;
            cbSpan.Text = Globals.Span_unit;
            cbFreq.Text = Globals.Freq_unit;
            cbSWT.Text = Globals.SWT_unit;

            ip1.Text = Globals.Devadd;
            tRBW. Text = Globals.RBW;
            tVBW.Text = Globals.VBW;
            tSpan.Text = Globals.Span;
            tFreq.Text = Globals.Freq;
            tSWT.Text = Globals.SWT;
            tSWP.Text = Globals.SWP;
            tREF.Text = Globals.REF;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Filehandlings settings = new Filehandlings();

            Globals.RBW_unit = cbRBW.Text;
            Globals.VBW_unit = cbVBW.Text;
            Globals.Span_unit = cbSpan.Text;
            Globals.Freq_unit = cbFreq.Text;
            Globals.SWT_unit = cbSWT.Text;

            Globals.Devadd = ip1.Text;
            Globals.RBW = tRBW.Text;
            Globals.VBW = tVBW.Text;
            Globals.Span = tSpan.Text;
            Globals.Freq = tFreq.Text;
            Globals.SWT = tSWT.Text;
            Globals.SWP = tSWP.Text;
            Globals.REF = tREF.Text;

            settings.Settings_write();

            this.Close();
        }
    }
}
