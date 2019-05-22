using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Crystal_1
{
    public partial class Payment_Entry : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["crystalConnectionString"].ConnectionString);

        string str;
        public Payment_Entry()
        {
            InitializeComponent();
        }
        private void Payment_Entry_Load(object sender, EventArgs e)
        {
            //count();
            txt_com_code.Focus();
            DateTime thedate;
            thedate = DateTime.Today;
            txt_date.Text = thedate.ToString("dd/MM/yyyy");
        }
        private void thedate()
        {
            try
            {
                DateTime thedate;
                thedate = DateTime.Today;
                txt_date.Text = thedate.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //public void count()
        //{
        //    str = "select MAX(Voucher_Id) from Trn_Payment_Entry";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(str, con);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        dr.Read();
        //        string x = dr[0].ToString();

        //        if (x.ToString() == "")
        //        {
        //            txt_vid.Text = "1";
        //        }

        //        else
        //        {
        //            //int x = int.Parse(dr[0].ToString());
        //            int z = int.Parse(x.ToString());
        //            z = z + 1;
        //            txt_vid.Text = z.ToString();
        //        }
        //    }
        //    else
        //    {

        //        txt_vid.Text = "1";
        //    }
        //    con.Close();
        //}



        private void txt_com_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    C_Code_Validation();

                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txt_com_code.Text = textInfo.ToTitleCase(txt_com_code.Text);
                txt_com_code.SelectionStart = txt_com_code.Text.Length;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void C_Code_Validation()
        {
            try
            {
                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else
                {
                    con.Open();
                    str = "select * from Mst_Company where Com_Code='" + txt_com_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_com_name.Text = dr["Com_Name"].ToString();
                        txt_vid.Focus();
                        btn_Update.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_com_code.Focus();
                    } con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_com_code_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                txt_com_code.BackColor = System.Drawing.Color.White;
                txt_com_code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txt_com_code.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txt_com_code_Enter(object sender, EventArgs e)
        {
            txt_com_code.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_com_code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_com_code.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_vid_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                    fill_Data();
                //txt_date.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void fill_Data()
        {
            try
            {
                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_vid.Text == "")
                {
                    MessageBox.Show("Enter Voucher ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vid.Focus();
                }
                else
                {

                    con.Open();
                    str = "select * from Trn_Payment_Entry where Com_Code='" + txt_com_code.Text + "' and Voucher_Id=" + txt_vid.Text + " ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_date.Text = dr["Date"].ToString();
                        txtVoucher_no.Text = dr["Voucher_No"].ToString();
                        cmb_PaymentMode.Text = dr["Payment_Mode"].ToString();
                        cmb_PaymentBy.Text = dr["Payment_By"].ToString();
                        txtDeposite_Acc.Text = dr["DepositeAcc_To"].ToString();
                        txt_cheque_no.Text = dr["Cheque_No"].ToString();
                        mask_Cheque_Date.Text = dr["Cheque_Date"].ToString();
                        txt_narration.Text = dr["Narration"].ToString();
                        btn_save.Enabled = false;
                        btn_Update.Enabled = true;
                        txtVoucher_no.Focus();
                    }
                    else
                    {
                        btn_Update.Enabled = false;
                        btn_save.Enabled = true;
                        txt_date.Focus();
                    } con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_vid_Leave(object sender, EventArgs e)
        {
            if (txt_vid.Text == "")
            {
                MessageBox.Show("Enter Voucher ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_vid.Focus();
            }
            txt_vid.BackColor = System.Drawing.Color.White;
            txt_vid.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_vid.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_vid_Enter(object sender, EventArgs e)
        {
            txt_vid.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_vid.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_vid.ForeColor = System.Drawing.Color.Black;
        }


        private void txt_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    txtVoucher_no.Focus();
                   
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txt_date_Enter(object sender, EventArgs e)
        {
            txt_date.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_date.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_date_Leave(object sender, EventArgs e)
        {
            txt_date.BackColor = System.Drawing.Color.White;
            txt_date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_date.ForeColor = System.Drawing.Color.Black;
        }

        private void txtVoucher_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    vouch_val();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void vouch_val()
        {
            try
            {
                if (txtVoucher_no.Text == "")
                {
                    MessageBox.Show("Enter Voucher No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_no.Focus();
                }
                else
                {
                    cmb_PaymentMode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtVoucher_no_Enter(object sender, EventArgs e)
        {
            txtVoucher_no.BackColor = System.Drawing.Color.AntiqueWhite;
            txtVoucher_no.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtVoucher_no.ForeColor = System.Drawing.Color.Black;
        }

        private void txtVoucher_no_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtVoucher_no.Text == "")
                {
                    MessageBox.Show("Enter Voucher No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_no.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtVoucher_no.BackColor = System.Drawing.Color.White;
            txtVoucher_no.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtVoucher_no.ForeColor = System.Drawing.Color.Black;
        }

        private void cmb_PaymentMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    paymode_val();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void paymode_val()
        {
            try
            {
                if (cmb_PaymentMode.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Payment Mode....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_PaymentMode.Focus();
                }
                else
                {
                    cmb_PaymentBy.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmb_PaymentMode_Enter(object sender, EventArgs e)
        {
            cmb_PaymentMode.BackColor = System.Drawing.Color.AntiqueWhite;
            cmb_PaymentMode.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmb_PaymentMode.ForeColor = System.Drawing.Color.Black;
        }

        private void cmb_PaymentMode_Leave(object sender, EventArgs e)
        {
            cmb_PaymentMode.BackColor = System.Drawing.Color.White;
            cmb_PaymentMode.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmb_PaymentMode.ForeColor = System.Drawing.Color.Black;
        }

        private void cmb_PaymentBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    paymentby_val();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void paymentby_val()
        {
            try
            {
                if (cmb_PaymentBy.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Payment By....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb_PaymentBy.Focus();
                }
                else
                {
                    txtDeposite_Acc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmb_PaymentBy_Enter(object sender, EventArgs e)
        {
            cmb_PaymentBy.BackColor = System.Drawing.Color.AntiqueWhite;
            cmb_PaymentBy.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmb_PaymentBy.ForeColor = System.Drawing.Color.Black;
        }

        private void cmb_PaymentBy_Leave(object sender, EventArgs e)
        {
            cmb_PaymentBy.BackColor = System.Drawing.Color.White;
            cmb_PaymentBy.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmb_PaymentBy.ForeColor = System.Drawing.Color.Black;
        }

        private void txtDeposite_Acc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    Deposite_val();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Deposite_val()
        {
            if (txtDeposite_Acc.Text == "")
            {
                MessageBox.Show("Enter Deposite Account To....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDeposite_Acc.Focus();
            }
            else
            {
                txt_cheque_no.Focus();
            }
        }


        private void txtDeposite_Acc_Enter(object sender, EventArgs e)
        {
            txtDeposite_Acc.BackColor = System.Drawing.Color.AntiqueWhite;
            txtDeposite_Acc.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDeposite_Acc.ForeColor = System.Drawing.Color.Black;

        }

        private void txtDeposite_Acc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDeposite_Acc.Text == "")
                {
                    MessageBox.Show("Enter Deposite Account To....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDeposite_Acc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtDeposite_Acc.BackColor = System.Drawing.Color.White;
            txtDeposite_Acc.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtDeposite_Acc.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_cheque_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    CheqNo_val();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CheqNo_val()
        {
            try
            {
                if (txt_cheque_no.Text == "")
                {
                    MessageBox.Show("Enter Cheque/DD No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_cheque_no.Focus();
                }
                else
                {
                    mask_Cheque_Date.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_cheque_no_Enter(object sender, EventArgs e)
        {
            txt_cheque_no.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_cheque_no.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_cheque_no.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_cheque_no_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_cheque_no.Text == "")
                {
                    MessageBox.Show("Enter Cheque/DD No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_cheque_no.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txt_cheque_no.BackColor = System.Drawing.Color.White;
            txt_cheque_no.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_cheque_no.ForeColor = System.Drawing.Color.Black;
        }

        private void mask_Cheque_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    val_date();
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void val_date()
        {
            if (mask_Cheque_Date.Text =="  /  /")
            {
                MessageBox.Show("Enter Cheque/DD Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mask_Cheque_Date.Focus();
            }
            else
            {
                txt_narration.Focus();
            }
        }

        private void mask_Cheque_Date_Enter(object sender, EventArgs e)
        {
            mask_Cheque_Date.BackColor = System.Drawing.Color.AntiqueWhite;
            mask_Cheque_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mask_Cheque_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void mask_Cheque_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (mask_Cheque_Date.Text == "  /  /")
                {
                    MessageBox.Show("Enter Cheque Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mask_Cheque_Date.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            mask_Cheque_Date.BackColor = System.Drawing.Color.White;
            mask_Cheque_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mask_Cheque_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_narration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    focus_valid();

                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txt_narration.Text = textInfo.ToTitleCase(txt_narration.Text);
                txt_narration.SelectionStart = txt_narration.Text.Length;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void focus_valid()
        {
            try
            {
                con.Open();
                str = "select * from Trn_Payment_Entry where Com_Code='" + txt_com_code.Text + "' and Voucher_Id=" + txt_vid.Text + " ";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    btn_Update.Enabled = true;
                    btn_Update.Focus();


                }
                else
                {
                    btn_save.Enabled = true;
                    btn_save.Focus();
                } con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
           
        }

        private void txt_narration_Enter(object sender, EventArgs e)
        {
            txt_narration.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_narration.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_narration.ForeColor = System.Drawing.Color.Black;
        }
        private void txt_narration_Leave(object sender, EventArgs e)
        {
            txt_narration.BackColor = System.Drawing.Color.White;
            txt_narration.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_narration.ForeColor = System.Drawing.Color.Black;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_vid.Text == "")
                {
                    MessageBox.Show("Enter Voucher ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vid.Focus();
                }
                else if (mask_Cheque_Date.Text == "  /  /")
                {
                    MessageBox.Show("Enter Cheque/DD Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mask_Cheque_Date.Focus();
                }
                else
                {
                    con.Open();
                    str = "insert into Trn_Payment_Entry values('" + txt_com_code.Text + "','" + txt_com_name.Text + "'," + txt_vid.Text + ",'" + DateTime.Parse(txt_date.Text).ToString("MM/dd/yyyy") + "','" + txtVoucher_no.Text + "','" + cmb_PaymentMode.SelectedItem + "','" + cmb_PaymentBy.SelectedItem + "','" + txtDeposite_Acc.Text + "','" + txt_cheque_no.Text + "','" + DateTime.Parse(mask_Cheque_Date.Text).ToString("MM/dd/yyyy") + "','" + txt_narration.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txt_com_code.Text = string.Empty;
            txt_com_name.Text = string.Empty;
            txt_date.Text = string.Empty;
            txt_vid.Text = string.Empty;
            txtVoucher_no.Text = string.Empty;
            cmb_PaymentMode.Text = "";
            cmb_PaymentBy.Text = "";
            txtDeposite_Acc.Text = string.Empty;
            txt_cheque_no.Text = string.Empty;
            mask_Cheque_Date.Text = string.Empty;
            txt_narration.Text = string.Empty;
            txt_com_code.Focus();
            //count();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_vid.Text == "")
                {
                    MessageBox.Show("Enter Voucher ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vid.Focus();
                }
                else
                {
                    con.Open();
                    str = "update Trn_Payment_Entry set Voucher_No='" + txtVoucher_no.Text + "', Payment_Mode='" + cmb_PaymentMode.SelectedItem + "', Payment_By='" + cmb_PaymentBy.SelectedItem + "',DepositeAcc_To='" + txtDeposite_Acc.Text + "',Cheque_No='" + txt_cheque_no.Text + "', Cheque_Date='" + DateTime.Parse(mask_Cheque_Date.Text).ToString("MM/dd/yyyy") + "',Narration='" + txt_narration.Text + "' where Com_Code='" + txt_com_code.Text + "' and Voucher_Id=" + txt_vid.Text + " ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                  
                    MessageBox.Show("Record Updated Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_com_code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_vid.Text == "")
                {
                    MessageBox.Show("Enter Voucher ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vid.Focus();
                }
                else if (txtVoucher_no.Text == "")
                {
                    MessageBox.Show("Enter Voucher No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_no.Focus();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Are you sure you want to Delete this Payment Entry ??", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {


                        con.Open();
                        str = "delete from Trn_Payment_Entry where Com_Code='" + txt_com_code.Text + "' and Voucher_Id=" + txt_vid.Text + " and Voucher_No='" + txtVoucher_no.Text + "' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                       
                        MessageBox.Show("Record Deleted Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        txt_com_code.Focus();

                    }
                    else if (result == DialogResult.No)
                    {
                        txt_com_code.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}
