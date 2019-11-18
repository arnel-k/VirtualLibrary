using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vLibrary.WinUI.HelperMethods
{
    public static class Helper
    {
        public static bool GuidIsSet { get; set; }
        public static void TextBoxValidation(object sender, CancelEventArgs e ,ErrorProvider errorProvider, TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider.SetError(txt, Properties.Resources.Validation_RequiredFiled);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txt, null);
            }
        }

        public static void ComboBoxValidation(object sender, CancelEventArgs e, ErrorProvider errorProvider, ComboBox cmb)
        {
            if(cmb.SelectedItem == null)
            {
                errorProvider.SetError(cmb, Properties.Resources.Validation_RequiredFiled);
                e.Cancel = true;
            }else if(GuidIsSet == false && cmb.SelectedIndex == 0)
            {
                errorProvider.SetError(cmb, "Please select a option!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmb, null);
            }
        }

        //Encrypte/Decrypt token
        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("asldjflasjflajslfjxcnv,xcnvdsjhf64654654316234862348---!!!");

        public static string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }
    }
}
