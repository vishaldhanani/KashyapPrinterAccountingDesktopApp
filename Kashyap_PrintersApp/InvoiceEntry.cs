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
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;


namespace Kashyap_PrintersApp
{
    public partial class InvoiceEntry : Form
    {
        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;
        public InvoiceEntry()
        {
            InitializeComponent();
            BuyerTextSuggestion();

        }
        string OrderNoEdit = EditInvoiceEntry.OrderNoEdit;

        private int childFormNumber = 0;
        public static string OrderNo = string.Empty;
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void InvoiceEntry_Load(object sender, EventArgs e)
        {
            txtDate.Text = (System.DateTime.Now).ToString("dd/MM/yyyy");
            //txtBuyerName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            //txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtBuyerName.ForeColor = System.Drawing.Color.Black;
            txtCGST.Text = "4";
            txtSGST.Text = "1";
            txtIGST.Text = "0";
            btnSave.Enabled = false;
            txtInvoiceNo.Focus();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            
            txtDate.BackColor = System.Drawing.Color.White;
            txtDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDate.ForeColor = System.Drawing.Color.Black;

        }


        #region KeyPress Events
        private void txtQty1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtRate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
            //if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            //    e.Handled = true;
        }

        private void txtCGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
        }

        #endregion

        #region KeyLeave Events
        private void txtBuyerAddress_Leave(object sender, EventArgs e)
        {
            txtBuyerAddress.BackColor = System.Drawing.Color.White;
            txtBuyerAddress.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerAddress.ForeColor = System.Drawing.Color.Black;
        }
        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            // txtDate.Focus();
            txtMobileNo.BackColor = System.Drawing.Color.White;
            txtMobileNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtMobileNo.ForeColor = System.Drawing.Color.Black;
        }
        private void txtBuyerName_Leave(object sender, EventArgs e)
        {
            txtBuyerName.BackColor = System.Drawing.Color.White;
            txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerName.ForeColor = System.Drawing.Color.Black;

            string Qry1 = "select BuyerName,BuyerAddress,MobileNo,BuyerTINNo,ChallanNo,PONo,ReferenceBy,DispatchBy,LRNo from SalesOrder where BuyerName='" + txtBuyerName.Text + "' and Flag=('0') order by PostingDate DESC";
            SqlConnection con1 = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(Qry1, con1);
            SqlDataReader dr1;

            try
            {
                con1.Open();
                dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    txtBuyerAddress.Text = dr1["BuyerAddress"].ToString();
                    txtTINNo.Text = dr1["BuyerTINNo"].ToString();
                    txtMobileNo.Text = dr1["MobileNo"].ToString();
                    txtDate.Text = (System.DateTime.Now).ToString("dd/MM/yyyy");
                    txtChallanNo.Text = dr1["ChallanNo"].ToString();
                    txtPONo.Text = dr1["PONo"].ToString();
                    txtRefBy.Text = dr1["ReferenceBy"].ToString();
                    txtDispatchBy.Text = dr1["DispatchBy"].ToString();
                    txtLRNo.Text = dr1["LRNo"].ToString();
                }
                con1.Close();
                con1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void txtPar1_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtPar1.Text))
            //{
            //    MessageBox.Show("Please enter Particular!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPar1.Focus();
            //}
            //else
            //{
            //    txtPar1.BackColor = System.Drawing.Color.White;
            //    txtPar1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    txtPar1.ForeColor = System.Drawing.Color.Black;
            //}
            txtPar1.BackColor = System.Drawing.Color.White;
            txtPar1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar1.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty1_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtQty1.Text) || txtQty1.Text == "0" || txtQty1.Text == "00" || txtQty1.Text == "0.00")
            //{
            //    MessageBox.Show("Please enter Quantity!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtQty1.Focus();
            //}
            //else
            //{
            //    txtQty1.BackColor = System.Drawing.Color.White;
            //    txtQty1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //    txtQty1.ForeColor = System.Drawing.Color.Black;
            //}
            txtQty1.BackColor = System.Drawing.Color.White;
            txtQty1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty1.ForeColor = System.Drawing.Color.Black;

        }

        private void txtSize1_Leave(object sender, EventArgs e)
        {

            txtSize1.BackColor = System.Drawing.Color.White;
            txtSize1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize1.ForeColor = System.Drawing.Color.Black;

        }

        private void txtRate1_Leave(object sender, EventArgs e)
        {
            txtRate1.BackColor = System.Drawing.Color.White;
            txtRate1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate1.ForeColor = System.Drawing.Color.Black;

            Decimal Amt1 = 0;
            Amt1 = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(txtRate1.Text);
            txtAmt1.Text = (Amt1).ToString("0.00");
            txtTotal.Text = Amt1.ToString("0.00");
        }

        private void txtPar2_Leave(object sender, EventArgs e)
        {
            txtPar2.BackColor = System.Drawing.Color.White;
            txtPar2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty2_Leave(object sender, EventArgs e)
        {
            txtQty2.BackColor = System.Drawing.Color.White;
            txtQty2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty2.ForeColor = System.Drawing.Color.Black;

        }

        private void txtSize2_Leave(object sender, EventArgs e)
        {
            txtSize2.BackColor = System.Drawing.Color.White;
            txtSize2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate2.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate2.Focus();
            }
            else
            {
                Decimal Amt2 = 0;
                Amt2 = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(txtRate2.Text);
                txtAmt2.Text = (Amt2).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + (Amt2);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate2.BackColor = System.Drawing.Color.White;
                txtRate2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate2.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void txtPar3_Leave(object sender, EventArgs e)
        {

            txtPar3.BackColor = System.Drawing.Color.White;
            txtPar3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar3.ForeColor = System.Drawing.Color.Black;

        }

        private void txtQty3_Leave(object sender, EventArgs e)
        {

            txtQty3.BackColor = System.Drawing.Color.White;
            txtQty3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty3.ForeColor = System.Drawing.Color.Black;

        }

        private void txtSize3_Leave(object sender, EventArgs e)
        {

            txtSize3.BackColor = System.Drawing.Color.White;
            txtSize3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize3.ForeColor = System.Drawing.Color.Black;

        }

        private void txtRate3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate3.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate3.Focus();
            }
            else
            {
                Decimal Amt3 = 0;
                Amt3 = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(txtRate3.Text);
                txtAmt3.Text = (Amt3).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + (Amt3);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate3.BackColor = System.Drawing.Color.White;
                txtRate3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate3.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void txtPar4_Leave(object sender, EventArgs e)
        {

            txtPar4.BackColor = System.Drawing.Color.White;
            txtPar4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar4.ForeColor = System.Drawing.Color.Black;


        }

        private void txtQty4_Leave(object sender, EventArgs e)
        {

            txtQty4.BackColor = System.Drawing.Color.White;
            txtQty4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty4.ForeColor = System.Drawing.Color.Black;


        }

        private void txtSize4_Leave(object sender, EventArgs e)
        {

            txtSize4.BackColor = System.Drawing.Color.White;
            txtSize4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate4.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate4.Focus();
            }
            else
            {
                Decimal Amt4 = 0;
                Amt4 = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(txtRate4.Text);
                txtAmt4.Text = (Amt4).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + (Amt4);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate4.BackColor = System.Drawing.Color.White;
                txtRate4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate4.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtPar5_Leave(object sender, EventArgs e)
        {
            txtPar5.BackColor = System.Drawing.Color.White;
            txtPar5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty5_Leave(object sender, EventArgs e)
        {
            txtQty5.BackColor = System.Drawing.Color.White;
            txtQty5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty5.ForeColor = System.Drawing.Color.Black;

        }

        private void txtSize5_Leave(object sender, EventArgs e)
        {

            txtSize5.BackColor = System.Drawing.Color.White;
            txtSize5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate5.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate5.Focus();
            }
            else
            {
                Decimal Amt5 = 0;
                Amt5 = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(txtRate5.Text);
                txtAmt5.Text = (Amt5).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + (Amt5);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate5.BackColor = System.Drawing.Color.White;
                txtRate5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate5.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtPar6_Leave(object sender, EventArgs e)
        {
            txtPar6.BackColor = System.Drawing.Color.White;
            txtPar6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty6_Leave(object sender, EventArgs e)
        {
            txtQty6.BackColor = System.Drawing.Color.White;
            txtQty6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize6_Leave(object sender, EventArgs e)
        {
            txtSize6.BackColor = System.Drawing.Color.White;
            txtSize6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate6.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate6.Focus();
            }
            else
            {
                Decimal Amt6 = 0;
                Amt6 = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(txtRate6.Text);
                txtAmt6.Text = (Amt6).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + (Amt6);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate6.BackColor = System.Drawing.Color.White;
                txtRate6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate6.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtPar7_Leave(object sender, EventArgs e)
        {
            txtPar7.BackColor = System.Drawing.Color.White;
            txtPar7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty7_Leave(object sender, EventArgs e)
        {
            txtQty7.BackColor = System.Drawing.Color.White;
            txtQty7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize7_Leave(object sender, EventArgs e)
        {
            txtSize7.BackColor = System.Drawing.Color.White;
            txtSize7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate7_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtRate7.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate7.Focus();
            }
            else
            {
                Decimal Amt7 = 0;
                Amt7 = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(txtRate7.Text);
                txtAmt7.Text = (Amt7).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + (Amt7);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate7.BackColor = System.Drawing.Color.White;
                txtRate7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate7.ForeColor = System.Drawing.Color.Black;
            }
            //txtPar8.Focus();
            //txtRate7.BackColor = System.Drawing.Color.White;
            //txtRate7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtRate7.ForeColor = System.Drawing.Color.Black;

            //txtPar8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            //txtPar8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtPar8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar8_Leave(object sender, EventArgs e)
        {
            txtPar8.BackColor = System.Drawing.Color.White;
            txtPar8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty8_Leave(object sender, EventArgs e)
        {
            txtQty8.BackColor = System.Drawing.Color.White;
            txtQty8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize8_Leave(object sender, EventArgs e)
        {
            txtSize8.BackColor = System.Drawing.Color.White;
            txtSize8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate8_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtRate8.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate8.Focus();
            }
            else
            {
                Decimal Amt8 = 0;
                Amt8 = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(txtRate8.Text);
                txtAmt8.Text = (Amt8).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + Convert.ToDecimal(txtAmt7.Text) + (Amt8);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate8.BackColor = System.Drawing.Color.White;
                txtRate8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate8.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtPar9_Leave(object sender, EventArgs e)
        {           
            txtPar9.BackColor = System.Drawing.Color.White;
            txtPar9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar9.ForeColor = System.Drawing.Color.Black;            
        }

        private void txtQty9_Leave(object sender, EventArgs e)
        {            
            txtQty9.BackColor = System.Drawing.Color.White;
            txtQty9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty9.ForeColor = System.Drawing.Color.Black;           
        }

        private void txtSize9_Leave(object sender, EventArgs e)
        {           
            txtSize9.BackColor = System.Drawing.Color.White;
            txtSize9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate9_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtRate9.Text) )
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate9.Focus();
            }
            else
            {
                Decimal Amt9 = 0;
                Amt9 = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(txtRate9.Text);
                txtAmt9.Text = (Amt9).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + Convert.ToDecimal(txtAmt7.Text) + Convert.ToDecimal(txtAmt8.Text) + (Amt9);
                txtTotal.Text = SubTol.ToString("0.00");

                txtRate9.BackColor = System.Drawing.Color.White;
                txtRate9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate8.ForeColor = System.Drawing.Color.Black;
            }           
        }

        private void txtPar10_Leave(object sender, EventArgs e)
        {           
            txtPar10.BackColor = System.Drawing.Color.White;
            txtPar10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty10_Leave(object sender, EventArgs e)
        {            
            txtQty10.BackColor = System.Drawing.Color.White;
            txtQty10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize10_Leave(object sender, EventArgs e)
        {            
            txtSize10.BackColor = System.Drawing.Color.White;
            txtSize10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize10.ForeColor = System.Drawing.Color.Black;           
        }

        private void txtRate10_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRate10.Text))
            {
                MessageBox.Show("Please enter Rate Otherwise put 0 instead of Rate!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate10.Focus();
            }
            else
            {
                Decimal Amt10 = 0;
                Amt10 = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(txtRate10.Text);
                txtAmt10.Text = (Amt10).ToString("0.00");

                Decimal SubTol = 0;
                SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + Convert.ToDecimal(txtAmt7.Text) + Convert.ToDecimal(txtAmt8.Text) + Convert.ToDecimal(txtAmt9.Text) + (Amt10);
                txtTotal.Text = SubTol.ToString("0.00");
                txtCGST.Focus();

                txtRate10.BackColor = System.Drawing.Color.White;
                txtRate10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRate10.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtCGST_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCGST.Text))
            {
                MessageBox.Show("Please enter Add. CGST % or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCGST.Focus();
            }
            else
            {
                Decimal GrndTol = 0, Tax = 0;
                Tax = ((Convert.ToDecimal(txtTotal.Text) * (Convert.ToDecimal(txtCGST.Text))) / 100);
                GrndTol = Math.Round(Convert.ToDecimal(txtTotal.Text) + Tax);
                txtGrandTotal.Text = GrndTol.ToString("0");
                txtRoundOff.Text = Tax.ToString("0");

                txtCGST.BackColor = System.Drawing.Color.White;
                txtCGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtCGST.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSGST_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSGST.Text))
            {
                MessageBox.Show("Please enter Add. SGST % or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSGST.Focus();
            }
            else
            {
                btnSave.Enabled = true;
                Decimal GrndTol = 0, Tax = 0;
                Tax = ((Convert.ToDecimal(txtTotal.Text) * ((Convert.ToDecimal(txtCGST.Text)) + Convert.ToDecimal(txtSGST.Text))) / 100);
                GrndTol = Math.Round(Convert.ToDecimal(txtTotal.Text) + Tax);
                txtGrandTotal.Text = GrndTol.ToString("0");
                txtRoundOff.Text = Tax.ToString("0");
                txtIGST.Focus();

                txtSGST.BackColor = System.Drawing.Color.White;
                txtSGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtSGST.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void txtRoundOff_Leave(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    MessageBox.Show("Please enter Invoice No!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInvoiceNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtBuyerName.Text))
                {
                    MessageBox.Show("Please enter Buyer Name!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuyerName.Focus();
                }
                else if (string.IsNullOrEmpty(txtBuyerAddress.Text))
                {
                    MessageBox.Show("Please enter Buyer Address!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuyerAddress.Focus();
                }
                else if (string.IsNullOrEmpty(txtMobileNo.Text))
                {
                    MessageBox.Show("Please enter Mobile No!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMobileNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtDate.Text))
                {
                    MessageBox.Show("Please enter Date!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDate.Focus();
                }
                else if (string.IsNullOrEmpty(txtPar1.Text) || string.IsNullOrEmpty(txtQty1.Text) || string.IsNullOrEmpty(txtRate1.Text))
                {
                    MessageBox.Show("Please enter atleast one Particulars details!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPar1.Focus();
                }
                else if (string.IsNullOrEmpty(txtCGST.Text))
                {
                    MessageBox.Show("Please enter Add. CGST % or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCGST.Focus();
                }
                else if (string.IsNullOrEmpty(txtSGST.Text))
                {
                    MessageBox.Show("Please enter Add. SGST %  or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSGST.Focus();
                }
                else if (string.IsNullOrEmpty(txtIGST.Text))
                {
                    MessageBox.Show("Please enter Add. IGST %  or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIGST.Focus();
                }
                else
                {

                    Decimal GrndTol = 0;
                    GrndTol = Math.Round(Convert.ToDecimal(txtTotal.Text) + ((Convert.ToDecimal(txtTotal.Text) * ((Convert.ToDecimal(txtCGST.Text)) + (Convert.ToDecimal(txtSGST.Text)) + Convert.ToDecimal(txtIGST.Text))) / 100));
                    txtGrandTotal.Text = GrndTol.ToString("0");
                    txtRoundOff.Text = GrndTol.ToString("0");

                    string OrderNoF = string.Empty;
                    using (SqlConnection ConnStr = new SqlConnection(str))
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.CommandText = "SP_InsertSalesOrderDetails";
                        cmd1.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                        cmd1.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                        cmd1.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                        cmd1.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                        cmd1.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                        cmd1.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                        cmd1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;

                        cmd1.Parameters.Add("@Total", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTotal.Text);
                        cmd1.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        cmd1.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                        cmd1.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                        cmd1.Parameters.Add("@RoundOff", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRoundOff.Text);
                        cmd1.Parameters.Add("@GrandTotal", SqlDbType.Decimal).Value = Convert.ToDecimal(txtGrandTotal.Text);
                        cmd1.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                        cmd1.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                        cmd1.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                        cmd1.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                        cmd1.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;                        
                        cmd1.Parameters.Add("@OrderNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd1.Connection = ConnStr;
                        ConnStr.Open();
                        cmd1.ExecuteNonQuery();
                        OrderNoF = cmd1.Parameters["@OrderNo"].Value.ToString();
                        ConnStr.Close();
                        ConnStr.Dispose();
                    }

                    //1st
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_InsertInvoiceDetails_New";
                        cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                        cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(1);
                        cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                        cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                        cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                        cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                        cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                        cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar1.Text;
                        cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN1.Text;
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty1.Text);
                        cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize1.Text;
                        cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate1.Text;
                        cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt1.Text);
                        cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                        cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                        cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                        cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                        cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                        cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                        cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }

                    if (!string.IsNullOrEmpty(txtPar2.Text) && txtQty2.Text != "0" && txtQty2.Text != "" && txtRate2.Text != "0" && !string.IsNullOrEmpty(txtRate2.Text) && txtAmt2.Text != "0.00")
                    {
                        //2st
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(2);
                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar2.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN2.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty2.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize2.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate2.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt2.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar3.Text) && txtQty3.Text != "0" && txtQty3.Text != "" && txtRate3.Text != "0" && !string.IsNullOrEmpty(txtRate3.Text) && txtAmt3.Text != "0.00")
                    {
                        //3st
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(3);
                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar3.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN3.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty3.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize3.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate3.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt3.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar4.Text) && txtQty4.Text != "0" && txtQty4.Text != "" && txtRate4.Text != "0" && !string.IsNullOrEmpty(txtRate4.Text) && txtAmt4.Text != "0.00")
                    {
                        //4th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(4);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar4.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN4.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty4.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize4.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate4.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt4.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }


                    if (!string.IsNullOrEmpty(txtPar5.Text) && txtQty5.Text != "0" && txtQty5.Text != "" && txtRate5.Text != "0" && !string.IsNullOrEmpty(txtRate5.Text) && txtAmt5.Text != "0.00")
                    {
                        //5th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(5);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar5.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN5.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty5.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize5.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate5.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt5.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar6.Text) && txtQty6.Text != "0" && txtQty6.Text != "" && txtRate6.Text != "0" && !string.IsNullOrEmpty(txtRate6.Text) && txtAmt6.Text != "0.00")
                    {
                        //6th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(6);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar6.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN6.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty6.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize6.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate6.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt6.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar7.Text) && txtQty7.Text != "0" && txtQty7.Text != "" && txtRate7.Text != "0" && !string.IsNullOrEmpty(txtRate7.Text) || txtAmt7.Text != "0.00")
                    {

                        //7th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(7);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar7.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN7.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty7.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize7.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate7.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt7.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar8.Text) && txtQty8.Text != "0" && txtQty8.Text != "" && txtRate8.Text != "0" && !string.IsNullOrEmpty(txtRate8.Text) && txtAmt8.Text != "0.00")
                    {
                        //8th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(8);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar8.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN8.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty8.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize8.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate8.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt8.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar9.Text) && txtQty9.Text != "0" && txtQty9.Text != "" && txtRate9.Text != "0" && !string.IsNullOrEmpty(txtRate9.Text) && txtAmt9.Text != "0.00")
                    {
                        //9th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(9);

                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar9.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN9.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty9.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize9.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate9.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt9.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    if (!string.IsNullOrEmpty(txtPar10.Text) && txtQty10.Text != "0" && txtQty10.Text != "" && txtRate10.Text != "0" && !string.IsNullOrEmpty(txtRate10.Text) && txtAmt10.Text != "0.00")
                    {
                        //10th
                        using (SqlConnection con = new SqlConnection(str))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SP_InsertInvoiceDetails_New";
                            cmd.Parameters.Add("@OrderNoF", SqlDbType.Int).Value = Convert.ToInt32(OrderNoF);
                            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = txtInvoiceNo.Text;
                            cmd.Parameters.Add("@No", SqlDbType.Int).Value = Convert.ToInt32(10);
                            cmd.Parameters.Add("@BuyerName", SqlDbType.NVarChar).Value = txtBuyerName.Text;
                            cmd.Parameters.Add("@BuyerAddress", SqlDbType.NVarChar).Value = txtBuyerAddress.Text;
                            cmd.Parameters.Add("@BuyerTINNo", SqlDbType.NVarChar).Value = txtTINNo.Text;
                            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                            cmd.Parameters.Add("@PostingDate", SqlDbType.DateTime).Value = System.DateTime.Now;
                            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;
                            cmd.Parameters.Add("@Par", SqlDbType.NVarChar).Value = txtPar10.Text;
                            cmd.Parameters.Add("@HSN", SqlDbType.NVarChar).Value = txtHSN10.Text;
                            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(txtQty10.Text);
                            cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = txtSize10.Text;
                            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = txtRate10.Text;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtAmt10.Text);
                            cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                            cmd.Parameters.Add("@AddiVAT", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                            cmd.Parameters.Add("@IGST", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                            cmd.Parameters.Add("@ChallanNo", SqlDbType.NVarChar).Value = txtChallanNo.Text;
                            cmd.Parameters.Add("@PONo", SqlDbType.NVarChar).Value = txtPONo.Text;
                            cmd.Parameters.Add("@ReferenceBy", SqlDbType.NVarChar).Value = txtRefBy.Text;
                            cmd.Parameters.Add("@DispatchBy", SqlDbType.NVarChar).Value = txtDispatchBy.Text;
                            cmd.Parameters.Add("@LRNo", SqlDbType.NVarChar).Value = txtLRNo.Text;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            con.Dispose();
                        }
                    }

                    MessageBox.Show("Record has been saved successfully!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    // this.Close();

                    OrderNo = OrderNoF.ToString();
                    InvoiceReportBuyerWise obj = new InvoiceReportBuyerWise();
                    obj.Show();
                    OrderNo = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected void ClearForm()
        {
            btnSave.Enabled = false;
            txtBuyerName.Text = string.Empty;
            txtBuyerAddress.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtDate.Text = (System.DateTime.Now).ToString("dd/MM/yyyy");
            txtPar1.Text = string.Empty;
            txtQty1.Text = "0";
            txtSize1.Text = string.Empty;
            txtRate1.Text = "0";
            txtAmt1.Text = "0.00";
            txtTINNo.Text = string.Empty;

            txtPar2.Text = string.Empty;
            txtQty2.Text = "0";
            txtSize2.Text = string.Empty;
            txtRate2.Text = "0";
            txtAmt2.Text = "0.00";

            txtPar3.Text = string.Empty;
            txtQty3.Text = "0";
            txtSize3.Text = string.Empty;
            txtRate3.Text = "0";
            txtAmt3.Text = "0.00";

            txtPar4.Text = string.Empty;
            txtQty4.Text = "0";
            txtSize4.Text = string.Empty;
            txtRate4.Text = "0";
            txtAmt4.Text = "0.00";

            txtPar5.Text = string.Empty;
            txtQty5.Text = "0";
            txtSize5.Text = string.Empty;
            txtRate5.Text = "0";
            txtAmt5.Text = "0.00";

            txtPar6.Text = string.Empty;
            txtQty6.Text = "0";
            txtSize6.Text = string.Empty;
            txtRate6.Text = "0";
            txtAmt6.Text = "0.00";

            txtPar7.Text = string.Empty;
            txtQty7.Text = "0";
            txtSize7.Text = string.Empty;
            txtRate7.Text = "0";
            txtAmt7.Text = "0.00";

            txtPar8.Text = string.Empty;
            txtQty8.Text = "0";
            txtSize8.Text = string.Empty;
            txtRate8.Text = "0";
            txtAmt8.Text = "0.00";

            txtPar9.Text = string.Empty;
            txtQty9.Text = "0";
            txtSize9.Text = string.Empty;
            txtRate9.Text = "0";
            txtAmt9.Text = "0.00";

            txtPar10.Text = string.Empty;
            txtQty10.Text = "0";
            txtSize10.Text = string.Empty;
            txtRate10.Text = "0";
            txtAmt10.Text = "0.00";

            txtTotal.Text = string.Empty;
            txtRoundOff.Text = string.Empty;
            txtGrandTotal.Text = string.Empty;
            txtCGST.Text = "4";
            txtSGST.Text = "1";
            txtIGST.Text = "0";

            txtHSN1.Text = string.Empty;
            txtHSN2.Text = string.Empty;
            txtHSN3.Text = string.Empty;
            txtHSN4.Text = string.Empty;
            txtHSN5.Text = string.Empty;
            txtHSN6.Text = string.Empty;
            txtHSN7.Text = string.Empty;
            txtHSN8.Text = string.Empty;
            txtHSN9.Text = string.Empty;
            txtHSN10.Text = string.Empty;
            txtChallanNo.Text = string.Empty;
            txtPONo.Text = string.Empty;
            txtRefBy.Text = string.Empty;
            txtDispatchBy.Text = string.Empty;
            txtLRNo.Text = string.Empty;            
            txtBuyerName.Focus();

            txtBuyerName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerName.ForeColor = System.Drawing.Color.Black;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtPar1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Decimal SubTol = 0;
                    SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + Convert.ToDecimal(txtAmt7.Text) + Convert.ToDecimal(txtAmt8.Text) + Convert.ToDecimal(txtAmt9.Text) + Convert.ToDecimal(txtAmt10.Text);
                    txtTotal.Text = SubTol.ToString("0.00");
                    txtCGST.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        protected void BuyerTextSuggestion()
        {
            try
            {
                string Qry = "select BuyerName,BuyerAddress,MobileNo,BuyerTINNo,ChallanNo,PONo,ReferenceBy,DispatchBy,LRNo from SalesOrder where Flag=('0') order by PostingDate DESC";
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

        private void txtBuyerName_TextChanged(object sender, EventArgs e)
        {
            //BuyerTextSuggestion();
        }

        private void txtBuyerAddress_Enter(object sender, EventArgs e)
        {
            txtBuyerAddress.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtBuyerAddress.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerAddress.ForeColor = System.Drawing.Color.Black;
        }

        private void txtMobileNo_Enter(object sender, EventArgs e)
        {
            txtMobileNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtMobileNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtMobileNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            txtDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDate.ForeColor = System.Drawing.Color.Black;
        }

        private void txtBuyerName_Enter(object sender, EventArgs e)
        {
            txtBuyerName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtBuyerName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBuyerName.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate1_Enter(object sender, EventArgs e)
        {
            txtRate1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate1.ForeColor = System.Drawing.Color.Black;


        }

        private void txtPar1_Enter(object sender, EventArgs e)
        {
            txtPar1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar1.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty1_Enter(object sender, EventArgs e)
        {
            txtQty1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty1.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize1_Enter(object sender, EventArgs e)
        {
            txtSize1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize1.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar2_Enter(object sender, EventArgs e)
        {
            txtPar2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty2_Enter(object sender, EventArgs e)
        {
            txtQty2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize2_Enter(object sender, EventArgs e)
        {
            txtSize2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate2_Enter(object sender, EventArgs e)
        {
            txtRate2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar3_Enter(object sender, EventArgs e)
        {
            txtPar3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty3_Enter(object sender, EventArgs e)
        {
            txtQty3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize3_Enter(object sender, EventArgs e)
        {
            txtSize3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate3_Enter(object sender, EventArgs e)
        {
            txtRate3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar4_Enter(object sender, EventArgs e)
        {
            txtPar4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty4_Enter(object sender, EventArgs e)
        {
            txtQty4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize4_Enter(object sender, EventArgs e)
        {
            txtSize4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate4_Enter(object sender, EventArgs e)
        {
            txtRate4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar5_Enter(object sender, EventArgs e)
        {
            txtPar5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty5_Enter(object sender, EventArgs e)
        {
            txtQty5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize5_Enter(object sender, EventArgs e)
        {
            txtSize5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate5_Enter(object sender, EventArgs e)
        {
            txtRate5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar6_Enter(object sender, EventArgs e)
        {
            txtPar6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty6_Enter(object sender, EventArgs e)
        {
            txtQty6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize6_Enter(object sender, EventArgs e)
        {
            txtSize6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar7_Enter(object sender, EventArgs e)
        {
            txtPar7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty7_Enter(object sender, EventArgs e)
        {
            txtQty7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize7_Enter(object sender, EventArgs e)
        {
            txtSize7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate7_Enter(object sender, EventArgs e)
        {
            txtRate7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar8_Enter(object sender, EventArgs e)
        {
            txtPar8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty8_Enter(object sender, EventArgs e)
        {
            txtQty8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize8_Enter(object sender, EventArgs e)
        {
            txtSize8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate8_Enter(object sender, EventArgs e)
        {
            txtRate8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar9_Enter(object sender, EventArgs e)
        {
            txtPar9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty9_Enter(object sender, EventArgs e)
        {
            txtQty9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize9_Enter(object sender, EventArgs e)
        {
            txtSize9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate9_Enter(object sender, EventArgs e)
        {
            txtRate9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPar10_Enter(object sender, EventArgs e)
        {
            txtPar10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPar10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPar10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtQty10_Enter(object sender, EventArgs e)
        {
            txtQty10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQty10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtQty10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSize10_Enter(object sender, EventArgs e)
        {
            txtSize10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSize10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSize10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate10_Enter(object sender, EventArgs e)
        {
            txtRate10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRate6_Enter(object sender, EventArgs e)
        {
            txtRate6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRate6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRate6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMobileNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))  || !(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            //{
            //    e.Handled = true;
            //}
            if ((!!char.IsLetter(e.KeyChar) && (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMobileNo.Text, "  ^ [0-9]"))
            {
                txtMobileNo.Text = "";
            }
        }

        private void txtTINNo_Leave(object sender, EventArgs e)
        {
            txtTINNo.BackColor = System.Drawing.Color.White;
            txtTINNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTINNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtTINNo_Enter(object sender, EventArgs e)
        {
            txtTINNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtTINNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTINNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtIGST_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIGST.Text))
            {
                MessageBox.Show("Please enter Add. IGST % or put 0 if it is not applicable. !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSGST.Focus();
            }
            else
            {
                btnSave.Enabled = true;
                Decimal GrndTol = 0, Tax =0;
                Tax = ((Convert.ToDecimal(txtTotal.Text) * ((Convert.ToDecimal(txtCGST.Text)) + Convert.ToDecimal(txtSGST.Text) + Convert.ToDecimal(txtIGST.Text))) / 100);
                GrndTol = Math.Round(Convert.ToDecimal(txtTotal.Text) + Tax);
                txtGrandTotal.Text = GrndTol.ToString("0");
                txtRoundOff.Text = Tax.ToString("0");
                txtRoundOff.Focus();

                txtIGST.BackColor = System.Drawing.Color.White;
                txtIGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtIGST.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtCGST_Enter(object sender, EventArgs e)
        {
            txtCGST.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtCGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtCGST.ForeColor = System.Drawing.Color.Black;
        }

        private void txtSGST_Enter(object sender, EventArgs e)
        {
            txtSGST.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtSGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtSGST.ForeColor = System.Drawing.Color.Black;
        }

        private void txtIGST_Enter(object sender, EventArgs e)
        {
            txtIGST.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtIGST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtIGST.ForeColor = System.Drawing.Color.Black;
        }

        private void txtIGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
                e.Handled = true;
        }

        private void txtChallanNo_Enter(object sender, EventArgs e)
        {
            txtChallanNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtChallanNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtChallanNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtChallanNo_Leave(object sender, EventArgs e)
        {
            txtChallanNo.BackColor = System.Drawing.Color.White;
            txtChallanNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtChallanNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPONo_Enter(object sender, EventArgs e)
        {
            txtPONo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPONo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPONo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPONo_Leave(object sender, EventArgs e)
        {
            txtPONo.BackColor = System.Drawing.Color.White;
            txtPONo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPONo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRefBy_Enter(object sender, EventArgs e)
        {
            txtRefBy.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtRefBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRefBy.ForeColor = System.Drawing.Color.Black;
        }

        private void txtRefBy_Leave(object sender, EventArgs e)
        {
            txtRefBy.BackColor = System.Drawing.Color.White;
            txtRefBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRefBy.ForeColor = System.Drawing.Color.Black;
        }

        private void txtDispatchBy_Enter(object sender, EventArgs e)
        {
            txtDispatchBy.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtDispatchBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDispatchBy.ForeColor = System.Drawing.Color.Black;
        }

        private void txtDispatchBy_Leave(object sender, EventArgs e)
        {
            txtDispatchBy.BackColor = System.Drawing.Color.White;
            txtDispatchBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDispatchBy.ForeColor = System.Drawing.Color.Black;
        }

        private void txtLRNo_Enter(object sender, EventArgs e)
        {
            txtLRNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtLRNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtLRNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtLRNo_Leave(object sender, EventArgs e)
        {
            txtPar1.Focus();
            txtLRNo.BackColor = System.Drawing.Color.White;
            txtLRNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtLRNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN1_Enter(object sender, EventArgs e)
        {
            txtHSN1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN1.ForeColor = System.Drawing.Color.Black;
        }
        private void txtHSN1_Leave(object sender, EventArgs e)
        {

            txtHSN1.BackColor = System.Drawing.Color.White;
            txtHSN1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN1.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN2_Enter(object sender, EventArgs e)
        {
            txtHSN2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN2_Leave(object sender, EventArgs e)
        {
            txtHSN2.BackColor = System.Drawing.Color.White;
            txtHSN2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN2.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN3_Enter(object sender, EventArgs e)
        {
            txtHSN3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN3_Leave(object sender, EventArgs e)
        {
            txtHSN3.BackColor = System.Drawing.Color.White;
            txtHSN3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN3.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN4_Enter(object sender, EventArgs e)
        {
            txtHSN4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN4_Leave(object sender, EventArgs e)
        {
            txtHSN4.BackColor = System.Drawing.Color.White;
            txtHSN4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN4.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN5_Enter(object sender, EventArgs e)
        {
            txtHSN5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN5_Leave(object sender, EventArgs e)
        {
            txtHSN5.BackColor = System.Drawing.Color.White;
            txtHSN5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN5.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN6_Enter(object sender, EventArgs e)
        {
            txtHSN6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN6_Leave(object sender, EventArgs e)
        {
            txtHSN6.BackColor = System.Drawing.Color.White;
            txtHSN6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN6.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN7_Enter(object sender, EventArgs e)
        {
            txtHSN7.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN7_Leave(object sender, EventArgs e)
        {
            txtHSN7.BackColor = System.Drawing.Color.White;
            txtHSN7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN7.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN8_Enter(object sender, EventArgs e)
        {
            txtHSN8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN8_Leave(object sender, EventArgs e)
        {
            txtHSN8.BackColor = System.Drawing.Color.White;
            txtHSN8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN8.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN9_Enter(object sender, EventArgs e)
        {
            txtHSN9.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN9_Leave(object sender, EventArgs e)
        {
            txtHSN9.BackColor = System.Drawing.Color.White;
            txtHSN9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN9.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN10_Enter(object sender, EventArgs e)
        {
            txtHSN10.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtHSN10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN10_Leave(object sender, EventArgs e)
        {
            txtHSN10.BackColor = System.Drawing.Color.White;
            txtHSN10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtHSN10.ForeColor = System.Drawing.Color.Black;
        }

        private void txtHSN1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Decimal SubTol = 0;
                    SubTol = Convert.ToDecimal(txtAmt1.Text) + Convert.ToDecimal(txtAmt2.Text) + Convert.ToDecimal(txtAmt3.Text) + Convert.ToDecimal(txtAmt4.Text) + Convert.ToDecimal(txtAmt5.Text) + Convert.ToDecimal(txtAmt6.Text) + Convert.ToDecimal(txtAmt7.Text) + Convert.ToDecimal(txtAmt8.Text) + Convert.ToDecimal(txtAmt9.Text) + Convert.ToDecimal(txtAmt10.Text);
                    txtTotal.Text = SubTol.ToString("0.00");
                    txtCGST.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            txtInvoiceNo.BackColor = System.Drawing.Color.White;
            txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtInvoiceNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            txtInvoiceNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtInvoiceNo.ForeColor = System.Drawing.Color.Black;
        }
      

    }
}
