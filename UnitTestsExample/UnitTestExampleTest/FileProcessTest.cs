﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using UnitTestsExample;

namespace UnitTestExampleTest
{
    [TestClass]
    public class FileProcessTest
    {

        private const string BAD_FILE_NAME = @"C:\Windows\regedit1.exe";
        private string _GoodFileName;
        public TestContext TestContext { get; set; } 

        #region Test Initialize e Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName == "FileNameDoesExists")
            {
                setGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName)) 
                {
                    TestContext.WriteLine($"Creating file: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup() 
        {
            if(TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting file: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        public void setGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Checking file: {fileName}");
            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file exists")]
        [Owner("LSaints")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file NOT exists")]
        [Owner("LSaints")]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists() 
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("LSaints")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
        
        [TestMethod]
        [Owner("LSaints")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch(ArgumentException)
            {
                // teste teve sucesso.
                return;
            }
            
            Assert.Fail("Falha esperada");

        }

    }
}
