using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Globals;

namespace Financial_Status.Forms.Admin
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void Settings_default()
        {
            StreamWriter sw2;
            sw2 = File.CreateText(".\\Settings.ini");
            sw2.WriteLine("Path :Satya_Financial_v2.db");
            sw2.Close();
        }

        public void Settings_Read()
        {
            StreamReader sw;
            int index;
            int index2;
            string str;
            sw = File.OpenText(".\\Settings.ini");
            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.Length - index - 1;
            GlobalVar.DataBasePath = str.Substring(index + 1, index2);
            sw.Close();
        }

        public void Settings_write()
        {
            StreamWriter sw;
            sw = File.CreateText(".\\Settings.ini");
            sw.WriteLine("Path :" + GlobalVar.DataBasePath);
            sw.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog loaddataDialog;
            loaddataDialog = new System.Windows.Forms.OpenFileDialog();
            loaddataDialog.Filter = "Database files (*.db)|*.db";
            loaddataDialog.ShowDialog();

            string path = loaddataDialog.FileName;

            tbPath.Text = path;

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string path = @".\Settings.ini";
            if (!File.Exists(path))
            {
                Settings_default();
            }
            Settings_Read();

            tbPath.Text = GlobalVar.DataBasePath;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            GlobalVar.DataBasePath = tbPath.Text;
            Settings_write();
        }
    }
}
