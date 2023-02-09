









using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Data;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessDataDriven : TestBase
    {
        [TestMethod]
        public void FileExistsTestFromDB()
        {
            FileProcess fp = new FileProcess();
            bool fromCall = false;
            bool testFailed = false;
            string fileName;
            bool expectedValue;
            bool causesException;

            string sql = "SELECT * FROM tests.FileProcessTest";
            string conn = TestContext.Properties["ConnectionString"].ToString();

            LoadDataTable(sql, conn);

            if (TestDataTable != null)
            {
                foreach (DataRow row in TestDataTable.Rows)
                {
                    fileName = row["FileName"].ToString();
                    expectedValue = Convert.ToBoolean(row["ExpectedValue"]);
                    causesException = Convert.ToBoolean(row["CausesException"]);

                    try
                    {
                        fromCall = fp.FileExists(fileName);
                    }
                    catch (ArgumentNullException)
                    {
                        if (!causesException)
                        {
                            testFailed = true;
                        }
                    }
                    catch (Exception)
                    {
                        testFailed = true;
                    }

                    TestContext.WriteLine("Testing File: '{0}', Expected Value: '{1}', Actual Value: '{2}', Result: '{3}'", fileName, expectedValue, fromCall, (expectedValue == fromCall ? "Success" : "FAILED"));

                    if (expectedValue != fromCall)
                    {
                        testFailed = true;
                    }
                }

                if (testFailed)
                {
                    Assert.Fail("Data Driven Tests Have Failed, Check Additional Output");
                }
            }
        }
    }
}
