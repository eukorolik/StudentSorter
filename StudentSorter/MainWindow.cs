using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using StudentSorter.ORM;

namespace StudentSorter
{
    public partial class MainWindow : Form
    {
        delegate bool Validator(char letter); // Определяем тип лямбды
        delegate bool ValidatorBounds(string number);

        const string StringValidator = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЭЮЯ";

        string StudentSurnameFieldPlaceholder;
        string StudentNameFieldPlaceholder;
        string StudentSecNameFieldPlaceholder;
        string TestRussianFieldPlaceholder;
        string TestMathFieldPlaceholder;
        string TestITFieldPlaceholder;

        string SuccessStudentLabelPlaceholder;

        StudentBaseController DBController;
        Sorter Sorter;
        //IEnumerable<University> UniversityList;

        public MainWindow()
        {
            InitializeComponent();

            PreferredUns.SelectedIndex = 0;
            SexSelect.SelectedIndex = 0;
            DBController = new StudentBaseController();
            Sorter = new Sorter(DBController);
            ShowSortingButtonIfPossible();

            StudentSurnameFieldPlaceholder = StudentSurnameField.Text;
            StudentNameFieldPlaceholder = StudentNameField.Text;
            StudentSecNameFieldPlaceholder = StudentSecNameField.Text;
            TestRussianFieldPlaceholder = TestRussianField.Text;
            TestMathFieldPlaceholder = TestMathField.Text;
            TestITFieldPlaceholder = TestITField.Text;

            SuccessStudentLabelPlaceholder = SuccessStudentLabel.Text;
        }

        private void ValidateStudentForm()
        {
            if (IsAllFieldsFilled() && IsAllDataValid())
                AddStudentButton.Enabled = true;
            else
                AddStudentButton.Enabled = false;
        }

        private bool IsAllDataValid()
        {
            int outnum = 0;

            Validator testString = (char letter) => StringValidator.Contains(letter);
            Validator testNumber = (char letter) => Int32.TryParse(letter.ToString(), out outnum);
            ValidatorBounds testBounds = (string number) =>
            {
                if (!Int32.TryParse(number, out outnum))
                    return false;

                return outnum >= 0 && outnum <= 100;
            };

            return IsDataValid(StudentSurnameField.Text, testString)
                && IsDataValid(StudentNameField.Text, testString)
                && IsDataValid(StudentSecNameField.Text, testString)
                && IsDataValid(TestRussianField.Text, testNumber)
                && IsDataValid(TestMathField.Text, testNumber)
                && IsDataValid(TestITField.Text, testNumber)
                && testBounds(TestRussianField.Text)
                && testBounds(TestMathField.Text)
                && testBounds(TestITField.Text);
        }

        private bool IsDataValid(string data, Validator action)
        {
            foreach (char letter in data)
            {
                if (!action(letter))
                    return false;
            }

            return true;
        }

        private bool IsAllFieldsFilled()
        {
            return StudentSurnameFieldPlaceholder != StudentSurnameField.Text
                && StudentNameFieldPlaceholder != StudentNameField.Text
                && StudentSecNameFieldPlaceholder != StudentSecNameField.Text
                && TestRussianFieldPlaceholder != TestRussianField.Text
                && TestMathFieldPlaceholder != TestMathField.Text
                && TestITFieldPlaceholder != TestITField.Text;
        }

        private void StudentSurnameField_Enter(object sender, EventArgs e)
        {
            if (StudentSurnameField.Text == StudentSurnameFieldPlaceholder)
                StudentSurnameField.Text = "";
        }

        private void StudentSurnameField_Leave(object sender, EventArgs e)
        {
            if (StudentSurnameField.Text == "")
                StudentSurnameField.Text = StudentSurnameFieldPlaceholder;

            ValidateStudentForm();
        }

        private void StudentNameField_Enter(object sender, EventArgs e)
        {
            if (StudentNameField.Text == StudentNameFieldPlaceholder)
                StudentNameField.Text = "";
        }

        private void StudentNameField_Leave(object sender, EventArgs e)
        {
            if (StudentNameField.Text == "")
                StudentNameField.Text = StudentNameFieldPlaceholder;

            ValidateStudentForm();
        }

        private void StudentSecNameField_Enter(object sender, EventArgs e)
        {
            if (StudentSecNameField.Text == StudentSecNameFieldPlaceholder)
                StudentSecNameField.Text = "";
        }

        private void StudentSecNameField_Leave(object sender, EventArgs e)
        {
            if (StudentSecNameField.Text == "")
                StudentSecNameField.Text = StudentSecNameFieldPlaceholder;

            ValidateStudentForm();
        }

        private void TestMathField_Enter(object sender, EventArgs e)
        {
            if (TestMathField.Text == TestMathFieldPlaceholder)
                TestMathField.Text = "";
        }

        private void TestMathField_Leave(object sender, EventArgs e)
        {
            if (TestMathField.Text == "")
                TestMathField.Text = TestMathFieldPlaceholder;

            ValidateStudentForm();
        }

        private void TestRussianField_Enter(object sender, EventArgs e)
        {
            if (TestRussianField.Text == TestRussianFieldPlaceholder)
                TestRussianField.Text = "";
        }

        private void TestRussianField_Leave(object sender, EventArgs e)
        {
            if (TestRussianField.Text == "")
                TestRussianField.Text = TestRussianFieldPlaceholder;

            ValidateStudentForm();
        }

        private void TestITField_Enter(object sender, EventArgs e)
        {
            if (TestITField.Text == TestITFieldPlaceholder)
                TestITField.Text = "";
        }

        private void TestITField_Leave(object sender, EventArgs e)
        {
            if (TestITField.Text == "")
                TestITField.Text = TestITFieldPlaceholder;

            ValidateStudentForm();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (OpenStudentList.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (OpenStudentList.FileName != "")
                    {
                        SelectFileField.Text = OpenStudentList.FileName;
                        UploadListButton.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void UploadListButton_Click(object sender, EventArgs e)
        {
            try
            {
                var parser = new TextFieldParser(SelectFileField.Text);

                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var transaction = DBController.StartTransaction();

                while (!parser.EndOfData)
                {
                    var outnum = 0;

                    string[] fields = parser.ReadFields();

                    if (!Int32.TryParse(fields[5], out outnum))
                        continue;

                    DBController.CreateStudent(fields);
                }

                DBController.EndTransaction(transaction);
                parser.Close();

                SuccessListLabel.Show();

                var timer = new System.Threading.Timer(
                    (state) => ((Label)state).Invoke((Action)(() => SuccessListLabel.Hide())),
                    SuccessListLabel,
                    2000,
                    System.Threading.Timeout.Infinite
                );

                ShowSortingButtonIfPossible();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            DBController.CreateStudent(new string[8] {
                StudentSurnameField.Text,
                StudentNameField.Text,
                StudentSecNameField.Text,
                SexSelect.SelectedIndex.ToString(),
                PreferredUns.SelectedIndex.ToString(),
                TestRussianField.Text,
                TestMathField.Text,
                TestITField.Text
            });

            SuccessStudentLabel.Text = string.Format(SuccessStudentLabelPlaceholder, DBController.GetStudentCount());
            SuccessStudentLabel.Show();

            var timer = new System.Threading.Timer(
                (state) => ((Label)state).Invoke((Action)(() => SuccessStudentLabel.Hide())),
                SuccessStudentLabel,
                2000,
                System.Threading.Timeout.Infinite
            );

            ClearStudentAddForm();

            ShowSortingButtonIfPossible();
        }

        protected void ClearStudentAddForm()
        {
            StudentSurnameField.Text = StudentSurnameFieldPlaceholder;
            StudentNameField.Text = StudentNameFieldPlaceholder;
            StudentSecNameField.Text = StudentSecNameFieldPlaceholder;
            TestRussianField.Text = TestRussianFieldPlaceholder;
            TestMathField.Text = TestMathFieldPlaceholder;
            TestITField.Text = TestITFieldPlaceholder;
        }

        private void StudentSortButton_Click(object sender, EventArgs e)
        {
            foreach (var university in DBController.GetUniversityList())
            {
                Sorter.Run(university);
            }

            DBController.RememberStudents();

            var result = new SortResultWindow(DBController);
            result.Show();
        }

        // Показываем нашу кнопку "Распределить", если у нас в БД есть студенты
        protected void ShowSortingButtonIfPossible()
        {
            if (DBController.GetStudentList(true).Length == 0)
                return;

            StudentSortButton.Enabled = true;
        }
    }
}
