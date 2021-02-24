using System.Collections.Generic;
using Domain;

namespace Application
{
    public interface ICRUDItem
    {
        public List<Item> getAllItems();

        public Item getItem(string itemDescription);

        public bool createItem(Item myItem);

        public Item addStockToItem(string itemDescription, int quantity);

        public Item takeStockFromItem(string itemDescription, int quantity);

        public Item deleteItem(string itemDescription);

    }
}
