using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public string CreationDate { get; set; }
        public string ExpirationDate { get; set; }

        public Item(string name, int sellIn, int quality, string creationDate, string expirationDate)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
            this.CreationDate = creationDate;
            this.ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}

