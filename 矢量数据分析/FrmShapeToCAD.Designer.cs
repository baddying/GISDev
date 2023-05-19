namespace EditSDELayerDemo
{
    partial class FrmShapeToCAD
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
            this.btnOpenShape = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShapePath = new System.Windows.Forms.TextBox();
            this.listBoxOfCADType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCADPath = new System.Windows.Forms.TextBox();
            this.btnSaveCADPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenShape
            // 
            this.btnOpenShape.Location = new System.Drawing.Point(420, 28);
            this.btnOpenShape.Name = "btnOpenShape";
            this.btnOpenShape.Size = new System.Drawing.Size(75, 23);
            this.btnOpenShape.TabIndex = 0;
            this.btnOpenShape.Text = "打开";
            this.btnOpenShape.UseVisualStyleBackColor = true;
            this.btnOpenShape.Click += new System.EventHandler(this.btnOpenShape_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "打开ShapeFile数据：";
            // 
            // txtShapePath
            // 
            this.txtShapePath.Enabled = false;
            this.txtShapePath.Location = new System.Drawing.Point(117, 28);
            this.txtShapePath.Name = "txtShapePath";
            this.txtShapePath.Size = new System.Drawing.Size(286, 21);
            this.txtShapePath.TabIndex = 2;
            // 
            // listBoxOfCADType
            // 
            this.listBoxOfCADType.FormattingEnabled = true;
            this.listBoxOfCADType.ItemHeight = 12;
            this.listBoxOfCADType.Location = new System.Drawing.Point(117, 68);
            this.listBoxOfCADType.MultiColumn = true;
            this.listBoxOfCADType.Name = "listBoxOfCADType";
            this.listBoxOfCADType.Size = new System.Drawing.Size(286, 112);
            this.listBoxOfCADType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择保存CAD路径：";
            // 
            // txtCADPath
            // 
            this.txtCADPath.Enabled = false;
            this.txtCADPath.Location = new System.Drawing.Point(117, 194);
            this.txtCADPath.Name = "txtCADPath";
            this.txtCADPath.Size = new System.Drawing.Size(286, 21);
            this.txtCADPath.TabIndex = 5;
            // 
            // btnSaveCADPath
            // 
            this.btnSaveCADPath.Location = new System.Drawing.Point(420, 194);
            this.btnSaveCADPath.Name = "btnSaveCADPath";
            this.btnSaveCADPath.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCADPath.TabIndex = 6;
            this.btnSaveCADPath.Text = "打开";
            this.btnSaveCADPath.UseVisualStyleBackColor = true;
            this.btnSaveCADPath.Click += new System.EventHandler(this.btnSaveCADPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "转换CAD类型：";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(149, 235);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(257, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmShapeToCAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 284);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveCADPath);
            this.Controls.Add(this.txtCADPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxOfCADType);
            this.Controls.Add(this.txtShapePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenShape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShapeToCAD";
            this.ShowIcon = false;
            this.Text = "Shapefile数据转换为CAD数据";
            this.Load += new System.EventHandler(this.FrmShapeToCAD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenShape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShapePath;
        private System.Windows.Forms.ListBox listBoxOfCADType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCADPath;
        private System.Windows.Forms.Button btnSaveCADPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnClose;
    }
}