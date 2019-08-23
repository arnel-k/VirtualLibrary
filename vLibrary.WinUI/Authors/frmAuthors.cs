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
        public frmAuthors()
        {
            InitializeComponent();
        }

        private void FrmAuthors_Load(object sender, EventArgs e)
        {

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new AuthorsSearchRequest
            {
                FName = txtSearch.Text
            };
            dgvAuthors.AutoGenerateColumns = false;
            dgvAuthors.DataSource = await apiService.Get<List<AuthorDto>>(search);
        }
    }
}
