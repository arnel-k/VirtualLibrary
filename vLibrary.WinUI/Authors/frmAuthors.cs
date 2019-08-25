using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.WinUI.Authors
{
    public partial class frmAuthors : Form
    {
        
        private readonly ApiService apiService = new ApiService("authors");
        public DataGridView DG
        {
            get
            {
                return dgvAuthors;
            }
        }
        public frmAuthors()
        {
            InitializeComponent();
        }
       

        private void FrmAuthors_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            GetSearchData();
        }

        private void DgvAuthors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvAuthors.SelectedRows.Count > 0)
            {
                var id = dgvAuthors.SelectedRows[0].Cells[0].Value;
                frmAuthorDetails frm = new frmAuthorDetails(Guid.Parse(id.ToString()));
                frm.Show();
            } 
           
        }
        //Get data into the datagrid 
        public async void GetSearchData()
        {
            var search = new AuthorsSearchRequest
            {
                FName = txtSearch.Text
            };
            dgvAuthors.AutoGenerateColumns = false;
            dgvAuthors.DataSource = await apiService.Get<List<AuthorDto>>(search);
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = dgvAuthors.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                var repsonse = await apiService.Delete<AuthorDto>(id);
                if (repsonse != null)
                {
                    //Int32 rowToDelete = dgvAuthors.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    //dgvAuthors.Rows.RemoveAt(rowToDelete);
                    //dgvAuthors.ClearSelection();
                    GetSearchData();
                    dgvAuthors.Update();
                    dgvAuthors.Refresh();
                }
            }

        }

      

        private void DgvAuthors_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if(e.Button == MouseButtons.Right)
            {
                if(e.RowIndex != -1)
                {
                    this.dgvAuthors.ClearSelection();
                    this.dgvAuthors.Rows[rowSelected].Selected = true;
                    this.ContextMenuStrip = ctxMenu;
                }
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAuthors.SelectedRows.Count > 0)
            {
                var id = dgvAuthors.SelectedRows[0].Cells[0].Value;
                frmAuthorDetails frm = new frmAuthorDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                GetSearchData();
            }
        }
    }
}
