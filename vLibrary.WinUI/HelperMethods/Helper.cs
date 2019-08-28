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

        //public static async void GetSearchData(DataGridView dg, T search,object dto, TextBox txt)
        //{
        //    var search = new Helper<T>
        //    {
        //        FName = txtSearch.Text
        //    };
        //    dgvAuthors.AutoGenerateColumns = false;
        //    dgvAuthors.DataSource = await apiService.Get<List<AuthorDto>>(search);
        //}
    }
}
