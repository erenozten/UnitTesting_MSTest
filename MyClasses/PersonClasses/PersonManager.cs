






using System.Collections.Generic;
using System.Threading;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>()
            {
                new Person(){FirstName = "Paul", LastName = "Sheriff"},
                new Person(){FirstName = "John", LastName = "Kuhn"},
                new Person(){FirstName = "Jim", LastName = "Ruhl"}
            };

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>
            {
                CreatePerson("Paul", "Sheriff", true),
                CreatePerson("Michael", "Krasowski", true),
                CreatePerson("Don", "Juan", true)
            };

            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>
            {
                CreatePerson("Steve", "Nystrom", false),
                CreatePerson("John", "Kuhn", false),
                CreatePerson("Jim", "Ruhl", false)
            };

            return people;
        }

        public List<Person> GetSupervisorsAndEmployees()
        {
            List<Person> people = new List<Person>();

            people.AddRange(GetEmployees());
            people.AddRange(GetSupervisors());

            return people;
        }
    }
}






