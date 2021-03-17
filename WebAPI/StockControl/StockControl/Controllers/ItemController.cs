using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace StockControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // GET: api/Item/GetAllItems/
        [HttpGet("GetAllItems")]
        public IEnumerable<Item> GetAllItems()
        {
            CRUDItem CrudItem = new CRUDItem();

            return CrudItem.getAllItems();
        }

        // GET: api/Item/GetItem/{id}
        [HttpGet("GetItem/{id}")]
        public Item GetItem(string id)
        {
            CRUDItem CrudItem = new CRUDItem();

            return CrudItem.getItem(id);
        }

        // POST: api/Item/add
        [HttpPost("add")]
        public void add([FromBody] Item item)
        {

           CRUDItem CrudItem = new CRUDItem();

           CrudItem.createItem(item);
        }

        // Patch: api/Item/addStockToItem/{id}/{stock}
        [HttpPatch("addStockToItem/{description}/{stock}")]
        public Item addaddStockToItem(string description, int stock)
        {
            CRUDItem CrudItem = new CRUDItem();

            return CrudItem.addStockToItem(description, stock);
        }

        [HttpPatch("takeStockFromItem/{description}/{stock}")]
        public Item takeStockFromItem(string description, int stock)
        {
            CRUDItem CrudItem = new CRUDItem();

            return CrudItem.takeStockFromItem(description, stock);
        }

        // DELETE: api/Item/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public void Delete(string id)
        {
            CRUDItem CrudItem = new CRUDItem();

            CrudItem.deleteItem(id);
        }

     
    }
}
