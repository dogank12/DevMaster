namespace ChallengeFluent
{
    partial class AddPersonDlg
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
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.TextBox();
            this.DateOfBirthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateNewPerson = new System.Windows.Forms.Button();
            this.Errors = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(23, 91);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(129, 20);
            this.FirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Last Name";
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(169, 91);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(121, 20);
            this.LastName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "&ID";
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(23, 47);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(129, 20);
            this.Id.TabIndex = 4;
            // 
            // DateOfBirthTimePicker
            // 
            this.DateOfBirthTimePicker.Location = new System.Drawing.Point(23, 140);
            this.DateOfBirthTimePicker.Name = "DateOfBirthTimePicker";
            this.DateOfBirthTimePicker.Size = new System.Drawing.Size(129, 20);
            this.DateOfBirthTimePicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date of &Birth";
            // 
            // CreateNewPerson
            // 
            this.CreateNewPerson.Location = new System.Drawing.Point(302, 182);
            this.CreateNewPerson.Name = "CreateNewPerson";
            this.CreateNewPerson.Size = new System.Drawing.Size(160, 32);
            this.CreateNewPerson.TabIndex = 9;
            this.CreateNewPerson.Text = "Create New";
            this.CreateNewPerson.UseVisualStyleBackColor = true;
            this.CreateNewPerson.Click += new System.EventHandler(this.CreateNewPerson_Click);
            // 
            // Errors
            // 
            this.Errors.FormattingEnabled = true;
            this.Errors.Location = new System.Drawing.Point(302, 47);
            this.Errors.Name = "Errors";
            this.Errors.Size = new System.Drawing.Size(160, 121);
            this.Errors.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Errors";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(299, 217);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 12;
            // 
            // AddPersonDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 236);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Errors);
            this.Controls.Add(this.CreateNewPerson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DateOfBirthTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstName);
            this.Name = "AddPersonDlg";
            this.Text = "Add Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.DateTimePicker DateOfBirthTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateNewPerson;
        private System.Windows.Forms.ListBox Errors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StatusLabel;
    }
}

