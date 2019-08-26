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
    public partial class frmAddressDetails : Form
    {
        private Guid? _id = null;
        private readonly ApiService _service = new ApiService("address");
        private frmAddress _frmAddress = (frmAddress)Application.OpenForms["frmAddress"];

        public frmAddressDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmAddressDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var address = await _service.GetById<AddressDto>(_id);
                txtStreet.Text = address.Street;
                txtCity.Text = address.City;
                txtZipCode.Text = address.ZipCode;
                txtCoutry.Text = address.Country;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            AddressDto response = null;


            if (this.ValidateChildren())
            {
                var request = new AddressUpsertRequest
                {
                    Street = txtStreet.Text,
                    City = txtCity.Text,
                    Country = txtCity.Text,
                    ZipCode = txtZipCode.Text
                };

                if (_id.HasValue)
                {
                    response = await _service.Update<AddressDto>(_id, request);
                    DialogResult dialogUpdate = MessageBox.Show("Address details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmAddress.GetSearchData();
                        _frmAddress.DG.Update();
                        _frmAddress.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Address details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _service.Insert<AddressDto>(request);
                    DialogResult dialogInsert = MessageBox.Show("Address details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtStreet.Clear();
                            txtCity.Clear();
                            txtZipCode.Clear();
                            txtCoutry.Clear();
                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
        private void TxtStreet_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtStreet);

        }

        private void TxtCity_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtCity);
        }

        private void TxtZipCode_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtZipCode);
        }

        private void TxtCoutry_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtCoutry);
        }

        private void FrmAddressDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}

       