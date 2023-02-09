using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    public class StringAssertClassTest : TestBase
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Steve Nystrom";
            string str2 = "Nystrom";
        
            StringAssert.Contains(str1, str2);
        }
    }
}
