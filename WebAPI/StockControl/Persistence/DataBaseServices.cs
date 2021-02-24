using Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace Persistence
{

    public class DataBaseServices : IDataBaseService
    {
        private SqlConnection SQLConnection;

        // Con el constructor ya levanto la sqlConneccion para usarla en todos los metodos.
        public DataBaseServices()
        {
            // Levanto la conexion con mi Base de datos y le meto en una variable global para llamarla desde cada metodo.
            this.SQLConnection = Connection.GetConection();
        }

        // Este metodo se encarga de añadir el Item. Validaciones: Si ya existe.
        public bool createItem(string description, int stock, int stockAlert)
        {
            bool ok = false;
            int filasAfectadas = -1;

            // Levanto la conexion con mi Base de datos.
            SqlConnection SQLConnection = Connection.GetConection();

            // Lo primero que hago es ver si el producto que voy a ingresar ya existe.
            // Preparo la Query. Le pregunto si tiene filas con la descripcion de ese producto.
            SqlCommand sqlCommand = new SqlCommand(
                "SELECT COUNT(itemDescription) 'quantity' FROM ITEM WHERE itemDescription = '" + description + "'", SQLConnection);

            // Intento ejecutar la Query. Si no tengo ninguno, agrego el Item.
            try
            {
                // Abro la conexion con la base de datos, ejecuto la query, pongo los datos en el data reader y cierro la conexion.

                SQLConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                dataReader.Read();

                int quantity = 0;
                quantity = (int)dataReader["quantity"];

                SQLConnection.Close();

                if (quantity >= 1)
                {
                    return ok;
                }
                else
                {
                    // Preparo la query.
                    SqlCommand sqlCommand2 = new SqlCommand(
                        "INSERT INTO ITEM VALUES ('" + description + "', " + stock + ", " + stockAlert + ")"
                        , SQLConnection);

                    try
                    {
                        SQLConnection.Open();

                        filasAfectadas = sqlCommand2.ExecuteNonQuery();

                        ok = (filasAfectadas >= 1) ? true : false;

                        SQLConnection.Close();
                        return ok;

                    }
                    catch (Exception e)
                    {
                        return ok;
                    }


                }

            }
            catch (Exception e)
            {
                return ok;
            }

        }

        public List<Item> getAllItems()
        {
            // Creo la lista que hoy a ir llenando y voy a devolver.
            List<Item> Items = new List<Item>();

            // Preparo la Query.
            SqlCommand command = new SqlCommand("SELECT * FROM ITEM", SQLConnection);

            try
            {

                // Abro la conexion con la base de datos, ejecuto la query y pongo los datos en el data reader.
                SQLConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                // Meto un ciclo que va leyendo linea por linea de los resultados de la query ( El Read() es un boolean que es true si tiene algo.
                while (dataReader.Read())
                {
                    Item myItem = new Item(
                       (int)dataReader["idItem"],
                       (string)dataReader["itemDescription"],
                       (int)dataReader["stock"],
                       (int)dataReader["stockAlert"]);

                    Items.Add(myItem);
                }

                // Cierro la conexion.
                SQLConnection.Close();

            }
            catch (System.IO.IOException e)
            {

            }

            finally
            {
                SQLConnection.Close();
            }

            return Items;

        }

        public Item getItem(string description)
        {
            Item myItem = null;

            try
            {
                // Preparo la Query.
                SqlCommand command = new SqlCommand("SELECT * FROM ITEM WHERE itemDescription = '" + description + "' ", SQLConnection);

                // Abro la conexion con la base de datos, ejecuto la query y pongo los datos en el data reader.
                SQLConnection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    myItem = new Item(
                               (int)dataReader["idItem"],
                               (string)dataReader["itemDescription"],
                               (int)dataReader["stock"],
                               (int)dataReader["stockAlert"]);

                }

                // Cierro la conexion.
                SQLConnection.Close();

            }
            catch (System.IO.IOException e)
            {

            }

            return myItem;

        }

        public bool deleteItem(string itemDescription)
        {
            bool ok = false;
            // Levanto la conexion con mi Base de datos.
            SqlConnection SQLConnection = Connection.GetConection();

            // Lo primero que hago es ver si el producto que voy a ingresar ya existe.
            // Preparo la Query. Le pregunto si tiene filas con la descripcion de ese producto.
            SqlCommand sqlCommand = new SqlCommand(
                "SELECT COUNT(itemDescription) 'quantity' FROM ITEM WHERE itemDescription = '" + itemDescription + "'", SQLConnection);

            // Intento ejecutar la Query. Si no tengo ninguno, agrego el Item.
            try
            {
                // Abro la conexion con la base de datos, ejecuto la query, pongo los datos en el data reader y cierro la conexion.

                SQLConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                dataReader.Read();

                int quantity = 0;
                quantity = (int)dataReader["quantity"];

                SQLConnection.Close();
            }
            catch (Exception e)
            {
                return ok;
            }

            return ok;
        }

        // Este metodo se encarga de actualizar las columnas del Item. Validaciones: Que los parametros no sean null.
        public bool updateItem(int id, string description, int stock, int stockAlert)
        {
            bool ok = false;
            int filasAfectadas = -1;

            //Valido que los parametros no sean null.
            if (id != 0 && description != "" && description != null)
            {
                // Levanto la conexion con mi Base de datos y preparo la query.
                SqlConnection SQLConnection = Connection.GetConection();

                SqlCommand sqlCommand = new SqlCommand(
                    "UPDATE ITEM SET ITEMDESCRIPTION = '" + description + "', STOCK = " + stock + ", STOCKALERT = " + stockAlert + " WHERE IDITEM = " + id, SQLConnection);

                // Abro la conexion con la base de datos, ejecuto la query, pongo los datos en el data reader y cierro la conexion.
                try
                {
                    SQLConnection.Open();

                    filasAfectadas = sqlCommand.ExecuteNonQuery();

                    ok = (filasAfectadas >= 1) ? true : false;

                    SQLConnection.Close();

                    return ok;

                }
                catch (Exception e)
                {

                }

            }
            return ok;
        }

        public bool newConsumption(int id, DateTime dateConsumed, int quantityConsumed)
        {
            throw new NotImplementedException();
        }

        public bool deteleConsumptions(int itemID)
        {
            throw new NotImplementedException();
        }
    }
}
