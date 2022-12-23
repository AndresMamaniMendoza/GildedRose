using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class SystemApp
    {
        public IList<Item> Items;
        public string actualDate;

        public SystemApp(IList<Item> Items, string actualDate)
        {
            this.Items = Items;
            this.actualDate = actualDate;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Quality < 50 && Items[i].Quality > 0)
                {
                    if (Items[i].Name == "Aged brie")
                    {
                        if (DateTimeHandler.CheckDateIfGreaterThanOtherDate(Items[i].ExpirationDate, Items[i].CreationDate) &&
                            DateTimeHandler.CheckDateIfLessThanOtherDate(Items[i].ExpirationDate, this.actualDate))
                        {
                            Items[i].Quality++;
                            var addDaysExpirationDate = DateTimeHandler.AddDays(Items[i].ExpirationDate, 1);
                            Items[i].ExpirationDate = addDaysExpirationDate;
                            var fewerDaysCreationDate = DateTimeHandler.SubtractDays(Items[i].CreationDate, 1);
                            Items[i].CreationDate = fewerDaysCreationDate;
                        }
                        if (DateTimeHandler.CheckDateIfGreaterThanOtherDate(Items[i].ExpirationDate, Items[i].CreationDate) &&
                            DateTimeHandler.CheckDateIfGreaterThanOtherDate(Items[i].ExpirationDate, this.actualDate))
                        {
                            Items[i].Quality += 2;
                            var addDaysExpirationDate = DateTimeHandler.AddDays(Items[i].ExpirationDate, 1);
                            Items[i].ExpirationDate = addDaysExpirationDate;
                            var fewerDaysCreationDate = DateTimeHandler.SubtractDays(Items[i].CreationDate, 1);
                            Items[i].CreationDate = fewerDaysCreationDate;
                        }
                        else
                        {
                            Console.WriteLine("not implemented");
                        }
                    }
                }
                //NOTA: Faltan agregar mas casos, pero hasta ahora se esta cumpliendo requerimientos.
                else
                {
                    throw new Exception("Quality is not in the allowed range");
                }
            }
        }

    }
}
