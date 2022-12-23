using GildedRose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestGildedRose
{
    [TestClass]
    public class DateTimeHandlerTest
    {
        [TestMethod]
        public void TestShouldConvertStringDateToDateTimeDate()
        {
            DateTime actual = DateTimeHandler.ConvertStringToDateTime("31/03/2017");
            DateTime expected = DateTime.Parse("31/03/2017");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertToString()
        {
            DateTime qwe = DateTime.Parse("31/03/2017");
            var actual = DateTimeHandler.ConvertDateTimeToString(qwe);
            var expected = "31/03/2017";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChekIsGreater()
        {
            var actual = DateTimeHandler.CheckDateIfGreaterThanOtherDate("20/11/2017", "10/11/2017");
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChekIsLess()
        {
            var actual = DateTimeHandler.CheckDateIfGreaterThanOtherDate("10/11/2017", "20/11/2017");
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddDays()
        {
            var actual = DateTimeHandler.AddDays("10/11/2017", 5);
            var expected = "15/11/2017";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubtractDays()
        {
            var actual = DateTimeHandler.SubtractDays("10/11/2017", 5);
            var expected = "05/11/2017";
            Assert.AreEqual(expected, actual);
        }
    }
}
