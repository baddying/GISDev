namespace 专题地图
{
    partial class frmUniqueValueRender
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
            this.cmbSelLyr = new System.Windows.Forms.ComboBox();
            this.cmbSelField = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSize = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "图层选择：";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSize = true;
            this.labelControl2.Location = new System.Drawing.Point(39, 128);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 15);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "字段选择";
            // 
            // cmbSelLyr
            // 
            this.cmbSelLyr.FormattingEnabled = true;
            this.cmbSelLyr.Location = new System.Drawing.Point(163, 31);
            this.cmbSelLyr.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelLyr.Name = "cmbSelLyr";
            this.cmbSelLyr.Size = new System.Drawing.Size(283, 23);
            this.cmbSelLyr.TabIndex = 2;
            this.cmbSelLyr.SelectedIndexChanged += new System.EventHandler(this.cmbSelLyr_SelectedIndexChanged);
            // 
            // cmbSelField
            // 
            this.cmbSelField.FormattingEnabled = true;
            this.cmbSelField.Location = new System.Drawing.Point(163, 125);
            this.cmbSelField.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelField.Name = "cmbSelField";
            this.cmbSelField.Size = new System.Drawing.Size(283, 23);
            this.cmbSelField.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(119, 189);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(303, 189);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 29);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FormUniqueValueRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 231);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbSelField);
            this.Controls.Add(this.cmbSelLyr);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUniqueValueRender";
            this.Text = "唯一值符号化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.ComboBox cmbSelLyr;
        private System.Windows.Forms.ComboBox cmbSelField;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
    }
}