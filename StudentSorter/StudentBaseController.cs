using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.Linq;
using System.Data;
using System.Data.Linq;
using System.IO;
using StudentSorter.ORM;

namespace StudentSorter
{
    class StudentBaseController
    {
        const string DBFile = "db.db3";
        SQLiteConnection Connection;
        DataContext Context;
        UniversityCollection UniversityList;
        Student[] StudentList;

        public StudentBaseController()
        {
            var isNewDB = false;

            if (!File.Exists(DBFile))
            {
                SQLiteConnection.CreateFile(DBFile);
                isNewDB = true;
            }

            Connection = new SQLiteConnection("Data Source=" + DBFile + "; Version=3;");
            Connection.Open();
            Context = new DataContext(Connection);

            if (!isNewDB)
                return;

            string createStudentTableSQL =
                "CREATE TABLE student"
                + "("
                    + "id integer primary key autoincrement,"
                    + "surname varchar(255) not null,"
                    + "name varchar(255) not null,"
                    + "sec_name varchar(255) not null,"
                    + "sex tinyint(1) not null,"
                    + "preferred_uns int(11),"
                    + "test_russian int(11) not null,"
                    + "test_math int(11) not null,"
                    + "test_it int(11) not null,"
                    + "result_uns int(11)"
                + ")";

            string createUniversityTableSQL =
                "CREATE TABLE university"
                + "("
                    + "id integer primary key autoincrement,"
                    + "name varchar(255) not null,"
                    + "min_rus int(11) not null,"
                    + "min_math int(11) not null,"
                    + "min_it int(11) not null,"
                    + "rating int(11) not null,"
                    + "quota int(11) not null,"
                    + "preferred_subject_first varchar(255) not null,"
                    + "preferred_subject_second varchar(255)"
                + ");"

                + "INSERT INTO `university` VALUES (1,'МГУ',50,60,60,1,10,'Информатика','Математика');"
                + "INSERT INTO `university` VALUES (2,'СПбГУ',50,60,60,2,12,'Информатика','Математика');"
                + "INSERT INTO `university` VALUES (3,'НГУ',40,40,40,3,15,'Информатика',null);"
                + "INSERT INTO `university` VALUES (4,'СФУ',30,40,40,4,18,'Информатика',null);"
                + "INSERT INTO `university` VALUES (5,'КГПУ',30,30,40,5,20,'Информатика',null);"
                + "INSERT INTO `university` VALUES (6,'СибГАУ',30,30,30,6,20,'Информатика',null);";

            var createStudentTable = new SQLiteCommand(Connection); 
            createStudentTable.CommandText = createStudentTableSQL; 
            createStudentTable.ExecuteNonQuery(); 

            var createUniversityTable = new SQLiteCommand(Connection);
            createUniversityTable.CommandText = createUniversityTableSQL;
            createUniversityTable.ExecuteNonQuery();
        }

        public SQLiteTransaction StartTransaction()
        {
            return Connection.BeginTransaction();
        }

        public void EndTransaction(SQLiteTransaction transaction)
        {
            transaction.Commit();
        }

        public void CreateStudent(string[] row)
        {
            var outnum = 0;
            var sex = Int32.TryParse(row[3].Trim(), out outnum) ?
                Student.GetSexById(outnum)
                : Student.GetSexByName(row[3].Trim());

            var preferredUns = Int32.TryParse(row[4].Trim(), out outnum) ?
                outnum
                : GetUniversityList().GetIdByName(row[4].Trim());

            var student = new Student
            {
                Surname = row[0].Trim(),
                Name = row[1].Trim(),
                SecName = row[2].Trim(),
                Sex = sex,
                PreferredUns = preferredUns,
                TestRussian = Int32.Parse(row[5].Trim()),
                TestMath = Int32.Parse(row[6].Trim()),
                TestIT = Int32.Parse(row[7].Trim())
            };

            var command = new SQLiteCommand(Connection); 
            command.CommandText = student.GetInsertQuery(); 
            command.ExecuteNonQuery(); 
        }

        public UniversityCollection GetUniversityList()
        {
            if (UniversityList == null)
            {
                UniversityList = new UniversityCollection(
                    (from c in Context.GetTable<University>()
                     select c).ToArray()
                );

            }

            return UniversityList;
        }

        public Student[] GetStudentList(bool refresh = true)
        {
            if (StudentList == null || refresh)
            {
                StudentList = (from c in Context.GetTable<Student>()
                               select c).ToArray();
            }

            return StudentList;
        }

        public int GetStudentCount()
        {
            return Context.GetTable<Student>().Count();
        }

        public void RememberStudents()
        {
            var transaction = StartTransaction();

            foreach (var student in StudentList)
            {
                var command = new SQLiteCommand(Connection);
                command.CommandText = student.GetUpdateQuery(new[] { "result_uns" });
                command.ExecuteNonQuery();
            }

            EndTransaction(transaction);
        }
    }
}
