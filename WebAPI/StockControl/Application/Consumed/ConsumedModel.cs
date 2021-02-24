using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ConsumedModel
    {
        private int idItem { get; set; }
        private int idConsumed { get; set; }
        private DateTime dateConsumed { get; set; }
        private int quantityConsumed { get; set; }


        public ConsumedModel(int idItem, int idConsumed, int quantityConsumed)
        {
            this.idItem = idItem;
            this.idConsumed = idConsumed;
            this.dateConsumed = DateTime.Now;
            this.quantityConsumed = quantityConsumed;
        }

    }

}
