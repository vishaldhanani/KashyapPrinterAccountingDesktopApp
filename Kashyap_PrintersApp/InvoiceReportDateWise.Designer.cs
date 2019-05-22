namespace Kashyap_PrintersApp
{
    partial class InvoiceReportDateWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceReportDateWise));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SalesInvoiceDetailsNewtbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KashyapPrinterDataSet = new Kashyap_PrintersApp.KashyapPrinterDataSet();
            this.SalesOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.reportViewer1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Name = "label2";
            // 
            // txtEndDate
            // 
            resources.ApplyResources(this.txtEndDate, "txtEndDate");
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Enter += new System.EventHandler(this.txtEndDate_Enter);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
            // 
            // txtStartDate
            // 
            resources.ApplyResources(this.txtStartDate, "txtStartDate");
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtStartDate_MaskInputRejected);
            this.txtStartDate.Enter += new System.EventHandler(this.txtStartDate_Enter);
            this.txtStartDate.Leave += new System.EventHandler(this.txtStartDate_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Name = "label1";
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
            // InvoiceReportDateWise
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceReportDateWise";
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
    }
}