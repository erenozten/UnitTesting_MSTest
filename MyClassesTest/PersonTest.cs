using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class PersonTest : TestBase
    {
        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsInstanceOfTypeSupervisor()
        {
            PersonManager mgr = new PersonManager();

            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsInstanceOfTypePerson()
        {
            PersonManager mgr = new PersonManager();

            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsInstanceOfType(per, typeof(Person));
        }

        [TestMethod]
        public void IsNotInstanceOfTypeEmployee()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Paul", "Sheriff", true);

            Assert.IsNotInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Sheriff", true);

            Assert.IsNull(per);
        }
    }
}
