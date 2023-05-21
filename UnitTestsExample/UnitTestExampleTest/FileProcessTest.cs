using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTestsExample;

namespace UnitTestExampleTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\regedit.exe");
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExists() 
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Windows\regedit1.exe");
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

    }
}
