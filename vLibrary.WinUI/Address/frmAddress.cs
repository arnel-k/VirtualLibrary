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

namespace vLibrary.WinUI.Address
{
    public partial class frmAddress : Form
    {
        private readonly ApiService apiService = new ApiService("address");
        public DataGridView DG
        {
            get
            {
                return dgvAddress;
            }
        }
        public frmAddress()
        {
            InitializeComponent();
        }
        public async void GetSearchData()
        {
            var search = new AddressSearchRequest
            {
                StreetName = txtSearch.Text
            };
            dgvAddress.AutoGenerateColumns = false;
            dgvAddress.DataSource = await apiService.Get<List<AddressDto>>(search);
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            GetSearchData();
        }

        private void DgvAddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvAddress.SelectedRows.Count > 0)
            {
                var id = dgvAddress.SelectedRows[0].Cells[0].Value;
                frmAddressDetails frm = new frmAddressDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void DgvAddress_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvAddress.ClearSelection();
                    this.dgvAddress.Rows[rowSelected].Selected = true;
                    this.ContextMenuStrip = ctxMenuAddress;
                }
            }
        }


        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetSearchData();
            }
        }

        private void UpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvAddress.SelectedRows.Count > 0)
            {
                var id = dgvAddress.SelectedRows[0].Cells[0].Value;
                frmAddressDetails frm = new frmAddressDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private async void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var id = dgvAddress.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    var repsonse = await apiService.Delete<AddressDto>(id);
                    if (repsonse != null)
                    {
                        GetSearchData();
                        dgvAddress.Update();
                        dgvAddress.Refresh();
                    }
                }
            }
            catch
            {
                MessageBox.Show($"The record is used in a relation, it can't be deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
