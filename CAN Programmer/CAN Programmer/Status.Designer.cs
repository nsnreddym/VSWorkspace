using System;
using System.Windows.Forms;

namespace CAN_Programmer
{
    partial class Status
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataPort = new System.IO.Ports.SerialPort(this.components);
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.BCancel = new System.Windows.Forms.Button();
            this.BUpdate = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.CBID = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.LabelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.LBlkStatus = new System.Windows.Forms.Label();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataPort
            // 
            this.DataPort.ReadTimeout = 5;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.DataGridView1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.Size = new System.Drawing.Size(617, 347);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.FileType,
            this.FileSize,
            this.FileName,
            this.FirstSector,
            this.LastSector});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(3, 160);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.Size = new System.Drawing.Size(611, 184);
            this.DataGridView1.TabIndex = 0;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.BCancel);
            this.Panel1.Controls.Add(this.BUpdate);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.CBID);
            this.Panel1.Controls.Add(this.CBClass);
            this.Panel1.Controls.Add(this.LabelX6);
            this.Panel1.Controls.Add(this.LabelX5);
            this.Panel1.Controls.Add(this.LBlkStatus);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(611, 151);
            this.Panel1.TabIndex = 1;
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(187, 59);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(80, 23);
            this.BCancel.TabIndex = 26;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            // 
            // BUpdate
            // 
            this.BUpdate.Location = new System.Drawing.Point(48, 59);
            this.BUpdate.Name = "BUpdate";
            this.BUpdate.Size = new System.Drawing.Size(80, 23);
            this.BUpdate.TabIndex = 25;
            this.BUpdate.Text = "Start";
            this.BUpdate.UseVisualStyleBackColor = true;
            this.BUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 115);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Status";
            // 
            // CBID
            // 
            this.CBID.FormattingEnabled = true;
            this.CBID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.CBID.Location = new System.Drawing.Point(187, 9);
            this.CBID.Name = "CBID";
            this.CBID.Size = new System.Drawing.Size(80, 21);
            this.CBID.TabIndex = 21;
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Items.AddRange(new object[] {
            "MMI",
            "CC"});
            this.CBClass.Location = new System.Drawing.Point(48, 9);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(80, 21);
            this.CBClass.TabIndex = 20;
            // 
            // LabelX6
            // 
            // 
            // 
            // 
            this.LabelX6.BackgroundStyle.Class = "";
            this.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX6.Location = new System.Drawing.Point(162, 9);
            this.LabelX6.Name = "LabelX6";
            this.LabelX6.Size = new System.Drawing.Size(19, 23);
            this.LabelX6.TabIndex = 19;
            this.LabelX6.Text = "ID";
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.Class = "";
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(9, 9);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(33, 23);
            this.LabelX5.TabIndex = 18;
            this.LabelX5.Text = "Class";
            // 
            // LBlkStatus
            // 
            this.LBlkStatus.AutoSize = true;
            this.LBlkStatus.Location = new System.Drawing.Point(52, 115);
            this.LBlkStatus.Name = "LBlkStatus";
            this.LBlkStatus.Size = new System.Drawing.Size(76, 13);
            this.LBlkStatus.TabIndex = 2;
            this.LBlkStatus.Text = "Please Wait....";
            // 
            // SNo
            // 
            this.SNo.HeaderText = "S.No";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "FileType";
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            this.FileType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "FileSize";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            this.FileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FirstSector
            // 
            this.FirstSector.HeaderText = "FirstSector";
            this.FirstSector.Name = "FirstSector";
            this.FirstSector.ReadOnly = true;
            this.FirstSector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LastSector
            // 
            this.LastSector.HeaderText = "LastSector";
            this.LastSector.Name = "LastSector";
            this.LastSector.ReadOnly = true;
            this.LastSector.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 347);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "Status";
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Status_FormClosing);
            this.Load += new System.EventHandler(this.Status_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        internal System.IO.Ports.SerialPort DataPort;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox CBID;
        internal System.Windows.Forms.ComboBox CBClass;
        internal DevComponents.DotNetBar.LabelX LabelX6;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal System.Windows.Forms.Label LBlkStatus;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.Button BUpdate;
        private DataGridViewTextBoxColumn SNo;
        private DataGridViewTextBoxColumn FileType;
        private DataGridViewTextBoxColumn FileSize;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn FirstSector;
        private DataGridViewTextBoxColumn LastSector;
    }
}