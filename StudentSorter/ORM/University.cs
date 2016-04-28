using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.Linq.Mapping;
using System;

namespace StudentSorter.ORM
{
    [Table(Name = "university")]
    class University : ORMBase
    {
        [Column(Name = "id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "min_rus")]
        public int MinRussian { get; set; }

        [Column(Name = "min_math")]
        public int MinMath { get; set; }

        [Column(Name = "min_it")]
        public int MinIT { get; set; }

        [Column(Name = "rating")]
        public int Rating { get; set; }

        [Column(Name = "quota")]
        public int Quota { get; set; }

        [Column(Name = "preferred_subject_first")]
        public string PreferredSubjectFirst { get; set; }

        [Column(Name = "preferred_subject_second")]
        public string PreferredSubjectSecond { get; set; }

        public static int? GetUniversityIdByName(University[] list, string name)
        {
            foreach (University university in list)
            {
                if (university.Name == name)
                    return university.Id;
            }

            if (name == "нет")
                return null;

            throw new Exception("No university with name " + name + " is found");
        }
    }
}

