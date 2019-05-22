using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WinForms;


namespace Kashyap_PrintersApp
{
    public partial class InvoiceReportBuyerWise : Form
    {
        string OrderNo = string.Empty;
        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;

        public InvoiceReportBuyerWise()
        {
            InitializeComponent();                       
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }   

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(txtBuyerName.Text))
        //        {
        //            MessageBox.Show("Error: Please enter Buyer Name!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtBuyerName.Focus();
        //        }
        //        else
        //        {
        //            string st = string.Empty;
        //            reportViewer1.Visible = true;
        //            reportViewer1.ProcessingMode = ProcessingMode.Local;
        //            reportViewer1.LocalReport.ReportPath = (@"J:\Kashyap_Printers\Kashyap_PrintersApp\Kashyap_PrintersApp\InvoiceRpt.rdlc");
        //            DataSet ds = new DataSet();

        //            using (SqlConnection con = new SqlConnection(str))
        //            {
        //                con.Open();
        //                st = "select * from SalesOrder as S inner join SalesInvoiceDetailsNewtb as I on S.OrderNo = I.OrderNoF where I.OrderNoF='" + OrderNo.ToString() + "'";
        //                SqlCommand cmd = new SqlCommand(st, con);
        //                SqlDataAdapter da;
        //                da = new SqlDataAdapter(cmd);
        //                da.Fill(ds, "Invoice");
        //                con.Close();
        //            }

        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                ReportDataSource rds = new ReportDataSource("Invoice", ds.Tables[0]);
        //                reportViewer1.LocalReport.DataSources.Clear();
        //                reportViewer1.LocalReport.DataSources.Add(rds);
        //                reportViewer1.LocalReport.Refresh();
        //                reportViewer1.RefreshReport();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
             
        private void InvoiceReportBuyerWise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesInvoiceDetailsNewtb' table. You can move, or remove it, as needed.
            this.SalesInvoiceDetailsNewtbTableAdapter.Fill(this.KashyapPrinterDataSet.SalesInvoiceDetailsNewtb);
            // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesOrder' table. You can move, or remove it, as needed.
            this.SalesOrderTableAdapter.Fill(this.KashyapPrinterDataSet.SalesOrder);
            this.reportViewer1.RefreshReport();
            if (!string.IsNullOrEmpty(InvoiceEntry.OrderNo))
            {
                OrderNo = InvoiceEntry.OrderNo;
            }
            else if(!string.IsNullOrEmpty(InvoiceEntryModify.OrderNo))
            {
                OrderNo = InvoiceEntryModify.OrderNo;
            }
            else
            {
                OrderNo = EditInvoiceEntry.OrderNoPrint;
            }
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

            string st = string.Empty;
            reportViewer1.Visible = true;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = (@"J:\Kashyap_Printers\Kashyap_PrintersApp\Kashyap_PrintersApp\InvoiceRpt.rdlc");
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                st = "select * from SalesInvoiceDetailsNewtb as I  inner join SalesOrder as S on S.OrderNo = I.OrderNoF where I.OrderNoF='" + OrderNo.ToString() + "'";
                SqlCommand cmd = new SqlCommand(st, con);
                SqlDataAdapter da;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Invoice");
                con.Close();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {                
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                int i = dt.Rows.Count;
                
                for (int j = i; j < 12; j++)
                {                    
                    DataRow row = dt.NewRow();
                    row["No"] = j.ToString();
                    dt.Rows.Add(row);                                        
                }
                                
                ReportDataSource rds = new ReportDataSource("Invoice", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
                OrderNo = string.Empty;
            }
            else
            {
                MessageBox.Show("Data Not Found!!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.SalesInvoiceDetailsNewtbTableAdapter.FillBy(this.KashyapPrinterDataSet.SalesInvoiceDetailsNewtb);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
