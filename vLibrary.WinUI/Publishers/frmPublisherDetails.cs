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
    public partial class frmPublisherDetails : Form
    {
        private Guid? _id = null;
        private readonly ApiService _service = new ApiService("publisher");
        private frmPublishers _frmPublishers = (frmPublishers)Application.OpenForms["frmPublishers"];

        public frmPublisherDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmPublisherDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var publisher = await _service.GetById<Model.PublisherDto>(_id);
                txtPublisherName.Text = publisher.PublisherName;
                txtDescription.Text = publisher.Description;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            PublisherDto response = null;


            if (this.ValidateChildren())
            {
                var request = new PublisherUpsertRequest()
                {
                    PublisherName = txtPublisherName.Text,
                    Description = txtDescription.Text
                };

                if (_id.HasValue)
                {
                    response = await _service.Update<PublisherDto>(_id, request);
                    DialogResult dialogUpdate = MessageBox.Show("Publisher details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmPublishers.GetSearchData();
                        _frmPublishers.DG.Update();
                        _frmPublishers.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Publisher details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _service.Insert<PublisherDto>(request);
                    DialogResult dialogInsert = MessageBox.Show("Publisher details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtPublisherName.Clear();
                            txtDescription.Clear();
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

        private void txtPublisherName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtPublisherName);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
           // HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtDescription);
        }

        private void frmPublisherDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
