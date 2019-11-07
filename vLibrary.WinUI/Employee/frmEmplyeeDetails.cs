using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vLibrary.Model;
using vLibrary.Model.Enums;
using vLibrary.Model.Requests;

namespace vLibrary.WinUI.Employee
{
    public partial class frmEmplyeeDetails : Form
    {
        private Guid? _id = null;
        private Guid? _addressId = null;

        private frmEmployees _frmEmployees = (frmEmployees)Application.OpenForms["frmEmployees"];
        private readonly ApiService _employeeService = new ApiService("employee");
        private readonly ApiService _libraryService = new ApiService("library");
        private readonly ApiService _addressService = new ApiService("address");
        private readonly ApiService _accountService = new ApiService("account");
        private bool _addButtonWasClicked = false;
        private Byte[] image;
        public frmEmplyeeDetails(Guid? id = null, Guid? addressId = null)
        {
            InitializeComponent();
            _id = id;
            _addressId = addressId;
        }

        public static Image ByteToImage(byte[] bArray)
        {
            using (var mStream = new MemoryStream(bArray))
            {
                return Image.FromStream(mStream);
            }
        }

        public byte[] ImageToByte(Image img)
        {
            using (var ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                return ms.ToArray();
            }
        }

        public async void LoadData()
        {
            if (_id.HasValue)
            {
                HelperMethods.Helper.GuidIsSet = true;
            }

            var employee = await _employeeService.GetById<EmployeeDto>(_id);
            txtFName.Text = employee.FirstName;
            txtLName.Text = employee.LastName;
            txtEmail.Text = employee.Email;
            txtPhone.Text = employee.Phone;
            bindingGender.DataSource = Enum.GetValues(typeof(Gender));
            cmbGender.DataSource = bindingGender.DataSource;
            cmbGender.SelectedItem = employee.Gender;
            dateTimeBirthDate.Value = employee.BirthDate;

            if (employee.Picture.Length > 0)
            {
                pictureBox1.Image = ByteToImage(employee.Picture);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void frmEmplyeeDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                LoadData();
            }
            
        }
        public async void LoadUpdateData()
        {
            var addressData = await _addressService.GetById<AddressDto>(_addressId);

            txtStreet.Text = addressData.Street;
            txtCity.Text = addressData.City;
            txtZipCode.Text = addressData.ZipCode;
        }
        public void LoadDataIntoInsertForm()
        {
            
            cmbGender.Items.Add("---Select a value---");
            cmbGender.SelectedIndex = 0;
            bindingGender.DataSource = Enum.GetValues(typeof(Gender));

            cmbGender.BeginUpdate();
            foreach (var i in (Gender[])Enum.GetValues(typeof(Gender)))
            {
                cmbGender.Items.Add($"{i}");
            }
            cmbGender.EndUpdate();

            
            
        }
        private bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            return b1.SequenceEqual(b2);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeDto response = null;
            EmployeeDto employee = null;
            AddressDto addressResponse = null;
            AccountDto accountResponse = null;
            if (_id.HasValue)
            {
                employee = await _employeeService.GetById<EmployeeDto>(_id);
            }
            var libraries = await _libraryService.Get<List<LibraryDto>>(null);
            var addresses = await _libraryService.Get<List<AddressDto>>(null);
            
            var request = new EmployeeUpsertRequest();
            var address = new AddressUpsertRequest();
            var account = new AccountUpsertRequest();
            if (this.ValidateChildren())
            {

                if (employee == null)
                {
                    request.Picture = image;
                }
                else if (_addButtonWasClicked == true && employee != null)
                {
                    if (employee.Picture.Length <= 0 || ByteArrayCompare(employee.Picture, ImageToByte(pictureBox1.Image)) == false)
                    {
                        request.Picture = image;
                    }

                }
                else
                {
                    image = employee.Picture;
                }

                {
                    address.Street = txtStreet.Text;
                    address.City = txtCity.Text;
                    address.ZipCode = txtZipCode.Text;
                    account.UserName = txtUserName.Text;
                    if(txtPassword.Text == txtPsswdConfirm.Text)
                    {
                        account.Password = txtPassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("Password is not the same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    account.Role = Role.Librarian;
                    account.AccountStatus = AccountStatus.Active;
                    
                    if (_addressId.HasValue)
                    {
                        try
                        {
                            addressResponse = await _addressService.Update<AddressDto>(_addressId, address);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Address update error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        try
                        {
                            addressResponse = await _addressService.Insert<AddressDto>(address);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Address insertion error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                    
                    request.FirstName = txtFName.Text;
                    request.LastName = txtLName.Text;
                    request.BirthDate = dateTimeBirthDate.Value.Date;
                    request.Gender = (Gender)Enum.Parse(typeof(Gender), cmbGender.SelectedItem.ToString());
                    request.Picture = image;
                    request.Email = txtEmail.Text;
                    request.Phone = txtPhone.Text;
                    request.AddressDtoGuid = addressResponse.Guid;
                    request.LibraryDtoGuid = libraries.Select(x => x.Guid).FirstOrDefault();

                };
                
                if (_id.HasValue )
                {
                    
                    response = await _employeeService.Update<EmployeeDto>(_id, request);
                    DialogResult dialogUpdate = MessageBox.Show("Employee details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmEmployees.GetSearchData();
                        _frmEmployees.DG.Update();
                        _frmEmployees.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Employee details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    accountResponse = await _accountService.Insert<AccountDto>(account);
                    response = await _employeeService.Insert<EmployeeDto>(request);
                    DialogResult dialogInsert = MessageBox.Show("Employee details saved!\nAdd new employee?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtFName.Clear();
                            txtLName.Clear();
                            txtEmail.Clear();
                            txtPhone.Clear();
                            txtStreet.Clear();
                            txtCity.Clear();
                            txtZipCode.Clear();
                            txtUserName.Clear();
                            txtPassword.Clear();
                            txtPsswdConfirm.Clear();

                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }


            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            _addButtonWasClicked = true;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dlg.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    image = File.ReadAllBytes(dlg.FileName);
                }
            }
        }

        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtFName);
        }

        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtLName);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtEmail);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtPhone);
        }

        private void cmbGender_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.ComboBoxValidation(sender, e, errorEmployeeDetailsProvider, cmbGender);
        }

        private void frmEmplyeeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender,e, errorEmployeeDetailsProvider, txtStreet);
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtCity);
        }

        private void txtZipCode_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtZipCode);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("You can only type numbers!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtPassword);
        }

        private void txtPsswdConfirm_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtPsswdConfirm);
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorEmployeeDetailsProvider, txtUserName);
        }
    }

}
