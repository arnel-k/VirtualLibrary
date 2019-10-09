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

namespace vLibrary.WinUI.Publishers
{
    public partial class frmPublishers : Form
    {
        private readonly ApiService _apiService = new ApiService("publisher");
        public frmPublishers()
        {
            InitializeComponent();
        }
        public DataGridView DG
        {
            get
            {
                return dgvPublishers;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSearchData();
        }

        public async void GetSearchData()
        {
            var search = new PublisherSearchRequest
            {
                PublisherName = txtSearch.Text
            };
            dgvPublishers.AutoGenerateColumns = false;
            dgvPublishers.DataSource = await _apiService.Get<List<PublisherDto>>(search);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = dgvPublishers.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    var repsonse = await _apiService.Delete<PublisherDto>(id);
                    if (repsonse != null)
                    {
                        GetSearchData();
                        dgvPublishers.Update();
                        dgvPublishers.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The record is used in a relation, it can't be deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgvPublishers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvPublishers.ClearSelection();
                    this.dgvPublishers.Rows[rowSelected].Selected = true;
                    this.ContextMenuStrip = ctxMenu;
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPublishers.SelectedRows.Count > 0)
            {
                var id = dgvPublishers.SelectedRows[0].Cells[0].Value;
                frmPublisherDetails frm = new frmPublisherDetails(Guid.Parse(id.ToString()));
                frm.Show();
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
