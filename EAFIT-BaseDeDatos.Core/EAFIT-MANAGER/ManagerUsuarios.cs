using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_MANAGER
{
    class ManagerUsuarios
    {

        internal bool InsertarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            BrokerUsuarios InsertUser = new BrokerUsuarios();
            ChangeValuesStateAndType(ValuesUsuario);

            return InsertUser.InsertarUsuario(ValuesUsuario);

        }
        internal bool ActualizarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            BrokerUsuarios UpdateUser = new BrokerUsuarios();
            ChangeValuesStateAndType(ValuesUsuario);

            return UpdateUser.ActualizarUsuario(ValuesUsuario);

        }
        internal bool InactivarUsuario(string ValuesUsuario)
        {
            BrokerUsuarios InactivateUser = new BrokerUsuarios(); 
            return InactivateUser.InactivarUsuario(ValuesUsuario);

        }
        internal Dictionary<string, string> ValidarUsuario(string UserSearch)
        {

            BrokerUsuarios ValidateUser = new BrokerUsuarios();
            return ValidateUser.ValidarUsuario(UserSearch);
        }
        private static void ChangeValuesStateAndType(Dictionary<string, string> ValuesUsuario)
        {
            string Estado = ValuesUsuario.GetValueOrDefault("State_user");
            string Tipo = ValuesUsuario.GetValueOrDefault("Client_Type");
            if (Estado == "Activo")
                ValuesUsuario["State_user"] = "1";
            else
                ValuesUsuario["State_user"] = "2";

            if (Tipo == "Cliente")
                ValuesUsuario["Client_Type"] = "1";
            else if (Tipo == "Usuario")
                ValuesUsuario["Client_Type"] = "2";
            else
                ValuesUsuario["Client_Type"] = "3";
        }



    }
}
