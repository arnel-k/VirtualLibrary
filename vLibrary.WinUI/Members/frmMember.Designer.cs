namespace vLibrary.WinUI.Members
{
    partial class frmMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RackLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RackDtoGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherDtoGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDtoGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LibraryGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Image
            // 
            this.Image.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Image.DataPropertyName = "Image";
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image.Visible = false;
            // 
            // RackLocation
            // 
            this.RackLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RackLocation.DataPropertyName = "RackLocation";
            this.RackLocation.HeaderText = "Rack Location";
            this.RackLocation.Name = "RackLocation";
            this.RackLocation.ReadOnly = true;
            // 
            // RackDtoGuid
            // 
            this.RackDtoGuid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RackDtoGuid.DataPropertyName = "RackNumber";
            this.RackDtoGuid.HeaderText = "Rack Number";
            this.RackDtoGuid.Name = "RackDtoGuid";
            this.RackDtoGuid.ReadOnly = true;
            // 
            // PublisherDtoGuid
            // 
            this.PublisherDtoGuid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PublisherDtoGuid.DataPropertyName = "PublisherName";
            this.PublisherDtoGuid.HeaderText = "Publisher";
            this.PublisherDtoGuid.Name = "PublisherDtoGuid";
            this.PublisherDtoGuid.ReadOnly = true;
            // 
            // CategoryDtoGuid
            // 
            this.CategoryDtoGuid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryDtoGuid.DataPropertyName = "CategoryName";
            this.CategoryDtoGuid.HeaderText = "Category";
            this.CategoryDtoGuid.Name = "CategoryDtoGuid";
            this.CategoryDtoGuid.ReadOnly = true;
            // 
            // PublicationDate
            // 
            this.PublicationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PublicationDate.DataPropertyName = "PublicationDate";
            this.PublicationDate.HeaderText = "Publication Date";
            this.PublicationDate.Name = "PublicationDate";
            this.PublicationDate.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "NumberOfPages";
            this.Description.HeaderText = "Number Of Pages";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // BookStatus
            // 
            this.BookStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookStatus.DataPropertyName = "BookStatus";
            this.BookStatus.HeaderText = "Book Status";
            this.BookStatus.Name = "BookStatus";
            this.BookStatus.ReadOnly = true;
            // 
            // Subject
            // 
            this.Subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // lName
            // 
            this.lName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lName.DataPropertyName = "Title";
            this.lName.HeaderText = "Title";
            this.lName.Name = "lName";
            this.lName.ReadOnly = true;
            // 
            // fName
            // 
            this.fName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fName.DataPropertyName = "ISBN";
            this.fName.HeaderText = "ISBN";
            this.fName.Name = "fName";
            this.fName.ReadOnly = true;
            // 
            // LibraryGuid
            // 
            this.LibraryGuid.DataPropertyName = "LibraryDtoGuid";
            this.LibraryGuid.HeaderText = "Library Guid";
            this.LibraryGuid.Name = "LibraryGuid";
            this.LibraryGuid.ReadOnly = true;
            this.LibraryGuid.Visible = false;
            // 
            // AuthorId
            // 
            this.AuthorId.DataPropertyName = "Guid";
            this.AuthorId.HeaderText = "BookId";
            this.AuthorId.Name = "AuthorId";
            this.AuthorId.ReadOnly = true;
            this.AuthorId.Visible = false;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuthorId,
            this.LibraryGuid,
            this.fName,
            this.lName,
            this.Subject,
            this.BookStatus,
            this.Description,
            this.PublicationDate,
            this.CategoryDtoGuid,
            this.PublisherDtoGuid,
            this.RackDtoGuid,
            this.RackLocation,
            this.Image});
            this.dgvBooks.Location = new System.Drawing.Point(3, 16);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(708, 319);
            this.dgvBooks.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(544, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvBooks);
            this.groupBox1.Location = new System.Drawing.Point(44, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 335);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Books";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(47, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(471, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // frmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmMember";
            this.Text = "Member - Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn RackLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn RackDtoGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherDtoGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryDtoGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn lName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LibraryGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorId;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}