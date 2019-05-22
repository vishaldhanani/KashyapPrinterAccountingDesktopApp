namespace Kashyap_PrintersApp
{
    partial class InvoiceReportBuyerNameWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceReportBuyerNameWise));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SalesInvoiceDetailsNewtbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KashyapPrinterDataSet = new Kashyap_PrintersApp.KashyapPrinterDataSet();
            this.SalesOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.lblBuyerName = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtBuyerName);
            this.groupBox1.Controls.Add(this.lblBuyerName);
            this.groupBox1.Controls.Add(this.reportViewer1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuyerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtBuyerName, "txtBuyerName");
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Enter += new System.EventHandler(this.txtBuyerName_Enter);
            this.txtBuyerName.Leave += new System.EventHandler(this.txtBuyerName_Leave);
            // 
            // lblBuyerName
            // 
            resources.ApplyResources(this.lblBuyerName, "lblBuyerName");
            this.lblBuyerName.BackColor = System.Drawing.Color.Transparent;
            this.lblBuyerName.ForeColor = System.Drawing.Color.Teal;
            this.lblBuyerName.Name = "lblBuyerName";
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
            // InvoiceReportBuyerNameWise
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceReportBuyerNameWise";
            this.Load += new System.EventHandler(this.InvoiceReportBuyerWise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesInvoiceDetailsNewtbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KashyapPrinterDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalesInvoiceDetailsNewtbBindingSource;
        private KashyapPrinterDataSet KashyapPrinterDataSet;
        private System.Windows.Forms.BindingSource SalesOrderBindingSource;
        private KashyapPrinterDataSetTableAdapters.SalesInvoiceDetailsNewtbTableAdapter SalesInvoiceDetailsNewtbTableAdapter;
        private KashyapPrinterDataSetTableAdapters.SalesOrderTableAdapter SalesOrderTableAdapter;
        private System.Windows.Forms.TextBox txtBuyerName;
        private System.Windows.Forms.Label lblBuyerName;
        private System.Windows.Forms.Button btnSearch;
    }
}