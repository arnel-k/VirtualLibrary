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
using vLibrary.Model.Enums;
using vLibrary.Model.Requests;

namespace vLibrary.WinUI.Books
{
    public partial class frmBookDetails : Form
    {
        private Guid? _id = null;
      
        private frmBooks _frmBooks = (frmBooks)Application.OpenForms["frmBooks"];

        private readonly ApiService _bookService = new ApiService("book");
        private readonly ApiService _categoryService = new ApiService("category");
        private readonly ApiService _publisherService = new ApiService("publisher");
        private readonly ApiService _rackService = new ApiService("rack");
        public frmBookDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FrmBookDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var book = await _bookService.GetById<BookDto>(_id);
                var category = await _categoryService.Get<List<CategoryDto>>(null);
                var publisher = await _publisherService.Get<List<PublisherDto>>(null);
                var rack = await _rackService.Get<List<RackDto>>(null);
                txtISBN.Text = book.ISBN;
                txtTitle.Text = book.Title;
                txtSubject.Text = book.Subject;
                txtNumofPages.Text = book.NumberOfPages.ToString();

                bindingBookStatus.DataSource = Enum.GetValues(typeof(BookStatus));
                cmbBookStatus.DataSource = bindingBookStatus.DataSource;
                cmbBookStatus.SelectedItem = book.BookStatus;

                bindingBookCategory.DataSource = category.Select(x => x.CategoryName).ToList();
                cmbCategory.DataSource = bindingBookCategory.DataSource;
                cmbCategory.SelectedItem = book.CategoryName;

                bindingBookPublisher.DataSource = publisher.Select(x=>x.PublisherName).ToList();
                cmbPublisher.DataSource = bindingBookPublisher.DataSource;
                cmbPublisher.SelectedItem = book.PublisherName;

                bindingBookRackLocation.DataSource = rack.Select(x => x.LocationIdentification).ToList();
                cmbRackLocation.DataSource = bindingBookRackLocation.DataSource;
                cmbRackLocation.SelectedItem = book.RackLocation;

                bindingBookRackNumber.DataSource = rack.Select(x => x.RackNumber).ToList();
                cmbRackNumber.DataSource = bindingBookRackNumber.DataSource;
                cmbRackNumber.SelectedItem = book.RackNumber;

                dateTimePublicationDate.Value = book.PublicationDate;

            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            BookDto response = null;
            var category = await _categoryService.Get<List<CategoryDto>>(null);

            if (this.ValidateChildren())
            {
                var request = new BookInsertRequest
                {
                    ISBN = txtISBN.Text,
                    NumberOfPages = Int32.Parse(txtNumofPages.Text),
                    PublicationDate = dateTimePublicationDate.Value,
                    Subject = txtSubject.Text,
                    Title = txtTitle.Text,
                   // BookStatus = (BookStatus)Enum.Parse(typeof(BookStatus), cmbBookStatus.SelectedText),
                    

                };

                if (_id.HasValue)
                {
                    response = await _bookService.Update<BookDto>(_id, request);
                    DialogResult dialogUpdate = MessageBox.Show("Book details updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (response != null)
                    {

                        _frmBooks.GetSearchData();
                        _frmBooks.DG.Update();
                        _frmBooks.DG.Refresh();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Book details not updated!", "Conforamtion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }

                else
                {
                    response = await _bookService.Insert<BookDto>(request);
                    DialogResult dialogInsert = MessageBox.Show("Book details saved!\nAdd new author?", "Conforamtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response != null)
                    {
                        if (dialogInsert == DialogResult.Yes)
                        {
                            txtISBN.Clear();
                            txtNumofPages.Clear();
                            txtSubject.Clear();
                            txtTitle.Clear();
                        }
                        else if (dialogInsert == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }


            }


        }
    }
}
