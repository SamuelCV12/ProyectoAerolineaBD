using EAFIT_BaseDeDatos.Core.EAFIT_BROKER;
using EAFIT_BaseDeDatos.Core.EAFIT_MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAFIT_BaseDeDatos.Core.EAFIT_FACADE
{
    public class FacadeUsuarios
    {

        public bool InsertarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            EAFIT_MANAGER.ManagerUsuarios InsertUser = new EAFIT_MANAGER.ManagerUsuarios();
            return InsertUser.InsertarUsuario(ValuesUsuario);

        }
        public bool ActualizarUsuario(Dictionary<string, string> ValuesUsuario)
        {
            EAFIT_MANAGER.ManagerUsuarios InsertUser = new EAFIT_MANAGER.ManagerUsuarios();
            return InsertUser.ActualizarUsuario(ValuesUsuario);

        }
        public bool InactivarUsuario(string ValuesUsuario)
        {
            EAFIT_MANAGER.ManagerUsuarios InsertUser = new EAFIT_MANAGER.ManagerUsuarios();
            return InsertUser.InactivarUsuario(ValuesUsuario);

        }

        public Dictionary<string, string> ValidarUsuario(string UserSearch)
        {

            ManagerUsuarios ValidateUser = new ManagerUsuarios();
            return ValidateUser.ValidarUsuario(UserSearch);
        }
    }
}
