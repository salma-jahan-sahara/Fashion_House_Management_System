
namespace Fashion_House_Management_System.Presentation_Layer
{
    partial class EmployeeManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.employeeManagementDataGridView = new System.Windows.Forms.DataGridView();
            this.addEmployeeBbutton = new System.Windows.Forms.Button();
            this.updateEmployeeButton = new System.Windows.Forms.Button();
            this.deleteEmployeeButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.nameLebel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.branchLabel = new System.Windows.Forms.Label();
            this.salaryTextBox = new System.Windows.Forms.TextBox();
            this.branchComboBox = new System.Windows.Forms.ComboBox();
            this.joinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.employeeGroupBox = new System.Windows.Forms.GroupBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ListofEmployeeGroupBox = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeeManagementDataGridView)).BeginInit();
            this.employeeGroupBox.SuspendLayout();
            this.ListofEmployeeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeeManagementDataGridView
            // 
            this.employeeManagementDataGridView.AllowUserToAddRows = false;
            this.employeeManagementDataGridView.AllowUserToDeleteRows = false;
            this.employeeManagementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeManagementDataGridView.Location = new System.Drawing.Point(18, 50);
            this.employeeManagementDataGridView.Name = "employeeManagementDataGridView";
            this.employeeManagementDataGridView.ReadOnly = true;
            this.employeeManagementDataGridView.RowHeadersWidth = 51;
            this.employeeManagementDataGridView.RowTemplate.Height = 24;
            this.employeeManagementDataGridView.Size = new System.Drawing.Size(650, 407);
            this.employeeManagementDataGridView.TabIndex = 0;
            this.employeeManagementDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeManagementDataGridView_CellClick);
            // 
            // addEmployeeBbutton
            // 
            this.addEmployeeBbutton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmployeeBbutton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.addEmployeeBbutton.Location = new System.Drawing.Point(566, 591);
            this.addEmployeeBbutton.Name = "addEmployeeBbutton";
            this.addEmployeeBbutton.Size = new System.Drawing.Size(176, 40);
            this.addEmployeeBbutton.TabIndex = 1;
            this.addEmployeeBbutton.Text = "Add";
            this.addEmployeeBbutton.UseVisualStyleBackColor = true;
            this.addEmployeeBbutton.Click += new System.EventHandler(this.addEmployeeBbutton_Click);
            // 
            // updateEmployeeButton
            // 
            this.updateEmployeeButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateEmployeeButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.updateEmployeeButton.Location = new System.Drawing.Point(1036, 591);
            this.updateEmployeeButton.Name = "updateEmployeeButton";
            this.updateEmployeeButton.Size = new System.Drawing.Size(176, 40);
            this.updateEmployeeButton.TabIndex = 2;
            this.updateEmployeeButton.Text = "Update";
            this.updateEmployeeButton.UseVisualStyleBackColor = true;
            this.updateEmployeeButton.Click += new System.EventHandler(this.updateEmployeeButton_Click);
            // 
            // deleteEmployeeButton
            // 
            this.deleteEmployeeButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteEmployeeButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.deleteEmployeeButton.Location = new System.Drawing.Point(798, 591);
            this.deleteEmployeeButton.Name = "deleteEmployeeButton";
            this.deleteEmployeeButton.Size = new System.Drawing.Size(176, 40);
            this.deleteEmployeeButton.TabIndex = 3;
            this.deleteEmployeeButton.Text = "Delete";
            this.deleteEmployeeButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeButton.Click += new System.EventHandler(this.deleteEmployeeButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.nameTextBox.Location = new System.Drawing.Point(166, 154);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(222, 35);
            this.nameTextBox.TabIndex = 4;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.usernameTextBox.Location = new System.Drawing.Point(166, 201);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(222, 35);
            this.usernameTextBox.TabIndex = 5;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.locationTextBox.Location = new System.Drawing.Point(166, 295);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(222, 35);
            this.locationTextBox.TabIndex = 8;
            // 
            // positionComboBox
            // 
            this.positionComboBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionComboBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Items.AddRange(new object[] {
            "Intern"});
            this.positionComboBox.Location = new System.Drawing.Point(166, 344);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(222, 34);
            this.positionComboBox.TabIndex = 9;
            // 
            // nameLebel
            // 
            this.nameLebel.AutoSize = true;
            this.nameLebel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLebel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.nameLebel.Location = new System.Drawing.Point(40, 154);
            this.nameLebel.Name = "nameLebel";
            this.nameLebel.Size = new System.Drawing.Size(58, 23);
            this.nameLebel.TabIndex = 10;
            this.nameLebel.Text = "Name";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.usernameLabel.Location = new System.Drawing.Point(40, 206);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(106, 23);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.locationLabel.Location = new System.Drawing.Point(40, 300);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(106, 23);
            this.locationLabel.TabIndex = 10;
            this.locationLabel.Text = "Location";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.positionLabel.Location = new System.Drawing.Point(40, 349);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(106, 23);
            this.positionLabel.TabIndex = 10;
            this.positionLabel.Text = "Position";
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.salaryLabel.Location = new System.Drawing.Point(40, 398);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(82, 23);
            this.salaryLabel.TabIndex = 10;
            this.salaryLabel.Tag = "";
            this.salaryLabel.Text = "Salary";
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.branchLabel.Location = new System.Drawing.Point(40, 449);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(82, 23);
            this.branchLabel.TabIndex = 10;
            this.branchLabel.Text = "Branch";
            // 
            // salaryTextBox
            // 
            this.salaryTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.salaryTextBox.Location = new System.Drawing.Point(166, 393);
            this.salaryTextBox.Name = "salaryTextBox";
            this.salaryTextBox.Size = new System.Drawing.Size(222, 35);
            this.salaryTextBox.TabIndex = 11;
            // 
            // branchComboBox
            // 
            this.branchComboBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchComboBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.branchComboBox.FormattingEnabled = true;
            this.branchComboBox.Items.AddRange(new object[] {
            "Dhaka",
            "Sylhet",
            "Chittagong"});
            this.branchComboBox.Location = new System.Drawing.Point(166, 444);
            this.branchComboBox.Name = "branchComboBox";
            this.branchComboBox.Size = new System.Drawing.Size(222, 34);
            this.branchComboBox.TabIndex = 12;
            // 
            // joinDateTimePicker
            // 
            this.joinDateTimePicker.Font = new System.Drawing.Font("Lucida Sans Typewriter", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinDateTimePicker.Location = new System.Drawing.Point(85, 140);
            this.joinDateTimePicker.Name = "joinDateTimePicker";
            this.joinDateTimePicker.Size = new System.Drawing.Size(200, 27);
            this.joinDateTimePicker.TabIndex = 13;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.backButton.Location = new System.Drawing.Point(990, 18);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(113, 39);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.logOutButton.Location = new System.Drawing.Point(1129, 18);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(156, 39);
            this.logOutButton.TabIndex = 15;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // employeeGroupBox
            // 
            this.employeeGroupBox.Controls.Add(this.idTextBox);
            this.employeeGroupBox.Controls.Add(this.idLabel);
            this.employeeGroupBox.Controls.Add(this.phoneTextBox);
            this.employeeGroupBox.Controls.Add(this.phoneLabel);
            this.employeeGroupBox.Controls.Add(this.nameLebel);
            this.employeeGroupBox.Controls.Add(this.nameTextBox);
            this.employeeGroupBox.Controls.Add(this.usernameTextBox);
            this.employeeGroupBox.Controls.Add(this.branchComboBox);
            this.employeeGroupBox.Controls.Add(this.locationTextBox);
            this.employeeGroupBox.Controls.Add(this.salaryTextBox);
            this.employeeGroupBox.Controls.Add(this.positionComboBox);
            this.employeeGroupBox.Controls.Add(this.positionLabel);
            this.employeeGroupBox.Controls.Add(this.usernameLabel);
            this.employeeGroupBox.Controls.Add(this.branchLabel);
            this.employeeGroupBox.Controls.Add(this.locationLabel);
            this.employeeGroupBox.Controls.Add(this.salaryLabel);
            this.employeeGroupBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeGroupBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.employeeGroupBox.Location = new System.Drawing.Point(62, 108);
            this.employeeGroupBox.Name = "employeeGroupBox";
            this.employeeGroupBox.Size = new System.Drawing.Size(407, 523);
            this.employeeGroupBox.TabIndex = 16;
            this.employeeGroupBox.TabStop = false;
            this.employeeGroupBox.Text = "Employee";
            // 
            // idTextBox
            // 
            this.idTextBox.Enabled = false;
            this.idTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.idTextBox.Location = new System.Drawing.Point(166, 103);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(222, 35);
            this.idTextBox.TabIndex = 16;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.idLabel.Location = new System.Drawing.Point(40, 108);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(34, 23);
            this.idLabel.TabIndex = 15;
            this.idLabel.Text = "ID";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.phoneTextBox.Location = new System.Drawing.Point(166, 246);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(222, 35);
            this.phoneTextBox.TabIndex = 14;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.phoneLabel.Location = new System.Drawing.Point(40, 251);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(70, 23);
            this.phoneLabel.TabIndex = 13;
            this.phoneLabel.Text = "Phone";
            // 
            // ListofEmployeeGroupBox
            // 
            this.ListofEmployeeGroupBox.Controls.Add(this.employeeManagementDataGridView);
            this.ListofEmployeeGroupBox.Controls.Add(this.joinDateTimePicker);
            this.ListofEmployeeGroupBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListofEmployeeGroupBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ListofEmployeeGroupBox.Location = new System.Drawing.Point(544, 80);
            this.ListofEmployeeGroupBox.Name = "ListofEmployeeGroupBox";
            this.ListofEmployeeGroupBox.Size = new System.Drawing.Size(695, 467);
            this.ListofEmployeeGroupBox.TabIndex = 17;
            this.ListofEmployeeGroupBox.TabStop = false;
            this.ListofEmployeeGroupBox.Text = "Employee List";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.searchTextBox.Location = new System.Drawing.Point(62, 43);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(251, 31);
            this.searchTextBox.TabIndex = 39;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(328, 41);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(141, 33);
            this.searchButton.TabIndex = 38;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // EmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 656);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.ListofEmployeeGroupBox);
            this.Controls.Add(this.employeeGroupBox);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.deleteEmployeeButton);
            this.Controls.Add(this.updateEmployeeButton);
            this.Controls.Add(this.addEmployeeBbutton);
            this.Name = "EmployeeManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeManagement_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeManagementDataGridView)).EndInit();
            this.employeeGroupBox.ResumeLayout(false);
            this.employeeGroupBox.PerformLayout();
            this.ListofEmployeeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView employeeManagementDataGridView;
        public System.Windows.Forms.Button addEmployeeBbutton;
        public System.Windows.Forms.Button updateEmployeeButton;
        public System.Windows.Forms.Button deleteEmployeeButton;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.TextBox usernameTextBox;
        public System.Windows.Forms.TextBox locationTextBox;
        public System.Windows.Forms.ComboBox positionComboBox;
        public System.Windows.Forms.Label nameLebel;
        public System.Windows.Forms.Label usernameLabel;
        public System.Windows.Forms.Label locationLabel;
        public System.Windows.Forms.Label positionLabel;
        public System.Windows.Forms.Label salaryLabel;
        public System.Windows.Forms.Label branchLabel;
        public System.Windows.Forms.TextBox salaryTextBox;
        public System.Windows.Forms.ComboBox branchComboBox;
        public System.Windows.Forms.DateTimePicker joinDateTimePicker;
        public System.Windows.Forms.Button backButton;
        public System.Windows.Forms.Button logOutButton;
        public System.Windows.Forms.GroupBox employeeGroupBox;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.GroupBox ListofEmployeeGroupBox;
        public System.Windows.Forms.TextBox phoneTextBox;
        public System.Windows.Forms.Label phoneLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}
