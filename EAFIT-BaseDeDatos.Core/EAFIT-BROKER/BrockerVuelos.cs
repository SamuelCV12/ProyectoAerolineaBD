using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{
    public class BrokerVuelos
    {
        MySqlConnection Connection;
        BrokerConnection InsConnection = new BrokerConnection();

        /// <summary>
        /// Método que inserta un vuelo en la base de datos 
        /// </summary> 
        internal bool InsertarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacInsert = new MySqlCommand();

            transacInsert.CommandText = string.Format(
                "CALL InsertarVuelo({0}, {1}, {2}, '{3}', '{4}');",
                ValuesVuelo.GetValueOrDefault("id_ruta"),
                ValuesVuelo.GetValueOrDefault("id_estado_vuelo"),
                ValuesVuelo.GetValueOrDefault("id_avion"),
                ValuesVuelo.GetValueOrDefault("fecha_hora_salida"),
                ValuesVuelo.GetValueOrDefault("fecha_hora_llegada")
            );

            transacInsert.Connection = Connection;
            int ResultInsert = transacInsert.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return ResultInsert > 0;
        }

        /// <summary>
        /// Método que consulta la información de un vuelo por su ID
        /// </summary>
        internal Dictionary<string, string> ConsultarVuelo(int idVuelo)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacConsulta = new MySqlCommand();
            transacConsulta.CommandText = string.Format(
                "SELECT id_vuelo, id_ruta, id_estado_vuelo, id_avion, fecha_hora_salida, fecha_hora_llegada FROM vuelos WHERE id_vuelo = {0};",
                idVuelo
            );
            transacConsulta.Connection = Connection;

            Dictionary<string, string> ReturnVuelo = new Dictionary<string, string>();
            MySqlDataReader ResultVuelo = transacConsulta.ExecuteReader();

            while (ResultVuelo.Read())
            {
                ReturnVuelo.Add("id_vuelo", ResultVuelo["id_vuelo"].ToString());
                ReturnVuelo.Add("id_ruta", ResultVuelo["id_ruta"].ToString());
                ReturnVuelo.Add("estado_vuelo", ResultVuelo["id_estado_vuelo"].ToString());
                ReturnVuelo.Add("id_avion", ResultVuelo["id_avion"].ToString());
                ReturnVuelo.Add("fecha_hora_salida", ResultVuelo["fecha_hora_salida"].ToString());
                ReturnVuelo.Add("fecha_hora_llegada", ResultVuelo["fecha_hora_llegada"].ToString());
            }

            InsConnection.CloseConnection(Connection);
            return ReturnVuelo;
        }

        /// <summary>
        /// Método que actualiza un vuelo en la base de datos 
        /// </summary> 
        internal bool ActualizarVuelo(Dictionary<string, string> ValuesVuelo)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacUpdate = new MySqlCommand();
            transacUpdate.Connection = Connection;

            transacUpdate.CommandText = "CALL ActualizarVuelo(@id_vuelo, @id_ruta, @id_estado_vuelo, @id_avion, @fecha_salida, @fecha_llegada)";
            transacUpdate.Parameters.AddWithValue("@id_vuelo", ValuesVuelo.GetValueOrDefault("id_vuelo"));
            transacUpdate.Parameters.AddWithValue("@id_ruta", ValuesVuelo.GetValueOrDefault("id_ruta"));

            string estadoValor = ValuesVuelo.ContainsKey("estado") && ValuesVuelo["estado"].ToLower() == "activo" ? "1" : "2";
            transacUpdate.Parameters.AddWithValue("@id_estado_vuelo", estadoValor);

            transacUpdate.Parameters.AddWithValue("@id_avion", ValuesVuelo.GetValueOrDefault("id_avion"));
            transacUpdate.Parameters.AddWithValue("@fecha_salida", ValuesVuelo.GetValueOrDefault("fecha_hora_salida"));
            transacUpdate.Parameters.AddWithValue("@fecha_llegada", ValuesVuelo.GetValueOrDefault("fecha_hora_llegada"));

            int ResultUpdate = transacUpdate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return ResultUpdate > 0;
        }

        /// <summary>
        /// Método que inactiva un vuelo (cambia su estado a inactivo)
        /// </summary>
        internal bool InactivarVuelo(int idVuelo)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacInactivar = new MySqlCommand();
            transacInactivar.CommandText = string.Format(
                "UPDATE vuelos SET id_estado_vuelo = 2 WHERE ID_vuelo = {0};",
                idVuelo
            );
            transacInactivar.Connection = Connection;
            int ResultInactivar = transacInactivar.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            return ResultInactivar > 0;
        }
    }
}
