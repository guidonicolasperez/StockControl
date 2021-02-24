using System;

namespace Domain
{
    public class Consumed
    {
        private int id { get; set; }
        private int itemID { get; set; }
        private DateTime dateConsumed { get; set; }
        private int quantityConsumed { get; set; }


        public Consumed(int idItem, int idConsumed, int quantityConsumed)
        {
            this.itemID = idItem;
            this.id = idConsumed;
            this.dateConsumed = DateTime.Now;
            this.quantityConsumed = quantityConsumed;
        }

    }

}
