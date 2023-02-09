





using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest : TestBase
    {
        [TestMethod]
        public void AreCollectionsNotEqual()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleActual = new List<Person>();

            List<Person> peopleExpected = new List<Person>()
            {
                new Person(){FirstName = "Paul", LastName = "Sheriff"},
                new Person(){FirstName = "John", LastName = "Kuhn"},
                new Person(){FirstName = "Jim", LastName = "Ruhl"},
            };

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreNotEqual(peopleActual, peopleExpected);
        }

        [TestMethod]
        public void AreCollectionsEqual()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();

            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            CollectionAssert.AreEqual(peopleActual, peopleExpected);
        }

        [TestMethod]
        public void AreCollectionsEqualWithComparer()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();

            List<Person> peopleActual;

            peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            peopleExpected.Add(new Person() { FirstName = "John", LastName = "Kuhn" });
            peopleExpected.Add(new Person() { FirstName = "Jim", LastName = "Ruhl" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x, y) =>
                x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        public void IsCollectionOfTypeSupervisor()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

        [TestMethod]
        public void IsCollectionOfTypePerson()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Person));
        }

        [TestMethod]
        public void IsAllItemsAreNotNull()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreNotNull(peopleActual);
        }

        [TestMethod]
        public void IsAllItemsAreUnique()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreUnique(peopleActual);
        }

        [TestMethod]
        public void AreCollectionsEquivalentTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual;

            peopleActual = mgr.GetSupervisors();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }
    }
}

