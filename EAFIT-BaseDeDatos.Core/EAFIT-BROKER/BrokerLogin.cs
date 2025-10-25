using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{
    class BrokerLogin
    {

        MySqlConnection Connection;
        BrokerConnection InsConnection = new BrokerConnection();
        /// <summary>
        /// Logeo de la aplicación
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal List<string> ValidarLogin(string usuario)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacLogeo = new MySqlCommand();
            transacLogeo.CommandText = string.Format("Select Password   from users where UserApps = '{0}' ", usuario);
            transacLogeo.Connection = Connection;
            List<string> ReturnLogin = new List<string>();
            //Dictionary<string, string>  = new Dictionary<string, string>();
            //El ExecuteNonQuery() para insert, delete y update
           // int cuantos = transacLogeo.ExecuteNonQuery();
            //ExecuteReader para select 
            MySqlDataReader ResultLogin = transacLogeo.ExecuteReader();
            while (ResultLogin.Read())
            { 
                ReturnLogin.Add(ResultLogin[0].ToString());
            }
            InsConnection.CloseConnection(Connection);
            return ReturnLogin;


        }
    }
}
