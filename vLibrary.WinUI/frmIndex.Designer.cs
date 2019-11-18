namespace vLibrary.WinUI
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.authorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.newBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.newCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.newRackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empoleesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.newEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorsToolStripMenuItem,
            this.addressesToolStripMenuItem,
            this.booksToolStripMenuItem,
            this.publishersToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.racksToolStripMenuItem,
            this.empoleesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // authorsToolStripMenuItem
            // 
            this.authorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.newAuthorToolStripMenuItem});
            this.authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            this.authorsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.authorsToolStripMenuItem.Text = "&Authors";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // newAuthorToolStripMenuItem
            // 
            this.newAuthorToolStripMenuItem.Name = "newAuthorToolStripMenuItem";
            this.newAuthorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newAuthorToolStripMenuItem.Text = "&New Author";
            this.newAuthorToolStripMenuItem.Click += new System.EventHandler(this.NewAuthorToolStripMenuItem_Click);
            // 
            // addressesToolStripMenuItem
            // 
            this.addressesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem1,
            this.newAddressToolStripMenuItem});
            this.addressesToolStripMenuItem.Name = "addressesToolStripMenuItem";
            this.addressesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.addressesToolStripMenuItem.Text = "A&ddress";
            // 
            // searchToolStripMenuItem1
            // 
            this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            this.searchToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.searchToolStripMenuItem1.Text = "&Search";
            this.searchToolStripMenuItem1.Click += new System.EventHandler(this.SearchToolStripMenuItem1_Click);
            // 
            // newAddressToolStripMenuItem
            // 
            this.newAddressToolStripMenuItem.Name = "newAddressToolStripMenuItem";
            this.newAddressToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newAddressToolStripMenuItem.Text = "&New Address";
            this.newAddressToolStripMenuItem.Click += new System.EventHandler(this.NewAddressToolStripMenuItem_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem2,
            this.addNewToolStripMenuItem});
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.booksToolStripMenuItem.Text = "&Books";
            // 
            // searchToolStripMenuItem2
            // 
            this.searchToolStripMenuItem2.Name = "searchToolStripMenuItem2";
            this.searchToolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.searchToolStripMenuItem2.Text = "&Search";
            this.searchToolStripMenuItem2.Click += new System.EventHandler(this.SearchToolStripMenuItem2_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addNewToolStripMenuItem.Text = "&New Book";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // publishersToolStripMenuItem
            // 
            this.publishersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem3,
            this.newBookToolStripMenuItem});
            this.publishersToolStripMenuItem.Name = "publishersToolStripMenuItem";
            this.publishersToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.publishersToolStripMenuItem.Text = "&Publishers";
            // 
            // searchToolStripMenuItem3
            // 
            this.searchToolStripMenuItem3.Name = "searchToolStripMenuItem3";
            this.searchToolStripMenuItem3.Size = new System.Drawing.Size(150, 22);
            this.searchToolStripMenuItem3.Text = "&Search";
            this.searchToolStripMenuItem3.Click += new System.EventHandler(this.searchToolStripMenuItem3_Click);
            // 
            // newBookToolStripMenuItem
            // 
            this.newBookToolStripMenuItem.Name = "newBookToolStripMenuItem";
            this.newBookToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newBookToolStripMenuItem.Text = "&New Publisher";
            this.newBookToolStripMenuItem.Click += new System.EventHandler(this.newBookToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem4,
            this.newCategoryToolStripMenuItem});
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "&Categories";
            // 
            // searchToolStripMenuItem4
            // 
            this.searchToolStripMenuItem4.Name = "searchToolStripMenuItem4";
            this.searchToolStripMenuItem4.Size = new System.Drawing.Size(149, 22);
            this.searchToolStripMenuItem4.Text = "&Search";
            this.searchToolStripMenuItem4.Click += new System.EventHandler(this.searchToolStripMenuItem4_Click);
            // 
            // newCategoryToolStripMenuItem
            // 
            this.newCategoryToolStripMenuItem.Name = "newCategoryToolStripMenuItem";
            this.newCategoryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newCategoryToolStripMenuItem.Text = "&New Category";
            this.newCategoryToolStripMenuItem.Click += new System.EventHandler(this.newCategoryToolStripMenuItem_Click);
            // 
            // racksToolStripMenuItem
            // 
            this.racksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem5,
            this.newRackToolStripMenuItem});
            this.racksToolStripMenuItem.Name = "racksToolStripMenuItem";
            this.racksToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.racksToolStripMenuItem.Text = "&Racks";
            // 
            // searchToolStripMenuItem5
            // 
            this.searchToolStripMenuItem5.Name = "searchToolStripMenuItem5";
            this.searchToolStripMenuItem5.Size = new System.Drawing.Size(126, 22);
            this.searchToolStripMenuItem5.Text = "&Search";
            this.searchToolStripMenuItem5.Click += new System.EventHandler(this.searchToolStripMenuItem5_Click);
            // 
            // newRackToolStripMenuItem
            // 
            this.newRackToolStripMenuItem.Name = "newRackToolStripMenuItem";
            this.newRackToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newRackToolStripMenuItem.Text = "&New Rack";
            this.newRackToolStripMenuItem.Click += new System.EventHandler(this.newRackToolStripMenuItem_Click);
            // 
            // empoleesToolStripMenuItem
            // 
            this.empoleesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem6,
            this.newEmployeeToolStripMenuItem});
            this.empoleesToolStripMenuItem.Name = "empoleesToolStripMenuItem";
            this.empoleesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.empoleesToolStripMenuItem.Text = "&Employees";
            // 
            // searchToolStripMenuItem6
            // 
            this.searchToolStripMenuItem6.Name = "searchToolStripMenuItem6";
            this.searchToolStripMenuItem6.Size = new System.Drawing.Size(153, 22);
            this.searchToolStripMenuItem6.Text = "&Search";
            this.searchToolStripMenuItem6.Click += new System.EventHandler(this.searchToolStripMenuItem6_Click);
            // 
            // newEmployeeToolStripMenuItem
            // 
            this.newEmployeeToolStripMenuItem.Name = "newEmployeeToolStripMenuItem";
            this.newEmployeeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newEmployeeToolStripMenuItem.Text = "&New Employee";
            this.newEmployeeToolStripMenuItem.Click += new System.EventHandler(this.newEmployeeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1063, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 679);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmIndex";
            this.Text = "Virtual Library - Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIndex_FormClosing);
            this.Load += new System.EventHandler(this.FrmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem authorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem newCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem newRackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empoleesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem newEmployeeToolStripMenuItem;
    }
}



