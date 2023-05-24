

using System;
using System.Collections.Generic;

namespace UnitTestsExample.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();
                ret.firstName = firstName;
                ret.lastName = lastName;

            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { firstName = "Mateus", lastName = "Leandro" });
            people.Add(new Person() { firstName = "Antonio", lastName = "Rafael" });
            people.Add(new Person() { firstName = "José", lastName = "Maria" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Mateus", "Leandro", true));
            people.Add(CreatePerson("Antonio", "Rafael", true));

            return people;
        }
    }
}
