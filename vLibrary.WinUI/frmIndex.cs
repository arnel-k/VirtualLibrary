using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vLibrary.WinUI.Address;
using vLibrary.WinUI.Authors;
using vLibrary.WinUI.Books;
using vLibrary.WinUI.Categories;
using vLibrary.WinUI.Employee;
using vLibrary.WinUI.Login;
using vLibrary.WinUI.Publishers;
using vLibrary.WinUI.Racks;

namespace vLibrary.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
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
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthors frm = new frmAuthors();
            frm.MdiParent = this;
            frm.Show();
        }

        private void NewAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthorDetails frm = new frmAuthorDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void FrmIndex_Load(object sender, EventArgs e)
        {
            //BackgroundImage = Properties.Resources.t;
            //this.BackColor = Color.Blue; 
            ///TODO: dodati boju ili pozadinu
        }

        private void SearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddress frm = new frmAddress();
            frm.MdiParent = this;
            frm.Show();
        }

        private void NewAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddressDetails frm = new frmAddressDetails();
            frm.MdiParent = this;
    
            frm.Show();
        }

        private void SearchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBooks frm = new frmBooks();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookDetails frm = new frmBookDetails();
            frm.MdiParent = this;
            frm.LoadDataIntoInsertForm();
            frm.Show();
        }

        private void searchToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmPublishers frm = new frmPublishers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPublisherDetails frm = new frmPublisherDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void searchToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmCategories frm = new frmCategories();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryDetails frm = new frmCategoryDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void searchToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmRacks frm = new frmRacks();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newRackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRackDetails frm = new frmRackDetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void searchToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmEmployees frm = new frmEmployees();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmplyeeDetails frm = new frmEmplyeeDetails();
            frm.MdiParent = this;
            frm.LoadDataIntoInsertForm();
            frm.Show();
        }

        private void appSettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{ConfigurationManager.AppSettings["token"]}");
        }
    }
}
