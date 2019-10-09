namespace vLibrary.WinUI.Racks
{
    partial class frmRackDetails
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
            this.txtRackNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocationIdentification = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRackNumber
            // 
            this.txtRackNumber.Location = new System.Drawing.Point(73, 123);
            this.txtRackNumber.Name = "txtRackNumber";
            this.txtRackNumber.Size = new System.Drawing.Size(240, 20);
            this.txtRackNumber.TabIndex = 22;
            this.txtRackNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRackNumber_KeyPress);
            this.txtRackNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtRackNumber_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Rack Number:";
            // 
            // txtLocationIdentification
            // 
            this.txtLocationIdentification.Location = new System.Drawing.Point(73, 176);
            this.txtLocationIdentification.Name = "txtLocationIdentification";
            this.txtLocationIdentification.Size = new System.Drawing.Size(240, 20);
            this.txtLocationIdentification.TabIndex = 25;
            this.txtLocationIdentification.Validating += new System.ComponentModel.CancelEventHandler(this.txtLocationIdentification_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Location Identification:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmRackDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 384);
            this.Controls.Add(this.txtLocationIdentification);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRackNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRackDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert - Update Rack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRackDetails_FormClosing);
            this.Load += new System.EventHandler(this.frmRackDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRackNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocationIdentification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}