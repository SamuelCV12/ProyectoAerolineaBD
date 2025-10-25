using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{
    class BrokerConnection
    {
        /// <summary>
        /// Apertura de conexion a la base de datos
        /// </summary>
        internal MySqlConnection OpenConnection()
        {
            MySqlConnection con;
            
            try
            {

                string StringConnection = string.Empty;//Environment.GetEnvironmentVariable("Conexion");//"server=127.0.0.1;uid=root;pwd=12345678;database=BaseDeDatos";
                //StringConnection = Environment.GetEnvironmentVariable("Connection");
                //StringConnection = "server=127.0.0.1;uid=root;pwd=12345678;database=BaseDeDatos";
                StringConnection = "cwBlAHIAdgBlAHIAPQAxADIANwAuADAALgAwAC4AMQA7AHUAaQBkAD0AcgBvAG8AdAA7AHAAdwBkAD0AMQAyADMANAA1ADYANwA4ADsAZABhAHQAYQBiAGEAcwBlAD0AQgBhAHMAZQBEAGUARABhAHQAbwBzAA==";
                if (!string.IsNullOrEmpty(StringConnection))
                    StringConnection = DesEncriptar(StringConnection);
                con = new MySqlConnection(StringConnection);
                //con.ConnectionString = StringConnection;
                con.Open();

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return con;

        }
        /// <summary>
        /// Cierre de conexion existente
        /// </summary>
        /// <param name="Connection"></param>
        internal void CloseConnection(MySqlConnection Connection)
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }



        /// <summary>
        /// encripta una cadena
        /// </summary>
        /// <param name="cadenaAencriptar"></param>
        /// <returns></returns>
        internal string Encriptar(string cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        internal string DesEncriptar(string cadenaAdesencriptar)
        {
            string result = string.Empty;

            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);

            return result;
        }

    }
}
