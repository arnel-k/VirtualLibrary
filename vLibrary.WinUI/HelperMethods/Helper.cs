using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

       
    }
}
