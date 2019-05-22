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
    public partial class ResetPassword : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString);
        private int childFormNumber = 0;
        public static Home mainhome;
        string str = string.Empty;
        

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtUserID.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtUserID.ForeColor = System.Drawing.Color.Black;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected void ClearForm()
        {
            try
            {
                txtUserID.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                txtUserID.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUserID.Text))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        if (!string.IsNullOrEmpty(txtConfirmPassword.Text))
                        {
                            if (txtPassword.Text == txtConfirmPassword.Text)
                            {
                                con.Open();
                                str = "update Login set Password = '" + txtConfirmPassword.Text + "' where UserID='" + txtUserID.Text + "'";
                                SqlCommand cmd = new SqlCommand(str, con);
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("Your Password reset successfully!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    txtConfirmPassword.Text = string.Empty;
                                    txtPassword.Text = string.Empty;
                                    txtUserID.Text = string.Empty;
                                    

                                }
                            }
                            else
                            {
                                MessageBox.Show("New Password and Confirm Password does not match.\nPlease check your password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Please enter Your Confirm Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtConfirmPassword.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Please enter Your Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Please enter Your User ID!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Focus();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }

        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    UserID_Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            txtUserID.BackColor = System.Drawing.Color.White;
            txtUserID.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtUserID.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    Password_Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BackColor = System.Drawing.Color.White;
            txtPassword.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPassword.ForeColor = System.Drawing.Color.Black;
        }

        public void UserID_Fill()
        {
            if (!string.IsNullOrEmpty(txtUserID.Text))
            {
                txtPassword.Focus();
            }
            else
            {
                MessageBox.Show("Please enter User ID!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Password_Fill()
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                btnLogin.Focus();
            }
            else
            {
                MessageBox.Show("Please enter Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {
            txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtUserID.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtUserID.ForeColor = System.Drawing.Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPassword.ForeColor = System.Drawing.Color.Black;
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtConfirmPassword.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtConfirmPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtConfirmPassword.ForeColor = System.Drawing.Color.Black;
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {

            txtConfirmPassword.BackColor = System.Drawing.Color.White;
            txtConfirmPassword.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtConfirmPassword.ForeColor = System.Drawing.Color.Black;
        }
    }
}
