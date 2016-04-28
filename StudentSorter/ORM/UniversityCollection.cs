using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSorter.ORM
{
    class UniversityCollection : IEnumerable<University>, IEnumerable
    {
        University[] Data;

        public UniversityCollection(University[] list)
        {
            Data = list;
        }

        public University this[int id]
        {
            protected set { }
            get
            {
                foreach (var university in Data)
                {
                    if (university.Id == id)
                        return university;
                }
                throw new Exception(string.Format("No university with ID = {0} exist in collection", id));
            }
        }

        public int? GetIdByName(string name)
        {
            foreach (var university in Data)
            {
                if (university.Name == name)
                    return university.Id;
            }

            if (name == "нет")
                return null;

            throw new Exception("No university with name " + name + " is found");
        }

        public string GetNameById(int? id)
        {
            foreach (var university in Data)
            {
                if (id.HasValue && university.Id == id.GetValueOrDefault())
                    return university.Name;
                else if (!id.HasValue)
                    return "No preferences";
            }

            throw new Exception("No university with id " + id.GetValueOrDefault() + " is found");
        }

        public bool IsBelowInRating(int preferred, int current)
        {
            return this[current].Rating < this[preferred].Rating;
        }

        public IEnumerator<University> GetEnumerator()
        {
            return ((IEnumerable<University>)Data).GetEnumerator();
        }

        IEnumerator<University> IEnumerable<University>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}