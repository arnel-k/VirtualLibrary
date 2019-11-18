using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vLibrary.Model;
using vLibrary.Model.Requests;
using vLibrary.WinUI.HelperMethods;

namespace vLibrary.WinUI.Authors
{
    public partial class frmAuthorDetails : Form
    {
        private Guid? _id = null;
        private readonly ApiService _service = new ApiService("authors");
        private frmAuthors _frmAuthors = (frmAuthors)Application.OpenForms["frmAuthors"];
        private string token = Helper.ToInsecureString(Helper.DecryptString(ConfigurationManager.AppSettings["token"]));
        public frmAuthorDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;

        }





        private async void BtnSave_Click(object sender, EventArgs e)
        {
            AuthorDto response = null;


            if (this.ValidateChildren())
            {
                var request = new AuthorInsertRequest
                {
                    FName = txtFName.Text,
                    LName = txtLName.Text,
                    Description = txtDescription.Text
                };

                if (_id.HasValue)
                {
                    response = await _service.Update<AuthorDto>(_id, request, token);
                    DialogResult dialogUpdate = MessageBox.Show("Author details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {
                        
                        _frmAuthors.GetSearchData();
                        _frmAuthors.DG.Update();
                        _frmAuthors.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Author details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _service.Insert<AuthorDto>(request, token);
                    DialogResult dialogInsert = MessageBox.Show("Author details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtFName.Clear();
                            txtLName.Clear();
                            txtDescription.Clear();
                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }


            }

        }

        private async void FrmAuthorDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var author = await _service.GetById<Model.AuthorDto>(_id, token);
                txtFName.Text = author.FName;
                txtLName.Text = author.LName;
                txtDescription.Text = author.Description;
            }
        }

        private void TxtFName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtFName);
          
        }

        private void TxtLName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtLName);
        }

        private void FrmAuthorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
