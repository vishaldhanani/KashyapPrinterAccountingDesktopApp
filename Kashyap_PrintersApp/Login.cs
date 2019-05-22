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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString);
        private int childFormNumber = 0;
        public static Home mainhome;
        string str = string.Empty;

        public Login()
        {
            InitializeComponent();
            btnResetPassword.Visible = false;
            txtUserID.Focus();
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
                txtUserID.Focus();
                txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtPassword.BackColor = System.Drawing.Color.White;

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
                        con.Open();
                        str = "select UserID, Password from Login where UserID='" + txtUserID.Text + "' AND Password='" + txtPassword.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                this.Hide();
                                Home obj = new Home();
                                obj.Show();
                            }
                            else
                            {
                                MessageBox.Show("Error: Please Check Your User ID and Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUserID.Focus();
                                txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                                txtPassword.BackColor = System.Drawing.Color.White;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: Please Check Your User ID and Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUserID.Focus();
                            txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                            txtPassword.BackColor = System.Drawing.Color.White;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Please enter Your Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        txtUserID.BackColor = System.Drawing.Color.White;
                        txtPassword.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Please enter Your User ID!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Focus();
                    txtUserID.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    txtPassword.BackColor = System.Drawing.Color.White;

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

            txtPassword.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtPassword.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtPassword.ForeColor = System.Drawing.Color.Black;
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

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ResetPassword obj = new ResetPassword();
            //    obj.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }                     
    }
}
