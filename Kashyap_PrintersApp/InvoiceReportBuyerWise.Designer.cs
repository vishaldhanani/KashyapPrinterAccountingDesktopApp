namespace Kashyap_PrintersApp
{
    partial class InvoiceReportBuyerWise
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceReportBuyerWise));
            this.SalesInvoiceDetailsNewtbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KashyapPrinterDataSet = new Kashyap_PrintersApp.KashyapPrinterDataSet();
            this.SalesOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SalesInvoiceDetailsNewtbTableAdapter = new Kashyap_PrintersApp.KashyapPrinterDataSetTableAdapters.SalesInvoiceDetailsNewtbTableAdapter();
            this.SalesOrderTableAdapter = new Kashyap_PrintersApp.KashyapPrinterDataSetTableAdapters.SalesOrderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInvoiceDetailsNewtbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KashyapPrinterDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SalesInvoiceDetailsNewtbBindingSource
            // 
            this.SalesInvoiceDetailsNewtbBindingSource.DataMember = "SalesInvoiceDetailsNewtb";
            this.SalesInvoiceDetailsNewtbBindingSource.DataSource = this.KashyapPrinterDataSet;
            // 
            // KashyapPrinterDataSet
            // 
            this.KashyapPrinterDataSet.DataSetName = "KashyapPrinterDataSet";
            this.KashyapPrinterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SalesOrderBindingSource
            // 
            this.SalesOrderBindingSource.DataMember = "SalesOrder";
            this.SalesOrderBindingSource.DataSource = this.KashyapPrinterDataSet;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.reportViewer1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SalesInvoiceDetailsNewtbBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.SalesOrderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kashyap_PrintersApp.Report1.rdlc";
            resources.ApplyResources(this.reportViewer1, "reportViewer1");
            this.reportViewer1.Name = "reportViewer1";
            // 
            // SalesInvoiceDetailsNewtbTableAdapter
            // 
            this.SalesInvoiceDetailsNewtbTableAdapter.ClearBeforeFill = true;
            // 
            // SalesOrderTableAdapter
            // 
            this.SalesOrderTableAdapter.ClearBeforeFill = true;
            // 
            // InvoiceReportBuyerWise
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceReportBuyerWise";
            this.Load += new System.EventHandler(this.InvoiceReportBuyerWise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesInvoiceDetailsNewtbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KashyapPrinterDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private KashyapPrinterDataSet KashyapPrinterDataSet;
        private System.Windows.Forms.BindingSource SalesOrderBindingSource;
        private KashyapPrinterDataSetTableAdapters.SalesInvoiceDetailsNewtbTableAdapter SalesInvoiceDetailsNewtbTableAdapter;
        private KashyapPrinterDataSetTableAdapters.SalesOrderTableAdapter SalesOrderTableAdapter;
        public System.Windows.Forms.BindingSource SalesInvoiceDetailsNewtbBindingSource;
    }
}