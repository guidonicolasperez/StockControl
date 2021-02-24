using System;
using Microsoft.Data.SqlClient;

namespace Persistence
{
    // El fin de esta clase es crear la conexion sql.
    public static class Connection
    {
        public static SqlConnection GetConection()
        {
            // Aca creo la ruta de conexion, seteo el servidor al cual se va a conectar, a que base de datos y el tipo de autenticacion.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "MAIN",
                InitialCatalog = "StockControl",
                IntegratedSecurity = true
            };

            // Creo la conexion con la cadena anterior y la devuelvo.
            SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);

            return sqlConnection;
        }
    }
}