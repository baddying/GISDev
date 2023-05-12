namespace 专题地图.Symbol
{
    partial class frmClassBreakRender
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
            this.labelControl1 = new System.Windows.Forms.Label();
            this.labelControl2 = new System.Windows.Forms.Label();
            this.labelControl3 = new System.Windows.Forms.Label();
            this.cmbSelLyr = new System.Windows.Forms.ComboBox();
            this.cmbSelField = new System.Windows.Forms.ComboBox();
            this.cmbClassNumber = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSize = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 12);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "图层选择";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSize = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 12);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "字段选择";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSize = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 166);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 12);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "划分级别";
            // 
            // cmbSelLyr
            // 
            this.cmbSelLyr.FormattingEnabled = true;
            this.cmbSelLyr.Location = new System.Drawing.Point(143, 25);
            this.cmbSelLyr.Name = "cmbSelLyr";
            this.cmbSelLyr.Size = new System.Drawing.Size(236, 20);
            this.cmbSelLyr.TabIndex = 3;
            this.cmbSelLyr.SelectedIndexChanged += new System.EventHandler(this.cmbSelLyr_SelectedIndexChanged);
            // 
            // cmbSelField
            // 
            this.cmbSelField.FormattingEnabled = true;
            this.cmbSelField.Location = new System.Drawing.Point(143, 84);
            this.cmbSelField.Name = "cmbSelField";
            this.cmbSelField.Size = new System.Drawing.Size(236, 20);
            this.cmbSelField.TabIndex = 4;
            // 
            // cmbClassNumber
            // 
            this.cmbClassNumber.FormattingEnabled = true;
            this.cmbClassNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbClassNumber.Location = new System.Drawing.Point(143, 158);
            this.cmbClassNumber.Name = "cmbClassNumber";
            this.cmbClassNumber.Size = new System.Drawing.Size(236, 20);
            this.cmbClassNumber.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(185, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(302, 201);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(77, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmClassBreakRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 229);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbClassNumber);
            this.Controls.Add(this.cmbSelField);
            this.Controls.Add(this.cmbSelLyr);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmClassBreakRender";
            this.Text = "分级符号化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.Label labelControl3;
        private System.Windows.Forms.ComboBox cmbSelLyr;
        private System.Windows.Forms.ComboBox cmbSelField;
        private System.Windows.Forms.ComboBox cmbClassNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
    }
}