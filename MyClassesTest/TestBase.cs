using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        protected string _GoodFileName;

        public DataTable TestDataTable { get; set; }

        public DataTable LoadDataTable(string sql, string connection)
        {
            TestDataTable = null;

            try
            {
                using (SqlConnection ConnectionObject = new SqlConnection(connection))
                {
                    using (SqlCommand CommandObject = new SqlCommand(sql, ConnectionObject))
                    {
                        using(SqlDataAdapter da = new SqlDataAdapter(CommandObject))
                        {
                            TestDataTable = new DataTable();
                            da.Fill(TestDataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Error in LoadDataTable() method. ");
                throw;
            }

            return TestDataTable;
        }

        protected void SetGoodFileName()
        {
            _GoodFileName = TestContext.Properties["GoodFileName"].ToString();

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        protected void WriteDescription(Type type)
        {
            string testName = TestContext.TestName;

            MemberInfo method = type.GetMethod(testName);
            if (method != null)
            {
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;

                    TestContext.WriteLine("Test Description: " + dattr.Description);
                }
            }
        }
    }
}
