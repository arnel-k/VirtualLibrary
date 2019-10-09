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

namespace vLibrary.WinUI.Books
{
    public partial class frmBooks : Form
    {
        private readonly ApiService apiService = new ApiService("book");

        public DataGridView DG
        {
            get
            {
                return dgvBooks;
            }
        }
        public frmBooks()
        {
            InitializeComponent();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmBooks_Load(object sender, EventArgs e)
        {

        }
        //Get data into the datagrid 
        public async void GetSearchData()
        {
            
            var search = new BookSearchRequest
            {
                Title = txtSearch.Text
            };
            dgvBooks.AutoGenerateColumns = false;
            var response = await apiService.Get<List<BookDto>>(search);
            dgvBooks.DataSource = response;

           
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetSearchData();
            
        }

        private async void  DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var id = dgvBooks.SelectedRows[0].Cells[0].Value;
            DialogResult dialogResult = MessageBox.Show("Do you wan't to remove it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var repsonse = await apiService.Delete<BookDto>(id);
                if (repsonse != null)
                {
                    GetSearchData();
                    dgvBooks.Update();
                    dgvBooks.Refresh();
                }
            }
        }

        private void DgvBooks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var id = dgvBooks.SelectedRows[0].Cells[0].Value;
                frmBookDetails frm = new frmBookDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var id = dgvBooks.SelectedRows[0].Cells[0].Value;
                frmBookDetails frm = new frmBookDetails(Guid.Parse(id.ToString()));
                frm.Show();
            }
        }

        private void DgvBooks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgvBooks.ClearSelection();
                    this.dgvBooks.Rows[rowSelected].Selected = true;
                    this.ContextMenuStrip = ctxBookMenu;
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
    }
}
