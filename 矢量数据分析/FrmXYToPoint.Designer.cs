namespace EditSDELayerDemo
{
    partial class FrmXYToPoint
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExcelSheets = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbXField = new System.Windows.Forms.ComboBox();
            this.cmbYField = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打开Excel坐标文件：";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(142, 29);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(286, 21);
            this.txtExcelPath.TabIndex = 4;
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Location = new System.Drawing.Point(444, 27);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(75, 23);
            this.btnOpenExcel.TabIndex = 3;
            this.btnOpenExcel.Text = "打开";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "选择坐标数据表：";
            // 
            // cmbExcelSheets
            // 
            this.cmbExcelSheets.FormattingEnabled = true;
            this.cmbExcelSheets.Location = new System.Drawing.Point(142, 72);
            this.cmbExcelSheets.Name = "cmbExcelSheets";
            this.cmbExcelSheets.Size = new System.Drawing.Size(121, 20);
            this.cmbExcelSheets.TabIndex = 6;
            this.cmbExcelSheets.SelectedIndexChanged += new System.EventHandler(this.cmbExcelSheets_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "成图X字段：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "成图Y字段：";
            // 
            // cmbXField
            // 
            this.cmbXField.FormattingEnabled = true;
            this.cmbXField.Location = new System.Drawing.Point(148, 117);
            this.cmbXField.Name = "cmbXField";
            this.cmbXField.Size = new System.Drawing.Size(121, 20);
            this.cmbXField.TabIndex = 12;
            // 
            // cmbYField
            // 
            this.cmbYField.FormattingEnabled = true;
            this.cmbYField.Location = new System.Drawing.Point(398, 116);
            this.cmbYField.Name = "cmbYField";
            this.cmbYField.Size = new System.Drawing.Size(121, 20);
            this.cmbYField.TabIndex = 13;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(188, 172);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 14;
            this.btnConvert.Text = "成图";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(308, 172);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 15;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FrmXYToPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 216);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.cmbYField);
            this.Controls.Add(this.cmbXField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbExcelSheets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.btnOpenExcel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXYToPoint";
            this.Text = "XY数据转化为点空间数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExcelSheets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbXField;
        private System.Windows.Forms.ComboBox cmbYField;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnCancle;
    }
}