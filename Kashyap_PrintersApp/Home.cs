using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Kashyap_PrintersApp
{

    public partial class Home : Form
    {

        string str = ConfigurationManager.ConnectionStrings["KashyapPrintersDBConnection"].ConnectionString;

        private int childFormNumber = 0;

        public Home()
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
                //string FileName = OpenFile                                                                                                                        eDialog.FileName;
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

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void quitExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null && this.MdiChildren.Length == 0)
            {
                DialogResult result;
                result = MessageBox.Show("Are you sure you want to Exit?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {

                }
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

        }

        private void createInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceEntry obj = new InvoiceEntry();
            obj.MdiParent = this;
            obj.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void editInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditInvoiceEntry obj = new EditInvoiceEntry();
            obj.MdiParent = this;
            obj.Show();
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReportBuyerNameWise obj = new InvoiceReportBuyerNameWise();
            obj.MdiParent = this;
            obj.Show();
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void backUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var backupFolder = ConfigurationManager.AppSettings["BackupFolder"];

            var sqlConStrBuilder = new SqlConnectionStringBuilder(str);

            // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")
            var backupFileName = String.Format("{0}{1}-{2}.bak",
                backupFolder, sqlConStrBuilder.InitialCatalog,
                DateTime.Now.ToString("yyyy-MM-dd"));

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                    sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Backup database successfully!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPassword obj = new ResetPassword();
            obj.MdiParent = this;
            obj.Show();
        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReportDateWise obj = new InvoiceReportDateWise();
            obj.MdiParent = this;
            obj.Show();
        }

       

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.I))
        //    {
        //        InvoiceEntry obj = new InvoiceEntry();
        //        obj.MdiParent = this;
        //        obj.Show();
        //    }
        //    else if (keyData == (Keys.Control | Keys.M))
        //    {
        //        EditInvoiceEntry obj = new EditInvoiceEntry();
        //        obj.MdiParent = this;
        //        obj.Show();
        //    }

        //    else if (keyData == (Keys.Control | Keys.S))
        //    {
        //        InvoiceReportBuyerWise obj = new InvoiceReportBuyerWise();
        //        obj.MdiParent = this;
        //        obj.Show();
        //    }
        //    else if (keyData == (Keys.Control | Keys.E))
        //    {
        //        if (this.ActiveMdiChild == null && this.MdiChildren.Length == 0)
        //        {
        //            DialogResult result;
        //            result = MessageBox.Show("Are you sure you want to Exit?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //            if (result == DialogResult.Yes)
        //            {
        //                Application.Exit();
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {
        //            this.ActiveMdiChild.Close();
        //        }
        //    }
        //    return true;
        //    return base.ProcessCmdKey(ref msg, keyData);

        //}

      
    }
}
