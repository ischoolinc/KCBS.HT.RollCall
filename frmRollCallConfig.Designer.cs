namespace KCBS.HT.RollCall
{
    partial class frmRollCallConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSetLeaveCategory = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnLeave = new DevComponents.DotNetBar.ButtonX();
            this.ckbxCrossDate = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dgvSetSession = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cbCrossDateOnlyRead = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetLeaveCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetSession)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSetLeaveCategory
            // 
            this.dgvSetLeaveCategory.AllowUserToAddRows = false;
            this.dgvSetLeaveCategory.AllowUserToDeleteRows = false;
            this.dgvSetLeaveCategory.AllowUserToResizeColumns = false;
            this.dgvSetLeaveCategory.AllowUserToResizeRows = false;
            this.dgvSetLeaveCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSetLeaveCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvSetLeaveCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetLeaveCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetLeaveCategory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSetLeaveCategory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSetLeaveCategory.Location = new System.Drawing.Point(12, 41);
            this.dgvSetLeaveCategory.Name = "dgvSetLeaveCategory";
            this.dgvSetLeaveCategory.RowHeadersVisible = false;
            this.dgvSetLeaveCategory.RowTemplate.Height = 24;
            this.dgvSetLeaveCategory.Size = new System.Drawing.Size(277, 251);
            this.dgvSetLeaveCategory.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "假別";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "導師可點";
            this.Column2.Name = "Column2";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(384, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeave.BackColor = System.Drawing.Color.Transparent;
            this.btnLeave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeave.Location = new System.Drawing.Point(465, 307);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(75, 23);
            this.btnLeave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLeave.TabIndex = 2;
            this.btnLeave.Text = "離開";
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // ckbxCrossDate
            // 
            this.ckbxCrossDate.AutoSize = true;
            this.ckbxCrossDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.ckbxCrossDate.BackgroundStyle.Class = "";
            this.ckbxCrossDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckbxCrossDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ckbxCrossDate.Location = new System.Drawing.Point(12, 12);
            this.ckbxCrossDate.Name = "ckbxCrossDate";
            this.ckbxCrossDate.Size = new System.Drawing.Size(174, 21);
            this.ckbxCrossDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckbxCrossDate.TabIndex = 3;
            this.ckbxCrossDate.Text = "開放線上補點及預先請假";
            // 
            // dgvSetSession
            // 
            this.dgvSetSession.AllowUserToAddRows = false;
            this.dgvSetSession.AllowUserToDeleteRows = false;
            this.dgvSetSession.AllowUserToResizeColumns = false;
            this.dgvSetSession.AllowUserToResizeRows = false;
            this.dgvSetSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetSession.BackgroundColor = System.Drawing.Color.White;
            this.dgvSetSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetSession.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DataGridViewComboBoxColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetSession.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSetSession.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSetSession.Location = new System.Drawing.Point(295, 41);
            this.dgvSetSession.Name = "dgvSetSession";
            this.dgvSetSession.RowHeadersVisible = false;
            this.dgvSetSession.RowTemplate.Height = 24;
            this.dgvSetSession.Size = new System.Drawing.Size(245, 251);
            this.dgvSetSession.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "節次";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DataGridViewComboBoxColumn
            // 
            this.DataGridViewComboBoxColumn.HeaderText = "導師可選";
            this.DataGridViewComboBoxColumn.Name = "DataGridViewComboBoxColumn";
            this.DataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewComboBoxColumn.Width = 120;
            // 
            // cbCrossDateOnlyRead
            // 
            this.cbCrossDateOnlyRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCrossDateOnlyRead.AutoSize = true;
            this.cbCrossDateOnlyRead.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbCrossDateOnlyRead.BackgroundStyle.Class = "";
            this.cbCrossDateOnlyRead.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbCrossDateOnlyRead.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbCrossDateOnlyRead.Location = new System.Drawing.Point(295, 12);
            this.cbCrossDateOnlyRead.Name = "cbCrossDateOnlyRead";
            this.cbCrossDateOnlyRead.Size = new System.Drawing.Size(161, 21);
            this.cbCrossDateOnlyRead.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCrossDateOnlyRead.TabIndex = 10;
            this.cbCrossDateOnlyRead.Text = "開放瀏覽點名請假狀況";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(12, 307);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 17);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "【節次導師可選】說明";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmRollCallConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 340);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cbCrossDateOnlyRead);
            this.Controls.Add(this.dgvSetSession);
            this.Controls.Add(this.ckbxCrossDate);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvSetLeaveCategory);
            this.DoubleBuffered = true;
            this.Name = "frmRollCallConfig";
            this.Text = "導師點名設定";
            this.Load += new System.EventHandler(this.frmRollCallConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetLeaveCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetSession)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSetLeaveCategory;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckbxCrossDate;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSetSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataGridViewComboBoxColumn;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbCrossDateOnlyRead;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}