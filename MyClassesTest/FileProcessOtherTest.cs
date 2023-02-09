using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        //[TestMethod]
        //public void FileNameDoesExistSimpleMessage()
        //{
        //    FileProcess fp = new();
        //    bool fromCall;
        //    fromCall = fp.FileExists(_GoodFileName);

        //    Assert.IsFalse(fromCall,
        //        "File " + _GoodFileName + " Does Not Exist!");

        //}


        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("** In ClassInitialize() method");
        }

        [ClassCleanup()]
        public static void ClassCleanUp()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");

            WriteDescription(this.GetType());

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating file: " + _GoodFileName);

                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In TestCleanup() method");

            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (File.Exists(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting file: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreEqualTestWithBooleanParameter()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        public void AreNotEqualTestWithLowerCase()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new();
            FileProcess y = new();

            Assert.AreNotSame(x, y);
        }

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }
    }
}
