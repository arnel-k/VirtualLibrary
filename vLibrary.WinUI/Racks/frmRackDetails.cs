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

namespace vLibrary.WinUI.Racks
{
    public partial class frmRackDetails : Form
    {
        private Guid? _id = null;
        private readonly ApiService _service = new ApiService("rack");
        private frmRacks _frmRacks = (frmRacks)Application.OpenForms["frmRacks"];
        public frmRackDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmRackDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var rack = await _service.GetById<Model.RackDto>(_id);
                txtRackNumber.Text = rack.RackNumber.ToString();
                txtLocationIdentification.Text = rack.LocationIdentification;

            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            RackDto response = null;


            if (this.ValidateChildren())
            {
                var request = new RackUpsertRequest()
                {
                    RackNumber = Int32.Parse(txtRackNumber.Text),
                    LocationIdentification = txtLocationIdentification.Text
                };

                if (_id.HasValue)
                {
                    response = await _service.Update<RackDto>(_id, request);
                    DialogResult dialogUpdate = MessageBox.Show("Rack details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmRacks.GetSearchData();
                        _frmRacks.DG.Update();
                        _frmRacks.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Rack details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _service.Insert<RackDto>(request);
                    DialogResult dialogInsert = MessageBox.Show("Rack details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtRackNumber.Clear();
                            txtLocationIdentification.Clear();
                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }


            }
        }

        private void txtRackNumber_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtRackNumber);
        }

        private void txtLocationIdentification_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorProvider, txtLocationIdentification);
        }

        private void frmRackDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void txtRackNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("You can only type numbers!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
