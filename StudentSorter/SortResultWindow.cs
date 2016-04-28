using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSorter.ORM;

namespace StudentSorter
{
    partial class SortResultWindow : Form
    {
        StudentBaseController DBController;
        Student[] StudentList;
        UniversityCollection UniversityList;

        public SortResultWindow(StudentBaseController controller)
        {
            InitializeComponent();

            DBController = controller;
            StudentList = DBController.GetStudentList();
            UniversityList = DBController.GetUniversityList();
            ResultLabel.Text = GetResults();
        }

        protected string GetResults()
        {
            var result = "";

            foreach (var university in UniversityList)
            {
                result += university.Name + ":" + Environment.NewLine;

                var i = 1;
                foreach (var student in StudentList)
                {
                    if (student.ResultUns != university.Id)
                        continue;

                    result += string.Format("{0}. {1} {2} {3} {4}", i, student.Surname, student.Name, student.SecName, Environment.NewLine);
                    i++;
                }
                result += Environment.NewLine + Environment.NewLine;
            }

            return result;
        }
    }
}
