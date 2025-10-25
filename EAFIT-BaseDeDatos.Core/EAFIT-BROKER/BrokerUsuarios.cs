using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace EAFIT_BaseDeDatos.Core.EAFIT_BROKER
{
    class BrokerUsuarios
    {

        MySqlConnection Connection;
        BrokerConnection InsConnection = new BrokerConnection();
        /// <summary>
        /// Metodo que inserta un usuario en la base de datos 
        /// </summary> 
        /// <returns></returns>
        internal bool InsertarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacLogeo = new MySqlCommand();
            transacLogeo.CommandText = string.Format("CALL  InsertarUsuario('{0}','{1}','{2}','{3}','{4}',{5},{6});", ValuesUsuario.GetValueOrDefault("Name_User"),
                ValuesUsuario.GetValueOrDefault("LName_User"), ValuesUsuario.GetValueOrDefault("Email"), ValuesUsuario.GetValueOrDefault("UserApps"),
                ValuesUsuario.GetValueOrDefault("Password"), ValuesUsuario.GetValueOrDefault("Client_Type"), ValuesUsuario.GetValueOrDefault("State_user"));
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
        /// <param name="UserSearch"></param>
        /// <returns></returns>
        internal Dictionary<string, string> ValidarUsuario(string UserSearch)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacLogeo = new MySqlCommand();
            transacLogeo.CommandText = string.Format("select Name_User, LName_User, Email, Client_Type, State_user from users where UserApps = '{0}'", UserSearch);
            transacLogeo.Connection = Connection;
            Dictionary<string, string> ReturnLogin = new Dictionary<string, string>();
            MySqlDataReader ResultLogin = transacLogeo.ExecuteReader();
            while (ResultLogin.Read())
            {
                ReturnLogin.Add("Name_User", ResultLogin[0].ToString());
                ReturnLogin.Add("LName_User", ResultLogin[1].ToString());
                ReturnLogin.Add("Email", ResultLogin[2].ToString());
                if (ResultLogin[3].ToString() == "1")
                    ReturnLogin.Add("State_user", "Activo");
                else
                    ReturnLogin.Add("State_user", "Inactivo");
                if (ResultLogin[4].ToString() == "1")
                    ReturnLogin.Add("Client_Type", "Cliente");
                else if (ResultLogin[4].ToString() == "2")
                    ReturnLogin.Add("Client_Type", "Usuario");
                else
                    ReturnLogin.Add("Client_Type", "Otro...");
            }
            InsConnection.CloseConnection(Connection);
            return ReturnLogin;
        }


        /// <summary>
        /// Metodo que actualiza un usuario en la base de datos 
        /// </summary> 
        /// <returns></returns>
        internal bool ActualizarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacUpdate = new MySqlCommand();
            transacUpdate.CommandText = string.Format("CALL  ActualizarUsuario( {0} , {1} , {2} , {3} , {4} ,{5},{6});",
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("Name_User")) ? null : string.Concat("'", ValuesUsuario.GetValueOrDefault("Name_User"), "'"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("LName_User")) ? null : string.Concat("'", ValuesUsuario.GetValueOrDefault("LName_User"), "'"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("Email")) ? null : string.Concat("'", ValuesUsuario.GetValueOrDefault("Email"), "'"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("UserApps")) ? null : string.Concat("'", ValuesUsuario.GetValueOrDefault("UserApps"), "'"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("Password")) ? null : string.Concat("'", ValuesUsuario.GetValueOrDefault("Password"), "'"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("Client_Type")) ? null : ValuesUsuario.GetValueOrDefault("Client_Type"),
                    string.IsNullOrEmpty(ValuesUsuario.GetValueOrDefault("State_user")) ? null : ValuesUsuario.GetValueOrDefault("State_user"));
            transacUpdate.Connection = Connection;
            int ResultLogin = transacUpdate.ExecuteNonQuery();
            InsConnection.CloseConnection(Connection);
            if (ResultLogin > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metodo que inactiva un usuario en la base de datos 
        /// </summary> 
        /// <returns></returns>
        internal bool InactivarUsuario(string UserInactivate)
        {
            Connection = InsConnection.OpenConnection();
            MySqlCommand transacInactivate = new MySqlCommand();
            transacInactivate.CommandText = string.Format("update users set State_user=2  where UserApps='{0}';", UserInactivate);
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
