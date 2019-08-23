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

namespace vLibrary.WinUI.Authors
{
    public partial class frmAuthors : Form
    {
        public frmAuthors()
        {
            InitializeComponent();
        }

        private void FrmAuthors_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var result = "https://localhost:44344/api/Authors".GetJsonAsync<List<AuthorDto>>().Result;
            dgvAuthors.DataSource = result;
        }
    }
}
