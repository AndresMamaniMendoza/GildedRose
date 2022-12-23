using GildedRose;

namespace TestGildedRose
{
    [TestClass]
    public class SystemAppTest
    {
        [TestMethod]
        /* Debe Retornar la calidad del articulo mas 1,
         * cuando la fecha de vencimiento del articulo es menor a la fecha permitida teniendo 1 dia mas de antiguedad.
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldIncreaseQualityX1WhenItemIs1DayOlder()
        {
            Item item = new Item("Aged brie", 10, 30, "10/10/2000", "10/10/2004");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1

            var actual = item.Quality;
            var expected = 31;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        /* Debe Retornar la calidad del articulo mas 5,
         * cuando la fecha de vencimiento del articulo es menor a la fecha permitida teniendo ( 5 ) dias mas de antiguedad.
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldIncreaseQualityX5WhenItemIs5DayOlder()
        {
            Item item = new Item("Aged brie", 10, 30, "10/10/2000", "10/10/2004");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1
            systemApp.UpdateQuality(); //day 2
            systemApp.UpdateQuality(); //day 3
            systemApp.UpdateQuality(); //day 4
            systemApp.UpdateQuality(); //day 5

            var actual = item.Quality;
            var expected = 35;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        /* Debe Retornar la calidad del articulo mas 2,
         * cuando la fecha de vencimiento del articulo es mayor al la fecha permitida con ( 1 ) dia de antiguedad.
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldIncreaseQualityX2WhenExpirationDateIsGreaterThanAllowedDate()
        {
            Item item = new Item("Aged brie", 10, 30, "10/10/2000", "10/10/2007");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1

            var actual = item.Quality;
            var expected = 32;
            Assert.AreEqual(expected, actual);
        }




        [TestMethod]
        /* Debe Retornar la calidad del articulo mas 2,
         * cuando la fecha de vencimiento del articulo es mayor al la fecha permitida con ( 4 ) dias de antiguedad.
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldIncreaseQualityX8WhenExpirationDateIsGreaterThanAllowedDate()
        {
            Item item = new Item("Aged brie", 10, 30, "10/10/2000", "10/10/2007");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1
            systemApp.UpdateQuality(); //day 2
            systemApp.UpdateQuality(); //day 3
            systemApp.UpdateQuality(); //day 4

            var actual = item.Quality;
            var expected = 38;
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        /* Debe Retornar la calidad del articulo,
         * cuando el articulo es mayor a ( 0 ).
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldUpdateQualityWhenQualityIsGreaterZero()
        {
            Item item = new Item("Aged brie", 10, 1, "10/10/2000", "10/10/2004");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1

            var actual = item.Quality;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        /* Debe Retornar la calidad del articulo,
         * cuando el articulo es menor a ( 50 ).
         * con los datos validos para el Articulo "AGED BRIE".*/
        public void TestShouldUpdateQualityWhenQualityIsLessFifty()
        {
            Item item = new Item("Aged brie", 10, 40, "10/10/2000", "10/10/2004");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");
            systemApp.UpdateQuality(); //day 1

            var actual = item.Quality;
            var expected = 41;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        /* Debe Retornar Exception,
         * cuando el articulo es no esta en el rango de ( 0 ) a ( 50 ).  when the quality is not in the range of 15 to 50
         * con los datos invalidos".*/
        public void TestShouldExceptionWhenQualityIsNotInRangeOfZeroToFifty()
        {
            Item item = new Item("Aged brie", 10, 70, "10/10/2000", "10/10/2004");
            List<Item> items = new List<Item>()
            {
                item
            };
            SystemApp systemApp = new SystemApp(items, "10/10/2006");

            var actual = Assert.ThrowsException<Exception>(() => systemApp.UpdateQuality()).Message;
            var expected = "Quality is not in the allowed range";
            Assert.AreEqual(expected, actual);
        }
    }
}
