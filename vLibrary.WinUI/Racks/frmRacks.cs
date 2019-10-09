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

namespace vLibrary.WinUI.Racks
{
    public partial class frmRacks : Form
    {
        private readonly ApiService _apiService = new ApiService("rack");
        public frmRacks()
        {
            InitializeComponent();
        }
        public DataGridView DG
        {
            get
            {
                return dgvRacks;
            }
        }

        public async void GetSearchData()
        {
            var search = new RackSearchRequest
            {
                RackNumber = txtSearch.Text
            };
            dgvRacks.AutoGenerateColumns = false;
            dgvRacks.DataSource = await _apiService.Get<List<RackDto>>(search);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSearchData();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = dgvRacks.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    var repsonse = await _apiService.Delete<RackDto>(id);

                    if (repsonse != null)
                    {
                        GetSearchData();
                        dgvRacks.Update();
                        dgvRacks.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The record is used in a relation, it can't be deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRacks.SelectedRows.Count > 0)
            {
                var id = dgvRacks.SelectedRows[0].Cells[0].Value;
                frmRackDetails frm = new frmRackDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void dgvRacks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvRacks.ClearSelection();
                    this.dgvRacks.Rows[rowSelected].Selected = true;
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

        private void frmRacks_Load(object sender, EventArgs e)
        {

        }
    }
}
