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
    public partial class InvoiceReportBuyerNameWise : Form
    {
        string OrderNo = string.Empty;
        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;
        public static string BuyerName = string.Empty;
        public InvoiceReportBuyerNameWise()
        {
            InitializeComponent();
            BuyerTextSuggestion();
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


        protected void BuyerTextSuggestion()
        {
            try
            {
                string Qry = "select BuyerName,BuyerAddress,MobileNo from SalesOrder where Flag=('0')";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd1 = new SqlCommand(Qry, con);
                SqlDataReader dr;

                txtBuyerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBuyerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                try
                {
                    con.Open();
                    dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        string st = dr["BuyerName"].ToString();
                        MyCollection.Add(st);
                    }
                    con.Close();
                    con.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtBuyerName.AutoCompleteCustomSource = MyCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
            else if (!string.IsNullOrEmpty(InvoiceEntryModify.OrderNo))
            {
                OrderNo = InvoiceEntryModify.OrderNo;
            }
            else
            {
                OrderNo = EditInvoiceEntry.OrderNoPrint;
            }

            string st = string.Empty;
            reportViewer1.Visible = true;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = (@"J:\Kashyap_Printers\Kashyap_PrintersApp\Kashyap_PrintersApp\InvoiceSummaryRpt.rdlc");
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
                ReportDataSource rds = new ReportDataSource("Invoice", ds.Tables[0]);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
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

        private void txtBuyerName_Enter(object sender, EventArgs e)
        {
            txtBuyerName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerName.ForeColor = System.Drawing.Color.Black;
        }

        private void txtBuyerName_Leave(object sender, EventArgs e)
        {
            txtBuyerName.BackColor = System.Drawing.Color.White;
            txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerName.ForeColor = System.Drawing.Color.Black;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBuyerName.Text))
                {
                    MessageBox.Show("Please enter Buyer Name!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuyerName.Focus();
                }
                else
                {
                    // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesInvoiceDetailsNewtb' table. You can move, or remove it, as needed.
                    this.SalesInvoiceDetailsNewtbTableAdapter.Fill(this.KashyapPrinterDataSet.SalesInvoiceDetailsNewtb);
                    // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesOrder' table. You can move, or remove it, as needed.
                    this.SalesOrderTableAdapter.Fill(this.KashyapPrinterDataSet.SalesOrder);
                    this.reportViewer1.RefreshReport();

                    string st = string.Empty;
                    reportViewer1.Visible = true;
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = (@"J:\Kashyap_Printers\Kashyap_PrintersApp\Kashyap_PrintersApp\InvoiceSummaryBuyerWiseRpt.rdlc");
                    DataSet ds = new DataSet();

                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();
                        st = "select * from SalesInvoiceDetailsNewtb as I  inner join SalesOrder as S on S.OrderNo = I.OrderNoF where I.BuyerName='" + txtBuyerName.Text + "'and I.Flag=('0')";
                        SqlCommand cmd = new SqlCommand(st, con);
                        SqlDataAdapter da;
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds, "Invoice");
                        con.Close();
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ReportDataSource rds = new ReportDataSource("Invoice", ds.Tables[0]);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(rds);
                        reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No Records Found!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}