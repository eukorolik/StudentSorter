namespace StudentSorter
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.SelectFileField = new System.Windows.Forms.TextBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SexSelect = new System.Windows.Forms.ComboBox();
            this.SuccessStudentLabel = new System.Windows.Forms.Label();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.PreferredUns = new System.Windows.Forms.ComboBox();
            this.TestITField = new System.Windows.Forms.TextBox();
            this.TestRussianField = new System.Windows.Forms.TextBox();
            this.TestMathField = new System.Windows.Forms.TextBox();
            this.StudentSecNameField = new System.Windows.Forms.TextBox();
            this.StudentNameField = new System.Windows.Forms.TextBox();
            this.StudentSurnameField = new System.Windows.Forms.TextBox();
            this.StudentSortButton = new System.Windows.Forms.Button();
            this.OpenStudentList = new System.Windows.Forms.OpenFileDialog();
            this.UploadListButton = new System.Windows.Forms.Button();
            this.SuccessListLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(760, 105);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перед вами программа для распределения студентов по ВУЗам на факультет Информацио" +
    "нных технологий. Вы можете выбрать Excel-файл (.csv) со списком студентов:";
            // 
            // SelectFileField
            // 
            this.SelectFileField.BackColor = System.Drawing.SystemColors.Window;
            this.SelectFileField.Location = new System.Drawing.Point(20, 120);
            this.SelectFileField.Name = "SelectFileField";
            this.SelectFileField.ReadOnly = true;
            this.SelectFileField.Size = new System.Drawing.Size(298, 26);
            this.SelectFileField.TabIndex = 1;
            this.SelectFileField.Text = "Загрузить файл";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectFileButton.Location = new System.Drawing.Point(325, 120);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(101, 30);
            this.SelectFileButton.TabIndex = 2;
            this.SelectFileButton.Text = "Выбрать";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(760, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Или ввести их вручную:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SexSelect);
            this.groupBox1.Controls.Add(this.SuccessStudentLabel);
            this.groupBox1.Controls.Add(this.AddStudentButton);
            this.groupBox1.Controls.Add(this.PreferredUns);
            this.groupBox1.Controls.Add(this.TestITField);
            this.groupBox1.Controls.Add(this.TestRussianField);
            this.groupBox1.Controls.Add(this.TestMathField);
            this.groupBox1.Controls.Add(this.StudentSecNameField);
            this.groupBox1.Controls.Add(this.StudentNameField);
            this.groupBox1.Controls.Add(this.StudentSurnameField);
            this.groupBox1.Location = new System.Drawing.Point(20, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление студента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Пол";
            // 
            // SexSelect
            // 
            this.SexSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SexSelect.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.SexSelect.Location = new System.Drawing.Point(451, 106);
            this.SexSelect.Name = "SexSelect";
            this.SexSelect.Size = new System.Drawing.Size(285, 27);
            this.SexSelect.TabIndex = 8;
            // 
            // SuccessStudentLabel
            // 
            this.SuccessStudentLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SuccessStudentLabel.Location = new System.Drawing.Point(13, 216);
            this.SuccessStudentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SuccessStudentLabel.Name = "SuccessStudentLabel";
            this.SuccessStudentLabel.Size = new System.Drawing.Size(724, 34);
            this.SuccessStudentLabel.TabIndex = 5;
            this.SuccessStudentLabel.Text = "Студент успешно добавлен (уже {0} студентов в базе)";
            this.SuccessStudentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SuccessStudentLabel.Visible = false;
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Enabled = false;
            this.AddStudentButton.Location = new System.Drawing.Point(18, 149);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(718, 64);
            this.AddStudentButton.TabIndex = 7;
            this.AddStudentButton.Text = "Добавить";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // PreferredUns
            // 
            this.PreferredUns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PreferredUns.Items.AddRange(new object[] {
            "Нет предпочтений ВУЗа",
            "МГУ",
            "СПбГУ",
            "НГУ",
            "СФУ"});
            this.PreferredUns.Location = new System.Drawing.Point(452, 35);
            this.PreferredUns.Name = "PreferredUns";
            this.PreferredUns.Size = new System.Drawing.Size(285, 27);
            this.PreferredUns.TabIndex = 6;
            // 
            // TestITField
            // 
            this.TestITField.Location = new System.Drawing.Point(235, 107);
            this.TestITField.Name = "TestITField";
            this.TestITField.Size = new System.Drawing.Size(211, 26);
            this.TestITField.TabIndex = 5;
            this.TestITField.Text = "ЕГЭ. Информатика";
            this.TestITField.Enter += new System.EventHandler(this.TestITField_Enter);
            this.TestITField.Leave += new System.EventHandler(this.TestITField_Leave);
            // 
            // TestRussianField
            // 
            this.TestRussianField.Location = new System.Drawing.Point(235, 71);
            this.TestRussianField.Name = "TestRussianField";
            this.TestRussianField.Size = new System.Drawing.Size(211, 26);
            this.TestRussianField.TabIndex = 4;
            this.TestRussianField.Text = "ЕГЭ. Русский";
            this.TestRussianField.Enter += new System.EventHandler(this.TestRussianField_Enter);
            this.TestRussianField.Leave += new System.EventHandler(this.TestRussianField_Leave);
            // 
            // TestMathField
            // 
            this.TestMathField.Location = new System.Drawing.Point(235, 35);
            this.TestMathField.Name = "TestMathField";
            this.TestMathField.Size = new System.Drawing.Size(211, 26);
            this.TestMathField.TabIndex = 3;
            this.TestMathField.Text = "ЕГЭ. Математика";
            this.TestMathField.Enter += new System.EventHandler(this.TestMathField_Enter);
            this.TestMathField.Leave += new System.EventHandler(this.TestMathField_Leave);
            // 
            // StudentSecNameField
            // 
            this.StudentSecNameField.Location = new System.Drawing.Point(18, 107);
            this.StudentSecNameField.Name = "StudentSecNameField";
            this.StudentSecNameField.Size = new System.Drawing.Size(211, 26);
            this.StudentSecNameField.TabIndex = 2;
            this.StudentSecNameField.Text = "Отчество";
            this.StudentSecNameField.Enter += new System.EventHandler(this.StudentSecNameField_Enter);
            this.StudentSecNameField.Leave += new System.EventHandler(this.StudentSecNameField_Leave);
            // 
            // StudentNameField
            // 
            this.StudentNameField.Location = new System.Drawing.Point(18, 71);
            this.StudentNameField.Name = "StudentNameField";
            this.StudentNameField.Size = new System.Drawing.Size(211, 26);
            this.StudentNameField.TabIndex = 1;
            this.StudentNameField.Text = "Имя";
            this.StudentNameField.Enter += new System.EventHandler(this.StudentNameField_Enter);
            this.StudentNameField.Leave += new System.EventHandler(this.StudentNameField_Leave);
            // 
            // StudentSurnameField
            // 
            this.StudentSurnameField.Location = new System.Drawing.Point(18, 35);
            this.StudentSurnameField.Name = "StudentSurnameField";
            this.StudentSurnameField.Size = new System.Drawing.Size(211, 26);
            this.StudentSurnameField.TabIndex = 0;
            this.StudentSurnameField.Text = "Фамилия";
            this.StudentSurnameField.Enter += new System.EventHandler(this.StudentSurnameField_Enter);
            this.StudentSurnameField.Leave += new System.EventHandler(this.StudentSurnameField_Leave);
            // 
            // StudentSortButton
            // 
            this.StudentSortButton.Enabled = false;
            this.StudentSortButton.Location = new System.Drawing.Point(20, 481);
            this.StudentSortButton.Name = "StudentSortButton";
            this.StudentSortButton.Size = new System.Drawing.Size(755, 75);
            this.StudentSortButton.TabIndex = 5;
            this.StudentSortButton.Text = "Распределить";
            this.StudentSortButton.UseVisualStyleBackColor = true;
            this.StudentSortButton.Click += new System.EventHandler(this.StudentSortButton_Click);
            // 
            // OpenStudentList
            // 
            this.OpenStudentList.Filter = "CSV files (*.csv)|*.csv";
            this.OpenStudentList.InitialDirectory = "c:\\";
            this.OpenStudentList.RestoreDirectory = true;
            this.OpenStudentList.Title = "Открыть файл .csv со списком студентов";
            // 
            // UploadListButton
            // 
            this.UploadListButton.Location = new System.Drawing.Point(501, 120);
            this.UploadListButton.Name = "UploadListButton";
            this.UploadListButton.Size = new System.Drawing.Size(255, 30);
            this.UploadListButton.TabIndex = 6;
            this.UploadListButton.Text = "Загрузить в базу";
            this.UploadListButton.UseVisualStyleBackColor = true;
            this.UploadListButton.Visible = false;
            this.UploadListButton.Click += new System.EventHandler(this.UploadListButton_Click);
            // 
            // SuccessListLabel
            // 
            this.SuccessListLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SuccessListLabel.Location = new System.Drawing.Point(501, 160);
            this.SuccessListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SuccessListLabel.Name = "SuccessListLabel";
            this.SuccessListLabel.Size = new System.Drawing.Size(256, 34);
            this.SuccessListLabel.TabIndex = 10;
            this.SuccessListLabel.Text = "Список добавлен";
            this.SuccessListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SuccessListLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 568);
            this.Controls.Add(this.SuccessListLabel);
            this.Controls.Add(this.UploadListButton);
            this.Controls.Add(this.StudentSortButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.SelectFileField);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Распределение студентов по ВУЗам";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SelectFileField;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox StudentSecNameField;
        private System.Windows.Forms.TextBox StudentNameField;
        private System.Windows.Forms.TextBox StudentSurnameField;
        private System.Windows.Forms.TextBox TestITField;
        private System.Windows.Forms.TextBox TestRussianField;
        private System.Windows.Forms.TextBox TestMathField;
        private System.Windows.Forms.ComboBox PreferredUns;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Label SuccessStudentLabel;
        private System.Windows.Forms.Button StudentSortButton;
        private System.Windows.Forms.OpenFileDialog OpenStudentList;
        private System.Windows.Forms.Button UploadListButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SexSelect;
        private System.Windows.Forms.Label SuccessListLabel;

    }
}

