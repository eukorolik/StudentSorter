using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.Linq;
using System.Data.Linq.Mapping;
using System;

namespace StudentSorter.ORM
{
    enum Sex : byte
    {
        MALE,
        FEMALE
    }

    [Table(Name = "student")]
    class Student : ORMBase
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "surname")]
        public string Surname { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "sec_name")]
        public string SecName { get; set; }

        [Column(Name = "sex")]
        public Sex Sex { get; set; }

        [Column(Name = "preferred_uns")]
        public int? PreferredUns { get; set; }

        [Column(Name = "test_russian")]
        public int TestRussian { get; set; }

        [Column(Name = "test_math")]
        public int TestMath { get; set; }

        [Column(Name = "test_it")]
        public int TestIT { get; set; }

        [Column(Name = "result_uns")]
        public int? ResultUns { get; set; }

        public static Sex GetSexByName(string name)
        {
            switch (name)
            {
                case "м":
                    return Sex.MALE;
                default:
                    return Sex.FEMALE;
            }
        }

        public static Sex GetSexById(int id)
        {
            switch (id)
            {
                case 0:
                    return Sex.MALE;
                default:
                    return Sex.FEMALE;
            }
        }

        public int GetUnPreferredSubject(string subject)
        {
            switch (subject)
            {
                case "Русский":
                    return TestRussian;
                case "Математика":
                    return TestMath;
                default:
                    return TestIT;
            }
        }

        public bool DesireUniversity(University university)
        {
            if (!PreferredUns.HasValue)
                return true;

            return university.Id == PreferredUns;
        }
    }
}