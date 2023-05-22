using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsExample.PersonClasses;

namespace UnitTestExampleTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region IsInstanceOfType Tests
        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            PersonManager manager = new PersonManager();
            Person person;

            person = manager.CreatePerson("Mateus", "Leandro", true);
            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonManager manager = new PersonManager();
            Person person;

            person = manager.CreatePerson("", "leandro", true);
            Assert.IsNull(person);
        }
        #endregion

    }
}
