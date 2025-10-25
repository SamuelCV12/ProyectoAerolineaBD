using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{
    class BrokerRutas
    {
        MySqlConnection Connection;
        BrokerConnection InsConnection = new BrokerConnection();

        /// <summary>
        /// Inserta una nueva ruta en la base de datos.
        /// </summary>
        /// <param name="ValuesRuta">Diccionario con los valores de la ruta.</param>
        /// <returns>True si la inserción fue exitosa, False en caso contrario.</returns>
        internal bool InsertarRuta(Dictionary<string, string> ValuesRuta)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacInsert = new MySqlCommand();

            transacInsert.CommandText = string.Format(
                "CALL InsertarRuta({0}, {1}, {2}, {3});",
                ValuesRuta.GetValueOrDefault("id_ciudad_origen"),
                ValuesRuta.GetValueOrDefault("id_ciudad_destino"),
                ValuesRuta.GetValueOrDefault("estado_ruta"),
                ValuesRuta.GetValueOrDefault("precio_base").Replace(",", ".")
            );

            transacInsert.Connection = Connection;
            int Result = transacInsert.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return Result > 0;
        }


        /// <summary>
        /// Consulta la información de una ruta por su ID.
        /// </summary>
        /// <param name="idRuta">ID de la ruta.</param>
        /// <returns>Diccionario con los datos de la ruta.</returns>
        internal Dictionary<string, string> ConsultarRuta(int idRuta)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacSelect = new MySqlCommand();
            transacSelect.CommandText = string.Format(
                "SELECT ID_ruta, id_ciudad_origen, id_ciudad_destino, estado_ruta, precio_base " +
                "FROM Rutas WHERE ID_ruta = {0};", idRuta);

            transacSelect.Connection = Connection;
            Dictionary<string, string> ReturnRuta = new Dictionary<string, string>();
            MySqlDataReader Result = transacSelect.ExecuteReader();

            if (Result.Read())
            {
                ReturnRuta.Add("ID_ruta", Result["ID_ruta"].ToString());
                ReturnRuta.Add("id_ciudad_origen", Result["id_ciudad_origen"].ToString());
                ReturnRuta.Add("id_ciudad_destino", Result["id_ciudad_destino"].ToString());
                ReturnRuta.Add("estado_ruta", Result["estado_ruta"].ToString());
                ReturnRuta.Add("precio_base", Result["precio_base"].ToString());
            }

            InsConnection.CloseConnection(Connection);
            return ReturnRuta;
        }

        /// <summary>
        /// Actualiza la información de una ruta existente.
        /// </summary>
        /// <param name="ValuesRuta">Diccionario con los valores a actualizar.</param>
        /// <returns>True si se actualizó correctamente, False en caso contrario.</returns>
        internal bool ActualizarRuta(Dictionary<string, string> ValuesRuta)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacUpdate = new MySqlCommand(
                "UPDATE Rutas SET id_ciudad_origen = @origen, id_ciudad_destino = @destino, estado_ruta = @estado, precio_base = @precio WHERE ID_ruta = @idRuta;",
                Connection
            );

            transacUpdate.Parameters.AddWithValue("@origen", ValuesRuta.GetValueOrDefault("id_ciudad_origen"));
            transacUpdate.Parameters.AddWithValue("@destino", ValuesRuta.GetValueOrDefault("id_ciudad_destino"));
            transacUpdate.Parameters.AddWithValue("@estado", ValuesRuta.GetValueOrDefault("estado_ruta"));
            transacUpdate.Parameters.AddWithValue("@precio", ValuesRuta.GetValueOrDefault("precio_base"));
            transacUpdate.Parameters.AddWithValue("@idRuta", ValuesRuta.GetValueOrDefault("ID_ruta"));

            int Result = transacUpdate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return Result > 0;
        }

        /// <summary>
        /// Inactiva una ruta (por ejemplo, cambiando el estado).
        /// </summary>
        /// <param name="idRuta">ID de la ruta a inactivar.</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
        internal bool InactivarRuta(int idRuta)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacInactivate = new MySqlCommand();

            // Por ejemplo, asumimos que estado_ruta = 2 significa "Inactiva"
            transacInactivate.CommandText = string.Format(
                "UPDATE Rutas SET estado_ruta = 2 WHERE ID_ruta = {0};", idRuta);

            transacInactivate.Connection = Connection;
            int Result = transacInactivate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return Result > 0;
        }
    }
}
