namespace vLibrary.WinUI.Books
{
    partial class frmBookDetails
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumofPages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBookStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePublicationDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPublisher = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRackNumber = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRackLocation = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpBookPicture = new System.Windows.Forms.GroupBox();
            this.bindingBookStatus = new System.Windows.Forms.BindingSource(this.components);
            this.bindingBookCategory = new System.Windows.Forms.BindingSource(this.components);
            this.bindingBookPublisher = new System.Windows.Forms.BindingSource(this.components);
            this.bindingBookRackNumber = new System.Windows.Forms.BindingSource(this.components);
            this.bindingBookRackLocation = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBookPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookRackNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookRackLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(532, 540);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(65, 179);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(240, 20);
            this.txtSubject.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Subject:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(65, 135);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(240, 20);
            this.txtTitle.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(65, 90);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(240, 20);
            this.txtISBN.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ISBN:";
            // 
            // txtNumofPages
            // 
            this.txtNumofPages.Location = new System.Drawing.Point(65, 224);
            this.txtNumofPages.Name = "txtNumofPages";
            this.txtNumofPages.Size = new System.Drawing.Size(240, 20);
            this.txtNumofPages.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Number of pages:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Book status:";
            // 
            // cmbBookStatus
            // 
            this.cmbBookStatus.FormattingEnabled = true;
            this.cmbBookStatus.Location = new System.Drawing.Point(65, 262);
            this.cmbBookStatus.Name = "cmbBookStatus";
            this.cmbBookStatus.Size = new System.Drawing.Size(240, 21);
            this.cmbBookStatus.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Publication date:";
            // 
            // dateTimePublicationDate
            // 
            this.dateTimePublicationDate.Location = new System.Drawing.Point(367, 87);
            this.dateTimePublicationDate.Name = "dateTimePublicationDate";
            this.dateTimePublicationDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePublicationDate.TabIndex = 21;
            // 
            // cmbPublisher
            // 
            this.cmbPublisher.FormattingEnabled = true;
            this.cmbPublisher.Location = new System.Drawing.Point(367, 134);
            this.cmbPublisher.Name = "cmbPublisher";
            this.cmbPublisher.Size = new System.Drawing.Size(240, 21);
            this.cmbPublisher.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Publisher";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(65, 301);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(240, 21);
            this.cmbCategory.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Category";
            // 
            // cmbRackNumber
            // 
            this.cmbRackNumber.FormattingEnabled = true;
            this.cmbRackNumber.Location = new System.Drawing.Point(367, 179);
            this.cmbRackNumber.Name = "cmbRackNumber";
            this.cmbRackNumber.Size = new System.Drawing.Size(240, 21);
            this.cmbRackNumber.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(364, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Rack Number:";
            // 
            // cmbRackLocation
            // 
            this.cmbRackLocation.FormattingEnabled = true;
            this.cmbRackLocation.Location = new System.Drawing.Point(367, 218);
            this.cmbRackLocation.Name = "cmbRackLocation";
            this.cmbRackLocation.Size = new System.Drawing.Size(240, 21);
            this.cmbRackLocation.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(364, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Rack Location";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 147);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // grpBookPicture
            // 
            this.grpBookPicture.Controls.Add(this.pictureBox1);
            this.grpBookPicture.Location = new System.Drawing.Point(367, 285);
            this.grpBookPicture.Name = "grpBookPicture";
            this.grpBookPicture.Size = new System.Drawing.Size(240, 193);
            this.grpBookPicture.TabIndex = 34;
            this.grpBookPicture.TabStop = false;
            this.grpBookPicture.Text = "Book Picture";
            // 
            // frmBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 632);
            this.Controls.Add(this.grpBookPicture);
            this.Controls.Add(this.cmbRackLocation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbRackNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPublisher);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePublicationDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBookStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumofPages);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Details";
            this.Load += new System.EventHandler(this.FrmBookDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBookPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookRackNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingBookRackLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumofPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBookStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePublicationDate;
        private System.Windows.Forms.ComboBox cmbPublisher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRackNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbRackLocation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpBookPicture;
        private System.Windows.Forms.BindingSource bindingBookStatus;
        private System.Windows.Forms.BindingSource bindingBookCategory;
        private System.Windows.Forms.BindingSource bindingBookPublisher;
        private System.Windows.Forms.BindingSource bindingBookRackNumber;
        private System.Windows.Forms.BindingSource bindingBookRackLocation;
    }
}