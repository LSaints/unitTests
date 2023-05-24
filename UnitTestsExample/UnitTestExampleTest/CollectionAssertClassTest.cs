using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestsExample.PersonClasses;

namespace UnitTestExampleTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("MateusL")]
        public void AreCollectionEqualsWithComparerTest()
        {
            PersonManager manager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { firstName = "Mateus", lastName = "Leandro"});
            peopleExpected.Add(new Person() { firstName = "Antonio", lastName = "Rafael"});
            peopleExpected.Add(new Person() { firstName = "José", lastName = "Maria"});

            peopleActual = manager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, 
                Comparer<Person>.Create((x, y)=> 
                x.firstName == y.firstName && x.lastName == y.lastName ? 0 : 1));
        }
        
        [TestMethod]
        [Owner("MateusL")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager manager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = manager.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("MateusL")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager manager = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = manager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }


    }
}
