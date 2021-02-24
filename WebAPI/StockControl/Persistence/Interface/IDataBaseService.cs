using System;
using System.Collections.Generic;
using Domain;

namespace Persistence
{
    public interface IDataBaseService
    {
        public bool createItem(string itemDescription, int stock, int stockAlert);

        public List<Item> getAllItems();

        public Item getItem(string itemDescription);

        public bool updateItem(int id, string description, int stock, int stockAlert);

        public bool deleteItem(string itemDescription);

        public bool newConsumption(int itemID, DateTime dateConsumed, int quantityConsumed);

        public bool deteleConsumptions(int itemID);

    }
}
