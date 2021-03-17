using System;

namespace Domain
{
    public class ItemConsumed
    {
        public int id { get; set; }
        public int itemID { get; set; }
        public DateTime dateConsumed { get; set; }
        public int quantityConsumed { get; set; }

        public ItemConsumed(int idItem, int quantityConsumed)
        {
            this.itemID = idItem;
            this.dateConsumed = DateTime.Now;
            this.quantityConsumed = quantityConsumed;
        }

        public ItemConsumed(int idItem, int idConsumed, int quantityConsumed)
        {
            this.itemID = idItem;
            this.id = idConsumed;
            this.dateConsumed = DateTime.Now;
            this.quantityConsumed = quantityConsumed;
        }

    }

}
