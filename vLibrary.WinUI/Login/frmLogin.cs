using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security;
using System.Windows.Forms;
using vLibrary.Model;
using vLibrary.Model.Requests;
using vLibrary.WinUI.HelperMethods;
namespace vLibrary.WinUI.Login
{
    public partial class frmLogin : Form
    {
        private readonly ApiService _loginService = new ApiService("account/authenticate");
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Close();
           
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            AccountUpsertRequest request = new AccountUpsertRequest();
            AccountDto response = null;
            

            try
            {
                
                if (!String.IsNullOrEmpty(txtUsername.Text) || !String.IsNullOrEmpty(txtPassword.Text))
                {
                    request.UserName = txtUsername.Text.Trim();
                    request.Password = txtPassword.Text.Trim();
                    response = await _loginService.Authenticate<AccountDto>(request);
                }
                else
                {
                    MessageBox.Show("Username or Password can't be empty!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                if(response != null)
                {
                    
                    var s = ConfigurationManager.AppSettings["token"];
                    if (!String.IsNullOrEmpty(s))
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings.Remove("token");
                        config.AppSettings.Settings.Add("token", Helper.EncryptString(Helper.ToSecureString(response.Token)));

                        config.Save(ConfigurationSaveMode.Modified);

                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    else
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["token"].Value = Helper.EncryptString(Helper.ToSecureString(response.Token));
                        config.Save(ConfigurationSaveMode.Modified);

                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("An error has occurred!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
            }
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
