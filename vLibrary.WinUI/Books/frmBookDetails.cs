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
using System.Diagnostics;
using System.IO;

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
        private readonly ApiService _libraryService = new ApiService("library");
        private bool _addButtonWasClicked = false;
        private Byte[] image;
        public frmBookDetails(Guid? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        public static Image ByteToImage(byte[] bArray)
        {
            using (var mStream = new MemoryStream(bArray))
            {
                return Image.FromStream(mStream);
            }
        }

        public  byte[] ImageToByte(Image img)
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

            bindingBookPublisher.DataSource = publisher.Select(x => x.PublisherName).ToList();
            cmbPublisher.DataSource = bindingBookPublisher.DataSource;
            cmbPublisher.SelectedItem = book.PublisherName;

            
            cmbRackNumberLocation.BeginUpdate();
            foreach (var i in rack)
            {
                cmbRackNumberLocation.Items.Add(String.Format("{0} | {1}", i.RackNumber, i.LocationIdentification));

            }

            cmbRackNumberLocation.EndUpdate();

            var s = rack.Where(r => r.RackNumber.ToString() == book.RackNumber).Select(x => new
            {
                value = String.Format("{0} | {1}", x.RackNumber, x.LocationIdentification)
            }).FirstOrDefault();


            cmbRackNumberLocation.SelectedItem = s.value;


            dateTimePublicationDate.Value = book.PublicationDate;
            if (book.Image.Length > 0)
            {
                pictureBox1.Image = ByteToImage(book.Image);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        public async void LoadDataIntoInsertForm()
        {
            
            var category = await _categoryService.Get<List<CategoryDto>>(null);
            var publisher = await _publisherService.Get<List<PublisherDto>>(null);
            var rack = await _rackService.Get<List<RackDto>>(null);

            cmbBookStatus.Items.Add("---Select a value---");
            cmbBookStatus.SelectedIndex = 0;
            bindingBookStatus.DataSource = Enum.GetValues(typeof(BookStatus));
           
            cmbBookStatus.BeginUpdate();
            foreach (var i in (BookStatus[]) Enum.GetValues(typeof(BookStatus)))
            {
                cmbBookStatus.Items.Add($"{i}");
            }
            cmbBookStatus.EndUpdate();

            cmbCategory.Items.Add("---Select a value---");
            cmbCategory.SelectedIndex = 0;
            bindingBookCategory.DataSource = category;
            cmbCategory.BeginUpdate();
            foreach(var i in category)
            {
                cmbCategory.Items.Add($"{i.CategoryName}");
            }
            cmbCategory.EndUpdate();

            cmbPublisher.Items.Add("---Select a value---");
            cmbPublisher.SelectedIndex = 0;
            bindingBookPublisher.DataSource = publisher;
            cmbPublisher.BeginUpdate();
            
            foreach(var i in publisher)
            {
                cmbPublisher.Items.Add($"{i.PublisherName}");
            }
            cmbPublisher.EndUpdate();

            cmbRackNumberLocation.Items.Add("---Select a value---");
            cmbRackNumberLocation.SelectedIndex = 0;
            bindingBookRackLocation.DataSource = rack;
            
            cmbRackNumberLocation.BeginUpdate();
            
            foreach (var i in rack)
            {
                cmbRackNumberLocation.Items.Add(String.Format("{0} | {1}", i.RackNumber, i.LocationIdentification));

            }

            cmbRackNumberLocation.EndUpdate();
           
        

        }
        private void FrmBookDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                LoadData();
            }
        }
        private bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            return b1.SequenceEqual(b2);
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            BookDto response = null;
            BookDto book = null;
            if (_id.HasValue)
            {
               book  = await _bookService.GetById<BookDto>(_id);
            }
            var libraries = await _libraryService.Get<List<LibraryDto>> (null);
            var category = await _categoryService.Get<List<CategoryDto>>(null);
            var publisher = await _publisherService.Get<List<PublisherDto>>(null);
            var rack = await _rackService.Get<List<RackDto>>(null);
            var indexOfPipe = cmbRackNumberLocation.SelectedItem.ToString().IndexOf("|");
            var request = new BookUpsertRequest();
            if (this.ValidateChildren())
            {
                
                if (book == null)
                {
                    request.Image = image;
                }
                else if (_addButtonWasClicked == true && book != null)
                {
                    if (book.Image.Length <= 0 || ByteArrayCompare(book.Image, ImageToByte(pictureBox1.Image)) == false)
                    {
                        request.Image = image;
                    }
                    
                }
                else
                {
                    image = book.Image;
                }

                {
                    request.ISBN = txtISBN.Text;
                    request.NumberOfPages = Int32.Parse(txtNumofPages.Text);
                    request.PublicationDate = dateTimePublicationDate.Value.Date;
                    request.Subject = txtSubject.Text;
                    request.Title = txtTitle.Text;
                    request.BookStatus = (BookStatus)Enum.Parse(typeof(BookStatus), cmbBookStatus.SelectedItem.ToString());
                    request.CategoryDtoGuid = category.Where(c => c.CategoryName == cmbCategory.SelectedItem.ToString()).Select(g => g.Guid).FirstOrDefault();
                    request.PublisherDtoGuid = publisher.Where(p => p.PublisherName == cmbPublisher.SelectedItem.ToString()).Select(g => g.Guid).FirstOrDefault();
                    request.LibraryDtoGuid = libraries.Select(x => x.Guid).FirstOrDefault();
                    request.RackDtoGuid = rack.Where(r => r.RackNumber.ToString() == cmbRackNumberLocation.SelectedItem.ToString().Substring(0, indexOfPipe).Trim()).Select(g => g.Guid).FirstOrDefault();
                    request.Image = image;
                   
                    

                };
               // Debug.WriteLine(request.RackDtoGuid);
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

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            _addButtonWasClicked = true;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dlg.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    image = File.ReadAllBytes(dlg.FileName);
                }
            }
        }

        private void TxtISBN_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e,errorBookDetailsProvider, txtISBN);
        }

        private void TxtTitle_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorBookDetailsProvider, txtTitle);
        }

        private void TxtSubject_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorBookDetailsProvider, txtSubject);
        }

        private void TxtNumofPages_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.TextBoxValidation(sender, e, errorBookDetailsProvider, txtNumofPages);
        }

        private void CmbBookStatus_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.ComboBoxValidation(sender, e, errorBookDetailsProvider, cmbBookStatus);
        }

        private void CmbCategory_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.ComboBoxValidation(sender, e, errorBookDetailsProvider, cmbCategory);
        }

        private void CmbPublisher_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.ComboBoxValidation(sender, e, errorBookDetailsProvider, cmbPublisher);
        }

        private void CmbRackNumberLocation_Validating(object sender, CancelEventArgs e)
        {
            HelperMethods.Helper.ComboBoxValidation(sender, e, errorBookDetailsProvider, cmbRackNumberLocation);
        }

        private void FrmBookDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void TxtNumofPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("You can only type numbers!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }
    }
}
