using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{

    public class BrokerAviones
    {
        MySqlConnection Connection;
        BrokerConnection InsConnection = new BrokerConnection();
        /// <summary>
        /// Metodo que inserta un avion en la base de datos 
        /// </summary> 
        /// <returns></returns>
        internal bool InsertarAvion(Dictionary<string, string> ValuesAvion)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacLogeo = new MySqlCommand();
            transacLogeo.CommandText = string.Format("CALL InsertarAvion({0}, '{1}', {2}, '{3}', '{4}', '{5}');",
                ValuesAvion.GetValueOrDefault("Estado_avion"),
                ValuesAvion.GetValueOrDefault("Referencia"),
                ValuesAvion.GetValueOrDefault("Aforo_maximo"),
                ValuesAvion.GetValueOrDefault("Size"),
                ValuesAvion.GetValueOrDefault("fecha_ensamblaje_avion"),
                ValuesAvion.GetValueOrDefault("matricula")
 );
            transacLogeo.Connection = Connection;
            int ResultLogin = transacLogeo.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);
            if (ResultLogin > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// metodo para consultar la información con el nombre de usuario
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        internal Dictionary<string, string> ValidarAvion(string matricula)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacLogeo = new MySqlCommand();
            transacLogeo.CommandText = string.Format("select Referencia, Aforo_maximo, Size, fecha_ensamblaje_avion, matricula, Estado_avion from Aviones where matricula = '{0}'", matricula);
            transacLogeo.Connection = Connection;
            Dictionary<string, string> ReturnAvion = new Dictionary<string, string>(); 
            MySqlDataReader ResultAvion = transacLogeo.ExecuteReader(); 

            while (ResultAvion.Read())
            {
                ReturnAvion.Add("Referencia", ResultAvion[0].ToString());
                ReturnAvion.Add("Aforo_maximo", ResultAvion[1].ToString());
                ReturnAvion.Add("Size", ResultAvion[2].ToString());
                ReturnAvion.Add("fecha_ensamblaje_avion", ResultAvion[3].ToString());
                ReturnAvion.Add("matricula", ResultAvion[4].ToString());
                string estado = ResultAvion[5].ToString();
                if (estado == "1")
                    ReturnAvion.Add("Estado_avion", "Activo");
                else if (estado == "2")
                    ReturnAvion.Add("Estado_avion", "Inactivo");
                else
                    ReturnAvion.Add("Estado_avion", "Desconocido");

            }
            InsConnection.CloseConnection(Connection);
            return ReturnAvion;
        }
        /// <summary>
        /// Metodo que actualiza un usuario en la base de datos 
        /// </summary> 
        /// <returns></returns>
        internal bool ActualizarAvion(Dictionary<string, string> ValuesAviones)
        {
            MySqlConnection Connection = InsConnection.OpenConnection();
            MySqlCommand transacUpdate = new MySqlCommand();
            transacUpdate.CommandText = string.Format("CALL ActualizarAvion( {0}, {1}, {2}, {3}, {4}, {5} );",

                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("Referencia")) ? "NULL" : string.Concat("'", ValuesAviones.GetValueOrDefault("Referencia"), "'"),
                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("Aforo_maximo")) ? "NULL" : ValuesAviones.GetValueOrDefault("Aforo_maximo"),
                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("Size")) ? "NULL" : string.Concat("'", ValuesAviones.GetValueOrDefault("Size"), "'"),
                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("fecha_ensamblaje_avion")) ? "NULL" : string.Concat("'", ValuesAviones.GetValueOrDefault("fecha_ensamblaje_avion"), "'"),
                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("Estado_avion")) ? "NULL" : ValuesAviones.GetValueOrDefault("Estado_avion"),
                string.IsNullOrEmpty(ValuesAviones.GetValueOrDefault("matricula")) ? "NULL" : string.Concat("'", ValuesAviones.GetValueOrDefault("matricula"), "'")
            );
            transacUpdate.Connection = Connection;
            int ResultLogin = transacUpdate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);
            if (ResultLogin > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo que inactiva un Avion en la base de datos 
        /// </summary> 
        /// <returns></returns>
        /// <summary>
        /// <param name="matricula">Matrícula del avión a inactivar.</param>

        internal bool InactivarAvion(string matricula)
        {
            MySqlConnection Connection = InsConnection.OpenConnection();
            MySqlCommand transacInactivate = new MySqlCommand();
            transacInactivate.CommandText = string.Format("update Aviones set Estado_Avion=2 where Matricula='{0}';", matricula);
            transacInactivate.Connection = Connection;
            int ResultInactivate = transacInactivate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);

            if (ResultInactivate > 0)
                return true;
            else
                return false;
        }

    }
}