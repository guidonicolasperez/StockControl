using System;


namespace Domain
{
    public class Item
    {
        public int id { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int stockAlert { get; set; }


        public Item()
        {
        }

        public Item(int id, String description, int stock)
        {
            this.id = id;
            this.description = description;
            this.stock = stock;
        }

        public Item(int id, String description, int stock, int stockAlert)
        {
            this.id = id;
            this.description = description;
            this.stock = stock;
            this.stockAlert = stockAlert;
        }


        public string toString()
        {
            return this.id + " - " + this.description + " - " + this.stock + " - " + this.stockAlert;
        }

    }

}