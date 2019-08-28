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
            //izvrsiti konverziju
            var category = await apiService.Get<List<CategoryDto>>("");
            category.Where(c => c.Guid == response.Select(x => x.LibraryDtoGuid).FirstOrDefault());
            dgvBooks.DataSource = new
            {
                ISBN = response.Select(x => x.ISBN),
                Category = category.Where(c => c.Guid == response.Select(x => x.LibraryDtoGuid).FirstOrDefault())
            };
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
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
                    //Int32 rowToDelete = dgvAuthors.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    //dgvAuthors.Rows.RemoveAt(rowToDelete);
                    //dgvAuthors.ClearSelection();
                    GetSearchData();
                    dgvBooks.Update();
                    dgvBooks.Refresh();
                }
            }
        }
    }
}
