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
            Item myItem;
            ItemConsumed myItemConsumed;
            bool updateOk;

            myItem = _dataBase.getItem(description);
            myItemConsumed = new ItemConsumed(myItem.id, quantity);

            if (myItem.stock > quantity)
            {
                myItem.stock = myItem.stock - quantity;

                updateOk = _dataBase.updateItem(myItem.id, myItem.description, myItem.stock, myItem.stockAlert);


                if (updateOk)
                {
                    updateOk = _dataBase.newConsumption(myItemConsumed);

                    if (updateOk)
                    {
                        return _dataBase.getItem(myItem.description);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public Item deleteItem(string itemDescription)
        {
            throw new System.NotImplementedException();
        }
    }
}
