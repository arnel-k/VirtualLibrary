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

namespace vLibrary.WinUI.Employee
{
    public partial class frmEmployees : Form
    {
        private readonly ApiService apiService = new ApiService("employee");

        public DataGridView DG
        {
            get
            {
                return dgvEmployees;
            }
        }
        public frmEmployees()
        {
            InitializeComponent();
        }

        public async void GetSearchData()
        {

            var search = new EmployeeSearchRequest
            {
                EmployeeName = txtSearch.Text
            };
            dgvEmployees.AutoGenerateColumns = false;
            var response = await apiService.Get<List<EmployeeDto>>(search);
            dgvEmployees.DataSource = response;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetSearchData();
        }

        private async void  deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var id = dgvEmployees.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    var repsonse = await apiService.Delete<EmployeeDto>(id);
                    if (repsonse != null)
                    {

                        GetSearchData();
                        dgvEmployees.Update();
                        dgvEmployees.Refresh();
                    }
                }
            }
            catch
            {
                MessageBox.Show($"The record is used in a relation, it can't be deleted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var id = dgvEmployees.SelectedRows[0].Cells[0].Value;
                var addressId = dgvEmployees.SelectedRows[0].Cells[1].Value;
                frmEmplyeeDetails frm = new frmEmplyeeDetails(Guid.Parse(id.ToString()), Guid.Parse(addressId.ToString()));
                frm.LoadUpdateData();
                frm.Show();
            }
        }

        private void dgvEmployees_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvEmployees.ClearSelection();
                    this.dgvEmployees.Rows[rowSelected].Selected = true;
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
