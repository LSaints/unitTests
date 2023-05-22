using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.RegularExpressions;

namespace UnitTestExampleTest
{
    [TestClass]
    public class StringAssertTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Mateus Leandro";
            string str2 = "Leandro";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartWithTest()
        {
            string str1 = "Todos caixa alta";
            string str2 = "Todos caixa";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa", reg);
        }

        [TestMethod]
        public void IsNotLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos Caixa", reg);
        }
    }
}
