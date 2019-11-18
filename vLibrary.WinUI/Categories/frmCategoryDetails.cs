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

namespace vLibrary.WinUI.Categories
{
    public partial class frmCategoryDetails : Form
    {
        private Guid? _id = null;
        private readonly ApiService _service = new ApiService("category");
        private frmCategories _frmCategories = (frmCategories)Application.OpenForms["frmCategories"];
        private string token = Helper.ToInsecureString(Helper.DecryptString(ConfigurationManager.AppSettings["token"]));
        public frmCategoryDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }

       

        private async void frmCategoryDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var category = await _service.GetById<Model.CategoryDto>(_id, token);
                txtCategoryName.Text = category.CategoryName;
                
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            CategoryDto response = null;


            if (this.ValidateChildren())
            {
                var request = new CategoryUpsertRequest()
                {
                    CategoryName = txtCategoryName.Text
                };

                if (_id.HasValue)
                {
                    response = await _service.Update<CategoryDto>(_id, request, token);
                    DialogResult dialogUpdate = MessageBox.Show("Category details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmCategories.GetSearchData();
                        _frmCategories.DG.Update();
                        _frmCategories.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Category details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _service.Insert<CategoryDto>(request, token);
                    DialogResult dialogInsert = MessageBox.Show("Category details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtCategoryName.Clear();
                            
                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }


            }

        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtCategoryName);
        }

        private void frmCategoryDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }

}
