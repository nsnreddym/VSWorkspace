using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataRadio_CFG_SW
{
    public partial class FlashDisplay : Form
    {
        byte[] flashData = new byte[512];

        public FlashDisplay()
        {
            InitializeComponent();
        }

        private void FlashDisplay_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle datacellstyle = new DataGridViewCellStyle();
            DataGridViewCellStyle groupcellstyle = new DataGridViewCellStyle();
            string name;

            datacellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datacellstyle.BackColor = Color.White;
            datacellstyle.ForeColor = Color.Black;
            datacellstyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            groupcellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            groupcellstyle.BackColor = Color.White;
            groupcellstyle.ForeColor = Color.Black;
            groupcellstyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            name = "Addr";
            FlashMemView.Columns.Add(name, name);
            FlashMemView.Columns[name].DefaultCellStyle = FlashMemView.DefaultCellStyle;
            FlashMemView.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
            FlashMemView.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            FlashMemView.Columns[name].ReadOnly = true;
            FlashMemView.Columns[name].DefaultCellStyle = groupcellstyle;

            for (int i = 0; i < 16; i++)
            {
                name = "Col" + i.ToString("X2");
                FlashMemView.Columns.Add(name, i.ToString("X2"));
                FlashMemView.Columns[name].DefaultCellStyle = FlashMemView.DefaultCellStyle;
                FlashMemView.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
                FlashMemView.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                FlashMemView.Columns[name].ReadOnly = true;
                FlashMemView.Columns[name].DefaultCellStyle = datacellstyle;
            }

            for (int i = 0; i < 32; i++)
            {                
                FlashMemView.Rows.Add();

                FlashMemView.Rows[i].Cells["Addr"].Value = i.ToString("X6");

                for (int j = 0; j < 16; j++)
                {
                    name = "Col" + j.ToString("X2");
                    FlashMemView.Rows[i].Cells[name].Value = flashData[i*16+j].ToString("X2");
                }
            }

            FlashMemView.Visible = true;
        }

        public void UpdateFlashMemory(byte[] indata)
        {
            for (int i = 0; i < 512; i++)
            {
                flashData[i] = indata[i];
            }
        }
    }
}
