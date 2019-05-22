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


namespace Kashyap_PrintersApp
{
    public partial class EditInvoiceEntry : Form
    {
        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;
        string st;
        public static string OrderNoEdit = string.Empty;
        public static string OrderNoPrint = string.Empty;

        public EditInvoiceEntry()
        {
            InitializeComponent();
            GridViewFill();
            dataGridView2.Hide();
            txtBuyerName.Focus();

        }

        //public void GridViewFill()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(str))
        //        {
        //            con.Open();
        //            st = "select OrderNo,BuyerName,MobileNo,Date,Total,GrandTotal from SalesOrder where Flag=('0')";
        //            SqlCommand cmd = new SqlCommand(st, con);
        //            try
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                {
        //                    using (DataTable dt = new DataTable())
        //                    {
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            dataGridView1.Rows.Add();
        //                            dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[0];
        //                            dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[1];
        //                            dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i].ItemArray[2];
        //                            dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i].ItemArray[3];
        //                            dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i].ItemArray[4];
        //                            dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i].ItemArray[5];
        //                            dataGridView1.Rows[i].Cells[6].Value = "Show";
        //                            dataGridView1.Rows[i].Cells[7].Value = "Edit";
        //                            dataGridView1.Rows[i].Cells[8].Value = "Delete";

        //                            con.Close();
        //                            con.Dispose();
        //                        }
        //                    }
        //                }
        //            }

        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        public void GridViewFill()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    st = "select OrderNo as [No],[InvoiceNo],BuyerName as [Buyer Name],MobileNo as [Mobile No],Date,Total, GrandTotal as [Grand Total]  from SalesOrder where Flag=('0') Order by OrderNo DESC";
                    SqlCommand cmd = new SqlCommand(st, con);
                    try
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                                DataGridViewLinkColumn col1 = new DataGridViewLinkColumn();
                                col1.DataPropertyName = "Show";
                                col1.Name = "Show";
                                col1.Text = "Show";
                                dataGridView1.Columns.Add(col1);
                                col1.UseColumnTextForLinkValue = true;

                                DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                                col.DataPropertyName = "Edit";
                                col.Name = "Edit";
                                col.Text = "Edit";
                                dataGridView1.Columns.Add(col);
                                col.UseColumnTextForLinkValue = true;

                                DataGridViewLinkColumn col2 = new DataGridViewLinkColumn();
                                col2.DataPropertyName = "Delete";
                                col2.Name = "Delete";
                                col2.Text = "Delete";
                                dataGridView1.Columns.Add(col2);
                                col2.UseColumnTextForLinkValue = true;

                                DataGridViewLinkColumn col3 = new DataGridViewLinkColumn();
                                col3.DataPropertyName = "Print";
                                col3.Name = "Print";
                                col3.Text = "Print";
                                dataGridView1.Columns.Add(col3);
                                col3.UseColumnTextForLinkValue = true;

                                con.Close();
                                con.Dispose();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void GridViewItemsFill(string Value)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    st = "select OrderNoF as [No], [InvoiceNo], Par as Particulares,Qty as Quantity ,Size,Rate,Amt as Amount from SalesInvoiceDetailsNewtb where OrderNoF= " + Value.ToString() + "and Flag =('0') order by OrderNoF ASC";
                    SqlCommand cmd = new SqlCommand(st, con);
                    SqlDataAdapter da;
                    da = new SqlDataAdapter(cmd);
                    DataSet ds;
                    ds = new DataSet();
                    da.Fill(ds, "SalesInvoiceDetailsNewtb");
                    dataGridView2.DataSource = ds.Tables["SalesInvoiceDetailsNewtb"];
                    dataGridView2.Show();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Show")  //(dataGridView1.Columns[e.ColumnIndex].Name == "Show")  //(dataGridView1.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        GridViewItemsFill(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        dataGridView2.Focus();
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        DialogResult result;
                        result = MessageBox.Show("Are you sure you want to Delete this Invoice ??", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            using (SqlConnection con = new SqlConnection(str))
                            {
                                SqlCommand cmd;
                                con.Open();
                                string st = "update SalesOrder set Flag =('1') where OrderNo =" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "";
                                cmd = new SqlCommand(st, con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                con.Dispose();
                            }

                            using (SqlConnection con = new SqlConnection(str))
                            {
                                SqlCommand cmd;
                                con.Open();
                                string st = "update SalesInvoiceDetailsNewtb set Flag =('1') where OrderNoF =" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "";
                                cmd = new SqlCommand(st, con);
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("Invoice No : " + dataGridView1.Rows[i].Cells[4].Value.ToString() + " Deleted Successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                                con.Dispose();
                            }
                            MessageBox.Show("Invoice No : " + dataGridView1.Rows[i].Cells[4].Value.ToString() + " Deleted Successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.Rows.RemoveAt(i);
                        }
                        else
                        {

                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        OrderNoEdit = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        this.Close();
                        InvoiceEntryModify obj = new InvoiceEntryModify();
                        obj.Show();
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Print")
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        string m = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        OrderNoPrint = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        InvoiceReportBuyerWise obj = new InvoiceReportBuyerWise();
                        obj.Show();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    dataGridView2.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtBuyerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    //st = "select OrderNo,BuyerName,MobileNo,Date,Total,GrandTotal from SalesOrder where Flag=('0') and BuyerName like '" + txtBuyerName.Text + "%'";
                    //SqlCommand cmd = new SqlCommand(st, con);
                    SqlDataAdapter adapt;
                    DataTable dt;
                    try
                    {
                        adapt = new SqlDataAdapter("select OrderNo as [Invoice No],BuyerName as [Buyer Name],MobileNo as [Mobile No],Date,Total,GrandTotal as [Grand Total]  from SalesOrder where Flag=('0') Order by OrderNo DESC", con);
                        dt = new DataTable();
                        adapt.Fill(dt);
                        //dataGridView1.DataSource = dt;
                        //con.Close();
                        DataView DV = new DataView(dt);
                        DV.RowFilter = string.Format("[Buyer Name] LIKE '%{0}%'", txtBuyerName.Text);
                        dataGridView1.DataSource = DV;
                        dataGridView1.AllowUserToOrderColumns = false;
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtBuyerName.Text)) && (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text)))
                {
                    MessageBox.Show("Please enter Buyer Name or Date for Searching Records!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuyerName.Focus();
                }
                else
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
                    else if (Convert.ToInt16(DateTime.Compare(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null), DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null))) > 0)
                    {
                        MessageBox.Show("Start Date should not be allowed greater than End Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtStartDate.Focus();
                    }
                    else
                    {
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            con.Open();
                            //st = "select OrderNo,BuyerName,MobileNo,Date,Total,GrandTotal from SalesOrder where Flag=('0') and BuyerName like '" + txtBuyerName.Text + "%'";
                            //SqlCommand cmd = new SqlCommand(st, con);
                            SqlDataAdapter adapt;
                            DataTable dt;
                            try
                            {
                                adapt = new SqlDataAdapter("select OrderNo as [Invoice No],BuyerName as [Buyer Name],MobileNo as [Mobile No],Date,Total,GrandTotal as [Grand Total]  from SalesOrder where Flag=('0') and Date between '" + txtStartDate.Text + "' and '" + txtEndDate.Text + "' Order by OrderNo DESC", con);
                                dt = new DataTable();
                                adapt.Fill(dt);
                                dataGridView1.DataSource = dt;
                                DataView DV = new DataView(dt);
                                //DV.RowFilter = string.Format("[Buyer Name] LIKE '%{0}%'", txtBuyerName.Text);
                                //dataGridView1.DataSource = DV;
                                dataGridView1.AllowUserToOrderColumns = false;
                                con.Close();
                                con.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtEndDate_Enter(object sender, EventArgs e)
        {
            txtEndDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtEndDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtEndDate.ForeColor = System.Drawing.Color.Black;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                txtBuyerName.Text = string.Empty;
                txtStartDate.Text = string.Empty;
                txtEndDate.Text = string.Empty;
                txtBuyerName.Focus();
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    //st = "select OrderNo,BuyerName,MobileNo,Date,Total,GrandTotal from SalesOrder where Flag=('0') and BuyerName like '" + txtBuyerName.Text + "%'";
                    //SqlCommand cmd = new SqlCommand(st, con);
                    SqlDataAdapter adapt;
                    DataTable dt;
                    try
                    {
                        adapt = new SqlDataAdapter("select OrderNo as [Invoice No],BuyerName as [Buyer Name],MobileNo as [Mobile No],Date,Total,GrandTotal as [Grand Total]  from SalesOrder where Flag=('0')  Order by OrderNo DESC", con);
                        dt = new DataTable();
                        adapt.Fill(dt);
                        dataGridView1.DataSource = dt;
                        DataView DV = new DataView(dt);
                        //DV.RowFilter = string.Format("[Buyer Name] LIKE '%{0}%'", txtBuyerName.Text);
                        //dataGridView1.DataSource = DV;
                        dataGridView1.AllowUserToOrderColumns = false;
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        private void EditInvoiceEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
