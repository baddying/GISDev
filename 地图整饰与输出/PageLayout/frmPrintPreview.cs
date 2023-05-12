// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at &lt;your ArcGIS install location&gt;/DeveloperKit10.0/userestrictions.txt.
// 

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Printing;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS;
using ESRI.ArcGIS.Controls;
using ��ͼ���������;


namespace PrintPreview
{

	public class frmPrintPreview : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
        //buttons for open file, print preview, print dialog, page setup
        private System.Windows.Forms.Button btnPageSize;
        private System.Windows.Forms.Button btnPrintpreview;
        private System.Windows.Forms.Button btnPrint;

        //����ҳ�����á���ӡԤ���ʹ�ӡ�Ի���
		private PrintPreviewDialog printPreviewDialog1;
		private PrintDialog printDialog1;
		private PageSetupDialog pageSetupDialog1;		
		private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();		
		private ITrackCancel m_TrackCancel = new CancelTrackerClass();
        private ESRI.ArcGIS.Controls.AxPageLayoutControl PrintPagelayoutControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;	
		private short m_CurrentPrintPage;// ����ҳ������


		public frmPrintPreview(AxPageLayoutControl pageltcontrol)
		{
			InitializeComponent();          
            //PageLayoutControlͬ������
            syn(pageltcontrol);
		}

        
		protected override void Dispose( bool disposing )
		{
			//Release COM objects		

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

    #region Windows Form Designer generated code    
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPreview));
        this.btnPageSize = new System.Windows.Forms.Button();
        this.btnPrintpreview = new System.Windows.Forms.Button();
        this.btnPrint = new System.Windows.Forms.Button();
        this.PrintPagelayoutControl = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
        this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
        ((System.ComponentModel.ISupportInitialize)(this.PrintPagelayoutControl)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
        this.SuspendLayout();
        // 
        // btnPageSize
        // 
        this.btnPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnPageSize.Location = new System.Drawing.Point(328, 59);
        this.btnPageSize.Name = "btnPageSize";
        this.btnPageSize.Size = new System.Drawing.Size(75, 23);
        this.btnPageSize.TabIndex = 4;
        this.btnPageSize.Text = "ҳ������";
        this.btnPageSize.Click += new System.EventHandler(this.btnPageSize_Click);
        // 
        // btnPrintpreview
        // 
        this.btnPrintpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnPrintpreview.Location = new System.Drawing.Point(328, 146);
        this.btnPrintpreview.Name = "btnPrintpreview";
        this.btnPrintpreview.Size = new System.Drawing.Size(75, 23);
        this.btnPrintpreview.TabIndex = 5;
        this.btnPrintpreview.Text = "��ӡԤ��";
        this.btnPrintpreview.Click += new System.EventHandler(this.btnPrintpreview_Click);
        // 
        // btnPrint
        // 
        this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnPrint.Location = new System.Drawing.Point(328, 219);
        this.btnPrint.Name = "btnPrint";
        this.btnPrint.Size = new System.Drawing.Size(75, 23);
        this.btnPrint.TabIndex = 6;
        this.btnPrint.Text = "��ӡ";
        this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
        // 
        // PrintPagelayoutControl
        // 
        this.PrintPagelayoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.PrintPagelayoutControl.Location = new System.Drawing.Point(3, 9);
        this.PrintPagelayoutControl.Name = "PrintPagelayoutControl";
        this.PrintPagelayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PrintPagelayoutControl.OcxState")));
        this.PrintPagelayoutControl.Size = new System.Drawing.Size(313, 306);
        this.PrintPagelayoutControl.TabIndex = 9;
        // 
        // axLicenseControl1
        // 
        this.axLicenseControl1.Enabled = true;
        this.axLicenseControl1.Location = new System.Drawing.Point(477, 63);
        this.axLicenseControl1.Name = "axLicenseControl1";
        this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
        this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
        this.axLicenseControl1.TabIndex = 10;
        // 
        // frmPrintPreview
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
        this.ClientSize = new System.Drawing.Size(409, 315);
        this.Controls.Add(this.axLicenseControl1);
        this.Controls.Add(this.PrintPagelayoutControl);
        this.Controls.Add(this.btnPrint);
        this.Controls.Add(this.btnPrintpreview);
        this.Controls.Add(this.btnPageSize);
        this.Name = "frmPrintPreview";
        this.Text = "��ӡ";
        this.Load += new System.EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)(this.PrintPagelayoutControl)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
        this.ResumeLayout(false);

    }
    #endregion

		[STAThread]		
		private void Form1_Load(object sender, System.EventArgs e)
		{ 
			InitializePrintPreviewDialog(); //��ʼ����ӡԤ���Ի���
			printDialog1 = new PrintDialog(); //ʵ������ӡ�Ի���
			InitializePageSetupDialog(); //��ʼ����ӡ���öԻ�                    
		}    
        #region ҳ������
        private void InitializePageSetupDialog()
        {
            pageSetupDialog1 = new PageSetupDialog();
            //��ʼ��ҳ�����öԻ����ҳ����������Ϊȱʡ����
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            //��ʼ��ҳ�����öԻ���Ĵ�ӡ������Ϊȱʡ����
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
        }
        private void btnPageSize_Click(object sender, EventArgs e)
        {
            try
            {
                //ʵ������ӡ���ô���
                DialogResult result = pageSetupDialog1.ShowDialog();
                //���ô�ӡ�ĵ�����Ĵ�ӡ��
                document.PrinterSettings = pageSetupDialog1.PrinterSettings;
                //���ô�ӡ�ĵ������ҳ������Ϊ�û��ڴ�ӡ���öԻ����е�����
                document.DefaultPageSettings = pageSetupDialog1.PageSettings;
                //ҳ������
                int i;
                IEnumerator paperSizes = pageSetupDialog1.PrinterSettings.PaperSizes.GetEnumerator();
                paperSizes.Reset();

                for (i = 0; i < pageSetupDialog1.PrinterSettings.PaperSizes.Count; ++i)
                {
                    paperSizes.MoveNext();
                    if (((PaperSize)paperSizes.Current).Kind == document.DefaultPageSettings.PaperSize.Kind)
                    {
                        document.DefaultPageSettings.PaperSize = ((PaperSize)paperSizes.Current);
                    }
                }

                //��ʼ��ֽ�źʹ�ӡ��
                IPaper paper = new PaperClass();
                IPrinter printer = new EmfPrinterClass();
                //������ӡ�������ֽ�Ŷ��� 
                paper.Attach(pageSetupDialog1.PrinterSettings.GetHdevmode(pageSetupDialog1.PageSettings).ToInt32(), pageSetupDialog1.PrinterSettings.GetHdevnames().ToInt32());
                printer.Paper = paper;
                PrintPagelayoutControl.Printer = printer;
            }
            catch { }
        }
        #endregion
        #region ��ӡԤ��
        private void InitializePrintPreviewDialog()
        {
            printPreviewDialog1 = new PrintPreviewDialog();
            //���ô�ӡԤ���ĳߴ磬λ�ã����ƣ��Լ���С�ߴ�
            printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 600);
            printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
            printPreviewDialog1.Name = "��ӡԤ���Ի���";
            printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
            printPreviewDialog1.UseAntiAlias = true;
            this.document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);
        }
        private void btnPrintpreview_Click(object sender, EventArgs e)
        {
            try
            {
                //��ʼ����ǰ��ӡҳ��
                m_CurrentPrintPage = 0;
                document.DocumentName = PrintPagelayoutControl.DocumentFilename;
                printPreviewDialog1.Document = document;
                printPreviewDialog1.ShowDialog();
            }
            catch { }
        }
        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //�� PrintPreviewDialog��Show��������ʱ��������δ��� 
                PrintPagelayoutControl.Page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingTile;
                //��ȡ��ӡ�ֱ���
                short dpi = (short)e.Graphics.DpiX;
                IEnvelope devBounds = new EnvelopeClass();
                //��ȡ��ӡҳ��
                IPage page = PrintPagelayoutControl.Page;
                //��ȡ��ӡ��ҳ��
                short printPageCount;
                printPageCount = PrintPagelayoutControl.get_PrinterPageCount(0);
                m_CurrentPrintPage++;

                //ѡ���ӡ��
                IPrinter printer = PrintPagelayoutControl.Printer;
                //��ô�ӡ��ҳ���С
                page.GetDeviceBounds(printer, m_CurrentPrintPage, 0, dpi, devBounds);
                //���ҳ���С�����귶Χ�����ĸ��ǵ�����
                tagRECT deviceRect;
                double xmin, ymin, xmax, ymax;
                devBounds.QueryCoords(out xmin, out ymin, out xmax, out ymax);
                deviceRect.bottom = (int)ymax;
                deviceRect.left = (int)xmin;
                deviceRect.top = (int)ymin;
                deviceRect.right = (int)xmax;
                //ȷ����ǰ��ӡҳ��Ĵ�С
                IEnvelope visBounds = new EnvelopeClass();
                page.GetPageBounds(printer, m_CurrentPrintPage, 0, visBounds);
                IntPtr hdc = e.Graphics.GetHdc();
                PrintPagelayoutControl.ActiveView.Output(hdc.ToInt32(), dpi, ref deviceRect, visBounds, m_TrackCancel);
                e.Graphics.ReleaseHdc(hdc);
                if (m_CurrentPrintPage < printPageCount)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch
            { }
        }
        #endregion
        #region ��ӡ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //��ʾ������ť            
                printDialog1.ShowHelp = true;
                printDialog1.Document = document;
                //��ʾ��ӡ����
                DialogResult result = printDialog1.ShowDialog();
                // �����ʾ�ɹ������ӡ.
                if (result == DialogResult.OK) document.Print();
                Close();
            }
            catch { }
        }
        #endregion
        #region  PageLayoutconrolͬ�� 
        private void syn(AxPageLayoutControl mainlayoutControl)
        {
            IObjectCopy objectcopy = new ObjectCopyClass();
            object tocopymap = mainlayoutControl.ActiveView.GraphicsContainer;   //��ȡmapcontrol�е�map   �����ԭʼ��
            object copiedmap = objectcopy.Copy(tocopymap);       //����һ��map����һ������
            object tooverwritemap = PrintPagelayoutControl.ActiveView.GraphicsContainer;    //IActiveView.FocusMap : The map that tools and controls act on. �ؼ��͹������õĵ�ͼ������ǵ�ǰ��ͼ�ɣ�����
            objectcopy.Overwrite(copiedmap, ref tooverwritemap);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objectcopy);
            IGraphicsContainer mainGraphCon = tooverwritemap as IGraphicsContainer;
            mainGraphCon.Reset();
            IElement pElement = mainGraphCon.Next();
            IArray pArray = new ArrayClass();
            while (pElement != null)
            {               
                pArray.Add(pElement);
                pElement = mainGraphCon.Next();
            }
            int pElementCount = pArray.Count;
            IPageLayout PrintPageLayout = PrintPagelayoutControl.PageLayout;
            IGraphicsContainer PrintGraphCon = PrintPageLayout as IGraphicsContainer;
            PrintGraphCon.Reset();
            IElement pPrintElement = PrintGraphCon.Next();
            while (pPrintElement != null)
            {
                PrintGraphCon.DeleteElement(pPrintElement);
                pPrintElement = PrintGraphCon.Next();
            }
            for (int i = 0; i < pArray.Count; i++)
            {
                PrintGraphCon.AddElement(pArray.get_Element(pElementCount - 1 - i) as IElement, 0);
            }
            PrintPagelayoutControl.Refresh();

        }
        #endregion
    }  
}
