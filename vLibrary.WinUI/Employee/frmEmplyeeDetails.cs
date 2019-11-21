using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vLibrary.Model;
using vLibrary.Model.Enums;
using vLibrary.Model.Requests;
using vLibrary.WinUI.HelperMethods;

namespace vLibrary.WinUI.Employee
{
    public partial class frmEmplyeeDetails : Form
    {
        private Guid? _id = null;
        private Guid? _addressId = null;
        private Guid? _accountId = null;

        private frmEmployees _frmEmployees = (frmEmployees)Application.OpenForms["frmEmployees"];
        private readonly ApiService _employeeService = new ApiService("Employee");
        private readonly ApiService _libraryService = new ApiService("library");
        private readonly ApiService _addressService = new ApiService("address");
        private readonly ApiService _accountService = new ApiService("account");
        private bool _addButtonWasClicked = false;
        private Byte[] image;
        private string token = Helper.ToInsecureString(Helper.DecryptString(ConfigurationManager.AppSettings["token"]));

        ILogger logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();

        public delegate void RemoveTxt(object sender, EventArgs e);
        public frmEmplyeeDetails(Guid? id = null, Guid? addressId = null, Guid? accountId = null)
        {
            InitializeComponent();
            _id = id;
            _addressId = addressId;
            _accountId = accountId;
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

            var employee = await _employeeService.GetById<EmployeeDto>(_id,token);
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
            AddressDto addressData=null;
            AccountDto accountData = null;
            try
            {
                addressData = await _addressService.GetById<AddressDto>(_addressId, token);
                accountData = await _accountService.GetById<AccountDto>(_accountId, token); ///TODO : serialization error 
            }
            catch (Exception e)
            {
                MessageBox.Show("Proccessing error !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error : {e}");
                this.Close();
                return;
            }
            txtStreet.Text = addressData.Street;
            txtCity.Text = addressData.City;
            txtZipCode.Text = addressData.ZipCode;
            txtUserName.Text = accountData.UserName;
            txtPassword.Text = "Set new password";
            txtPsswdConfirm.Text = "Password confirmation";
            txtUserName.Enabled = false;

            txtPassword.GotFocus += RemovePassowrdText;
            txtPassword.LostFocus += AddPasswordText;
            txtPsswdConfirm.GotFocus += RemovePsswdConfirmationText;
            txtPsswdConfirm.LostFocus += AddPasswdConfirmationText;

        }

        public void RemovePassowrdText(object sender , EventArgs e)
        {
            if (txtPassword.Text == "Set new password")
            {
                txtPassword.Text = "";
            }
            
        }
        public void RemovePsswdConfirmationText(object sender, EventArgs e)
        {
            if(txtPsswdConfirm.Text == "Password confirmation")
            {
                txtPsswdConfirm.Text = "";
            }
        }

        public void AddPasswordText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Set new password";
            }
               
            
        }

        public void AddPasswdConfirmationText(object sender , EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPsswdConfirm.Text))
            {
                txtPsswdConfirm.Text = "Password confirmation";
            }
        }

        public void EmailCheck(object sender, EventArgs e)
        {

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
        public bool IsValidEmailAddress(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }catch
            {
                return false;
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeDto response = null;
            EmployeeDto employee = null;
          
            if (_id.HasValue)
            {
                employee = await _employeeService.GetById<EmployeeDto>(_id, token);
            }
 
            var request = new EmployeeUpsertRequest();
          
            DialogResult dialogInsert = new DialogResult();
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
                    request.UserName = txtUserName.Text.Trim();
                    if (IsValidEmailAddress(txtEmail.Text))
                    {
                        request.Email = txtEmail.Text;
                    }
                    else
                    {
                        MessageBox.Show("Email not valid, please provide valid email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                    request.Role = Role.Librarian;
                    request.AccountStatus = AccountStatus.Active;
                    request.FirstName = txtFName.Text;
                    request.LastName = txtLName.Text;
                    request.BirthDate = dateTimeBirthDate.Value.Date;
                    request.Gender = (Gender)Enum.Parse(typeof(Gender), cmbGender.SelectedItem.ToString());
                    request.Picture = image;
                   
                    request.Phone = txtPhone.Text;
                    request.Street = txtStreet.Text;
                    request.City = txtCity.Text;
                    request.ZipCode = txtZipCode.Text;
                    if (txtPassword.Text == txtPsswdConfirm.Text)
                    {
                        request.Password = txtPassword.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Password is not the same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                };
                
                if (_id.HasValue )
                {
                    
                    try
                    {
                        response = await _employeeService.Update<EmployeeDto>(_id, request, token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insertion error "+ ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
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
                    try
                    {
                        response = await _employeeService.Insert<EmployeeDto>(request, token); 
                        dialogInsert = MessageBox.Show("Employee details saved!\nAdd new employee?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    } catch (Exception err)
                    {
                        dialogInsert = MessageBox.Show("Employee not saved! " + err.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    
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

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void txtPsswdConfirm_Click(object sender, EventArgs e)
        {
            txtPsswdConfirm.Text = "";
        }
    }

}
