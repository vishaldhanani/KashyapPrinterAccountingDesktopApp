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
    public partial class InvoiceReportDateWise : Form
    {
        string OrderNo = string.Empty;
        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;
        public static string BuyerName = string.Empty;
        public InvoiceReportDateWise()
        {
            InitializeComponent();            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {               
                

                if (!txtStartDate.MaskCompleted)
                {
                    MessageBox.Show("Please enter Start Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStartDate.Focus();
                }
                else if (!txtEndDate.MaskCompleted)
                {
                    MessageBox.Show("Please enter End Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEndDate.Focus();
                }
                else if ((DateTime.Compare(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null), DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null))) > 0)
                {
                    MessageBox.Show("Start Date should not be allowed greater than End Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStartDate.Focus();
                }
                else
                {
                    DateTime FromDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                    DateTime ToDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
                   // int result = DateTime.Compare(FromDate, ToDate);
                    // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesInvoiceDetailsNewtb' table. You can move, or remove it, as needed.
                    this.SalesInvoiceDetailsNewtbTableAdapter.Fill(this.KashyapPrinterDataSet.SalesInvoiceDetailsNewtb);
                    // TODO: This line of code loads data into the 'KashyapPrinterDataSet.SalesOrder' table. You can move, or remove it, as needed.
                    this.SalesOrderTableAdapter.Fill(this.KashyapPrinterDataSet.SalesOrder);
                    this.reportViewer1.RefreshReport();

                    string st = string.Empty;
                    reportViewer1.Visible = true;
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = (@"J:\Kashyap_Printers\Kashyap_PrintersApp\Kashyap_PrintersApp\InvoiceSummaryDateWiseRpt.rdlc");
                    DataSet ds = new DataSet();

                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();
                        st = "select * from SalesInvoiceDetailsNewtb as I inner join SalesOrder as S on S.OrderNo = I.OrderNoF and I.Date between '" + txtStartDate.Text + "' and '" + txtEndDate.Text + "'and I.Flag=('0')";
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

                        ReportDataSource rds = new ReportDataSource("Invoice", dt);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtStartDate.Focus();
        }

        private void txtStartDate_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime FromDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);                                
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please enter correct Start Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtStartDate.Focus();
            //}

            txtStartDate.BackColor = System.Drawing.Color.White;
            txtStartDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtStartDate.ForeColor = System.Drawing.Color.Black;
        }

        private void txtStartDate_Enter(object sender, EventArgs e)
        {
            txtStartDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtStartDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtStartDate.ForeColor = System.Drawing.Color.Black;
        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime FromDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please enter correct End Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtEndDate.Focus();
            //}

            txtEndDate.BackColor = System.Drawing.Color.White;
            txtEndDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtEndDate.ForeColor = System.Drawing.Color.Black;
        }

        private void txtEndDate_Enter(object sender, EventArgs e)
        {
            txtEndDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtEndDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtEndDate.ForeColor = System.Drawing.Color.Black;
        }

        private void txtStartDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
       
    }
}