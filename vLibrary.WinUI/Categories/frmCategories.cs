using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vLibrary.Model;
using vLibrary.Model.Requests;
using vLibrary.WinUI.Publishers;

namespace vLibrary.WinUI.Categories
{
    public partial class frmCategories : Form
    {
        private readonly ApiService _apiService = new ApiService("category");
        
        public frmCategories()
        {
            InitializeComponent();
        }
        public DataGridView DG
        {
            get
            {
                return dgvCategories;
            }
        }

        public async void GetSearchData()
        {
            var search = new CategorySearchRequest
            {
                CategoryName = txtSearch.Text
            };
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.DataSource = await _apiService.Get<List<CategoryDto>>(search);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSearchData();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var id = dgvCategories.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    var repsonse = await _apiService.Delete<CategoryDto>(id);

                    if (repsonse != null)
                    {
                        GetSearchData();
                        dgvCategories.Update();
                        dgvCategories.Refresh();
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"The record is used in a relation, it can't be deleted!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var id = dgvCategories.SelectedRows[0].Cells[0].Value;
                frmCategoryDetails frm = new frmCategoryDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void dgvCategories_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvCategories.ClearSelection();
                    this.dgvCategories.Rows[rowSelected].Selected = true;
                    this.ContextMenuStrip = ctxMenu;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetSearchData();
            }
        }
    }
}
