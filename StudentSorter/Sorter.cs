using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSorter.ORM;

namespace StudentSorter
{
    class Sorter
    {
        public bool IsLogActive = true;

        StudentBaseController DBController; 
        University CurrentUniversity; 
        Student[] StudentList; 
        List<int> Throwed;
        List<int> Selected;
        List<int> SelectedInAllUniversities;

        public Sorter(StudentBaseController controller)
        {
            DBController = controller;
            Throwed = new List<int>();
            Selected = new List<int>();
            SelectedInAllUniversities = new List<int>();
        }

        
        public void Run(University university)
        {
            if (StudentList == null)
                StudentList = DBController.GetStudentList();

            CurrentUniversity = university;
            ThrowOut();
            CompleteQuota();
            ApplySelection();
            Clear();
        }

        protected void ThrowOut()
        {
            for (var i = 0; i < StudentList.Length; i++)
            {
                if (StudentList[i].TestRussian < CurrentUniversity.MinRussian
                    || StudentList[i].TestMath < CurrentUniversity.MinMath
                    || StudentList[i].TestIT < CurrentUniversity.MinIT)
                {
                    Log(string.Format("Студент №{0} {1} {2} отвергнут ВУЗом {3}", StudentList[i].Id, StudentList[i].Surname, StudentList[i].Name, CurrentUniversity.Name));
                    Throwed.Add(i);
                }
            }
        }

        protected void CompleteQuota()
        {
            var firstPrefSubj = CurrentUniversity.PreferredSubjectFirst;
            var secondPrefSubj = CurrentUniversity.PreferredSubjectSecond;

          
            for (var i = 0; i < CurrentUniversity.Quota; i++)
            {
                Student maxStudent = null;
                int maxKey = 0;

                for (var j = 0; j < StudentList.Length; j++)
                {
                    if (
                        Selected.Contains(j)
                        || SelectedInAllUniversities.Contains(j)
                        || Throwed.Contains(j)
                        || (
                            !StudentList[j].DesireUniversity(CurrentUniversity)
                            && !DBController.GetUniversityList().IsBelowInRating(
                                CurrentUniversity.Id,
                                StudentList[j].PreferredUns.GetValueOrDefault()
                            )
                        )
                    )
                    {
                        continue;
                    }

                    if (maxStudent == null)
                    {
                        maxStudent = StudentList[j];
                        maxKey = j;
                        continue;
                    }

                    var maxMark = maxStudent.GetUnPreferredSubject(firstPrefSubj)
                        + (secondPrefSubj != null ? maxStudent.GetUnPreferredSubject(secondPrefSubj) : 0);

                    
                    var studentMark = StudentList[j].GetUnPreferredSubject(firstPrefSubj)
                        + (secondPrefSubj != null ? StudentList[j].GetUnPreferredSubject(secondPrefSubj) : 0);

                    
                    if (maxMark < studentMark)
                    {
                        maxStudent = StudentList[j];

                        maxKey = j;
                    }
                   
                    else if (maxMark == studentMark)
                    {
                        Log(string.Format("Одинаковые результаты в ВУЗ {6} на место {7}! Выбираем по полу: студент {0} {1}, {4} и {2} {3}, {5}", maxStudent.Surname, maxStudent.Name, StudentList[j].Surname, StudentList[j].Name, maxMark, studentMark, CurrentUniversity.Name, i));

                        if (maxStudent.Sex == Sex.MALE && StudentList[j].Sex == Sex.FEMALE)
                        {
                            maxStudent = StudentList[j];
                            maxKey = j;
                        }

                        Log(string.Format("Выбран(а) {0} {1}", maxStudent.Surname, maxStudent.Name));
                    }
                }

                if (maxStudent != null)
                {
                    Log(string.Format("Студент №{0} {1} {2}, выбран(а) ВУЗом {3}, место №{4}, баллы: рус - {5}, мат - {6}, инф - {7}, хотел(а) в ВУЗ {8}", maxStudent.Id, maxStudent.Surname, maxStudent.Name, CurrentUniversity.Name, i, maxStudent.TestRussian, maxStudent.TestMath, maxStudent.TestIT, DBController.GetUniversityList().GetNameById(maxStudent.PreferredUns)));
                    maxStudent.PreferredUns = CurrentUniversity.Id;
                    Selected.Add(maxKey);
                }
            }

            SelectedInAllUniversities = SelectedInAllUniversities.Concat(Selected).ToList<int>();
        }

       
        protected void ApplySelection()
        {
            foreach (var id in Selected)
            {
                StudentList[id].ResultUns = CurrentUniversity.Id;
            }
        }

        protected void Clear()
        {
            Throwed.Clear();
            Selected.Clear();
        }

        protected void Log(string logging)
        {
            if (IsLogActive)
                Console.WriteLine(logging);
        }
    }
}