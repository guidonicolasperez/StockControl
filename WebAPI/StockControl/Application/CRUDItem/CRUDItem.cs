using Persistence;
using Domain;
using System.Collections.Generic;


namespace Application
{
    public class CRUDItem : ICRUDItem
    {
        private readonly IDataBaseService _dataBase;

        public CRUDItem()
        {
            this._dataBase = new DataBaseServices();
        }

        public bool createItem(Item myItem)
        {
            return _dataBase.createItem(myItem.description, myItem.stock, myItem.stockAlert);
        }

        public List<Item> getAllItems()
        {
            return _dataBase.getAllItems();
        }

        public Item getItem(string description)
        {
            return _dataBase.getItem(description);
        }

        public Item addStockToItem(string description, int quantity)
        {
            Item myItem;
            bool updateOk;
            myItem = _dataBase.getItem(description);

            myItem.description = description;
            myItem.stock = myItem.stock + quantity;


            updateOk = _dataBase.updateItem(myItem.id, myItem.description, myItem.stock, myItem.stockAlert);

            if (updateOk)
            {
                return _dataBase.getItem(myItem.description);
            }
            else
            {
                return null;
            }

        }

        public Item takeStockFromItem(string description, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public Item deleteItem(string itemDescription)
        {
            throw new System.NotImplementedException();
        }
    }
}
